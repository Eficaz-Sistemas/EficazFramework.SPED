
namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// REGISTRO C177: COMPLEMENTO DE ITEM - OUTRAS INFORMAÇÕES (CÓDIGO 01,55) -(VÁLIDO A PARTIR DE 01/01/2019)
/// </summary>
/// <remarks></remarks>
public class RegistroC177 : Primitives.Registro
{
    public RegistroC177() : base("C177")
    {
    }

    public RegistroC177(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C177|"); // 1
        writer.Append(CodigoInformAdicional + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoInformAdicional = data[2].ToString();
    }

    public string CodigoInformAdicional { get; set; } = null;
}
