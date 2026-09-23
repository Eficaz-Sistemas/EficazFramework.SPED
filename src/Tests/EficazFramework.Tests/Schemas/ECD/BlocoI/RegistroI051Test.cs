using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI051Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI051();
        reg.Codigo.Should().Be("I051");
    }

    [TestCase("|I051|CC1|CONTA_REF1|", "900")]
    [TestCase("|I051|INST1|CC1|CONTA_REF1|", "700")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI051(linha, versao);
        reg.Codigo.Should().Be("I051");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I051|CC1|CONTA_REF1|", "900")]
    [TestCase("|I051|INST1|CC1|CONTA_REF1|", "700")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI051("", versao)
        {
            CodInstRespPlanoContasRef = "INST1",
            CodCentroCusto = "CC1",
            CodContaReferencial = "CONTA_REF1"
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I051|CC1|CONTA_REF1|", "900")]
    [TestCase("|I051|INST1|CC1|CONTA_REF1|", "700")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI051(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI051 reg, string versao)
    {
        reg.CodInstRespPlanoContasRef.Should().Be(versao == "700" ? "INST1" : null);
        reg.CodCentroCusto.Should().Be("CC1");
        reg.CodContaReferencial.Should().Be("CONTA_REF1");
    }
}
