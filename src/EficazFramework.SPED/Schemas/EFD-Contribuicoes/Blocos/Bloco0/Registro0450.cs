
namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Tabela de Informação Complementar do Documento Fiscal
    /// </summary>
    /// <remarks></remarks>

    public class Registro0450 : Primitives.Registro
    {
        public Registro0450() : base("0450")
        {
        }

        public Registro0450(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoComplementarDocumentoFiscal { get; set; } = null; // tamanho 6'
        public string TextoComplementarDocFiscal { get; set; } = null; // livre'

        public override string EscreveLinha()
        {
            var writer = new global::System.Text.StringBuilder();
            writer.Append("|0450|");
            writer.Append(CodigoComplementarDocumentoFiscal + "|");
            writer.Append(TextoComplementarDocFiscal + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoComplementarDocumentoFiscal = data[2];
            TextoComplementarDocFiscal = data[3];
        }
    }
}