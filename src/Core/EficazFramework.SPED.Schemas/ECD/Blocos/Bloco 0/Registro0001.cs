using System.Collections.Generic;
using EficazFramework.SPED.Extensions;
using EficazFramework.SPED.Schemas.Primitives;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Abertura do Bloco 0
/// </summary>
/// <remarks></remarks>
public class Registro0001 : Registro
{
    public Registro0001() : base("0001")
    {
    }

    public Registro0001(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public IndicadorMovimento IndicadorMovimento { get; set; } = IndicadorMovimento.ComDados;
    public List<Registro0150> Registros0150 { get; set; } = new List<Registro0150>();

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0001|");
        writer.Append(((int)IndicadorMovimento).ToString() + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorMovimento = (IndicadorMovimento)data[2].ToEnum<IndicadorMovimento>(IndicadorMovimento.ComDados);
    }
}
