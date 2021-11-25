using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.Sintegra
{

    // NFCe
    public class Registro61 : Primitives.Registro
    {
        public Registro61(string linha, string versao) : base(linha, versao)
        {
        }

        public Registro61() : base("61")
        {
        }

        public override string EscreveLinha()
        {
            var writer = new global::System.Text.StringBuilder();
            writer.Append("61"); // 1
            writer.Append(Brancos.ToFixedLenghtString(28, Escrituracao._builder, Alignment.Left, " ")); // 2 e 3
            writer.Append(Data.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 4
            // writer.Append(Me.UF.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")) 
            writer.Append(Modelo.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 5
            writer.Append(Serie.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Right, " ")); // 6
            writer.Append(SubSerie.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 7
            writer.Append(NumeroInicial.ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 8
            writer.Append(NumeroFinal.ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 9
            writer.Append(ValorTotal.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 10
            writer.Append(BaseCalculo.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 11
            writer.Append(ICMS.ValueToString(2).ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 12
            writer.Append(Isentas.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 13
            writer.Append(Outras.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 14
            writer.Append(Aliquota.ValueToString(2).ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 15
            writer.Append(' '); // 16
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            Data = linha.Substring(30, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
            Modelo = linha.Substring(38, 2).Trim();
            Serie = linha.Substring(40, 3).Trim();
            SubSerie = linha.Substring(43, 2).Trim();
            NumeroInicial = linha.Substring(45, 6).Trim();
            NumeroFinal = linha.Substring(51, 6).Trim();
            ValorTotal = linha.Substring(57, 13).ToNullableDouble(2);
            BaseCalculo = linha.Substring(70, 13).ToNullableDouble(2);
            ICMS = linha.Substring(83, 12).ToNullableDouble(2);
            Isentas = linha.Substring(95, 13).ToNullableDouble(2);
            Outras = linha.Substring(108, 13).ToNullableDouble(2);
            Aliquota = linha.Substring(121, 4).ToNullableDouble(2);
        }

        private string Brancos { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime? Data { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string SubSerie { get; set; }
        public string NumeroInicial { get; set; }
        public string NumeroFinal { get; set; }
        public double? ValorTotal { get; set; }
        public double? BaseCalculo { get; set; }
        public double? ICMS { get; set; }
        public double? Isentas { get; set; }
        public double? Outras { get; set; }
        public double? Aliquota { get; set; }
    }
}