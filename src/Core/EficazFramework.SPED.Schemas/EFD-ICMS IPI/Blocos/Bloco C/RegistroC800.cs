using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Cupom Fiscal Eletrônico SAT CF-e (59)
/// </summary>
/// <remarks></remarks>
public class RegistroC800 : Primitives.Registro
{
    public RegistroC800() : base("C800")
    {
    }

    public RegistroC800(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C800|"); // 1
        writer.Append(EspecieDocumento + "|"); // 2
        writer.Append(string.Format("{0:00}", (int)SituacaoDocumento) + "|"); // 3
        writer.Append(Numero + "|"); // 4
        if (DocumentoValido())
            writer.Append(DataEmissao.ToSpedString() + "|");
        else
            writer.Append('|'); // 5
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", ValorTotalDocumento) + "|");
        else
            writer.Append('|'); // 6
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", ValorPIS) + "|");
        else
            writer.Append('|'); // 7
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", ValorCofins) + "|");
        else
            writer.Append('|'); // 8
        writer.Append(CNPJ_CPF + "|"); // 9
        writer.Append(string.Format("{0:000000000}", NumeroSerieSAT + "|")); // 10
        writer.Append(ChaveCFe + "|"); // 11
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", ValorDesconto) + "|");
        else
            writer.Append('|'); // 12
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", ValorTotalMercadorias) + "|");
        else
            writer.Append('|'); // 13
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", ValorOutrasDespesas) + "|");
        else
            writer.Append('|'); // 14
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", ValorICMS) + "|");
        else
            writer.Append('|'); // 15
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", ValorPISST) + "|");
        else
            writer.Append('|'); // 16
        if (DocumentoValido())
            writer.Append(string.Format("{0:0.##}", ValorCofinsST) + "|");
        else
            writer.Append('|'); // 17
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        EspecieDocumento = data[2];
        SituacaoDocumento = (SituacaoDocumento)data[3].ToEnum<SituacaoDocumento>(SituacaoDocumento.Cancelado);
        Numero = data[4].ToNullableInteger();
        DataEmissao = data[5].ToDate();
        ValorTotalDocumento = data[6].ToNullableDouble();
        ValorPIS = data[7].ToNullableDouble();
        ValorCofins = data[8].ToNullableDouble();
        CNPJ_CPF = data[9];
        NumeroSerieSAT = data[10].ToNullableInteger();
        ChaveCFe = data[11];
        ValorDesconto = data[12].ToNullableDouble();
        ValorTotalMercadorias = data[13].ToNullableDouble();
        ValorOutrasDespesas = data[14].ToNullableDouble();
        ValorICMS = data[15].ToNullableDouble();
        ValorPISST = data[16].ToNullableDouble();
        ValorCofinsST = data[17].ToNullableDouble();
    }

    public string EspecieDocumento { get; set; } = null; // 2
    public SituacaoDocumento SituacaoDocumento { get; set; } = SituacaoDocumento.Regular; // 3
    public int? Numero { get; set; } = default; // 4
    public DateTime? DataEmissao { get; set; } = default; // 5
    public double? ValorTotalDocumento { get; set; } = default; // 6
    public double? ValorPIS { get; set; } = default; // 7
    public double? ValorCofins { get; set; } = default; // 8
    public string CNPJ_CPF { get; set; } = null; // 9
    public int? NumeroSerieSAT { get; set; } = default; // 10
    public string ChaveCFe { get; set; } = null; // 11
    public double? ValorDesconto { get; set; } = default; // 12
    public double? ValorTotalMercadorias { get; set; } = default; // 13
    public double? ValorOutrasDespesas { get; set; } = default; // 14
    public double? ValorICMS { get; set; } = default; // 15
    public double? ValorPISST { get; set; } = default; // 16
    public double? ValorCofinsST { get; set; } = default; // 17

    // Registros Filhos
    public List<RegistroC850> RegistrosC850 { get; set; } = new List<RegistroC850>();

    public bool DocumentoValido()
    {
        if (SituacaoDocumento == SituacaoDocumento.Cancelado | SituacaoDocumento == SituacaoDocumento.CanceladoExtemporaneo | SituacaoDocumento == SituacaoDocumento.Denegado | SituacaoDocumento == SituacaoDocumento.Inutilizado)
            return false;
        else
            return true;
    }
}
