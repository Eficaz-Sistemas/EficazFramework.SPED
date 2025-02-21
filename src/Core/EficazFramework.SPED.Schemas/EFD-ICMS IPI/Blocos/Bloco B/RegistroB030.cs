using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Abertura do Bloco B
/// </summary>
/// <remarks></remarks>


public class RegistroB030 : Primitives.Registro
{
    public RegistroB030() : base("B030")
    {
    }

    public RegistroB030(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|B030|"); // 1
        writer.Append(CodigoModeloDocFiscal + "|"); // 2
        writer.Append(SerieDocFiscal + "|"); // 3
        writer.Append(NumeroDocInicialDia + "|"); // 4
        writer.Append(NumeroDocFinalDia + "|"); // 5
        writer.Append(DataEmissaoDocFiscal + "|"); // 6
        writer.Append(QuantDocCanc + "|"); // 7
        writer.Append(string.Format("{0:0.##}", ValorContabilTotalDocs) + "|"); // 8
        writer.Append(string.Format("{0:0.##}", ValorAcumOpIsentasNTribISS) + "|"); // 9
        writer.Append(string.Format("{0:0.##}", ValorAcumBCISS) + "|"); // 10
        writer.Append(string.Format("{0:0.##}", ValorISSDestacado) + "|"); // 11
        writer.Append(CodigoObsLctoFiscal + "|"); // 12
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoModeloDocFiscal = data[2].ToString();
        SerieDocFiscal = data[3].ToString();
        NumeroDocInicialDia = data[4].ToNullableInteger();
        NumeroDocFinalDia = data[5].ToNullableInteger();
        DataEmissaoDocFiscal = data[6].ToDate();
        QuantDocCanc = data[7].ToNullableInteger();
        ValorContabilTotalDocs = data[8].ToNullableDouble();
        ValorAcumOpIsentasNTribISS = data[9].ToNullableDouble();
        ValorAcumBCISS = data[10].ToNullableDouble();
        ValorISSDestacado = data[11].ToNullableDouble();
        CodigoObsLctoFiscal = data[12].ToString();
    }

    public string CodigoModeloDocFiscal { get; set; } = null; // 2
    public string SerieDocFiscal { get; set; } = null; // 3
    public int? NumeroDocInicialDia { get; set; } = default; // 4
    public int? NumeroDocFinalDia { get; set; } = default; // 5
    public DateTime? DataEmissaoDocFiscal { get; set; } = default; // 6
    public int? QuantDocCanc { get; set; } = default; // 7
    public double? ValorContabilTotalDocs { get; set; } = default; // 8
    public double? ValorAcumOpIsentasNTribISS { get; set; } = default; // 9
    public double? ValorAcumBCISS { get; set; } = default; // 10
    public double? ValorISSDestacado { get; set; } = default; // 11
    public string CodigoObsLctoFiscal { get; set; } = null; // 12
}
