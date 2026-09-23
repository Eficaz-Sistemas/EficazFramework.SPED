using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.Bloco0;

public class Registro0990Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new Registro0990();
        reg.Codigo.Should().Be("0990");
    }

    [TestCase("|0990|150|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new Registro0990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0990|150|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new Registro0990("", versao)
        {
            QuantidadeLinhasBloco0 = "150"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0990|150|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new Registro0990(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(Registro0990 reg, string versao)
    {
        reg.QuantidadeLinhasBloco0.Should().Be("150");
    }
}
