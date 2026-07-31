using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoP;

public class RegistroP500 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP500();
        reg.Codigo.Should().Be("P500");
    }

    [TestCase("|P500|1|Cálculo CSLL Presumido|2880,00|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP500(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|P500|1|Cálculo CSLL Presumido|2880,00|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP500("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Cálculo CSLL Presumido",
            Valor = 2880.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|P500|1|Cálculo CSLL Presumido|2880,00|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroP500("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroP500 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("P500");
        reg.Versao.Should().Be(versao);
    }
}
