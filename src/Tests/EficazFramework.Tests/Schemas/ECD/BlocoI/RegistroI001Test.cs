using System;
using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI001Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI001();
        reg.Codigo.Should().Be("I001");
    }

    [TestCase("|I001|0|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI001(linha, versao);
        reg.Codigo.Should().Be("I001");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I001|0|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI001()
        {
            IndicadorMovimento = Primitives.IndicadorMovimento.ComDados
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I001|0|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI001(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI001 reg, string versao)
    {
        reg.IndicadorMovimento.Should().Be(Primitives.IndicadorMovimento.ComDados);
    }
}
