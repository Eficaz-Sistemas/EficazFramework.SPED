using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Ajuste da contribuição previdenciária apurada sobre a receita bruta
    /// </summary>
    /// <remarks></remarks>

    public class RegistroP210 : Primitives.Registro
    {
        public RegistroP210() : base("P210")
        {
        }

        public RegistroP210(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public IndicadorTipoAjusteBlocoP IndicadorTipoAjuste { get; set; } = IndicadorTipoAjusteBlocoP.AjusteAcrescimo;
        public double? VrAjuste { get; set; }
        public string CodigoAjuste { get; set; } = null;
        public string NumeroProcesso { get; set; } = null;
        public string DescricaoResumidaAjuste { get; set; } = null;
        public DateTime? DataRefAjuste { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|P210|");
            writer.Append(((int)IndicadorTipoAjuste).ToString() + "|");
            writer.Append(VrAjuste + "|");
            writer.Append(CodigoAjuste + "|");
            writer.Append(NumeroProcesso + "|");
            writer.Append(DescricaoResumidaAjuste + "|");
            writer.Append(DataRefAjuste + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorTipoAjuste = (IndicadorTipoAjusteBlocoP)data[2].ToEnum<IndicadorTipoAjusteBlocoP>(IndicadorTipoAjusteBlocoP.AjusteAcrescimo);
            VrAjuste = data[3].ToNullableDouble();
            CodigoAjuste = data[4];
            NumeroProcesso = data[5];
            DescricaoResumidaAjuste = data[6];
            DataRefAjuste = data[7].ToDate();
        }
    }
}