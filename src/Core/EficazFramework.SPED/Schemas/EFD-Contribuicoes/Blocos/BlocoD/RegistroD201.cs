using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Totalização Resumo Diário
/// </summary>
/// <remarks></remarks>

public class RegistroD201 : Primitives.Registro
{
    public RegistroD201() : base("D201")
    {
    }

    public RegistroD201(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CSTPis { get; set; } = null;
    public double? VrTotalItens { get; set; }
    public double? VrBcPis { get; set; }
    public double? AliquotaPis { get; set; }
    public double? VrPis { get; set; }
    public string CodigoContaContabil { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D201|");
        writer.Append(CSTPis + "|");
        writer.Append(VrTotalItens + "|");
        writer.Append(VrBcPis + "|");
        writer.Append(AliquotaPis + "|");
        writer.Append(VrPis + "|");
        writer.Append(CodigoContaContabil + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CSTPis = data[2];
        VrTotalItens = data[3].ToNullableDouble();
        VrBcPis = data[4].ToNullableDouble();
        AliquotaPis = data[5].ToNullableDouble();
        VrPis = data[6].ToNullableDouble();
        CodigoContaContabil = data[7];
    }
}
