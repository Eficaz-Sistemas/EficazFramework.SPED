using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Resumo de Itens do Movimento Diário (Código 02, 2D)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC425 : Primitives.Registro
    {
        public RegistroC425() : base("C425")
        {
        }

        public RegistroC425(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C425|"); // 1
            writer.Append(Produto + "|"); // 2
            writer.Append(string.Format("{0:0.###}", Quantidade) + "|"); // 3
            writer.Append(Unidade + "|"); // 4
            writer.Append(string.Format("{0:0.##}", ValorItem) + "|"); // 5
            writer.Append(string.Format("{0:0.##}", PIS) + "|"); // 6
            writer.Append(string.Format("{0:0.##}", COFINS) + "|"); // 7
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Produto = data[2];
            Quantidade = (double)data[3].ToNullableDouble();
            Unidade = data[4];
            ValorItem = data[5].ToNullableDouble();
            PIS = data[6].ToNullableDouble();
            COFINS = data[7].ToNullableDouble();
        }

        public string Produto { get; set; } = null; // 2
        public double Quantidade { get; set; } = default; // 3
        public string Unidade { get; set; } = null; // 4
        public double? ValorItem { get; set; } = default; // 5
        public double? PIS { get; set; } = default; // 6
        public double? COFINS { get; set; } = default; // 7
    }
}