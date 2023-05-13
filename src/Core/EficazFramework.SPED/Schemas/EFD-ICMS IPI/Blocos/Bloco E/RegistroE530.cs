using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Ajustes de Apuração do IPI
/// </summary>
/// <remarks></remarks>
public class RegistroE530 : Primitives.Registro
{
    public RegistroE530() : base("E530")
    {
    }

    public RegistroE530(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|E530|"); // 1
        writer.Append($"{(int)IndicadorAjuste}" + "|"); // 2
        writer.Append(string.Format("{0:0.##}", ValorAjuste) + "|"); // 3
        writer.Append(CodigoAjuste + "|"); // 4
        writer.Append($"{(int)Origem}" + "|"); // 5
        writer.Append(NumeroDocumento + "|"); // 6
        writer.Append(Descricao + "|"); // 7
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorAjuste = (IndicadorAjusteIPI)data[2].ToEnum<IndicadorAjusteIPI>(IndicadorAjusteIPI.Debito);
        ValorAjuste = data[3].ToNullableDouble();
        CodigoAjuste = data[4];
        Origem = (IndicadorOrigemAjusteIPI)data[5].ToEnum<IndicadorOrigemAjusteIPI>(IndicadorOrigemAjusteIPI.Outros);
        NumeroDocumento = data[6];
        Descricao = data[7];
    }

    public IndicadorAjusteIPI IndicadorAjuste { get; set; } = IndicadorAjusteIPI.Debito; // 2
    public double? ValorAjuste { get; set; } = default; // 3
    public string CodigoAjuste { get; set; } = default; // 4
    public IndicadorOrigemAjusteIPI Origem { get; set; } = IndicadorOrigemAjusteIPI.Outros; // 5
    public string NumeroDocumento { get; set; } = default; // 6
    public string Descricao { get; set; } = default; // 7
}
