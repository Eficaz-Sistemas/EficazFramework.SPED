using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Identificação e Remuneração de Sócios, Titulares, Dirigentes e Conselheiros
/// </summary>
public class RegistroY600 : Primitives.Registro
{
    public RegistroY600() : base("Y600")
    {
    }

    public RegistroY600(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public DateTime? DataAlteracao { get; set; } = default;
    public DateTime? DataSaida { get; set; } = default;
    public string Pais { get; set; } = null;
    /// <summary>
    /// PF = Pessoa Física
    /// PJ = Pessoa Jurídica
    /// FI = FUndo de Investimento
    /// </summary>
    public string IndicadorQualificacao { get; set; } = null;
    public string CNPJ_CPF { get; set; } = null;
    public string Nome { get; set; } = null;
    public string Qualificacao { get; set; } = null;
    public double? PercentualCapitalTotal { get; set; } = default;
    public double? PercentualCapitalVotante { get; set; } = default;
    public string CPF_ResponsavelLegal { get; set; } = null;
    /// <summary>
    /// 01 - Procurador
    /// 02 - Curador
    /// 03 - Mãe
    /// 04 - Pai
    /// 05 - Tutor
    /// 06 - Outro
    /// </summary>
    public string QualificacaoResponsavelLegal { get; set; } = null;
    public double? ValorRemuneracao { get; set; } = default;
    public double? ValorLucrosDividendos { get; set; } = default;
    public double? ValorJurosCapitalProprio { get; set; } = default;
    public double? ValorDemaisRendimentos { get; set; } = default;
    public double? ValorIR_Retido { get; set; } = default;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|Y600|"); // 1
        writer.Append(DataAlteracao.ToSpedString() + "|"); // 2
        writer.Append(DataSaida.ToSpedString() + "|"); // 3
        writer.Append(Pais + "|"); // 4
        writer.Append(IndicadorQualificacao + "|"); // 5
        writer.Append(CNPJ_CPF + "|"); // 6
        writer.Append(Nome + "|"); // 7
        writer.Append(Qualificacao + "|"); // 8
        writer.Append(string.Format("{0:F2}", PercentualCapitalTotal) + "|"); // 9
        writer.Append(string.Format("{0:F2}", PercentualCapitalVotante) + "|"); // 10
        writer.Append(CPF_ResponsavelLegal + "|"); // 11
        writer.Append(QualificacaoResponsavelLegal + "|"); // 12
        writer.Append(string.Format("{0:F2}", ValorRemuneracao) + "|"); // 13
        writer.Append(string.Format("{0:F2}", ValorLucrosDividendos) + "|"); // 14
        writer.Append(string.Format("{0:F2}", ValorJurosCapitalProprio) + "|"); // 15
        writer.Append(string.Format("{0:F2}", ValorDemaisRendimentos) + "|"); // 16
        writer.Append(string.Format("{0:F2}", ValorIR_Retido) + "|"); // 17
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
