using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Identificação dos Documentos do Ajuste da Apuração do ICMS
    /// </summary>
    /// <remarks></remarks>
    public class RegistroE113 : Primitives.Registro
    {
        public RegistroE113() : base("E113")
        {
        }

        public RegistroE113(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|E113|"); // 01
            writer.Append(CodigoParticipante + "|"); // 02
            writer.Append(Modelo + "|"); // 03
            writer.Append(Serie + "|"); // 04
            writer.Append(SubSerie + "|"); // 05
            writer.Append(Numero + "|"); // 06
            writer.Append(DataEmissao.ToSpedString() + "|"); // 07
            writer.Append(CodigoItem0200 + "|"); // 08
            writer.Append(string.Format("{0:0.##}", ValorAjusteItem) + "|"); // 09
            writer.Append(ChaveDocEletronico + "|"); // 10
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoParticipante = data[2];
            Modelo = data[3];
            Serie = data[4];
            SubSerie = data[5];
            Numero = data[6].ToNullableInteger();
            DataEmissao = data[7].ToDate();
            CodigoItem0200 = data[8];
            ValorAjusteItem = data[9].ToNullableDouble();
            ChaveDocEletronico = data[10];
        }

        public string CodigoParticipante { get; set; } = null; // 02
        public string Modelo { get; set; } = null; // 03
        public string Serie { get; set; } = null; // 04
        public string SubSerie { get; set; } = null; // 05
        public int? Numero { get; set; } = default; // 06
        public DateTime? DataEmissao { get; set; } = default; // 07
        public string CodigoItem0200 { get; set; } = null; // 08
        public double? ValorAjusteItem { get; set; } = default; // 09
        public string ChaveDocEletronico { get; set; } = null; // 10
    }
}