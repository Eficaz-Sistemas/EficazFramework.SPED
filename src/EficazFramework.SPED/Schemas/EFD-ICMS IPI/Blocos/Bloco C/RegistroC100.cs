using System;
using System.Collections.Generic;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Documentos Fiscais (01, 1B, 04, 55 e 65)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC100 : Primitives.Registro
    {
        public RegistroC100() : base("C100")
        {
        }

        public RegistroC100(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C100|"); // 1
            writer.Append(((int)Operacao).ToString() + "|"); // 2
            writer.Append(((int)Emissao).ToString() + "|");  // 3
            if (DocumentoValido())
                writer.Append(CodigoParticipante + "|");
            else
                writer.Append("|"); // 4
            writer.Append(EspecieDocumento + "|"); // 5
            writer.Append(string.Format("{0:00}", (int)SituacaoDocumento) + "|"); // 6
            writer.Append(Serie.ToFixedLenghtString(3, Alignment.Left, "0") + "|"); // 7
            writer.Append(Numero + "|"); // 8
            writer.Append(ChaveNFe + "|"); // 9
            if (DocumentoValido())
                writer.Append(DataEmissao.ToSpedString() + "|");
            else
                writer.Append("|"); // 10
            if (DocumentoValido())
                writer.Append(DataEntradaSaida.ToSpedString() + "|");
            else
                writer.Append("|"); // 11
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorTotalDocumento) + "|");
            else
                writer.Append("|"); // 12
            if (DocumentoValido())
                writer.Append(((int)Pagamento).ToString() + "|");
            else
                writer.Append("|"); // 13
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorDesconto) + "|");
            else
                writer.Append("|"); // 14
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorAbatimento) + "|");
            else
                writer.Append("|"); // 15
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorTotalMercadorias) + "|");
            else
                writer.Append("|"); // 16
            if (DocumentoValido())
                writer.Append(((int)TipoFrete).ToString() + "|");
            else
                writer.Append("|"); // 17
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorFrete) + "|");
            else
                writer.Append("|"); // 18
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorSeguro) + "|");
            else
                writer.Append("|"); // 19
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorOutrasDespesas) + "|");
            else
                writer.Append("|"); // 20
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorBaseCalculoICMS) + "|");
            else
                writer.Append("|"); // 21
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorICMS) + "|");
            else
                writer.Append("|"); // 22
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorBaseCalculoICMSST) + "|");
            else
                writer.Append("|"); // 23
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorICMSST) + "|");
            else
                writer.Append("|"); // 24
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorIPI) + "|");
            else
                writer.Append("|"); // 25
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorPIS) + "|");
            else
                writer.Append("|"); // 26
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorCofins) + "|");
            else
                writer.Append("|"); // 27
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorPISST) + "|");
            else
                writer.Append("|"); // 28
            if (DocumentoValido())
                writer.Append(string.Format("{0:0.##}", ValorCofinsST) + "|");
            else
                writer.Append("|"); // 29
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Operacao = (IndicadorOperacao)data[2].ToEnum<IndicadorOperacao>(IndicadorOperacao.Entrada);
            Emissao = (IndicadorEmitente)data[3].ToEnum<IndicadorEmitente>(IndicadorEmitente.Terceiros);
            CodigoParticipante = data[4];
            EspecieDocumento = data[5];
            SituacaoDocumento = (SituacaoDocumento)data[6].ToEnum<SituacaoDocumento>(SituacaoDocumento.Cancelado);
            Serie = data[7];
            Numero = data[8].ToNullableInteger();
            ChaveNFe = data[9];
            DataEmissao = data[10].ToDate();
            DataEntradaSaida = data[11].ToDate();
            ValorTotalDocumento = data[12].ToNullableDouble();
            Pagamento = (IndicadorPagamento)data[13].ToEnum<IndicadorPagamento>(IndicadorPagamento.Outros);
            ValorDesconto = data[14].ToNullableDouble();
            ValorAbatimento = data[15].ToNullableDouble();
            ValorTotalMercadorias = data[16].ToNullableDouble();
            TipoFrete = (IndicadorFrete)data[17].ToEnum<IndicadorFrete>(IndicadorFrete.SemFrete);
            ValorFrete = data[18].ToNullableDouble();
            ValorSeguro = data[19].ToNullableDouble();
            ValorOutrasDespesas = data[20].ToNullableDouble();
            ValorBaseCalculoICMS = data[21].ToNullableDouble();
            ValorICMS = data[22].ToNullableDouble();
            ValorBaseCalculoICMSST = data[23].ToNullableDouble();
            ValorICMSST = data[24].ToNullableDouble();
            ValorIPI = data[25].ToNullableDouble();
            ValorPIS = data[26].ToNullableDouble();
            ValorCofins = data[27].ToNullableDouble();
            ValorPISST = data[28].ToNullableDouble();
            ValorCofinsST = data[29].ToNullableDouble();
        }

        public IndicadorOperacao Operacao { get; set; } = IndicadorOperacao.Entrada; // 2
        public IndicadorEmitente Emissao { get; set; } = IndicadorEmitente.Propria; // 3
        public string CodigoParticipante { get; set; } = null; // 4
        public string EspecieDocumento { get; set; } = null; // 5
        public SituacaoDocumento SituacaoDocumento { get; set; } = SituacaoDocumento.Regular; // 6
        public string Serie { get; set; } = null; // 7
        public int? Numero { get; set; } = default; // 8
        public string ChaveNFe { get; set; } = null; // 9
        public DateTime? DataEmissao { get; set; } = default; // 10
        public DateTime? DataEntradaSaida { get; set; } = default; // 11
        public double? ValorTotalDocumento { get; set; } = default; // 12
        public IndicadorPagamento Pagamento { get; set; } = IndicadorPagamento.Outros; // 13
        public double? ValorDesconto { get; set; } = default; // 14
        public double? ValorAbatimento { get; set; } = default; // 15
        public double? ValorTotalMercadorias { get; set; } = default; // 16
        public IndicadorFrete TipoFrete { get; set; } = IndicadorFrete.SemFrete; // 17
        public double? ValorFrete { get; set; } = default; // 18
        public double? ValorSeguro { get; set; } = default; // 19
        public double? ValorOutrasDespesas { get; set; } = default; // 20
        public double? ValorBaseCalculoICMS { get; set; } = default; // 21
        public double? ValorICMS { get; set; } = default; // 22
        public double? ValorBaseCalculoICMSST { get; set; } = default; // 23
        public double? ValorICMSST { get; set; } = default; // 24
        public double? ValorIPI { get; set; } = default; // 25
        public double? ValorPIS { get; set; } = default; // 26
        public double? ValorCofins { get; set; } = default; // 27
        public double? ValorPISST { get; set; } = default; // 28
        public double? ValorCofinsST { get; set; } = default; // 29

        // Registros Filhos
        public RegistroC101 RegistroC101 { get; set; }
        public List<RegistroC113> RegistrosC113 { get; set; } = new List<RegistroC113>();
        public List<RegistroC114> RegistrosC114 { get; set; } = new List<RegistroC114>();
        public List<RegistroC120> RegistrosC120 { get; set; } = new List<RegistroC120>();
        public RegistroC130 RegistroC130 { get; set; }
        public RegistroC140 RegistroC140 { get; set; }
        public List<RegistroC170> RegistrosC170 { get; set; } = new List<RegistroC170>();
        public List<RegistroC190> RegistrosC190 { get; set; } = new List<RegistroC190>();
        public List<RegistroC195> RegistrosC195 { get; set; } = new List<RegistroC195>();

        public bool DocumentoValido()
        {
            if (SituacaoDocumento == SituacaoDocumento.Cancelado | SituacaoDocumento == SituacaoDocumento.CanceladoExtemporaneo | SituacaoDocumento == SituacaoDocumento.Denegado | SituacaoDocumento == SituacaoDocumento.Inutilizado)
                return false;
            else
                return true;
        }
    }
}