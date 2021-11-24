using System;
using EficazFrameworkCore.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Aquisição de Serviços de Transporte
    /// </summary>
    /// <remarks></remarks>

    public class RegistroD100 : Primitives.Registro
    {
        public RegistroD100() : base("D100")
        {
        }

        public RegistroD100(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public IndicadorTipoOperacaoBlocoD IndicadorOperacao { get; set; } = IndicadorTipoOperacaoBlocoD.Aquisicao;
        public EFD_ICMS_IPI.IndicadorEmitente IndicadorEmitenteDocFiscal { get; set; } = EFD_ICMS_IPI.IndicadorEmitente.Propria;
        public string CodigoParticipante { get; set; } = null;
        public string CodigoModeloDocFiscal { get; set; } = null;
        public string CodigoSituacaoDocFiscal { get; set; } = null;
        public string SerieDocFiscal { get; set; } = null;
        public string SubSerieDocFiscal { get; set; } = null;
        public long? NumeroDocFiscal { get; set; }
        public string ChaveCte { get; set; } = null;
        public DateTime? DataEmissaoDocFiscal { get; set; }
        public DateTime? DataAquisicaoPrestServico { get; set; }
        public string TipoCte { get; set; } = null;
        public string ChaveCteReferencia { get; set; } = null;
        public double? VrTotalDocFiscal { get; set; }
        public double? VrTotalDesconto { get; set; }
        public EFD_ICMS_IPI.IndicadorFrete IndicadorTipoFrete { get; set; } = EFD_ICMS_IPI.IndicadorFrete.Destinatario_Remetente;
        public double? VrTotalPrestacaoServ { get; set; }
        public double? VrBcICMS { get; set; }
        public double? VrICMS { get; set; }
        public double? VrNãoTributadoICMS { get; set; }
        public string CodigoInfoComplementarDocFiscal { get; set; } = null;
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|D100|");
            writer.Append(((int)IndicadorOperacao).ToString() + "|");
            writer.Append(((int)IndicadorEmitenteDocFiscal).ToString() + "|");
            writer.Append(CodigoParticipante + "|");
            writer.Append(CodigoModeloDocFiscal + "|");
            writer.Append(string.Format("{0:00}", Conversions.ToInteger(CodigoSituacaoDocFiscal)) + "|");
            writer.Append(SerieDocFiscal + "|");
            writer.Append(SubSerieDocFiscal + "|");
            writer.Append(NumeroDocFiscal + "|");
            writer.Append(ChaveCte + "|");
            writer.Append(DataEmissaoDocFiscal.ToSpedString() + "|");
            writer.Append(DataAquisicaoPrestServico.ToSpedString() + "|");
            writer.Append(TipoCte + "|");
            writer.Append(ChaveCteReferencia + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalDocFiscal) + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalDesconto) + "|");
            writer.Append(((int)IndicadorTipoFrete).ToString() + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalPrestacaoServ) + "|");
            writer.Append(string.Format("{0:0.##}", VrBcICMS) + "|");
            writer.Append(string.Format("{0:0.##}", VrICMS) + "|");
            writer.Append(string.Format("{0:0.##}", VrNãoTributadoICMS) + "|");
            writer.Append(CodigoInfoComplementarDocFiscal + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorOperacao = (IndicadorTipoOperacaoBlocoD)data[2].ToEnum<IndicadorTipoOperacaoBlocoD>(IndicadorTipoOperacaoBlocoD.Aquisicao);
            IndicadorEmitenteDocFiscal = (EFD_ICMS_IPI.IndicadorEmitente)data[3].ToEnum<EFD_ICMS_IPI.IndicadorEmitente>(EFD_ICMS_IPI.IndicadorEmitente.Propria);
            CodigoParticipante = data[4];
            CodigoModeloDocFiscal = data[5];
            CodigoSituacaoDocFiscal = data[6];
            SerieDocFiscal = data[7];
            SubSerieDocFiscal = data[8];
            NumeroDocFiscal = data[9].ToNullableLong();
            ChaveCte = data[10];
            DataEmissaoDocFiscal = data[11].ToDate();
            DataAquisicaoPrestServico = data[12].ToDate();
            TipoCte = data[13];
            ChaveCteReferencia = data[14];
            VrTotalDocFiscal = data[15].ToNullableDouble();
            VrTotalDesconto = data[16].ToNullableDouble();
            IndicadorTipoFrete = (EFD_ICMS_IPI.IndicadorFrete)data[17].ToEnum<EFD_ICMS_IPI.IndicadorFrete>(EFD_ICMS_IPI.IndicadorFrete.Destinatario_Remetente);
            VrTotalPrestacaoServ = data[18].ToNullableDouble();
            VrBcICMS = data[19].ToNullableDouble();
            VrICMS = data[20].ToNullableDouble();
            VrNãoTributadoICMS = data[21].ToNullableDouble();
            CodigoInfoComplementarDocFiscal = data[22];
            CodigoContaContabil = data[23];
        }
    }
}