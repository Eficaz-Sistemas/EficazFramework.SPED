using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Ajustes da contribuição para o Cofins apurada
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM620 : Primitives.Registro
    {
        public RegistroM620() : base("M620")
        {
        }

        public RegistroM620(string linha, string versao) : base(linha, versao)
        {
        }


        // Campos'
        public IndicadorTipoAjuste IndicadorTipoAjuste { get; set; } = IndicadorTipoAjuste.AjusteAcrescimo;
        public double? VrAjuste { get; set; }
        public string CodigoAjuste { get; set; } = null;
        public string NumeroProcesso { get; set; } = null;
        public string DescResumAjuste { get; set; } = null;
        public string DataAjuste { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M620|");
            writer.Append(((int)IndicadorTipoAjuste).ToString() + "|");
            writer.Append(VrAjuste + "|");
            writer.Append(CodigoAjuste + "|");
            writer.Append(NumeroProcesso + "|");
            writer.Append(DescResumAjuste + "|");
            writer.Append(DataAjuste + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorTipoAjuste = (IndicadorTipoAjuste)data[2].ToEnum<IndicadorTipoAjuste>(IndicadorTipoAjuste.AjusteAcrescimo);
            VrAjuste = data[3].ToNullableDouble();
            CodigoAjuste = data[4];
            NumeroProcesso = data[5];
            DescResumAjuste = data[6];
            DataAjuste = Conversions.ToString(data[7].ToDate());
        }
    }
}