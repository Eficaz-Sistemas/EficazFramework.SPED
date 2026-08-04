using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI151Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI151();
        reg.Codigo.Should().Be("I151");
    }

    [TestCase("|I151|HASH_FICHAS|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI151(linha, versao);
        reg.Codigo.Should().Be("I151");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I151|HASH_FICHAS|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI151()
        {
            HashFichasLanctos = "HASH_FICHAS"
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I151|HASH_FICHAS|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI151(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI151 reg, string versao)
    {
        reg.HashFichasLanctos.Should().Be("HASH_FICHAS");
    }
}
