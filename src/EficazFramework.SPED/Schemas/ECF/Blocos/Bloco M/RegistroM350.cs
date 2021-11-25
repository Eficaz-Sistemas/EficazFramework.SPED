
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Demonstração da Base de Cálculo da CSLL
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM350 : Primitives.Registro
    {
        public RegistroM350() : base("M350")
        {
        }

        public RegistroM350(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CodigoReferencial { get; set; } = null;
        public string Descricao { get; set; } = null;
        /// <summary>
        /// A- Adição
        /// E - Exclusão
        /// P - Compensação de Prejuízo
        /// L - Lucro
        /// </summary>
        public string TipoConta { get; set; } = null;
        /// <summary>
        /// 1 - Com Conta da Parte B
        /// 2 - Com Conta Contábil
        /// 3 – Com Conta da parte B e Conta Contábil
        /// 4 - Sem Relacionamento
        /// </summary>
        public string IndicadorRelacao { get; set; } = null;
        public double? Valor { get; set; } = default;
        public string Historico { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M350|");
            writer.Append(CodigoReferencial + "|");
            writer.Append(Descricao + "|");
            writer.Append(TipoConta + "|");
            writer.Append(IndicadorRelacao + "|");
            writer.Append(string.Format("{0:F2}", Valor) + "|");
            writer.Append(Historico + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}