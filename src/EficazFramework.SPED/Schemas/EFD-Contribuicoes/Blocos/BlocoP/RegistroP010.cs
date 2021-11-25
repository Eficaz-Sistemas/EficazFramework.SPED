
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Identificação da pessoa jurídica estabelecimento
    /// </summary>
    /// <remarks></remarks>

    public class RegistroP010 : Primitives.Registro
    {
        public RegistroP010() : base("P010")
        {
        }

        public RegistroP010(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CNPJ { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|P010|");
            writer.Append(CNPJ + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CNPJ = data[2];
        }
    }
}