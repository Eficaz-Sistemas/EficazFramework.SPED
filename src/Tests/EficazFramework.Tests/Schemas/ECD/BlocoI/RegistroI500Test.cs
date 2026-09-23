using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI500Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI500();
        reg.Codigo.Should().Be("I500");
    }

    [TestCase("|I500|12|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI500(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I500|12|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI500()
        {
            TamanhoFonte = "12"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|I500|12|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI500();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI500 reg, string versao)
    {
        reg.TamanhoFonte.Should().Be("12");
    }
}
