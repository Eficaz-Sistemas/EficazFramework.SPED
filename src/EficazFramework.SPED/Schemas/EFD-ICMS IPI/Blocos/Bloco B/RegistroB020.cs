using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Abertura do Bloco B
    /// </summary>
    /// <remarks></remarks>
    public class RegistroB020 : Primitives.Registro
    {
        public RegistroB020() : base("B020")
        {
        }

        public RegistroB020(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|B020|"); // 1
            writer.Append(((int)IndicadorTipoOperacao).ToString() + "|"); // 2
            writer.Append(((int)IndicadorEmitente).ToString() + "|"); // 3
            if (DocumentoValido())
                writer.Append(CodigoParticipante + "|"); // 4
            writer.Append(EspecieDocumento + "|"); // 5
            writer.Append(string.Format("{0:00}", (int)SituacaoDocumento) + "|"); // 6
            writer.Append(Serie + "|"); // 7
            writer.Append(NumeroDoc + "|"); // 8
            writer.Append(ChaveNFe + "|"); // 9
            if (DocumentoValido())
                writer.Append(DataDoc.ToSpedString() + "|");
            else
                writer.Append("|"); // 10
            if (DocumentoValido())
                writer.Append(CodigoMunicipio.ToString() + "|");
            else
                writer.Append("|"); // 11
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorContabil) + "|");
            else
                writer.Append("|"); // 12
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorMaterialTerceiro) + "|");
            else
                writer.Append("|"); // 13
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorSubempreitada) + "|");
            else
                writer.Append("|"); // 14
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorISSIsentoNTrib) + "|");
            else
                writer.Append("|"); // 16
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorDedBC) + "|");
            else
                writer.Append("|"); // 17
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorBCISS) + "|");
            else
                writer.Append("|"); // 18
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorISSRetTomador) + "|");
            else
                writer.Append("|"); // 19
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorISSDestacado) + "|");
            else
                writer.Append("|"); // 20
            if (DocumentoValido())
                writer.Append(CodigoObsLactoFiscal.ToString() + "|");
            else
                writer.Append("|"); // 21
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorTipoOperacao = (IndicadorOperacao)data[2].ToEnum<IndicadorOperacao>(IndicadorOperacao.Entrada);
            IndicadorEmitente = (IndicadorEmitente)data[3].ToEnum<IndicadorEmitente>(IndicadorEmitente.Terceiros);
            CodigoParticipante = data[4].ToString();
            EspecieDocumento = data[5].ToString();
            SituacaoDocumento = (SituacaoDocumento)data[6].ToEnum<SituacaoDocumento>(SituacaoDocumento.Regular);
            Serie = data[7].ToString();
            NumeroDoc = data[8].ToNullableInteger();
            ChaveNFe = data[9].ToString();
            DataDoc = data[10].ToDate();
            CodigoMunicipio = data[11].ToString();
            ValorContabil = data[12].ToNullableDouble();
            ValorMaterialTerceiro = data[13].ToNullableDouble();
            ValorSubempreitada = data[14].ToNullableDouble();
            ValorISSIsentoNTrib = data[15].ToNullableDouble();
            ValorDedBC = data[16].ToNullableDouble();
            ValorBCISS = data[17].ToNullableDouble();
            ValorBCRetISS = data[18].ToNullableDouble();
            ValorISSRetTomador = data[19].ToNullableDouble();
            ValorISSDestacado = data[20].ToNullableDouble();
            CodigoObsLactoFiscal = data[21].ToString();
        }

        public IndicadorOperacao IndicadorTipoOperacao { get; set; } = IndicadorOperacao.Entrada; // 2
        public IndicadorEmitente IndicadorEmitente { get; set; } = IndicadorEmitente.Propria; // 3
        public string CodigoParticipante { get; set; } = null; // 4
        public string EspecieDocumento { get; set; } = null; // 5
        public SituacaoDocumento SituacaoDocumento { get; set; } = SituacaoDocumento.Regular; // 6
        public string Serie { get; set; } = null; // 7
        public int? NumeroDoc { get; set; } = default; // 8
        public string ChaveNFe { get; set; } = null; // 9
        public DateTime? DataDoc { get; set; } = default; // 10
        public string CodigoMunicipio { get; set; } = null; // 11
        public double? ValorContabil { get; set; } = default; // 12
        public double? ValorMaterialTerceiro { get; set; } = default; // 13
        public double? ValorSubempreitada { get; set; } = default; // 14
        public double? ValorISSIsentoNTrib { get; set; } = default; // 15
        public double? ValorDedBC { get; set; } = default; // 16
        public double? ValorBCISS { get; set; } = default; // 17
        public double? ValorBCRetISS { get; set; } = default; // 18
        public double? ValorISSRetTomador { get; set; } = default; // 19
        public double? ValorISSDestacado { get; set; } = default; // 20
        public string CodigoObsLactoFiscal { get; set; } = null; // 21

        public bool DocumentoValido()
        {
            if (SituacaoDocumento == SituacaoDocumento.Cancelado | SituacaoDocumento == SituacaoDocumento.CanceladoExtemporaneo | SituacaoDocumento == SituacaoDocumento.Denegado | SituacaoDocumento == SituacaoDocumento.Inutilizado)
                return false;
            else
                return true;
        }
    }
}