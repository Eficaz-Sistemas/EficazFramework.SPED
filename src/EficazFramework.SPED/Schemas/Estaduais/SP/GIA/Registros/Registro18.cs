using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.SP.GIA
{

    /// <summary>
    /// ZFM/ALC
    /// </summary>
    public class Registro18 : Primitives.Registro
    {
        public Registro18() : base("18")
        {
        }

        public Registro18(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("18"); // 1 Código Registro
            if (NumeroNF.HasValue == false)
                NumeroNF = 0;
            writer.Append(string.Format(Conversions.ToString(NumeroNF), "{0:000000000}")); // 2
            writer.Append(Data.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3
            writer.Append(Valor.ValueToString().ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 4
            writer.Append(CNPJDestinatario.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 5
            writer.Append(MunicipioDestinatario.ToFixedLenghtString(5, Escrituracao._builder, Alignment.Left, "0")); // 6
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            NumeroNF = linha.Substring(2, 9).Trim().ToNullableInteger();
            Data = linha.Substring(11, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
            Valor = linha.Substring(19, 15).ToNullableDouble(2);
            CNPJDestinatario = linha.Substring(34, 14).Trim();
            MunicipioDestinatario = linha.Substring(48, 5).Trim();
        }

        public int? NumeroNF { get; set; } = default;
        public DateTime? Data { get; set; } = default;
        public double? Valor { get; set; } = 0;
        public string CNPJDestinatario { get; set; } = null;
        public string MunicipioDestinatario { get; set; } = null;
    }
}