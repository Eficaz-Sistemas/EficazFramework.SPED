using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Identificação do Estabelecimento
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC010 : Primitives.Registro
    {
        public RegistroC010() : base("C010")
        {
        }

        public RegistroC010(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string NumeroInscricaoEstabelecimentoCNPJ { get; set; } = null;
        public IndicadorApuracaoContribuicoes IndicadorApuracaoContribuicoes { get; set; } = IndicadorApuracaoContribuicoes.ApuracaoBaseRegistroIndividualizado;
        public List<RegistroC100> RegistrosC100 { get; set; } = new List<RegistroC100>();
        public List<RegistroC180> RegistrosC180 { get; set; } = new List<RegistroC180>();
        public List<RegistroC190> RegistrosC190 { get; set; } = new List<RegistroC190>();
        public List<RegistroC380> RegistrosC380 { get; set; } = new List<RegistroC380>();
        public List<RegistroC395> RegistrosC395 { get; set; } = new List<RegistroC395>();
        public List<RegistroC400> RegistrosC400 { get; set; } = new List<RegistroC400>();
        public List<RegistroC490> RegistrosC490 { get; set; } = new List<RegistroC490>();
        public List<RegistroC500> RegistrosC500 { get; set; } = new List<RegistroC500>();

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C010|");
            writer.Append(NumeroInscricaoEstabelecimentoCNPJ + "|");
            writer.Append(((int)IndicadorApuracaoContribuicoes).ToString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroInscricaoEstabelecimentoCNPJ = data[2];
            IndicadorApuracaoContribuicoes = (IndicadorApuracaoContribuicoes)data[3].ToEnum<IndicadorApuracaoContribuicoes>(IndicadorApuracaoContribuicoes.ApuracaoBaseRegistroIndividualizado);
        }
    }
}