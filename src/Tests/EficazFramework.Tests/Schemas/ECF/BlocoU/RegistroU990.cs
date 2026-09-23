using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoU;

public class RegistroU990 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU990();
        reg.Codigo.Should().Be("U990");
    }

    [TestCase("|U990|10|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|U990|10|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU990("", versao)
        {
            QuantidadeLinhasBlocoK = "10"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|U990|10|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU990("", versao);
        reg.QuantidadeLinhasBlocoK.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroU990 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("U990");
        reg.Versao.Should().Be(versao);
        reg.QuantidadeLinhasBlocoK.Should().Be("10");
    }
}
