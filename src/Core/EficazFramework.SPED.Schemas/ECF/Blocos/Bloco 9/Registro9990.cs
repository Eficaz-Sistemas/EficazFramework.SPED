
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Encerramento do Bloco 9
/// </summary>
/// <remarks></remarks>

public class Registro9990 : Primitives.Registro
{
    public Registro9990() : base("9990")
    {
    }

    public Registro9990(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string TotalLinhas { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|9990|");
        writer.Append(TotalLinhas + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        TotalLinhas = data[2];
    }
}
