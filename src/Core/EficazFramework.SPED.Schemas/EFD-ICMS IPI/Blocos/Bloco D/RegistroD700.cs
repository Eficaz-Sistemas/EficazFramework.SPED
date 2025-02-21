using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Nota Fiscal Fatura Eletrônica de Serviços de Comunicação – NFCom(Código 62)
/// </summary>
/// <remarks></remarks>
public class RegistroD700 : Primitives.Registro
{
    public RegistroD700() : base("D700")
    {
    }

    public RegistroD700(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D700|"); // 1
        writer.Append(((int)Operacao).ToString() + "|"); // 2
        writer.Append(((int)Emissao).ToString() + "|"); // 3
        writer.Append(CodigoParticipante + "|"); // 4
        writer.Append(EspecieDocumento + "|"); // 5
        writer.Append(string.Format("{0:00}", (int)SituacaoDocumento) + "|"); // 6
        writer.Append(Serie + "|"); // 7
        writer.Append(Numero + "|"); // 8
        writer.Append(DataEmissao.ToSpedString() + "|"); // 9
        writer.Append(DataPrestacaoAquisicao.ToSpedString() + "|"); // 10
        writer.Append(string.Format("{0:0.##}", ValorTotalDocumento) + "|"); // 11
        writer.Append(string.Format("{0:0.##}", ValorDesconto) + "|"); // 12
        writer.Append(string.Format("{0:0.##}", ValorServicos) + "|"); // 13
        writer.Append(string.Format("{0:0.##}", ValorServicosICMSNaoTributato) + "|"); // 14
        writer.Append(string.Format("{0:0.##}", ValorCobradoTerceiros) + "|"); // 15
        writer.Append(string.Format("{0:0.##}", ValorDespesasAcessorias) + "|"); // 16
        writer.Append(string.Format("{0:0.##}", ValorBaseCalculoICMS) + "|"); // 17
        writer.Append(string.Format("{0:0.##}", ValorICMS) + "|"); // 18
        writer.Append(CodigoInformacaoComplementar0450 + "|"); // 19
        writer.Append(string.Format("{0:0.##}", ValorPIS) + "|"); // 20
        writer.Append(string.Format("{0:0.##}", ValorCofins) + "|"); // 21
        writer.Append(ChaveDocEletronico + "|"); // 22
        writer.Append(((int)FinalidadeEmissao).ToString() + "|"); // 23
        writer.Append(EspecieDocReferenciado + "|"); // 25
        writer.Append(ChaveDocReferenciado + "|"); // 26
        writer.Append(HashDocReferenciado + "|"); // 27
        writer.Append(SerieDocReferenciado + "|"); // 28
        writer.Append(NumeroDocReferenciado + "|"); // 29
        writer.Append(DataEmissao.ToSintegraString(DateFormat.MMAAAA) + "|"); // 30
        writer.Append(CodigoIbgeDestinatario + "|"); // 31
        if (int.Parse(Versao) >= 19)
        {
            writer.Append(string.Format("{0:0.##}", Deducoes) + "|"); // 32
        }

        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        Operacao = (IndicadorOperacao)data[2].ToEnum<IndicadorOperacao>(IndicadorOperacao.Entrada);
        Emissao = (IndicadorEmitente)data[3].ToEnum<IndicadorEmitente>(IndicadorEmitente.Terceiros);
        CodigoParticipante = data[4];
        EspecieDocumento = data[5];
        SituacaoDocumento = (SituacaoDocumento)data[6].ToEnum<SituacaoDocumento>(SituacaoDocumento.Cancelado);
        Serie = data[7];
        Numero = data[8].ToNullableInteger();
        DataEmissao = data[9].ToDate();
        DataPrestacaoAquisicao = data[10].ToDate();
        ValorTotalDocumento = data[11].ToNullableDouble();
        ValorDesconto = data[12].ToNullableDouble();
        ValorServicos = data[13].ToNullableDouble();
        ValorServicosICMSNaoTributato = data[14].ToNullableDouble();
        ValorCobradoTerceiros = data[15].ToNullableDouble();
        ValorDespesasAcessorias = data[16].ToNullableDouble();
        ValorBaseCalculoICMS = data[17].ToNullableDouble();
        ValorICMS = data[18].ToNullableDouble();
        CodigoInformacaoComplementar0450 = data[19];
        ValorPIS = data[20].ToNullableDouble();
        ValorCofins = data[21].ToNullableDouble();
        ChaveDocEletronico = data[22];
        FinalidadeEmissao = (FinalidadeEmissaoDocE)data[23].ToEnum<FinalidadeEmissaoDocE>(FinalidadeEmissaoDocE.Normal);
        TipoFaturamento = (TipoFaturaDocE)data[24].ToEnum<TipoFaturaDocE>(TipoFaturaDocE.Normal);
        EspecieDocReferenciado = data[25];
        ChaveDocReferenciado = data[26];
        HashDocReferenciado = data[27];
        SerieDocReferenciado = data[28];
        NumeroDocReferenciado = data[29].ToNullableInteger();
        CompetenciaDocReferenciado = data[30].ToDate(DateFormat.MMAAAA);
        CodigoIbgeDestinatario = data[31];
        if (int.Parse(Versao) >= 19)
        {
            Deducoes = data[32].ToNullableDouble();
        }


    }

