using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Bens incorporados ao ativo imobilizado - operações geradoras de créditos
/// </summary>
/// <remarks></remarks>

public class RegistroF130 : Primitives.Registro
{
    public RegistroF130() : base("F130")
    {
    }

    public RegistroF130(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string NatBcCalculo { get; set; } = null;
    public IdentificacaoBensGrupoAtivoImobilizado IdentificacaoBensGrupoAtivo { get; set; } = IdentificacaoBensGrupoAtivoImobilizado.Outros;
    public IndicadorOrigemCreditoAtivoImobilizado IndicadorOrigemBemAtivoImob { get; set; } = IndicadorOrigemCreditoAtivoImobilizado.AquisicaoMercadoInterno;
    public IndicadorUtilizacaoBensAtivoImobilizado IndicadorUtilizacaoBensAtivoImob { get; set; } = IndicadorUtilizacaoBensAtivoImobilizado.Outros;
    public DateTime? MesAquisicaoBemAtivoImobilizado { get; set; }
    public double? VrOperacaoAquisicao { get; set; }
    public double? ParcelaExcluirBcCreditoAquisicao { get; set; }
    public double? VrBcCrédito { get; set; }
    public IndicadorNumeroParcelas IndicadorNumParcelas { get; set; } = IndicadorNumeroParcelas.Integral;
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
        writer.Append("|F130|");
        writer.Append(NatBcCalculo + "|");
        writer.Append(((int)IdentificacaoBensGrupoAtivo).ToString() + "|");
        writer.Append(((int)IndicadorOrigemBemAtivoImob).ToString() + "|");
        writer.Append(((int)IndicadorUtilizacaoBensAtivoImob).ToString() + "|");
        writer.Append(MesAquisicaoBemAtivoImobilizado + "|");
        writer.Append(VrOperacaoAquisicao + "|");
        writer.Append(ParcelaExcluirBcCreditoAquisicao + "|");
        writer.Append(VrBcCrédito + "|");
        writer.Append(((int)IndicadorNumParcelas).ToString() + "|");
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
        NatBcCalculo = Conversions.ToString(data[2].ToEnum<NaturezaBaseCalculo>(NaturezaBaseCalculo.MaqEquipImob_CreditoDepreciacao));
        IdentificacaoBensGrupoAtivo = (IdentificacaoBensGrupoAtivoImobilizado)data[3].ToEnum<IdentificacaoBensGrupoAtivoImobilizado>(IdentificacaoBensGrupoAtivoImobilizado.Outros);
        IndicadorOrigemBemAtivoImob = (IndicadorOrigemCreditoAtivoImobilizado)data[4].ToEnum<IndicadorOrigemCreditoAtivoImobilizado>(IndicadorOrigemCreditoAtivoImobilizado.AquisicaoMercadoInterno);
        IndicadorUtilizacaoBensAtivoImob = (IndicadorUtilizacaoBensAtivoImobilizado)data[5].ToEnum<IndicadorUtilizacaoBensAtivoImobilizado>(IndicadorUtilizacaoBensAtivoImobilizado.Outros);
        MesAquisicaoBemAtivoImobilizado = data[6].ToDate();
        VrOperacaoAquisicao = data[7].ToNullableDouble();
        ParcelaExcluirBcCreditoAquisicao = data[8].ToNullableDouble();
        VrBcCrédito = data[9].ToNullableDouble();
        IndicadorNumParcelas = (IndicadorNumeroParcelas)data[10].ToEnum<IndicadorNumeroParcelas>(IndicadorNumeroParcelas.Integral);
        CSTPis = data[11];
        VrBcPis = data[12].ToNullableDouble();
        AliqPis = data[13].ToNullableDouble();
        VrPis = data[14].ToNullableDouble();
        CSTCofins = data[15];
        VrBcCofins = data[16].ToNullableDouble();
        AliqCofins = data[17].ToNullableDouble();
        VrCofins = data[18].ToNullableDouble();
        CodigoContaContabil = data[19];
        CodigoCentroCusto = data[20];
        DescricaoComplementar = data[21];
    }
}
