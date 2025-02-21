using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.Sintegra;

/// <summary>
/// Dados do produto ou serviço
/// </summary>
/// <remarks></remarks>
public class Registro75 : Primitives.Registro
{
    public Registro75(string linha, string versao) : base(linha, versao)
    {
    }

    public Registro75() : base("75")
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("75"); // 1
        writer.Append(DataInicial.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 2
        writer.Append(DataFinal.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3
        writer.Append(CodigoProduto.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 4
        writer.Append(CodigoNCM.ToFixedLenghtString(8, Escrituracao._builder, Alignment.Right, " ")); // 5
        writer.Append(Descricao.ToFixedLenghtString(53, Escrituracao._builder, Alignment.Right, " ")); // 6
        writer.Append(UnidadeMedida.ToFixedLenghtString(6, Escrituracao._builder, Alignment.Right, " ")); // 7
        writer.Append(AliquotaIPI.ValueToString().ToFixedLenghtString(5, Escrituracao._builder, Alignment.Left, "0")); // 8
        writer.Append(AliquotaICMS.ValueToString().ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 9
        writer.Append(ReducaoBaseCalculoPercentual.ValueToString().ToFixedLenghtString(5, Escrituracao._builder, Alignment.Left, "0")); // 10
        writer.Append(BaseCalculoICMSST.ValueToString().ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 11
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        DataInicial = linha.Substring(2, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
        DataFinal = linha.Substring(10, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
        CodigoProduto = linha.Substring(18, 14).Trim();
        CodigoNCM = linha.Substring(32, 8).Trim();
        Descricao = linha.Substring(40, 53).Trim();
        UnidadeMedida = linha.Substring(93, 6).Trim();
        AliquotaIPI = linha.Substring(99, 5).ToNullableDouble(2);
        AliquotaICMS = linha.Substring(104, 4).ToNullableDouble(2);
        ReducaoBaseCalculoPercentual = linha.Substring(108, 5).ToNullableDouble(2);
        BaseCalculoICMSST = linha.Substring(113, 13).ToNullableDouble(2);
    }

    public DateTime? DataInicial { get; set; }
    public DateTime? DataFinal { get; set; }
    public string CodigoProduto { get; set; }
    public string CodigoNCM { get; set; }
    public string Descricao { get; set; }
    public string UnidadeMedida { get; set; }
    public double? AliquotaIPI { get; set; }
    public double? AliquotaICMS { get; set; }
    public double? ReducaoBaseCalculoPercentual { get; set; }
    public double? BaseCalculoICMSST { get; set; }
}
