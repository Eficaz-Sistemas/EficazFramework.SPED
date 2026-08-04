using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ001Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ001();
        reg.Codigo.Should().Be("J001");
    }

    [TestCase("|J001|0|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ001(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J001|0|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ001()
        {
            IndicadorMovimento = Primitives.IndicadorMovimento.ComDados
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J001|0|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ001();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ001 reg, string versao)
    {
        reg.IndicadorMovimento.Should().Be(Primitives.IndicadorMovimento.ComDados);
    }
}
