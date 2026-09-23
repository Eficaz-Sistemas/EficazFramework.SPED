using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoD;

public class RegistroD500 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD500();
        reg.Codigo.Should().Be("D500");
    }

    [TestCase("|D500|0|1|PART01|21|00|1|0|123456|01112022|01112022|100|0|100|0|0|0|100|12|COMP01|1,65|7,6|CONTA01|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD500(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|D500|0|1|PART01|21|00|1|0|123456|01112022|01112022|100|0|100|0|0|0|100|12|COMP01|1,65|7,6|CONTA01|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD500("", versao)
        {
            Operacao = IndicadorOperacao.Entrada,
            Emissao = IndicadorEmitente.Terceiros,
            CodigoParticipante = "PART01",
            EspecieDocumento = "21",
            SituacaoDocumento = SituacaoDocumento.Regular,
            Serie = "1",
            SubSerie = "0",
            Numero = 123456,
            DataEmissao = new System.DateTime(2022, 11, 1),
            DataPrestacaoAquisicao = new System.DateTime(2022, 11, 1),
            ValorTotalDocumento = 100.0d,
            ValorDesconto = 0.0d,
            ValorServicos = 100.0d,
            ValorServicosICMSNaoTributato = 0.0d,
            ValorCobradoTerceiros = 0.0d,
            ValorDespesasAcessorias = 0.0d,
            ValorBaseCalculoICMS = 100.0d,
            ValorICMS = 12.0d,
            CodigoInformacaoComplementar0450 = "COMP01",
            ValorPIS = 1.65d,
            ValorCofins = 7.6d,
            CodigoContaContabil = "CONTA01",
            TipoAssinante = TipoAssinanteComunincacao.Comercial_Industrial
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|D500|0|1|PART01|21|00|1|0|123456|01112022|01112022|100|0|100|0|0|0|100|12|COMP01|1,65|7,6|CONTA01|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD500("", versao);
        reg.CodigoParticipante.Should().BeNull();
        reg.ValorTotalDocumento.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD500 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("D500");
        reg.Versao.Should().Be(versao);
        reg.Operacao.Should().Be(IndicadorOperacao.Entrada);
        reg.Emissao.Should().Be(IndicadorEmitente.Terceiros);
        reg.CodigoParticipante.Should().Be("PART01");
        reg.EspecieDocumento.Should().Be("21");
        reg.SituacaoDocumento.Should().Be(SituacaoDocumento.Regular);
        reg.Serie.Should().Be("1");
        reg.SubSerie.Should().Be("0");
        reg.Numero.Should().Be(123456);
        reg.DataEmissao.Should().Be(new System.DateTime(2022, 11, 1));
        reg.DataPrestacaoAquisicao.Should().Be(new System.DateTime(2022, 11, 1));
        reg.ValorTotalDocumento.Should().Be(100.0d);
        reg.ValorDesconto.Should().Be(0.0d);
        reg.ValorServicos.Should().Be(100.0d);
        reg.ValorServicosICMSNaoTributato.Should().Be(0.0d);
        reg.ValorCobradoTerceiros.Should().Be(0.0d);
        reg.ValorDespesasAcessorias.Should().Be(0.0d);
        reg.ValorBaseCalculoICMS.Should().Be(100.0d);
        reg.ValorICMS.Should().Be(12.0d);
        reg.CodigoInformacaoComplementar0450.Should().Be("COMP01");
        reg.ValorPIS.Should().Be(1.65d);
        reg.ValorCofins.Should().Be(7.6d);
        reg.CodigoContaContabil.Should().Be("CONTA01");
        reg.TipoAssinante.Should().Be(TipoAssinanteComunincacao.Comercial_Industrial);
    }
}
