
namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Método de Avaliação do Estoque Final
/// </summary>
/// <remarks></remarks>

public class RegistroL200 : Primitives.Registro
{
    public RegistroL200() : base("L200")
    {
    }

    public RegistroL200(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public MetodoAvEstoque Metodo { get; set; } = MetodoAvEstoque.CustoMedioPonderado;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|L200|");
        writer.Append((int)Metodo + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
