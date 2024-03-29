﻿using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Período da Apuração do ICMS ST
/// </summary>
public class RegistroE200 : Primitives.Registro
{
    public RegistroE200() : base("E200")
    {
    }

    public RegistroE200(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|E200|"); // 1
        writer.Append(UF + "|"); // 2
        writer.Append(DataInicial.ToSpedString() + "|"); // 3
        writer.Append(DataFinal.ToSpedString() + "|"); // 4
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        UF = data[2];
        DataInicial = data[3].ToDate(); // 03
        DataFinal = data[4].ToDate(); // 04
    }

    public string UF { get; set; } = null; // 02
    public DateTime? DataInicial { get; set; } = default; // 03
    public DateTime? DataFinal { get; set; } = default; // 04

    // Registros Filhos
    public RegistroE210 RegistroE210 { get; set; } = null;
}
