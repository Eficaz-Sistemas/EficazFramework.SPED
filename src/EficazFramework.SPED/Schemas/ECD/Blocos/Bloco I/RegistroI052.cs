
namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Indicação dos Códigos de Aglutinação
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI052 : Primitives.Registro
    {
        public RegistroI052() : base("I052")
        {
        }

        public RegistroI052(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodCentroCusto { get; set; } = null;
        public string CodAglutinacaoUtilzBalanco { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new global::System.Text.StringBuilder();
            writer.Append("|I052|");
            writer.Append(CodCentroCusto + "|");
            writer.Append(CodAglutinacaoUtilzBalanco + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodCentroCusto = data[2];
            CodAglutinacaoUtilzBalanco = data[3];
        }
    }
}