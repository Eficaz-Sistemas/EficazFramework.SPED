using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC470 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC470();
        reg.Codigo.Should().Be("C470");
    }

    [TestCase("|C470|PROD01|10|0|UN|100|000|5102|18|1,65|7,6|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC470(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C470|PROD01|10|0|UN|100|000|5102|18|1,65|7,6|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC470("", versao)
        {
            Produto = "PROD01",
            QuantidadeBruto = 10.0d,
            QuantidadeCancelada = 0.0d,
            Unidade = "UN",
            ValorLiquidoItem = 100.0d,
            Origem = NFe.OrigemMercadoria.Nacional,
            CST_ICMS = NFe.CST_ICMS.CST_00,
            CFOP = "5102",
            Aliquota_ICMS = 18.0d,
            PIS = 1.65d,
            COFINS = 7.6d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C470|PROD01|10|0|UN|100|000|5102|18|1,65|7,6|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC470("", versao);
        reg.Produto.Should().BeNull();
        reg.ValorLiquidoItem.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC470 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C470");
        reg.Versao.Should().Be(versao);
        reg.Produto.Should().Be("PROD01");
        reg.QuantidadeBruto.Should().Be(10.0d);
        reg.QuantidadeCancelada.Should().Be(0.0d);
        reg.Unidade.Should().Be("UN");
        reg.ValorLiquidoItem.Should().Be(100.0d);
        reg.Origem.Should().Be(NFe.OrigemMercadoria.Nacional);
        reg.CST_ICMS.Should().Be(NFe.CST_ICMS.CST_00);
        reg.CFOP.Should().Be("5102");
        reg.Aliquota_ICMS.Should().Be(18.0d);
        reg.PIS.Should().Be(1.65d);
        reg.COFINS.Should().Be(7.6d);
    }
}
