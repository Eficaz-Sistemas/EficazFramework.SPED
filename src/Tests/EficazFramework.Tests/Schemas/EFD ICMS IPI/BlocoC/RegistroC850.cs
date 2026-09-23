using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC850 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC850();
        reg.Codigo.Should().Be("C850");
    }

    [TestCase("|C850|000|5102|18|100|100|18|OBS01|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC850(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C850|000|5102|18|100|100|18|OBS01|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC850("", versao)
        {
            Origem = NFe.OrigemMercadoria.Nacional,
            CST_ICMS = NFe.CST_ICMS.CST_00,
            CFOP = "5102",
            AliquotaICMS = 18.0d,
            ValorOperacao = 100.0d,
            ValorBaseCalculoICMS = 100.0d,
            ValorICMS = 18.0d,
            CodigoObservavao = "OBS01"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C850|000|5102|18|100|100|18|OBS01|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC850("", versao);
        reg.CFOP.Should().BeNull();
        reg.ValorOperacao.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC850 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C850");
        reg.Versao.Should().Be(versao);
        reg.Origem.Should().Be(NFe.OrigemMercadoria.Nacional);
        reg.CST_ICMS.Should().Be(NFe.CST_ICMS.CST_00);
        reg.CFOP.Should().Be("5102");
        reg.AliquotaICMS.Should().Be(18.0d);
        reg.ValorOperacao.Should().Be(100.0d);
        reg.ValorBaseCalculoICMS.Should().Be(100.0d);
        reg.ValorICMS.Should().Be(18.0d);
        reg.CodigoObservavao.Should().Be("OBS01");
    }
}
