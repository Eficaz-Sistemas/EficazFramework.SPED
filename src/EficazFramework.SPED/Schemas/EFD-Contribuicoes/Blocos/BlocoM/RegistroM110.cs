using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Ajustes do crédito de pis apurado
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM110 : Primitives.Registro
    {
        public RegistroM110() : base("M110")
        {
        }

        public RegistroM110(string linha, string versao) : base(linha, versao)
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
            writer.Append("|M110|");
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