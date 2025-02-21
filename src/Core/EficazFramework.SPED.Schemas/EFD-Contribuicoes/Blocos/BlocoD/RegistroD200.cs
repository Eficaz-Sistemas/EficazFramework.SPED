using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Resumo Escrituração Diária Transportes
/// </summary>
/// <remarks></remarks>

public class RegistroD200 : Primitives.Registro
{
    public RegistroD200() : base("D200")
    {
    }

    public RegistroD200(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoModeloDocFiscal { get; set; } = null;
    public string CodigoSituacaoDocFisca { get; set; } = null;
    public string SerieDocFiscal { get; set; } = null;
    public string SubSerieDocFiscal { get; set; } = null;
    public long? NumeroDocFiscalInicial { get; set; }
    public long? NumeroDocFiscalFinal { get; set; }
    public string CFOP { get; set; } = null;
    public DateTime? DataReferenciaResumoDiario { get; set; }
    public double? VrTotalDocsFiscais { get; set; }
    public double? VrTotalDescontos { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D200|");
        writer.Append(CodigoModeloDocFiscal + "|");
        writer.Append(CodigoSituacaoDocFisca + "|");
        writer.Append(SerieDocFiscal + "|");
        writer.Append(SubSerieDocFiscal + "|");
        writer.Append(NumeroDocFiscalInicial + "|");
        writer.Append(NumeroDocFiscalFinal + "|");
        writer.Append(CFOP + "|");
        writer.Append(DataReferenciaResumoDiario + "|");
        writer.Append(VrTotalDocsFiscais + "|");
        writer.Append(VrTotalDescontos + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoModeloDocFiscal = data[2];
        CodigoSituacaoDocFisca = data[3];
        SerieDocFiscal = data[4];
        SubSerieDocFiscal = data[5];
        NumeroDocFiscalInicial = data[6].ToNullableLong();
        NumeroDocFiscalFinal = data[7].ToNullableLong();
        CFOP = data[8];
        DataReferenciaResumoDiario = data[9].ToDate();
        VrTotalDocsFiscais = data[10].ToNullableDouble();
        VrTotalDescontos = data[11].ToNullableDouble();
    }
}
