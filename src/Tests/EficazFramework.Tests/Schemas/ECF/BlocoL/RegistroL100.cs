using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoL;

public class RegistroL100 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL100();
        reg.Codigo.Should().Be("L100");
    }

    [TestCase("|L100|1.01.01.01|Caixa|A|4|1|1.01.01|1000,00|D|500,00|200,00|1300,00|D|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL100(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|L100|1.01.01.01|Caixa|A|4|1|1.01.01|1000,00|D|500,00|200,00|1300,00|D|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL100("", versao)
        {
            CodigoReferencial = "1.01.01.01",
            Descricao = "Caixa",
            TipoConta = "A",
            Nivel = 4,
            Natureza = ECD.TipoConta.Ativo,
            ContaSuperior = "1.01.01",
            SaldoInicial = 1000.0d,
            NaturezaSaldoInicial = "D",
            Debitos = 500.0d,
            Creditos = 200.0d,
            SaldoFinal = 1300.0d,
            NaturezaSaldoFinal = "D"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|L100|1.01.01.01|Caixa|A|4|1|1.01.01|1000,00|D|500,00|200,00|1300,00|D|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL100("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroL100 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("L100");
        reg.Versao.Should().Be(versao);
    }
}
