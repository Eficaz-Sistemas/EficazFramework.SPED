using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Documento Nota Fiscal de Serviço
/// </summary>
/// <remarks></remarks>

public class RegistroA100 : Primitives.Registro
{
    public RegistroA100() : base("A100")
    {
    }

    public RegistroA100(string linha, string versao) : base(linha, versao)
    {
    }

    // Campo'
    public IndicadorTipoOperacao IndicadorTipoOperacao { get; set; } = IndicadorTipoOperacao.ServicoContratadoEstabelecimento;
    public EFD_ICMS_IPI.IndicadorEmitente IndicadorEmitenteDocFiscal { get; set; } = EFD_ICMS_IPI.IndicadorEmitente.Propria;
    public string CodigoParticipante { get; set; } = null; // tamanho 60'
    public EFD_ICMS_IPI.SituacaoDocumento CodigoSituacaoDocFiscal { get; set; } = EFD_ICMS_IPI.SituacaoDocumento.Regular;
    public string SerieDocFiscal { get; set; } = null; // tamanho 20'
    public string SubserieDocFiscal { get; set; } = null; // Tamanho 20'
    public string NumeroDocFiscal { get; set; } = null; // tamanho 60'
    public string ChaveCodigoVerificacaoNFSe { get; set; } = null; // tamanho 60'
    public DateTime? Datadocfiscal { get; set; } // ddMMaaaa'
    public DateTime? DataExecucaoConclusao { get; set; } // ddMMaaaa'
    public double? VrTotalDoc { get; set; }
    public NFe.FormaDePagamento TipoPagamento { get; set; } = NFe.FormaDePagamento.Vista;
    public double? VrTotalDesconto { get; set; }
    public double? VrBaseCalculoPis { get; set; }
    public double? VrPis { get; set; }
    public double? VrBaseCalculoCofins { get; set; }
    public double? VrCofins { get; set; }
    public double? VrPisRetidoFonte { get; set; }
    public double? VrCofinsRetidoFonte { get; set; }
    public double? VrISS { get; set; }
    public List<RegistroA110> RegistrosA110 { get; set; } = new List<RegistroA110>();
    public List<RegistroA111> RegistrosA111 { get; set; } = new List<RegistroA111>();
    public List<RegistroA120> RegistrosA120 { get; set; } = new List<RegistroA120>();
    public List<RegistroA170> RegistrosA170 { get; set; } = new List<RegistroA170>();

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|A100|");
        writer.Append(((int)IndicadorTipoOperacao).ToString() + "|");
        writer.Append(((int)IndicadorEmitenteDocFiscal).ToString() + "|");
        writer.Append(CodigoParticipante + "|");
        writer.Append(string.Format("{0:00}", (int)CodigoSituacaoDocFiscal) + "|");
        writer.Append(SerieDocFiscal + "|");
        writer.Append(SubserieDocFiscal + "|");
        writer.Append(NumeroDocFiscal + "|");
        writer.Append(ChaveCodigoVerificacaoNFSe + "|");
        writer.Append(Datadocfiscal.ToSpedString() + "|");
        writer.Append(DataExecucaoConclusao.ToSpedString() + "|");
        writer.Append(VrTotalDoc + "|");
        writer.Append(((int)TipoPagamento).ToString() + "|");
        writer.Append(VrTotalDesconto + "|");
        writer.Append(VrBaseCalculoPis + "|");
        writer.Append(VrPis + "|");
        writer.Append(VrBaseCalculoCofins + "|");
        writer.Append(VrCofins + "|");
        writer.Append(VrPisRetidoFonte + "|");
        writer.Append(VrCofinsRetidoFonte + "|");
        writer.Append(VrISS + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorTipoOperacao = (IndicadorTipoOperacao)data[2].ToEnum<IndicadorTipoOperacao>(IndicadorTipoOperacao.ServicoContratadoEstabelecimento);
        IndicadorEmitenteDocFiscal = (EFD_ICMS_IPI.IndicadorEmitente)data[3].ToEnum<EFD_ICMS_IPI.IndicadorEmitente>(EFD_ICMS_IPI.IndicadorEmitente.Propria);
        CodigoParticipante = data[4];
        CodigoSituacaoDocFiscal = (EFD_ICMS_IPI.SituacaoDocumento)data[5].ToEnum<EFD_ICMS_IPI.SituacaoDocumento>(EFD_ICMS_IPI.SituacaoDocumento.Regular);
        SerieDocFiscal = data[6];
        SubserieDocFiscal = data[7];
        NumeroDocFiscal = data[8];
        ChaveCodigoVerificacaoNFSe = data[9];
        Datadocfiscal = data[10].ToDate();
        DataExecucaoConclusao = data[11].ToDate();
        VrTotalDoc = data[12].ToNullableDouble();
        TipoPagamento = (NFe.FormaDePagamento)data[13].ToEnum<NFe.FormaDePagamento>(NFe.FormaDePagamento.Vista);
        VrTotalDesconto = data[14].ToNullableDouble();
        VrBaseCalculoPis = data[15].ToNullableDouble();
        VrPis = data[16].ToNullableDouble();
        VrBaseCalculoCofins = data[17].ToNullableDouble();
        VrCofins = data[18].ToNullableDouble();
        VrPisRetidoFonte = data[19].ToNullableDouble();
        VrCofinsRetidoFonte = data[20].ToNullableDouble();
        VrISS = data[21].ToNullableDouble();
    }
}
