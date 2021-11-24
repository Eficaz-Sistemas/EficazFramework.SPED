using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Processo Referenciado - Ação judicial
    /// </summary>
    /// <remarks></remarks>
    public class Registro1010 : Primitives.Registro
    {
        public Registro1010() : base("1010")
        {
        }

        public Registro1010(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string IdentNumProcessoJudicial { get; set; } = null;
        public string IdentSecaoJudiciaria { get; set; } = null;
        public string IndVara { get; set; } = null;
        public IndicadorNaturezaAcaoJudicialJF IndicadorNaturezaAcaoJudicialJF { get; set; } = IndicadorNaturezaAcaoJudicialJF.Outros;
        public string DescricaoResumidaEfeitosTributario { get; set; } = null;
        public DateTime? DataSetencaDecisaoJudicial { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1010|");
            writer.Append(IdentNumProcessoJudicial + "|");
            writer.Append(IdentSecaoJudiciaria + "|");
            writer.Append(IndVara + "|");
            writer.Append(((int)IndicadorNaturezaAcaoJudicialJF).ToString() + "|");
            writer.Append(DescricaoResumidaEfeitosTributario + "|");
            writer.Append(DataSetencaDecisaoJudicial + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IdentNumProcessoJudicial = data[2];
            IdentSecaoJudiciaria = data[3];
            IndVara = data[4];
            IndicadorNaturezaAcaoJudicialJF = (IndicadorNaturezaAcaoJudicialJF)data[5].ToEnum<IndicadorNaturezaAcaoJudicialJF>(IndicadorNaturezaAcaoJudicialJF.Outros);
            DescricaoResumidaEfeitosTributario = data[6];
            DataSetencaDecisaoJudicial = data[7].ToDate();
        }
    }
}