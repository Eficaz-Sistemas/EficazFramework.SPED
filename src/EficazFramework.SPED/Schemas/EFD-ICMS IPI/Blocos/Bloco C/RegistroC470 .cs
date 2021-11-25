using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Itens do Documento Fiscal 2D
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC470 : Primitives.Registro
    {
        public RegistroC470() : base("C470")
        {
        }

        public RegistroC470(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C470|"); // 1
            writer.Append(Produto + "|"); // 2
            writer.Append(string.Format("{0:0.###}", QuantidadeBruto) + "|"); // 3
            writer.Append(string.Format("{0:0.###}", QuantidadeCancelada) + "|"); // 4
            writer.Append(Unidade + "|"); // 5
            writer.Append(string.Format("{0:0.##}", ValorLiquidoItem) + "|"); // 6
            writer.Append(((int)Origem).ToString() + string.Format("{0:00}", (int)CST_ICMS) + "|"); // 7
            writer.Append(CFOP + "|"); // 8
            writer.Append(string.Format("{0:0.##}", Aliquota_ICMS) + "|"); // 9
            writer.Append(string.Format("{0:0.##}", PIS) + "|"); // 10
            writer.Append(string.Format("{0:0.##}", COFINS) + "|"); // 11
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Produto = data[2];
            QuantidadeBruto = data[3].ToNullableDouble();
            QuantidadeCancelada = data[4].ToNullableDouble();
            Unidade = data[5];
            ValorLiquidoItem = data[6].ToNullableDouble();
            Origem = (NFe.OrigemMercadoria)data[7][..1].ToEnum<NFe.OrigemMercadoria>(NFe.OrigemMercadoria.Nacional);
            CST_ICMS = (NFe.CST_ICMS)data[7].Substring(1, 2).ToEnum<NFe.CST_ICMS>(NFe.CST_ICMS.CST_00);
            CFOP = data[8];
            Aliquota_ICMS = data[9].ToNullableDouble();
            PIS = data[10].ToNullableDouble();
            COFINS = data[11].ToNullableDouble();
        }

        public string Produto { get; set; } = null; // 2
        public double? QuantidadeBruto { get; set; } = default; // 3
        public double? QuantidadeCancelada { get; set; } = default; // 4
        public string Unidade { get; set; } = null; // 5
        public double? ValorLiquidoItem { get; set; } = default; // 6
        public NFe.OrigemMercadoria Origem { get; set; } = NFe.OrigemMercadoria.Nacional; // 7
        public NFe.CST_ICMS CST_ICMS { get; set; } = NFe.CST_ICMS.CST_00; // 7
        public string CFOP { get; set; } = null; // 8
        public double? Aliquota_ICMS { get; set; } // 9
        public double? PIS { get; set; } = default; // 10
        public double? COFINS { get; set; } = default; // 11
    }
}