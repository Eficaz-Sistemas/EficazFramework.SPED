using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Saldos Finais das Contas de Resultado Antes do Encerramento
    /// </summary>
    /// <remarks></remarks>

    public class RegistroK355 : Primitives.Registro
    {
        public RegistroK355() : base("K355")
        {
        }

        public RegistroK355(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodContaAnaliticaResultado { get; set; } = null;
        public string CodCentroCusto { get; set; } = null;
        public double? VrSaldoFinalAntesEncerramento { get; set; }
        public string IndicadorSituacaoSaldoFinal { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|K355|");
            writer.Append(CodContaAnaliticaResultado + "|");
            writer.Append(CodCentroCusto + "|");
            writer.Append(string.Format("{0:F2}", VrSaldoFinalAntesEncerramento) + "|");
            writer.Append(IndicadorSituacaoSaldoFinal + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodContaAnaliticaResultado = data[2];
            CodCentroCusto = data[3];
            VrSaldoFinalAntesEncerramento = data[4].ToNullableDouble();
            IndicadorSituacaoSaldoFinal = data[5];
        }
    }
}