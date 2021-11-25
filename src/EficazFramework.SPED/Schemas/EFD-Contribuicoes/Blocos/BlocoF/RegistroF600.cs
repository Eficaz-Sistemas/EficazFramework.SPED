using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Contribuição Retida na fonte
    /// </summary>
    /// <remarks></remarks>

    public class RegistroF600 : Primitives.Registro
    {
        public RegistroF600() : base("F600")
        {
        }

        public RegistroF600(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'   
        public IndicadorNatRetFonte IndicadorNatRetFonte { get; set; } = IndicadorNatRetFonte.RetencaoPessoasJuridicasDireitoPrivado;
        public DateTime? DataRetencao { get; set; }
        public double? VrBcRetencao { get; set; }
        public double? VrTotalRetidoFonte { get; set; }
        public string CodigoReceita { get; set; } = null;
        public IndicadorNaturezaReceita IndicadorNatRec { get; set; } = IndicadorNaturezaReceita.ReceitaNaturezaCumulativa;
        public string CNPJFontePagadora { get; set; } = null;
        public double? VrRetidoFontePis { get; set; }
        public double? VrRetidoFonteCofins { get; set; }
        public IndicadorCondicaoPJDeclarante IndicadorCondDeclarante { get; set; } = IndicadorCondicaoPJDeclarante.BeneficiariaRetencao;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|F600|");
            writer.Append(((int)IndicadorNatRetFonte).ToString() + "|");
            writer.Append(DataRetencao + "|");
            writer.Append(VrBcRetencao + "|");
            writer.Append(VrTotalRetidoFonte + "|");
            writer.Append(CodigoReceita + "|");
            writer.Append(((int)IndicadorNatRec).ToString() + "|");
            writer.Append(CNPJFontePagadora + "|");
            writer.Append(VrRetidoFontePis + "|");
            writer.Append(VrRetidoFonteCofins + "|");
            writer.Append(((int)IndicadorCondDeclarante).ToString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorNatRetFonte = (IndicadorNatRetFonte)data[2].ToEnum<IndicadorNatRetFonte>(IndicadorNatRetFonte.RetencaoPessoasJuridicasDireitoPrivado);
            DataRetencao = data[3].ToDate();
            VrBcRetencao = data[4].ToNullableDouble();
            VrTotalRetidoFonte = data[5].ToNullableDouble();
            CodigoReceita = data[6];
            IndicadorNatRec = (IndicadorNaturezaReceita)data[7].ToEnum<IndicadorNaturezaReceita>(IndicadorNaturezaReceita.ReceitaNaturezaCumulativa);
            CNPJFontePagadora = data[8];
            VrRetidoFontePis = data[9].ToNullableDouble();
            VrRetidoFonteCofins = data[10].ToNullableDouble();
            IndicadorCondDeclarante = (IndicadorCondicaoPJDeclarante)data[11].ToEnum<IndicadorCondicaoPJDeclarante>(IndicadorCondicaoPJDeclarante.BeneficiariaRetencao);
        }
    }
}