
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{


    /// <summary>
    /// Código de Produto Conforme Tabela ANP(Combustíveis)
    /// </summary>
    /// <remarks></remarks>

    public class Registro0206 : Primitives.Registro
    {
        public Registro0206() : base("0206")
        {
        }

        public Registro0206(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoCombustivelANP { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0206|");
            writer.Append(CodigoCombustivelANP + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoCombustivelANP = data[2];
        }
    }
}