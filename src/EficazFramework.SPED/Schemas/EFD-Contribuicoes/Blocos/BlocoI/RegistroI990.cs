
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Encerramento do BlocoI
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI990 : Primitives.Registro
    {
        public RegistroI990() : base("I990")
        {
        }

        public RegistroI990(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string QuantidadeLinhasBlocoI { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I990|");
            writer.Append(QuantidadeLinhasBlocoI + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            QuantidadeLinhasBlocoI = data[2];
        }
    }
}