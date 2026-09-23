using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI155Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI155();
        reg.Codigo.Should().Be("I155");
    }

    [TestCase("|I155|CONTA|CC1|1500,50|D|100,25|50,00|1550,75|D|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI155(linha, versao);
        reg.Codigo.Should().Be("I155");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I155|CONTA|CC1|1500,50|D|100,25|50,00|1550,75|D|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI155()
        {
            CodigoConta = "CONTA",
            CodigoCentroCusto = "CC1",
            VrSaldoInicialPeriodo = 1500.50d,
            IndicadorSituacaoSaldoInicial = "D",
            VrTotalDebitosPeriodo = 100.25d,
            VrTotalCreditosPeriodo = 50.00d,
            VrSaldoFinalPeriodo = 1550.75d,
            IndicadorSituacaoSaldoFinal = "D"
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I155|CONTA|CC1|1500,50|D|100,25|50,00|1550,75|D|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI155(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI155 reg, string versao)
    {
        reg.CodigoConta.Should().Be("CONTA");
        reg.CodigoCentroCusto.Should().Be("CC1");
        reg.VrSaldoInicialPeriodo.Should().Be(1500.50d);
        reg.IndicadorSituacaoSaldoInicial.Should().Be("D");
        reg.VrTotalDebitosPeriodo.Should().Be(100.25d);
        reg.VrTotalCreditosPeriodo.Should().Be(50.00d);
        reg.VrSaldoFinalPeriodo.Should().Be(1550.75d);
        reg.IndicadorSituacaoSaldoFinal.Should().Be("D");
    }
}
