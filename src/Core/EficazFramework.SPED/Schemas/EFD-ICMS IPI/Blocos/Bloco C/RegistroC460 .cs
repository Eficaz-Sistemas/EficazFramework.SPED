using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Documento Fiscal emitido por ECF (Código 02, 2D e 60)
/// </summary>
/// <remarks></remarks>
public class RegistroC460 : Primitives.Registro
{
    public RegistroC460() : base("C460")
    {
    }

    public RegistroC460(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C460|"); // 1
        writer.Append(CodigoModelo + "|"); // 2
        writer.Append(string.Format("{0:00}", (int)Situacao) + "|"); // 3
        writer.Append(Numero + "|"); // 4
        writer.Append(Data.ToSpedString() + "|"); // 5
        writer.Append(string.Format("{0:0.##}", ValorTotal) + "|"); // 6
        writer.Append(string.Format("{0:0.##}", ValorPIS) + "|"); // 7
        writer.Append(string.Format("{0:0.##}", ValorCofins) + "|"); // 8
        writer.Append(CNPJ_CPF + "|"); // 9
        writer.Append(NomeAdquirente + "|"); // 10
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoModelo = data[2];
        Situacao = (SituacaoDocumento)data[3].ToEnum<SituacaoDocumento>(SituacaoDocumento.Regular);
        Numero = data[4].ToNullableLong();
        Data = data[5].ToDate();
        ValorTotal = data[6].ToNullableDouble();
        ValorPIS = data[7].ToNullableDouble();
        ValorCofins = data[8].ToNullableDouble();
        CNPJ_CPF = data[9];
        NomeAdquirente = data[10];
    }

    public string CodigoModelo { get; set; } = null; // 2
    public SituacaoDocumento Situacao { get; set; } = SituacaoDocumento.Regular; // 3
    public long? Numero { get; set; } = default;  // 4
    public DateTime? Data { get; set; } = default; // 5
    public double? ValorTotal { get; set; } = default; // 6
    public double? ValorPIS { get; set; } = default; // 7
    public double? ValorCofins { get; set; } = default; // 8
    public string CNPJ_CPF { get; set; } = null; // 9
    public string NomeAdquirente { get; set; } = null; // 10

    // Registros Filhos
    public List<RegistroC470> RegistrosC470 { get; set; } = new List<RegistroC470>();
}
