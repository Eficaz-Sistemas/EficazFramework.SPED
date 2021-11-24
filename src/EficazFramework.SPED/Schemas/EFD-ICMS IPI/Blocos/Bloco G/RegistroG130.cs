using System;
using System.Collections.Generic;
using EficazFrameworkCore.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Identificação do Documento Fiscal
    /// </summary>
    /// <remarks></remarks>
    public class RegistroG130 : Primitives.Registro
    {
        public RegistroG130() : base("G130")
        {
        }

        public RegistroG130(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|G130|"); // 01
            writer.Append((int)IndicadorEmissao + "|"); // 02
            writer.Append(CodigoParticipante + "|"); // 03
            writer.Append(Modelo + "|"); // 04
            writer.Append(Serie + "|"); // 05
            writer.Append(Numero + "|"); // 06
            writer.Append(Chave_NFeCTe + "|"); // 07
            writer.Append(DataEmissao.ToSpedString() + "|"); // 08
            if (Conversions.ToInteger(Versao) >= 14)
            {
                writer.Append(NumeroDocArrecadacao + "|"); // 09
            }

            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorEmissao = (IndicadorEmitente)data[2].ToEnum<IndicadorEmitente>(IndicadorEmitente.Propria);
            CodigoParticipante = data[3];
            Modelo = data[4];
            Serie = data[5];
            Numero = data[6].ToNullableInteger();
            Chave_NFeCTe = data[7];
            DataEmissao = data[8].ToDate();
            if (Conversions.ToInteger(Versao) >= 14)
            {
                NumeroDocArrecadacao = data[9];
            }
        }

        public IndicadorEmitente IndicadorEmissao { get; set; } = IndicadorEmitente.Propria; // 02
        public string CodigoParticipante { get; set; } = null; // 03
        public string Modelo { get; set; } = null; // 04
        public string Serie { get; set; } = null; // 05
        public int? Numero { get; set; } = default; // 06
        public string Chave_NFeCTe { get; set; } = null; // 07
        public DateTime? DataEmissao { get; set; } = default; // 08
        // Versa 14
        public string NumeroDocArrecadacao { get; set; } = null; // 09

        // Navigation
        public List<RegistroG140> RegistrosG140 { get; set; } = new List<RegistroG140>();
    }
}