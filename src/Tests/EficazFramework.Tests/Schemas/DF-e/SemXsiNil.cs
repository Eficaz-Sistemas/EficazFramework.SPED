using System.Reflection;
using System.Xml.Serialization;
using EficazFramework.SPED.Schemas.NFSe.Nacional;

namespace EficazFramework.SPED.Schemas.DFe;

/// <summary>
/// Nenhum DF-e aceita <c>xsi:nil</c> (ex.: ADN da NFS-e: "E1235 - If the 'nillable' attribute is false in the schema,
/// the 'xsi:nil' attribute must not be present"). O <see cref="XmlSerializer"/> escreve <c>xsi:nil="true"</c> em toda
/// propriedade <see cref="Nullable{T}"/> nula, a menos que exista <c>ShouldSerialize{Nome}()</c> ou <c>{Nome}Specified</c>.
/// </summary>
public class SemXsiNil
{
    [Test]
    public void PropriedadesAnulaveisNaoSerializamNulo()
    {
        var assembly = typeof(DeclaracaoPrestacaoServico).Assembly;
        var semControle = new List<string>();

        foreach (var tipo in assembly.GetTypes().Where(t => t.IsClass && t.IsPublic))
        {
            foreach (var propriedade in tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                if (Nullable.GetUnderlyingType(propriedade.PropertyType) is null || !propriedade.CanRead || !propriedade.CanWrite)
                    continue;
                if (propriedade.IsDefined(typeof(XmlIgnoreAttribute)) || propriedade.IsDefined(typeof(XmlAttributeAttribute)) || propriedade.IsDefined(typeof(XmlTextAttribute)))
                    continue;
                if (!SerializadaComoXml(tipo, propriedade))
                    continue;
                if (tipo.GetMethod($"ShouldSerialize{propriedade.Name}", Type.EmptyTypes) is not null || tipo.GetProperty($"{propriedade.Name}Specified") is not null)
                    continue;

                semControle.Add($"{tipo.FullName}.{propriedade.Name}");
            }
        }

        semControle.Should().BeEmpty("propriedades Nullable<T> sem ShouldSerialize/Specified geram xsi:nil quando nulas");
    }

    [Test]
    public void DpsComCamposOpcionaisNulosNaoGeraXsiNil()
    {
        var dps = Mock.NFSe.PreencheNFSeNacionalDpsFake();
        dps.InfDPS.Prestador.RegimeTributario = new RegimeTributario { OptanteSimplesNacional = 1, RegimeEspecial = 0 }; // regApTribSN nulo
        dps.InfDPS.Valores.ValoresPrestacao.vReceb = null;

        var xml = dps.Serialize();

        xml.Should().NotContain("xsi:nil");
        xml.Should().NotContain("<regApTribSN");
        xml.Should().Contain("<opSimpNac>1</opSimpNac>");
    }

    /// <summary>Classe que participa de XML: tem <c>[XmlType]</c>/<c>[XmlRoot]</c> ou algum membro com <c>[XmlElement]</c>.</summary>
    private static bool SerializadaComoXml(Type tipo, PropertyInfo propriedade) =>
        tipo.IsDefined(typeof(XmlTypeAttribute)) || tipo.IsDefined(typeof(XmlRootAttribute))
        || propriedade.IsDefined(typeof(XmlElementAttribute))
        || tipo.GetProperties().Any(p => p.IsDefined(typeof(XmlElementAttribute)));
}
