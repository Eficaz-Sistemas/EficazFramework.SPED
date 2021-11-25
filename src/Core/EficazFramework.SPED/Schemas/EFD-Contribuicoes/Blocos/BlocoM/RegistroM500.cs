using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Crédito de Cofins relativo ao período
/// </summary>
/// <remarks></remarks>

public class RegistroM500 : Primitives.Registro
{
    public RegistroM500() : base("M500")
    {
    }

    public RegistroM500(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CoditoTipoCreditoPeriodo { get; set; } = null;
    public IndicadorCreditoOriundo IndicadorCreditoOriundo { get; set; } = IndicadorCreditoOriundo.OperacoesProprias;
    public double? VrBcCredito { get; set; }
    public double? AliqCofins { get; set; }
    public double? QtdeBcCofins { get; set; }
    public double? AliqCofinsQtde { get; set; }
    public double? VrCreditoCofinsPeriodo { get; set; }
    public double? VrTotalAjusteAcrescimo { get; set; }
    public double? VrTotalAjusteReducao { get; set; }
    public double? VrTotalCredDiferido { get; set; }
    public double? VrTotalCredDispPerido { get; set; }
    public IndicadorCredDispPeriodo IndicadorUtilCredDisp { get; set; } = IndicadorCredDispPeriodo.UtilizacaoValorTotal;
    public double? VrCredDispDescContApPeriodo { get; set; }
    public double? SaldoCreditosUtilFuturo { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M500|");
        writer.Append(CoditoTipoCreditoPeriodo + "|");
        writer.Append(((int)IndicadorCreditoOriundo).ToString() + "|");
        writer.Append(string.Format("{0:0.##}", VrBcCredito) + "|");
        writer.Append(string.Format("{0:0.####}", AliqCofins) + "|");
        writer.Append(string.Format("{0:0.###}", QtdeBcCofins) + "|");
        writer.Append(string.Format("{0:0.##}", AliqCofinsQtde) + "|");
        writer.Append(string.Format("{0:0.##}", VrCreditoCofinsPeriodo) + "|");
        writer.Append(string.Format("{0:0.##}", VrTotalAjusteAcrescimo) + "|");
        writer.Append(string.Format("{0:0.##}", VrTotalAjusteReducao) + "|");
        writer.Append(string.Format("{0:0.##}", VrTotalCredDiferido) + "|");
        writer.Append(string.Format("{0:0.##}", VrTotalCredDispPerido) + "|");
        writer.Append(((int)IndicadorUtilCredDisp).ToString() + "|");
        writer.Append(VrCredDispDescContApPeriodo + "|");
        writer.Append(SaldoCreditosUtilFuturo + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CoditoTipoCreditoPeriodo = data[2];
        IndicadorCreditoOriundo = (IndicadorCreditoOriundo)data[3].ToEnum<IndicadorCreditoOriundo>(IndicadorCreditoOriundo.OperacoesProprias);
        VrBcCredito = data[4].ToNullableDouble();
        AliqCofins = data[5].ToNullableDouble();
        QtdeBcCofins = data[6].ToNullableDouble();
        AliqCofinsQtde = data[7].ToNullableDouble();
        VrCreditoCofinsPeriodo = data[8].ToNullableDouble();
        VrTotalAjusteAcrescimo = data[9].ToNullableDouble();
        VrTotalAjusteReducao = data[10].ToNullableDouble();
        VrTotalCredDiferido = data[11].ToNullableDouble();
        VrTotalCredDispPerido = data[12].ToNullableDouble();
        IndicadorUtilCredDisp = (IndicadorCredDispPeriodo)data[13].ToNullableDouble();
        VrCredDispDescContApPeriodo = data[14].ToNullableDouble();
        SaldoCreditosUtilFuturo = data[15].ToNullableDouble();
    }
}
