using EficazFramework.SPED.Extensions;
using EficazFramework.SPED.Schemas.Primitives;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Abertura do Bloco 9
/// </summary>
/// <remarks></remarks>

public class Registro9001 : Registro
{
    public Registro9001() : base("9001")
    {
    }

    public Registro9001(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public IndicadorMovimento IndicadorMovimento { get; set; } = IndicadorMovimento.ComDados;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|9001|");
        writer.Append(((int)IndicadorMovimento).ToString() + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorMovimento = (IndicadorMovimento)data[2].ToEnum<IndicadorMovimento>(IndicadorMovimento.ComDados);
    }
}
