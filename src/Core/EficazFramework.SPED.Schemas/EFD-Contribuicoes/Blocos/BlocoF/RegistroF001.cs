using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Abertura do BlocoF
/// </summary>
/// <remarks></remarks>
public class RegistroF001 : Primitives.Registro
{
    public RegistroF001() : base("F001")
    {
    }

    public RegistroF001(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|F001|");
        writer.Append(((int)IndicadorMovimento).ToString() + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
    }
}
