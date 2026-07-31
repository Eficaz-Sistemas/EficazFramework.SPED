using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoD;

public class RegistroD590 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD590();
        reg.Codigo.Should().Be("D590");
    }

    [TestCase("|D590|000|5303|12|100|100|12|0|0|0|OBS01|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD590(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|D590|000|5303|12|100|100|12|0|0|0|OBS01|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD590("", versao)
        {
            Origem = NFe.OrigemMercadoria.Nacional,
            CST_ICMS = NFe.CST_ICMS.CST_00,
            CFOP = "5303",
            AliquotaICMS = 12.0d,
            ValorOperacao = 100.0d,
            ValorBaseCalculoICMS = 100.0d,
            ValorICMS = 12.0d,
            ValorBaseCalculoICMSST = 0.0d,
            ValorICMSST = 0.0d,
            ValorReducaoBC = 0.0d,
            CodigoObservacao0460 = "OBS01"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|D590|000|5303|12|100|100|12|0|0|0|OBS01|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD590("", versao);
        reg.CFOP.Should().BeNull();
        reg.ValorOperacao.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD590 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("D590");
        reg.Versao.Should().Be(versao);
        reg.Origem.Should().Be(NFe.OrigemMercadoria.Nacional);
        reg.CST_ICMS.Should().Be(NFe.CST_ICMS.CST_00);
        reg.CFOP.Should().Be("5303");
        reg.AliquotaICMS.Should().Be(12.0d);
        reg.ValorOperacao.Should().Be(100.0d);
        reg.ValorBaseCalculoICMS.Should().Be(100.0d);
        reg.ValorICMS.Should().Be(12.0d);
        reg.ValorBaseCalculoICMSST.Should().Be(0.0d);
        reg.ValorICMSST.Should().Be(0.0d);
        reg.ValorReducaoBC.Should().Be(0.0d);
        reg.CodigoObservacao0460.Should().Be("OBS01");
    }
}
