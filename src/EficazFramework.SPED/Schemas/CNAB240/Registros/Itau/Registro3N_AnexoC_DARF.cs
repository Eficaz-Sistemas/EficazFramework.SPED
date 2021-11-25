using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.CNAB240.Itau
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
            writer.Append("02"); // 1
            writer.Append(CodigoRecolhimento ?? "".Replace("-", "").ToFixedLenghtString(4, Escrituracao._builder, Alignment.Right, " ")); // 2
            writer.Append(TipoInscricao.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(CNPJ_CPF.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 4
            writer.Append(string.Format("{0:ddMMyyyy}", Competencia)); // 5
            writer.Append(Referencia.ToFixedLenghtString(17, Escrituracao._builder, Alignment.Right, " ")); // 6
            writer.Append(ValorPrincipal.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 7
            writer.Append(ValorMulta.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 8
            writer.Append(ValorJurosEncargos.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 9
            writer.Append(ValorTotal.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 10
            writer.Append(string.Format("{0:ddMMyyyy}", DataVencimento)); // 11
            writer.Append(string.Format("{0:ddMMyyyy}", DataArrecadacao)); // 12
            writer.Append("                              "); // 13
            writer.Append(ContribuinteNome.ToFixedLenghtString(30, Escrituracao._builder, Alignment.Right, " ")); // 14
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoRecolhimento = linha.Substring(19, 4).Trim();
            TipoInscricao = linha.Substring(23, 1).Trim();
            CNPJ_CPF = linha.Substring(24, 14).Trim();
            Competencia = linha.Substring(38, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
            Referencia = linha.Substring(46, 17).Trim();
            ValorPrincipal = linha.Substring(63, 14).Trim().ToNullableDouble(2);
            ValorMulta = linha.Substring(77, 14).Trim().ToNullableDouble(2);
            ValorJurosEncargos = linha.Substring(91, 14).Trim().ToNullableDouble(2);
            ValorTotal = linha.Substring(105, 14).Trim().ToNullableDouble(2);
            DataVencimento = linha.Substring(119, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
            DataArrecadacao = linha.Substring(127, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
            ContribuinteNome = linha.Substring(165, 30).Trim();
        }

        public string CodigoRecolhimento { get; set; }
        /// <summary>
        /// 1 = CPF
        /// 2 = CNPJ [Default]
        /// </summary>
        public string TipoInscricao { get; set; } = "2";
        public string CNPJ_CPF { get; set; }
        public DateTime? Competencia { get; set; }
        public string Referencia { get; set; }
        public double? ValorPrincipal { get; set; }
        public double? ValorMulta { get; set; }
        public double? ValorJurosEncargos { get; set; }
        public double? ValorTotal { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataArrecadacao { get; set; }
        public string ContribuinteNome { get; set; }
    }
}