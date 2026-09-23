using System;
using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI150Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI150();
        reg.Codigo.Should().Be("I150");
    }

    [TestCase("|I150|01012023|31012023|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI150(linha, versao);
        reg.Codigo.Should().Be("I150");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I150|01012023|31012023|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI150()
        {
            DataInicioPeriodo = new DateTime(2023, 1, 1),
            DataFinalPeriodo = new DateTime(2023, 1, 31)
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I150|01012023|31012023|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI150(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI150 reg, string versao)
    {
        reg.DataInicioPeriodo.Should().Be(new DateTime(2023, 1, 1));
        reg.DataFinalPeriodo.Should().Be(new DateTime(2023, 1, 31));
    }
}
