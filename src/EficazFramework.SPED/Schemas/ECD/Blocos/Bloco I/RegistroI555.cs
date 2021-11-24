using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Totais no Livro Razão Auxiliar com Leiaute Parametrizável
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI555 : Primitives.Registro
    {
        public RegistroI555() : base("I555")
        {
        }

        public RegistroI555(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodProduto { get; set; } = null;
        public string DescricaoProduto { get; set; } = null;
        public double? QtdeProduto { get; set; }
        public double? VrUnitario { get; set; }
        public double? VrTotal { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I555|");
            writer.Append(CodProduto + "|");
            writer.Append(DescricaoProduto + "|");
            writer.Append(QtdeProduto + "|");
            writer.Append(VrUnitario + "|");
            writer.Append(VrTotal + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodProduto = data[2];
            DescricaoProduto = data[3];
            QtdeProduto = data[4].ToNullableDouble();
            VrUnitario = data[5].ToNullableDouble();
            VrTotal = data[6].ToNullableDouble();
        }
    }
}