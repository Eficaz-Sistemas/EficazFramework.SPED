using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Bloco0;

public class Registro0220 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0220();
        reg.Codigo.Should().Be("0220");
    }

    
    [TestCase("|0220|To|1000|", "015")]
    [TestCase("|0220|To|1000|0110110|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0220(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("|0220|To|1000|", "015")]
    [TestCase("|0220|To|1000|0110110|", "016")]
    public void Escrita(string result, string versao = "016")
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
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0220("", versao);
        reg.FatorConversao.HasValue.Should().Be(false);
        reg.UnidadeComercialConvertida.Should().Be(null);
        
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }


    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0220 reg, string versao = "016", bool indicadorContribIcms = false)
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
