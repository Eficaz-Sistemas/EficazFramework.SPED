using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Termo de Encerramento
/// </summary>
/// <remarks></remarks>

public class RegistroJ900 : Primitives.Registro
{
    public RegistroJ900() : base("J900")
    {
    }

    // Campos'
    public string NumeroOrdemLivro { get; set; } = null;
    public string NaturezaLivro { get; set; } = null;
    public string NomeEmpresarial { get; set; } = null;
    public long? QtdeLinhasArquivoTotal { get; set; }
    public DateTime? DataInicioEscrituracao { get; set; }
    public DateTime? DataTerminoEscrituracao { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|J900|TERMO DE ENCERRAMENTO|");
        writer.Append(NumeroOrdemLivro + "|");
        writer.Append(NaturezaLivro + "|");
        writer.Append(NomeEmpresarial + "|");
        writer.Append(QtdeLinhasArquivoTotal + "|");
        writer.Append(DataInicioEscrituracao.ToSpedString() + "|");
        writer.Append(DataTerminoEscrituracao.ToSpedString() + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        NumeroOrdemLivro = data[3];
        NaturezaLivro = data[4];
        NomeEmpresarial = data[5];
        QtdeLinhasArquivoTotal = data[6].ToNullableLong();
        DataInicioEscrituracao = data[7].ToDate();
        DataTerminoEscrituracao = data[8].ToDate();
    }
}
