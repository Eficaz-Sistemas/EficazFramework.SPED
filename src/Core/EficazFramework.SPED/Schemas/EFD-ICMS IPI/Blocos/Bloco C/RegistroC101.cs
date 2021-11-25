using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// REGISTRO C101: INFORMAÇÃO COMPLEMENTAR DOS DOCUMENTOS FISCAIS QUANDO DAS
/// OPERAÇÕES INTERESTADUAIS DESTINADAS A CONSUMIDOR FINAL NÃO CONTRIBUINTE
/// EC 87/15 (CÓDIGO 55)
/// </summary>
/// <remarks></remarks>
public class RegistroC101 : Primitives.Registro
{
    public RegistroC101() : base("C101")
    {
    }

    public RegistroC101(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C101|"); // 1
        writer.Append(string.Format("{0:0.##}", Vr_FCP_Uf_Destino) + "|"); // 2
        writer.Append(string.Format("{0:0.##}", Vr_ICMS_UF_Destino) + "|"); // 3
        writer.Append(string.Format("{0:0.##}", Vr_ICMS_UF_Remetente) + "|"); // 4
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        Vr_FCP_Uf_Destino = data[2].ToNullableDouble();
        Vr_ICMS_UF_Destino = data[3].ToNullableDouble();
        Vr_ICMS_UF_Remetente = data[4].ToNullableDouble();
    }

    public double? Vr_FCP_Uf_Destino { get; set; } // 2
    public double? Vr_ICMS_UF_Destino { get; set; } // 3
    public double? Vr_ICMS_UF_Remetente { get; set; } // 4
}
