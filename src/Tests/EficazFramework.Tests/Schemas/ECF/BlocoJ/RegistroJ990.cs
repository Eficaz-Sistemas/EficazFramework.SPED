using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoJ;

public class RegistroJ990 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ990();
        reg.Codigo.Should().Be("J990");
    }

    [TestCase("|J990|10|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J990|10|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ990("", versao)
        {
            QuantidadeLinhasBlocoJ = "10"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J990|10|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ990("", versao);
        reg.QuantidadeLinhasBlocoJ.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroJ990 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("J990");
        reg.Versao.Should().Be(versao);
        reg.QuantidadeLinhasBlocoJ.Should().Be("10");
    }
}
