using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoD;

public class RegistroD100 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD100();
        reg.Codigo.Should().Be("D100");
    }

    [TestCase("|D100|0|0|PART01|57|00|1|0|123456|35191100000000000000570010001234561001234567|01112022|01112022|0|35191100000000000000570010001234561001234568|1000|0|9|1000|1000|120|0|COMP01|CONTA01|3100104|3100203|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD100(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|D100|0|0|PART01|57|00|1|0|123456|35191100000000000000570010001234561001234567|01112022|01112022|0|35191100000000000000570010001234561001234568|1000|0|9|1000|1000|120|0|COMP01|CONTA01|3100104|3100203|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD100("", versao)
        {
            Operacao = IndicadorOperacao.Entrada,
            Emissao = IndicadorEmitente.Propria,
            CodigoParticipante = "PART01",
            EspecieDocumento = "57",
            SituacaoDocumento = SituacaoDocumento.Regular,
            Serie = "1",
            SubSerie = "0",
            Numero = 123456,
            ChaveNFe = "35191100000000000000570010001234561001234567",
            DataEmissao = new System.DateTime(2022, 11, 1),
            DataPrestacaoAquisicao = new System.DateTime(2022, 11, 1),
            TipoCTe = CTe.TipoCTe.Normal,
            ChaveCTeReferenciado = "35191100000000000000570010001234561001234568",
            ValorTotalDocumento = 1000.0d,
            ValorDesconto = 0.0d,
            TipoFrete = IndicadorFrete.SemFrete,
            ValorPrestacaoServico = 1000.0d,
            ValorBaseCalculoICMS = 1000.0d,
            ValorICMS = 120.0d,
            ValorNaoTributado = 0.0d,
            CodigoComplementar0450 = "COMP01",
            CodigoContaContabil = "CONTA01",
            IBGE_Municipio_Origem = "3100104",
            IBGE_Municipio_destino = "3100203"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|D100|0|0|PART01|57|00|1|0|123456|35191100000000000000570010001234561001234567|01112022|01112022|0|35191100000000000000570010001234561001234568|1000|0|9|1000|1000|120|0|COMP01|CONTA01|3100104|3100203|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD100("", versao);
        reg.CodigoParticipante.Should().BeNull();
        reg.ValorTotalDocumento.HasValue.Should().BeFalse();

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroD100 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("D100");
        reg.Versao.Should().Be(versao);
        reg.Operacao.Should().Be(IndicadorOperacao.Entrada);
        reg.Emissao.Should().Be(IndicadorEmitente.Propria);
        reg.CodigoParticipante.Should().Be("PART01");
        reg.EspecieDocumento.Should().Be("57");
        reg.SituacaoDocumento.Should().Be(SituacaoDocumento.Regular);
        reg.Serie.Should().Be("1");
        reg.SubSerie.Should().Be("0");
        reg.Numero.Should().Be(123456);
        reg.ChaveNFe.Should().Be("35191100000000000000570010001234561001234567");
        reg.DataEmissao.Should().Be(new System.DateTime(2022, 11, 1));
        reg.DataPrestacaoAquisicao.Should().Be(new System.DateTime(2022, 11, 1));
        reg.TipoCTe.Should().Be(CTe.TipoCTe.Normal);
        reg.ChaveCTeReferenciado.Should().Be("35191100000000000000570010001234561001234568");
        reg.ValorTotalDocumento.Should().Be(1000.0d);
        reg.ValorDesconto.Should().Be(0.0d);
        reg.TipoFrete.Should().Be(IndicadorFrete.SemFrete);
        reg.ValorPrestacaoServico.Should().Be(1000.0d);
        reg.ValorBaseCalculoICMS.Should().Be(1000.0d);
        reg.ValorICMS.Should().Be(120.0d);
        reg.ValorNaoTributado.Should().Be(0.0d);
        reg.CodigoComplementar0450.Should().Be("COMP01");
        reg.CodigoContaContabil.Should().Be("CONTA01");
        reg.IBGE_Municipio_Origem.Should().Be("3100104");
        reg.IBGE_Municipio_destino.Should().Be("3100203");
    }
}
