using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoK;

public class RegistroK990 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK990();
        reg.Codigo.Should().Be("K990");
    }

    [TestCase("|K990|10|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K990|10|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK990("", versao)
        {
            QuantidadeLinhasBlocoK = "10"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K990|10|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK990("", versao);
        reg.QuantidadeLinhasBlocoK.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroK990 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("K990");
        reg.Versao.Should().Be(versao);
        reg.QuantidadeLinhasBlocoK.Should().Be("10");
    }
}
