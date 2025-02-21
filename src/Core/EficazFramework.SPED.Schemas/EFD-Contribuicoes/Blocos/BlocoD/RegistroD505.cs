using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Complemento da Operação
/// </summary>
/// <remarks></remarks>

public class RegistroD505 : Primitives.Registro
{
    public RegistroD505() : base("D505")
    {
    }

    public RegistroD505(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CSTCofins { get; set; } = null;
    public double? VrTotalItens { get; set; }
    public NaturezaBaseCalculo NatBcCalculo { get; set; } = NaturezaBaseCalculo.OutOpDireitoCredito;
    public double? VrBCCofins { get; set; }
    public double? AliquotaCofins { get; set; }
    public double? VrCofins { get; set; }
    public string CodigoContaContabil { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D505|");
        writer.Append(CSTCofins + "|");
        writer.Append(string.Format("{0:0.##}", VrTotalItens) + "|");
        if ((VrCofins ?? 0d) > 0d)
            writer.Append(string.Format("{0:00}", (int)NatBcCalculo) + "|");
        else
            writer.Append('|');
        writer.Append(string.Format("{0:0.##}", VrBCCofins) + "|");
        writer.Append(string.Format("{0:0.####}", AliquotaCofins) + "|");
        writer.Append(string.Format("{0:0.##}", VrCofins) + "|");
        writer.Append(CodigoContaContabil + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CSTCofins = data[2];
        VrTotalItens = data[3].ToNullableDouble();
        NatBcCalculo = (NaturezaBaseCalculo)data[4].ToEnum<NaturezaBaseCalculo>(NaturezaBaseCalculo.OutOpDireitoCredito);
        VrBCCofins = data[5].ToNullableDouble();
        AliquotaCofins = data[6].ToNullableDouble();
        VrCofins = data[7].ToNullableDouble();
        CodigoContaContabil = data[8];
    }
}
