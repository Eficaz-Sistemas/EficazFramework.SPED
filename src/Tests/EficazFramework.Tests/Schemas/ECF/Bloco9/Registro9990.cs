using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.Bloco9;

public class Registro9990 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro9990();
        reg.Codigo.Should().Be("9990");
    }

    [TestCase("|9990|10|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro9990(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|9990|10|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro9990("", versao)
        {
            TotalLinhas = "10"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|9990|10|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro9990("", versao);
        reg.TotalLinhas.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.Registro9990 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("9990");
        reg.Versao.Should().Be(versao);
        reg.TotalLinhas.Should().Be("10");
    }
}
