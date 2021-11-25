
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Identificação e Remuneração de Sócios, Titulares, Dirigentes e Conselheiros
    /// </summary>
    public class RegistroY612 : Primitives.Registro
    {
        public RegistroY612() : base("Y612")
        {
        }

        public RegistroY612(string linha, string versao) : base(linha, versao)
        {
        }

        public string CPF { get; set; } = null;
        public string Nome { get; set; } = null;
        public string Qualificacao { get; set; } = null;
        public double? ValorRemuneracao { get; set; } = default;
        public double? ValorDemaisRendimentos { get; set; } = default;
        public double? ValorIR_Retido { get; set; } = default;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|Y612|"); // 1
            writer.Append(CPF + "|"); // 6
            writer.Append(Nome + "|"); // 7
            writer.Append(Qualificacao + "|"); // 8
            writer.Append(string.Format("{0:F2}", ValorRemuneracao) + "|"); // 13
            writer.Append(string.Format("{0:F2}", ValorDemaisRendimentos) + "|"); // 16
            writer.Append(string.Format("{0:F2}", ValorIR_Retido) + "|"); // 17
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}