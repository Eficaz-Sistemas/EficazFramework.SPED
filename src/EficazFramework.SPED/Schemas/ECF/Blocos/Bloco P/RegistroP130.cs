
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Demonstração das Receitas Incentivadas do Lucro Presumido
    /// </summary>
    /// <remarks></remarks>

    public class RegistroP130 : Primitives.Registro
    {
        public RegistroP130() : base("P130")
        {
        }

        public RegistroP130(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CodigoReferencial { get; set; } = null;
        public string Descricao { get; set; } = null;
        public double? Valor { get; set; } = default;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|P130|");
            writer.Append(CodigoReferencial + "|");
            writer.Append(Descricao + "|");
            writer.Append(string.Format("{0:F2}", Valor) + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}