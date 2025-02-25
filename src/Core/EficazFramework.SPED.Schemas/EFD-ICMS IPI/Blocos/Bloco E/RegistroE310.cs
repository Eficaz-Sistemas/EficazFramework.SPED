using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Apuração do ICMS Difal
/// </summary>
public class RegistroE310 : Primitives.Registro
{
    public RegistroE310() : base("E310")
    {
    }

    public RegistroE310(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|E310|"); // 1
        writer.Append((int)IndicadorMovimentoDifal + "|"); // 2
        writer.Append(string.Format("{0:0.##}", SaldoCredorAnterior) + "|"); // 3
        writer.Append(string.Format("{0:0.##}", DebitosDifal) + "|"); // 4
        writer.Append(string.Format("{0:0.##}", OutrosDebitos) + "|"); // 5
        writer.Append(string.Format("{0:0.##}", CreditosDifal) + "|"); // 6
        writer.Append(string.Format("{0:0.##}", OutrosCreditos) + "|"); // 7
        writer.Append(string.Format("{0:0.##}", SaldoDevedorApurado) + "|"); // 8
        writer.Append(string.Format("{0:0.##}", DeducoesDifal) + "|"); // 9
        writer.Append(string.Format("{0:0.##}", ICMSDifal_Recolher) + "|"); // 10
        writer.Append(string.Format("{0:0.##}", SaldoCredorATransportar) + "|"); // 11
        writer.Append(string.Format("{0:0.##}", DebitosExtraApuracao) + "|"); // 12
        writer.Append(string.Format("{0:0.##}", SaldoCredorAnteriorFCP) + "|"); // 13
        writer.Append(string.Format("{0:0.##}", DebitosFCP) + "|"); // 14
        writer.Append(string.Format("{0:0.##}", OutrosDebitosFCP) + "|"); // 15
        writer.Append(string.Format("{0:0.##}", CreditosFCP) + "|"); // 16
        writer.Append(string.Format("{0:0.##}", OutrosCreditosFCP) + "|"); // 17
        writer.Append(string.Format("{0:0.##}", SaldoDevedorApuradoFCP) + "|"); // 18
        writer.Append(string.Format("{0:0.##}", DeducoesFCP) + "|"); // 19
        writer.Append(string.Format("{0:0.##}", ICMSFCP_Recolher) + "|"); // 20
        writer.Append(string.Format("{0:0.##}", SaldoCredorATransportarFCP) + "|"); // 21
        writer.Append(string.Format("{0:0.##}", DebitosExtraApuracaoFCP) + "|"); // 22
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorMovimentoDifal = (IndicadorMovimentoST_Difal)data[2].ToEnum<IndicadorMovimentoST_Difal>(IndicadorMovimentoST_Difal.SemOperacoes);
        SaldoCredorAnterior = data[3].ToNullableDouble();
        DebitosDifal = data[4].ToNullableDouble();
        OutrosDebitos = data[5].ToNullableDouble();
        CreditosDifal = data[6].ToNullableDouble();
        OutrosCreditos = data[7].ToNullableDouble();
        SaldoDevedorApurado = data[8].ToNullableDouble();
        DeducoesDifal = data[9].ToNullableDouble();
        ICMSDifal_Recolher = data[10].ToNullableDouble();
        SaldoCredorATransportar = data[11].ToNullableDouble();
        DebitosExtraApuracao = data[12].ToNullableDouble();
        SaldoCredorAnterior = data[13].ToNullableDouble();
        DebitosFCP = data[14].ToNullableDouble();
        OutrosDebitosFCP = data[15].ToNullableDouble();
        CreditosFCP = data[16].ToNullableDouble();
        OutrosCreditosFCP = data[17].ToNullableDouble();
        SaldoDevedorApuradoFCP = data[18].ToNullableDouble();
        DeducoesFCP = data[19].ToNullableDouble();
        ICMSFCP_Recolher = data[20].ToNullableDouble();
        SaldoCredorATransportarFCP = data[21].ToNullableDouble();
        DebitosExtraApuracaoFCP = data[22].ToNullableDouble();
    }

    public IndicadorMovimentoST_Difal IndicadorMovimentoDifal { get; set; } = IndicadorMovimentoST_Difal.SemOperacoes; // 02
    public double? SaldoCredorAnterior { get; set; } = default; // 03
    public double? DebitosDifal { get; set; } = default; // 04
    public double? OutrosDebitos { get; set; } = default; // 05
    public double? CreditosDifal { get; set; } = default; // 06
    public double? OutrosCreditos { get; set; } = default; // 07
    public double? SaldoDevedorApurado { get; set; } = default; // 08
    public double? DeducoesDifal { get; set; } = default; // 09
    public double? ICMSDifal_Recolher { get; set; } = default; // 10
    public double? SaldoCredorATransportar { get; set; } = default; // 11
    public double? DebitosExtraApuracao { get; set; } = default; // 12
    public double? SaldoCredorAnteriorFCP { get; set; } = default; // 13
    public double? DebitosFCP { get; set; } = default; // 14
    public double? OutrosDebitosFCP { get; set; } = default; // 15
    public double? CreditosFCP { get; set; } = default; // 16
    public double? OutrosCreditosFCP { get; set; } = default; // 17
    public double? SaldoDevedorApuradoFCP { get; set; } = default; // 18
    public double? DeducoesFCP { get; set; } = default; // 19
    public double? ICMSFCP_Recolher { get; set; } = default; // 20
    public double? SaldoCredorATransportarFCP { get; set; } = default; // 21
    public double? DebitosExtraApuracaoFCP { get; set; } = default; // 22

    // // Navegation Properties:

    public List<RegistroE311> RegistrosE311 { get; set; } = new List<RegistroE311>();
    public List<RegistroE316> RegistrosE316 { get; set; } = new List<RegistroE316>();
}
