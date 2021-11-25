using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Demais documentos e operações geradoras de contribuições e créditos
    /// </summary>
    /// <remarks></remarks>

    public class RegistroF100 : Primitives.Registro
    {
        public RegistroF100() : base("F100")
        {
        }

        public RegistroF100(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public IndicadorTipoOperacaoF IndicadorTipoOperacaoF { get; set; } = IndicadorTipoOperacaoF.OperacaoRepresentativaAquisCustosDespEncargRecIncPisCofins;
        public string CodigoParticipante { get; set; } = null;
        public string CodigoItem { get; set; } = null;
        public DateTime? DataOperacao { get; set; }
        public double? ValorOperacaoItem { get; set; }
        public string CSTPis { get; set; } = null;
        public double? VrBcPis { get; set; }
        public double? AliqPis { get; set; }
        public double? VrPis { get; set; }
        public string CSTCofins { get; set; } = null;
        public double? VrBcCofins { get; set; }
        public double? AliqCofins { get; set; }
        public double? VrCofins { get; set; }
        public string NatBcCredito { get; set; } = null;
        public IndicadorOrigemCredito IndicadorOrigemCredito { get; set; } = IndicadorOrigemCredito.OperacaoMercadoInterno;
        public string CodigoContaContabil { get; set; } = null;
        public string CodigoCentroCustos { get; set; } = null;
        public string DescricaoDocOperacao { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|F100|");
            writer.Append(((int)IndicadorTipoOperacaoF).ToString() + "|");
            writer.Append(CodigoParticipante + "|");
            writer.Append(CodigoItem + "|");
            writer.Append(DataOperacao.ToSpedString() + "|");
            writer.Append(ValorOperacaoItem + "|");
            writer.Append(CSTPis + "|");
            writer.Append(VrBcPis + "|");
            writer.Append(AliqPis + "|");
            writer.Append(VrPis + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(VrBcCofins + "|");
            writer.Append(AliqCofins + "|");
            writer.Append(VrCofins + "|");
            writer.Append(NatBcCredito + "|");
            writer.Append(((int)IndicadorOrigemCredito).ToString() + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(CodigoCentroCustos + "|");
            writer.Append(DescricaoDocOperacao + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorTipoOperacaoF = (IndicadorTipoOperacaoF)data[2].ToEnum<IndicadorTipoOperacaoF>(IndicadorTipoOperacaoF.OperacaoRepresentativaAquisCustosDespEncargRecIncPisCofins);
            CodigoParticipante = data[3];
            CodigoItem = data[4];
            DataOperacao = data[5].ToDate();
            ValorOperacaoItem = data[6].ToNullableDouble();
            CSTPis = data[7];
            VrBcPis = data[8].ToNullableDouble();
            AliqPis = data[9].ToNullableDouble();
            VrPis = data[10].ToNullableDouble();
            CSTCofins = data[11];
            VrBcCofins = data[12].ToNullableDouble();
            AliqCofins = data[13].ToNullableDouble();
            VrCofins = data[14].ToNullableDouble();
            NatBcCredito = data[15];
            IndicadorOrigemCredito = (IndicadorOrigemCredito)data[16].ToEnum<IndicadorOrigemCredito>(IndicadorOrigemCredito.OperacaoMercadoInterno);
            CodigoContaContabil = data[17];
            CodigoCentroCustos = data[18];
            DescricaoDocOperacao = data[19];
        }
    }
}