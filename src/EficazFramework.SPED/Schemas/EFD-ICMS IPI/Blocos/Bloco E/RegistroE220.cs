using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Informações Adicionais do Ajuste da Apuração do ICMS ST
    /// </summary>
    /// <remarks></remarks>
    public class RegistroE220 : Primitives.Registro
    {
        public RegistroE220() : base("E220")
        {
        }

        public RegistroE220(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|E220|"); // 01
            writer.Append(CodigoAjuste + "|"); // 02
            writer.Append(DescricaoComplementar + "|"); // 03
            writer.Append(string.Format("{0:0.##}", ValorAjuste) + "|"); // 04
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoAjuste = data[2];
            DescricaoComplementar = data[3];
            ValorAjuste = data[4].ToNullableDouble();
        }

        public string CodigoAjuste { get; set; } = null; // 02
        public string DescricaoComplementar { get; set; } = null; // 03
        public double? ValorAjuste { get; set; } // 04

        // Navigation Properties
        public List<RegistroE230> RegistrosE230 { get; set; } = new List<RegistroE230>();
        public List<RegistroE240> RegistrosE240 { get; set; } = new List<RegistroE240>();
    }
}