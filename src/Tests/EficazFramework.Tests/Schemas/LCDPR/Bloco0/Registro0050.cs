using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.LCDPR.Bloco0;

public class Registro0050 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0050();
        reg.Codigo.Should().Be("0050");
    }


    [TestCase("0050|500|BR|756|Banco Cooperativo do Brasil S.|3195|9999")]
    public void Construtor(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0050(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("0050|500|BR|756|Banco Cooperativo do Brasil S.|3195|9999")]
    public void Escrita(string result, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0050("", versao)
        {
            CodigoContaBanco = 500,
            Pais = "BR",
            NumeroInstBancaria = "756",
            Nome = "Banco Cooperativo do Brasil S.",
            Agencia = "3195",
            NumeroCC = "9999"
        };
        reg.ToString().Should().Be(result);
    }


    [TestCase("0050|500|BR|756|Banco Cooperativo do Brasil S.|3195|9999")]
    public void Leitura(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0050("", versao);
        reg.CodigoContaBanco.Should().Be(null);
        reg.Pais.Should().Be("BR"); //default
        reg.NumeroInstBancaria.Should().Be(null);
        reg.Nome.Should().Be(null);
        reg.Agencia.Should().Be(null);
        reg.NumeroCC.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }


    private void InternalRead(EficazFramework.SPED.Schemas.LCDPR.Registro0050 reg, string versao = "0013")
    {
        reg.CodigoContaBanco.Should().Be(500);
        reg.Pais.Should().Be("BR");
        reg.NumeroInstBancaria.Should().Be("756");
        reg.Nome.Should().Be("Banco Cooperativo do Brasil S.");
        reg.Agencia.Should().Be("3195");
        reg.NumeroCC.Should().Be("9999");
    }
}
