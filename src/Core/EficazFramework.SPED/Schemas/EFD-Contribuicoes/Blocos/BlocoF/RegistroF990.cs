
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Encerramento do BlocoF
/// </summary>
/// <remarks></remarks>

public class RegistroF990 : Primitives.Registro
{
    public RegistroF990() : base("F990")
    {
    }

    public RegistroF990(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string QuantidadeLinhasBlocoF { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|F990|");
        writer.Append(QuantidadeLinhasBlocoF + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        QuantidadeLinhasBlocoF = data[2];
    }
}
