using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoM;

public class RegistroM310 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM310();
        reg.Codigo.Should().Be("M310");
    }

    [TestCase("|M310|1.01.01.001|CC01|2500,00|D|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM310(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|M310|1.01.01.001|CC01|2500,00|D|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM310("", versao)
        {
            CodigoContaContabil = "1.01.01.001",
            CentroDeCusto = "CC01",
            Valor = 2500.0d,
            Natureza = "D"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|M310|1.01.01.001|CC01|2500,00|D|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM310("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroM310 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("M310");
        reg.Versao.Should().Be(versao);
    }
}
