
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Outras Informações (Lucro Real)
    /// </summary>
    public class RegistroY672 : Primitives.Registro
    {
        public RegistroY672() : base("Y672")
        {
        }

        public RegistroY672(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public double? CapitalSocial_Anterior { get; set; } = default;
        public double? CapitalSocial { get; set; } = default;
        public double? Estoque_Anterior { get; set; } = default;
        public double? Estoque { get; set; } = default;
        public double? CaixaBancos_Anterior { get; set; } = default;
        public double? CaixaBancos { get; set; } = default;
        public double? AplicacoesFinanceiras_Anterior { get; set; } = default;
        public double? AplicacoesFinanceiras { get; set; } = default;
        public double? ContasReceber_Anterior { get; set; } = default;
        public double? ContasReceber { get; set; } = default;
        public double? ContasPagar_Anterior { get; set; } = default;
        public double? ContasPagar { get; set; } = default;
        public double? CompraMercadorias { get; set; } = default;
        public double? CompraAtivo { get; set; } = default;
        public double? ReceitasNaoTributaveisOuExclusivFonte { get; set; } = default;
        public double? TotalAtivo { get; set; } = default;
        public double? ValorFolhaPagtoAliqReduzica { get; set; } = default;
        public double? AliquotaReduzidaFolhaPagto { get; set; } = default;
        public MetodoAvEstoque AvaliacaoEstoque { get; set; } = MetodoAvEstoque.CustoMedioPonderado;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|Y672|"); // 1
            writer.Append(string.Format("{0:F2}", CapitalSocial_Anterior) + "|"); // 2
            writer.Append(string.Format("{0:F2}", CapitalSocial) + "|"); // 3
            writer.Append(string.Format("{0:F2}", Estoque_Anterior) + "|"); // 4
            writer.Append(string.Format("{0:F2}", Estoque) + "|"); // 5
            writer.Append(string.Format("{0:F2}", CaixaBancos_Anterior) + "|"); // 6
            writer.Append(string.Format("{0:F2}", CaixaBancos) + "|"); // 7
            writer.Append(string.Format("{0:F2}", AplicacoesFinanceiras_Anterior) + "|"); // 8
            writer.Append(string.Format("{0:F2}", AplicacoesFinanceiras) + "|"); // 9
            writer.Append(string.Format("{0:F2}", ContasReceber_Anterior) + "|"); // 10
            writer.Append(string.Format("{0:F2}", ContasReceber) + "|"); // 11         
            writer.Append(string.Format("{0:F2}", ContasPagar_Anterior) + "|"); // 12
            writer.Append(string.Format("{0:F2}", ContasPagar) + "|"); // 13
            writer.Append(string.Format("{0:F2}", CompraMercadorias) + "|"); // 14
            writer.Append(string.Format("{0:F2}", CompraAtivo) + "|"); // 15
            writer.Append(string.Format("{0:F2}", ReceitasNaoTributaveisOuExclusivFonte) + "|"); // 16
            writer.Append(string.Format("{0:F2}", TotalAtivo) + "|"); // 17
            writer.Append(string.Format("{0:F2}", ValorFolhaPagtoAliqReduzica) + "|"); // 18
            writer.Append(string.Format("{0:F4}", AliquotaReduzidaFolhaPagto) + "|"); // 19
            writer.Append((int)AvaliacaoEstoque + "|"); // 20
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}