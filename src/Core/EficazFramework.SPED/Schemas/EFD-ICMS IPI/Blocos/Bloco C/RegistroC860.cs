using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Identificação do Equipamento SAT CF-e (59)
/// </summary>
/// <remarks></remarks>
public class RegistroC860 : Primitives.Registro
{
    public RegistroC860() : base("C860")
    {
    }

    public RegistroC860(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C860|"); // 1
        writer.Append(EspecieDocumento + "|"); // 2
        writer.Append(string.Format("{0:000000000}", NumeroSerieSAT + "|")); // 3
        writer.Append(DataEmissao.ToSpedString() + "|"); // 4
        writer.Append(DocInicial + "|"); // 5
        writer.Append(DocFinal + "|"); // 6
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        EspecieDocumento = data[2];
        NumeroSerieSAT = data[3].ToNullableInteger();
        DataEmissao = data[4].ToDate();
        DocInicial = data[5].ToNullableInteger();
        DocFinal = data[6].ToNullableInteger();
    }

    public string EspecieDocumento { get; set; } = null; // 2
    public int? NumeroSerieSAT { get; set; } = default; // 3
    public DateTime? DataEmissao { get; set; } = default; // 4
    public int? DocInicial { get; set; } = default; // 5
    public int? DocFinal { get; set; } = default; // 6

    // Registros Filhos
    public List<RegistroC890> RegistrosC890 { get; set; } = new List<RegistroC890>();
}
