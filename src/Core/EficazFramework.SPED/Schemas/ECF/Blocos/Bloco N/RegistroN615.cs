
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Informações da Base de Cálculo dos Incentivos Fiscais
/// </summary>
/// <remarks></remarks>

public class RegistroN615 : Primitives.Registro
{
    public RegistroN615() : base("N615")
    {
    }

    public RegistroN615(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public double? BaseCalculoIncentivosFiscais { get; set; } = default;
    public double? PercentualIncentivoFINOR { get; set; } = default;
    public double ValorLiquidoFINOR { get; set; } = default;
    public double? PercentualFINAM { get; set; } = default;
    public double? ValorLiquidoFINAM { get; set; } = default;
    public double? TotalIncentivos { get; set; } = default;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|N615|");
        writer.Append(string.Format("{0:F2}", BaseCalculoIncentivosFiscais) + "|");
        writer.Append(string.Format("{0:F4}", PercentualIncentivoFINOR) + "|");
        writer.Append(string.Format("{0:F2}", ValorLiquidoFINOR) + "|");
        writer.Append(string.Format("{0:F4}", PercentualFINAM) + "|");
        writer.Append(string.Format("{0:F2}", ValorLiquidoFINAM) + "|");
        writer.Append(string.Format("{0:F2}", TotalIncentivos) + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
