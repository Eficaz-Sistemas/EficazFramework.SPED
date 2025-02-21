
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Encerramento do Bloco N
/// </summary>
/// <remarks></remarks>

public class RegistroN990 : Primitives.Registro
{
    public RegistroN990() : base("N990")
    {
    }

    public RegistroN990(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string QuantidadeLinhasBlocoK { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|N990|");
        writer.Append(QuantidadeLinhasBlocoK + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        QuantidadeLinhasBlocoK = data[2];
    }
}
