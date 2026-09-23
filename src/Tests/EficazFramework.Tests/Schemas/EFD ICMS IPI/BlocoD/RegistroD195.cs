using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoD;

public class RegistroD195 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD195();
        reg.Codigo.Should().Be("D195");
    }

    [TestCase("|D195|OBS01|Obs D195|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD195(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|D195|OBS01|Obs D195|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD195("", versao)
        {
            CodigoObs0460 = "OBS01",
            Descricao = "Obs D195"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|D195|OBS01|Obs D195|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD195("", versao);
        reg.CodigoObs0460.Should().BeNull();
        reg.Descricao.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD195 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("D195");
        reg.Versao.Should().Be(versao);
        reg.CodigoObs0460.Should().Be("OBS01");
        reg.Descricao.Should().Be("Obs D195");
    }
}
