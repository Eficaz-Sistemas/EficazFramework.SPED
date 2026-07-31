using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.Bloco9;

public class Registro9999 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro9999();
        reg.Codigo.Should().Be("9999");
    }

    [TestCase("|9999|100|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro9999(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|9999|100|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro9999("", versao)
        {
            TotalLinhas = 100
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|9999|100|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.Registro9999("", versao);
        reg.TotalLinhas.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        reg.Codigo.Should().Be("9999");
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.Registro9999 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("9999");
        reg.Versao.Should().Be(versao);
    }
}
