using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Identificação dos Documentos do Ajuste da Apuração do ICMS Difal
    /// </summary>
    /// <remarks></remarks>
    public class RegistroE313 : Primitives.Registro
    {
        public RegistroE313() : base("E313")
        {
        }

        public RegistroE313(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|E313|"); // 01
            writer.Append(CodigoParticipante + "|"); // 02
            writer.Append(Modelo + "|"); // 03
            writer.Append(Serie + "|"); // 04
            writer.Append(SubSerie + "|"); // 05
            writer.Append(Numero + "|"); // 06
            writer.Append(Chave + "|"); // 07
            writer.Append(DataEmissao.ToSpedString() + "|"); // 08
            writer.Append(CodigoItem0200 + "|"); // 09
            writer.Append(string.Format("{0:0.##}", ValorAjusteItem) + "|"); // 10
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoParticipante = data[2];
            Modelo = data[3];
            Serie = data[4];
            SubSerie = data[5];
            Numero = data[6].ToNullableInteger();
            Chave = data[7];
            DataEmissao = data[8].ToDate();
            CodigoItem0200 = data[9];
            ValorAjusteItem = data[10].ToNullableDouble();
        }

        public string CodigoParticipante { get; set; } = null; // 02
        public string Modelo { get; set; } = null; // 03
        public string Serie { get; set; } = null; // 04
        public string SubSerie { get; set; } = null; // 05
        public int? Numero { get; set; } = default; // 06
        public string Chave { get; set; } = null; // 07
        public DateTime? DataEmissao { get; set; } = default; // 08
        public string CodigoItem0200 { get; set; } = null; // 09
        public double? ValorAjusteItem { get; set; } = default; // 10
    }
}