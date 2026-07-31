using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoN;

public class RegistroN615 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN615();
        reg.Codigo.Should().Be("N615");
    }

    [TestCase("|N615|100000,00|9,0000|9000,00|0,0000|0,00|9000,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN615(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|N615|100000,00|9,0000|9000,00|0,0000|0,00|9000,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN615("", versao)
        {
            BaseCalculoIncentivosFiscais = 100000.0d,
            PercentualIncentivoFINOR = 9.0d,
            ValorLiquidoFINOR = 9000.0d,
            PercentualFINAM = 0.0d,
            ValorLiquidoFINAM = 0.0d,
            TotalIncentivos = 9000.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|N615|100000,00|9,0000|9000,00|0,0000|0,00|9000,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroN615("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroN615 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("N615");
        reg.Versao.Should().Be(versao);
    }
}
