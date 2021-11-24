using System.Collections.Generic;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Apuração do ICMS ST
    /// </summary>
    public class RegistroE210 : Primitives.Registro
    {
        public RegistroE210() : base("E210")
        {
        }

        public RegistroE210(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|E210|"); // 1
            writer.Append((int)IndicadorMovimentoST + "|"); // 2
            writer.Append(string.Format("{0:0.##}", SaldoCredorAnterior) + "|"); // 3
            writer.Append(string.Format("{0:0.##}", ValorSTDevolucoes) + "|"); // 4
            writer.Append(string.Format("{0:0.##}", ValorSTRessarcimentos) + "|"); // 5
            writer.Append(string.Format("{0:0.##}", CreditosAjustes) + "|"); // 6
            writer.Append(string.Format("{0:0.##}", CreditosAjustesDocFiscal) + "|"); // 7
            writer.Append(string.Format("{0:0.##}", RetencaoST) + "|"); // 8
            writer.Append(string.Format("{0:0.##}", DebitosAjustes) + "|"); // 9
            writer.Append(string.Format("{0:0.##}", DebitosAjustesDocFiscal) + "|"); // 10
            writer.Append(string.Format("{0:0.##}", SaldoDevedorApurado) + "|"); // 11
            writer.Append(string.Format("{0:0.##}", DeducoesTotais) + "|"); // 12
            writer.Append(string.Format("{0:0.##}", ICMSST_Recolher) + "|"); // 13
            writer.Append(string.Format("{0:0.##}", SaldoCredorATransportar) + "|"); // 14
            writer.Append(string.Format("{0:0.##}", DebitosExtraApuracao) + "|"); // 15
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorMovimentoST = (IndicadorMovimentoST_Difal)data[2].ToEnum<IndicadorMovimentoST_Difal>(IndicadorMovimentoST_Difal.SemOperacoes);
            SaldoCredorAnterior = data[3].ToNullableDouble();
            ValorSTDevolucoes = data[4].ToNullableDouble();
            ValorSTRessarcimentos = data[5].ToNullableDouble();
            CreditosAjustes = data[6].ToNullableDouble();
            CreditosAjustesDocFiscal = data[7].ToNullableDouble();
            RetencaoST = data[8].ToNullableDouble();
            DebitosAjustes = data[9].ToNullableDouble();
            DebitosAjustesDocFiscal = data[10].ToNullableDouble();
            SaldoDevedorApurado = data[11].ToNullableDouble();
            DeducoesTotais = data[12].ToNullableDouble();
            ICMSST_Recolher = data[13].ToNullableDouble();
            SaldoCredorATransportar = data[14].ToNullableDouble();
            DebitosExtraApuracao = data[15].ToNullableDouble();
        }

        public IndicadorMovimentoST_Difal IndicadorMovimentoST { get; set; } = IndicadorMovimentoST_Difal.SemOperacoes; // 02
        public double? SaldoCredorAnterior { get; set; } = default; // 03
        public double? ValorSTDevolucoes { get; set; } = default; // 04
        public double? ValorSTRessarcimentos { get; set; } = default; // 05
        public double? CreditosAjustes { get; set; } = default; // 06
        public double? CreditosAjustesDocFiscal { get; set; } = default; // 07
        public double? RetencaoST { get; set; } = default; // 08
        public double? DebitosAjustes { get; set; } = default; // 09
        public double? DebitosAjustesDocFiscal { get; set; } = default; // 10
        public double? SaldoDevedorApurado { get; set; } = default; // 11
        public double? DeducoesTotais { get; set; } = default; // 12
        public double? ICMSST_Recolher { get; set; } = default; // 13
        public double? SaldoCredorATransportar { get; set; } = default; // 14
        public double? DebitosExtraApuracao { get; set; } = default; // 15

        // // Navegation Properties:

        public List<RegistroE220> RegistrosE220 { get; set; } = new List<RegistroE220>();
        public List<RegistroE250> RegistrosE250 { get; set; } = new List<RegistroE250>();
    }
}