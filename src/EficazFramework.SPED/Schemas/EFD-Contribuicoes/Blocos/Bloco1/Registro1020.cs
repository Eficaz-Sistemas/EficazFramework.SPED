using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Processo Referenciado - Processo administrativo
    /// </summary>
    /// <remarks></remarks>

    public class Registro1020 : Primitives.Registro
    {
        public Registro1020() : base("1020")
        {
        }

        public Registro1020(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string IdentifProcessoAdmOuDecisaoAdm { get; set; } = null;
        public IndicadorNaturezaAcaoProcAdmSRFB IndicadorNaturezaAcaoProcAdmSRFB { get; set; } = IndicadorNaturezaAcaoProcAdmSRFB.Outros;
        public string DataDespachoDescisaoAdm { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1020|");
            writer.Append(IdentifProcessoAdmOuDecisaoAdm + "|");
            writer.Append(((int)IndicadorNaturezaAcaoProcAdmSRFB).ToString() + "|");
            writer.Append(DataDespachoDescisaoAdm + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IdentifProcessoAdmOuDecisaoAdm = data[2];
            IndicadorNaturezaAcaoProcAdmSRFB = (IndicadorNaturezaAcaoProcAdmSRFB)Conversions.ToInteger(data[3]);
            DataDespachoDescisaoAdm = data[4];
        }
    }
}