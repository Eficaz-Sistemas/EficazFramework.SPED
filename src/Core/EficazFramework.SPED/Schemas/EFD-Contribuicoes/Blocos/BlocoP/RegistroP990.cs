
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Encerramento do BlocoP
/// </summary>
/// <remarks></remarks>

public class RegistroP990 : Primitives.Registro
{
    public RegistroP990() : base("P990")
    {
    }

    public RegistroP990(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string QuantidadeLinhasBlocoP { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|P990|");
        writer.Append(QuantidadeLinhasBlocoP + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        QuantidadeLinhasBlocoP = data[2];
    }
}
