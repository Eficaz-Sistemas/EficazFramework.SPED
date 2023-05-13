using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Informações Adicionais dos Ajustes da Apuração do IPI - Identificação dos 
/// Documentos Fiscais (01 e 55)
/// </summary>
/// <remarks></remarks>
public class RegistroE531 : Primitives.Registro
{
    public RegistroE531() : base("E531")
    {
    }

    public RegistroE531(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|E531|"); // 1
        writer.Append(this.CodigoParticipante + "|"); // 2
        writer.Append(this.EspecieDocumento + "|"); // 3
        writer.Append(this.Serie.ToFixedLenghtString(3, Alignment.Left, "0") + "|"); // 4
        writer.Append(this.SubSerie + "|"); // 5
        writer.Append(this.Numero + "|"); // 6
        writer.Append(this.DataEmissao.ToSpedString() + "|"); // 7
        writer.Append(this.CodigoProduto + "|"); // 8
        writer.Append(string.Format("{0:0.##}", this.ValorAjuste) + "|"); // 9
        writer.Append(this.ChaveNFe + "|"); // 10
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoParticipante = data[2];
        EspecieDocumento = data[3];
        Serie = data[4];
        SubSerie = data[5];
        Numero = data[6].ToNullableInteger();
        DataEmissao = data[7].ToDate();
        CodigoProduto = data[8];
        ValorAjuste = data[9].ToNullableDouble();
        ChaveNFe = data[10];
    }

    public string CodigoParticipante { get; set; } = null; // 2
    public string EspecieDocumento { get; set; } = null; // 3
    public string Serie { get; set; } = null; // 4
    public string SubSerie { get; set; } = null; // 5
    public int? Numero { get; set; } = null; // 6
    public DateTime? DataEmissao { get; set; } = null; // 7
    public string CodigoProduto { get; set; } = null; // 8
    public double? ValorAjuste { get; set; } = null; // 9
    public string ChaveNFe { get; set; } = null; // 10
}
