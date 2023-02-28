using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoD;

public class RegistroD510 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD510();
        reg.Codigo.Should().Be("D510");
    }

    
    [TestCase("|D510|2|Rvsta|0123|158|Un|500,85||040|1303|539,8|18|100|6|42|0||1,65|7,6||", "015")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD510(linha, versao);
        InternalRead(reg, versao);
    }

    
    [TestCase("|D510|2|Rvsta|0123|158|Un|500,85||040|1303|539,8|18|100|6|42|0||1,65|7,6||", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD510("", versao)
        {
            NumeroSequencialItem = 2,
            CodigoProduto = "Rvsta",
            CodigoClassificacao = "0123",
            Quantidade = 158,
            UnidadeMedida = "Un",
            ValorItem = 500.85d,
            Origem = NFe.OrigemMercadoria.Nacional,
            CST_ICMS = NFe.CST_ICMS.CST_40,
            CFOP = "1303",
            BaseCalculo_ICMS = 539.8d,
            Aliquota_ICMS = 18d,
            Valor_ICMS = 100d,
            BaseCalculo_ICMS_UFs = 6d,
            Valor_ICMS_UFs = 42d,
            IndicadorReceita = IndicadorTipoReceitaTelecom.PropriaServPrestado,
            Valor_PIS = 1.65,
            Valor_COFINS = 7.6
        };
        
       
        reg.ToString().Should().Be(result);
    }


    [TestCase("|D510|2|Rvsta|0123|158|Un|500,85||040|1303|539,8|18|100|6|42|0||1,65|7,6||", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD510("", versao);
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD510 reg, string versao = "016")
    {
        reg.NumeroSequencialItem.Should().Be(2);
        reg.CodigoProduto.Should().Be("Rvsta");
        reg.CodigoClassificacao.Should().Be("0123");
        reg.Quantidade.Should().Be(158);
        reg.UnidadeMedida.Should().Be("Un");
        reg.ValorItem.Should().Be(500.85d);
        reg.Desconto.Should().BeNull();
        reg.Origem.Should().Be(NFe.OrigemMercadoria.Nacional);
        reg.CST_ICMS.Should().Be(NFe.CST_ICMS.CST_40);
        reg.CFOP.Should().Be("1303");
        reg.BaseCalculo_ICMS.Should().Be(539.8d);
        reg.Aliquota_ICMS.Should().Be(18d);
        reg.Valor_ICMS.Should().Be(100d);
        reg.BaseCalculo_ICMS_UFs.Should().Be(6d);
        reg.Valor_ICMS_UFs.Should().Be(42d);
        reg.Valor_PIS.Should().Be(1.65d);
        reg.Valor_COFINS.Should().Be(7.6d);

    }
}
