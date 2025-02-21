using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Bens incorporados ao ativo imobilizado - operações geradoras de créditos
/// </summary>
/// <remarks></remarks>

public class RegistroF120 : Primitives.Registro
{
    public RegistroF120() : base("F120")
    {
    }

    public RegistroF120(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public NaturezaBaseCalculo NatBcCalculo { get; set; } = NaturezaBaseCalculo.MaqEquipImob_CreditoDepreciacao;
    public IdentificacaoBensGrupoAtivoImobilizado IdentificacaoBensGrupoAtivo { get; set; } = IdentificacaoBensGrupoAtivoImobilizado.Outros;
    public IndicadorOrigemCreditoAtivoImobilizado IndicadorOrigemBemAtivoImob { get; set; } = IndicadorOrigemCreditoAtivoImobilizado.AquisicaoMercadoInterno;
    public IndicadorUtilizacaoBensAtivoImobilizado IndicadorUtilizacaoBensAtivoImob { get; set; } = IndicadorUtilizacaoBensAtivoImobilizado.Outros;
    public double? VrEncargoDepreciacao { get; set; }
    public double? ParcelaVrEncargoExcluirBc { get; set; }
    public string CSTPis { get; set; } = null;
    public double? VrBcPis { get; set; }
    public double? AliqPis { get; set; }
    public double? VrPis { get; set; }
    public string CSTCofins { get; set; } = null;
    public double? VrBcCofins { get; set; }
    public double? AliqCofins { get; set; }
    public double? VrCofins { get; set; }
    public string CodigoContaContabil { get; set; } = null;
    public string CodigoCentroCusto { get; set; } = null;
    public string DescricaoComplementar { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|F120|");
        writer.Append(((int)NatBcCalculo).ToString() + "|");
        writer.Append(((int)IdentificacaoBensGrupoAtivo).ToString() + "|");
        writer.Append(((int)IndicadorOrigemBemAtivoImob).ToString() + "|");
        writer.Append(((int)IndicadorUtilizacaoBensAtivoImob).ToString() + "|");
        writer.Append(VrEncargoDepreciacao + "|");
        writer.Append(ParcelaVrEncargoExcluirBc + "|");
        writer.Append(CSTPis + "|");
        writer.Append(VrBcPis + "|");
        writer.Append(AliqPis + "|");
        writer.Append(VrPis + "|");
        writer.Append(CSTCofins + "|");
        writer.Append(VrBcCofins + "|");
        writer.Append(AliqCofins + "|");
        writer.Append(VrCofins + "|");
        writer.Append(CodigoContaContabil + "|");
        writer.Append(CodigoCentroCusto + "|");
        writer.Append(DescricaoComplementar + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        NatBcCalculo = (NaturezaBaseCalculo)data[2].ToEnum<NaturezaBaseCalculo>(NaturezaBaseCalculo.MaqEquipImob_CreditoDepreciacao);
        IdentificacaoBensGrupoAtivo = (IdentificacaoBensGrupoAtivoImobilizado)data[3].ToEnum<IdentificacaoBensGrupoAtivoImobilizado>(IdentificacaoBensGrupoAtivoImobilizado.Outros);
        IndicadorOrigemBemAtivoImob = (IndicadorOrigemCreditoAtivoImobilizado)data[4].ToEnum<IndicadorOrigemCreditoAtivoImobilizado>(IndicadorOrigemCreditoAtivoImobilizado.AquisicaoMercadoInterno);
        IndicadorUtilizacaoBensAtivoImob = (IndicadorUtilizacaoBensAtivoImobilizado)data[5].ToEnum<IndicadorUtilizacaoBensAtivoImobilizado>(IndicadorUtilizacaoBensAtivoImobilizado.Outros);
        VrEncargoDepreciacao = data[6].ToNullableDouble();
        ParcelaVrEncargoExcluirBc = data[7].ToNullableDouble();
        CSTPis = data[8];
        VrBcPis = data[9].ToNullableDouble();
        AliqPis = data[10].ToNullableDouble();
        VrPis = data[11].ToNullableDouble();
        CSTCofins = data[12];
        VrBcCofins = data[13].ToNullableDouble();
        AliqCofins = data[14].ToNullableDouble();
        VrCofins = data[15].ToNullableDouble();
        CodigoContaContabil = data[16];
        CodigoCentroCusto = data[17];
        DescricaoComplementar = data[18];
    }
}
