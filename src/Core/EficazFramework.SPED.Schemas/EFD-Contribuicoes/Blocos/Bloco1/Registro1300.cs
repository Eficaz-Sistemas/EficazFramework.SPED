using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Controle dos valores retidos da fonte - pis
/// </summary>
/// <remarks></remarks>

public class Registro1300 : Primitives.Registro
{
    public Registro1300() : base("1300")
    {
    }

    public Registro1300(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public IndicadorNatRetFonte IndicadorNaturezaRetFonte { get; set; } = IndicadorNatRetFonte.OutrasRetencoes;
    public DateTime? PeriodoRecebRetencao { get; set; }
    public double? VrTotalRetencao { get; set; }
    public double? VrRetencaoDedContrDevidaPerEscPerAnteriores { get; set; }
    public double? VrRetencaoUtilPedRestituicao { get; set; }
    public double? VrRetencaoUtilDeclaracaoComp { get; set; }
    public double? SaldoRetencaoPerApFuturos { get; set; }

    public override string EscreveLinha()
    {
        var writer = new global::System.Text.StringBuilder();
        writer.Append("|1300|");
        writer.Append(((int)IndicadorNaturezaRetFonte).ToString() + "|");
        writer.Append(PeriodoRecebRetencao + "|");
        writer.Append(VrTotalRetencao + "|");
        writer.Append(VrRetencaoDedContrDevidaPerEscPerAnteriores + "|");
        writer.Append(VrRetencaoUtilPedRestituicao + "|");
        writer.Append(VrRetencaoUtilDeclaracaoComp + "|");
        writer.Append(SaldoRetencaoPerApFuturos + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorNaturezaRetFonte = (IndicadorNatRetFonte)data[2].ToEnum<IndicadorNatRetFonte>(IndicadorNatRetFonte.OutrasRetencoes);
        PeriodoRecebRetencao = data[3].ToDate();
        VrTotalRetencao = data[4].ToNullableDouble();
        VrRetencaoDedContrDevidaPerEscPerAnteriores = data[5].ToNullableDouble();
        VrRetencaoUtilPedRestituicao = data[6].ToNullableDouble();
        VrRetencaoUtilDeclaracaoComp = data[7].ToNullableDouble();
        SaldoRetencaoPerApFuturos = data[8].ToNullableDouble();
    }
}
