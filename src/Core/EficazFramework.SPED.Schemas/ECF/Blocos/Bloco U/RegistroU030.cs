using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Identificação dos Períodos e Formas de Apuração do IRPJ e da CSLL das Empresas Imunes e Isentas
/// </summary>
/// <remarks></remarks>

public class RegistroU030 : Primitives.Registro
{
    public RegistroU030() : base("U030")
    {
    }

    public RegistroU030(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public DateTime? DataInicial { get; set; }
    public DateTime? DataFinal { get; set; }
    /// <summary>
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
        writer.Append("|U030|");
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
