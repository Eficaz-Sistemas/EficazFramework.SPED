
namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Tabela de Informação Complementar do documento fiscal
/// </summary>
/// <remarks></remarks>
public class Registro0450 : Primitives.Registro
{
    public Registro0450() : base("0450")
    {
    }

    public Registro0450(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0450|"); // 1
        writer.Append(CodigoInfComplementar + "|"); // 02
        writer.Append(TextoInfComplementar + "|"); // 03
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoInfComplementar = data[2];
        TextoInfComplementar = data[3];
    }

    /// <summary>
    /// Código da Informação Complementar - 06 dígitos.
    /// </summary>
    public string CodigoInfComplementar { get; set; } = null;
    /// <summary>
    /// Texto Livre da Informação Complementar.
    /// </summary>
    public string TextoInfComplementar { get; set; } = null;
}
