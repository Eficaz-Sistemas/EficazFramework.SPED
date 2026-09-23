using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoD;

public class RegistroD760 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD760();
        reg.Codigo.Should().Be("D760");
    }

    [TestCase("|D760|000|5307|12|1000|1000|120|0|OBS01|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD760(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|D760|000|5307|12|1000|1000|120|0|OBS01|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD760("", versao)
        {
            Origem = NFe.OrigemMercadoria.Nacional,
            CST_ICMS = NFe.CST_ICMS.CST_00,
            CFOP = "5307",
            AliquotaICMS = 12.0d,
            ValorOperacao = 1000.0d,
            ValorBaseCalculoICMS = 1000.0d,
            ValorICMS = 120.0d,
            ValorReducaoBC = 0.0d,
            CodigoObservacao0460 = "OBS01"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|D760|000|5307|12|1000|1000|120|0|OBS01|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD760("", versao);
        reg.CFOP.Should().BeNull();
        reg.ValorOperacao.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD760 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("D760");
        reg.Versao.Should().Be(versao);
        reg.Origem.Should().Be(NFe.OrigemMercadoria.Nacional);
        reg.CST_ICMS.Should().Be(NFe.CST_ICMS.CST_00);
        reg.CFOP.Should().Be("5307");
        reg.AliquotaICMS.Should().Be(12.0d);
        reg.ValorOperacao.Should().Be(1000.0d);
        reg.ValorBaseCalculoICMS.Should().Be(1000.0d);
        reg.ValorICMS.Should().Be(120.0d);
        reg.ValorReducaoBC.Should().Be(0.0d);
        reg.CodigoObservacao0460.Should().Be("OBS01");
    }
}
