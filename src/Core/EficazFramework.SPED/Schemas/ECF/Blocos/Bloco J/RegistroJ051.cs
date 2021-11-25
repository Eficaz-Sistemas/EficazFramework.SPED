
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Plano de Contas Referencial
/// </summary>
/// <remarks></remarks>

public class RegistroJ051 : Primitives.Registro
{
    public RegistroJ051() : base("J051")
    {
    }

    public RegistroJ051(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodCentroCusto { get; set; } = null;
    public string CodContaReferencial { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|J051|");
        writer.Append(CodCentroCusto + "|");
        writer.Append(CodContaReferencial + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodCentroCusto = data[3];
        CodContaReferencial = data[4];
    }
}
