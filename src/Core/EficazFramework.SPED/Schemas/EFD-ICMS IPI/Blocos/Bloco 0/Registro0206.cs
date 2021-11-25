
namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Código de produto conforme Tabela ANP (Combustíveis)
/// </summary>
/// <remarks></remarks>
public class Registro0206 : Primitives.Registro
{
    public Registro0206() : base("0206")
    {
    }

    public Registro0206(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0206|"); // 1
        writer.Append(CodigoANP + "|"); // 2
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoANP = data[2];
    }

    public string CodigoANP { get; set; }
}
