using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Informações do fundo de combate à pobreza – FCP – (Código 62)
/// </summary>
/// <remarks></remarks>
public class RegistroD731 : Primitives.Registro
{
    public RegistroD731() : base("D731")
    {
    }

    public RegistroD731(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D731|"); // 1
        writer.Append(string.Format("{0:0.##}", ValorFCP) + "|"); // 02
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        ValorFCP = data[2].ToNullableDouble();
    }

    public double? ValorFCP { get; set; } = default; // 02
}
