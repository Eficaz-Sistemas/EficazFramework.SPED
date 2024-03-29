﻿
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Encerramento do Bloco X
/// </summary>
/// <remarks></remarks>

public class RegistroX990 : Primitives.Registro
{
    public RegistroX990() : base("X990")
    {
    }

    public RegistroX990(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string QuantidadeLinhasBlocoK { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|X990|");
        writer.Append(QuantidadeLinhasBlocoK + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        QuantidadeLinhasBlocoK = data[2];
    }
}
