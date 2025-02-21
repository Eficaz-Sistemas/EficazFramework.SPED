using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Identificação dos Período e Formas de Apuração de IRPJ e da CSLL no Ano-Calendário
/// </summary>
/// <remarks></remarks>

public class RegistroL030 : Primitives.Registro
{
    public RegistroL030() : base("L030")
    {
    }

    public RegistroL030(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public DateTime? DataInicial { get; set; }
    public DateTime? DataFinal { get; set; }
    /// <summary>
    /// A00 – Anual
    /// A01 – Rec. Bruta de janeiro /Balanço suspensão redução até janeiro
    /// A02 – Rec. Bruta de fevereiro /Balanço suspensão redução até fevereiro
    /// A03 – Rec. Bruta de março /Balanço suspensão redução até março
    /// A04 – Rec. Bruta de abril /Balanço suspensão redução até abril
    /// A05 – Rec. Bruta de maio /Balanço suspensão redução até maio
    /// A06 – Rec. Bruta de junho /Balanço suspensão redução até junho
    /// A07 – Rec. Bruta de julho /Balanço suspensão redução até julho
    /// A08 – Rec. Bruta de agosto /Balanço suspensão redução até agosto
    /// A09 – Rec. Bruta de setembro /Balanço suspensão redução até setembro
    /// A10 – Rec. Bruta de outubro/Balanço suspensão redução até outubro
    /// A11 – Rec. Bruta de novembro /Balanço suspensão redução até novembro
    /// A12 – Rec. Bruta de dezembro/Balanço suspensão redução até dezembro
    /// T01 – 1º Trimestre
    /// T02 – 2º Trimestre
    /// T03 – 3º Trimestre
    /// T04 – 4º Trimestre
    /// </summary>
    /// <returns></returns>
    public string Periodo { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|L030|");
        writer.Append(DataInicial.ToSpedString() + "|");
        writer.Append(DataFinal.ToSpedString() + "|");
        writer.Append(Periodo + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DataInicial = data[2].ToDate();
        DataFinal = data[3].ToDate();
        Periodo = data[4];
    }
}
