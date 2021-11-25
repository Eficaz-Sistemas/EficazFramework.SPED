using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Lançamento Contábil
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI200 : Primitives.Registro
    {
        public RegistroI200() : base("I200")
        {
        }

        public RegistroI200(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodIdentUnicaLcto { get; set; } = null;
        public DateTime? DataLcto { get; set; }
        public double? VrLcto { get; set; }
        public string IndicadorTipoLancamento { get; set; } = null;
        public DateTime? DataLctoExtemporaneo { get; set; }
        public List<RegistroI250> RegistrosI250 { get; set; } = new List<RegistroI250>();

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I200|");
            writer.Append(CodIdentUnicaLcto + "|");
            writer.Append(DataLcto.ToSpedString() + "|");
            writer.Append(string.Format("{0:F2}", VrLcto) + "|");
            writer.Append(IndicadorTipoLancamento + "|");
            if (Conversions.ToInteger(Versao) / 100d >= 7d)
                writer.Append(DataLctoExtemporaneo.ToSpedString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodIdentUnicaLcto = data[2];
            DataLcto = data[3].ToDate();
            VrLcto = data[4].ToNullableDouble();
            IndicadorTipoLancamento = data[5];
            if (Conversions.ToInteger(Versao) / 100d >= 7d)
                DataLctoExtemporaneo = data[6].ToDate();
        }
    }
}