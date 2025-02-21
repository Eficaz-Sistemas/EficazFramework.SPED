using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Detalhamento da Consolidaçao - Operações de Aquisição Com direito a crédito
/// e operações de devolução de compras e vendas - cofins
/// </summary>
/// <remarks></remarks>

public class RegistroC195 : Primitives.Registro
{
    public RegistroC195() : base("C195")
    {
    }

    public RegistroC195(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos 
    public string CNPJParticipanteOperConsolidadas { get; set; } = null;
    public string CSTCofins { get; set; } = null;
    public string CFOP { get; set; } = null;
    public double? VrItem { get; set; }
    public double? VrDescontoExclusao { get; set; }
    public double? VrBaseCalculoCofins { get; set; }
    public double? AliquotaCofins { get; set; }
    public double? BCCofinsQuantidade { get; set; }
    public double? AliquotaCofinsReais { get; set; }
    public double VrCofins { get; set; }
    public string CodigoContaContabil { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C195|");
        writer.Append(CNPJParticipanteOperConsolidadas + "|");
        writer.Append(CSTCofins + "|");
        writer.Append(CFOP + "|");
        writer.Append(VrItem + "|");
        writer.Append(VrDescontoExclusao + "|");
        writer.Append(VrBaseCalculoCofins + "|");
        writer.Append(AliquotaCofins + "|");
        writer.Append(BCCofinsQuantidade + "|");
        writer.Append(AliquotaCofinsReais + "|");
        writer.Append(VrCofins + "|");
        writer.Append(CodigoContaContabil + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CNPJParticipanteOperConsolidadas = data[2];
        CSTCofins = data[3];
        CFOP = data[4];
        VrItem = data[5].ToNullableDouble();
        VrDescontoExclusao = data[6].ToNullableDouble();
        VrBaseCalculoCofins = data[7].ToNullableDouble();
        AliquotaCofins = data[8].ToNullableDouble();
        BCCofinsQuantidade = data[9].ToNullableDouble();
        AliquotaCofinsReais = data[10].ToNullableDouble();
        VrCofins = (double)data[11].ToNullableDouble();
        CodigoContaContabil = data[12];
    }
}
