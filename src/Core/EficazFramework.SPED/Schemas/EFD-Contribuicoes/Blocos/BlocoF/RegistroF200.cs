using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Operações da atividade imobiliária - Unidade imobiliária vendida
/// </summary>
/// <remarks></remarks>

public class RegistroF200 : Primitives.Registro
{
    public RegistroF200() : base("F200")
    {
    }

    public RegistroF200(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public IndicadorTipoOperacaoImob IndicadorTipoOperacao { get; set; } = IndicadorTipoOperacaoImob.Outras;
    public IndicadorTipoUnidadeImobiliariaVendida IndicadorTipoUnidImobVendida { get; set; } = IndicadorTipoUnidadeImobiliariaVendida.Outras;
    public string NomeEmpreendimento { get; set; } = null;
    public string DescResumidaUnidImobVend { get; set; } = null;
    public string NumeroContratoVendaUnidImob { get; set; } = null;
    public string IdentificacaoPfouPj { get; set; } = null;
    public DateTime? DataOperacao { get; set; }
    public double? VrTotalUnidImobVendida { get; set; }
    public double? VrRecebAcumMesAnterior { get; set; }
    public double? VrRecebMes { get; set; }
    public string CSTPis { get; set; } = null;
    public double? VrBcPis { get; set; }
    public double? AliqPis { get; set; }
    public double? VrPis { get; set; }
    public string CSTCofins { get; set; } = null;
    public double? VrBcCofins { get; set; }
    public double? AliqCofins { get; set; }
    public double? VrCofins { get; set; }
    public double? PercentualRecTotalRecebida { get; set; }
    public IndicadoNaturezaEspecEmpreend IndicadorNaturezaEspecEmpreend { get; set; } = IndicadoNaturezaEspecEmpreend.Outras;
    public string InfosComplementares { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|F200|");
        writer.Append(string.Format("{0:00}", (int)IndicadorTipoOperacao) + "|");
        writer.Append(string.Format("{0:00}", (int)IndicadorTipoUnidImobVendida) + "|");
        writer.Append(NomeEmpreendimento + "|");
        writer.Append(DescResumidaUnidImobVend + "|");
        writer.Append(NumeroContratoVendaUnidImob + "|");
        writer.Append(IdentificacaoPfouPj + "|");
        writer.Append(DataOperacao.ToSpedString() + "|");
        writer.Append(string.Format("{0:0.##}", VrTotalUnidImobVendida) + "|");
        writer.Append(string.Format("{0:0.##}", VrRecebAcumMesAnterior) + "|");
        writer.Append(string.Format("{0:0.##}", VrRecebMes) + "|");
        writer.Append(CSTPis + "|");
        writer.Append(string.Format("{0:0.##}", VrBcPis) + "|");
        writer.Append(string.Format("{0:0.##}", AliqPis) + "|");
        writer.Append(string.Format("{0:0.##}", VrPis) + "|");
        writer.Append(CSTCofins + "|");
        writer.Append(string.Format("{0:0.##}", VrBcCofins) + "|");
        writer.Append(string.Format("{0:0.##}", AliqCofins) + "|");
        writer.Append(string.Format("{0:0.##}", VrCofins) + "|");
        writer.Append(string.Format("{0:0.##}", PercentualRecTotalRecebida) + "|");
        writer.Append(((int)IndicadorNaturezaEspecEmpreend).ToString() + "|");
        writer.Append(InfosComplementares + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorTipoOperacao = (IndicadorTipoOperacaoImob)data[2].ToEnum<IndicadorTipoOperacaoImob>(IndicadorTipoOperacaoImob.Outras);
        IndicadorTipoUnidImobVendida = (IndicadorTipoUnidadeImobiliariaVendida)data[3].ToEnum<IndicadorTipoUnidadeImobiliariaVendida>(IndicadorTipoUnidadeImobiliariaVendida.Outras);
        NomeEmpreendimento = data[4];
        DescResumidaUnidImobVend = data[5];
        NumeroContratoVendaUnidImob = data[6];
        IdentificacaoPfouPj = data[7];
        DataOperacao = data[8].ToDate();
        VrTotalUnidImobVendida = data[9].ToNullableDouble();
        VrRecebAcumMesAnterior = data[10].ToNullableDouble();
        VrRecebMes = data[11].ToNullableDouble();
        CSTPis = data[12];
        VrBcPis = data[13].ToNullableDouble();
        AliqPis = data[14].ToNullableDouble();
        VrPis = data[15].ToNullableDouble();
        CSTCofins = data[16];
        VrBcCofins = data[17].ToNullableDouble();
        AliqCofins = data[18].ToNullableDouble();
        VrCofins = data[19].ToNullableDouble();
        PercentualRecTotalRecebida = data[20].ToNullableDouble();
        IndicadorNaturezaEspecEmpreend = (IndicadoNaturezaEspecEmpreend)data[21].ToEnum<IndicadoNaturezaEspecEmpreend>(IndicadoNaturezaEspecEmpreend.Outras);
        InfosComplementares = data[22];
    }
}
