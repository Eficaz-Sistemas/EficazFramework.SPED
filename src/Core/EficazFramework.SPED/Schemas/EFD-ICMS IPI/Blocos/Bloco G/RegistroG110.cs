using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// ICMS - Ativo Permanente - CIAP
/// </summary>
/// <remarks></remarks>
public class RegistroG110 : Primitives.Registro
{
    public RegistroG110() : base("G110")
    {
    }

    public RegistroG110(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|G110|"); // 01
        writer.Append(DataInicial.ToSpedString() + "|"); // 02
        writer.Append(DataFinal.ToSpedString() + "|"); // 03
        writer.Append(string.Format("{0:0.##}", SaldoInicial) + "|"); // 04
        writer.Append(string.Format("{0:0.##}", SomatoriosParcelas) + "|"); // 05
        writer.Append(string.Format("{0:0.##}", SaidasTributadasOuExportacao) + "|"); // 06
        writer.Append(string.Format("{0:0.##}", TotalSaidas) + "|"); // 07
        writer.Append(string.Format("{0:0.########}", IndiceParticipacao) + "|"); // 08
        writer.Append(string.Format("{0:0.##}", ICMSApropriado) + "|"); // 09
        writer.Append(string.Format("{0:0.##}", SomaICMSOutrosCreditos) + "|"); // 10
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DataInicial = data[2].ToDate();
        DataFinal = data[3].ToDate();
        SaldoInicial = data[4].ToNullableDouble();
        SomatoriosParcelas = data[5].ToNullableDouble();
        SaidasTributadasOuExportacao = data[6].ToNullableDouble();
        TotalSaidas = data[7].ToNullableDouble();
        IndiceParticipacao = data[8].ToNullableDouble();
        ICMSApropriado = data[9].ToNullableDouble();
        SomaICMSOutrosCreditos = data[10].ToNullableDouble();
    }

    public DateTime? DataInicial { get; set; } = default; // 02
    public DateTime? DataFinal { get; set; } = default; // 03
    public double? SaldoInicial { get; set; } = default; // 04
    /// <summary>
    /// Correspondente ao campo 10 do Registro G125
    /// </summary>
    public double? SomatoriosParcelas { get; set; } = default; // 05
    public double? SaidasTributadasOuExportacao { get; set; } = default; // 06
    public double? TotalSaidas { get; set; } = default; // 07
    public double? IndiceParticipacao { get; set; } = default; // 08
    public double? ICMSApropriado { get; set; } = default; // 09
    /// <summary>
    /// Correspondente ao campo 09 do Registro G126
    /// </summary>
    public double? SomaICMSOutrosCreditos { get; set; } = default; // 10


    // Navigation
    public List<RegistroG125> RegistrosG125 { get; set; } = new List<RegistroG125>();
}
