using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Abertura do Bloco D
/// </summary>
/// <remarks></remarks>
public class RegistroD001 : Primitives.Registro
{
    public RegistroD001() : base("D001")
    {
    }

    public RegistroD001(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D001|"); // 1
        writer.Append(((int)IndicadorMovimento).ToString() + "|"); // 3
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
    }

    public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;
}
