using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Demonstração da Atividade Rural
/// </summary>
/// <remarks></remarks>
public class RegistroQ200 : Primitives.Registro
{
    public RegistroQ200() : base("Q200")
    {
    }

    public RegistroQ200(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("Q200|"); // 1
        writer.Append(string.Format("{0:MMyyyy}", Competencia) + "|");  // 2
        writer.Append(ValorEntrada.ValueToString(2) + "|"); // 3
        writer.Append(ValorSaida.ValueToString(2) + "|"); // 4
        writer.Append(SaldoFinal.ValueToString(2) + "|"); // 5
        writer.Append(SaldoFinal_Natureza); // 6
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }

    public DateTime? Competencia { get; set; } = default;
    public double? ValorEntrada { get; set; } = default;
    public double? ValorSaida { get; set; } = default;
    public double? SaldoFinal { get; set; } = default;
    /// <summary>
    /// [N/P]
    /// </summary>
    public string SaldoFinal_Natureza { get; set; } = null;
}
