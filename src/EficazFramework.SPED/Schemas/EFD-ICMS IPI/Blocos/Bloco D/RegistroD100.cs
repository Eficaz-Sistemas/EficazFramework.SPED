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
    public class RegistroD100 : Primitives.Registro
    {
        public RegistroD100() : base("D100")
        {
        }

        public RegistroD100(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|D100|"); // 1
            writer.Append(((int)Operacao).ToString() + "|"); // 2
            writer.Append(((int)Emissao).ToString() + "|"); // 3
            writer.Append(CodigoParticipante + "|"); // 4
            writer.Append(EspecieDocumento + "|"); // 5
            writer.Append(string.Format("{0:00}", (int)SituacaoDocumento) + "|"); // 6
            writer.Append(Serie + "|"); // 7
            writer.Append(SubSerie + "|"); // 7
            writer.Append(Numero + "|"); // 9
            writer.Append(ChaveNFe + "|"); // 10
            writer.Append(DataEmissao.ToSpedString() + "|"); // 11
            writer.Append(DataPrestacaoAquisicao.ToSpedString() + "|"); // 12
            if (EspecieDocumento == "57")
            {
                if (DocumentoValido())
                    writer.Append(((int)TipoCTe).ToString() + "|");
                else
                    writer.Append('|');  // 13
            }
            else
            {
                writer.Append('|');
            } // 13

            if (DocumentoValido())
                writer.Append(ChaveCTeReferenciado + "|");
            else
                writer.Append('|');  // 14
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorTotalDocumento) + "|");
            else
                writer.Append('|'); // 15
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorDesconto) + "|");
            else
                writer.Append('|');  // 16
            if (DocumentoValido())
                writer.Append(((int)TipoFrete).ToString() + "|");
            else
                writer.Append('|'); // 17
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorPrestacaoServico) + "|");
            else
                writer.Append('|'); // 18
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorBaseCalculoICMS) + "|");
            else
                writer.Append('|'); // 19
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorICMS) + "|");
            else
                writer.Append('|'); // 20
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorNaoTributado) + "|");
            else
                writer.Append('|'); // 21
            if (DocumentoValido())
                writer.Append(CodigoComplementar0450 + "|");
            else
                writer.Append('|'); // 22
            if (DocumentoValido())
                writer.Append(CodigoContaContabil + "|");
            else
                writer.Append('|'); // 23
            if (Conversions.ToInteger(Versao) > 11)
            {
                if (DocumentoValido())
                    writer.Append(IBGE_Municipio_Origem + "|");
                else
                    writer.Append('|'); // 24
                if (DocumentoValido())
                    writer.Append(IBGE_Municipio_destino + "|");
                else
                    writer.Append('|'); // 25
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
            Numero = data[9].ToNullableInteger();
            ChaveNFe = data[10];
            DataEmissao = data[11].ToDate();
            DataPrestacaoAquisicao = data[12].ToDate();
            if (EspecieDocumento == "57")
            {
                TipoCTe = (CTe.TipoCTe)data[13].ToEnum<CTe.TipoCTe>(CTe.TipoCTe.Normal);
            }

            ChaveCTeReferenciado = data[14];
            ValorTotalDocumento = data[15].ToNullableDouble();
            ValorDesconto = data[16].ToNullableDouble();
            TipoFrete = (IndicadorFrete)data[17].ToEnum<IndicadorFrete>(IndicadorFrete.SemFrete);
            ValorPrestacaoServico = data[18].ToNullableDouble();
            ValorBaseCalculoICMS = data[19].ToNullableDouble();
            ValorICMS = data[20].ToNullableDouble();
            ValorNaoTributado = data[21].ToNullableDouble();
            CodigoComplementar0450 = data[22];
            CodigoContaContabil = data[23];
            if (Conversions.ToInteger(Versao) > 11)
            {
                IBGE_Municipio_Origem = data[24];
                IBGE_Municipio_destino = data[25];
            }
        }

        public IndicadorOperacao Operacao { get; set; } = IndicadorOperacao.Entrada; // 2
        public IndicadorEmitente Emissao { get; set; } = IndicadorEmitente.Propria; // 3
        public string CodigoParticipante { get; set; } = null; // 4
        public string EspecieDocumento { get; set; } = null; // 5
        public SituacaoDocumento SituacaoDocumento { get; set; } = SituacaoDocumento.Regular; // 6
        public string Serie { get; set; } = null; // 7
        public string SubSerie { get; set; } = null; // 8
        public int? Numero { get; set; } = default; // 9
        public string ChaveNFe { get; set; } = null; // 10
        public DateTime? DataEmissao { get; set; } = default; // 11
        public DateTime? DataPrestacaoAquisicao { get; set; } = default; // 12
        public CTe.TipoCTe TipoCTe { get; set; } = CTe.TipoCTe.Normal; // 13
        public string ChaveCTeReferenciado { get; set; } = null; // 14
        public double? ValorTotalDocumento { get; set; } = default; // 15
        public double? ValorDesconto { get; set; } = default; // 16
        public IndicadorFrete TipoFrete { get; set; } = IndicadorFrete.SemFrete; // 17
        public double? ValorPrestacaoServico { get; set; } = default; // 18
        public double? ValorBaseCalculoICMS { get; set; } = default; // 19
        public double? ValorICMS { get; set; } = default; // 20
        public double? ValorNaoTributado { get; set; } = default; // 21
        public string CodigoComplementar0450 { get; set; } = null; // 22
        public string CodigoContaContabil { get; set; } = null; // 23
        public string IBGE_Municipio_Origem { get; set; } = null; // 24
        public string IBGE_Municipio_destino { get; set; } = null; // 25


        // Registros Filhos
        public RegistroD101 RegistroD101 { get; set; }
        public List<RegistroD110> RegistrosD110 { get; set; } = new List<RegistroD110>();
        public List<RegistroD190> RegistrosD190 { get; set; } = new List<RegistroD190>();
        public List<RegistroD195> RegistrosD195 { get; set; } = new List<RegistroD195>();

        public bool DocumentoValido()
        {
            if (SituacaoDocumento == SituacaoDocumento.Cancelado | SituacaoDocumento == SituacaoDocumento.CanceladoExtemporaneo | SituacaoDocumento == SituacaoDocumento.Denegado | SituacaoDocumento == SituacaoDocumento.Inutilizado)
                return false;
            else
                return true;
        }
    }
}