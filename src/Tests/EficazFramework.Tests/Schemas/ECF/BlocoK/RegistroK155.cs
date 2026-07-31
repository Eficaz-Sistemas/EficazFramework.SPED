using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoK;

public class RegistroK155 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK155();
        reg.Codigo.Should().Be("K155");
    }

    [TestCase("|K155|1.01.01.001|CC01|1000,00|D|500,00|200,00|1300,00|D|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK155(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K155|1.01.01.001|CC01|1000,00|D|500,00|200,00|1300,00|D|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK155("", versao)
        {
            CodigoConta = "1.01.01.001",
            CodigoCentroCusto = "CC01",
            VrSaldoInicialPeriodo = 1000.0d,
            IndicadorSituacaoSaldoInicial = "D",
            VrTotalDebitosPeriodo = 500.0d,
            VrTotalCreditosPeriodo = 200.0d,
            VrSaldoFinalPeriodo = 1300.0d,
            IndicadorSituacaoSaldoFinal = "D"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K155|1.01.01.001|CC01|1000,00|D|500,00|200,00|1300,00|D|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK155("", versao);
        reg.CodigoConta.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroK155 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("K155");
        reg.Versao.Should().Be(versao);
        reg.CodigoConta.Should().Be("1.01.01.001");
        reg.CodigoCentroCusto.Should().Be("CC01");
        reg.VrSaldoInicialPeriodo.Should().Be(1000.0d);
        reg.VrTotalDebitosPeriodo.Should().Be(500.0d);
        reg.VrTotalCreditosPeriodo.Should().Be(200.0d);
        reg.VrSaldoFinalPeriodo.Should().Be(1300.0d);
        reg.IndicadorSituacaoSaldoFinal.Should().Be("D");
    }
}
