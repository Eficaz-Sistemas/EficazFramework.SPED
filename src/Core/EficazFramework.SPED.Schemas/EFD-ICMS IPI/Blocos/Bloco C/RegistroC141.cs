using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// REGISTRO C141: VENCIMENTO DA FATURA (CÓDIGO 01)
/// </summary>
/// <remarks></remarks>
public class RegistroC141 : Primitives.Registro
{
    public RegistroC141() : base("C141")
    {
    }

    public RegistroC141(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C141|"); // 1
        writer.Append(Numero_Parcela + "|"); // 2
        writer.Append(Data_vecto_parcela.ToSpedString() + "|"); // 3
        writer.Append(string.Format("{0:0.##}", Valor_parcela) + "|"); // 4
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        Numero_Parcela = data[2].ToNullableInteger();
        Data_vecto_parcela = data[3].ToDate();
        Valor_parcela = data[4].ToNullableDouble();
    }

    public int? Numero_Parcela { get; set; } // 2
    public DateTime? Data_vecto_parcela { get; set; } // 3
    public double? Valor_parcela { get; set; } // 4
}
