using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC185 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC185();
        reg.Codigo.Should().Be("C185");
    }

    [TestCase("|C185|1|PROD01|000|5102|MOT01|10|UN|100|18|18|120|21,6|0|21,6|0|0|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC185(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C185|1|PROD01|000|5102|MOT01|10|UN|100|18|18|120|21,6|0|21,6|0|0|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC185("", versao)
        {
            NumSequencialItem = 1,
            CodigoItem = "PROD01",
            Origem = NFe.OrigemMercadoria.Nacional,
            CST_ICMS = NFe.CST_ICMS.CST_00,
            CFOP = "5102",
            Cod_Mot_RestCompl = "MOT01",
            Quant_Item = 10.0d,
            UnidadeMedida = "UN",
            ValorUnitario = 100.0d,
            ValorUnitarioICMS = 18.0d,
            ValorUnitarioICMSEntrada = 18.0d,
            ValorMedioUnitBCICMSST = 120.0d,
            ValorMedioUnitICMSSTFCPST = 21.6d,
            ValorMedioUnitFCPST = 0.0d,
            ValorUnitTotalICMSSTFCPST = 21.6d,
            ValorUnitParcICMSFCPST = 0.0d,
            ValorUnitComplICMSFCPST = 0.0d,
            ValorUnitICMSFCPST = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C185|1|PROD01|000|5102|MOT01|10|UN|100|18|18|120|21,6|0|21,6|0|0|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC185("", versao);
        reg.CodigoItem.Should().BeNull();
        reg.Quant_Item.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC185 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C185");
        reg.Versao.Should().Be(versao);
        reg.NumSequencialItem.Should().Be(1);
        reg.CodigoItem.Should().Be("PROD01");
        reg.Origem.Should().Be(NFe.OrigemMercadoria.Nacional);
        reg.CST_ICMS.Should().Be(NFe.CST_ICMS.CST_00);
        reg.CFOP.Should().Be("5102");
        reg.Cod_Mot_RestCompl.Should().Be("MOT01");
        reg.Quant_Item.Should().Be(10.0d);
        reg.UnidadeMedida.Should().Be("UN");
        reg.ValorUnitario.Should().Be(100.0d);
        reg.ValorUnitarioICMS.Should().Be(18.0d);
    }
}
