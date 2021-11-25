using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Nota Fiscal Serviços de Comunicação
    /// </summary>
    /// <remarks></remarks>

    public class RegistroD500 : Primitives.Registro
    {
        public RegistroD500() : base("D500")
        {
        }

        public RegistroD500(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public IndicadorTipoOperacaoBlocoD IndicadorTipoOperacao { get; set; } = IndicadorTipoOperacaoBlocoD.Aquisicao;
        public EFD_ICMS_IPI.IndicadorEmitente IndicadorEmitenteDocFiscal { get; set; } = EFD_ICMS_IPI.IndicadorEmitente.Propria;
        public string CodigoParticipante { get; set; } = null;
        public string CodigoModeloDocFiscal { get; set; } = null;
        public string CodigoSituacaoDocFiscal { get; set; } = null;
        public string SerieDocFiscal { get; set; } = null;
        public string SubSerieDocFiscal { get; set; } = null;
        public long? NumeroDocFiscal { get; set; }
        public DateTime? DataEmissaoDocFiscal { get; set; }
        public DateTime? DataEntrada { get; set; }
        public double? VrTotalDocFiscal { get; set; }
        public double? VrTotalDesconto { get; set; }
        public double? VrPrestacaoServico { get; set; }
        public double? VrTotalServicosNaoTribICMS { get; set; }
        public double? VrCobradoNomeTerceiro { get; set; }
        public double? VrOutrasDespesas { get; set; }
        public double? VrBcICMS { get; set; }
        public double? VrICMS { get; set; }
        public string CodigoInfoComplementar { get; set; } = null;
        public double? VrPis { get; set; }
        public double? VrCofins { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|D500|");
            writer.Append(((int)IndicadorTipoOperacao).ToString() + "|");
            writer.Append(((int)IndicadorEmitenteDocFiscal).ToString() + "|");
            writer.Append(CodigoParticipante + "|");
            writer.Append(CodigoModeloDocFiscal + "|");
            writer.Append(CodigoSituacaoDocFiscal + "|");
            writer.Append(SerieDocFiscal + "|");
            writer.Append(SubSerieDocFiscal + "|");
            writer.Append(NumeroDocFiscal + "|");
            writer.Append(DataEmissaoDocFiscal + "|");
            writer.Append(DataEntrada + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalDocFiscal) + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalDesconto) + "|");
            writer.Append(string.Format("{0:0.##}", VrPrestacaoServico) + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalServicosNaoTribICMS) + "|");
            writer.Append(string.Format("{0:0.##}", VrCobradoNomeTerceiro) + "|");
            writer.Append(string.Format("{0:0.##}", VrOutrasDespesas) + "|");
            writer.Append(string.Format("{0:0.##}", VrBcICMS) + "|");
            writer.Append(string.Format("{0:0.##}", VrICMS) + "|");
            writer.Append(CodigoInfoComplementar + "|");
            writer.Append(string.Format("{0:0.##}", VrPis) + "|");
            writer.Append(string.Format("{0:0.##}", VrCofins) + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorTipoOperacao = (IndicadorTipoOperacaoBlocoD)data[2].ToEnum<IndicadorTipoOperacaoBlocoD>(IndicadorTipoOperacaoBlocoD.Aquisicao);
            IndicadorEmitenteDocFiscal = (EFD_ICMS_IPI.IndicadorEmitente)data[3].ToEnum<EFD_ICMS_IPI.IndicadorEmitente>(EFD_ICMS_IPI.IndicadorEmitente.Propria);
            CodigoParticipante = data[4];
            CodigoModeloDocFiscal = data[5];
            CodigoSituacaoDocFiscal = data[6];
            SerieDocFiscal = data[7];
            SubSerieDocFiscal = data[8];
            NumeroDocFiscal = data[9].ToNullableLong();
            DataEmissaoDocFiscal = data[10].ToDate();
            DataEntrada = data[11].ToDate();
            VrTotalDocFiscal = data[12].ToNullableDouble();
            VrTotalDesconto = data[13].ToNullableDouble();
            VrPrestacaoServico = data[14].ToNullableDouble();
            VrTotalServicosNaoTribICMS = data[15].ToNullableDouble();
            VrCobradoNomeTerceiro = data[16].ToNullableDouble();
            VrOutrasDespesas = data[17].ToNullableDouble();
            VrBcICMS = data[18].ToNullableDouble();
            VrICMS = data[19].ToNullableDouble();
            CodigoInfoComplementar = Conversions.ToString(data[20].ToNullableDouble());
            VrPis = data[21].ToNullableDouble();
            VrCofins = data[22].ToNullableDouble();
        }
    }
}