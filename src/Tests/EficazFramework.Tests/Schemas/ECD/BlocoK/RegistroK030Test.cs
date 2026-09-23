using System;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoK;

public class RegistroK030Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroK030();
        reg.Codigo.Should().Be("K030");
    }

    [TestCase("|K030|01012023|31122023|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroK030(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K030|01012023|31122023|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroK030("", versao)
        {
            DataInicialPeriodoConsolidado = new DateTime(2023, 1, 1),
            DataFinalPeriodoConsolidado = new DateTime(2023, 12, 31)
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K030|01012023|31122023|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroK030(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroK030 reg, string versao)
    {
        reg.DataInicialPeriodoConsolidado.Should().Be(new DateTime(2023, 1, 1));
        reg.DataFinalPeriodoConsolidado.Should().Be(new DateTime(2023, 12, 31));
    }
}
