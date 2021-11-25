using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Demonstração do crédito a descontar da contribuição extemporânea - Cofins
    /// </summary>
    /// <remarks></remarks>

    public class Registro1620 : Primitives.Registro
    {
        public Registro1620() : base("1620")
        {
        }

        public Registro1620(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public DateTime? PeriodoApuracaoCredito { get; set; }
        public IndicadorOrigemCreditoBloco1 IndicadorOrigemCredito { get; set; } = IndicadorOrigemCreditoBloco1.CreditoDecorrenteOperacoesProprias;
        public string CodigoTipoCredito { get; set; } = null;
        public double? VrCredDescontar { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1620|");
            writer.Append(PeriodoApuracaoCredito + "|");
            writer.Append(((int)IndicadorOrigemCredito).ToString() + "|");
            writer.Append(CodigoTipoCredito + "|");
            writer.Append(VrCredDescontar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            PeriodoApuracaoCredito = data[2].ToDate();
            IndicadorOrigemCredito = (IndicadorOrigemCreditoBloco1)data[3].ToEnum<IndicadorOrigemCreditoBloco1>(IndicadorOrigemCreditoBloco1.CreditoDecorrenteOperacoesProprias);
            CodigoTipoCredito = data[4];
            VrCredDescontar = data[5].ToNullableDouble();
        }
    }
}