
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Cálculo da Isenção e Redução do Imposto Sobre o Lucro Real
/// </summary>
/// <remarks></remarks>

public class RegistroN610 : Primitives.Registro
{
    public RegistroN610() : base("N610")
    {
    }

    public RegistroN610(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string CodigoReferencial { get; set; } = null;
    public string Descricao { get; set; } = null;
    public double? Valor { get; set; } = default;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|N610|");
        writer.Append(CodigoReferencial + "|");
        writer.Append(Descricao + "|");
        writer.Append(string.Format("{0:F2}", Valor) + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
