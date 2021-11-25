
namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Tabela de Histórico Padronizado
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI075 : Primitives.Registro
    {
        public RegistroI075() : base("I075")
        {
        }

        public RegistroI075(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodHistPadronizado { get; set; } = null;
        public string DescHistPadronizado { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I075|");
            writer.Append(CodHistPadronizado + "|");
            writer.Append(DescHistPadronizado + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodHistPadronizado = data[2];
            DescHistPadronizado = data[3];
        }
    }
}