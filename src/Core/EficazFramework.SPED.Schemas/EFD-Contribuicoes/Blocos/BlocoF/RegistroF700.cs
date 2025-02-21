using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Deduções diversas
/// </summary>
/// <remarks></remarks>

public class RegistroF700 : Primitives.Registro
{
    public RegistroF700() : base("F700")
    {
    }

    public RegistroF700(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public IndicadorOrigemDeducoesDiversas IndicadorOrigemDedDiversas { get; set; } = IndicadorOrigemDeducoesDiversas.OutrasDeducoes;
    public IndicadorNatDeducao IndicadorNatDeducao { get; set; } = IndicadorNatDeducao.DeducaoNaturezaNaoCumulativa;
    public double? VrDeduzirPis { get; set; }
    public double? VrDeduzirCofins { get; set; }
    public double? VrBcOperacao { get; set; }
    public string CNPJPJ { get; set; } = null;
    public string InfoComplementar { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|F700|");
        writer.Append(((int)IndicadorOrigemDedDiversas).ToString() + "|");
        writer.Append(((int)IndicadorNatDeducao).ToString() + "|");
        writer.Append(VrDeduzirPis + "|");
        writer.Append(VrDeduzirCofins + "|");
        writer.Append(VrBcOperacao + "|");
        writer.Append(CNPJPJ + "|");
        writer.Append(InfoComplementar + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorOrigemDedDiversas = (IndicadorOrigemDeducoesDiversas)data[2].ToEnum<IndicadorOrigemDeducoesDiversas>(IndicadorOrigemDeducoesDiversas.OutrasDeducoes);
        IndicadorNatDeducao = (IndicadorNatDeducao)data[3].ToEnum<IndicadorNatDeducao>(IndicadorNatDeducao.DeducaoNaturezaNaoCumulativa);
        VrDeduzirPis = data[4].ToNullableDouble();
        VrDeduzirCofins = data[5].ToNullableDouble();
        VrBcOperacao = data[6].ToNullableDouble();
        CNPJPJ = data[7];
        InfoComplementar = data[8];
    }
}
