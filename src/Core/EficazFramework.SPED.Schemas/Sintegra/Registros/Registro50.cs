using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.Sintegra;

public class Registro50 : Primitives.Registro
{
    public Registro50(string linha, string versao) : base(linha, versao)
    {
    }

    public Registro50() : base("50")
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("50"); // 1
        writer.Append(CNPJ.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 2
        writer.Append(InscricaoEstadual.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 3
        writer.Append(Data.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 4
        writer.Append(UF.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 5
        writer.Append(Modelo.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 6
        writer.Append(Serie.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Right, " ")); // 7
        writer.Append(Numero.ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 8
        writer.Append(CFOP.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 9
        if (Emitente == EFD_ICMS_IPI.IndicadorEmitente.Propria)
            writer.Append('P');
        else
            writer.Append('T'); // 10
        writer.Append(ValorTotal.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 11
        writer.Append(BaseCalculo.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 12
        writer.Append(ICMS.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 12
        writer.Append(Isentas.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 12
        writer.Append(Outras.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 12
        writer.Append(Aliquota.ValueToString(2).ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 12
        switch (Situacao)
        {
            case EFD_ICMS_IPI.SituacaoDocumento.Complementar:
            case EFD_ICMS_IPI.SituacaoDocumento.ComplementarExtemporaneo:
            case EFD_ICMS_IPI.SituacaoDocumento.RegimeEspecial:
            case EFD_ICMS_IPI.SituacaoDocumento.Regular:
            case EFD_ICMS_IPI.SituacaoDocumento.RegularExtemporaneo:
                {
                    writer.Append('N');
                    break;
                }

            case EFD_ICMS_IPI.SituacaoDocumento.Pendente:
            case EFD_ICMS_IPI.SituacaoDocumento.Inutilizado:
            case EFD_ICMS_IPI.SituacaoDocumento.Denegado:
            case EFD_ICMS_IPI.SituacaoDocumento.CanceladoExtemporaneo:
            case EFD_ICMS_IPI.SituacaoDocumento.Cancelado:
                {
                    writer.Append('S');
                    break;
                }

            default:
                {
                    writer.Append('S');
                    break;
                }
        }

        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        CNPJ = linha.Substring(2, 14).Trim();
        InscricaoEstadual = linha.Substring(16, 14).Trim();
        Data = linha.Substring(30, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
        UF = linha.Substring(38, 2).Trim();
        Modelo = linha.Substring(40, 2).Trim();
        Serie = linha.Substring(42, 3).Trim();
        Numero = linha.Substring(45, 6).Trim();
        CFOP = linha.Substring(51, 4).Trim();
        string emitentestr = linha.Substring(55, 1);
        if (emitentestr.ToUpper() == "P")
            Emitente = EFD_ICMS_IPI.IndicadorEmitente.Propria;
        else
            Emitente = EFD_ICMS_IPI.IndicadorEmitente.Terceiros;
        ValorTotal = linha.Substring(56, 13).ToNullableDouble(2);
        BaseCalculo = linha.Substring(69, 13).ToNullableDouble(2);
        ICMS = linha.Substring(82, 13).ToNullableDouble(2);
        Isentas = linha.Substring(95, 13).ToNullableDouble(2);
        Outras = linha.Substring(108, 13).ToNullableDouble(2);
        Aliquota = linha.Substring(121, 4).ToNullableDouble(2);
        string sitstr = linha.Substring(125, 1);
        if (sitstr.ToUpper() == "N")
            Situacao = EFD_ICMS_IPI.SituacaoDocumento.Regular;
        else
            Situacao = EFD_ICMS_IPI.SituacaoDocumento.Cancelado;
    }

    public string CNPJ { get; set; }
    public string InscricaoEstadual { get; set; }
    public DateTime? Data { get; set; }
    public string UF { get; set; }
    public string Modelo { get; set; }
    public string Serie { get; set; }
    public string Numero { get; set; }
    public string CFOP { get; set; }
    public EFD_ICMS_IPI.IndicadorEmitente Emitente { get; set; } = EFD_ICMS_IPI.IndicadorEmitente.Terceiros;
    public double? ValorTotal { get; set; }
    public double? BaseCalculo { get; set; }
    public double? ICMS { get; set; }
    public double? Isentas { get; set; }
    public double? Outras { get; set; }
    public double? Aliquota { get; set; }
    public EFD_ICMS_IPI.SituacaoDocumento Situacao { get; set; } = EFD_ICMS_IPI.SituacaoDocumento.Regular;
}
