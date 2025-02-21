using EficazFramework.SPED.Extensions;
using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Informações complementares das operações de devolução de entradas de mercadorias sujeitas à
/// substituição tributária(código 01, 1B, 04 e 55).
/// </summary>
/// <remarks></remarks>

public class RegistroC186 : Primitives.Registro
{
    public RegistroC186() : base("C186")
    {
    }

    public RegistroC186(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C186|"); // 1
        writer.Append(string.Format("{0:##0}", NumeroItem) + "|"); // 2
        writer.Append(CodigoProduto + "|"); // 3
        writer.Append(((int)Origem).ToString() + string.Format("{0:00}", (int)CST_ICMS) + "|"); // 4
        writer.Append(CFOP + "|"); // 5
        writer.Append(CodMotivoRestituicao + "|"); // 6
        writer.Append(string.Format("{0:0.######}", QuantidadeItem) + "|"); // 7
        writer.Append(Unidade + "|"); // 8
        writer.Append(EspecieDocEntrada + "|"); // 9
        writer.Append(SerieDocEntrada + "|"); // 10
        writer.Append(NumeroDocEntrada + "|"); // 11
        writer.Append(ChaveDocEntrada + "|"); // 12
        writer.Append(DataDocEntrada.ToSpedString() + "|"); //13
        writer.Append(string.Format("{0:##0}", NumeroItemDocEntrada) + "|"); // 14
        writer.Append(string.Format("{0:0.######}", VrUnitarioEntrada) + "|"); // 15
        writer.Append(string.Format("{0:0.######}", VrUnitarioOpPropriaEntrada) + "|"); // 16
        writer.Append(string.Format("{0:0.######}", VrUnitarioBC_STEntrada) + "|"); // 17
        writer.Append(string.Format("{0:0.######}", VrUnitarioSTEntrada) + "|"); // 18
        writer.Append(string.Format("{0:0.######}", VrUnitarioFCPEntrada) + "|"); // 19
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }

    public short? NumeroItem { get; set; } // 2
    public string CodigoProduto { get; set; } // 3
    public NFe.OrigemMercadoria Origem { get; set; } = NFe.OrigemMercadoria.Nacional; // 4
    public NFe.CST_ICMS CST_ICMS { get; set; } = NFe.CST_ICMS.CST_00; // 4
    public string CFOP { get; set; } // 5
    public string CodMotivoRestituicao { get; set; } // 6
    public double? QuantidadeItem { get; set; } // 7
    public string Unidade { get; set; } // 8
    public string EspecieDocEntrada { get; set; } // 9
    public string SerieDocEntrada { get; set; } // 10
    public long? NumeroDocEntrada { get; set; } // 11
    public string ChaveDocEntrada { get; set; } // 12
    public DateTime? DataDocEntrada { get; set; } // 13
    public short? NumeroItemDocEntrada { get; set; } // 14
    public double? VrUnitarioEntrada { get; set; } // 15
    public double? VrUnitarioOpPropriaEntrada { get; set; } // 16
    public double? VrUnitarioBC_STEntrada { get; set; } // 17
    public double? VrUnitarioSTEntrada { get; set; } // 18
    public double? VrUnitarioFCPEntrada { get; set; } // 19

}
