using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.CNAB240.Febraban
{
    public class Registro3N_AnexoC_GARE_SP : Registro3N_AnexoC
    {
        public Registro3N_AnexoC_GARE_SP()
        {
        }

        public Registro3N_AnexoC_GARE_SP(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append(CodigoRecolhimento ?? "".Replace("-", "").ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 1
            writer.Append(TipoInscricao.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append(CNPJ_CPF.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(IdentificacaoTributo.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(string.Format("{0:ddMMyyyy}", DataVencimento)); // 5
            writer.Append(InscricaoEstadual.ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 6
            writer.Append(DividaAtiva_Etiqueta.ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 7
            writer.Append(string.Format("{0:MMyyyy}", Competencia)); // 8
            writer.Append(ParcelaNotificacao.ToFixedLenghtString(13, Escrituracao._builder, Alignment.Right, "0")); // 9
            writer.Append(ValorPrincipal.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 10
            writer.Append(ValorMulta.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 11
            writer.Append(ValorJurosEncargos.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 12
            writer.Append("".ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 13
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoRecolhimento = linha.Substring(110, 6).Trim();
            TipoInscricao = linha.Substring(116, 2).Trim();
            CNPJ_CPF = linha.Substring(118, 14).Trim();
            IdentificacaoTributo = linha.Substring(132, 2).Trim();
            DataVencimento = linha.Substring(143, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
            InscricaoEstadual = linha.Substring(143, 12).Trim();
            DividaAtiva_Etiqueta = linha.Substring(154, 13).Trim();
            Competencia = linha.Substring(167, 6).Trim().ToDate(Extensions.DateFormat.MMAAAA);
            ParcelaNotificacao = linha.Substring(173, 13).Trim();
            ValorPrincipal = linha.Substring(186, 13).Trim().ToNullableDouble(2);
            ValorJurosEncargos = linha.Substring(201, 12).Trim().ToNullableDouble(2);
            ValorMulta = linha.Substring(215, 12).Trim().ToNullableDouble(2);
        }

        public string CodigoRecolhimento { get; set; }
        /// <summary>
        /// 1 = CNPJ [Default]
        /// 2 = CPF
        /// 3 = NIT/PIS/PASEP
        /// 4 = CEI
        /// 6 = NB
        /// 7 = Núm. Título
        /// 8 = DEBCAD
        /// 9 = Referencia
        /// </summary>
        public string TipoInscricao { get; set; } = "1";
        public string CNPJ_CPF { get; set; }
        public string IdentificacaoTributo { get; set; } = "22";
        public string InscricaoEstadual { get; set; }
        public string DividaAtiva_Etiqueta { get; set; }
        public string Parcela_Notificacao { get; set; }
        public DateTime? Competencia { get; set; }
        public string ParcelaNotificacao { get; set; }
        public double? ValorPrincipal { get; set; }
        public double? ValorMulta { get; set; }
        public double? ValorJurosEncargos { get; set; }
        public double? ValorTotal { get; set; }
        public DateTime? DataVencimento { get; set; }
    }
}