using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Deduções do ISS
/// </summary>
/// <remarks></remarks>

public class RegistroB460 : Primitives.Registro
{
    public RegistroB460() : base("B460")
    {
    }

    public RegistroB460(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|B460|"); // 1
        writer.Append(((int)IndicadorTipoDeducao).ToString() + "|"); // 2
        writer.Append(string.Format("{0:0.##}", ValorDeducao) + "|"); // 3
        writer.Append(NumeroProcesso + "|"); // 4
        writer.Append(((int)IndicadorOrigemProcesso).ToString() + "|"); // 5
        writer.Append(DescricaoProcessoLcto + "|"); // 6
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorTipoDeducao = (IndicadorTipoDeducao)data[2].ToEnum<IndicadorTipoDeducao>(IndicadorTipoDeducao.Compensacao_ISS_CalculadoMaior);
        ValorDeducao = data[3].ToNullableDouble();
        NumeroProcesso = data[4].ToString();
        IndicadorOrigemProcesso = (IndicadorOrigemProcessoServico)data[5].ToEnum<IndicadorOrigemProcessoServico>(IndicadorOrigemProcessoServico.Sefin);
        DescricaoProcessoLcto = data[6].ToString();
    }

    public IndicadorTipoDeducao IndicadorTipoDeducao { get; set; } = IndicadorTipoDeducao.Compensacao_ISS_CalculadoMaior; // 2 
    public double? ValorDeducao { get; set; } = default; // 3
    public string NumeroProcesso { get; set; } = null; // 4
    public IndicadorOrigemProcessoServico IndicadorOrigemProcesso { get; set; } = IndicadorOrigemProcessoServico.Sefin; // 5
    public string DescricaoProcessoLcto { get; set; } = null; // 6
}
