
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Base de Cálculo do IRPJ Sobre o Lucro Real Após as Compensações de Prejuízos
/// </summary>
/// <remarks></remarks>

public class RegistroN500 : Primitives.Registro
{
    public RegistroN500() : base("N500")
    {
    }

    public RegistroN500(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string CodigoReferencial { get; set; } = null;
    public string Descricao { get; set; } = null;
    public double? Valor { get; set; } = default;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|N500|");
        writer.Append(CodigoReferencial + "|");
        writer.Append(Descricao + "|");
        writer.Append(string.Format("{0:F2}", Valor) + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
