using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoK;

public class RegistroK990Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroK990();
        reg.Codigo.Should().Be("K990");
    }

    [TestCase("|K990|15|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroK990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K990|15|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroK990("", versao)
        {
            QuantidadeLinhasBlocoK = "15"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K990|15|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroK990(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroK990 reg, string versao)
    {
        reg.QuantidadeLinhasBlocoK.Should().Be("15");
    }
}
