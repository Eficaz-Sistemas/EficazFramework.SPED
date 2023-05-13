using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoE;

public class RegistroE510 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE510();
        reg.Codigo.Should().Be("E510");
    }

    
    [TestCase("|E510|5101|99|100,57|104,48|10,01|", "015")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE510(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("|E510|5101|99|100,57|104,48|10,01|", "015")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE510("", versao)
        {
            CFOP = "5101",
            CST = NFe.CST_IPI.OutrasSaidas,
            ValorContabil = 100.57d,
            BaseDeCalculo = 104.48d,
            ValorIpi = 10.01d
        };
        
       
        reg.ToString().Should().Be(result);
    }


    [TestCase("|E510|5101|99|100,57|104,48|10,01|", "015")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE510("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroE510 reg, string versao = "016")
    {
        reg.CFOP.Should().Be("5101");
        reg.CST.Should().Be(NFe.CST_IPI.OutrasSaidas);
        reg.ValorContabil.Should().Be(100.57d);
        reg.BaseDeCalculo.Should().Be(104.48d);
        reg.ValorIpi.Should().Be(10.01d);
    }
}
