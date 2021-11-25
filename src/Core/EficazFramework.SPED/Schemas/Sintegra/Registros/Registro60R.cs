using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.Sintegra;

/// <summary>
/// 60 Resumo: Total por mercadoria/produto no mês
/// </summary>
/// <remarks></remarks>
public class Registro60R : Primitives.Registro
{
    public Registro60R(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("60R"); // 1 & 2
        writer.Append(Competencia.ToSintegraString(Extensions.DateFormat.MMAAAA)); // 3
        writer.Append(CodigoProduto.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 5
        writer.Append(Quantidade.ValueToString().ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 6
        writer.Append(ValorLiquido.ValueToString().ToFixedLenghtString(16, Escrituracao._builder, Alignment.Left, "0")); // 7
        writer.Append(BaseCalculo.ValueToString().ToFixedLenghtString(16, Escrituracao._builder, Alignment.Left, "0")); // 8
        writer.Append(SituacaoTributariaAliquota.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Right, " ")); // 9
        writer.Append(Brancos.ToFixedLenghtString(54, Escrituracao._builder, Alignment.Right, " ")); // 11
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        Competencia = linha.Substring(3, 6).Trim().ToDate(Extensions.DateFormat.MMAAAA);
        CodigoProduto = linha.Substring(9, 14).Trim();
        Quantidade = linha.Substring(23, 13).ToNullableDouble(3);
        ValorLiquido = linha.Substring(36, 16).ToNullableDouble(2);
        BaseCalculo = linha.Substring(52, 16).ToNullableDouble(2);
        SituacaoTributariaAliquota = linha.Substring(68, 4).Trim();
        Brancos = linha.Substring(72, 19).Trim();
    }

    public DateTime? Competencia { get; set; }
    public string CodigoProduto { get; set; }
    public double? Quantidade { get; set; }
    public double? ValorLiquido { get; set; }
    public double? BaseCalculo { get; set; }
    public string SituacaoTributariaAliquota { get; set; }
    public string Brancos { get; set; }
}
