using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.MG.DAPI;

/// <summary>
/// Detalhamento de Estorno de Débitos no Campo 95
/// </summary>
public class Registro29 : Primitives.Registro
{
    public Registro29() : base("29")
    {
    }

    public Registro29(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("29"); // 1 Código Registro
        writer.Append(InscricaoEstadual.ToFixedLenghtString(13, Alignment.Left, "0")); // 2 IE do Contribuinte
        writer.Append(DataFinal.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3 Competencia no Formato AAAAMMDD
        writer.Append(DataInicial.ToSintegraString(Extensions.DateFormat.DD)); // 4 Competencia no Formato DD
        writer.Append(((int)Motivo).ToString().ToFixedLenghtString(2, Alignment.Left, "0")); // 5
        writer.Append(AutoInfracao.ToFixedLenghtString(13, Alignment.Right, " ")); // 6
        writer.Append(ValorDeclarado.ValueToString(2).ToFixedLenghtString(15, Alignment.Left, "0")); // 7
        writer.Append(NotaFiscal_Numero.ToFixedLenghtString(9, Alignment.Left, " ")); // 8
        writer.Append(NotaFiscal_Serie.ToFixedLenghtString(3, Alignment.Left, " ")); // 9
        if (NotaFiscal_Data.HasValue)
            writer.Append(NotaFiscal_Data.ToSintegraString(Extensions.DateFormat.AAAADDMM));
        else
            writer.Append("        ");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
    }

    public string InscricaoEstadual { get; set; } = null;
    public DateTime? DataFinal { get; set; } = default;
    public DateTime? DataInicial { get; set; } = default;
    public Registro_29_Motivos Motivo { get; set; } = Registro_29_Motivos.DEmaisEstornos;
    public string AutoInfracao { get; set; } = null;
    public double? ValorDeclarado { get; set; } = default;
    public string NotaFiscal_Numero { get; set; } = null;
    public string NotaFiscal_Serie { get; set; } = null;
    public DateTime? NotaFiscal_Data { get; set; } = default;
}
