using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Analíticos (Energia Elétrica / Gás)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC590 : Primitives.Registro
    {
        public RegistroC590() : base("C590")
        {
        }

        public RegistroC590(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C590|"); // 1
            writer.Append(((int)Origem).ToString() + string.Format("{0:00}", (int)CST_ICMS) + "|"); // 2
            writer.Append(CFOP + "|"); // 3
            writer.Append(string.Format("{0:0.##}", AliquotaICMS) + "|"); // 4
            writer.Append(string.Format("{0:0.##}", ValorOperacao) + "|"); // 5
            writer.Append(string.Format("{0:0.##}", ValorBaseCalculoICMS) + "|"); // 6
            writer.Append(string.Format("{0:0.##}", ValorICMS) + "|"); // 7
            writer.Append(string.Format("{0:0.##}", ValorBaseCalculoICMSST) + "|"); // 8
            writer.Append(string.Format("{0:0.##}", ValorICMSST) + "|"); // 9
            writer.Append(string.Format("{0:0.##}", ValorReducaoBC) + "|"); // 10
            writer.Append(CodigoObservacao0460 + "|"); // 11
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Origem = (NFe.OrigemMercadoria)data[2].Substring(0, 1).ToEnum<NFe.OrigemMercadoria>(NFe.OrigemMercadoria.Nacional);
            CST_ICMS = (NFe.CST_ICMS)data[2].Substring(1, 2).ToEnum<NFe.CST_ICMS>(NFe.CST_ICMS.CST_00);
            CFOP = data[3];
            AliquotaICMS = data[4].ToNullableDouble();
            ValorOperacao = data[5].ToNullableDouble();
            ValorBaseCalculoICMS = data[6].ToNullableDouble();
            ValorICMS = data[7].ToNullableDouble();
            ValorBaseCalculoICMSST = data[8].ToNullableDouble();
            ValorICMSST = data[9].ToNullableDouble();
            ValorReducaoBC = data[10].ToNullableDouble();
            CodigoObservacao0460 = data[11];
        }

        public NFe.OrigemMercadoria Origem { get; set; } = NFe.OrigemMercadoria.Nacional; // 2
        public NFe.CST_ICMS CST_ICMS { get; set; } = NFe.CST_ICMS.CST_00; // 2
        public string CFOP { get; set; } = null; // 3
        public double? AliquotaICMS { get; set; } = default; // 4
        public double? ValorOperacao { get; set; } = default; // 5
        public double? ValorBaseCalculoICMS { get; set; } = default; // 6
        public double? ValorICMS { get; set; } = default; // 7
        public double? ValorBaseCalculoICMSST { get; set; } = default; // 8
        public double? ValorICMSST { get; set; } = default; // 9
        public double? ValorReducaoBC { get; set; } = default; // 10
        public string CodigoObservacao0460 { get; set; } = null; // 11
    }
}