
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Demonstrativo do Imposto de Renda e CSLL Retidos na Fonte
    /// </summary>
    public class RegistroY550 : Primitives.Registro
    {
        public RegistroY550() : base("Y570")
        {
        }

        public RegistroY550(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CNPJ_FontePagadora { get; set; } = null;
        public string NomeEmpresarial { get; set; } = null;
        public bool IndicadorOrgaoPublico { get; set; } = false;
        public string CodigoRecolhimento { get; set; } = null;
        public double? RendimentoBruto { get; set; } = default;
        public double? IR_Retido { get; set; } = default;
        public double? CSLL_Retida { get; set; } = default;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|Y570|"); // 1
            writer.Append(CNPJ_FontePagadora + "|"); // 2
            writer.Append(NomeEmpresarial + "|"); // 3
            if (IndicadorOrgaoPublico)
                writer.Append("S|");
            else
                writer.Append("N|"); // 4
            writer.Append(CodigoRecolhimento + "|"); // 5
            writer.Append(string.Format("{0:F2}", RendimentoBruto) + "|"); // 6
            writer.Append(string.Format("{0:F2}", IR_Retido) + "|"); // 7
            writer.Append(string.Format("{0:F2}", CSLL_Retida) + "|"); // 8
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}