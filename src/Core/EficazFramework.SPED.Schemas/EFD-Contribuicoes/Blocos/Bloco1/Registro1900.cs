using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Consolidação dos documentos emitidos no período por pessoa jurídica submetida ao regime de tributação com base no lucro presumido - regime de caixa ou de competência
/// </summary>
/// <remarks></remarks>

public class Registro1900 : Primitives.Registro
{
    public Registro1900() : base("1900")
    {
    }

    public Registro1900(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CNPJEstabPJEmitenteDocsGeradoresReceita { get; set; } = null;
    public string CodModDocFiscal { get; set; } = null;
    public string SerieDocFiscal { get; set; } = null;
    public string SubSerieDocFiscal { get; set; } = null;
    public EFD_ICMS_IPI.SituacaoDocumento CodigoSitDocFiscal { get; set; } = EFD_ICMS_IPI.SituacaoDocumento.Regular;
    public double? VrTotalRecConfDocsEmitidosPer { get; set; }
    public int? QtdeDocsEmitidosPeriodo { get; set; }
    public string CSTPis { get; set; } = null;
    public string CSTCofins { get; set; } = null;
    public string CFOP { get; set; } = null;
    public string InfoComplementar { get; set; } = null;
    public string CodigoConta { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|1809|");
        writer.Append(CNPJEstabPJEmitenteDocsGeradoresReceita + "|");
        writer.Append(CodModDocFiscal + "|");
        writer.Append(SerieDocFiscal + "|");
        writer.Append(SubSerieDocFiscal + "|");
        writer.Append(((int)CodigoSitDocFiscal).ToString() + "|");
        writer.Append(VrTotalRecConfDocsEmitidosPer + "|");
        writer.Append(QtdeDocsEmitidosPeriodo + "|");
        writer.Append(CSTPis + "|");
        writer.Append(CSTCofins + "|");
        writer.Append(CFOP + "|");
        writer.Append(InfoComplementar + "|");
        writer.Append(CodigoConta + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CNPJEstabPJEmitenteDocsGeradoresReceita = data[2];
        CodModDocFiscal = data[3];
        SerieDocFiscal = data[4];
        SubSerieDocFiscal = data[5];
        CodigoSitDocFiscal = (EFD_ICMS_IPI.SituacaoDocumento)Conversions.ToInteger(data[6]);
        VrTotalRecConfDocsEmitidosPer = data[7].ToNullableDouble();
        QtdeDocsEmitidosPeriodo = data[8].ToNullableInteger();
        CSTPis = data[9];
        CSTCofins = data[10];
        CFOP = data[11];
        InfoComplementar = data[12];
        CodigoConta = data[13];
    }
}
