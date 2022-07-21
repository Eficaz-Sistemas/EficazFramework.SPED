using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

public class Bloco0 : Tests.BaseTest
{
    [Test]
    public void Registro0220_Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0220();
        reg.Codigo.Should().Be("0220");
    }

    
    [TestCase("|0220|To|1000|", "015")]
    [TestCase("|0220|To|1000|0110110|", "016")]
    public void Registro0220_Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0220(linha, versao);
        Registro0220_InternalRead(reg, versao);
    }


    [TestCase("|0220|To|1000|", "015")]
    [TestCase("|0220|To|1000|0110110|", "016")]
    public void Registro0220_Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0220("", versao)
        {
            UnidadeComercialConvertida = "To",
            FatorConversao = 1000d,
            CodigoBarras = "0110110"
        };
        reg.ToString().Should().Be(result);

    }
    

    [TestCase("|0220|To|1000|", "015")]
    [TestCase("|0220|To|1000|0110110|", "016")]
    public void Registro0220_Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0220("", versao);
        reg.FatorConversao.HasValue.Should().Be(false);
        reg.UnidadeComercialConvertida.Should().Be(null);
        
        reg.LeParametros(linha.Split('|'));
        Registro0220_InternalRead(reg, versao);
    }


    private void Registro0220_InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0220 reg, string versao = "016", bool indicadorContribIcms = false)
    {
        reg.Codigo.Should().Be("0220");
        reg.Versao.Should().Be(versao);
        reg.UnidadeComercialConvertida.Should().Be("To");
        reg.FatorConversao.Should().Be(1000d);

        if (int.Parse(versao) >= 16)
            reg.CodigoBarras.Should().Be("0110110");
        else
            reg.CodigoBarras.Should().Be(null);

    }

}
