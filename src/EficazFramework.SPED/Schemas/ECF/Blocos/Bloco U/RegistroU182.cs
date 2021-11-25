
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Cálculo da Contribuição Social sobre o Lucro Líquido (CSLL) das Empresas Imunes e Isentas
    /// </summary>
    /// <remarks></remarks>

    public class RegistroU182 : Primitives.Registro
    {
        public RegistroU182() : base("U182")
        {
        }

        public RegistroU182(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CodigoReferencial { get; set; } = null;
        public string Descricao { get; set; } = null;
        public double? Valor { get; set; } = default;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|U182|");
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