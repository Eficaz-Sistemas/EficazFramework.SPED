
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Conta da Parte B do e-Lacs
/// </summary>
/// <remarks></remarks>

public class RegistroM355 : Primitives.Registro
{
    public RegistroM355() : base("M355")
    {
    }

    public RegistroM355(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string CodigoContaB { get; set; } = null;
    public double? Valor { get; set; } = default;
    /// <summary>
    /// D – Para prejuízos ou valores que reduzam o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.
    /// C – Para valores que aumentem o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.
    /// </summary>
    /// <returns></returns>
    public string Natureza { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M355|");
        writer.Append(CodigoContaB + "|");
        writer.Append(string.Format("{0:F2}", Valor) + "|");
        writer.Append(Natureza + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
