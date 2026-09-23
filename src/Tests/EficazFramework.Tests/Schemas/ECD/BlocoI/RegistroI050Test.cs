using System;
using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI050Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI050();
        reg.Codigo.Should().Be("I050");
    }

    [TestCase("|I050|01012023|01|A|5|1.1.01.01|1.1.01|CAIXA|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI050(linha, versao);
        reg.Codigo.Should().Be("I050");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I050|01012023|01|A|5|1.1.01.01|1.1.01|CAIXA|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI050()
        {
            DataInclusaoAlteracao = new DateTime(2023, 1, 1),
            CodNaturezaContaGrupo = "01",
            IndicadorTipoConta = IndicadorConta.Analitica,
            NivelContaAnaliticaGrupo = 5,
            CodContaAnaliticaGrupo = "1.1.01.01",
            CodContaSuperior = "1.1.01",
            NomeContaAnaliticaGrupo = "CAIXA"
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I050|01012023|01|A|5|1.1.01.01|1.1.01|CAIXA|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI050(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI050 reg, string versao)
    {
        reg.DataInclusaoAlteracao.Should().Be(new DateTime(2023, 1, 1));
        reg.CodNaturezaContaGrupo.Should().Be("01");
        reg.IndicadorTipoConta.Should().Be(IndicadorConta.Analitica);
        reg.NivelContaAnaliticaGrupo.Should().Be(5);
        reg.CodContaAnaliticaGrupo.Should().Be("1.1.01.01");
        reg.CodContaSuperior.Should().Be("1.1.01");
        reg.NomeContaAnaliticaGrupo.Should().Be("CAIXA");
    }
}
