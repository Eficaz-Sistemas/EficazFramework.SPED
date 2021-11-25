
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Encerramento do Bloco U
    /// </summary>
    /// <remarks></remarks>

    public class RegistroU990 : Primitives.Registro
    {
        public RegistroU990() : base("U990")
        {
        }

        public RegistroU990(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string QuantidadeLinhasBlocoK { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|U990|");
            writer.Append(QuantidadeLinhasBlocoK + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            QuantidadeLinhasBlocoK = data[2];
        }
    }
}