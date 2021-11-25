using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Outros Créditos CIAP
    /// </summary>
    /// <remarks></remarks>
    public class RegistroG126 : Primitives.Registro
    {
        public RegistroG126() : base("G126")
        {
        }

        public RegistroG126(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|G126|"); // 01
            writer.Append(DataInicial.ToSpedString() + "|"); // 02
            writer.Append(DataFinal.ToSpedString() + "|"); // 03
            writer.Append(string.Format("{0:000}", NumeroParcela) + "|"); // 04
            writer.Append(string.Format("{0:0.##}", ValorParcela) + "|"); // 05
            writer.Append(string.Format("{0:0.##}", SaidasTributadasOuExportacao) + "|"); // 06
            writer.Append(string.Format("{0:0.##}", TotalSaidas) + "|"); // 07
            writer.Append(string.Format("{0:0.########}", IndiceParticipacao) + "|"); // 08
            writer.Append(string.Format("{0:0.##}", ICMSApropriado) + "|"); // 09
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataInicial = data[2].ToDate();
            DataFinal = data[3].ToDate();
            NumeroParcela = data[4].ToNullableDouble();
            ValorParcela = data[5].ToNullableDouble();
            SaidasTributadasOuExportacao = data[6].ToNullableDouble();
            TotalSaidas = data[7].ToNullableDouble();
            IndiceParticipacao = data[8].ToNullableDouble();
            ICMSApropriado = data[9].ToNullableDouble();
        }

        public DateTime? DataInicial { get; set; } = default; // 02
        public DateTime? DataFinal { get; set; } = default; // 03
        public double? NumeroParcela { get; set; } = default; // 04
        public double? ValorParcela { get; set; } = default; // 05
        public double? SaidasTributadasOuExportacao { get; set; } = default; // 06
        public double? TotalSaidas { get; set; } = default; // 07
        public double? IndiceParticipacao { get; set; } = default; // 08
        public double? ICMSApropriado { get; set; } = default; // 09
    }
}