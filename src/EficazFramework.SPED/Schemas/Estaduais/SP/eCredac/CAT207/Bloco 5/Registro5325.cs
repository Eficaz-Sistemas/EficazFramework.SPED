
namespace EficazFramework.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Operações Geradoras de Crédito Acumulado
    /// </summary>
    /// <remarks></remarks>
    public class Registro5325 : Primitives.Registro
    {
        public int? EnquadramentoLegal { get; set; } = default;
        public double? IVA { get; set; } = default;
        public double? PMC { get; set; } = default;
        public double? CreditoEstimado { get; set; } = default;
        public double? CreditoAcumulado { get; set; } = default;

        public Registro5325() : base("5325")
        {
        }

        public Registro5325(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("5325|");
            writer.Append(string.Format("{0:0000}", EnquadramentoLegal) + "|");
            writer.Append(string.Format("{0:F4}", IVA) + "|");
            writer.Append(string.Format("{0:F4}", PMC) + "|");
            writer.Append(string.Format("{0:F2}", CreditoEstimado) + "|");
            writer.Append(string.Format("{0:F2}", CreditoAcumulado));
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}