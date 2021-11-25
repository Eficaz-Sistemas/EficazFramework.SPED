
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Cálculo do IRPJ com Base no Lucro Presumido
/// </summary>
/// <remarks></remarks>

public class RegistroP300 : Primitives.Registro
{
    public RegistroP300() : base("P300")
    {
    }

    public RegistroP300(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string CodigoReferencial { get; set; } = null;
    public string Descricao { get; set; } = null;
    public double? Valor { get; set; } = default;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|P300|");
        writer.Append(CodigoReferencial + "|");
        writer.Append(Descricao + "|");
        writer.Append(string.Format("{0:F2}", Valor) + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
