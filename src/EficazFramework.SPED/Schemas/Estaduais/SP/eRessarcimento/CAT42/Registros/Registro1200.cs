using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.SP.eRessarcimento.CAT42
{

    /// <summary>
    /// REGISTRO DE DOCUMENTO FISCAL NÃO-ELETRÔNICO PARA FINS DE RESSARCIMENTO DE SUBSTITUIÇÂO TRIBUTÁRIA - SP
    /// </summary>
    /// <remarks></remarks>
    public class Registro1200 : Primitives.Registro
    {
        public string CodigoParticipante { get; set; } = null; // 2
        public string CodigoModelo { get; set; } = null; // 3
        public string ECF_NnumeroSerie { get; set; } = null; // 4
        public string SerieDocumento { get; set; } = null; // 5
        public int? NumeroDocumento { get; set; } = default; // 6
        public int? NumeroItemOrdem { get; set; } = default; // 7
        public EFD_ICMS_IPI.IndicadorOperacao Operacao { get; set; } = EFD_ICMS_IPI.IndicadorOperacao.Entrada; // 8
        public DateTime? DataEscrituracao { get; set; } = default; // 9
        public string CFOP { get; set; } = null; // 10
        public string CodigoProduto { get; set; } = null; // 11
        public double? Quantidade { get; set; } = default; // 12

        /// <summary>
        /// Valor total do ICMS suportado pelo contribuinte nas operações de entrada.
        /// </summary>
        /// <returns></returns>
        public double? ICMSTotal { get; set; } = default; // 13

        /// <summary>
        /// Valor de confronto nas operações de saída
        /// </summary>
        /// <returns></returns>
        public double? ValorConfronto { get; set; } = default; // 14
        public EnquadramentLegal CodigoLegal { get; set; } = EnquadramentLegal.OperacaoSemComplouRessarc; // 15
        public bool IsDevolucao { get; set; } = false;

        public Registro1200() : base("1200")
        {
        }

        public Registro1200(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("1200|"); // 1
            writer.Append(CodigoParticipante + "|"); // 2
            writer.Append(CodigoModelo + "|"); // 3
            writer.Append(ECF_NnumeroSerie + "|"); // 4
            writer.Append(SerieDocumento + "|"); // 5
            writer.Append(NumeroDocumento + "|"); // 6
            writer.Append(string.Format("{0:000}", NumeroItemOrdem) + "|"); // 7
            writer.Append((int)Operacao + "|"); // 8
            writer.Append(DataEscrituracao.ToSpedString() + "|");  // 9
            writer.Append(CFOP + "|"); // 10
            writer.Append(CodigoProduto + "|"); // 11
            if (Operacao == EFD_ICMS_IPI.IndicadorOperacao.Entrada & (int)CodigoLegal > 0)
            {
                if (Quantidade.HasValue)
                    Quantidade *= -1;
                if (ICMSTotal.HasValue)
                    ICMSTotal *= -1;
                if (ValorConfronto.HasValue)
                    ValorConfronto *= -1;
            }

            writer.Append(string.Format("{0:0.000}", Quantidade) + "|"); // 12
            // ICMS Total 13
            if (Operacao == EFD_ICMS_IPI.IndicadorOperacao.Saida)
            {
                if (IsDevolucao == true)
                    writer.Append(string.Format("{0:0.00}", ICMSTotal) + "|");
                else
                    writer.Append('|');
            }
            else
            {
                writer.Append(string.Format("{0:0.00}", ICMSTotal) + "|");
            }
            // Valor Confronto 14
            if (Operacao == EFD_ICMS_IPI.IndicadorOperacao.Saida)
            {
                if (IsDevolucao == false)
                {
                    if ((int)CodigoLegal > 0)
                        writer.Append(string.Format("{0:0.00}", ValorConfronto) + "|");
                    else
                        writer.Append('|');
                }
                else
                {
                    writer.Append('|');
                }
            }
            else if (IsDevolucao == true)
            {
                if ((int)CodigoLegal > 0)
                    writer.Append(string.Format("{0:0.00}", ValorConfronto) + "|");
                else
                    writer.Append('|');
            }
            else
            {
                writer.Append('|');
            }
            // Codigo Legal 15
            if (Operacao == EFD_ICMS_IPI.IndicadorOperacao.Saida)
            {
                if (IsDevolucao == false)
                    writer.Append((int)CodigoLegal);
            }
            else if ((int)CodigoLegal > 0 | IsDevolucao)
                writer.Append((int)CodigoLegal);
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}