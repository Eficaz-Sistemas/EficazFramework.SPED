using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Notas Fiscais de Venda a Consumidor
/// </summary>
/// <remarks></remarks>

public class RegistroC395 : Primitives.Registro
{
    public RegistroC395() : base("C395")
    {
    }

    public RegistroC395(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoModeloDocFiscal { get; set; } = null;
    public string CodigoParticipante { get; set; } = null;
    public string SerieDocFiscal { get; set; } = null;
    public string SubSerieDocFiscal { get; set; } = null;
    public int? NumeroDocFiscal { get; set; }
    public DateTime? DataEmissaoDocFiscal { get; set; }
    public double? ValorDocFiscal { get; set; }
    public List<RegistroC396> RegistrosC396 { get; set; } = new List<RegistroC396>();

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C395|");
        writer.Append(CodigoModeloDocFiscal + "|");
        writer.Append(CodigoParticipante + "|");
        writer.Append(SerieDocFiscal + "|");
        writer.Append(SubSerieDocFiscal + "|");
        writer.Append(NumeroDocFiscal + "|");
        writer.Append(DataEmissaoDocFiscal + "|");
        writer.Append(ValorDocFiscal + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoModeloDocFiscal = data[2];
        CodigoParticipante = data[3];
        SerieDocFiscal = data[4];
        SubSerieDocFiscal = data[5];
        NumeroDocFiscal = data[6].ToNullableInteger();
        DataEmissaoDocFiscal = data[7].ToDate();
        ValorDocFiscal = data[8].ToNullableDouble();
    }
}
