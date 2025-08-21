using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes.BlocoF;

public class RegistroF600 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroF600();
        reg.Codigo.Should().Be("F600");
    }

    
    [TestCase("|F600|03|01072025|6500|237,25||0|10608025000126|42,25|195|0|", "006")]
    public void Construtor(string linha, string versao = "006")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroF600(linha, versao);
        InternalRead(reg, versao);
    }

    
    [TestCase("|F600|03|01072025|6500|237,25||0|10608025000126|42,25|195|0|", "006")]
    public void Escrita(string result, string versao = "006")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroF600("", versao)
        {
            IndicadorNatRetFonte = IndicadorNatRetFonte.RetencaoPessoasJuridicasDireitoPrivado,
            DataRetencao = new DateTime(2025, 07, 01),
            VrBcRetencao = 6500d,
            VrTotalRetidoFonte = 237.25d,
            CodigoReceita = null,
            IndicadorNatRec = IndicadorNaturezaReceita.ReceitaNaturezaNaoCumulativa,
            CNPJFontePagadora = "10608025000126",
            VrRetidoFontePis = 42.25d,
            VrRetidoFonteCofins = 195d,
            IndicadorCondDeclarante = IndicadorCondicaoPJDeclarante.BeneficiariaRetencao
        };
        
        reg.ToString().Should().Be(result);
    }


    [TestCase("|F600|03|01072025|6500|237,25||0|10608025000126|42,25|195|0|", "006")]
    public void Leitura(string linha, string versao = "006")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroF600("", versao);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroF600 reg, string versao = "006")
    {
        reg.IndicadorNatRetFonte.Should().Be(IndicadorNatRetFonte.RetencaoPessoasJuridicasDireitoPrivado);
        reg.DataRetencao = new DateTime(2025, 07, 01);
        reg.VrBcRetencao.Should().Be(6500d);
        reg.VrTotalRetidoFonte.Should().Be(237.25d);
        reg.CodigoReceita.Should().BeNullOrEmpty();
        reg.IndicadorNatRec.Should().Be(IndicadorNaturezaReceita.ReceitaNaturezaNaoCumulativa);
        reg.CNPJFontePagadora.Should().Be("10608025000126");
        reg.VrRetidoFontePis.Should().Be(42.25d);
        reg.VrRetidoFonteCofins.Should().Be(195d);
        reg.IndicadorCondDeclarante.Should().Be(IndicadorCondicaoPJDeclarante.BeneficiariaRetencao);


    }
}
