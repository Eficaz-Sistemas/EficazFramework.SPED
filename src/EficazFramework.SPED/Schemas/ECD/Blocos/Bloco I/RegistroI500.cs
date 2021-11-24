
namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Parâmetros de Impressão e Visualização do Livro Razão Auxiliar com Leiaute Parametrizável
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI500 : Primitives.Registro
    {
        public RegistroI500() : base("I500")
        {
        }

        public RegistroI500(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string TamanhoFonte { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I500|");
            writer.Append(TamanhoFonte + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            TamanhoFonte = data[2];
        }
    }
}