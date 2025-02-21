using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.Sintegra;

public class Registro54 : Primitives.Registro
{
    public Registro54(string linha, string versao) : base(linha, versao)
    {
    }

    public Registro54() : base("54")
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("54"); // 1
        writer.Append(CNPJ.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 2
        writer.Append(Modelo.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 3
        writer.Append(Serie.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Right, " ")); // 4
        writer.Append(Numero.ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 5
        writer.Append(CFOP.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 6
        writer.Append(CST.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 7
        writer.Append(NumeroItem.ValueToString().ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 8
        writer.Append(CodigoProduto.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 9
        writer.Append(Quantidade.ValueToString(3).ToFixedLenghtString(11, Escrituracao._builder, Alignment.Left, "0")); // 11
        writer.Append(ValorProduto.ValueToString(2).ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 11
        writer.Append(Desconto.ValueToString(2).ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 12
        writer.Append(BaseCalculo.ValueToString(2).ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 12
        writer.Append(BaseCalculoST.ValueToString(2).ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 12
        writer.Append(IPI.ValueToString(2).ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 12
        writer.Append(ICMS_Aliquota.ValueToString(2).ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 12
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        CNPJ = linha.Substring(2, 14).Trim();
        Modelo = linha.Substring(16, 2).Trim();
        Serie = linha.Substring(18, 3).Trim();
        Numero = linha.Substring(21, 6).Trim();
        CFOP = linha.Substring(27, 4).Trim();
        CST = linha.Substring(31, 3).Trim();
        NumeroItem = linha.Substring(34, 3).ToNullableInteger();
        CodigoProduto = linha.Substring(37, 14).Trim();
        Quantidade = linha.Substring(51, 11).ToNullableDouble(3);
        ValorProduto = linha.Substring(62, 12).ToNullableDouble(2);
        Desconto = linha.Substring(74, 12).ToNullableDouble(2);
        BaseCalculo = linha.Substring(86, 12).ToNullableDouble(2);
        BaseCalculoST = linha.Substring(98, 12).ToNullableDouble(2);
        IPI = linha.Substring(110, 12).ToNullableDouble(2);
        ICMS_Aliquota = linha.Substring(122, 4).ToNullableDouble(2);
    }

    public string CNPJ { get; set; }
    public string Modelo { get; set; }
    public string Serie { get; set; }
    public string Numero { get; set; }
    public string CFOP { get; set; }
    public string CST { get; set; }
    public int? NumeroItem { get; set; }
    public string CodigoProduto { get; set; }
    public double? Quantidade { get; set; }
    public double? ValorProduto { get; set; }
    public double? Desconto { get; set; }
    public double? BaseCalculo { get; set; }
    public double? BaseCalculoST { get; set; }
    public double? IPI { get; set; }
    public double? ICMS_Aliquota { get; set; }
}
