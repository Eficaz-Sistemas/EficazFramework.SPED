
namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Encerramento do Bloco J
    /// </summary>
    /// <remarks></remarks>

    public class RegistroJ990 : Primitives.Registro
    {
        public RegistroJ990() : base("J990")
        {
        }

        public RegistroJ990(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string QuantidadeLinhasBlocoJ { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|J990|");
            writer.Append(QuantidadeLinhasBlocoJ + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            QuantidadeLinhasBlocoJ = data[2];
        }
    }
}