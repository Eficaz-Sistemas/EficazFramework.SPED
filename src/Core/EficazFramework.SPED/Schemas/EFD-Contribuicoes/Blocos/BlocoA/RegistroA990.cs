
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Encerramento do BlocoA
/// </summary>
/// <remarks></remarks>

public class RegistroA990 : Primitives.Registro
{
    public RegistroA990() : base("A990")
    {
    }

    public RegistroA990(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string QuantidadeLinhasBlocoA { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new global::System.Text.StringBuilder();
        writer.Append("|A990|");
        writer.Append(QuantidadeLinhasBlocoA + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        QuantidadeLinhasBlocoA = data[2];
    }
}
