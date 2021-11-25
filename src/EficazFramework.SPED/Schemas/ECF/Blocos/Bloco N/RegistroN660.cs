
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Apuração da CSLL Mensal por Estimativa
    /// </summary>
    /// <remarks></remarks>

    public class RegistroN660 : Primitives.Registro
    {
        public RegistroN660() : base("N660")
        {
        }

        public RegistroN660(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CodigoReferencial { get; set; } = null;
        public string Descricao { get; set; } = null;
        public double? Valor { get; set; } = default;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|N660|");
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