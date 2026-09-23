using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoU;

public class RegistroU150 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU150();
        reg.Codigo.Should().Be("U150");
    }

    [TestCase("|U150|3.01.01|Receita Bruta U150|S|3|3|3.01|100000,00|C|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU150(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|U150|3.01.01|Receita Bruta U150|S|3|4|3.01|100000,00|C|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU150("", versao)
        {
            CodigoReferencial = "3.01.01",
            Descricao = "Receita Bruta U150",
            TipoConta = "S",
            Nivel = 3,
            Natureza = ECD.TipoConta.Resultado,
            ContaSuperior = "3.01",
            Valor = 100000.0d,
            NaturezaSaldoInicial = "C"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|U150|3.01.01|Receita Bruta U150|S|3|3|3.01|100000,00|C|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroU150("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroU150 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("U150");
        reg.Versao.Should().Be(versao);
    }
}
