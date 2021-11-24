using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Controle de créditos fiscais - Cofins
    /// </summary>
    /// <remarks></remarks>

    public class Registro1500 : Primitives.Registro
    {
        public Registro1500() : base("1500")
        {
        }

        public Registro1500(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos"
        public DateTime? PeriodoApuracaoCredito { get; set; }
        public IndicadorOrigemCreditoBloco1 IndicadorOrigemCredito { get; set; } = IndicadorOrigemCreditoBloco1.CreditoDecorrenteOperacoesProprias;
        public string CNPJSucedida { get; set; } = null;
        public string CodigoTipoCredito { get; set; } = null;
        public double? VrTotalCreditoRegistroM100PerAnt { get; set; }
        public double? VrCreditoExtempApuradoPerAnt { get; set; }
        public double? VrTotalCreditoApurado { get; set; }
        public double? VrCreditoUtilizDescPerAnt { get; set; }
        public double? VrCreditoUtilizPedidoRessarcPerAnt { get; set; }
        public double? VrCreditoUtilizDeclCompPerAnt { get; set; }
        public double? SaldoCreditoDispUtilPerEscrit { get; set; }
        public double? VrCredDescontPerEscrit { get; set; }
        public double? VrCredObjPedidoRessarcPerEscrit { get; set; }
        public double? VrCredUtilDeclCompPerEscrit { get; set; }
        public double? VrCredTransfCisaoFusaoIncorp { get; set; }
        public double? VrCredUtilizOutrasFormas { get; set; }
        public double? SaldCredUtilPerFuturos { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1500|");
            writer.Append(PeriodoApuracaoCredito + "|");
            writer.Append(((int)IndicadorOrigemCredito).ToString() + "|");
            writer.Append(CNPJSucedida + "|");
            writer.Append(CodigoTipoCredito + "|");
            writer.Append(VrTotalCreditoRegistroM100PerAnt + "|");
            writer.Append(VrCreditoExtempApuradoPerAnt + "|");
            writer.Append(VrTotalCreditoApurado + "|");
            writer.Append(VrCreditoUtilizDescPerAnt + "|");
            writer.Append(VrCreditoUtilizPedidoRessarcPerAnt + "|");
            writer.Append(VrCreditoUtilizDeclCompPerAnt + "|");
            writer.Append(SaldoCreditoDispUtilPerEscrit + "|");
            writer.Append(VrCredDescontPerEscrit + "|");
            writer.Append(VrCredObjPedidoRessarcPerEscrit + "|");
            writer.Append(VrCredUtilDeclCompPerEscrit + "|");
            writer.Append(VrCredTransfCisaoFusaoIncorp + "|");
            writer.Append(VrCredUtilizOutrasFormas + "|");
            writer.Append(SaldCredUtilPerFuturos + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            PeriodoApuracaoCredito = data[2].ToDate();
            IndicadorOrigemCredito = (IndicadorOrigemCreditoBloco1)data[3].ToEnum<IndicadorOrigemCreditoBloco1>(IndicadorOrigemCreditoBloco1.CreditoDecorrenteOperacoesProprias);
            CNPJSucedida = data[4];
            CodigoTipoCredito = data[5];
            VrTotalCreditoRegistroM100PerAnt = data[6].ToNullableDouble();
            VrCreditoExtempApuradoPerAnt = data[7].ToNullableDouble();
            VrTotalCreditoApurado = data[8].ToNullableDouble();
            VrCreditoUtilizDescPerAnt = data[9].ToNullableDouble();
            VrCreditoUtilizPedidoRessarcPerAnt = data[10].ToNullableDouble();
            VrCreditoUtilizDeclCompPerAnt = data[11].ToNullableDouble();
            SaldoCreditoDispUtilPerEscrit = data[12].ToNullableDouble();
            VrCredDescontPerEscrit = data[13].ToNullableDouble();
            VrCredObjPedidoRessarcPerEscrit = data[14].ToNullableDouble();
            VrCredUtilDeclCompPerEscrit = data[15].ToNullableDouble();
            VrCredTransfCisaoFusaoIncorp = data[16].ToNullableDouble();
            VrCredUtilizOutrasFormas = data[17].ToNullableDouble();
            SaldCredUtilPerFuturos = data[18].ToNullableDouble();
        }
    }
}