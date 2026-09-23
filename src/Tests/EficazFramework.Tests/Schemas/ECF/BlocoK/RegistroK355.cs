using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoK;

public class RegistroK355 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK355();
        reg.Codigo.Should().Be("K355");
    }

    [TestCase("|K355|3.01.01.001|CC01|5000,00|C|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK355(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|K355|3.01.01.001|CC01|5000,00|C|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK355("", versao)
        {
            CodContaAnaliticaResultado = "3.01.01.001",
            CodCentroCusto = "CC01",
            VrSaldoFinalAntesEncerramento = 5000.0d,
            IndicadorSituacaoSaldoFinal = "C"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K355|3.01.01.001|CC01|5000,00|C|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK355("", versao);
        reg.CodContaAnaliticaResultado.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroK355 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("K355");
        reg.Versao.Should().Be(versao);
        reg.CodContaAnaliticaResultado.Should().Be("3.01.01.001");
        reg.CodCentroCusto.Should().Be("CC01");
        reg.VrSaldoFinalAntesEncerramento.Should().Be(5000.0d);
        reg.IndicadorSituacaoSaldoFinal.Should().Be("C");
    }
}
