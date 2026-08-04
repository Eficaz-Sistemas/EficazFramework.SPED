using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoK;

public class RegistroK001Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroK001();
        reg.Codigo.Should().Be("K001");
    }

    [TestCase("|K001|0|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroK001(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K001|0|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroK001("", versao)
        {
            IndicadorMovimento = Primitives.IndicadorMovimento.ComDados
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K001|0|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroK001(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroK001 reg, string versao)
    {
        reg.IndicadorMovimento.Should().Be(Primitives.IndicadorMovimento.ComDados);
    }
}
