using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoL;

public class RegistroL300 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL300();
        reg.Codigo.Should().Be("L300");
    }

    [TestCase("|L300|3.01.01|Receita de Vendas|S|3|3|3.01|50000,00|C|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL300(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|L300|3.01.01|Receita de Vendas|S|3|4|3.01|50000,00|C|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL300("", versao)
        {
            CodigoReferencial = "3.01.01",
            Descricao = "Receita de Vendas",
            TipoConta = "S",
            Nivel = 3,
            Natureza = ECD.TipoConta.Resultado,
            ContaSuperior = "3.01",
            Valor = 50000.0d,
            NaturezaSaldoInicial = "C"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|L300|3.01.01|Receita de Vendas|S|3|3|3.01|50000,00|C|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroL300("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroL300 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("L300");
        reg.Versao.Should().Be(versao);
    }
}
