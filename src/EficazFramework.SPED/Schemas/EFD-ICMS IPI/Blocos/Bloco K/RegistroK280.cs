// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Estoque Escriturado
    /// </summary>
    /// <remarks></remarks>
    public class RegistroK280 : Primitives.Registro
    {
        public RegistroK280() : base("K280")
        {
        }

        public RegistroK280(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|K280|"); // 1
            writer.Append(DataEscrituracao.ToSpedString() + "|"); // 2
            writer.Append(CodigoProduto + "|"); // 3
            writer.Append(string.Format("{0:0.###}", QuantidadePositiva) + "|"); // 4
            writer.Append(string.Format("{0:0.###}", QuantidadeNegativa) + "|"); // 5
            writer.Append(((int)IndicadorPosse).ToString() + "|"); // 6
            writer.Append(CodigoParticipante + "|"); // 7
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataEscrituracao = data[2].ToDate();
            CodigoProduto = data[3];
            QuantidadePositiva = data[4].ToNullableDouble();
            QuantidadeNegativa = data[5].ToNullableDouble();
            IndicadorPosse = (IndicadorPropriedade)data[6].ToEnum<IndicadorPropriedade>(IndicadorPropriedade.InformanteEmPoder);
            CodigoParticipante = data[7];
        }

        public DateTime? DataEscrituracao { get; set; }
        public string CodigoProduto { get; set; }
        public string UnidadeInventariada { get; set; }
        public double? QuantidadePositiva { get; set; }
        public double? QuantidadeNegativa { get; set; }
        public IndicadorPropriedade IndicadorPosse { get; set; } = IndicadorPropriedade.InformanteEmPoder;
        public string CodigoParticipante { get; set; }
    }
}