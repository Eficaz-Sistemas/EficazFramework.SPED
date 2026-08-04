using System;
using AwesomeAssertions;
using NUnit.Framework;
using EficazFramework.SPED.Schemas.ECD;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI250Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI250();
        reg.Codigo.Should().Be("I250");
    }

    [TestCase("|I250|CTA|CC|1500,75|D|1234|HIST PADRAO|HISTORICO|PART|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI250(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I250|CTA|CC|1500,75|D|1234|HIST PADRAO|HISTORICO|PART|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI250()
        {
            CodContaAnalitica = "CTA",
            CodCentroCusto = "CC",
            VrPartida = 1500.75,
            IndNaturezaPartida = "D",
            NumeroCodigoCaminhoLocalizacaoArquivo = "1234",
            CodHistoricoPadronizado = "HIST PADRAO",
            HistoricoCompleto = "HISTORICO",
            CodParticipante = "PART"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|I250|CTA|CC|1500,75|D|1234|HIST PADRAO|HISTORICO|PART|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI250();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI250 reg, string versao)
    {
        reg.CodContaAnalitica.Should().Be("CTA");
        reg.CodCentroCusto.Should().Be("CC");
        reg.VrPartida.Should().Be(1500.75);
        reg.IndNaturezaPartida.Should().Be("D");
        reg.NumeroCodigoCaminhoLocalizacaoArquivo.Should().Be("1234");
        reg.CodHistoricoPadronizado.Should().Be("HIST PADRAO");
        reg.HistoricoCompleto.Should().Be("HISTORICO");
        reg.CodParticipante.Should().Be("PART");
    }
}
