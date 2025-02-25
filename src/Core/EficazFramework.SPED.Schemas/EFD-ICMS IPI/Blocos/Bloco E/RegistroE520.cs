using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Apuração do IPI
/// </summary>
/// <remarks></remarks>
public class RegistroE520 : Primitives.Registro
{
    public RegistroE520() : base("E520")
    {
    }

    public RegistroE520(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|E520|"); // 1
        writer.Append(string.Format("{0:0.##}", SaldoCredorAnterior) + "|"); // 2
        writer.Append(string.Format("{0:0.##}", Debitos) + "|"); // 3
        writer.Append(string.Format("{0:0.##}", Creditos) + "|"); // 4
        writer.Append(string.Format("{0:0.##}", OutrosDebitos_EstornoCreditos) + "|"); // 5
        writer.Append(string.Format("{0:0.##}", OutrosCreditos_EstornoDebitos) + "|"); // 6
        writer.Append(string.Format("{0:0.##}", SaldoCredorATransportar) + "|"); // 7
        writer.Append(string.Format("{0:0.##}", SaldoDevedor) + "|"); // 8
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        SaldoCredorAnterior = data[2].ToNullableDouble();
        Debitos = data[3].ToNullableDouble();
        Creditos = data[4].ToNullableDouble();
        OutrosDebitos_EstornoCreditos = data[5].ToNullableDouble();
        OutrosCreditos_EstornoDebitos = data[6].ToNullableDouble();
        SaldoCredorATransportar = data[7].ToNullableDouble();
        SaldoDevedor = data[8].ToNullableDouble();
    }

    public double? SaldoCredorAnterior { get; set; } = default; // 2
    public double? Debitos { get; set; } = default; // 3
    public double? Creditos { get; set; } = default; // 4
    public double? OutrosDebitos_EstornoCreditos { get; set; } = default; // 5
    public double? OutrosCreditos_EstornoDebitos { get; set; } = default; // 6
    public double? SaldoCredorATransportar { get; set; } = default; // 7
    public double? SaldoDevedor { get; set; } = default; // 8

}
