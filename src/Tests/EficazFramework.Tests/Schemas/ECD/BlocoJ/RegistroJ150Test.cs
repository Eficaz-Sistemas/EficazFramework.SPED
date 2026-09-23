using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoJ;

public class RegistroJ150Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroJ150();
        reg.Codigo.Should().Be("J150");
    }

    [TestCase("|J150|1|COD|IND|NIVEL|SUP|DESC|150,5|D|160,5|C|GRP|NOTA|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroJ150(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J150|1|COD|IND|NIVEL|SUP|DESC|150,50|D|160,50|C|GRP|NOTA|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroJ150("", versao)
        {
            NumeroOrdem = 1,
            CodAglutinacao = "COD",
            IndicadorCodAglutinacao = "IND",
            NivelCodAglutinacao = "NIVEL",
            CodAglutinacaoSuperior = "SUP",
            DescCodAglutinacao = "DESC",
            VrTotalPerAnteriorCodAglutinacao = 150.5,
            IndicadorSitVrPerAnteriorInformado = "D",
            VrTotalCodAglutinacao = 160.5,
            IndicadorSitVrInformado = "C",
            IndicadorGrupoDRE = "GRP",
            NotaExplicativa = "NOTA"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J150|1|COD|IND|NIVEL|SUP|DESC|150,5|D|160,5|C|GRP|NOTA|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroJ150(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroJ150 reg, string versao)
    {
        reg.NumeroOrdem.Should().Be(1);
        reg.CodAglutinacao.Should().Be("COD");
        reg.IndicadorCodAglutinacao.Should().Be("IND");
        reg.NivelCodAglutinacao.Should().Be("NIVEL");
        reg.CodAglutinacaoSuperior.Should().Be("SUP");
        reg.DescCodAglutinacao.Should().Be("DESC");
        reg.VrTotalPerAnteriorCodAglutinacao.Should().Be(150.5);
        reg.IndicadorSitVrPerAnteriorInformado.Should().Be("D");
        reg.VrTotalCodAglutinacao.Should().Be(160.5);
        reg.IndicadorSitVrInformado.Should().Be("C");
        reg.IndicadorGrupoDRE.Should().Be("GRP");
        reg.NotaExplicativa.Should().Be("NOTA");
    }
}
