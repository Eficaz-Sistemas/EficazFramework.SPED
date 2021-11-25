using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Complemento da operação
/// </summary>
/// <remarks></remarks>

public class RegistroC505 : Primitives.Registro
{
    public RegistroC505() : base("C505")
    {
    }

    public RegistroC505(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CstCofins { get; set; } = null;
    public double? VrTotalItens { get; set; }
    public string NatBaseCalculo { get; set; } = null;
    public double VrBaseCalculoCofins { get; set; }
    public double? AliquotaCofins { get; set; }
    public double? VrCofins { get; set; }
    public string CodContaContabil { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C505|");
        if (Conversions.ToDouble(CstCofins) != (double)NFe.CST_COFINS.NotValid)
            writer.Append(string.Format("{0:#00}", Conversions.ToInteger(CstCofins)) + "|");
        else
            writer.Append('|');
        writer.Append(string.Format("{0:0.##}", VrTotalItens) + "|");
        writer.Append(string.Format("{0:00}", Conversions.ToInteger(NatBaseCalculo)) + "|");
        writer.Append(string.Format("{0:0.##}", VrBaseCalculoCofins) + "|");
        writer.Append(string.Format("{0:0.####}", AliquotaCofins) + "|");
        writer.Append(string.Format("{0:0.##}", VrCofins) + "|");
        writer.Append(CodContaContabil + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CstCofins = data[2];
        VrTotalItens = data[3].ToNullableDouble();
        NatBaseCalculo = data[4];
        VrBaseCalculoCofins = (double)data[5].ToNullableDouble();
        AliquotaCofins = data[6].ToNullableDouble();
        VrCofins = data[7].ToNullableDouble();
        CodContaContabil = data[8];
    }
}
