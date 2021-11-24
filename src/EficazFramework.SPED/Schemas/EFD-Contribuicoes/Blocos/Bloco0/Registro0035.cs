
namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Identificação de Sociedade em Conta de Participação - SCP
    /// </summary>
    /// <remarks></remarks>

    public class Registro0035 : Primitives.Registro
    {
        public Registro0035() : base("0035")
        {
        }

        public Registro0035(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string IdentificacaoSCP { get; set; } = null; // tamanho 14'
        public string DescricaoSCP { get; set; } = null;
        public string InformacaoComplementar { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0035|");
            writer.Append(IdentificacaoSCP + "|");
            writer.Append(DescricaoSCP + "|");
            writer.Append(InformacaoComplementar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IdentificacaoSCP = data[2];
            DescricaoSCP = data[3];
            InformacaoComplementar = data[4];
        }
    }
}