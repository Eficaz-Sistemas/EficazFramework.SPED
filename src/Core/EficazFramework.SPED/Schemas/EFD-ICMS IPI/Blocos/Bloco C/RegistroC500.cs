using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Energia Elétrica / Gás / Água
/// </summary>
/// <remarks></remarks>
public class RegistroC500 : Primitives.Registro
{
    public RegistroC500() : base("C500")
    {
    }

    public RegistroC500(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C500|"); // 1
        writer.Append(((int)Operacao).ToString() + "|"); // 2
        writer.Append(((int)Emissao).ToString() + "|"); // 3
        writer.Append(CodigoParticipante + "|"); // 4
        writer.Append(EspecieDocumento + "|"); // 5
        writer.Append(string.Format("{0:00}", (int)SituacaoDocumento) + "|"); // 6
        writer.Append(Serie + "|"); // 7
        writer.Append(SubSerie + "|"); // 8
        if (EspecieDocumento == "29")
        {
            writer.Append(CodigoConsumoAgua + "|"); // 9
        }
        else
        {
            writer.Append(string.Format("{0:00}", (int)CodigoConsumo) + "|");
        } // 9

        writer.Append(Numero + "|"); // 10
        writer.Append(DataEmissao.ToSpedString() + "|"); // 11
        writer.Append(DataEntradaSaida.ToSpedString() + "|"); // 12
        writer.Append(string.Format("{0:0.##}", ValorTotalDocumento) + "|"); // 13
        writer.Append(string.Format("{0:0.##}", ValorDesconto) + "|"); // 14
        writer.Append(string.Format("{0:0.##}", ValorFornecidoOuConsumido) + "|"); // 15
        writer.Append(string.Format("{0:0.##}", ValorServicosICMSNaoTributato) + "|"); // 16
        writer.Append(string.Format("{0:0.##}", ValorCobradoTerceiros) + "|"); // 17
        writer.Append(string.Format("{0:0.##}", ValorDespesasAcessorias) + "|"); // 18
        writer.Append(string.Format("{0:0.##}", ValorBaseCalculoICMS) + "|"); // 19
        writer.Append(string.Format("{0:0.##}", ValorICMS) + "|"); // 20
        writer.Append(string.Format("{0:0.##}", ValorBaseCalculoICMSST) + "|"); // 21
        writer.Append(string.Format("{0:0.##}", ValorICMSST) + "|"); // 22
        writer.Append(CodigoInformacaoComplementar0450 + "|"); // 23
        writer.Append(string.Format("{0:0.##}", ValorPIS) + "|"); // 24
        writer.Append(string.Format("{0:0.##}", ValorCofins) + "|"); // 25
        if (EspecieDocumento == "06" & Conversions.ToInteger(Versao) >= 3)
        {
            writer.Append(((int)TipoLigacao).ToString() + "|"); // 26
            writer.Append(string.Format("{0:00}", (int)CodigoGrupoTensao) + "|"); // 27
        }
        else if (Conversions.ToInteger(Versao) >= 3)
        {
            writer.Append('|'); // 26
            writer.Append('|'); // 27
        }

        if (Conversions.ToInteger(Versao) >= 14)
        {
            writer.Append(ChaveDocE + "|"); // 28
            if (EspecieDocumento == "66")
                writer.Append(((int)FinDocE).ToString() + "|");
            else
                writer.Append('|'); // 29
            writer.Append(ChaveDocE_Referenciado + "|"); // 30
            writer.Append((DestinatarioIndicador != null ? (int)DestinatarioIndicador : "") + "|"); // 31
            writer.Append(DestinatarioCodMunicipio + "|"); // 32
            writer.Append(CodigoContaAnaliticaCtb + "|"); // 33
        }
        if (Conversions.ToInteger(Versao) > 15)
        {
            writer.Append(this.EspecieDocumentoReferenciado + "|"); // 34
            writer.Append(this.HashDocumentoReferenciado + "|"); // 35
            writer.Append(this.SerieDocumentoReferenciado + "|"); // 36
            writer.Append(this.NumeroDocumentoReferenciado + "|"); // 37
            writer.Append(string.Format("{0:MMyyyy}", this.CompetenciaDocumentoReferenciado) + "|"); // 38
            writer.Append(string.Format("{0:0.##}", this.EnergiaInjetada) + "|"); // 39
            writer.Append(string.Format("{0:0.##}", this.OutrasDeducoes) + "|"); // 40
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
        SubSerie = data[8];
        if (EspecieDocumento == "29")
        {
            CodigoConsumoAgua = data[9];
        }
        else
        {
            CodigoConsumo = (CodigoConsumoEnEletricaOuGas)data[9].ToEnum<CodigoConsumoEnEletricaOuGas>(CodigoConsumoEnEletricaOuGas.ConsumoProprio);
        }

        Numero = data[10].ToNullableInteger();
        DataEmissao = data[11].ToDate();
        DataEntradaSaida = data[12].ToDate();
        ValorTotalDocumento = data[13].ToNullableDouble();
        ValorDesconto = data[14].ToNullableDouble();
        ValorFornecidoOuConsumido = data[15].ToNullableDouble();
        ValorServicosICMSNaoTributato = data[16].ToNullableDouble();
        ValorCobradoTerceiros = data[17].ToNullableDouble();
        ValorDespesasAcessorias = data[18].ToNullableDouble();
        ValorBaseCalculoICMS = data[19].ToNullableDouble();
        ValorICMS = data[20].ToNullableDouble();
        ValorBaseCalculoICMSST = data[21].ToNullableDouble();
        ValorICMSST = data[22].ToNullableDouble();
        CodigoInformacaoComplementar0450 = data[23];
        ValorPIS = data[24].ToNullableDouble();
        ValorCofins = data[25].ToNullableDouble();
        if (EspecieDocumento == "06" & Conversions.ToInteger(Versao) >= 3)
        {
            TipoLigacao = (TipoLigacaoEnEletrica)data[26].ToEnum<TipoLigacaoEnEletrica>(TipoLigacaoEnEletrica.Monifasico);
            CodigoGrupoTensao = (GrupoTensao)data[27].ToEnum<GrupoTensao>(GrupoTensao.A1);
        }

        if (Conversions.ToInteger(Versao) >= 14)
        {
            ChaveDocE = data[28];
            FinDocE = (FinalidadeEmissaoDocE)data[29].ToEnum<FinalidadeEmissaoDocE>(FinalidadeEmissaoDocE.Normal);
            ChaveDocE_Referenciado = data[30];
            DestinatarioIndicador = (IndicadorDestinatario?)data[31].ToEnum<IndicadorDestinatario>(null);
            DestinatarioCodMunicipio = data[32];
            CodigoContaAnaliticaCtb = data[33];
        }
        if (Conversions.ToInteger(Versao) > 15)
        {
            EspecieDocumentoReferenciado = data[34];
            HashDocumentoReferenciado = data[35];
            SerieDocumentoReferenciado = data[36];
            NumeroDocumentoReferenciado = data[37].ToNullableInteger();
            CompetenciaDocumentoReferenciado = data[38].ToDate(DateFormat.MMAAAA);
            EnergiaInjetada = data[39].ToNullableDouble();
            OutrasDeducoes = data[40].ToNullableDouble();
        }
    }

    public IndicadorOperacao Operacao { get; set; } = IndicadorOperacao.Entrada; // 2
    public IndicadorEmitente Emissao { get; set; } = IndicadorEmitente.Terceiros; // 3
    public string CodigoParticipante { get; set; } = null; // 4
    public string EspecieDocumento { get; set; } = null; // 5
    public SituacaoDocumento SituacaoDocumento { get; set; } = SituacaoDocumento.Regular; // 6
    public string Serie { get; set; } = null; // 7
    public string SubSerie { get; set; } = null; // 8
    public CodigoConsumoEnEletricaOuGas CodigoConsumo { get; set; } = CodigoConsumoEnEletricaOuGas.ConsumoProprio; // 9
    public string CodigoConsumoAgua { get; set; } = null; // 9
    public int? Numero { get; set; } = default; // 10
    public DateTime? DataEmissao { get; set; } = default; // 11
    public DateTime? DataEntradaSaida { get; set; } = default; // 12
    public double? ValorTotalDocumento { get; set; } = default; // 13
    public double? ValorDesconto { get; set; } = default; // 14
    public double? ValorFornecidoOuConsumido { get; set; } = default; // 15
    public double? ValorServicosICMSNaoTributato { get; set; } = default; // 16
    public double? ValorCobradoTerceiros { get; set; } = default; // 17
    public double? ValorDespesasAcessorias { get; set; } = default; // 18
    public double? ValorBaseCalculoICMS { get; set; } = default; // 19
    public double? ValorICMS { get; set; } = default; // 20
    public double? ValorBaseCalculoICMSST { get; set; } = default; // 21
    public double? ValorICMSST { get; set; } = default; // 22
    public string CodigoInformacaoComplementar0450 { get; set; } = null; // 23
    public double? ValorPIS { get; set; } = default; // 24
    public double? ValorCofins { get; set; } = default; // 25
    public TipoLigacaoEnEletrica TipoLigacao { get; set; } = TipoLigacaoEnEletrica.Monifasico; // 26
    public GrupoTensao CodigoGrupoTensao { get; set; } = GrupoTensao.A1; // 27
                                                                         // Versão 14
    public string ChaveDocE { get; set; } = null; // 28
    public FinalidadeEmissaoDocE FinDocE { get; set; } = FinalidadeEmissaoDocE.Normal; // 29
    public string ChaveDocE_Referenciado { get; set; } = null; // 30
    public IndicadorDestinatario? DestinatarioIndicador { get; set; } = null; //IndicadorDestinatario.ContribuinteICMS; // 31
    public string DestinatarioCodMunicipio { get; set; } = null; // 32
    public string CodigoContaAnaliticaCtb { get; set; } = null; // 33

    // Versão 16
    public string EspecieDocumentoReferenciado { get; set; } = null; // 34
    public string HashDocumentoReferenciado { get; set; } = null; // 35
    public string SerieDocumentoReferenciado { get; set; } = null; // 36
    public int? NumeroDocumentoReferenciado { get; set; } // 37
    public DateTime? CompetenciaDocumentoReferenciado { get; set; } // 38
    public double? EnergiaInjetada { get; set; } = default(Double?); // 39
    public double? OutrasDeducoes { get; set; } = default(Double?); // 40

    // Registros Filhos
    public List<RegistroC590> RegistrosC590 { get; set; } = new List<RegistroC590>();
}
