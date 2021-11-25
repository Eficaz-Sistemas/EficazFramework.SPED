
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Encerramento do Bloco 1
    /// </summary>
    /// <remarks></remarks>

    public class Registro1990 : Primitives.Registro
    {
        public Registro1990() : base("1990")
        {
        }

        public Registro1990(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string QuantidadeLinhasBloco1 { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1990|");
            writer.Append(QuantidadeLinhasBloco1 + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            QuantidadeLinhasBloco1 = data[2];
        }
    }
}