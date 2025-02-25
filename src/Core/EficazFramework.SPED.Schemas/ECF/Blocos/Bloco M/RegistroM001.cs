using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Abertura do Bloco M
/// </summary>
/// <remarks></remarks>
public class RegistroM001 : Primitives.Registro
{
    public RegistroM001() : base("M001")
    {
    }

    public RegistroM001(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M001|");
        writer.Append(((int)IndicadorMovimento).ToString() + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
    }
}
