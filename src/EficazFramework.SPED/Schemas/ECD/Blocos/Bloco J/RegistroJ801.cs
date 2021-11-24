
namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Termo de Verificação para Fins de Substituição da ECD
    /// </summary>
    /// <remarks></remarks>

    public class RegistroJ801 : Primitives.Registro
    {
        public RegistroJ801() : base("J801")
        {
        }

        // Campos'
        public string TipoDoc { get; set; } = null;
        public string DescricaoArquivoRTF { get; set; } = null;
        public string HashArquivoRTF { get; set; } = null;
        public string SequenciaBytesArquitoRTF { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|J801|");
            writer.Append(TipoDoc + "|");
            writer.Append(DescricaoArquivoRTF + "|");
            writer.Append(HashArquivoRTF + "|");
            writer.Append(SequenciaBytesArquitoRTF + "|");
            writer.Append("|J801FIM|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            TipoDoc = data[2];
            DescricaoArquivoRTF = data[3];
            HashArquivoRTF = data[4];
            SequenciaBytesArquitoRTF = data[5];
        }
    }
}