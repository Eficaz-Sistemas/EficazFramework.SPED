using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.CNAB240.Febraban
{
    public class Registro3N_AnexoC_DARF : Registro3N_AnexoC
    {
        public Registro3N_AnexoC_DARF()
        {
        }

        public Registro3N_AnexoC_DARF(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append(CodigoRecolhimento.ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 1
            writer.Append(TipoInscricao.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append(CNPJ_CPF.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(IdentificacaoTributo.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(string.Format("{0:ddMMyyyy}", Competencia)); // 5
            writer.Append(Referencia.ToFixedLenghtString(17, Escrituracao._builder, Alignment.Right, " ")); // 6
            writer.Append(ValorPrincipal.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 7
            writer.Append(ValorMulta.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 8
            writer.Append(ValorJurosEncargos.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 9
            writer.Append(string.Format("{0:ddMMyyyy}", DataVencimento)); // 10
            writer.Append("".ToFixedLenghtString(18, Escrituracao._builder, Alignment.Right, " ")); // 11
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoRecolhimento = linha.Substring(110, 6).Trim();
            TipoInscricao = linha.Substring(116, 2).Trim();
            CNPJ_CPF = linha.Substring(118, 14).Trim();
            IdentificacaoTributo = linha.Substring(132, 2).Trim();
            Competencia = linha.Substring(134, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
            Referencia = linha.Substring(142, 17).Trim();
            ValorPrincipal = linha.Substring(159, 13).Trim().ToNullableDouble(2);
            ValorMulta = linha.Substring(174, 13).Trim().ToNullableDouble(2);
            ValorJurosEncargos = linha.Substring(189, 13).Trim().ToNullableDouble(2);
            DataVencimento = linha.Substring(204, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
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
        public string IdentificacaoTributo { get; set; } = "16";
        public DateTime? Competencia { get; set; }
        public string Referencia { get; set; }
        public double? ValorPrincipal { get; set; }
        public double? ValorMulta { get; set; }
        public double? ValorJurosEncargos { get; set; }
        public DateTime? DataVencimento { get; set; }
    }
}