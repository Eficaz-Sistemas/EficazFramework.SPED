using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoJ;

public class RegistroJ051 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ051();
        reg.Codigo.Should().Be("J051");
    }

    [TestCase("|J051|CC01|REF01|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ051(linha, versao);
        reg.Codigo.Should().Be("J051");
    }

    [TestCase("|J051|CC01|REF01|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ051("", versao)
        {
            CodCentroCusto = "CC01",
            CodContaReferencial = "REF01"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J051|CC01|REF01|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ051("", versao);
        reg.CodCentroCusto.Should().BeNull();
        reg.CodContaReferencial.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        reg.CodCentroCusto.Should().Be("CC01");
        reg.CodContaReferencial.Should().Be("REF01");
    }
}
