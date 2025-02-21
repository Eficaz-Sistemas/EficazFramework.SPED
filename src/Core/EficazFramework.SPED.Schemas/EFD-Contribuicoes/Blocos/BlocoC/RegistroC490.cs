using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Consolidação de Documentos Fiscais
/// </summary>
/// <remarks></remarks>

public class RegistroC490 : Primitives.Registro
{
    public RegistroC490() : base("C490")
    {
    }

    public RegistroC490(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public DateTime? DataEmissaoInicialDocs { get; set; }
    public DateTime? DataEmissaoFinalDocs { get; set; }
    public string CodigoModeloDocFiscal { get; set; } = null;
    public List<RegistroC491> RegistrosC491 { get; set; } = new List<RegistroC491>();
    public List<RegistroC495> RegistrosC495 { get; set; } = new List<RegistroC495>();
    public List<RegistroC499> RegistrosC499 { get; set; } = new List<RegistroC499>();

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C490|");
        writer.Append(DataEmissaoInicialDocs + "|");
        writer.Append(DataEmissaoFinalDocs + "|");
        writer.Append(CodigoModeloDocFiscal + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DataEmissaoInicialDocs = data[2].ToDate();
        DataEmissaoFinalDocs = data[3].ToDate();
        CodigoModeloDocFiscal = data[4];
    }
}
