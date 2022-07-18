using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Escrituração consolidada da Nota Fiscal Fatura Eletrônica de 
/// Serviços de Comunicação – NFCom (Código 62)
/// </summary>
/// <remarks></remarks>
public class RegistroD750 : Primitives.Registro
{
    public RegistroD750() : base("D750")
    {
    }

    public RegistroD750(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D750|"); // 1
        writer.Append(EspecieDocumento + "|"); // 2
        writer.Append(Serie + "|"); // 3
        writer.Append(DataEmissao.ToSpedString() + "|"); // 4
        writer.Append(Quantidade + "|"); // 5
        writer.Append((int)IndicadorPrePago + "|"); // 6
        writer.Append(string.Format("{0:0.##}", ValorTotalDocumentos) + "|"); // 7
        writer.Append(string.Format("{0:0.##}", ValorServicos) + "|"); // 8
        writer.Append(string.Format("{0:0.##}", ValorServicosNT) + "|"); // 9
        writer.Append(string.Format("{0:0.##}", ValorCobradoTerceiros) + "|"); // 10
        writer.Append(string.Format("{0:0.##}", ValorDesconto) + "|"); // 11
        writer.Append(string.Format("{0:0.##}", ValorDespesasAcessorias) + "|"); // 12
        writer.Append(string.Format("{0:0.##}", ValorBaseCalculoICMS) + "|"); // 13
        writer.Append(string.Format("{0:0.##}", ValorICMS) + "|"); // 14
        writer.Append(string.Format("{0:0.##}", ValorPIS) + "|"); // 15
        writer.Append(string.Format("{0:0.##}", ValorCofins) + "|"); // 16
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        EspecieDocumento = data[2];
        Serie = data[3];
        DataEmissao = data[4].ToDate();
        Quantidade = data[5].ToNullableInteger();
        IndicadorPrePago = (IndicadorPrePago)data[6].ToEnum<IndicadorPrePago>(IndicadorPrePago.PrePago);
        ValorTotalDocumentos = data[7].ToNullableDouble();
        ValorServicos = data[8].ToNullableDouble();
        ValorServicosNT = data[9].ToNullableDouble();
        ValorCobradoTerceiros = data[10].ToNullableDouble();
        ValorDesconto = data[11].ToNullableDouble();
        ValorDespesasAcessorias = data[12].ToNullableDouble();
        ValorBaseCalculoICMS = data[13].ToNullableDouble();
        ValorICMS = data[14].ToNullableDouble();
        ValorPIS = data[15].ToNullableDouble();
        ValorCofins = data[16].ToNullableDouble();
    }

    public string EspecieDocumento { get; set; } = null; // 2
    public string Serie { get; set; } = null; // 3
    public DateTime? DataEmissao { get; set; } = default; // 4
    public int? Quantidade { get; set; } = default; // 5
    public IndicadorPrePago IndicadorPrePago { get; set; } = IndicadorPrePago.PrePago; // 6
    public double? ValorTotalDocumentos { get; set; } = default; // 7
    public double? ValorServicos { get; set; } = default; // 8
    public double? ValorServicosNT { get; set; } = default; // 9
    public double? ValorCobradoTerceiros { get; set; } = default; // 10
    public double? ValorDesconto { get; set; } = default; // 11
    public double? ValorDespesasAcessorias { get; set; } = default; // 12
    public double? ValorBaseCalculoICMS { get; set; } = default; // 13
    public double? ValorICMS { get; set; } = default; // 14
    public double? ValorPIS { get; set; } = default; // 15
    public double? ValorCofins { get; set; } = default; // 16

}
