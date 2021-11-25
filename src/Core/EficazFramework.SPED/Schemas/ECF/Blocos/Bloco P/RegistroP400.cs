
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Apuração da Base de Cálculo da CSLL com Base no Lucro Presumido
/// </summary>
/// <remarks></remarks>

public class RegistroP400 : Primitives.Registro
{
    public RegistroP400() : base("P400")
    {
    }

    public RegistroP400(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string CodigoReferencial { get; set; } = null;
    public string Descricao { get; set; } = null;
    public double? Valor { get; set; } = default;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|P400|");
        writer.Append(CodigoReferencial + "|");
        writer.Append(Descricao + "|");
        writer.Append(string.Format("{0:F2}", Valor) + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
