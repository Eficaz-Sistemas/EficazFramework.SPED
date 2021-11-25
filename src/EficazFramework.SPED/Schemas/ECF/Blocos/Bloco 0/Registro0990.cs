
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Encerramento do Bloco 0
    /// </summary>
    /// <remarks></remarks>

    public class Registro0990 : Primitives.Registro
    {
        public Registro0990() : base("0990")
        {
        }

        public Registro0990(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string QuantidadeLinhasBloco0 { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0990|");
            writer.Append(QuantidadeLinhasBloco0 + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            QuantidadeLinhasBloco0 = data[2];
        }
    }
}