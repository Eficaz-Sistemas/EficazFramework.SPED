
namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Identificação das SCP
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
        public string IdentificacaoSCPCNPJ { get; set; } = null;
        public string NomeSCP { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0035|");
            writer.Append(IdentificacaoSCPCNPJ + "|");
            writer.Append(NomeSCP + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IdentificacaoSCPCNPJ = data[2];
            NomeSCP = data[3];
        }
    }
}