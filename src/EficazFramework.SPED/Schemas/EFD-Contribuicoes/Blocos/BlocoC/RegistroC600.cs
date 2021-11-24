using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Consolidação Diária de Notas fiscais/contas emitidas de energia elétrica
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC600 : Primitives.Registro
    {
        public RegistroC600() : base("C600")
        {
        }

        public RegistroC600(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodModDocFiscal { get; set; } = null;
        public string CodMunicipioIBGE { get; set; } = null;
        public string SerieDocFiscal { get; set; } = null;
        public string SubSerieDocFiscal { get; set; } = null;
        public string CodClasseConsEnergia { get; set; } = null;
        public int? QtdeDocsConsolidadosRegistro { get; set; }
        public int? QtdeDocsCancelados { get; set; }
        public DateTime? DataDocConsolidados { get; set; }
        public double? VrTotalDocs { get; set; }
        public double? VrAcumDescontos { get; set; }
        public double? ConsumoTotalAcum { get; set; }
        public double? VrAcumFornecimento { get; set; }
        public double? VrAcumServNaoTributICMS { get; set; }
        public double? VrCobradosNomeTerceiros { get; set; }
        public double? VrAcumDespAcessorias { get; set; }
        public double? VrAcumBCICMS { get; set; }
        public double? VrAcumICMS { get; set; }
        public double? VrAcumBCICMSST { get; set; }
        public double? VrAcumICMSretidoST { get; set; }
        public double? VrAcumPIS { get; set; }
        public double? VrAcumCofins { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C600|");
            writer.Append(CodModDocFiscal + "|");
            writer.Append(CodMunicipioIBGE + "|");
            writer.Append(SerieDocFiscal + "|");
            writer.Append(SubSerieDocFiscal + "|");
            writer.Append(CodClasseConsEnergia + "|");
            writer.Append(QtdeDocsConsolidadosRegistro + "|");
            writer.Append(QtdeDocsCancelados + "|");
            writer.Append(DataDocConsolidados + "|");
            writer.Append(VrTotalDocs + "|");
            writer.Append(VrAcumDescontos + "|");
            writer.Append(ConsumoTotalAcum + "|");
            writer.Append(VrAcumFornecimento + "|");
            writer.Append(VrAcumServNaoTributICMS + "|");
            writer.Append(VrCobradosNomeTerceiros + "|");
            writer.Append(VrAcumDespAcessorias + "|");
            writer.Append(VrAcumBCICMS + "|");
            writer.Append(VrAcumICMS + "|");
            writer.Append(VrAcumBCICMSST + "|");
            writer.Append(VrAcumICMSretidoST + "|");
            writer.Append(VrAcumPIS + "|");
            writer.Append(VrAcumCofins + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodModDocFiscal = data[2];
            CodMunicipioIBGE = data[3];
            SerieDocFiscal = data[4];
            SubSerieDocFiscal = data[5];
            CodClasseConsEnergia = data[6];
            QtdeDocsConsolidadosRegistro = data[7].ToNullableInteger();
            QtdeDocsCancelados = data[8].ToNullableInteger();
            DataDocConsolidados = data[9].ToDate();
            VrTotalDocs = data[10].ToNullableDouble();
            VrAcumDescontos = data[11].ToNullableDouble();
            ConsumoTotalAcum = data[12].ToNullableDouble();
            VrAcumFornecimento = data[13].ToNullableDouble();
            VrAcumServNaoTributICMS = data[14].ToNullableDouble();
            VrCobradosNomeTerceiros = data[15].ToNullableDouble();
            VrAcumDespAcessorias = data[16].ToNullableDouble();
            VrAcumBCICMS = data[17].ToNullableDouble();
            VrAcumICMS = data[18].ToNullableDouble();
            VrAcumBCICMSST = data[19].ToNullableDouble();
            VrAcumICMSretidoST = data[20].ToNullableDouble();
            VrAcumPIS = data[21].ToNullableDouble();
            VrAcumCofins = data[22].ToNullableDouble();
        }
    }
}