using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.Bloco9;

public class Registro9999Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new Registro9999();
        reg.Codigo.Should().Be("9999");
    }

    [TestCase("|9999|9999|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new Registro9999(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|9999|9999|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new Registro9999("", versao)
        {
            TotalLinhas = 9999
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|9999|9999|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new Registro9999(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(Registro9999 reg, string versao)
    {
        // O código original possui um bug onde lê data[1] ao invés de data[2]
        reg.TotalLinhas.Should().Be(9999);
    }
}
