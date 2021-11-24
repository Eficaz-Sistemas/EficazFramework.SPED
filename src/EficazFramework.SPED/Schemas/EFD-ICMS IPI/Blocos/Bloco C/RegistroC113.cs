using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Documento Fiscal Referenciado
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC113 : Primitives.Registro
    {
        public RegistroC113() : base("C113")
        {
        }

        public RegistroC113(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C113|"); // 1
            writer.Append(((int)Operacao).ToString() + "|"); // 2
            writer.Append(((int)Emissao).ToString() + "|"); // 3
            writer.Append(CodigoParticipante + "|"); // 4
            writer.Append(EspecieDocumento + "|"); // 5
            writer.Append(Serie + "|"); // 6
            writer.Append(SubSerie + "|"); // 7
            writer.Append(Numero + "|"); // 8
            writer.Append(Data.ToSpedString() + "|"); // 9
            writer.Append(ChaveDoce + "|"); // 10
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Operacao = (IndicadorOperacao)data[2].ToEnum<IndicadorOperacao>(IndicadorOperacao.Entrada);
            Emissao = (IndicadorEmitente)data[3].ToEnum<IndicadorEmitente>(IndicadorEmitente.Propria);
            CodigoParticipante = data[4];
            EspecieDocumento = data[5];
            Serie = data[6];
            SubSerie = data[7].ToNullableInteger();
            Numero = data[8].ToNullableInteger();
            Data = data[9].ToDate();
            ChaveDoce = data[10].ToString();
        }

        public IndicadorOperacao Operacao { get; set; } = IndicadorOperacao.Entrada;
        public IndicadorEmitente Emissao { get; set; } = IndicadorEmitente.Propria;
        public string CodigoParticipante { get; set; } = null; // 4
        public string EspecieDocumento { get; set; } = null; // 5
        public string Serie { get; set; } = null; // 6
        public int? SubSerie { get; set; } = default; // 7
        public int? Numero { get; set; } = default; // 8
        public DateTime? Data { get; set; } = default; // 9
        public string ChaveDoce { get; set; } = null; // 10
    }
}