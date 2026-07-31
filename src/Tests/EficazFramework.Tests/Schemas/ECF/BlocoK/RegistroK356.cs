using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoK;

public class RegistroK356 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK356();
        reg.Codigo.Should().Be("K356");
    }

    [TestCase("|K356|REF01|5000,00|C|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK356(linha, versao);
        reg.Codigo.Should().Be("K356");
    }

    [TestCase("|K356|REF01|5000,00|C|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK356("", versao)
        {
            CodigoContaReferencial = "REF01",
            VrSaldoFinalPeriodo = 5000.0d,
            IndicadorSituacaoSaldoFinal = "C"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|K356|REF01|5000,00|C|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroK356("", versao);
        reg.CodigoContaReferencial.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        reg.CodigoContaReferencial.Should().Be("REF01");
        reg.VrSaldoFinalPeriodo.Should().Be(5000.0d);
        reg.IndicadorSituacaoSaldoFinal.Should().Be("C");
    }
}
