using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Resumo Mensal do Demonstrativo do Resultado da Atividade Rural
/// </summary>
/// <remarks>
/// Nível hierárquico - 2 <br/>
/// Ocorrência - 0:N  <br/>
/// O campo <see cref="SaldoFinal"/> registra o saldo cumulativo até o mês, ou seja, 
/// registra o saldo dos lançamentos do mês acrescido do saldo final do mês 
/// imediatamente anterior da declaração.
/// </remarks>
/// <registrosped/>
/// <example>
/// ```csharp
/// string _versao = "0013";
/// var regQ200 = new RegistroQ200(null, _versao)
/// {
///     Competencia = new System.DateTime(2021, 1, 1),
///     ValorEntrada = 1500d,
///     ValorSaida = 250d,
///     SaldoFinal = 1250d,
///     SaldoFinal_Natureza = "P"
/// };
/// ```
/// </example>
public class RegistroQ200 : Primitives.Registro
{
    /// <exclude />
    public RegistroQ200() : base("Q200")
    {
    }

    /// <exclude />
    public RegistroQ200(string linha, string versao) : base(linha, versao)
    {
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        Competencia = data[1].ToDate(DateFormat.MMAAAA);
        ValorEntrada = data[2].ToNullableDouble(2);
        ValorSaida = data[3].ToNullableDouble(2);
        SaldoFinal = data[4].ToNullableDouble(2);
        SaldoFinal_Natureza = data[5];
    }

    /// <summary>
    /// Mês e ano da Entrada ou Saída de Recursos (MMAAAA)
    /// </summary>
    public DateTime? Competencia { get; set; } = default;

    /// <summary>
    /// Valor Total da Entrada Recursos no mês (P)
    /// </summary>
    public double? ValorEntrada { get; set; } = default;

    /// <summary>
    /// Valor Total da Saída de Recursos no mês (N)
    /// </summary>
    public double? ValorSaida { get; set; } = default;

    /// <summary>
    /// Saldo Final até o mês (P / N)
    /// </summary>
    public double? SaldoFinal { get; set; } = default;

    /// <summary>
    ///  Natureza do Saldo Final do mês [N/P]
    /// </summary>
    public string SaldoFinal_Natureza { get; set; } = null;
}
