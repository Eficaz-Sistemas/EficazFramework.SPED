using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Identificação da Conta na Parte B do e-Lalur e do e-Lacs
/// </summary>
/// <remarks></remarks>

public class RegistroM010 : Primitives.Registro
{
    public RegistroM010() : base("M010")
    {
    }

    public RegistroM010(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos
    public string CodigoContaB { get; set; } = null;
    public string Descricao { get; set; } = null;
    /// <summary>
    /// Data final do período de apuração em que a conta foi criada.
    /// </summary>
    public DateTime? DataFinal { get; set; } = default;
    /// <summary>
    /// Código do lançamento na parte A do e-Lalur e/ou do e-Lacs que deu origem à conta.
    /// </summary>
    /// <returns></returns>
    public string CodigoLancamentoOrigem { get; set; } = null;
    /// <summary>
    /// Descrição do tipo de lançamento na parte A do e-Lalur e/ou do e-Lacs que deu origem à conta.
    /// </summary>
    /// <returns></returns>
    public string DescricaoLanctoOrigem { get; set; } = null;
    /// <summary>
    /// Data limite para a exclusão, adição ou compensação do valor controlado, se houver.
    /// </summary>
    /// <returns></returns>
    public DateTime? DataLimite { get; set; } = default;
    /// <summary>
    /// I = IRPJ
    /// C = CSLL
    /// </summary>
    /// <returns></returns>
    public string CodigoTributo { get; set; } = null;
    public double? SaldoInicial { get; set; } = default;
    /// <summary>
    /// D – Para prejuízos ou valores que reduzam o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.
    /// C – Para valores que aumentem o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.
    /// </summary>
    /// <returns></returns>
    public string NaturezaSaldoInicial { get; set; } = null;
    /// <summary>
    /// CNPJ da outra pessoa jurídica relacionada com evento originário da conta.
    /// Exemplos: 1-  Identificar a investida no caso de valores (ganhos/perdas no novo AVJ) da participação societária anterior, nos caso de aquisições em estágios.
    /// 2- Identificar a investida no caso de amortização de mais-valia e menos-valia.
    /// 3- Identificar a investida no caso de impairment de goodwill, mais-valia e menos-valia.
    /// 4- Identificar a investida no caso de ganho por compra vantajosa.
    /// 5- Identificar a investida no caso registro do ágio gerado na aquisição de participação societária ocorrida até 31/12/2009.
    /// 6  - Identificar a investida no caso de ágio gerado pela sistemática de transição disciplinada no art. 65, Lei Nº 12.973/14.
    /// 7 - Identificar a pessoa jurídica antecessora no caso de conta incorporada devido a evento societário
    /// </summary>
    /// <returns></returns>
    public string CNPJSituacaoEspecial { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M010|");
        writer.Append(CodigoContaB + "|");
        writer.Append(Descricao + "|");
        writer.Append(DataFinal.ToSpedString() + "|");
        writer.Append(CodigoLancamentoOrigem + "|");
        if (int.Parse(Versao) < 7)
            writer.Append(DescricaoLanctoOrigem + "|");
        writer.Append(DataLimite.ToSpedString() + "|");
        writer.Append(CodigoTributo + "|");
        writer.Append(string.Format("{0:F2}", SaldoInicial) + "|");
        writer.Append(NaturezaSaldoInicial + "|");
        writer.Append(CNPJSituacaoEspecial + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
