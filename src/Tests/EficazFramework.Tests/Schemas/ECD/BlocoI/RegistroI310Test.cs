using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI310Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI310();
        reg.Codigo.Should().Be("I310");
    }

    [TestCase("|I310|CTA|CC|1500,75|3000,5|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI310(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I310|CTA|CC|1500,75|3000,5|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI310()
        {
            CodContaAnalitica = "CTA",
            CodCentroCusto = "CC",
            TotalDebitos = 1500.75,
            TotalCreditos = 3000.50
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|I310|CTA|CC|1500,75|3000,5|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI310();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI310 reg, string versao)
    {
        reg.CodContaAnalitica.Should().Be("CTA");
        reg.CodCentroCusto.Should().Be("CC");
        reg.TotalDebitos.Should().Be(1500.75);
        reg.TotalCreditos.Should().Be(3000.50);
    }
}
