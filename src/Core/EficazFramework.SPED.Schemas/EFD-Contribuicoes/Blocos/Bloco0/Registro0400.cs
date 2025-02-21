
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Tabela de Natureza da Operação/Prestação
/// </summary>
/// <remarks></remarks>

public class Registro0400 : Primitives.Registro
{
    public Registro0400() : base("0400")
    {
    }

    public Registro0400(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoNaturezaOperacao { get; set; } = null; // tamanho 10'
    public string DescricaoNaturezaOperacao { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0400|");
        writer.Append(CodigoNaturezaOperacao + "|");
        writer.Append(DescricaoNaturezaOperacao + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoNaturezaOperacao = data[2];
        DescricaoNaturezaOperacao = data[3];
    }
}
