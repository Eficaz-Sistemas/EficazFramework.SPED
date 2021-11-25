using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Apuração de Crédito Extemporâneo - Documentos e Operações de Períodos Anteriores
    /// </summary>
    /// <remarks></remarks>

    public class Registro1501 : Primitives.Registro
    {
        public Registro1501() : base("1501")
        {
        }

        public Registro1501(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoParticipante { get; set; } = null;
        public string CodigoItem { get; set; } = null;
        public string CodigoModDocFiscal { get; set; } = null;
        public string SerieDocFiscal { get; set; } = null;
        public string SubSerieDocFiscal { get; set; } = null;
        public string NumeroDocFiscal { get; set; } = null;
        public DateTime? DataOperacao { get; set; }
        public string ChaveNFe { get; set; } = null;
        public double? VrOperacao { get; set; }
        public string CFOP { get; set; } = null;
        public string CodigoBCCredito { get; set; } = null;
        public IndicadorOrigemCredito IndicadorOrigemCredito { get; set; } = IndicadorOrigemCredito.OperacaoMercadoInterno;
        public string CSTCofins { get; set; } = null;
        public double? VrBCCofins { get; set; }
        public double? AliqCofins { get; set; }
        public double? VrCredCofins { get; set; }
        public string CodigoContaContabil { get; set; } = null;
        public string CodigoCentroCusto { get; set; } = null;
        public string DescricaoComplementar { get; set; } = null;
        public DateTime? MesAnoEscrituracao { get; set; }
        public string CNPJEstabelecimentoCredito { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1501|");
            writer.Append(CodigoParticipante + "|");
            writer.Append(CodigoItem + "|");
            writer.Append(CodigoModDocFiscal + "|");
            writer.Append(SerieDocFiscal + "|");
            writer.Append(SubSerieDocFiscal + "|");
            writer.Append(NumeroDocFiscal + "|");
            writer.Append(DataOperacao + "|");
            writer.Append(ChaveNFe + "|");
            writer.Append(VrOperacao + "|");
            writer.Append(CFOP + "|");
            writer.Append(CodigoBCCredito + "|");
            writer.Append(((int)IndicadorOrigemCredito).ToString() + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(VrBCCofins + "|");
            writer.Append(AliqCofins + "|");
            writer.Append(VrCredCofins + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(CodigoCentroCusto + "|");
            writer.Append(DescricaoComplementar + "|");
            writer.Append(MesAnoEscrituracao + "|");
            writer.Append(CNPJEstabelecimentoCredito + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoParticipante = data[2];
            CodigoItem = data[3];
            CodigoModDocFiscal = data[4];
            SerieDocFiscal = data[5];
            SubSerieDocFiscal = data[6];
            NumeroDocFiscal = data[7];
            DataOperacao = data[8].ToDate();
            ChaveNFe = data[9];
            VrOperacao = data[10].ToNullableDouble();
            CFOP = data[11];
            CodigoBCCredito = data[12];
            IndicadorOrigemCredito = (IndicadorOrigemCredito)data[13].ToEnum<IndicadorOrigemCredito>(IndicadorOrigemCredito.OperacaoMercadoInterno);
            CSTCofins = data[14];
            VrBCCofins = data[15].ToNullableDouble();
            AliqCofins = data[16].ToNullableDouble();
            VrCredCofins = data[17].ToNullableDouble();
            CodigoContaContabil = data[18];
            CodigoCentroCusto = data[19];
            DescricaoComplementar = data[20];
            MesAnoEscrituracao = data[21].ToDate();
            CNPJEstabelecimentoCredito = data[22];
        }
    }
}