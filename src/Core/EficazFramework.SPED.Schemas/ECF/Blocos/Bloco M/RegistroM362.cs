
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Números dos Lançamentos Relacionados à Conta Contábil
/// </summary>
/// <remarks></remarks>

public class RegistroM362 : Primitives.Registro
{
    public RegistroM362() : base("M362")
    {
    }

    public RegistroM362(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string NumeroLancto { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M362|");
        writer.Append(NumeroLancto + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
