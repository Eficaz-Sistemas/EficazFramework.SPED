using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.LCDPR.Bloco0;

public class Registro0000 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0000();
        reg.Codigo.Should().Be("0000");
    }

    
    [TestCase("0000|LCDPR|0013|12345678900|José das Coves|0|0||01012021|31122021")]
    public void Construtor(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0000(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("0000|LCDPR|0013|12345678900|José das Coves|0|0||01012021|31122021")]
    public void Escrita(string result, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0000("", versao)
        {
            DataInicial = new System.DateTime(2021, 1, 1),
            DataFinal = new System.DateTime(2021, 12, 31),
            Nome = "José das Coves",
            CPF = "12345678900",
            IndicadorSitInicioPeriodo = SituacaoInicioPeriodo.Regular,
            DataSituacaoEspecial = null,
            SituacaoEspecial = SituacaoEspecial.Normal,
        };
        reg.ToString().Should().Be(result);

    }


    [TestCase("0000|LCDPR|0013|12345678900|José das Coves|0|0||01012021|31122021")]
    public void Leitura(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0000("", versao);
        reg.DataInicial.Should().Be(null);
        reg.DataFinal.Should().Be(null);
        reg.Nome.Should().Be(null);
        reg.CPF.Should().Be(null);
        reg.DataSituacaoEspecial.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }


    private void InternalRead(EficazFramework.SPED.Schemas.LCDPR.Registro0000 reg, string versao = "0013")
    {
        reg.Codigo.Should().Be("0000");
        reg.Versao.Should().Be(versao);
        reg.DataInicial.Should().Be(new System.DateTime(2021, 1, 1));
        reg.DataFinal.Should().Be(new System.DateTime(2021, 12, 31));
        reg.Nome.Should().Be("José das Coves");
        reg.CPF.Should().Be("12345678900");
        reg.IndicadorSitInicioPeriodo.Should().Be(SituacaoInicioPeriodo.Regular);
        reg.DataSituacaoEspecial.Should().Be(null);
        reg.SituacaoEspecial.Should().Be(SituacaoEspecial.Normal);
    }

}
