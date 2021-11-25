
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Apuração da CSLL Com Base no Lucro Real
    /// </summary>
    /// <remarks></remarks>

    public class RegistroN670 : Primitives.Registro
    {
        public RegistroN670() : base("N670")
        {
        }

        public RegistroN670(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CodigoReferencial { get; set; } = null;
        public string Descricao { get; set; } = null;
        public double? Valor { get; set; } = default;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|N670|");
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