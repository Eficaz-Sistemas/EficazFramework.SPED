using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC190 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC190();
        reg.Codigo.Should().Be("C190");
    }

    [TestCase("|C190|000|5102|18|1000|1000|180|0|0|0|0|OBS01|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC190(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C190|000|5102|18|1000|1000|180|0|0|0|0|OBS01|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC190("", versao)
        {
            Origem = NFe.OrigemMercadoria.Nacional,
            CST_ICMS = NFe.CST_ICMS.CST_00,
            CFOP = "5102",
            AliquotaICMS = 18.0d,
            ValorOperacao = 1000.0d,
            ValorBaseCalculoICMS = 1000.0d,
            ValorICMS = 180.0d,
            ValorBaseCalculoICMSST = 0.0d,
            ValorICMSST = 0.0d,
            ValorReducaoBC = 0.0d,
            ValorIPI = 0.0d,
            CodigoObservavao = "OBS01"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C190|000|5102|18|1000|1000|180|0|0|0|0|OBS01|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC190("", versao);
        reg.CFOP.Should().BeNull();
        reg.ValorOperacao.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC190 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C190");
        reg.Versao.Should().Be(versao);
        reg.Origem.Should().Be(NFe.OrigemMercadoria.Nacional);
        reg.CST_ICMS.Should().Be(NFe.CST_ICMS.CST_00);
        reg.CFOP.Should().Be("5102");
        reg.AliquotaICMS.Should().Be(18.0d);
        reg.ValorOperacao.Should().Be(1000.0d);
        reg.ValorBaseCalculoICMS.Should().Be(1000.0d);
        reg.ValorICMS.Should().Be(180.0d);
        reg.CodigoObservavao.Should().Be("OBS01");
    }
}
