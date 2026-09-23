using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI052Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI052();
        reg.Codigo.Should().Be("I052");
    }

    [TestCase("|I052|CC1|AGL1|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI052(linha, versao);
        reg.Codigo.Should().Be("I052");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I052|CC1|AGL1|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI052()
        {
            CodCentroCusto = "CC1",
            CodAglutinacaoUtilzBalanco = "AGL1"
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I052|CC1|AGL1|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI052(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI052 reg, string versao)
    {
        reg.CodCentroCusto.Should().Be("CC1");
        reg.CodAglutinacaoUtilzBalanco.Should().Be("AGL1");
    }
}
