using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoK;

public class RegistroK156 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK156();
        reg.Codigo.Should().Be("K156");
    }

    [TestCase("|K156|1.01.01.01.01|1000,00|D|500,00|200,00|1300,00|D|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK156(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K156|1.01.01.01.01|1000,00|D|500,00|200,00|1300,00|D|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK156("", versao)
        {
            CodigoContaReferencial = "1.01.01.01.01",
            VrSaldoInicialPeriodo = 1000.0d,
            IndicadorSituacaoSaldoInicial = "D",
            VrTotalDebitosPeriodo = 500.0d,
            VrTotalCreditosPeriodo = 200.0d,
            VrSaldoFinalPeriodo = 1300.0d,
            IndicadorSituacaoSaldoFinal = "D"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K156|1.01.01.01.01|1000,00|D|500,00|200,00|1300,00|D|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK156("", versao);
        reg.CodigoContaReferencial.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroK156 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("K156");
        reg.Versao.Should().Be(versao);
        reg.CodigoContaReferencial.Should().Be("1.01.01.01.01");
        reg.VrSaldoInicialPeriodo.Should().Be(1000.0d);
        reg.VrTotalDebitosPeriodo.Should().Be(500.0d);
        reg.VrTotalCreditosPeriodo.Should().Be(200.0d);
        reg.VrSaldoFinalPeriodo.Should().Be(1300.0d);
        reg.IndicadorSituacaoSaldoFinal.Should().Be("D");
    }
}
