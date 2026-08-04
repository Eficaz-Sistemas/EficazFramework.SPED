using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.Bloco9;

public class Registro9001Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new Registro9001();
        reg.Codigo.Should().Be("9001");
    }

    [TestCase("|9001|0|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new Registro9001(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|9001|0|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new Registro9001("", versao)
        {
            IndicadorMovimento = Primitives.IndicadorMovimento.ComDados
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|9001|0|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new Registro9001(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(Registro9001 reg, string versao)
    {
        reg.IndicadorMovimento.Should().Be(Primitives.IndicadorMovimento.ComDados);
    }
}
