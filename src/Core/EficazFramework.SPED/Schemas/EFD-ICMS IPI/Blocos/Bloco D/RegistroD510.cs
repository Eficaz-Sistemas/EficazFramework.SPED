using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Itens do Documento - Nota Fiscal de Serviõ de Comunicação (Código 21) e Serviço de Telecomunicação (Código 22) 
/// </summary>
/// <remarks></remarks>
public partial class RegistroD510 : Primitives.Registro
{

    public RegistroD510() : base("D510")
    {
    }

    public RegistroD510(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new StringBuilder();
        writer.Append("|D510|"); // 1
        writer.Append(string.Format("{0:##0}", NumeroSequencialItem) + "|"); // 2
        writer.Append(CodigoProduto + "|"); // 3
        writer.Append(CodigoClassificacao + "|"); // 4
        writer.Append(string.Format("{0:0.###}", Quantidade) + "|"); // 5
        writer.Append(UnidadeMedida + "|"); // 6
        writer.Append(string.Format("{0:0.##}", ValorItem) + "|"); // 7
        writer.Append(string.Format("{0:0.##}", Desconto) + "|"); // 8
        writer.Append((int)Origem + string.Format("{0:00}", (int)CST_ICMS) + "|"); // 9
        writer.Append(CFOP + "|"); // 10
        writer.Append(string.Format("{0:0.##}", BaseCalculo_ICMS) + "|"); // 11
        writer.Append(string.Format("{0:0.##}", Aliquota_ICMS) + "|"); // 12
        writer.Append(string.Format("{0:0.##}", Valor_ICMS) + "|"); // 13
        writer.Append(string.Format("{0:0.##}", BaseCalculo_ICMS_UFs) + "|"); // 14
        writer.Append(string.Format("{0:0.##}", Valor_ICMS_UFs) + "|"); // 15
        writer.Append((int)OutrosValores + "|"); // 16
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        NumeroSequencialItem = data[2].ToNullableInteger();
        CodigoProduto = data[3];
        CodigoClassificacao = data[4];
        Quantidade = data[5].ToNullableDouble();
        UnidadeMedida = data[6];
        ValorItem = data[7].ToNullableDouble();
        Desconto = data[8].ToNullableDouble();
        Origem = (NFe.OrigemMercadoria)data[9][..1].ToEnum<NFe.OrigemMercadoria>(NFe.OrigemMercadoria.Nacional);
        CST_ICMS = (NFe.CST_ICMS)data[9].Substring(1, 2).ToEnum<NFe.CST_ICMS>(NFe.CST_ICMS.CST_00);
        CFOP = data[10];
        BaseCalculo_ICMS = data[11].ToNullableDouble();
        Aliquota_ICMS = data[12].ToNullableDouble();
        Valor_ICMS = data[13].ToNullableDouble();
        BaseCalculo_ICMS_UFs = data[14].ToNullableDouble();
        Valor_ICMS_UFs = data[15].ToNullableDouble();
        OutrosValores = (IndicadorTipoReceitaTelecom)data[16].ToEnum<IndicadorTipoReceitaTelecom>(IndicadorTipoReceitaTelecom.PropriaServPrestado);
    }

    public int? NumeroSequencialItem { get; set; } // 2
    public string CodigoProduto { get; set; } // 3
    public string CodigoClassificacao { get; set; } // 4
    public double? Quantidade { get; set; } // 5
    public string UnidadeMedida { get; set; } // 6
    public double? ValorItem { get; set; } // 7
    public double? Desconto { get; set; } // 8
    public NFe.OrigemMercadoria Origem { get; set; } = NFe.OrigemMercadoria.Nacional; // 9
    public NFe.CST_ICMS CST_ICMS { get; set; } = NFe.CST_ICMS.CST_00; // 9
    public string CFOP { get; set; } // 10
    public double? BaseCalculo_ICMS { get; set; } // 11
    public double? Aliquota_ICMS { get; set; } // 12
    public double? Valor_ICMS { get; set; } // 13
    public double? BaseCalculo_ICMS_UFs { get; set; } // 14
    public double? Valor_ICMS_UFs { get; set; } // 15
    public IndicadorTipoReceitaTelecom OutrosValores { get; set; } = IndicadorTipoReceitaTelecom.PropriaServPrestado; // 16

}
