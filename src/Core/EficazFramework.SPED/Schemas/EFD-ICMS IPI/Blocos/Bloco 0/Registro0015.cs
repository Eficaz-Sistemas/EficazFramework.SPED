
namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Dados do Contribuinte Substituto
/// </summary>
/// <remarks></remarks>
public class Registro0015 : Primitives.Registro
{
    public Registro0015() : base("0015")
    {
    }

    public Registro0015(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0015|"); // 1
        writer.Append(UF + "|"); // 2
        writer.Append(InscricaoEstadual + "|"); // 3
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        UF = data[2];
        InscricaoEstadual = data[3];
    }

    public string UF { get; set; } = null;
    public string InscricaoEstadual { get; set; } = null;
}
