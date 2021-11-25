using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.Sintegra;

/// <summary>
/// 60 Analítico: Identificação da Situação Tributária no final do dia de cada ECF
/// </summary>
/// <remarks></remarks>
public class Registro60A : Primitives.Registro
{
    public Registro60A(string linha, string versao) : base(linha, versao)
    {
    }

    public Registro60A() : base("60A")
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("60A"); // 1 & 2
        writer.Append(DataEmissao.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3
        writer.Append(NumeroSerieFabEquip.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 4
        writer.Append(SituacaoTributariaAliquota.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Right, " ")); // 5
        writer.Append(ValorAcumulado.ValueToString(2).ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 6
        writer.Append(Brancos.ToFixedLenghtString(79, Escrituracao._builder, Alignment.Right, " ")); // 7
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        DataEmissao = linha.Substring(3, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
        NumeroSerieFabEquip = linha.Substring(11, 20).Trim();
        SituacaoTributariaAliquota = linha.Substring(31, 4).Trim();
        ValorAcumulado = linha.Substring(35, 12).Trim().ToNullableDouble(2);
        Brancos = linha.Substring(47, 79).Trim();
    }

    public DateTime? DataEmissao { get; set; }
    public string NumeroSerieFabEquip { get; set; }
    public string SituacaoTributariaAliquota { get; set; }
    public double? ValorAcumulado { get; set; }
    public string Brancos { get; set; }
}
