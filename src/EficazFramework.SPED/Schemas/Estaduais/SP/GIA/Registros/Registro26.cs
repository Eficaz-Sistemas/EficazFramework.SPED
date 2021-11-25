using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.SP.GIA
{

    /// <summary>
    /// IE Substituto
    /// </summary>
    public class Registro26 : Primitives.Registro
    {
        public Registro26() : base("26")
        {
        }

        public Registro26(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("26"); // 1 Código Registro
            writer.Append(InscricaoEstadual.ToFixedLenghtString(12, Escrituracao._builder, Alignment.Right, " ")); // 2
            if (NumeroNF.HasValue == false)
                NumeroNF = 0;
            writer.Append(string.Format(Conversions.ToString(NumeroNF), "{0:000000000}")); // 3
            writer.Append(DataInicio.ToSintegraString(Extensions.DateFormat.AAAAMM)); // 4
            writer.Append(DataFim.ToSintegraString(Extensions.DateFormat.AAAAMM)); // 5
            writer.Append(Valor.ValueToString().ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 6
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            InscricaoEstadual = linha.Substring(2, 12).Trim();
            NumeroNF = linha.Substring(14, 9).Trim().ToNullableInteger();
            DataInicio = linha.Substring(23, 6).Trim().ToDate(Extensions.DateFormat.AAAAMM);
            DataFim = linha.Substring(29, 6).Trim().ToDate(Extensions.DateFormat.AAAAMM);
            Valor = linha.Substring(35, 15).ToNullableDouble(2);
        }

        public string InscricaoEstadual { get; set; } = null;
        public int? NumeroNF { get; set; } = default;
        public DateTime? DataInicio { get; set; } = default;
        public DateTime? DataFim { get; set; } = default;
        public double? Valor { get; set; } = 0;
    }
}