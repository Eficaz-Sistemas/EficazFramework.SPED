using EficazFramework.SPED.Extensions;
using System;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Identificação de Períodos Dispensados da Escrituração Fiscal Digital das Contribuições - EFD Contribuições
/// </summary>
/// <remarks></remarks>

public class Registro0120 : Primitives.Registro
{
    public Registro0120() : base("0120")
    {
    }

    public Registro0120(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public DateTime? MesReferencia { get; set; }
    public string InformacaoComplementar { get; set; } // tamanho 90'

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0120|");
        writer.Append(string.Format("{0:MMyyyy}", MesReferencia) + "|");
        writer.Append(InformacaoComplementar + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        MesReferencia = data[2].ToDate();
        InformacaoComplementar = data[3];
    }
}
