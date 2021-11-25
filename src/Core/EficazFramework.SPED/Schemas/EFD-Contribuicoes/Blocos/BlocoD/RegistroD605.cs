using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Complemento da Consolidação da Prestação de Serviços
/// </summary>
/// <remarks></remarks>

public class RegistroD605 : Primitives.Registro
{
    public RegistroD605() : base("D605")
    {
    }

    public RegistroD605(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoClassifItemServComun { get; set; } = null;
    public double? VrAcumItem { get; set; }
    public double? VrAcumDesconto { get; set; }
    public string CstCofins { get; set; } = null;
    public double? VrBcCofins { get; set; }
    public double? AliquotaCofins { get; set; }
    public double? VrCofins { get; set; }
    public string CodigoContaContabil { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D605|");
        writer.Append(CodigoClassifItemServComun + "|");
        writer.Append(VrAcumItem + "|");
        writer.Append(VrAcumDesconto + "|");
        writer.Append(CstCofins + "|");
        writer.Append(VrBcCofins + "|");
        writer.Append(AliquotaCofins + "|");
        writer.Append(VrCofins + "|");
        writer.Append(CodigoContaContabil + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoClassifItemServComun = data[2];
        VrAcumItem = data[3].ToNullableDouble();
        VrAcumDesconto = data[4].ToNullableDouble();
        CstCofins = data[5];
        VrBcCofins = data[6].ToNullableDouble();
        AliquotaCofins = data[7].ToNullableDouble();
        VrCofins = data[8].ToNullableDouble();
        CodigoContaContabil = data[9];
    }
}
