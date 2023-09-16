using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE500 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE500();
        reg.Codigo.Should().Be("E500");
    }

    
    [TestCase("|E500|0|01052023|31052023|", "015")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE500(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("|E500|0|01052023|31052023|", "015")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE500("", versao)
        {
            IndicadorPeriodo = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.IndicadorPeriodoIPI.Mensal,
            DataInicial = new DateTime(2023, 05, 01),
            DataFinal = new DateTime(2023, 05, 31)
        };
        
       
        reg.ToString().Should().Be(result);
    }


    [TestCase("|E500|0|01052023|31052023|", "015")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE500("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE500 reg, string versao = "016")
    {
        reg.IndicadorPeriodo.Should().Be(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.IndicadorPeriodoIPI.Mensal);
        reg.DataInicial.Should().Be(new DateTime(2023, 05, 01));
        reg.DataFinal.Should().Be(new DateTime(2023, 05, 31));
    }
}
