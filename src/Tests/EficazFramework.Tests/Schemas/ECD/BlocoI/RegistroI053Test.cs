using EficazFramework.SPED.Schemas.ECD;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.BlocoI;

public class RegistroI053Test : EficazFramework.SPED.Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new RegistroI053();
        reg.Codigo.Should().Be("I053");
    }

    [TestCase("|I053|GRP1|SUB1|NAT1|", "900")]
    public void Construtor(string linha, string versao)
    {
        var reg = new RegistroI053(linha, versao);
        reg.Codigo.Should().Be("I053");
        reg.Versao.Should().Be(versao);
        InternalRead(reg, versao);
    }

    [TestCase("|I053|GRP1|SUB1|NAT1|", "900")]
    public void Escrita(string result, string versao)
    {
        var reg = new RegistroI053()
        {
            CodIdentGrupoContaSubconta = "GRP1",
            CodSubcontaCorrelata = "SUB1",
            NaturezaSubcontaCorrelata = "NAT1"
        };
        reg.EscreveLinha().Should().Be(result);
    }

    [TestCase("|I053|GRP1|SUB1|NAT1|", "900")]
    public void Leitura(string linha, string versao)
    {
        var reg = new RegistroI053(linha, versao);
        InternalRead(reg, versao);
    }

    private void InternalRead(RegistroI053 reg, string versao)
    {
        reg.CodIdentGrupoContaSubconta.Should().Be("GRP1");
        reg.CodSubcontaCorrelata.Should().Be("SUB1");
        reg.NaturezaSubcontaCorrelata.Should().Be("NAT1");
    }
}
