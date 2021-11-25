
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Encerramento do Bloco Y
/// </summary>
/// <remarks></remarks>

public class RegistroY990 : Primitives.Registro
{
    public RegistroY990() : base("Y990")
    {
    }

    public RegistroY990(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string QuantidadeLinhasBlocoK { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|Y990|");
        writer.Append(QuantidadeLinhasBlocoK + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        QuantidadeLinhasBlocoK = data[2];
    }
}
