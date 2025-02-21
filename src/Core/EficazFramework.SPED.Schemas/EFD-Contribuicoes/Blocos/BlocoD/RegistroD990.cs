
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Encerramento do BlocoD
/// </summary>
/// <remarks></remarks>

public class RegistroD990 : Primitives.Registro
{
    public RegistroD990() : base("D990")
    {
    }

    public RegistroD990(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string QuantidadeLinhasBlocoD { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D990|");
        writer.Append(QuantidadeLinhasBlocoD + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        QuantidadeLinhasBlocoD = data[2];
    }
}
