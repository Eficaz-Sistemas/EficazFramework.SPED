using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Plano de Contas Referencial
/// </summary>
/// <remarks></remarks>

public class RegistroI051 : Primitives.Registro
{
    public RegistroI051() : base("I051")
    {
    }

    public RegistroI051(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodInstRespPlanoContasRef { get; set; } = null;
    public string CodCentroCusto { get; set; } = null;
    public string CodContaReferencial { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|I051|");
        if (Conversions.ToInteger(Versao) / 100d == 7d)
            writer.Append(CodInstRespPlanoContasRef + "|");
        writer.Append(CodCentroCusto + "|");
        writer.Append(CodContaReferencial + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodInstRespPlanoContasRef = data[2];
        CodCentroCusto = data[3];
        CodContaReferencial = data[4];
    }
}
