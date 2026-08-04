using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoK;

public class RegistroK010 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK010();
        reg.Codigo.Should().Be("K010");
    }

    [TestCase("|K010|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK010(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K010|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK010("", versao)
        {
            IndicadorTemplate = IndicadorLayoutBlocoK.Simplificado
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K010|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK010("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroK010 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("K010");
        reg.Versao.Should().Be(versao);
        reg.IndicadorTemplate.Should().Be(IndicadorLayoutBlocoK.Simplificado);
    }
}
