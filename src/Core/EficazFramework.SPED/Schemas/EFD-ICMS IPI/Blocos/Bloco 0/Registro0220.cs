
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
        writer.Append(FatorConversao + "|"); // 3
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        UnidadeComercialConvertida = data[2].ToString();
        FatorConversao = data[3].ToString();
    }

    public string UnidadeComercialConvertida { get; set; } // 2
    public string FatorConversao { get; set; } // 3
}
