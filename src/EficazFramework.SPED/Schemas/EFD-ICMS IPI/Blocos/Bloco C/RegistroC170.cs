using System.Collections.Generic;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Items dos Documentos Fiscais
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

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C170|"); // 1
            writer.Append(string.Format("{0:##0}", NumeroSequencialItem) + "|"); // 2
            writer.Append(CodigoProduto + "|"); // 3
            writer.Append(DescricaoComplementarItem + "|"); // 4
            writer.Append(string.Format("{0:0.#####}", Quantidade) + "|"); // 5
            writer.Append(UnidadeMedida + "|"); // 6
            writer.Append(string.Format("{0:0.##}", TotalItem) + "|"); // 7
            writer.Append(string.Format("{0:0.##}", Desconto) + "|"); // 8
            if (IndicadorMovimento == true == true)
                writer.Append(0 + "|");
            else
                writer.Append(1 + "|"); // 9
            writer.Append(((int)Origem).ToString() + string.Format("{0:00}", (int)CST_ICMS) + "|"); // 10
            writer.Append(CFOP + "|"); // 11
            writer.Append(NaturezaOperacao + "|"); // 12
            writer.Append(string.Format("{0:0.##}", BaseCalculo_ICMS) + "|"); // 13
            writer.Append(string.Format("{0:0.##}", Aliquota_ICMS) + "|"); // 14
            writer.Append(string.Format("{0:0.##}", Valor_ICMS) + "|"); // 15
            writer.Append(string.Format("{0:0.##}", BaseCalculoST_ICMS) + "|"); // 16
            writer.Append(string.Format("{0:0.##}", AliquotaST_ICMS) + "|"); // 17
            writer.Append(string.Format("{0:0.##}", ValorST_ICMS) + "|"); // 18
            if (IndicadorApuracaoIPI.HasValue == false)
                writer.Append('|');
            else
            {
                if ((int?)IndicadorApuracaoIPI == (int?)IndicadorPeriodoIPI.Decendial == true)
                    writer.Append(1 + "|");
                else
                    writer.Append(0 + "|");
            } // 19

            writer.Append(string.Format("{0:#00}", Conversions.ToInteger(CST_IPI)) + "|"); // 20
            writer.Append(Enquadramento_IPI + "|"); // 21
            writer.Append(string.Format("{0:0.##}", BaseCalculo_IPI) + "|"); // 22
            writer.Append(string.Format("{0:0.##}", Aliquota_IPI) + "|"); // 23
            writer.Append(string.Format("{0:0.##}", Valor_IPI) + "|"); // 24
            writer.Append(string.Format("{0:#00}", (int)CST_PIS) + "|");  // 25
            writer.Append(string.Format("{0:0.##}", BaseCalculo_PIS) + "|"); // 26
            writer.Append(string.Format("{0:0.####}", AliquotaPercentual_PIS) + "|"); // 27
            writer.Append(string.Format("{0:0.###}", BaseCalculoQuantidade_PIS) + "|"); // 28
            writer.Append(string.Format("{0:0.####}", AliquotaReais_PIS) + "|"); // 29
            writer.Append(string.Format("{0:0.##}", Valor_PIS) + "|"); // 30
            writer.Append(string.Format("{0:#00}", (int)CST_COFINS) + "|"); // 31
            writer.Append(string.Format("{0:0.##}", BaseCalculo_COFINS) + "|"); // 32
            writer.Append(string.Format("{0:0.####}", AliquotaPercentual_COFINS) + "|"); // 33
            writer.Append(string.Format("{0:0.###}", BaseCalculoQuantidade_COFINS) + "|"); // 34
            writer.Append(string.Format("{0:0.####}", AliquotaReais_COFINS) + "|"); // 35
            writer.Append(string.Format("{0:0.##}", Valor_COFINS) + "|"); // 36
            writer.Append(CodigoContaContabil + "|"); // 37
            if (Conversions.ToInteger(Versao) >= 13)
                writer.Append(string.Format("{0:0.###}", AbatimentosNT) + "|"); // 38
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroSequencialItem = data[2].ToNullableInteger();
            CodigoProduto = data[3];
            DescricaoComplementarItem = data[4];
            Quantidade = data[5].ToNullableDouble();
            UnidadeMedida = data[6];
            TotalItem = data[7].ToNullableDouble();
            Desconto = data[8].ToNullableDouble();
            if (data[9] == "0")
                IndicadorMovimento = true;
            else
                IndicadorMovimento = false;

            // ## ICMS:
            Origem = (NFe.OrigemMercadoria)data[10][..1].ToEnum<NFe.OrigemMercadoria>(NFe.OrigemMercadoria.Nacional);
            CST_ICMS = (NFe.CST_ICMS)data[10].Substring(1, 2).ToEnum<NFe.CST_ICMS>(NFe.CST_ICMS.CST_00);
            CFOP = data[11];
            NaturezaOperacao = data[12];
            BaseCalculo_ICMS = data[13].ToNullableDouble();
            Aliquota_ICMS = data[14].ToNullableDouble();
            Valor_ICMS = data[15].ToNullableDouble();
            BaseCalculoST_ICMS = data[16].ToNullableDouble();
            AliquotaST_ICMS = data[17].ToNullableDouble();
            ValorST_ICMS = data[18].ToNullableDouble();

            // ## IPI:
            if (data[19] == "1")
                IndicadorApuracaoIPI = IndicadorPeriodoIPI.Decendial;
            else
            {
                if (data[19] == "0")
                    IndicadorApuracaoIPI = IndicadorPeriodoIPI.Mensal;
            }

            CST_IPI = data[20];
            Enquadramento_IPI = data[21];
            BaseCalculo_IPI = data[22].ToNullableDouble();
            Aliquota_IPI = data[23].ToNullableDouble();
            Valor_IPI = data[24].ToNullableDouble();

            // ## PIS:
            CST_PIS = (NFe.CST_PIS)data[25].ToEnum<NFe.CST_PIS>(NFe.CST_PIS.NotValid);
            BaseCalculo_PIS = data[26].ToNullableDouble();
            AliquotaPercentual_PIS = data[27].ToNullableDouble();
            BaseCalculoQuantidade_PIS = data[28].ToNullableDouble();
            AliquotaReais_PIS = data[29].ToNullableDouble();
            Valor_PIS = data[30].ToNullableDouble();

            // ## COFINS:
            CST_COFINS = (NFe.CST_COFINS)data[31].ToEnum<NFe.CST_COFINS>(NFe.CST_COFINS.NotValid);
            BaseCalculo_COFINS = data[32].ToNullableDouble();
            AliquotaPercentual_COFINS = data[33].ToNullableDouble();
            BaseCalculoQuantidade_COFINS = data[34].ToNullableDouble();
            AliquotaReais_COFINS = data[35].ToNullableDouble();
            Valor_COFINS = data[36].ToNullableDouble();

            // ## Contábil:
            CodigoContaContabil = data[37];
            if (Conversions.ToInteger(Versao) >= 13)
                AbatimentosNT = data[38].ToNullableDouble();
            // ## outras merdas de versoes posteriores:

        }

        public int? NumeroSequencialItem { get; set; }
        public string CodigoProduto { get; set; }
        public string DescricaoComplementarItem { get; set; }
        public double? Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
        public double? TotalItem { get; set; }
        public double? Desconto { get; set; }
        public bool? IndicadorMovimento { get; set; }
        public NFe.OrigemMercadoria Origem { get; set; } = NFe.OrigemMercadoria.Nacional;
        public NFe.CST_ICMS CST_ICMS { get; set; } = NFe.CST_ICMS.CST_00;
        public string CFOP { get; set; }
        public string NaturezaOperacao { get; set; }
        public double? BaseCalculo_ICMS { get; set; }
        public double? Aliquota_ICMS { get; set; }
        public double? Valor_ICMS { get; set; }
        public double? BaseCalculoST_ICMS { get; set; }
        public double? AliquotaST_ICMS { get; set; }
        public double? ValorST_ICMS { get; set; }
        public IndicadorPeriodoIPI? IndicadorApuracaoIPI { get; set; } // = IndicadorPeriodoIPI.Mensal
        public string CST_IPI { get; set; }
        public string Enquadramento_IPI { get; set; }
        public double? BaseCalculo_IPI { get; set; }
        public double? Aliquota_IPI { get; set; }
        public double? Valor_IPI { get; set; }
        public NFe.CST_PIS CST_PIS { get; set; } = NFe.CST_PIS.AliquotaNormal;
        public double? BaseCalculo_PIS { get; set; }
        public double? BaseCalculoQuantidade_PIS { get; set; }
        public double? AliquotaPercentual_PIS { get; set; }
        public double? AliquotaReais_PIS { get; set; }
        public double? Valor_PIS { get; set; }
        public NFe.CST_COFINS CST_COFINS { get; set; } = NFe.CST_COFINS.AliquotaNormal;
        public double? BaseCalculo_COFINS { get; set; }
        public double? BaseCalculoQuantidade_COFINS { get; set; }
        public double? AliquotaPercentual_COFINS { get; set; }
        public double? AliquotaReais_COFINS { get; set; }
        public double? Valor_COFINS { get; set; }
        public string CodigoContaContabil { get; set; }
        public double? AbatimentosNT { get; set; }

        // // Filhos:
        public RegistroC172 RegistroC172 { get; set; } = null;
        public List<RegistroC176> RegistrosC176 { get; set; } = new List<RegistroC176>();
    }
}