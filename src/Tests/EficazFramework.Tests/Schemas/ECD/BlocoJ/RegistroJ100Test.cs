using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ100Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ100();
        reg.Codigo.Should().Be("J100");
    }

    [TestCase("|J100|COD|IND|NIVEL|SUP|A|DESC|150,5|D|160,5|C|NOTA|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ100(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J100|COD|IND|NIVEL|SUP|A|DESC|150,50|D|160,50|C|NOTA|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ100("", versao)
        {
            CodAglutinacao = "COD",
            IndicadorCodAglutinacao = "IND",
            NivelCodAglut = "NIVEL",
            CodAglutinacaoSuperior = "SUP",
            IndicadorGrupoBalanco = IndicadorGrupoBalanço.Ativo,
            DescrCodAglut = "DESC",
            VrInicialCodAglut = 150.5,
            IndicadorSitSaldoInicial = "D",
            VrTotalCodAglut = 160.5,
            IndicadorSitSaldo = "C",
            NotaExplicativa = "NOTA"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J100|COD|IND|NIVEL|SUP|A|DESC|150,5|D|160,5|C|NOTA|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ100(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ100 reg, string versao)
    {
        reg.CodAglutinacao.Should().Be("COD");
        reg.IndicadorCodAglutinacao.Should().Be("IND");
        reg.NivelCodAglut.Should().Be("NIVEL");
        reg.CodAglutinacaoSuperior.Should().Be("SUP");
        reg.IndicadorGrupoBalanco.Should().Be(IndicadorGrupoBalanço.Ativo);
        reg.DescrCodAglut.Should().Be("DESC");
        reg.VrInicialCodAglut.Should().Be(150.5);
        reg.IndicadorSitSaldoInicial.Should().Be("D");
        reg.VrTotalCodAglut.Should().Be(160.5);
        reg.IndicadorSitSaldo.Should().Be("C");
        reg.NotaExplicativa.Should().Be("NOTA");
    }
}
