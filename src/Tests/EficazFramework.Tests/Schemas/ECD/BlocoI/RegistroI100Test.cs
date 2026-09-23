using System;
using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI100Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI100();
        reg.Codigo.Should().Be("I100");
    }

    [TestCase("|I100|01012023|CC1|NOME_CC1|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI100(linha, versao);
        reg.Codigo.Should().Be("I100");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I100|01012023|CC1|NOME_CC1|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI100()
        {
            DataInclusaoAlteracao = new DateTime(2023, 1, 1),
            CodCentroCusto = "CC1",
            NomeCentroCusto = "NOME_CC1"
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I100|01012023|CC1|NOME_CC1|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI100(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI100 reg, string versao)
    {
        reg.DataInclusaoAlteracao.Should().Be(new DateTime(2023, 1, 1));
        reg.CodCentroCusto.Should().Be("CC1");
        reg.NomeCentroCusto.Should().Be("NOME_CC1");
    }
}
