using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ990Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ990();
        reg.Codigo.Should().Be("J990");
    }

    [TestCase("|J990|10|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J990|10|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ990()
        {
            QuantidadeLinhasBlocoJ = "10"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J990|10|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ990();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ990 reg, string versao)
    {
        reg.QuantidadeLinhasBlocoJ.Should().Be("10");
    }
}
