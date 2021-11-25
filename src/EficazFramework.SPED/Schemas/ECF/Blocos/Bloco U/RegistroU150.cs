
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Demonstração do Resultado
    /// </summary>
    /// <remarks></remarks>

    public class RegistroU150 : Primitives.Registro
    {
        public RegistroU150() : base("U150")
        {
        }

        public RegistroU150(string linha, string versao) : base(linha, versao)
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
        public double? Valor { get; set; } = default;
        /// <summary>
        /// D - Devedor
        /// C - Credor
        /// </summary>
        /// <returns></returns>
        public string NaturezaSaldoInicial { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|U150|");
            writer.Append(CodigoReferencial + "|");
            writer.Append(Descricao + "|");
            writer.Append(TipoConta + "|");
            writer.Append(Nivel + "|");
            writer.Append((int)Natureza + "|");
            writer.Append(ContaSuperior + "|");
            writer.Append(string.Format("{0:F2}", Valor) + "|");
            writer.Append(NaturezaSaldoInicial + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}