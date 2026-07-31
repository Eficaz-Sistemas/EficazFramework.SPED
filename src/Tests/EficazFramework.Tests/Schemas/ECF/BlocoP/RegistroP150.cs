using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoP;

public class RegistroP150 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP150();
        reg.Codigo.Should().Be("P150");
    }

    [TestCase("|P150|3.01.01|Receita Bruta P150|S|3|3|3.01|100000,00|C|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP150(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|P150|3.01.01|Receita Bruta P150|S|3|4|3.01|100000,00|C|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP150("", versao)
        {
            CodigoReferencial = "3.01.01",
            Descricao = "Receita Bruta P150",
            TipoConta = "S",
            Nivel = 3,
            Natureza = ECD.TipoConta.Resultado,
            ContaSuperior = "3.01",
            Valor = 100000.0d,
            NaturezaSaldoInicial = "C"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|P150|3.01.01|Receita Bruta P150|S|3|3|3.01|100000,00|C|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP150("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroP150 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("P150");
        reg.Versao.Should().Be(versao);
    }
}
