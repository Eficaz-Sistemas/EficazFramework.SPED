using EficazFramework.SPED.Schemas.NFe;

namespace EficazFramework.SPED.Schemas.NFe.Tests;

/// <summary>Autorizados a acessar o XML da NF-e (grupo autXML): posição no leiaute, CNPJ ou CPF e leitura.</summary>
public class AutXml
{
    private static readonly System.Xml.Serialization.XmlSerializer Serializer = new(typeof(InformacoesNFe), "http://www.portalfiscal.inf.br/nfe");

    private static string Serializar(InformacoesNFe nfe)
    {
        using StringWriter writer = new();
        Serializer.Serialize(writer, nfe);
        return writer.ToString();
    }

    [Test]
    public void Autorizados_GravadosEntreEntregaEDet_ComCnpjOuCpf()
    {
        InformacoesNFe nfe = new() { LocalEntrega = new Local(), Items = [new Item { Dados = new Produto { Codigo = "P1" } }] };
        nfe.AutorizadosDownloadXml.Add(new AutorizadoDownloadXml("09.041.929/0001-33"));
        nfe.AutorizadosDownloadXml.Add(new AutorizadoDownloadXml("529.982.247-25"));

        string xml = Serializar(nfe);

        xml.Should().Contain("<CNPJ>09041929000133</CNPJ>").And.Contain("<CPF>52998224725</CPF>");
        int entrega = xml.IndexOf("<entrega", StringComparison.Ordinal);
        int autXml = xml.IndexOf("<autXML>", StringComparison.Ordinal);
        int det = xml.IndexOf("<det", StringComparison.Ordinal);
        entrega.Should().BeLessThan(autXml, "no leiaute o autXML vem depois do entrega");
        autXml.Should().BeLessThan(det, "e antes do det");
    }

    [Test]
    public void SemAutorizados_NaoGravaOGrupo() =>
        Serializar(new InformacoesNFe()).Should().NotContain("autXML");

    [Test]
    public void Leitura_RecuperaODocumentoEOTipo()
    {
        InformacoesNFe nfe = new();
        nfe.AutorizadosDownloadXml.Add(new AutorizadoDownloadXml("09041929000133"));
        nfe.AutorizadosDownloadXml.Add(new AutorizadoDownloadXml("52998224725"));

        using StringReader reader = new(Serializar(nfe));
        var lido = (InformacoesNFe)Serializer.Deserialize(reader)!;

        lido.AutorizadosDownloadXml.Select(a => (a.AutorizadoPersonalidadeJuridica, a.CNPJ_CPF)).Should().Equal(
            (PersonalidadeJuridica.CNPJ, "09041929000133"),
            (PersonalidadeJuridica.CPF, "52998224725"));
    }
}
