
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Vendas a Comercial Exportadora com Fim Específico de Exportação
    /// </summary>
    /// <remarks></remarks>
    public class RegistroY570 : Primitives.Registro
    {
        public RegistroY570() : base("Y550")
        {
        }

        public RegistroY570(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CNPJ_Exportadora { get; set; }
        public string NCM { get; set; }
        public double? ValorVenda { get; set; } = default;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|Y550|"); // 1
            writer.Append(CNPJ_Exportadora + "|"); // 2
            writer.Append(NCM + "|"); // 3
            writer.Append(string.Format("{0:F2}", ValorVenda) + "|"); // 3
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}