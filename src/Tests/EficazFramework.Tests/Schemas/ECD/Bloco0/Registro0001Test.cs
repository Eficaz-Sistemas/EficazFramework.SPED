using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.Bloco0;

public class Registro0001Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new Registro0001();
        reg.Codigo.Should().Be("0001");
    }

    [TestCase("|0001|0|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new Registro0001(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0001|0|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new Registro0001("", versao)
        {
            IndicadorMovimento = Primitives.IndicadorMovimento.ComDados
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0001|0|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new Registro0001(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(Registro0001 reg, string versao)
    {
        reg.IndicadorMovimento.Should().Be(Primitives.IndicadorMovimento.ComDados);
    }
}
