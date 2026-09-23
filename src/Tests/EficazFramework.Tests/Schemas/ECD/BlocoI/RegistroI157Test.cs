using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI157Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI157();
        reg.Codigo.Should().Be("I157");
    }

    [TestCase("|I157|CONTA|CC1|1500,5|D|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI157(linha, versao);
        reg.Codigo.Should().Be("I157");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I157|CONTA|CC1|1500,5|D|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI157()
        {
            CodConta = "CONTA",
            CodCentroCusto = "CC1",
            VrSaldoInicialPeriodo = 1500.5d,
            IndicadorSituacaoSaldoInicial = "D"
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I157|CONTA|CC1|1500,5|D|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI157(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI157 reg, string versao)
    {
        reg.CodConta.Should().Be("CONTA");
        reg.CodCentroCusto.Should().Be("CC1");
        reg.VrSaldoInicialPeriodo.Should().Be(1500.5d);
        reg.IndicadorSituacaoSaldoInicial.Should().Be("D");
    }
}
