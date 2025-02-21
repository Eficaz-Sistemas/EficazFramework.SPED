using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Fatores de Conversão de Unidades
/// </summary>
/// <remarks></remarks>
public class Registro0220 : Primitives.Registro
{
    public Registro0220() : base("0220")
    {
    }

    public Registro0220(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0220|"); // 1
        writer.Append(UnidadeComercialConvertida + "|"); // 2
        writer.Append(string.Format("{0:0.######}", FatorConversao) + "|"); // 3
        if (int.Parse(Versao) > 15)
        {
            writer.Append(CodigoBarras + "|"); //4
        }
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        UnidadeComercialConvertida = data[2].ToString();
        FatorConversao = data[3].ToNullableDouble();
        if (int.Parse(Versao) > 15)
        {
            CodigoBarras = data[4].ToString();
        }
    }

    public string UnidadeComercialConvertida { get; set; } // 2
    public double? FatorConversao { get; set; } // 3
    public string CodigoBarras { get; set; } //4
}
