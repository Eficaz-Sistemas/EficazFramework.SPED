using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Detalhes do Balancete Diário
/// </summary>
/// <remarks></remarks>

public class RegistroI310 : Primitives.Registro
{
    public RegistroI310() : base("I310")
    {
    }

    public RegistroI310(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodContaAnalitica { get; set; } = null;
    public string CodCentroCusto { get; set; } = null;
    public double? TotalDebitos { get; set; }
    public double? TotalCreditos { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|I310|");
        writer.Append(CodContaAnalitica + "|");
        writer.Append(CodCentroCusto + "|");
        writer.Append(TotalDebitos + "|");
        writer.Append(TotalCreditos + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodContaAnalitica = data[2];
        CodCentroCusto = data[3];
        TotalDebitos = data[4].ToNullableDouble();
        TotalCreditos = data[5].ToNullableDouble();
    }
}
