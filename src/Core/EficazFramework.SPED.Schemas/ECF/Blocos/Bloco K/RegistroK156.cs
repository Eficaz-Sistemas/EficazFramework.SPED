using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Mapeamento Referencial do Saldo Final
/// </summary>
/// <remarks></remarks>

public class RegistroK156 : Primitives.Registro
{
    public RegistroK156() : base("K156")
    {
    }

    public RegistroK156(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoContaReferencial { get; set; } = null;
    public double? VrSaldoInicialPeriodo { get; set; }
    public string IndicadorSituacaoSaldoInicial { get; set; } = null;
    public double? VrTotalDebitosPeriodo { get; set; }
    public double? VrTotalCreditosPeriodo { get; set; }
    public double? VrSaldoFinalPeriodo { get; set; }
    public string IndicadorSituacaoSaldoFinal { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|K156|");
        writer.Append(CodigoContaReferencial + "|");
        if (Conversions.ToInteger(Versao) >= 5)
        {
            writer.Append(string.Format("{0:F2}", VrSaldoInicialPeriodo) + "|");
            writer.Append(IndicadorSituacaoSaldoInicial + "|");
            writer.Append(string.Format("{0:F2}", VrTotalDebitosPeriodo) + "|");
            writer.Append(string.Format("{0:F2}", VrTotalCreditosPeriodo) + "|");
        }

        writer.Append(string.Format("{0:F2}", VrSaldoFinalPeriodo) + "|");
        writer.Append(IndicadorSituacaoSaldoFinal + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoContaReferencial = data[2];
        if (Conversions.ToInteger(Versao) >= 5)
        {
            VrSaldoInicialPeriodo = data[3].ToNullableDouble();
            IndicadorSituacaoSaldoFinal = data[4];
            VrTotalDebitosPeriodo = data[5].ToNullableDouble();
            VrTotalCreditosPeriodo = data[6].ToNullableDouble();
        }

        VrSaldoFinalPeriodo = data[7].ToNullableDouble();
        IndicadorSituacaoSaldoFinal = data[8];
    }
}
