
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Complemento do Documento - Informação complementar da NF
/// </summary>
/// <remarks></remarks>

public class RegistroA110 : Primitives.Registro
{
    public RegistroA110() : base("A110")
    {
    }

    public RegistroA110(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoInfoComplemDocFiscal { get; set; } = null; // tamanho 6'
    public string InformacaoComplemDocFiscal { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|A110|");
        writer.Append(CodigoInfoComplemDocFiscal + "|");
        writer.Append(InformacaoComplemDocFiscal + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoInfoComplemDocFiscal = data[2];
        InformacaoComplemDocFiscal = data[3];
    }
}
