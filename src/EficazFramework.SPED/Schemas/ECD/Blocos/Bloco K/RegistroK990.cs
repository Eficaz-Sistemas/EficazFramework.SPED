
namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Encerramento do Bloco K
    /// </summary>
    /// <remarks></remarks>

    public class RegistroK990 : Primitives.Registro
    {
        public RegistroK990() : base("K990")
        {
        }

        public RegistroK990(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string QuantidadeLinhasBlocoK { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|K990|");
            writer.Append(QuantidadeLinhasBlocoK + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            QuantidadeLinhasBlocoK = data[2];
        }
    }
}