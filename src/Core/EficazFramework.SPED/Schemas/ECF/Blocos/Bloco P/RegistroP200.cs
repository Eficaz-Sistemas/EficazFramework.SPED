
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Apuração da Base de Cálculo do IRPJ com Base no Lucro Presumido
/// </summary>
/// <remarks></remarks>

public class RegistroP200 : Primitives.Registro
{
    public RegistroP200() : base("P200")
    {
    }

    public RegistroP200(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string CodigoReferencial { get; set; } = null;
    public string Descricao { get; set; } = null;
    public double? Valor { get; set; } = default;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|P200|");
        writer.Append(CodigoReferencial + "|");
        writer.Append(Descricao + "|");
        writer.Append(string.Format("{0:F2}", Valor) + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
