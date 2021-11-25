
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Encerramento do Bloco M
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM990 : Primitives.Registro
    {
        public RegistroM990() : base("M990")
        {
        }

        public RegistroM990(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string QuantidadeLinhasBlocoK { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M990|");
            writer.Append(QuantidadeLinhasBlocoK + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            QuantidadeLinhasBlocoK = data[2];
        }
    }
}