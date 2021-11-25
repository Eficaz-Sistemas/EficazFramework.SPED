
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Demonstração do Lucro da Exploração
    /// </summary>
    /// <remarks></remarks>

    public class RegistroN600 : Primitives.Registro
    {
        public RegistroN600() : base("N600")
        {
        }

        public RegistroN600(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CodigoReferencial { get; set; } = null;
        public string Descricao { get; set; } = null;
        public double? Valor { get; set; } = default;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|N600|");
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