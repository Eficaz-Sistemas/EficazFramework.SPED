using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Items dos Documentos Fiscais
/// </summary>
/// <remarks></remarks>

public class RegistroC185 : Primitives.Registro
{
    public RegistroC185() : base("C185")
    {
    }

    public RegistroC185(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C185|"); // 1
        writer.Append(NumSequencialItem + "|"); // 2
        writer.Append(CodigoItem + "|"); // 3
        writer.Append(((int)Origem).ToString() + string.Format("{0:00}", (int)CST_ICMS) + "|"); // 4
        writer.Append(CFOP + "|"); // 5
        writer.Append(Cod_Mot_RestCompl + "|"); // 6
        writer.Append(string.Format("{0:0.#####}", Quant_Item) + "|"); // 7 
        writer.Append(UnidadeMedida + "|"); // 8
        writer.Append(string.Format("{0:0.######}", ValorUnitario) + "|"); // 9
        writer.Append(string.Format("{0:0.######}", ValorUnitarioICMS) + "|"); // 10
        writer.Append(string.Format("{0:0.######}", ValorUnitarioICMSEntrada) + "|"); // 11
        writer.Append(string.Format("{0:0.######}", ValorMedioUnitBCICMSST) + "|"); // 12
        writer.Append(string.Format("{0:0.######}", ValorMedioUnitICMSSTFCPST) + "|"); // 13
        writer.Append(string.Format("{0:0.######}", ValorMedioUnitFCPST) + "|"); // 14
        writer.Append(string.Format("{0:0.######}", ValorUnitTotalICMSSTFCPST) + "|"); // 15
        writer.Append(string.Format("{0:0.######}", ValorUnitParcICMSFCPST) + "|"); // 16
        writer.Append(string.Format("{0:0.######}", ValorUnitComplICMSFCPST) + "|"); // 17
        writer.Append(string.Format("{0:0.######}", ValorUnitICMSFCPST) + "|"); // 18
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        NumSequencialItem = data[2].ToNullableInteger();
        CodigoItem = data[3].ToString();
        Origem = (NFe.OrigemMercadoria)data[4][..1].ToEnum<NFe.OrigemMercadoria>(NFe.OrigemMercadoria.Nacional);
        CST_ICMS = (NFe.CST_ICMS)data[4].Substring(1, 2).ToEnum<NFe.CST_ICMS>(NFe.CST_ICMS.CST_00);
        CFOP = data[5].ToString();
        Cod_Mot_RestCompl = data[6].ToString();
        Quant_Item = data[7].ToNullableDouble();
        UnidadeMedida = data[8].ToString();
        ValorUnitario = data[9].ToNullableDouble();
        ValorUnitarioICMS = data[10].ToNullableDouble();
        ValorUnitarioICMSEntrada = data[11].ToNullableDouble();
        ValorMedioUnitBCICMSST = data[12].ToNullableDouble();
        ValorMedioUnitICMSSTFCPST = data[13].ToNullableDouble();
        ValorMedioUnitFCPST = data[14].ToNullableDouble();
        ValorUnitTotalICMSSTFCPST = data[15].ToNullableDouble();
        ValorUnitParcICMSFCPST = data[16].ToNullableDouble();
        ValorUnitComplICMSFCPST = data[17].ToNullableDouble();
        ValorUnitICMSFCPST = data[18].ToNullableDouble();
    }

    public int? NumSequencialItem { get; set; } = default; // 2
    public string CodigoItem { get; set; } = null; // 3
    public NFe.OrigemMercadoria Origem { get; set; } = NFe.OrigemMercadoria.Nacional; // 4
    public NFe.CST_ICMS CST_ICMS { get; set; } = NFe.CST_ICMS.CST_00; // 4
    public string CFOP { get; set; } = null; // 5
    public string Cod_Mot_RestCompl { get; set; } = null; // 6
    public double? Quant_Item { get; set; } = default; // 7
    public string UnidadeMedida { get; set; } = null; // 8
    public double? ValorUnitario { get; set; } = default; // 9
    public double? ValorUnitarioICMS { get; set; } = default; // 10
    public double? ValorUnitarioICMSEntrada { get; set; } = default; // 11
    public double? ValorMedioUnitBCICMSST { get; set; } = default; // 12
    public double? ValorMedioUnitICMSSTFCPST { get; set; } = default; // 13
    public double? ValorMedioUnitFCPST { get; set; } = default; // 14
    public double? ValorUnitTotalICMSSTFCPST { get; set; } = default; // 15
    public double? ValorUnitParcICMSFCPST { get; set; } = default; // 16
    public double? ValorUnitComplICMSFCPST { get; set; } = default; // 17
    public double? ValorUnitICMSFCPST { get; set; } = default; // 18
}
