
namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Identificação do Estabelecimento
    /// </summary>
    /// <remarks></remarks>

    public class RegistroF010 : Primitives.Registro
    {
        public RegistroF010() : base("F010")
        {
        }

        public RegistroF010(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string NumeroInscricaoEstabelecimentoCNPJ { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|F010|");
            writer.Append(NumeroInscricaoEstabelecimentoCNPJ + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroInscricaoEstabelecimentoCNPJ = data[2];
        }
    }
}