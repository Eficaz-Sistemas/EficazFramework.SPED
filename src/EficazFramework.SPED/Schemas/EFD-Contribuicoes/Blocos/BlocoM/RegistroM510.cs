using System;
using EficazFrameworkCore.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Ajustes do crédito de Cofins apurado
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM510 : Primitives.Registro
    {
        public RegistroM510() : base("M510")
        {
        }

        public RegistroM510(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public IndicadorTipoAjuste IndicadorTipoAjuste { get; set; } = IndicadorTipoAjuste.AjusteAcrescimo;
        public double? VrAjuste { get; set; }
        public string CodigoAjuste { get; set; } = null;
        public string NumeroProcessoVincAjuste { get; set; } = null;
        public string DescResumAjuste { get; set; } = null;
        public DateTime? DataRefAjuste { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M510|");
            writer.Append(((int)IndicadorTipoAjuste).ToString() + "|");
            writer.Append(string.Format("{0:0.##}", VrAjuste) + "|");
            writer.Append(CodigoAjuste + "|");
            writer.Append(NumeroProcessoVincAjuste + "|");
            writer.Append(DescResumAjuste + "|");
            writer.Append(DataRefAjuste + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorTipoAjuste = (IndicadorTipoAjuste)Conversions.ToInteger(data[2]);
            VrAjuste = data[3].ToNullableDouble();
            CodigoAjuste = data[4];
            NumeroProcessoVincAjuste = data[5];
            DescResumAjuste = data[6];
            DataRefAjuste = data[7].ToDate();
        }
    }
}