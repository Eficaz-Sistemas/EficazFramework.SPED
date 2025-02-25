// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Itens Produzidos
/// </summary>
/// <remarks></remarks>
public class Registrok230 : Primitives.Registro
{
    public Registrok230(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|K230|"); // 1
        writer.Append(DataInicio.ToSpedString() + "|"); // 2
        writer.Append(DataFim.ToSpedString() + "|"); // 3
        writer.Append(CodigoRelatorio.Trim() + "|"); // 4
        writer.Append(CodigoProduto.Trim() + "|"); // 5
        writer.Append(Quantidade.ValueToString(3) + "|"); // 6
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DataInicio = data[2].ToDate();
        DataFim = data[3].ToDate();
        CodigoRelatorio = data[4];
        CodigoRelatorio = data[5];
        Quantidade = data[6].ToNullableDouble(3);
        if (data.Length > 7)
            Custo = data[6].ToNullableDouble(2);
        if (data.Length > 8)
            ICMS = data[7].ToNullableDouble(2);
        if (data.Length > 9)
            IPI = data[8].ToNullableDouble(2);
        if (data.Length > 10)
            PIS = data[9].ToNullableDouble(2);
        if (data.Length > 11)
            COFINS = data[10].ToNullableDouble(2);
    }

    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public string CodigoRelatorio { get; set; }
    public string CodigoProduto { get; set; }
    public double? Quantidade { get; set; }

    // // Navigation Properties
    public List<RegistroK235> RegistrosK235 { get; set; } = new List<RegistroK235>();

    // // Extra Properties (Integration Pack)
    public double? Custo { get; set; }
    public double? ICMS { get; set; }
    public double? IPI { get; set; }
    public double? PIS { get; set; }
    public double? COFINS { get; set; }
}
