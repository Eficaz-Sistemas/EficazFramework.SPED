using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.SP.GIA
{

    /// <summary>
    /// Registro Mestre
    /// </summary>
    public class Registro01 : Primitives.Registro
    {
        public Registro01() : base("01")
        {
        }

        public Registro01(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("01"); // 1 Código Registro
            writer.Append("01"); // 2 Front-End GIA
            writer.Append(DataGeracao.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3
            writer.Append(HoraGeracao.ToSintegraString(TimeFormat.HHMMSS)); // 4
            writer.Append("0000"); // 2 Front-End GIA
            writer.Append(VersaoSistemaGIA.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 5
            // writer.Append(Me.Versao.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")) '6
            if (TotalRegistros05.HasValue == false)
                TotalRegistros05 = 0;
            writer.Append(TotalRegistros05.ToString().ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 7
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            DataGeracao = linha.Substring(4, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
            HoraGeracao = linha.Substring(12, 6).Trim().ToTime(TimeFormat.HHMMSS);
            VersaoSistemaGIA = linha.Substring(18, 4).Trim();
            TotalRegistros05 = linha.Substring(26, 4).ToNullableInteger();
        }

        public DateTime? DataGeracao { get; set; } = default;
        public TimeSpan? HoraGeracao { get; set; } = default;
        public string VersaoSistemaGIA { get; set; } = "0000";
        public int? TotalRegistros05 { get; set; } = 0;
    }
}