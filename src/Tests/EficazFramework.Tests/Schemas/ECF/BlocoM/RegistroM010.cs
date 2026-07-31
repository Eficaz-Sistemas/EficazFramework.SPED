using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoM;

public class RegistroM010 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM010();
        reg.Codigo.Should().Be("M010");
    }

    [TestCase("|M010|CB001|Prejuízos Acumulados|31122022|LAN01|31122027|I|50000,00|D|12345678000100|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM010(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|M010|CB001|Prejuízos Acumulados|31122022|LAN01|31122027|I|50000,00|D|12345678000100|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM010("", versao)
        {
            CodigoContaB = "CB001",
            Descricao = "Prejuízos Acumulados",
            DataFinal = new System.DateTime(2022, 12, 31),
            CodigoLancamentoOrigem = "LAN01",
            DataLimite = new System.DateTime(2027, 12, 31),
            CodigoTributo = "I",
            SaldoInicial = 50000.0d,
            NaturezaSaldoInicial = "D",
            CNPJSituacaoEspecial = "12345678000100"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|M010|CB001|Prejuízos Acumulados|31122022|LAN01|31122027|I|50000,00|D|12345678000100|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroM010("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroM010 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("M010");
        reg.Versao.Should().Be(versao);
    }
}
