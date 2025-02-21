using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Plano de Contas Contábeis
/// </summary>
/// <remarks></remarks>

public class Registro0500 : Primitives.Registro
{
    public Registro0500() : base("0500")
    {
    }

    public Registro0500(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public DateTime? DataInclusaoAlteracao { get; set; } // ddMMaaa'
    public string CodigoNaturezaConta { get; set; } = null;
    public string IndicadorConta { get; set; } = "A";
    public string NivelConta { get; set; } = null; // tamanho 5'
    public string CodigoConta { get; set; } = null;  // tamanho 60'
    public string NomeConta { get; set; } = null; // tamanho 60'
    public string CodigoContaReferencial { get; set; } = null; // tamanho 60'
    public string CNPJEstabelecimento { get; set; } = null; // tamanho 14'

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0500|");
        writer.Append(DataInclusaoAlteracao.ToSpedString() + "|");
        writer.Append(string.Format("{0:00}", Conversions.ToInteger(CodigoNaturezaConta)) + "|");
        writer.Append(IndicadorConta + "|");
        writer.Append(NivelConta + "|");
        writer.Append(CodigoConta + "|");
        writer.Append(NomeConta + "|");
        writer.Append(CodigoContaReferencial + "|");
        writer.Append(CNPJEstabelecimento + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DataInclusaoAlteracao = data[2].ToDate();
        CodigoNaturezaConta = Conversions.ToString(data[3].ToEnum<ECD.TipoConta>(ECD.TipoConta.Ativo));
        IndicadorConta = Conversions.ToString(data[4].ToEnum<ECD.IndicadorConta>(ECD.IndicadorConta.Analitica));
        NivelConta = data[5];
        CodigoConta = data[6];
        NomeConta = data[7];
        CodigoContaReferencial = data[8];
        CNPJEstabelecimento = data[9];
    }
}
