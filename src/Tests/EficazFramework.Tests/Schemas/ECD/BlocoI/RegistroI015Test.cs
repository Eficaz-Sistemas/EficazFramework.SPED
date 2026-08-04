using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI015Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI015();
        reg.Codigo.Should().Be("I015");
    }

    [TestCase("|I015|CONTA|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI015(linha, versao);
        reg.Codigo.Should().Be("I015");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I015|CONTA|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI015()
        {
            CodigoContaResumida = "CONTA"
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I015|CONTA|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI015(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI015 reg, string versao)
    {
        reg.CodigoContaResumida.Should().Be("CONTA");
    }
}
