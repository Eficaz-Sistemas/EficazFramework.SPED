
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Contas Contábeis Relacionadas ao Lançamento da Parte A do e-Lacs
/// </summary>
/// <remarks></remarks>

public class RegistroM360 : Primitives.Registro
{
    public RegistroM360() : base("M360")
    {
    }

    public RegistroM360(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string CodigoContaContabil { get; set; } = null;
    public string CentroDeCusto { get; set; } = null;
    public double? Valor { get; set; } = default;
    /// <summary>
    /// D – Devedor
    /// C – Credor
    /// </summary>
    public string Natureza { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M360|");
        writer.Append(CodigoContaContabil + "|");
        writer.Append(CentroDeCusto + "|");
        writer.Append(string.Format("{0:F2}", Valor) + "|");
        writer.Append(Natureza + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
