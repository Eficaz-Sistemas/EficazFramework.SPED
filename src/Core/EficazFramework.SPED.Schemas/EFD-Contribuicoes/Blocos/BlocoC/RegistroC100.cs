using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;
using EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Documento - Nota Fiscal
/// </summary>
/// <remarks></remarks>

public class RegistroC100 : Primitives.Registro
{
    public RegistroC100() : base("C100")
    {
    }

    public RegistroC100(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public NFe.OperacaoNFe IndicadorTipoOperacao { get; set; } = NFe.OperacaoNFe.Entrada;
    public IndicadorEmitente IndicadorEmitenteDocFiscal { get; set; } = IndicadorEmitente.Propria;
    public string CodigoParticipante { get; set; } = null;
    public string CodigoModeloDocFiscal { get; set; } = null;
    public SituacaoDocumento CodigoSituacaoDocFiscal { get; set; } = SituacaoDocumento.Regular;
    public string SerieDocFiscal { get; set; } = null;
    public string NumeroDocFiscal { get; set; } = null;
    public string ChaveNFeDocFiscal { get; set; } = null;
    public DateTime? DataEmissaoDocFiscal { get; set; } = default;
    public DateTime? DataEntradaSaida { get; set; } = default;
    public double? VrTotalDocFiscal { get; set; } = default;
    public IndicadorPagamento IndicadorTipoPagamento { get; set; } = IndicadorPagamento.Outros;
    public double? VrTotalDesconto { get; set; } = default;
    public double? VrAbatimentoNT { get; set; } = default;
    public double? VrTotalMercadorias { get; set; } = default;
    public IndicadorFrete IndicadorTipoFrete { get; set; } = IndicadorFrete.Destinatario_Remetente;
    public double? VrFrete { get; set; } = default;
    public double? VrSeguro { get; set; } = default;
    public double? VrOutrasDespesas { get; set; } = default;
    public double? VrBaseCalculoICMS { get; set; } = default;
    public double? VrICMS { get; set; } = default;
    public double? VrBaseCalculoICMSST { get; set; } = default;
    public double? VrICMSST { get; set; } = default;
    public double? VrIPI { get; set; } = default;
    public double? VrPIS { get; set; } = default;
    public double? VrCOFINS { get; set; } = default;
    public double? VrPISST { get; set; } = default;
    public double? VrCOFINSST { get; set; } = default;
    public List<RegistroC110> RegistrosC110 { get; set; } = new List<RegistroC110>();
    public List<RegistroC111> RegistrosC111 { get; set; } = new List<RegistroC111>();
    public List<RegistroC120> RegistrosC120 { get; set; } = new List<RegistroC120>();
    public List<RegistroC170> RegistrosC170 { get; set; } = new List<RegistroC170>();
    public List<RegistroC175> RegistrosC175 { get; set; } = new List<RegistroC175>();

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C100|");
        writer.Append(((int)IndicadorTipoOperacao).ToString() + "|");
        writer.Append(((int)IndicadorEmitenteDocFiscal).ToString() + "|");
        writer.Append(CodigoParticipante + "|");
        writer.Append(CodigoModeloDocFiscal + "|");
        writer.Append(string.Format("{0:00}", (int)CodigoSituacaoDocFiscal) + "|"); // 6
        writer.Append(SerieDocFiscal + "|");
        writer.Append(NumeroDocFiscal + "|");
        writer.Append(ChaveNFeDocFiscal + "|");
        if (DocumentoValido())
            writer.Append(DataEmissaoDocFiscal.ToSpedString() + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(DataEntradaSaida.ToSpedString() + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrTotalDocFiscal) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(((int)IndicadorTipoPagamento).ToString() + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrTotalDesconto) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrAbatimentoNT) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrTotalMercadorias) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(((int)IndicadorTipoFrete).ToString() + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrFrete) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrSeguro) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrOutrasDespesas) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrBaseCalculoICMS) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrICMS) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrBaseCalculoICMSST) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrICMSST) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrIPI) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrPIS) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrCOFINS) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrPISST) + "|");
        else
            writer.Append('|');
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", VrCOFINSST) + "|");
        else
            writer.Append('|');
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorTipoOperacao = (NFe.OperacaoNFe)data[2].ToEnum<NFe.OperacaoNFe>(NFe.OperacaoNFe.Entrada);
        IndicadorEmitenteDocFiscal = (IndicadorEmitente)data[3].ToEnum<IndicadorEmitente>(IndicadorEmitente.Propria);
        CodigoParticipante = data[4];
        CodigoModeloDocFiscal = data[5];
        CodigoSituacaoDocFiscal = (SituacaoDocumento)data[6].ToEnum<SituacaoDocumento>(SituacaoDocumento.Regular);
        SerieDocFiscal = data[7];
        NumeroDocFiscal = data[8];
        ChaveNFeDocFiscal = data[9];
        DataEmissaoDocFiscal = data[10].ToDate();
        DataEntradaSaida = data[11].ToDate();
        VrTotalDocFiscal = data[12].ToNullableDouble();
        IndicadorTipoPagamento = (IndicadorPagamento)data[13].ToEnum<IndicadorPagamento>(IndicadorPagamento.Outros);
        VrTotalDesconto = data[14].ToNullableDouble();
        VrAbatimentoNT = data[15].ToNullableDouble();
        VrTotalMercadorias = data[16].ToNullableDouble();
        IndicadorTipoFrete = (IndicadorFrete)data[17].ToEnum<IndicadorFrete>(IndicadorFrete.Destinatario_Remetente);
        VrFrete = data[18].ToNullableDouble();
        VrSeguro = data[19].ToNullableDouble();
        VrOutrasDespesas = data[20].ToNullableDouble();
        VrBaseCalculoICMS = data[21].ToNullableDouble();
        VrICMS = data[22].ToNullableDouble();
        VrBaseCalculoICMSST = data[23].ToNullableDouble();
        VrICMSST = data[24].ToNullableDouble();
        VrIPI = data[25].ToNullableDouble();
        VrPIS = data[26].ToNullableDouble();
        VrCOFINS = data[27].ToNullableDouble();
        VrPISST = data[28].ToNullableDouble();
        VrCOFINSST = data[29].ToNullableDouble();
    }

    public bool DocumentoValido()
    {
        if (CodigoSituacaoDocFiscal == SituacaoDocumento.Cancelado | CodigoSituacaoDocFiscal == SituacaoDocumento.CanceladoExtemporaneo | CodigoSituacaoDocFiscal == SituacaoDocumento.Denegado | CodigoSituacaoDocFiscal == SituacaoDocumento.Inutilizado)
            return false;
        else
            return true;
    }
}
