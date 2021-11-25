using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// REGISTRO C174: OPERAÇÕES COM ARMAS DE FOGO (CÓDIGO 01)
/// </summary>
/// <remarks></remarks>
public class RegistroC174 : Primitives.Registro
{
    public RegistroC174() : base("C174")
    {
    }

    public RegistroC174(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C174|"); // 1
        writer.Append(((int)IndicadorTipoArmaFogo).ToString() + "|"); // 2
        writer.Append(NumSerieFabricacao + "|"); // 3
        writer.Append(DescricaoArma + "|"); // 4
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorTipoArmaFogo = (IndicadorTipoArmaFogo)data[2].ToEnum<IndicadorTipoArmaFogo>(IndicadorTipoArmaFogo.UsoPermitido);
        NumSerieFabricacao = data[3].ToString();
        DescricaoArma = data[4].ToString();
    }

    public IndicadorTipoArmaFogo IndicadorTipoArmaFogo { get; set; } = IndicadorTipoArmaFogo.UsoPermitido; // 2
    public string NumSerieFabricacao { get; set; } // 3
    public string DescricaoArma { get; set; } // 4
}
