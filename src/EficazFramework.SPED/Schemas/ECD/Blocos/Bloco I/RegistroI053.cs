
namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Subcontas Correlatas
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI053 : Primitives.Registro
    {
        public RegistroI053() : base("I053")
        {
        }

        public RegistroI053(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodIdentGrupoContaSubconta { get; set; } = null;
        public string CodSubcontaCorrelata { get; set; } = null;
        public string NaturezaSubcontaCorrelata { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I053|");
            writer.Append(CodIdentGrupoContaSubconta + "|");
            writer.Append(CodSubcontaCorrelata + "|");
            writer.Append(NaturezaSubcontaCorrelata + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodIdentGrupoContaSubconta = data[2];
            CodSubcontaCorrelata = data[3];
            NaturezaSubcontaCorrelata = data[4];
        }
    }
}