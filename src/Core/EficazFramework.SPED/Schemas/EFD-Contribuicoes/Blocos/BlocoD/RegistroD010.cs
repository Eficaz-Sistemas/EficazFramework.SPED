
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Identificação do Estabelecimento
/// </summary>
/// <remarks></remarks>

public class RegistroD010 : Primitives.Registro
{
    public RegistroD010() : base("D010")
    {
    }

    public RegistroD010(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string NumeroInscricaoEstabelecimentoCNPJ { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D010|");
        writer.Append(NumeroInscricaoEstabelecimentoCNPJ + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        NumeroInscricaoEstabelecimentoCNPJ = data[2];
    }
}
