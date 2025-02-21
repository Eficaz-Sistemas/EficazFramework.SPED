using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.CNAB240.Febraban;

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
        writer.Append(CodigoRecolhimento.ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 1
        writer.Append(TipoInscricao.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Left, "0")); // 2
        writer.Append(CNPJ.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 3
        writer.Append(IdentificacaoTributo.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 4
        writer.Append(string.Format("{0:MMyyyy}", Competencia)); // 5
        writer.Append(ValorTributo.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 6
        writer.Append(ValorOutrasEntidades.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 7
        writer.Append(ValorAtualizacaoMonetaria.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 8
        writer.Append("".ToFixedLenghtString(45, Escrituracao._builder, Alignment.Right, " ")); // 9
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        CodigoRecolhimento = linha.Substring(110, 6).Trim();
        TipoInscricao = linha.Substring(116, 2).Trim();
        CNPJ = linha.Substring(118, 14).Trim();
        IdentificacaoTributo = linha.Substring(132, 2).Trim();
        Competencia = linha.Substring(134, 6).Trim().ToDate(Extensions.DateFormat.MMAAAA);
        ValorTributo = linha.Substring(140, 13).Trim().ToNullableDouble(2);
        ValorOutrasEntidades = linha.Substring(155, 13).Trim().ToNullableDouble(2);
        ValorAtualizacaoMonetaria = linha.Substring(170, 13).Trim().ToNullableDouble(2);
    }

    public string CodigoRecolhimento { get; set; }
    /// <summary>
    /// 1 = CNPJ [Default]
    /// 2 = CPF
    /// 3 = NIT/PIS/PASEP
    /// 4 = CEI
    /// 6 = NB
    /// 7 = Núm. Título
    /// 8 = DEBCAD
    /// 9 = Referencia
    /// </summary>
    public string TipoInscricao { get; set; } = "1";
    public string CNPJ { get; set; }
    public string IdentificacaoTributo { get; set; } = "17";
    public DateTime? Competencia { get; set; }
    public double? ValorTributo { get; set; }
    public double? ValorOutrasEntidades { get; set; }
    public double? ValorAtualizacaoMonetaria { get; set; }
}
