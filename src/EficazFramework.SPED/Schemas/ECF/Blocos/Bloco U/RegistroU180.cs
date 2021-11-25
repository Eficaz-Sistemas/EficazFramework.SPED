
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Cálculo do IRPJ das Empresas Imunes e Isentas
    /// </summary>
    /// <remarks></remarks>

    public class RegistroU180 : Primitives.Registro
    {
        public RegistroU180() : base("U180")
        {
        }

        public RegistroU180(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CodigoReferencial { get; set; } = null;
        public string Descricao { get; set; } = null;
        public double? Valor { get; set; } = default;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|U180|");
            writer.Append(CodigoReferencial + "|");
            writer.Append(Descricao + "|");
            writer.Append(string.Format("{0:F2}", Valor) + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}