using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Ressarcimento de ICMS em operações com ST (01 e 55)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC176 : Primitives.Registro
    {
        public RegistroC176() : base("C176")
        {
        }

        public RegistroC176(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C176|"); // 1
            writer.Append(ModeloDocFiscal + "|"); // 02
            writer.Append(NumeroDocFiscal + "|"); // 03
            writer.Append(SerieDocFiscal + "|"); // 04
            writer.Append(DataDocFiscal.ToSpedString() + "|"); // 05
            writer.Append(CodigoParticipante + "|"); // 06
            writer.Append(string.Format("{0:0.###}", QuantidadeItem) + "|"); // 07
            writer.Append(string.Format("{0:0.###}", ValorUnitarioItem) + "|"); // 08
            writer.Append(string.Format("{0:0.###}", Valor_BC_ST_UnitarioItem) + "|"); // 09
            writer.Append(ChaveNFe + "|"); // 10
            writer.Append(NumeroItem + "|"); // 11
            writer.Append(string.Format("{0:0.##}", Valor_BC_UnitarioItem) + "|"); // 12
            writer.Append(string.Format("{0:0.##}", Aliquota_ICMS) + "|"); // 13
            writer.Append(string.Format("{0:0.##}", ValorUnitario_LimitadoBC) + "|"); // 14
            writer.Append(string.Format("{0:0.###}", ValorUnitario_Credito_ICMS_LimitadoBC) + "|"); // 15
            writer.Append(string.Format("{0:0.##}", Aliquota_ICMS_ST) + "|"); // 16
            writer.Append(string.Format("{0:0.###}", ValorUnitarioRessarcimento) + "|"); // 17
            writer.Append(((int)ResponsavelRetencao).ToString() + "|");  // 18
            writer.Append(((int)MotivoRessarcimento).ToString() + "|");  // 19
            writer.Append(ChaveNF_Retencao + "|");  // 20
            writer.Append(CodigoParticipante_Retencao + "|");  // 21
            writer.Append(SerieNFe_Retencao + "|");  // 22
            writer.Append(NumeroNFe_Retencao + "|");  // 23
            writer.Append(ItemNFe_Retencao + "|");  // 24
            writer.Append(((int)ModeloDocumentoArrecadacao).ToString() + "|");  // 25
            writer.Append(NumeroDocumentoArrecadacao + "|");  // 26
            if (Conversions.ToInteger(Versao) > 13)
            {
                writer.Append(string.Format("{0:0.##}", VlrUnitarioResFCP) + "|"); // 27
            }

            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            ModeloDocFiscal = data[2];
            NumeroDocFiscal = data[3].ToNullableInteger();
            SerieDocFiscal = data[4];
            DataDocFiscal = data[5].ToDate();
            CodigoParticipante = data[6];
            QuantidadeItem = data[7].ToNullableDouble();
            ValorUnitarioItem = data[8].ToNullableDouble();
            Valor_BC_ST_UnitarioItem = data[9].ToNullableDouble();
        }

        public string ModeloDocFiscal { get; set; } = null; // 02
        public int? NumeroDocFiscal { get; set; } = default; // 03
        public string SerieDocFiscal { get; set; } = null; // 04
        public DateTime? DataDocFiscal { get; set; } = default; // 05
        public string CodigoParticipante { get; set; } = null; // 06
        public double? QuantidadeItem { get; set; } = default; // 07
        public double? ValorUnitarioItem { get; set; } = default; // 08
        public double? Valor_BC_ST_UnitarioItem { get; set; } = default; // 09
        public string ChaveNFe { get; set; } = null; // 10
        public int? NumeroItem { get; set; } = default; // 11
        public double? Valor_BC_UnitarioItem { get; set; } = default; // 12
        public double? Aliquota_ICMS { get; set; } = default; // 13

        /// <summary>
        /// Valor unitário da base de cálculo do ICMS relativo à última entrada da mercadoria, limitado ao valor
        /// da BC da retenção (corresponde ao menor valor entre os campos VL_UNIT_BC_ST e VL_UNIT_BC_ICMS_ULT_E )
        /// </summary>
        public double? ValorUnitario_LimitadoBC { get; set; } = default; // 14

        /// <summary>
        /// Valor unitário do crédito de ICMS sobre operações próprias Do remetente, relativo à última entrada da mercadoria
        /// decorrente da quebra da ST – equivalente a multiplicação entre os campos 13 e 14
        /// </summary>
        public double? ValorUnitario_Credito_ICMS_LimitadoBC { get; set; } = default; // 15
        public double? Aliquota_ICMS_ST { get; set; } = default; // 16
        public double? ValorUnitarioRessarcimento { get; set; } = default; // 17
        public ResponsavelRetencaoST ResponsavelRetencao { get; set; } = ResponsavelRetencaoST.ProprioDeclarante; // 18
        public MotimoRessarcimentoST MotivoRessarcimento { get; set; } = MotimoRessarcimentoST.VendaOutraUF; // 19

        /// <summary>
        /// Chave NF-e emitida pelo substituto, na qual consta o valor do ICMS-ST Retido
        /// </summary>
        /// <returns></returns>
        public string ChaveNF_Retencao { get; set; } = null; // 20

        /// <summary>
        /// Código do Partipante emitente da NF-e na qual consta o valor do ICMS-ST Retido
        /// </summary>
        /// <returns></returns>
        public string CodigoParticipante_Retencao { get; set; } = null; // 21

        /// <summary>
        /// Série da NF-e na qual consta o valor do ICMS-ST Retido
        /// </summary>
        /// <returns></returns>
        public string SerieNFe_Retencao { get; set; } = null; // 22

        /// <summary>
        /// Número da NF-e na qual consta o valor do ICMS-ST Retido
        /// </summary>
        /// <returns></returns>
        public int? NumeroNFe_Retencao { get; set; } = default; // 23

        /// <summary>
        /// Número de ordem do Item da NF-e na qual consta o valor do ICMS-ST Retido
        /// </summary>
        /// <returns></returns>
        public int? ItemNFe_Retencao { get; set; } = default; // 24
        public ModeloDocumentoArrecadacaoC176 ModeloDocumentoArrecadacao { get; set; } = ModeloDocumentoArrecadacaoC176.DAE; // 26
        public string NumeroDocumentoArrecadacao { get; set; } = null; // 26
        public double? VlrUnitarioResFCP { get; set; } = default; // 27
    }
}