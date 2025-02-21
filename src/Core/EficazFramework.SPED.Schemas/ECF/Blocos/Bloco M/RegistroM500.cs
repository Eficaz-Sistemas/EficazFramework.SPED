
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Controle de Saldos das Contas da Parte B do e-Lalur e do e-Lacs
/// </summary>
/// <remarks></remarks>

public class RegistroM500 : Primitives.Registro
{
    public RegistroM500() : base("M500")
    {
    }

    public RegistroM500(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string CodigoContaB { get; set; } = null;
    /// <summary>
    /// I = IRPJ
    /// C = CSLL
    /// </summary>
    public string CodigoTributo { get; set; } = null;
    public double? SaldoInicial { get; set; } = default;
    /// <summary>
    /// D – Para prejuízos ou valores que reduzam o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.
    /// C – Para valores que aumentem o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.
    /// </summary>
    /// <returns></returns>
    public string NaturezaSaldoInicial { get; set; } = null;
    public double? ValorLanctoParteA { get; set; } = default;
    /// <summary>
    /// D – Para prejuízos ou valores que reduzam o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.
    /// C – Para valores que aumentem o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.
    /// </summary>
    /// <returns></returns>
    public string NaturezaLanctoParteA { get; set; } = null;
    public double? ValorLanctoParteB { get; set; } = default;
    /// <summary>
    /// D – Para prejuízos ou valores que reduzam o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.
    /// C – Para valores que aumentem o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.
    /// </summary>
    /// <returns></returns>
    public string NaturezaLanctoParteB { get; set; } = null;
    public double? SaldoFinal { get; set; } = default;
    /// <summary>
    /// D – Para prejuízos ou valores que reduzam o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.
    /// C – Para valores que aumentem o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.
    /// </summary>
    /// <returns></returns>
    public string NaturezaSaldoFinal { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M500|");
        writer.Append(CodigoContaB + "|");
        writer.Append(CodigoTributo + "|");
        writer.Append(string.Format("{0:F2}", SaldoInicial) + "|");
        writer.Append(NaturezaSaldoInicial + "|");
        writer.Append(string.Format("{0:F2}", ValorLanctoParteA) + "|");
        writer.Append(NaturezaLanctoParteA + "|");
        writer.Append(string.Format("{0:F2}", ValorLanctoParteB) + "|");
        writer.Append(NaturezaLanctoParteB + "|");
        writer.Append(string.Format("{0:F2}", SaldoFinal) + "|");
        writer.Append(NaturezaSaldoFinal + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
