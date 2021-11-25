using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.CNAB240.Itau;

public class Registro3N_AnexoC_GPS : Registro3N_AnexoC
{
    public Registro3N_AnexoC_GPS()
    {
    }

    public Registro3N_AnexoC_GPS(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("01"); // 1
        writer.Append(CodigoRecolhimento.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Right, " ")); // 2
        writer.Append(string.Format("{0:MMyyyy}", Competencia)); // 3
        writer.Append(CNPJ.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 4
        writer.Append(ValorTributo.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 5
        writer.Append(ValorOutrasEntidades.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 6
        writer.Append(ValorAtualizacaoMonetaria.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 7
        writer.Append(ValorArrecadado.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 8
        writer.Append(string.Format("{0:ddMMyyyy}", DataArrecadacao)); // 9
        writer.Append("        "); // 10
        writer.Append(UsoDaEmpresa.ToFixedLenghtString(50, Escrituracao._builder, Alignment.Right, " ")); // 11
        writer.Append(ContribuinteNome.ToFixedLenghtString(30, Escrituracao._builder, Alignment.Right, " ")); // 12
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        CodigoRecolhimento = linha.Substring(19, 4).Trim();
        Competencia = linha.Substring(23, 6).Trim().ToDate(Extensions.DateFormat.MMAAAA);
        CNPJ = linha.Substring(29, 14).Trim();
        ValorTributo = linha.Substring(43, 14).Trim().ToNullableDouble(2);
        ValorOutrasEntidades = linha.Substring(57, 14).Trim().ToNullableDouble(2);
        ValorAtualizacaoMonetaria = linha.Substring(71, 14).Trim().ToNullableDouble(2);
        ValorArrecadado = linha.Substring(85, 14).Trim().ToNullableDouble(2);
        DataArrecadacao = linha.Substring(99, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
        UsoDaEmpresa = linha.Substring(115, 50).Trim();
        ContribuinteNome = linha.Substring(115, 30).Trim();
    }

    public string CodigoRecolhimento { get; set; }
    public DateTime? Competencia { get; set; }
    public string CNPJ { get; set; }
    public double? ValorTributo { get; set; }
    public double? ValorOutrasEntidades { get; set; }
    public double? ValorAtualizacaoMonetaria { get; set; }
    public double? ValorArrecadado { get; set; }
    public DateTime? DataArrecadacao { get; set; }
    public string UsoDaEmpresa { get; set; }
    public string ContribuinteNome { get; set; }
}
