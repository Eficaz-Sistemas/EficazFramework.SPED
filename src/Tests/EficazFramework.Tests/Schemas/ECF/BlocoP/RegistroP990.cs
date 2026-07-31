using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoP;

public class RegistroP990 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP990();
        reg.Codigo.Should().Be("P990");
    }

    [TestCase("|P990|10|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|P990|10|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP990("", versao)
        {
            QuantidadeLinhasBlocoP = "10"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|P990|10|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP990("", versao);
        reg.QuantidadeLinhasBlocoP.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroP990 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("P990");
        reg.Versao.Should().Be(versao);
        reg.QuantidadeLinhasBlocoP.Should().Be("10");
    }
}
