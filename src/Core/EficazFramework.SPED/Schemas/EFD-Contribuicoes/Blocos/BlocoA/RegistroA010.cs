using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Identificação do Estabelecimento
/// </summary>
/// <remarks></remarks>

public class RegistroA010 : Primitives.Registro
{
    public RegistroA010() : base("A010")
    {
    }

    public RegistroA010(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CNPJEstabelecimento { get; set; } = null;
    public List<RegistroA100> RegistrosA100 { get; set; } = new List<RegistroA100>();

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|A010|");
        writer.Append(CNPJEstabelecimento + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CNPJEstabelecimento = data[2];
    }
}
