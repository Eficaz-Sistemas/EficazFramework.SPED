using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Resumo da Escrituração Diária - Bilhetes Consolidados
    /// </summary>
    /// <remarks></remarks>

    public class RegistroD300 : Primitives.Registro
    {
        public RegistroD300() : base("D300")
        {
        }

        public RegistroD300(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoModeloDocFiscal { get; set; } = null;
        public string SerieDocFiscal { get; set; } = null;
        public string SubSerieDocFiscal { get; set; } = null;
        public long? NumeroDocFiscalInicial { get; set; }
        public long? NumeroDocFiscalFinal { get; set; }
        public string CFOP { get; set; } = null;
        public DateTime? DataReferenciaResumoDiario { get; set; }
        public double? VrTotalDocsFiscais { get; set; }
        public double? VrTotalDescontos { get; set; }
        public string CSTPis { get; set; } = null;
        public double? VrBcPis { get; set; }
        public double? AliquotaPis { get; set; }
        public double? VrPis { get; set; }
        public string CSTCofins { get; set; } = null;
        public double? VrBcCofins { get; set; }
        public double? AliquotaCofins { get; set; }
        public double? VrCofins { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|D209|");
            writer.Append(CodigoModeloDocFiscal + "|");
            writer.Append(SerieDocFiscal + "|");
            writer.Append(SubSerieDocFiscal + "|");
            writer.Append(NumeroDocFiscalInicial + "|");
            writer.Append(NumeroDocFiscalFinal + "|");
            writer.Append(CFOP + "|");
            writer.Append(DataReferenciaResumoDiario + "|");
            writer.Append(VrTotalDocsFiscais + "|");
            writer.Append(VrTotalDescontos + "|");
            writer.Append(CSTPis + "|");
            writer.Append(VrBcPis + "|");
            writer.Append(VrPis + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(VrBcCofins + "|");
            writer.Append(AliquotaCofins + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoModeloDocFiscal = data[2];
            SerieDocFiscal = data[3];
            SubSerieDocFiscal = data[4];
            NumeroDocFiscalInicial = data[5].ToNullableLong();
            NumeroDocFiscalFinal = data[6].ToNullableLong();
            CFOP = data[7];
            DataReferenciaResumoDiario = data[8].ToDate();
            VrTotalDocsFiscais = data[9].ToNullableDouble();
            VrTotalDescontos = data[10].ToNullableDouble();
            CSTPis = data[11];
            VrBcPis = data[12].ToNullableDouble();
            AliquotaPis = data[13].ToNullableDouble();
            VrPis = data[14].ToNullableDouble();
            CSTCofins = data[15];
            VrBcCofins = data[16].ToNullableDouble();
            AliquotaCofins = data[17].ToNullableDouble();
            VrCofins = data[18].ToNullableDouble();
            CodigoContaContabil = data[19];
        }
    }
}