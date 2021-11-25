using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.MG.DAPI;

/// <summary>
/// Detalhamento de Créditos Recebidos no Campo 66
/// </summary>
public class Registro20 : Primitives.Registro
{
    public Registro20() : base("20")
    {
    }

    public Registro20(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("20"); // 1 Código Registro
        writer.Append(InscricaoEstadual.ToFixedLenghtString(13, Alignment.Left, "0")); // 2 IE do Contribuinte
        writer.Append(DataFinal.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3 Competencia no Formato AAAAMMDD
        writer.Append(DataInicial.ToSintegraString(Extensions.DateFormat.DD)); // 4 Competencia no Formato DD
        writer.Append(ProdutorRural.ToFixedLenghtString(1, Alignment.Left, "0")); // 5 
        writer.Append(UF_Remetente.ToFixedLenghtString(2, Alignment.Left, "0")); // 6 
        writer.Append(IE_Rementete.ToFixedLenghtString(15, Alignment.Left, "0")); // 7
        writer.Append(NotaFiscal_Numero.ToFixedLenghtString(9, Alignment.Left, "0")); // 8
        writer.Append(NotaFiscal_Serie.ToFixedLenghtString(3, Alignment.Left, "0")); // 9
        writer.Append(NotaFiscal_Data.ToSintegraString(Extensions.DateFormat.AAAADDMM)); // 10
        writer.Append(NotaFiscal_DataVisto.ToSintegraString(Extensions.DateFormat.AAAADDMM)); // 11
        writer.Append(ValorDeclarado.ValueToString(2).ToFixedLenghtString(15, Alignment.Left, "0")); // 12
        writer.Append(Motivo.ToString().ToFixedLenghtString(2, Alignment.Left, "0")); // 8
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
    }

    public string InscricaoEstadual { get; set; } = null;
    public DateTime? DataFinal { get; set; } = default;
    public DateTime? DataInicial { get; set; } = default;
    /// <summary>
    /// Informar SEMPRE "N" a partir da versao 8.02.00
    /// </summary>
    /// <returns></returns>
    public string ProdutorRural { get; set; } = "N";
    public string UF_Remetente { get; set; } = null;
    public string IE_Rementete { get; set; } = null;
    public string NotaFiscal_Numero { get; set; } = null;
    public string NotaFiscal_Serie { get; set; } = null;
    public DateTime? NotaFiscal_Data { get; set; } = default;
    public DateTime? NotaFiscal_DataVisto { get; set; } = default;
    public double? ValorDeclarado { get; set; } = default;
    public short Motivo { get; set; } = 0;
}
