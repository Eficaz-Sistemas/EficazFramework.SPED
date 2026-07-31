using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoJ;

public class RegistroJ100 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ100();
        reg.Codigo.Should().Be("J100");
    }

    [TestCase("|J100|01/01/2022 00:00:00|CC01|Administrativo|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ100(linha, versao);
        reg.Codigo.Should().Be("J100");
    }

    [TestCase("|J100|01/01/2022 00:00:00|CC01|Administrativo|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ100("", versao)
        {
            DataInclusaoAlteracao = new System.DateTime(2022, 1, 1),
            CodCentroCusto = "CC01",
            NomeCentroCusto = "Administrativo"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J100|01/01/2022 00:00:00|CC01|Administrativo|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ100("", versao);
        reg.CodCentroCusto.Should().BeNull();
        reg.NomeCentroCusto.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        reg.CodCentroCusto.Should().Be("CC01");
        reg.NomeCentroCusto.Should().Be("Administrativo");
    }
}
