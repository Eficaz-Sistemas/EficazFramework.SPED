using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Plano de contas contábeis
    /// </summary>
    /// <remarks></remarks>
    public class RegistroD500 : Primitives.Registro
    {
        public RegistroD500() : base("D500")
        {
        }

        public RegistroD500(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|D500|"); // 1
            writer.Append(((int)Operacao).ToString() + "|"); // 2
            writer.Append(((int)Emissao).ToString() + "|"); // 3
            writer.Append(CodigoParticipante + "|"); // 4
            writer.Append(EspecieDocumento + "|"); // 5
            writer.Append(string.Format("{0:00}", (int)SituacaoDocumento) + "|"); // 6
            writer.Append(Serie + "|"); // 7
            writer.Append(SubSerie + "|"); // 8
            writer.Append(Numero + "|"); // 9
            writer.Append(DataEmissao.ToSpedString() + "|"); // 10
            writer.Append(DataPrestacaoAquisicao.ToSpedString() + "|"); // 11
            writer.Append(string.Format("{0:0.##}", ValorTotalDocumento) + "|"); // 12
            writer.Append(string.Format("{0:0.##}", ValorDesconto) + "|"); // 13
            writer.Append(string.Format("{0:0.##}", ValorServicos) + "|"); // 14
            writer.Append(string.Format("{0:0.##}", ValorServicosICMSNaoTributato) + "|"); // 15
            writer.Append(string.Format("{0:0.##}", ValorCobradoTerceiros) + "|"); // 16
            writer.Append(string.Format("{0:0.##}", ValorDespesasAcessorias) + "|"); // 17
            writer.Append(string.Format("{0:0.##}", ValorBaseCalculoICMS) + "|"); // 18
            writer.Append(string.Format("{0:0.##}", ValorICMS) + "|"); // 19
            writer.Append(CodigoInformacaoComplementar0450 + "|"); // 20
            writer.Append(string.Format("{0:0.##}", ValorPIS) + "|"); // 21
            writer.Append(string.Format("{0:0.##}", ValorCofins) + "|"); // 22
            writer.Append(CodigoContaContabil + "|"); // 23
            writer.Append(((int)TipoAssinante).ToString() + "|"); // 24
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
            Numero = data[9].ToNullableInteger();
            DataEmissao = data[10].ToDate();
            DataPrestacaoAquisicao = data[11].ToDate();
            ValorTotalDocumento = data[12].ToNullableDouble();
            ValorDesconto = data[13].ToNullableDouble();
            ValorServicos = data[14].ToNullableDouble();
            ValorServicosICMSNaoTributato = data[15].ToNullableDouble();
            ValorCobradoTerceiros = data[16].ToNullableDouble();
            ValorDespesasAcessorias = data[17].ToNullableDouble();
            ValorBaseCalculoICMS = data[18].ToNullableDouble();
            ValorICMS = data[19].ToNullableDouble();
            CodigoInformacaoComplementar0450 = data[20];
            ValorPIS = data[21].ToNullableDouble();
            ValorCofins = data[22].ToNullableDouble();
            CodigoContaContabil = data[23];
            if (Conversions.ToInteger(Versao) >= 3)
            {
                TipoAssinante = (TipoAssinanteComunincacao)data[24].ToEnum<TipoAssinanteComunincacao>(TipoAssinanteComunincacao.Comercial_Industrial);
            }
        }

        public IndicadorOperacao Operacao { get; set; } = IndicadorOperacao.Entrada; // 2
        public IndicadorEmitente Emissao { get; set; } = IndicadorEmitente.Terceiros; // 3
        public string CodigoParticipante { get; set; } = null; // 4
        public string EspecieDocumento { get; set; } = null; // 5
        public SituacaoDocumento SituacaoDocumento { get; set; } = SituacaoDocumento.Regular; // 6
        public string Serie { get; set; } = null; // 7
        public string SubSerie { get; set; } = null; // 8
        public int? Numero { get; set; } = default; // 9
        public DateTime? DataEmissao { get; set; } = default; // 10
        public DateTime? DataPrestacaoAquisicao { get; set; } = default; // 11
        public double? ValorTotalDocumento { get; set; } = default; // 12
        public double? ValorDesconto { get; set; } = default; // 13
        public double? ValorServicos { get; set; } = default; // 14
        public double? ValorServicosICMSNaoTributato { get; set; } = default; // 15
        public double? ValorCobradoTerceiros { get; set; } = default; // 16
        public double? ValorDespesasAcessorias { get; set; } = default; // 17
        public double? ValorBaseCalculoICMS { get; set; } = default; // 18
        public double? ValorICMS { get; set; } = default; // 19
        public string CodigoInformacaoComplementar0450 { get; set; } = null; // 20
        public double? ValorPIS { get; set; } = default; // 21
        public double? ValorCofins { get; set; } = default; // 22
        public string CodigoContaContabil { get; set; } = null; // 23
        public TipoAssinanteComunincacao TipoAssinante { get; set; } = TipoAssinanteComunincacao.Comercial_Industrial; // 24

        // Registros Filhos
        public List<RegistroD590> RegistrosD590 { get; set; } = new List<RegistroD590>();
    }
}