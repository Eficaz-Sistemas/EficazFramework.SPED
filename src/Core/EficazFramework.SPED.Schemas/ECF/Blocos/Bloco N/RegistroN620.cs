
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Apuração do IRPJ Mensal por Estimativa
/// </summary>
/// <remarks></remarks>

public class RegistroN620 : Primitives.Registro
{
    public RegistroN620() : base("N620")
    {
    }

    public RegistroN620(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string CodigoReferencial { get; set; } = null;
    public string Descricao { get; set; } = null;
    public double? Valor { get; set; } = default;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|N620|");
        writer.Append(CodigoReferencial + "|");
        writer.Append(Descricao + "|");
        writer.Append(string.Format("{0:F2}", Valor) + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
