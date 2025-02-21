
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Informativo da Composição de Custos
/// </summary>
/// <remarks></remarks>

public class RegistroL210 : Primitives.Registro
{
    public RegistroL210() : base("L210")
    {
    }

    public RegistroL210(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string CodigoReferencial { get; set; } = null;
    public string Descricao { get; set; } = null;
    public double? Valor { get; set; } = default;
    public bool Analitica { get; set; } = false;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|L210|");
        writer.Append(CodigoReferencial + "|");
        writer.Append(Descricao + "|");
        writer.Append(string.Format("{0:F2}", Valor) + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
