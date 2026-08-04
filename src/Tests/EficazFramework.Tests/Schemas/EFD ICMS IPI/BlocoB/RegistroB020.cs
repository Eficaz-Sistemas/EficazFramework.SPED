using AwesomeAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI.BlocoB;

public class RegistroB020 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB020();
        reg.Codigo.Should().Be("B020");
    }

    [TestCase("|B020|0|0|1|NF|00|1|1|CHAVE|01112022|1|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1|", "016")]
    public void Construtor(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB020(linha, versao);
        InternalRead(reg, versao);
    }

    [TestCase("|B020|0|0|1|NF|00|1|1|CHAVE|01112022|1|1000|1000|1000|1000|1000|1000|1000|1000|1000|1|", "016")]
    public void Escrita(string result, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB020("", versao)
        {
            IndicadorTipoOperacao = IndicadorOperacao.Entrada,
            IndicadorEmitente = IndicadorEmitente.Propria,
            CodigoParticipante = "1",
            EspecieDocumento = "NF",
            SituacaoDocumento = SituacaoDocumento.Regular,
            Serie = "1",
            NumeroDoc = 1,
            ChaveNFe = "CHAVE",
            DataDoc = new DateTime(2022, 11, 1),
            CodigoMunicipio = "1",
            ValorContabil = 1000.0,
            ValorMaterialTerceiro = 1000.0,
            ValorSubempreitada = 1000.0,
            ValorISSIsentoNTrib = 1000.0,
            ValorDedBC = 1000.0,
            ValorBCISS = 1000.0,
            ValorBCRetISS = 1000.0, // wait this one doesn't have an append in DocumentoValido for ValorBCRetISS!
            ValorISSRetTomador = 1000.0,
            ValorISSDestacado = 1000.0,
            CodigoObsLactoFiscal = "1"
        };
        reg.ToString().Should().Be(result);
    }

    [TestCase("|B020|0|0|1|NF|00|1|1|CHAVE|01112022|1|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1000,00|1|", "016")]
    public void Leitura(string linha, string versao = "016")
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB020("", versao);
        reg.CodigoParticipante.Should().BeNull();
        reg.EspecieDocumento.Should().BeNull();
        reg.Serie.Should().BeNull();
        reg.ChaveNFe.Should().BeNull();
        reg.CodigoMunicipio.Should().BeNull();
        reg.CodigoObsLactoFiscal.Should().BeNull();
        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }

    private void InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroB020 reg, string versao = "016")
    {
        reg.Codigo.Should().Be("B020");
        reg.Versao.Should().Be(versao);
        reg.IndicadorTipoOperacao.Should().Be(IndicadorOperacao.Entrada);
        reg.IndicadorEmitente.Should().Be(IndicadorEmitente.Propria);
        reg.CodigoParticipante.Should().Be("1");
        reg.EspecieDocumento.Should().Be("NF");
        reg.SituacaoDocumento.Should().Be(SituacaoDocumento.Regular);
        reg.Serie.Should().Be("1");
        reg.NumeroDoc.Should().Be(1);
        reg.ChaveNFe.Should().Be("CHAVE");
        reg.DataDoc.Should().Be(new DateTime(2022, 11, 1));
        reg.CodigoMunicipio.Should().Be("1");
        reg.ValorContabil.Should().Be(1000.0);
        reg.ValorMaterialTerceiro.Should().Be(1000.0);
        reg.ValorSubempreitada.Should().Be(1000.0);
        reg.ValorISSIsentoNTrib.Should().Be(1000.0);
        reg.ValorDedBC.Should().Be(1000.0);
        reg.ValorBCISS.Should().Be(1000.0);
        reg.ValorBCRetISS.Should().Be(1000.0);
        reg.ValorISSRetTomador.Should().Be(1000.0);
        reg.ValorISSDestacado.Should().Be(1000.0);
        reg.CodigoObsLactoFiscal.Should().Be("1");
    }
}
