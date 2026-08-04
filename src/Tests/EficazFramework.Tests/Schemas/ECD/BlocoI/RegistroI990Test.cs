using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI990Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI990();
        reg.Codigo.Should().Be("I990");
    }

    [TestCase("|I990|10|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I990|10|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI990()
        {
            QuantidadeLinhasBlocoI = "10"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|I990|10|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI990();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI990 reg, string versao)
    {
        reg.QuantidadeLinhasBlocoI.Should().Be("10");
    }
}
