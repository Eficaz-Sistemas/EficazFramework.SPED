
namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Identificação das Contas da Escrituração Resumida a que se Refere a Escrituração Auxiliar
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI015 : Primitives.Registro
    {
        public RegistroI015() : base("I015")
        {
        }

        public RegistroI015(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoContaResumida { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I015|");
            writer.Append(CodigoContaResumida + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoContaResumida = data[2];
        }
    }
}