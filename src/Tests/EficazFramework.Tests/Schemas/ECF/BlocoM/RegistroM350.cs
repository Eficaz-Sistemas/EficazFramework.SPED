using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoM;

public class RegistroM350 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM350();
        reg.Codigo.Should().Be("M350");
    }

    [TestCase("|M350|1|Base de Cálculo CSLL|L|4|100000,00|Histórico M350|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM350(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|M350|1|Base de Cálculo CSLL|L|4|100000,00|Histórico M350|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM350("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Base de Cálculo CSLL",
            TipoConta = "L",
            IndicadorRelacao = "4",
            Valor = 100000.0d,
            Historico = "Histórico M350"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|M350|1|Base de Cálculo CSLL|L|4|100000,00|Histórico M350|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM350("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroM350 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("M350");
        reg.Versao.Should().Be(versao);
    }
}
