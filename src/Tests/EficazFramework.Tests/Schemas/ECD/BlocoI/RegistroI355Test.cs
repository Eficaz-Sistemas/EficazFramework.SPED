using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI355Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI355();
        reg.Codigo.Should().Be("I355");
    }

    [TestCase("|I355|CTA|CC|1500,75|D|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI355(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I355|CTA|CC|1500,75|D|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI355()
        {
            CodContaAnaliticaResultado = "CTA",
            CodCentroCusto = "CC",
            VrSaldoFinalAntesEncerramento = 1500.75,
            IndicadorSituacaoSaldoFinal = "D"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|I355|CTA|CC|1500,75|D|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI355();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI355 reg, string versao)
    {
        reg.CodContaAnaliticaResultado.Should().Be("CTA");
        reg.CodCentroCusto.Should().Be("CC");
        reg.VrSaldoFinalAntesEncerramento.Should().Be(1500.75);
        reg.IndicadorSituacaoSaldoFinal.Should().Be("D");
    }
}
