
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Base de Cálculo da CSLL Após as Compensações da Base de Cálculo Negativa
    /// </summary>
    /// <remarks></remarks>

    public class RegistroN650 : Primitives.Registro
    {
        public RegistroN650() : base("N650")
        {
        }

        public RegistroN650(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CodigoReferencial { get; set; } = null;
        public string Descricao { get; set; } = null;
        public double? Valor { get; set; } = default;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|N650|");
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