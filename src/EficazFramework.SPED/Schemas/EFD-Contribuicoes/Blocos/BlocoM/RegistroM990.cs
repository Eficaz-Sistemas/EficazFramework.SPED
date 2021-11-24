
namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Encerramento do BlocoM
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM990 : Primitives.Registro
    {
        public RegistroM990() : base("M990")
        {
        }

        public RegistroM990(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string QuantidadeLinhasBlocoM { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M990|");
            writer.Append(QuantidadeLinhasBlocoM + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            QuantidadeLinhasBlocoM = data[2];
        }
    }
}