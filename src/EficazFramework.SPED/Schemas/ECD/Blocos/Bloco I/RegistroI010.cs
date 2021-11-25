
namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Identificação da Escrituração Contábil
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI010 : Primitives.Registro
    {
        public RegistroI010() : base("I010")
        {
        }

        public RegistroI010(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string IndicadorFormaEscritContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I010|");
            writer.Append(IndicadorFormaEscritContabil + "|");
            writer.Append(Versao + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorFormaEscritContabil = data[2];
        }
    }
}