
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Encerramento do BlocoC
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC990 : Primitives.Registro
    {
        public RegistroC990() : base("C990")
        {
        }

        public RegistroC990(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string QuantidadeLinhasBlocoC { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C990|");
            writer.Append(QuantidadeLinhasBlocoC + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            QuantidadeLinhasBlocoC = data[2];
        }
    }
}