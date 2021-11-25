
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Encerramento do Bloco L
/// </summary>
/// <remarks></remarks>

public class RegistroL990 : Primitives.Registro
{
    public RegistroL990() : base("L990")
    {
    }

    public RegistroL990(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string QuantidadeLinhasBlocoL { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|L990|");
        writer.Append(QuantidadeLinhasBlocoL + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        QuantidadeLinhasBlocoL = data[2];
    }
}
