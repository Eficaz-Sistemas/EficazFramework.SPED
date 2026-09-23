using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoL;

public class RegistroL990 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL990();
        reg.Codigo.Should().Be("L990");
    }

    [TestCase("|L990|10|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|L990|10|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL990("", versao)
        {
            QuantidadeLinhasBlocoL = "10"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|L990|10|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL990("", versao);
        reg.QuantidadeLinhasBlocoL.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroL990 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("L990");
        reg.Versao.Should().Be(versao);
        reg.QuantidadeLinhasBlocoL.Should().Be("10");
    }
}
