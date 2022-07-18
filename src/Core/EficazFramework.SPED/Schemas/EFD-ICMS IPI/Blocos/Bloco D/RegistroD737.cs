using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Outras obrigações tributárias, ajustes e informações de 
/// valores provenientes de documento fiscal.
/// </summary>
/// <remarks></remarks>
public class RegistroD737 : Primitives.Registro
{
    public RegistroD737() : base("D737")
    {
    }

    public RegistroD737(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D737|"); // 1
        writer.Append(CodigoAjusteBeneficio + "|"); // 02
        writer.Append(DescricaoAjusteBeneficio + "|"); // 03
        writer.Append(CodigoItem + "|"); // 04
        writer.Append(string.Format("{0:0.##}", ValorBaseCalculoICMS) + "|"); // 05
        writer.Append(string.Format("{0:0.##}", AliquotaICMS) + "|"); // 06
        writer.Append(string.Format("{0:0.##}", ValorICMS) + "|"); // 07
        writer.Append(string.Format("{0:0.##}", ValorOutros) + "|"); // 08
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoAjusteBeneficio = data[2];
        DescricaoAjusteBeneficio = data[3];
        CodigoItem = data[4];
        ValorBaseCalculoICMS = data[5].ToNullableDouble();
        AliquotaICMS = data[6].ToNullableDouble();
        ValorICMS = data[7].ToNullableDouble();
        ValorOutros = data[8].ToNullableDouble();
    }

    public string CodigoAjusteBeneficio { get; set; } = null; // 02
    public string DescricaoAjusteBeneficio { get; set; } = null; // 03
    public string CodigoItem { get; set; } = null; // 04
    public double? ValorBaseCalculoICMS { get; set; } = default; // 05
    public double? AliquotaICMS { get; set; } = default; // 06
    public double? ValorICMS { get; set; } = default; // 07
    public double? ValorOutros { get; set; } = default; // 08
}
