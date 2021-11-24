
namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Outras Informações
    /// </summary>
    /// <remarks></remarks>

    public class RegistroJ800 : Primitives.Registro
    {
        public RegistroJ800() : base("J800")
        {
        }

        // Campos'
        public string SequenciaBytesArquitoRTF { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|J800|");
            writer.Append(SequenciaBytesArquitoRTF + "|");
            writer.Append("|J800FIM|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            SequenciaBytesArquitoRTF = data[2];
        }
    }
}