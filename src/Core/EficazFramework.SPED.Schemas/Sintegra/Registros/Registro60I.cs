using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.Sintegra;

/// <summary>
/// 60 Item: Registro de mercadoria/produto constante em PDV / ECF
/// </summary>
/// <remarks></remarks>
public class Registro60I : Primitives.Registro
{
    public Registro60I(string linha, string versao) : base(linha, versao)
    {
    }

    public Registro60I() : base("60I")
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("60I"); // 1 & 2
        writer.Append(DataEmissao.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3
        writer.Append(NumeroSerieFabEquip.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 4
        writer.Append(ModeloDocFiscal.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 5
        writer.Append(CCO.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 6
        writer.Append(OrdemItem.ValueToString().ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 7
        writer.Append(CodigoProduto.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 8
        writer.Append(Quantidade.ValueToString().ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 9
        writer.Append(ValorLiquido.ValueToString().ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 10
        writer.Append(BaseCalculo.ValueToString().ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 11
        writer.Append(SituacaoTributariaAliquota.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Right, " ")); // 12
        writer.Append(ICMS.ValueToString().ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 13
        writer.Append(Brancos.ToFixedLenghtString(16, Escrituracao._builder, Alignment.Right, " ")); // 14
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        DataEmissao = linha.Substring(3, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
        NumeroSerieFabEquip = linha.Substring(11, 20).Trim();
        ModeloDocFiscal = linha.Substring(31, 2).Trim();
        CCO = linha.Substring(33, 6).Trim().ToNullableLong();
        OrdemItem = linha.Substring(39, 3).ToNullableShort();
        CodigoProduto = linha.Substring(42, 14).Trim();
        Quantidade = linha.Substring(56, 13).ToNullableDouble(3);
        ValorLiquido = linha.Substring(69, 13).ToNullableDouble(2);
        BaseCalculo = linha.Substring(82, 12).ToNullableDouble(2);
        SituacaoTributariaAliquota = linha.Substring(94, 4).Trim();
        ICMS = linha.Substring(98, 12).Trim().ToNullableDouble(2);
        // Me.Brancos = linha.Substring(110, 16).Trim
    }

    public DateTime? DataEmissao { get; set; }
    public string NumeroSerieFabEquip { get; set; }
    public string ModeloDocFiscal { get; set; }
    public long? CCO { get; set; }
    public short? OrdemItem { get; set; }
    public string CodigoProduto { get; set; }
    public double? Quantidade { get; set; }
    public double? ValorLiquido { get; set; }
    public double? BaseCalculo { get; set; }
    public string SituacaoTributariaAliquota { get; set; }
    public double? ICMS { get; set; }
    public string Brancos { get; set; }
}
