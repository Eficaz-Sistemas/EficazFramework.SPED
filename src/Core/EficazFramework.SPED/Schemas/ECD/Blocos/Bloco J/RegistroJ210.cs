using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// DLPA - Demonstração de Lucros ou Prejuízos Acumulados/DMPL - Demonstração de Mutações do Patrimônio Líquido
/// </summary>
/// <remarks></remarks>

public class RegistroJ210 : Primitives.Registro
{
    public RegistroJ210() : base("J210")
    {
    }

    // Campos'
    public IndicadorTipoDemonst IndicadorTipoDemonst { get; set; } = IndicadorTipoDemonst.DLPA;
    public string CodAglutinacao { get; set; } = null;
    public string DescCodAglutinacao { get; set; } = null;
    public double? SaldoFinalCodAglutinacao { get; set; }
    public string IndicadorSitSaldoInformado { get; set; } = null;
    public double? SaldoInicialCodAglutinacao { get; set; }
    public string IndicadorSitSaldoInformadoInicial { get; set; } = null;
    public string NotasExplicativas { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|J210|");
        writer.Append(((int)IndicadorTipoDemonst).ToString() + "|");
        writer.Append(CodAglutinacao + "|");
        writer.Append(DescCodAglutinacao + "|");
        if (Conversions.ToInteger(Versao) / 100d >= 7d)
        {
            writer.Append(string.Format("{0:F2}", SaldoInicialCodAglutinacao) + "|"); // gera 2,119999999999999
            writer.Append(IndicadorSitSaldoInformadoInicial + "|");
            writer.Append(string.Format("{0:F2}", SaldoFinalCodAglutinacao) + "|"); // gera 2,12
            writer.Append(IndicadorSitSaldoInformado + "|");
            writer.Append(NotasExplicativas + "|");
        }
        else
        {
            writer.Append(string.Format("{0:F2}", SaldoFinalCodAglutinacao) + "|"); // gera 2,12
            writer.Append(IndicadorSitSaldoInformado + "|");
            writer.Append(string.Format("{0:F2}", SaldoInicialCodAglutinacao) + "|"); // gera 2,119999999999999
            writer.Append(IndicadorSitSaldoInformadoInicial + "|");
        }

        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorTipoDemonst = (IndicadorTipoDemonst)data[2].ToEnum<IndicadorTipoDemonst>(IndicadorTipoDemonst.DLPA);
        CodAglutinacao = data[3];
        DescCodAglutinacao = data[4];
        SaldoFinalCodAglutinacao = data[5].ToNullableDouble();
        IndicadorSitSaldoInformado = data[6];
        SaldoInicialCodAglutinacao = data[7].ToNullableDouble();
        IndicadorSitSaldoInformadoInicial = data[8];
    }
}
