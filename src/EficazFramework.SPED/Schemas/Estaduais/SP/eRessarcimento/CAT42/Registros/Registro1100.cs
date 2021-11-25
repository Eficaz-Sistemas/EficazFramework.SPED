using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.SP.eRessarcimento.CAT42
{

    /// <summary>
    /// REGISTRO DE DOCUMENTO FISCAL ELETRÔNICO PARA FINS DE RESSARCIMENTO DE SUBSTITUIÇÂO TRIBUTÁRIA OU ANTECIPAÇÃO
    /// </summary>
    /// <remarks></remarks>
    public class Registro1100 : Primitives.Registro
    {
        public string ChaveNFe { get; set; } = null; // 2
        public DateTime? DataEscrituracao { get; set; } = default; // 3
        public int? NumeroItemOrdem { get; set; } = default; // 4
        public EFD_ICMS_IPI.IndicadorOperacao Operacao { get; set; } = EFD_ICMS_IPI.IndicadorOperacao.Entrada; // 5
        public string CodigoProduto { get; set; } = null; // 6
        public string CFOP { get; set; } = null; // 7
        public double? Quantidade { get; set; } = default; // 8

        /// <summary>
        /// Valor total do ICMS suportado pelo contribuinte nas operações de entrada.
        /// </summary>
        /// <returns></returns>
        public double? ICMSTotal { get; set; } = default; // 9

        /// <summary>
        /// Valor de confronto nas operações de saída
        /// </summary>
        /// <returns></returns>
        public double? ValorConfronto { get; set; } = default; // 10
        public EnquadramentLegal CodigoLegal { get; set; } = EnquadramentLegal.OperacaoSemComplouRessarc; // 11
        public bool IsDevolucao { get; set; } = false;

        public Registro1100() : base("1100")
        {
        }

        public Registro1100(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("1100|"); // 1
            writer.Append(ChaveNFe + "|"); // 2
            writer.Append(DataEscrituracao.ToSpedString() + "|");  // 3
            writer.Append(string.Format("{0:000}", NumeroItemOrdem) + "|"); // 4s
            writer.Append((int)Operacao + "|"); // 5
            writer.Append(CodigoProduto + "|"); // 6
            writer.Append(CFOP + "|"); // 7
            //if (Operacao == EFD_ICMS_IPI.IndicadorOperacao.Entrada & (int)CodigoLegal > 0)
            //{
            //    if (Quantidade.HasValue)
            //        Quantidade *= -1;
            //    if (ICMSTotal.HasValue)
            //        ICMSTotal *= -1;
            //    if (ValorConfronto.HasValue)
            //        ValorConfronto *= -1;
            //}

            writer.Append(string.Format("{0:0.000}", Quantidade) + "|"); // 8
            // ICMS Total 9
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


            // Valor Confronto 10
            //if (Operacao == EFD_ICMS_IPI.IndicadorOperacao.Saida)
            //{
            //    if (IsDevolucao == false)
            //    {
            //        if ((int)CodigoLegal > 0)
            //            writer.Append(string.Format("{0:0.00}", ValorConfronto) + "|");
            //        else
            //            writer.Append("|");
            //    }
            //    else
            //    {
            //        writer.Append("|");
            //    }
            //}
            //else if (IsDevolucao == true)
            //{
            //    if ((int)CodigoLegal > 0)
            //        writer.Append(string.Format("{0:0.00}", ValorConfronto) + "|");
            //    else
            //        writer.Append("|");
            //}
            //else
            //{
            //    writer.Append("|");
            //}
            if ((int)CodigoLegal > 0)
                writer.Append(string.Format("{0:0.00}", ValorConfronto) + "|");
            else
                writer.Append('|');

            // Codigo Legal 11
            //if (Operacao == EFD_ICMS_IPI.IndicadorOperacao.Saida)
            //{
            //    if (IsDevolucao == false) 
            //        writer.Append((int)CodigoLegal);
            //}
            //else if ((int)CodigoLegal > 0 | IsDevolucao)
            //    writer.Append((int)CodigoLegal);

            //if ((int)CodigoLegal > 0)
            //    writer.Append((int)CodigoLegal);

            if (Operacao == EFD_ICMS_IPI.IndicadorOperacao.Saida)
                if (!IsDevolucao) writer.Append((int)CodigoLegal);
            else
                if ((int)CodigoLegal > 0 || IsDevolucao) writer.Append((int)CodigoLegal);

            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}