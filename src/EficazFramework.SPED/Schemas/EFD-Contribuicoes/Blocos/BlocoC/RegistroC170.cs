using EficazFrameworkCore.SPED.Extensions;
using EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento do Documento - itens do documento
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC170 : Primitives.Registro
    {
        public RegistroC170() : base("C170")
        {
        }

        public RegistroC170(string linha, string versao) : base(linha, versao)
        {
        }

        // campos'
        public short? NumeroSequenciaItem { get; set; }
        public string CodigoItem { get; set; }
        public string DescricaoItem { get; set; }
        public double? QuantidadeItem { get; set; }
        public string UnidadeItem { get; set; }
        public double? VrItem { get; set; }
        public double? VrDesconto { get; set; }
        public bool? MovimentacaoFisica { get; set; }
        public NFe.OrigemMercadoria Origem { get; set; }
        public NFe.CST_ICMS CST_ICMS { get; set; }
        public string CFOP { get; set; }
        public string CodNaturezaOperacao { get; set; }
        public double? VrBaseCalculoICMS { get; set; }
        public double? AliquotaICMS { get; set; }
        public double? VrICMS { get; set; }
        public double? VrBaseCalculoICMSST { get; set; }
        public double? AliquotaICMSST { get; set; }
        public double? VrICMSST { get; set; }
        public IndicadorPeriodoIPI? IndicadorApuracaoIPI { get; set; }
        public NFe.CST_IPI CST_IPI { get; set; }
        public string CodEnquadramentoIPI { get; set; }
        public double? VrBaseCalculoIPI { get; set; }
        public double? AliquotaIPI { get; set; }
        public double? VrIPI { get; set; }
        public NFe.CST_PIS CST_PIS { get; set; }
        public double? VrBaseCalculoPIS { get; set; }
        public double? AliquotaPIS { get; set; }
        public double? QuantidadeBCPIS { get; set; }
        public double? AliquotaPISQuantidade { get; set; }
        public double? VrPIS { get; set; }
        public NFe.CST_COFINS CST_COFINS { get; set; }
        public double? VrBaseCalculoCOFINS { get; set; }
        public double? AliquotaCOFINS { get; set; }
        public double? QuantidadeBCCOFINS { get; set; }
        public double? AliquotaCOFINSQuantidade { get; set; }
        public double? VrCOFINS { get; set; }
        public string CodigoContaContabil { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C170|"); // 1
            writer.Append(NumeroSequenciaItem + "|"); // 2
            writer.Append(CodigoItem + "|"); // 3
            writer.Append(DescricaoItem + "|"); // 4
            writer.Append(string.Format("{0:0.#####}", QuantidadeItem) + "|"); // 5
            writer.Append(UnidadeItem + "|"); // 6
            writer.Append(string.Format("{0:0.##}", VrItem) + "|"); // 7
            writer.Append(string.Format("{0:0.##}", VrDesconto) + "|"); // 8
            if (MovimentacaoFisica == true == true)
                writer.Append(0 + "|");
            else
                writer.Append(1 + "|"); // 9
            writer.Append(((int)Origem).ToString() + string.Format("{0:00}", (int)CST_ICMS) + "|"); // 10
            writer.Append(CFOP + "|"); // 11
            writer.Append(CodNaturezaOperacao + "|"); // 12
            writer.Append(string.Format("{0:0.##}", VrBaseCalculoICMS) + "|"); // 13
            writer.Append(string.Format("{0:0.##}", AliquotaICMS) + "|"); // 14
            writer.Append(string.Format("{0:0.##}", VrICMS) + "|"); // 15
            writer.Append(string.Format("{0:0.##}", VrBaseCalculoICMSST) + "|"); // 16
            writer.Append(string.Format("{0:0.##}", AliquotaICMSST) + "|"); // 17
            writer.Append(string.Format("{0:0.##}", VrICMSST) + "|"); // 18
            if (IndicadorApuracaoIPI.HasValue == false)
                writer.Append("|");
            else
            {
                if ((int?)IndicadorApuracaoIPI == (int?)IndicadorPeriodoIPI.Decendial == true)
                    writer.Append(1 + "|");
                else
                    writer.Append(0 + "|");
            } // 19

            writer.Append(string.Format("{0:#00}", (int)CST_IPI) + "|"); // 20
            writer.Append(CodEnquadramentoIPI + "|"); // 21
            writer.Append(string.Format("{0:0.##}", VrBaseCalculoIPI) + "|"); // 22
            writer.Append(string.Format("{0:0.##}", AliquotaIPI) + "|"); // 23
            writer.Append(string.Format("{0:0.##}", VrIPI) + "|"); // 24
            if (CST_PIS != NFe.CST_PIS.NotValid)
                writer.Append(string.Format("{0:#00}", (int)CST_PIS) + "|");
            else
                writer.Append("|"); // 25
            writer.Append(string.Format("{0:0.##}", VrBaseCalculoPIS) + "|"); // 26
            writer.Append(string.Format("{0:0.####}", AliquotaPIS) + "|"); // 27
            writer.Append(string.Format("{0:0.###}", QuantidadeBCPIS) + "|"); // 28
            writer.Append(string.Format("{0:0.####}", AliquotaPISQuantidade) + "|"); // 29
            writer.Append(string.Format("{0:0.##}", VrPIS) + "|"); // 30
            if (CST_COFINS != NFe.CST_COFINS.NotValid)
                writer.Append(string.Format("{0:#00}", (int)CST_COFINS) + "|");
            else
                writer.Append("|"); // 31
            writer.Append(string.Format("{0:0.##}", VrBaseCalculoCOFINS) + "|"); // 32
            writer.Append(string.Format("{0:0.####}", AliquotaCOFINS) + "|"); // 33
            writer.Append(string.Format("{0:0.###}", QuantidadeBCCOFINS) + "|"); // 34
            writer.Append(string.Format("{0:0.####}", AliquotaCOFINSQuantidade) + "|"); // 35
            writer.Append(string.Format("{0:0.##}", VrCOFINS) + "|"); // 36
            writer.Append(CodigoContaContabil + "|"); // 37
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroSequenciaItem = data[2].ToNullableShort();
            CodigoItem = data[3];
            DescricaoItem = data[4];
            QuantidadeItem = data[5].ToNullableDouble();
            UnidadeItem = data[6];
            VrItem = data[7].ToNullableDouble();
            VrDesconto = data[8].ToNullableDouble();
            if (data[9] == "0")
            {
                MovimentacaoFisica = true;
            }
            else
            {
                MovimentacaoFisica = false;
            }

            CST_ICMS = (NFe.CST_ICMS)Conversions.ToInteger(data[10]);
            CFOP = data[11];
            CodNaturezaOperacao = data[12];
            VrBaseCalculoICMS = data[13].ToNullableDouble();
            AliquotaICMS = data[14].ToNullableDouble();
            VrICMS = data[15].ToNullableDouble();
            VrBaseCalculoICMSST = data[16].ToNullableDouble();
            AliquotaICMSST = data[17].ToNullableDouble();
            VrICMSST = data[18].ToNullableDouble();
            IndicadorApuracaoIPI = (IndicadorPeriodoIPI?)data[19].ToEnum<IndicadorPeriodoIPI>(IndicadorPeriodoIPI.Mensal);
            CST_IPI = (NFe.CST_IPI)Conversions.ToInteger(data[20]);
            CodEnquadramentoIPI = data[21];
            VrBaseCalculoIPI = data[22].ToNullableDouble();
            AliquotaIPI = data[23].ToNullableDouble();
            VrIPI = data[24].ToNullableDouble();
            CST_PIS = (NFe.CST_PIS)Conversions.ToInteger(data[25]);
            VrBaseCalculoPIS = data[26].ToNullableDouble();
            AliquotaPIS = data[27].ToNullableDouble();
            QuantidadeBCPIS = data[28].ToNullableDouble();
            AliquotaPISQuantidade = data[29].ToNullableDouble();
            VrPIS = data[30].ToNullableDouble();
            CST_COFINS = (NFe.CST_COFINS)Conversions.ToInteger(data[31]);
            VrBaseCalculoCOFINS = data[32].ToNullableDouble();
            AliquotaCOFINS = data[33].ToNullableDouble();
            QuantidadeBCCOFINS = data[34].ToNullableDouble();
            AliquotaCOFINSQuantidade = data[35].ToNullableDouble();
            VrCOFINS = data[36].ToNullableDouble();
            CodigoContaContabil = data[37];
        }
    }
}