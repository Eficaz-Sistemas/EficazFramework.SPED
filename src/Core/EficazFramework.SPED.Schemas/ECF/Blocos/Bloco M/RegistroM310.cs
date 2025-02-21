
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Contas Contábeis Relacionadas ao Lançamento da Parte A do e-Lalur
/// </summary>
/// <remarks></remarks>

public class RegistroM310 : Primitives.Registro
{
    public RegistroM310() : base("M310")
    {
    }

    public RegistroM310(string linha, string versao) : base(linha, versao)
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
    /// <returns></returns>
    public string Natureza { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M310|");
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
