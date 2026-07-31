using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoC;

public class RegistroC100 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC100();
        reg.Codigo.Should().Be("C100");
    }

    [TestCase("|C100|0|0|PART01|55|00|001|123456|35191100000000000000550010001234561001234567|01112022|01112022|1000|0|0|0|1000|9|0|0|0|1000|180|0|0|0|16,5|76|0|0|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC100(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|C100|0|0|PART01|55|00|001|123456|35191100000000000000550010001234561001234567|01112022|01112022|1000|0|0|0|1000|9|0|0|0|1000|180|0|0|0|16,5|76|0|0|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC100("", versao)
        {
            Operacao = IndicadorOperacao.Entrada,
            Emissao = IndicadorEmitente.Propria,
            CodigoParticipante = "PART01",
            EspecieDocumento = "55",
            SituacaoDocumento = SituacaoDocumento.Regular,
            Serie = "001",
            Numero = 123456,
            ChaveNFe = "35191100000000000000550010001234561001234567",
            DataEmissao = new System.DateTime(2022, 11, 1),
            DataEntradaSaida = new System.DateTime(2022, 11, 1),
            ValorTotalDocumento = 1000.0d,
            Pagamento = IndicadorPagamento.Vista,
            ValorDesconto = 0.0d,
            ValorAbatimento = 0.0d,
            ValorTotalMercadorias = 1000.0d,
            TipoFrete = IndicadorFrete.SemFrete,
            ValorFrete = 0.0d,
            ValorSeguro = 0.0d,
            ValorOutrasDespesas = 0.0d,
            ValorBaseCalculoICMS = 1000.0d,
            ValorICMS = 180.0d,
            ValorBaseCalculoICMSST = 0.0d,
            ValorICMSST = 0.0d,
            ValorIPI = 0.0d,
            ValorPIS = 16.5d,
            ValorCofins = 76.0d,
            ValorPISST = 0.0d,
            ValorCofinsST = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|C100|0|0|PART01|55|00|001|123456|35191100000000000000550010001234561001234567|01112022|01112022|1000|0|0|0|1000|9|0|0|0|1000|180|0|0|0|16,5|76|0|0|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC100("", versao);
        reg.CodigoParticipante.Should().BeNull();
        reg.ValorTotalDocumento.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC100 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("C100");
        reg.Versao.Should().Be(versao);
        reg.Operacao.Should().Be(IndicadorOperacao.Entrada);
        reg.Emissao.Should().Be(IndicadorEmitente.Propria);
        reg.CodigoParticipante.Should().Be("PART01");
        reg.EspecieDocumento.Should().Be("55");
        reg.SituacaoDocumento.Should().Be(SituacaoDocumento.Regular);
        reg.Serie.Should().Be("001");
        reg.Numero.Should().Be(123456);
        reg.ChaveNFe.Should().Be("35191100000000000000550010001234561001234567");
        reg.DataEmissao.Should().Be(new System.DateTime(2022, 11, 1));
        reg.DataEntradaSaida.Should().Be(new System.DateTime(2022, 11, 1));
        reg.ValorTotalDocumento.Should().Be(1000.0d);
        reg.Pagamento.Should().Be(IndicadorPagamento.Vista);
        reg.ValorTotalMercadorias.Should().Be(1000.0d);
        reg.TipoFrete.Should().Be(IndicadorFrete.SemFrete);
        reg.ValorBaseCalculoICMS.Should().Be(1000.0d);
        reg.ValorICMS.Should().Be(180.0d);
        reg.ValorPIS.Should().Be(16.5d);
        reg.ValorCofins.Should().Be(76.0d);
    }
}
