using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Balanço Patrimonial
    /// </summary>
    /// <remarks></remarks>

    public class RegistroU100 : Primitives.Registro
    {
        public RegistroU100() : base("U100")
        {
        }

        public RegistroU100(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CodigoReferencial { get; set; } = null;
        public string Descricao { get; set; } = null;
        /// <summary>
        /// S - Sintética
        /// A - Analitica
        /// </summary>
        /// <returns></returns>
        public string TipoConta { get; set; } = null;
        public int Nivel { get; set; } = 0;
        public ECD.TipoConta Natureza { get; set; } = ECD.TipoConta.Ativo;
        public string ContaSuperior { get; set; } = null;
        public double? SaldoInicial { get; set; } = default;
        /// <summary>
        /// D - Devedor
        /// C - Credor
        /// </summary>
        /// <returns></returns>
        public string NaturezaSaldoInicial { get; set; } = null;
        public double? Debitos { get; set; } = default;
        public double? Creditos { get; set; } = default;
        public double? SaldoFinal { get; set; } = default;
        /// <summary>
        /// D - Devedor
        /// C - Credor
        /// </summary>
        /// <returns></returns>
        public string NaturezaSaldoFinal { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|U100|");
            writer.Append(CodigoReferencial + "|");
            writer.Append(Descricao + "|");
            writer.Append(TipoConta + "|");
            writer.Append(Nivel + "|");
            writer.Append((int)Natureza + "|");
            writer.Append(ContaSuperior + "|");
            writer.Append(string.Format("{0:F2}", SaldoInicial) + "|");
            writer.Append(NaturezaSaldoInicial + "|");
            if (Conversions.ToBoolean(Conversions.ToInteger(Conversions.ToDouble(Versao) >= 5d)))
            {
                writer.Append(string.Format("{0:F2}", Debitos) + "|");
                writer.Append(string.Format("{0:F2}", Creditos) + "|");
            }

            writer.Append(string.Format("{0:F2}", SaldoFinal) + "|");
            writer.Append(NaturezaSaldoFinal + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}