using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.Bloco9;

public class Registro9990Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new Registro9990();
        reg.Codigo.Should().Be("9990");
    }

    [TestCase("|9990|150|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new Registro9990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|9990|150|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new Registro9990("", versao)
        {
            TotalLinhas = "150"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|9990|150|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new Registro9990(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(Registro9990 reg, string versao)
    {
        reg.TotalLinhas.Should().Be("150");
    }
}