    public IndicadorOperacao Operacao { get; set; } = IndicadorOperacao.Entrada; // 2
    public IndicadorEmitente Emissao { get; set; } = IndicadorEmitente.Terceiros; // 3
    public string CodigoParticipante { get; set; } = null; // 4
    public string EspecieDocumento { get; set; } = null; // 5
    public SituacaoDocumento SituacaoDocumento { get; set; } = SituacaoDocumento.Regular; // 6
    public string Serie { get; set; } = null; // 7
    public int? Numero { get; set; } = default; // 8
    public DateTime? DataEmissao { get; set; } = default; // 9
    public DateTime? DataPrestacaoAquisicao { get; set; } = default; // 10
    public double? ValorTotalDocumento { get; set; } = default; // 11
    public double? ValorDesconto { get; set; } = default; // 12
    public double? ValorServicos { get; set; } = default; // 13
    public double? ValorServicosICMSNaoTributato { get; set; } = default; // 14
    public double? ValorCobradoTerceiros { get; set; } = default; // 15
    public double? ValorDespesasAcessorias { get; set; } = default; // 16
    public double? ValorBaseCalculoICMS { get; set; } = default; // 17
    public double? ValorICMS { get; set; } = default; // 18
    public string CodigoInformacaoComplementar0450 { get; set; } = null; // 19
    public double? ValorPIS { get; set; } = default; // 20
    public double? ValorCofins { get; set; } = default; // 21
    public string ChaveDocEletronico { get; set; } = null; // 22
    public FinalidadeEmissaoDocE FinalidadeEmissao { get; set; } = FinalidadeEmissaoDocE.Normal; // 23
    public TipoFaturaDocE TipoFaturamento { get; set; } = TipoFaturaDocE.Normal; // 24
    public string EspecieDocReferenciado { get; set; } = null; // 25
    public string ChaveDocReferenciado { get; set; } = null; // 26
    public string HashDocReferenciado { get; set; } = null; // 27
    public string SerieDocReferenciado { get; set; } = null; // 28
    public int? NumeroDocReferenciado { get; set; } = default; // 29
    /// <summary>
    /// Mês e Ano do Documento Fiscal Referenciado
    /// </summary>
    public DateTime? CompetenciaDocReferenciado { get; set; } = default; // 30
    public string CodigoIbgeDestinatario { get; set; } = null; // 31
    public double? Deducoes { get; set; } // 32

    // Registros Filhos
    public List<RegistroD730> RegistrosD730 { get; set; } = new List<RegistroD730>();

}
