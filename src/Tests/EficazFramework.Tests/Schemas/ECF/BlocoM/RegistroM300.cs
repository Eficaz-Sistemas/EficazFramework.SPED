using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoM;

public class RegistroM300 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM300();
        reg.Codigo.Should().Be("M300");
    }

    [TestCase("|M300|1|Lucro Líquido do Período|L|4|100000,00|Histórico M300|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM300(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|M300|1|Lucro Líquido do Período|L|4|100000,00|Histórico M300|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM300("", versao)
        {
            CodigoReferencial = "1",
            Descricao = "Lucro Líquido do Período",
            TipoConta = "L",
            IndicadorRelacao = "4",
            Valor = 100000.0d,
            Historico = "Histórico M300"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|M300|1|Lucro Líquido do Período|L|4|100000,00|Histórico M300|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM300("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroM300 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("M300");
        reg.Versao.Should().Be(versao);
    }
}
