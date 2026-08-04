using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ210Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ210();
        reg.Codigo.Should().Be("J210");
    }

    [TestCase("|J210|1|COD|DESC|150,5|D|160,5|C|NOTA|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ210(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J210|1|COD|DESC|150,50|D|160,50|C|NOTA|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ210("", versao)
        {
            IndicadorTipoDemonst = IndicadorTipoDemonst.DMPL,
            CodAglutinacao = "COD",
            DescCodAglutinacao = "DESC",
            SaldoInicialCodAglutinacao = 150.5,
            IndicadorSitSaldoInformadoInicial = "D",
            SaldoFinalCodAglutinacao = 160.5,
            IndicadorSitSaldoInformado = "C",
            NotasExplicativas = "NOTA"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J210|1|COD|DESC|150,5|D|160,5|C|NOTA|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ210(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ210 reg, string versao)
    {
        reg.IndicadorTipoDemonst.Should().Be(IndicadorTipoDemonst.DMPL);
        reg.CodAglutinacao.Should().Be("COD");
        reg.DescCodAglutinacao.Should().Be("DESC");
        reg.SaldoFinalCodAglutinacao.Should().Be(160.5);
        reg.IndicadorSitSaldoInformado.Should().Be("C");
        reg.SaldoInicialCodAglutinacao.Should().Be(150.5);
        reg.IndicadorSitSaldoInformadoInicial.Should().Be("D");
    }
}
