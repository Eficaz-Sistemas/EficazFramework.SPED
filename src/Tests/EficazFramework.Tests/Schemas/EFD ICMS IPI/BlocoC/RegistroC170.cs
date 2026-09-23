using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC170 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC170();
        reg.Codigo.Should().Be("C170");
    }

    [TestCase("|C170|1|PROD01|Item teste|10|UN|100|0|0|000|5102|Venda|100|18|18|0|0|0||50|999|0|0|0|01|100|1,65|0|0|1,65|01|100|7,6|0|0|7,6|1.01.01|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC170(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C170|1|PROD01|Item teste|10|UN|100|0|0|000|5102|Venda|100|18|18|0|0|0||50|999|0|0|0|01|100|1,65|0|0|1,65|01|100|7,6|0|0|7,6|1.01.01|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC170("", versao)
        {
            NumeroSequencialItem = 1,
            CodigoProduto = "PROD01",
            DescricaoComplementarItem = "Item teste",
            Quantidade = 10.0d,
            UnidadeMedida = "UN",
            TotalItem = 100.0d,
            Desconto = 0.0d,
            IndicadorMovimento = true,
            Origem = NFe.OrigemMercadoria.Nacional,
            CST_ICMS = NFe.CST_ICMS.CST_00,
            CFOP = "5102",
            NaturezaOperacao = "Venda",
            BaseCalculo_ICMS = 100.0d,
            Aliquota_ICMS = 18.0d,
            Valor_ICMS = 18.0d,
            BaseCalculoST_ICMS = 0.0d,
            AliquotaST_ICMS = 0.0d,
            ValorST_ICMS = 0.0d,
            IndicadorApuracaoIPI = null,
            CST_IPI = "50",
            Enquadramento_IPI = "999",
            BaseCalculo_IPI = 0.0d,
            Aliquota_IPI = 0.0d,
            Valor_IPI = 0.0d,
            CST_PIS = NFe.CST_PIS.AliquotaNormal,
            BaseCalculo_PIS = 100.0d,
            AliquotaPercentual_PIS = 1.65d,
            BaseCalculoQuantidade_PIS = 0.0d,
            AliquotaReais_PIS = 0.0d,
            Valor_PIS = 1.65d,
            CST_COFINS = NFe.CST_COFINS.AliquotaNormal,
            BaseCalculo_COFINS = 100.0d,
            AliquotaPercentual_COFINS = 7.6d,
            BaseCalculoQuantidade_COFINS = 0.0d,
            AliquotaReais_COFINS = 0.0d,
            Valor_COFINS = 7.6d,
            CodigoContaContabil = "1.01.01",
            AbatimentosNT = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C170|1|PROD01|Item teste|10|UN|100|0|0|000|5102|Venda|100|18|18|0|0|0||50|999|0|0|0|01|100|1,65|0|0|1,65|01|100|7,6|0|0|7,6|1.01.01|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC170("", versao);
        reg.CodigoProduto.Should().BeNull();
        reg.TotalItem.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC170 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C170");
        reg.Versao.Should().Be(versao);
        reg.NumeroSequencialItem.Should().Be(1);
        reg.CodigoProduto.Should().Be("PROD01");
        reg.DescricaoComplementarItem.Should().Be("Item teste");
        reg.Quantidade.Should().Be(10.0d);
        reg.UnidadeMedida.Should().Be("UN");
        reg.TotalItem.Should().Be(100.0d);
        reg.Desconto.Should().Be(0.0d);
        reg.IndicadorMovimento.Should().BeTrue();
        reg.Origem.Should().Be(NFe.OrigemMercadoria.Nacional);
        reg.CST_ICMS.Should().Be(NFe.CST_ICMS.CST_00);
        reg.CFOP.Should().Be("5102");
        reg.NaturezaOperacao.Should().Be("Venda");
        reg.BaseCalculo_ICMS.Should().Be(100.0d);
        reg.Aliquota_ICMS.Should().Be(18.0d);
        reg.Valor_ICMS.Should().Be(18.0d);
        reg.CST_IPI.Should().Be("50");
        reg.Enquadramento_IPI.Should().Be("999");
        reg.CST_PIS.Should().Be(NFe.CST_PIS.AliquotaNormal);
        reg.Valor_PIS.Should().Be(1.65d);
        reg.CST_COFINS.Should().Be(NFe.CST_COFINS.AliquotaNormal);
        reg.Valor_COFINS.Should().Be(7.6d);
        reg.CodigoContaContabil.Should().Be("1.01.01");
    }
}
