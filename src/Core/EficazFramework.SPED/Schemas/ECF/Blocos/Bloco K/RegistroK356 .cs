using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Mapeamento Referencial dos Saldos Final
/// </summary>
/// <remarks></remarks>

public class RegistroK356 : Primitives.Registro
{
    public RegistroK356() : base("K356")
    {
    }

    public RegistroK356(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoContaReferencial { get; set; } = null;
    public double? VrSaldoFinalPeriodo { get; set; }
    public string IndicadorSituacaoSaldoFinal { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|K356|");
        writer.Append(CodigoContaReferencial + "|");
        writer.Append(string.Format("{0:F2}", VrSaldoFinalPeriodo) + "|");
        writer.Append(IndicadorSituacaoSaldoFinal + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoContaReferencial = data[2];
        VrSaldoFinalPeriodo = data[8].ToNullableDouble();
        IndicadorSituacaoSaldoFinal = data[9];
    }
}
