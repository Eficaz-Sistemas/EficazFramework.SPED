using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoD;

public class RegistroD700 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD700();
        reg.Codigo.Should().Be("D700");
    }

    [TestCase("|D700|0|1|PART01|62|00|1|123456|01112022|01112022|100|0|100|0|0|0|100|12|COMP01|1,65|7,6|35191100000000000000620010001234561001234567|1|0|62|35191100000000000000620010001234561001234568|HASH123|1|123455|112022|3100104|0|", "019")]
    public void Construtor(string linha, string versao = "019")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD700(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|D700|0|1|PART01|62|00|1|123456|01112022|01112022|100|0|100|0|0|0|100|12|COMP01|1,65|7,6|35191100000000000000620010001234561001234567|1|0|62|35191100000000000000620010001234561001234568|HASH123|1|123455|112022|3100104|0|", "019")]
    public void Escrita(string result, string versao = "019")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD700("", versao)
        {
            Operacao = IndicadorOperacao.Entrada,
            Emissao = IndicadorEmitente.Terceiros,
            CodigoParticipante = "PART01",
            EspecieDocumento = "62",
            SituacaoDocumento = SituacaoDocumento.Regular,
            Serie = "1",
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
            ChaveDocEletronico = "35191100000000000000620010001234561001234567",
            FinalidadeEmissao = FinalidadeEmissaoDocE.Normal,
            TipoFaturamento = TipoFaturaDocE.Normal,
            EspecieDocReferenciado = "62",
            ChaveDocReferenciado = "35191100000000000000620010001234561001234568",
            HashDocReferenciado = "HASH123",
            SerieDocReferenciado = "1",
            NumeroDocReferenciado = 123455,
            CompetenciaDocReferenciado = new System.DateTime(2022, 11, 1),
            CodigoIbgeDestinatario = "3100104",
            Deducoes = 0.0d
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|D700|0|1|PART01|62|00|1|123456|01112022|01112022|100|0|100|0|0|0|100|12|COMP01|1,65|7,6|35191100000000000000620010001234561001234567|1|0|62|35191100000000000000620010001234561001234568|HASH123|1|123455|112022|3100104|0|", "019")]
    public void Leitura(string linha, string versao = "019")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD700("", versao);
        reg.CodigoParticipante.Should().BeNull();
        reg.ValorTotalDocumento.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD700 reg, string versao = "019")
    {
        reg.Codigo.Should().Be("D700");
        reg.Versao.Should().Be(versao);
        reg.Operacao.Should().Be(IndicadorOperacao.Entrada);
        reg.Emissao.Should().Be(IndicadorEmitente.Terceiros);
        reg.CodigoParticipante.Should().Be("PART01");
        reg.EspecieDocumento.Should().Be("62");
        reg.SituacaoDocumento.Should().Be(SituacaoDocumento.Regular);
        reg.Serie.Should().Be("1");
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
        reg.ChaveDocEletronico.Should().Be("35191100000000000000620010001234561001234567");
        reg.FinalidadeEmissao.Should().Be(FinalidadeEmissaoDocE.Normal);
        reg.TipoFaturamento.Should().Be(TipoFaturaDocE.Normal);
        reg.EspecieDocReferenciado.Should().Be("62");
        reg.ChaveDocReferenciado.Should().Be("35191100000000000000620010001234561001234568");
        reg.HashDocReferenciado.Should().Be("HASH123");
        reg.SerieDocReferenciado.Should().Be("1");
        reg.NumeroDocReferenciado.Should().Be(123455);
        reg.CodigoIbgeDestinatario.Should().Be("3100104");
        reg.Deducoes.Should().Be(0.0d);
    }
}
