using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI010Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI010();
        reg.Codigo.Should().Be("I010");
    }

    [TestCase("|I010|G|900|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI010(linha, versao);
        reg.Codigo.Should().Be("I010");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I010|G|900|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI010("", versao)
        {
            IndicadorFormaEscritContabil = "G",
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I010|G|900|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI010(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI010 reg, string versao)
    {
        reg.IndicadorFormaEscritContabil.Should().Be("G");
    }
}
