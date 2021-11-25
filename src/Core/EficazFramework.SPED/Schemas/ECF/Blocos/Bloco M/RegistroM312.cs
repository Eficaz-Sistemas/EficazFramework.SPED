
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Números dos Lançamentos Relacionados à Conta Contábil
/// </summary>
/// <remarks></remarks>

public class RegistroM312 : Primitives.Registro
{
    public RegistroM312() : base("M312")
    {
    }

    public RegistroM312(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string NumeroLancto { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M312|");
        writer.Append(NumeroLancto + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
