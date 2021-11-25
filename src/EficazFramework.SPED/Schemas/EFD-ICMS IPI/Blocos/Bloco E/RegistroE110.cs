using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Apuração do ICMS
    /// </summary>
    public class RegistroE110 : Primitives.Registro
    {
        public RegistroE110() : base("E110")
        {
        }

        public RegistroE110(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|E110|"); // 1
            writer.Append(string.Format("{0:0.##}", Debitos) + "|"); // 2
            writer.Append(string.Format("{0:0.##}", DebitosAjustesDocFiscal) + "|"); // 3
            writer.Append(string.Format("{0:0.##}", DebitosAjustes) + "|"); // 4
            writer.Append(string.Format("{0:0.##}", EstornoCreditos) + "|"); // 5
            writer.Append(string.Format("{0:0.##}", Creditos) + "|"); // 6
            writer.Append(string.Format("{0:0.##}", CreditosAjustesDocFiscal) + "|"); // 7
            writer.Append(string.Format("{0:0.##}", CreditosAjustes) + "|"); // 8
            writer.Append(string.Format("{0:0.##}", EstornoDebitos) + "|"); // 9
            writer.Append(string.Format("{0:0.##}", SaldoCredorAnterior) + "|"); // 10
            writer.Append(string.Format("{0:0.##}", SaldoDevedorApurado) + "|"); // 11
            writer.Append(string.Format("{0:0.##}", DeducoesTotais) + "|"); // 12
            writer.Append(string.Format("{0:0.##}", ICMS_Recolher) + "|"); // 13
            writer.Append(string.Format("{0:0.##}", SaldoCredorATransportar) + "|"); // 14
            writer.Append(string.Format("{0:0.##}", DebitosExtraApuracao) + "|"); // 15
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Debitos = data[2].ToNullableDouble();
            DebitosAjustesDocFiscal = data[3].ToNullableDouble();
            DebitosAjustes = data[4].ToNullableDouble();
            EstornoCreditos = data[5].ToNullableDouble();
            Creditos = data[6].ToNullableDouble();
            CreditosAjustesDocFiscal = data[7].ToNullableDouble();
            CreditosAjustes = data[8].ToNullableDouble();
            EstornoDebitos = data[9].ToNullableDouble();
            SaldoCredorAnterior = data[10].ToNullableDouble();
            SaldoDevedorApurado = data[11].ToNullableDouble();
            DeducoesTotais = data[12].ToNullableDouble();
            ICMS_Recolher = data[13].ToNullableDouble();
            SaldoCredorATransportar = data[14].ToNullableDouble();
            DebitosExtraApuracao = data[15].ToNullableDouble();
        }

        public double? Debitos { get; set; } = default; // 2
        public double? DebitosAjustesDocFiscal { get; set; } = default; // 3
        public double? DebitosAjustes { get; set; } = default; // 4
        public double? EstornoCreditos { get; set; } = default; // 5
        public double? Creditos { get; set; } = default; // 6
        public double? CreditosAjustesDocFiscal { get; set; } = default; // 7
        public double? CreditosAjustes { get; set; } = default; // 8
        public double? EstornoDebitos { get; set; } = default; // 9
        public double? SaldoCredorAnterior { get; set; } = default; // 10
        public double? SaldoDevedorApurado { get; set; } = default; // 11
        public double? DeducoesTotais { get; set; } = default; // 12
        public double? ICMS_Recolher { get; set; } = default; // 13
        public double? SaldoCredorATransportar { get; set; } = default; // 14
        public double? DebitosExtraApuracao { get; set; } = default; // 15

        // // Navegation Properties:

        public List<RegistroE111> RegistrosE111 { get; set; } = new List<RegistroE111>();
        public List<RegistroE115> RegistrosE115 { get; set; } = new List<RegistroE115>();
        public List<RegistroE116> RegistrosE116 { get; set; } = new List<RegistroE116>();
    }
}