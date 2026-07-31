using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoM;

public class RegistroM500 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM500();
        reg.Codigo.Should().Be("M500");
    }

    [TestCase("|M500|CB001|I|50000,00|D|10000,00|D|0,00|D|60000,00|D|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM500(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|M500|CB001|I|50000,00|D|10000,00|D|0,00|D|60000,00|D|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM500("", versao)
        {
            CodigoContaB = "CB001",
            CodigoTributo = "I",
            SaldoInicial = 50000.0d,
            NaturezaSaldoInicial = "D",
            ValorLanctoParteA = 10000.0d,
            NaturezaLanctoParteA = "D",
            ValorLanctoParteB = 0.0d,
            NaturezaLanctoParteB = "D",
            SaldoFinal = 60000.0d,
            NaturezaSaldoFinal = "D"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|M500|CB001|I|50000,00|D|10000,00|D|0,00|D|60000,00|D|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM500("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroM500 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("M500");
        reg.Versao.Should().Be(versao);
    }
}
