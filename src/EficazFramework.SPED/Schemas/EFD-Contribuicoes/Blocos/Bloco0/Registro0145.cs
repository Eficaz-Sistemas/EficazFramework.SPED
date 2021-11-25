using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Regime de Apuração da Contribuição Previdenciária Sobre a Receita Bruta
    /// </summary>
    /// <remarks></remarks>

    public class Registro0145 : Primitives.Registro
    {
        public Registro0145() : base("0145")
        {
        }

        public Registro0145(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public RegimeApuracaoCPRB RegimeApuracaoCPRB { get; set; } = RegimeApuracaoCPRB.ContribuicaoPrevidenciariaExclusivamenteRecBruta;
        public double? ValorRecBrutaPJPeriodo { get; set; }
        public double? ValorRecBrutaAtividadeCPRB { get; set; }
        public double? ValorRecBrutaAtividadenaoCPRB { get; set; }
        public string InformacaoComplementar { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0145|");
            writer.Append(((int)RegimeApuracaoCPRB).ToString() + "|");
            writer.Append(ValorRecBrutaPJPeriodo + "|");
            writer.Append(ValorRecBrutaAtividadeCPRB + "|");
            writer.Append(ValorRecBrutaAtividadenaoCPRB + "|");
            writer.Append(InformacaoComplementar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            RegimeApuracaoCPRB = (RegimeApuracaoCPRB)data[2].ToEnum<RegimeApuracaoCPRB>(RegimeApuracaoCPRB.ContribuicaoPrevidenciariaExclusivamenteRecBruta);
            ValorRecBrutaPJPeriodo = data[3].ToNullableDouble();
            ValorRecBrutaAtividadeCPRB = data[4].ToNullableDouble();
            ValorRecBrutaAtividadenaoCPRB = data[5].ToNullableDouble();
            InformacaoComplementar = data[6];
        }
    }
}