using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.LCDPR.BlocoQ;

public class RegistroQ200 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.RegistroQ200();
        reg.Codigo.Should().Be("Q200");
    }

    
    [TestCase("Q200|012021|250010|209856|40154|P")]
    public void Construtor(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.RegistroQ200(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("Q200|012021|250010|209856|40154|P")]
    public void Escrita(string result, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.RegistroQ200("", versao)
        {
            Competencia = new System.DateTime(2021, 1, 1),
            ValorEntrada = 2500.1D,
            ValorSaida = 2098.56D,
            SaldoFinal = 401.54d,
            SaldoFinal_Natureza = "P"
        };
        reg.ToString().Should().Be(result);

    }


    [TestCase("Q200|012021|250010|209856|40154|P")]
    public void Leitura(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.RegistroQ200("", versao);
        reg.Competencia.Should().Be(null);
        reg.ValorEntrada.Should().Be(null);
        reg.ValorSaida.Should().Be(null);
        reg.SaldoFinal.Should().Be(null);
        reg.SaldoFinal_Natureza.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }


    private void InternalRead(EficazFramework.SPED.Schemas.LCDPR.RegistroQ200 reg, string versao = "0013")
    {
        reg.Codigo.Should().Be("Q200");
        reg.Versao.Should().Be(versao);
        reg.Competencia.Should().Be(new System.DateTime(2021, 1, 1));
        reg.ValorEntrada.Should().Be(2500.1D);
        reg.ValorSaida.Should().Be(2098.56D);
        reg.SaldoFinal.Should().Be(401.54d);
        reg.SaldoFinal_Natureza.Should().Be("P");
    }

}
