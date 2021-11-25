using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Demonstração do Resultado do Exercício
    /// </summary>
    /// <remarks></remarks>

    public class RegistroJ150 : Primitives.Registro
    {
        public RegistroJ150() : base("J150")
        {
        }

        // Campos'
        // \\\layout 8
        public int NumeroOrdem { get; set; } = 0;
        // fim layout 8
        public string CodAglutinacao { get; set; } = null;
        // \\\layout 7
        public string IndicadorCodAglutinacao { get; set; } = null;
        public string NivelCodAglutinacao { get; set; } = null;
        public string CodAglutinacaoSuperior { get; set; } = null;
        // fim layout 7
        public string DescCodAglutinacao { get; set; } = null;
        // \\\layout 8
        public double? VrTotalPerAnteriorCodAglutinacao { get; set; }
        public string IndicadorSitVrPerAnteriorInformado { get; set; } = null;
        // fim layout 8
        /// <summary>
        /// Entenda esta campo como saldo final, a partir do Layout 7.00 considerado antes do encerramento
        /// </summary>
        public double? VrTotalCodAglutinacao { get; set; }
        public string IndicadorSitVrInformado { get; set; } = null;
        public string IndicadorGrupoDRE { get; set; } = null;
        /// <summary>
        /// Utilizado apenas até o layout 6.00
        /// </summary>
        public double? VrSaldoFinalAntesEncerr { get; set; }
        /// <summary>
        /// Utilizado apenas até o layout 6.00
        /// </summary>
        public string IndicadorSitVrInformadoSaldo { get; set; } = null;
        public string NotaExplicativa { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|J150|");
            if (Conversions.ToInteger(Versao) / 100d >= 8d)
                writer.Append(NumeroOrdem + "|");
            writer.Append(CodAglutinacao + "|");
            if (Conversions.ToInteger(Versao) / 100d >= 7d)
                writer.Append(IndicadorCodAglutinacao + "|");
            writer.Append(NivelCodAglutinacao + "|");
            if (Conversions.ToInteger(Versao) / 100d >= 7d)
                writer.Append(CodAglutinacaoSuperior + "|");
            writer.Append(DescCodAglutinacao.TrimStart() + "|");
            if (Conversions.ToInteger(Versao) / 100d >= 8d)
            {
                writer.Append(string.Format("{0:F2}", VrTotalPerAnteriorCodAglutinacao) + "|");
                writer.Append(IndicadorSitVrPerAnteriorInformado + "|");
            }

            writer.Append(string.Format("{0:F2}", VrTotalCodAglutinacao) + "|");
            writer.Append(IndicadorSitVrInformado + "|");
            if (Conversions.ToInteger(Versao) / 100d >= 7d)
                writer.Append(IndicadorGrupoDRE + "|");
            if (Conversions.ToInteger(Versao) / 100d < 7d)
            {
                writer.Append(string.Format("{0:F2}", VrSaldoFinalAntesEncerr) + "|");
                writer.Append(IndicadorSitVrInformadoSaldo + "|");
            }

            writer.Append(NotaExplicativa + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            if (Conversions.ToInteger(Versao) / 100d >= 8d)
            {
                NumeroOrdem = data[2].ToNullableInteger() ?? 0;
                CodAglutinacao = data[3];
                IndicadorCodAglutinacao = data[4];
                NivelCodAglutinacao = data[5];
                CodAglutinacaoSuperior = data[6];
                DescCodAglutinacao = data[7];
                VrTotalPerAnteriorCodAglutinacao = data[8].ToNullableDouble();
                IndicadorSitVrPerAnteriorInformado = data[9];
                VrTotalCodAglutinacao = data[10].ToNullableDouble();
                IndicadorSitVrInformado = data[11];
                IndicadorGrupoDRE = data[12];
                NotaExplicativa = data[13];
            }
            else if (Conversions.ToInteger(Versao) / 100d >= 7d)
            {
                CodAglutinacao = data[2];
                IndicadorCodAglutinacao = data[3];
                NivelCodAglutinacao = data[4];
                CodAglutinacaoSuperior = data[5];
                DescCodAglutinacao = data[6];
                VrTotalCodAglutinacao = data[7].ToNullableDouble();
                IndicadorSitVrInformado = data[8];
                IndicadorGrupoDRE = data[9];
                NotaExplicativa = data[10];
            }
            else
            {
                CodAglutinacao = data[2];
                NivelCodAglutinacao = data[3];
                DescCodAglutinacao = data[4];
                VrTotalCodAglutinacao = data[5].ToNullableDouble();
                IndicadorSitVrInformado = data[6];
                VrSaldoFinalAntesEncerr = data[7].ToNullableDouble();
                IndicadorSitVrInformadoSaldo = data[8];
            }
        }
    }
}