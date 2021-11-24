using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.CNAB240.Itau
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
            writer.Append("05"); // 1
            writer.Append(CodigoRecolhimento ?? "".Replace("-", "").ToFixedLenghtString(4, Escrituracao._builder, Alignment.Right, " ")); // 2
            writer.Append(TipoInscricao.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(CNPJ_CPF.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 4
            writer.Append(InscricaoEstadual.ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 5
            writer.Append(DividaAtiva_Etiqueta.ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 6
            writer.Append(string.Format("{0:MMyyyy}", Competencia)); // 7
            writer.Append(ParcelaNotificacao.ToFixedLenghtString(13, Escrituracao._builder, Alignment.Right, "0")); // 8
            writer.Append(ValorPrincipal.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 9
            writer.Append(ValorMulta.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 10
            writer.Append(ValorJurosEncargos.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 11
            writer.Append(ValorTotal.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 12
            writer.Append(string.Format("{0:ddMMyyyy}", DataVencimento)); // 13
            writer.Append(string.Format("{0:ddMMyyyy}", DataArrecadacao)); // 14
            writer.Append("           "); // 15
            writer.Append(ContribuinteNome.ToFixedLenghtString(30, Escrituracao._builder, Alignment.Right, " ")); // 16
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoRecolhimento = linha.Substring(19, 4).Trim();
            TipoInscricao = linha.Substring(23, 1).Trim();
            CNPJ_CPF = linha.Substring(24, 14).Trim();
            InscricaoEstadual = linha.Substring(38, 12).Trim();
            DividaAtiva_Etiqueta = linha.Substring(50, 13).Trim();
            Competencia = linha.Substring(63, 6).Trim().ToDate(Extensions.DateFormat.MMAAAA);
            ParcelaNotificacao = linha.Substring(69, 13).Trim();
            ValorPrincipal = linha.Substring(82, 14).Trim().ToNullableDouble(2);
            ValorJurosEncargos = linha.Substring(96, 14).Trim().ToNullableDouble(2);
            ValorMulta = linha.Substring(110, 14).Trim().ToNullableDouble(2);
            ValorTotal = linha.Substring(124, 14).Trim().ToNullableDouble(2);
            DataVencimento = linha.Substring(138, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
            DataArrecadacao = linha.Substring(146, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
            ContribuinteNome = linha.Substring(165, 30).Trim();
        }

        public string CodigoRecolhimento { get; set; }
        /// <summary>
        /// 1 = CNPJ [Default]
        /// 2 = CEI
        /// </summary>
        public string TipoInscricao { get; set; } = "2";
        public string CNPJ_CPF { get; set; }
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
        public DateTime? DataArrecadacao { get; set; }
        public string ContribuinteNome { get; set; }
    }
}