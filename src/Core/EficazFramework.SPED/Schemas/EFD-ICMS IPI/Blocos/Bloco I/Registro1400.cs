using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Informações Sobre Valores Agregados
/// </summary>
/// <remarks></remarks>
public class Registro1400 : Primitives.Registro
{
    public Registro1400() : base("1400")
    {
    }

    public Registro1400(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|1400|"); // 1
        writer.Append(ItemIPM + "|"); // 2
        writer.Append(MunicipioIBGE + "|");   // 3
        writer.Append(string.Format("{0:0.##}", Valor) + "|"); // 4
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        ItemIPM = data[2];
        MunicipioIBGE = data[3];
        Valor = data[4].ToNullableDouble();
    }

    public string ItemIPM { get; set; } = null; // 2
    public string MunicipioIBGE { get; set; } = null; // 3
    public double? Valor { get; set; } = default; // 4
}
