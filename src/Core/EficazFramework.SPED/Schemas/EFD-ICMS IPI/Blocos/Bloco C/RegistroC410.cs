using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// PIS e COFINS Totalizados no dia (Código 02, 2D e 60)
/// </summary>
/// <remarks></remarks>
public class RegistroC410 : Primitives.Registro
{
    public RegistroC410() : base("C410")
    {
    }

    public RegistroC410(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C410|"); // 1
        writer.Append(string.Format("{0:0.##}", PIS) + "|"); // 2
        writer.Append(string.Format("{0:0.##}", COFINS) + "|"); // 3
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        PIS = data[2].ToNullableDouble();
        COFINS = data[3].ToNullableDouble();
    }

    public double? PIS { get; set; } = default; // 2
    public double? COFINS { get; set; } = default; // 3
}
