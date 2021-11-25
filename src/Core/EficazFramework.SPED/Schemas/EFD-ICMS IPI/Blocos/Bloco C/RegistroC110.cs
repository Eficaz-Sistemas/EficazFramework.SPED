
namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// REGISTRO C110: INFORMAÇÃO COMPLEMENTAR DA NOTA FISCAL (CÓDIGO
/// 01, 1B, 04 e 55).
/// </summary>
/// <remarks></remarks>
public class RegistroC110 : Primitives.Registro
{
    public RegistroC110() : base("C110")
    {
    }

    public RegistroC110(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C110|"); // 1
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }

    public string Cod_Inf { get; set; } // 2 --- tamanho 006
    public string TXT_Complementar { get; set; } // 3 --- 
}
