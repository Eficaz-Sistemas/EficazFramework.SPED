using EficazFramework.SPED.Schemas.NFe;
using EficazFramework.SPED.Tests;

namespace EficazFramework.SPED.Schemas.NFe.Tributos;

public class Icms : BaseXmlTest<ProcessoNFe>
{

    [Test]
    public async Task MonofasicoCombustiveis()
    {
        ProcessoNFe instance = await ReadAsync(Resources.Schemas.XML.NFCeNt2023_001);
        instance.Should().NotBeNull();
        ((EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS)instance.NFe.InformacoesNFe.Items[0].Imposto.EstaduaisMunicipais[0]).Tributacao.Origem.Should().Be(OrigemMercadoria.Nacional);
        ((EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS)instance.NFe.InformacoesNFe.Items[0].Imposto.EstaduaisMunicipais[0]).Tributacao.CST.Should().Be(CST_ICMS.CST_61);
        ((EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS)instance.NFe.InformacoesNFe.Items[0].Imposto.EstaduaisMunicipais[0]).Tributacao.qBCMonoRet.Should().Be(16.761d);
        ((EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS)instance.NFe.InformacoesNFe.Items[0].Imposto.EstaduaisMunicipais[0]).Tributacao.adRemICMSRet.Should().Be(1.2200d);
        ((EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS)instance.NFe.InformacoesNFe.Items[0].Imposto.EstaduaisMunicipais[0]).Tributacao.vICMSMonoRet.Should().Be(20.44d);
    }

    private static Item ItemIcms40(CST_ICMS cst, double? desonerado = null, DetalhamentoICMS_CST40_MotivoDesoneracao motivo = default) => new()
    {
        Dados = new Produto { Codigo = "P1" },
        Imposto = new Tributacao
        {
            EstaduaisMunicipais =
            [
                new DetalhamentoICMS
                {
                    TributacaoIndentifier = Tributacao_ICMS_Identifier.ICMS40,
                    Tributacao = new DetalhamentoICMS_Tributacao { CST = cst, vICMSDeson = desonerado, motDesICMS = motivo }
                }
            ]
        }
    };

    private static string Serializar(Item item)
    {
        System.Xml.Serialization.XmlSerializer serializer = new(typeof(Item), "http://www.portalfiscal.inf.br/nfe");
        using StringWriter writer = new();
        serializer.Serialize(writer, item);
        return writer.ToString();
    }

    private static Item Ler(string xml)
    {
        System.Xml.Serialization.XmlSerializer serializer = new(typeof(Item), "http://www.portalfiscal.inf.br/nfe");
        using StringReader reader = new(xml);
        return (Item)serializer.Deserialize(reader)!;
    }

    [TestCase(CST_ICMS.CST_40)]
    [TestCase(CST_ICMS.CST_41)]
    [TestCase(CST_ICMS.CST_50)]
    public void Icms40_SemDesoneracao_NaoGravaValorNemMotivo(CST_ICMS cst)
    {
        // motivo não informado (0 não existe no enum): antes da correção o XmlSerializer falhava com XmlUnknownConstant
        string xml = Serializar(ItemIcms40(cst));

        xml.Should().NotContain("motDesICMS").And.NotContain("vICMSDeson");
    }

    [Test]
    public void Icms40_ComDesoneracao_GravaValorComDuasCasasEAntesDoMotivo()
    {
        string xml = Serializar(ItemIcms40(CST_ICMS.CST_40, 12.5, DetalhamentoICMS_CST40_MotivoDesoneracao.SUFRAMA));

        xml.Should().Contain("<vICMSDeson>12.50</vICMSDeson>").And.Contain("<motDesICMS>7</motDesICMS>");
        xml.IndexOf("<vICMSDeson>", StringComparison.Ordinal).Should().BeLessThan(xml.IndexOf("<motDesICMS>", StringComparison.Ordinal),
            "no leiaute o vICMSDeson vem antes do motDesICMS");

        var lido = (DetalhamentoICMS)Ler(xml).Imposto.EstaduaisMunicipais[0];
        lido.Tributacao.vICMSDeson.Should().Be(12.5);
        lido.Tributacao.motDesICMS.Should().Be(DetalhamentoICMS_CST40_MotivoDesoneracao.SUFRAMA);
    }
}
