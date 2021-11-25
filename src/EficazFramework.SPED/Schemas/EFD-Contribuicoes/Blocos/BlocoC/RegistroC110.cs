
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento do Documento - Informação Complementar da Nota Fiscal
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC110 : Primitives.Registro
    {
        public RegistroC110() : base("C110")
        {
        }

        public RegistroC110(string linha, string versao) : base(linha, versao)
        {
        }

        // campos'
        public string CodigoInformacaoComplementas { get; set; } = null;
        public string DescricaoComplementarCodRef { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C110|");
            writer.Append(CodigoInformacaoComplementas + "|");
            writer.Append(DescricaoComplementarCodRef + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoInformacaoComplementas = data[2];
            DescricaoComplementarCodRef = data[3];
        }
    }
}