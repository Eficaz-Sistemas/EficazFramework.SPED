
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Identificação das Unidades de Medida
    /// </summary>
    /// <remarks></remarks>

    public class Registro0190 : Primitives.Registro
    {
        public Registro0190() : base("0190")
        {
        }

        public Registro0190(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoUnidadeMedida { get; set; } = null; // Tamanho 6'
        public string DescricaoUnidadeMedida { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0190|");
            writer.Append(CodigoUnidadeMedida + "|");
            writer.Append(DescricaoUnidadeMedida + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoUnidadeMedida = data[2];
            DescricaoUnidadeMedida = data[3];
        }
    }
}