using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// créditos decorrentes de eventos de incorporação, fusão e cisão
/// </summary>
/// <remarks></remarks>

public class RegistroF800 : Primitives.Registro
{
    public RegistroF800() : base("F800")
    {
    }

    public RegistroF800(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public IndicadorNaturezaEventoSucessao IndicadorNaturezaEventoSucessao { get; set; } = IndicadorNaturezaEventoSucessao.Outros;
    public DateTime? DataEvento { get; set; }
    public string CNPJSucedida { get; set; } = null;
    public DateTime? PeriodoApCredito { get; set; }
    public string CodigoCreditoTransferido { get; set; } = null;
    public double? VrCredTransfPis { get; set; }
    public double? VrCredTransfCofins { get; set; }
    public double? PercentualCredOriginalTransf { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|F800|");
        writer.Append(((int)IndicadorNaturezaEventoSucessao).ToString() + "|");
        writer.Append(DataEvento + "|");
        writer.Append(CNPJSucedida + "|");
        writer.Append(PeriodoApCredito + "|");
        writer.Append(CodigoCreditoTransferido + "|");
        writer.Append(VrCredTransfPis + "|");
        writer.Append(VrCredTransfCofins + "|");
        writer.Append(PercentualCredOriginalTransf + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorNaturezaEventoSucessao = (IndicadorNaturezaEventoSucessao)data[2].ToEnum<IndicadorNaturezaEventoSucessao>(IndicadorNaturezaEventoSucessao.Outros);
        DataEvento = data[3].ToDate();
        CNPJSucedida = data[4];
        PeriodoApCredito = data[5].ToDate();
        CodigoCreditoTransferido = data[6];
        VrCredTransfPis = data[7].ToNullableDouble();
        VrCredTransfCofins = data[8].ToNullableDouble();
        PercentualCredOriginalTransf = data[9].ToNullableDouble();
    }
}
