using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Abertura do Bloco B
/// </summary>
/// <remarks></remarks>

public class RegistroB420 : Primitives.Registro
{
    public RegistroB420() : base("B420")
    {
    }

    public RegistroB420(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|B420|"); // 1
        writer.Append(string.Format("{0:0.##}", ValorContabil) + "|"); // 2
        writer.Append(string.Format("{0:0.##}", ValorBcISS) + "|"); // 3
        writer.Append(string.Format("{0:0.##}", AliquotaISS) + "|"); // 4
        writer.Append(string.Format("{0:0.##}", TotalValorOpIsentas) + "|"); // 5
        writer.Append(string.Format("{0:0.##}", TotalCombAliqISS) + "|"); // 6
        writer.Append(CodServico + "|"); // 7
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        ValorContabil = data[2].ToNullableDouble();
        ValorBcISS = data[3].ToNullableDouble();
        AliquotaISS = data[4].ToNullableDouble();
        TotalValorOpIsentas = data[5].ToNullableDouble();
        TotalCombAliqISS = data[6].ToNullableDouble();
        CodServico = data[7].ToString();
    }

    public double? ValorContabil { get; set; } = default; // 2
    public double? ValorBcISS { get; set; } = default; // 3
    public double? AliquotaISS { get; set; } = default; // 4
    public double? TotalValorOpIsentas { get; set; } = default; // 5
    public double? TotalCombAliqISS { get; set; } = default; // 6
    public string CodServico { get; set; } = null; // 7
}
