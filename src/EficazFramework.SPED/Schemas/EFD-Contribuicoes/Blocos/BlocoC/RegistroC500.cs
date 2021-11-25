using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Nota Fiscal Energia Elétrica
    /// </summary>
    /// <remarks></remarks>


    public class RegistroC500 : Primitives.Registro
    {
        public RegistroC500() : base("C500")
        {
        }

        public RegistroC500(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoParticipante { get; set; } = null;
        public string CodigoModeloDocFiscal { get; set; } = null;
        public string CodigoSitDocFiscal { get; set; } = null;
        public string SerieDocFiscal { get; set; } = null;
        public string SubSerieDocFiscal { get; set; } = null;
        public string NumeroDocFiscal { get; set; } = null;
        public DateTime? DataDocFiscal { get; set; }
        public DateTime? DataEntrada { get; set; }
        public double? VrTotalDocFiscal { get; set; }
        public double? VrAcumICMS { get; set; }
        public string CodigoInfoComplementar { get; set; } = null;
        public double? VrPis { get; set; }
        public double? VrCofins { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C500|");
            writer.Append(CodigoParticipante + "|");
            writer.Append(CodigoModeloDocFiscal + "|");
            writer.Append(string.Format("{0:00}", Conversions.ToInteger(CodigoSitDocFiscal)) + "|");
            writer.Append(SerieDocFiscal + "|");
            writer.Append(SubSerieDocFiscal + "|");
            writer.Append(NumeroDocFiscal + "|");
            writer.Append(DataDocFiscal.ToSpedString() + "|");
            writer.Append(DataEntrada.ToSpedString() + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalDocFiscal) + "|");
            writer.Append(string.Format("{0:0.##}", VrAcumICMS) + "|");
            writer.Append(CodigoInfoComplementar + "|");
            writer.Append(string.Format("{0:0.##}", VrPis) + "|");
            writer.Append(string.Format("{0:0.##}", VrCofins) + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoParticipante = data[2];
            CodigoModeloDocFiscal = data[3];
            CodigoSitDocFiscal = data[4];
            SerieDocFiscal = data[5];
            SubSerieDocFiscal = data[6];
            NumeroDocFiscal = data[7];
            DataDocFiscal = data[8].ToDate();
            DataEntrada = data[9].ToDate();
            VrTotalDocFiscal = data[10].ToNullableDouble();
            VrAcumICMS = data[11].ToNullableDouble();
            CodigoInfoComplementar = data[12];
            VrPis = data[13].ToNullableDouble();
            VrCofins = data[14].ToNullableDouble();
        }
    }
}