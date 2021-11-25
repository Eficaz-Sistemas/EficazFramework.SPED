using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Saldo das Contas de Resultado Antes do Encerramento - Identificação da Data
/// </summary>
/// <remarks></remarks>

public class RegistroI350 : Primitives.Registro
{
    public RegistroI350() : base("I350")
    {
    }

    public RegistroI350(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public DateTime? DataApuracaoResultado { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|I350|");
        writer.Append(DataApuracaoResultado.ToSpedString() + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DataApuracaoResultado = data[2].ToDate();
    }
}
