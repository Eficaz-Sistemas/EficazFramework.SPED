using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.Bloco0;

public class Registro0990 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0990();
        reg.Codigo.Should().Be("0990");
    }

    [TestCase("|0990|10|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|0990|10|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0990("", versao)
        {
            QuantidadeLinhasBloco0 = "10"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|0990|10|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro0990("", versao);
        reg.QuantidadeLinhasBloco0.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.Registro0990 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("0990");
        reg.Versao.Should().Be(versao);
        reg.QuantidadeLinhasBloco0.Should().Be("10");
    }
}
