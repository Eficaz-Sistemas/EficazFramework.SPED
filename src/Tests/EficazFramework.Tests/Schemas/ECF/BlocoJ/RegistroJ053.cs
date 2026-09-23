using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECF.BlocoJ;

public class RegistroJ053 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ053();
        reg.Codigo.Should().Be("J053");
    }

    [TestCase("|J053|GRP01|SUB01|01|", "00010")]
    public void Construtor(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ053(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|J053|GRP01|SUB01|01|", "00010")]
    public void Escrita(string result, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ053("", versao)
        {
            CodIdentGrupoContaSubconta = "GRP01",
            CodSubcontaCorrelata = "SUB01",
            NaturezaSubcontaCorrelata = "01"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|J053|GRP01|SUB01|01|", "00010")]
    public void Leitura(string linha, string versao = "00010")
    {
        var reg = new EficazFramework.SPED.Schemas.ECF.RegistroJ053("", versao);
        reg.CodIdentGrupoContaSubconta.Should().BeNull();
        reg.CodSubcontaCorrelata.Should().BeNull();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.ECF.RegistroJ053 reg, string versao = "00010")
    {
        reg.Codigo.Should().Be("J053");
        reg.Versao.Should().Be(versao);
        reg.CodIdentGrupoContaSubconta.Should().Be("GRP01");
        reg.CodSubcontaCorrelata.Should().Be("SUB01");
        reg.NaturezaSubcontaCorrelata.Should().Be("01");
    }
}
