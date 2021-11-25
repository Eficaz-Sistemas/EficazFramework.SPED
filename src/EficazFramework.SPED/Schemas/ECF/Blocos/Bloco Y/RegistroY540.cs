
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Discriminação da Receita de Vendas dos Estabelecimentos por Atividade Econômica
    /// </summary>
    /// <remarks></remarks>
    public class RegistroY540 : Primitives.Registro
    {
        public RegistroY540() : base("Y540")
        {
        }

        public RegistroY540(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CNPJEstabelecimento { get; set; }
        public double? ValorReceitas { get; set; } = default;
        public string CNAE { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|Y540|"); // 1
            writer.Append(CNPJEstabelecimento + "|"); // 2
            writer.Append(string.Format("{0:F2}", ValorReceitas) + "|"); // 3
            writer.Append(CNAE + "|"); // 4
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}