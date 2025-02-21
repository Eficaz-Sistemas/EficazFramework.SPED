// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Insumos Consumidos
/// </summary>
/// <remarks></remarks>
public class RegistroK235 : Primitives.Registro
{
    public RegistroK235(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|K235|"); // 1
        writer.Append(DataSaida.ToSpedString() + "|"); // 2
        writer.Append(CodigoInsumo.Trim() + "|"); // 3
        writer.Append(Quantidade.ValueToString(3) + "|"); // 4
        writer.Append(CodigoInsumoSubstituido.Trim() + "|"); // 5
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DataSaida = data[2].ToDate();
        CodigoInsumo = data[3];
        Quantidade = data[4].ToNullableDouble(3);
        CodigoInsumoSubstituido = data[5];
        if (data.Length > 6)
            Custo = data[6].ToNullableDouble(2);
        if (data.Length > 7)
            ICMS = data[7].ToNullableDouble(2);
        if (data.Length > 8)
            IPI = data[8].ToNullableDouble(2);
        if (data.Length > 9)
            PIS = data[9].ToNullableDouble(2);
        if (data.Length > 10)
            COFINS = data[10].ToNullableDouble(2);
    }

    public DateTime? DataSaida { get; set; }
    public string CodigoInsumo { get; set; }
    public double? Quantidade { get; set; }
    public string CodigoInsumoSubstituido { get; set; }

    // // Extra Properties (Integration Pack)
    public double? Custo { get; set; }
    public double? ICMS { get; set; }
    public double? IPI { get; set; }
    public double? PIS { get; set; }
    public double? COFINS { get; set; }
}
