// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Inventário
    /// </summary>
    /// <remarks></remarks>
    public class RegistroH010 : Primitives.Registro
    {
        public RegistroH010() : base("H010")
        {
        }

        public RegistroH010(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|H010|"); // 1
            writer.Append(CodigoProduto + "|"); // 2
            writer.Append(UnidadeInventariada + "|"); // 3
            writer.Append(string.Format("{0:0.###}", Quantidade) + "|"); // 4
            writer.Append(string.Format("{0:0.######}", ValorUnitario) + "|"); // 5
            writer.Append(string.Format("{0:0.##}", ValorTotal) + "|"); // 6
            writer.Append(((int)IndicadorPosse).ToString() + "|"); // 7
            writer.Append(CodigoParticipante + "|"); // 8
            writer.Append(TextoComplementar + "|"); // 9
            writer.Append(ContaAnaliticaContabil + "|"); // 10
            if (Conversions.ToInteger(Versao) >= 9)
                writer.Append(string.Format("{0:0.##}", ValotTotalRIR) + "|"); // 11
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoProduto = data[2];
            UnidadeInventariada = data[3];
            Quantidade = data[4].ToNullableDouble();
            ValorUnitario = data[5].ToNullableDouble();
            ValorTotal = data[6].ToNullableDouble();
            IndicadorPosse = (IndicadorPropriedade)data[7].ToEnum<IndicadorPropriedade>(IndicadorPropriedade.InformanteEmPoder);
            CodigoParticipante = data[8];
            TextoComplementar = data[9];
            ContaAnaliticaContabil = data[10];
            if (Conversions.ToInteger(Versao) >= 9)
                ValotTotalRIR = data[11].ToNullableDouble(2);
        }

        public string CodigoProduto { get; set; }
        public string UnidadeInventariada { get; set; }
        public double? Quantidade { get; set; }
        public double? ValorUnitario { get; set; }
        public double? ValorTotal { get; set; }
        public IndicadorPropriedade IndicadorPosse { get; set; } = IndicadorPropriedade.InformanteEmPoder;
        public string CodigoParticipante { get; set; }
        public string TextoComplementar { get; set; }
        public string ContaAnaliticaContabil { get; set; }
        public double? ValotTotalRIR { get; set; }

        // // Navigation Properties:

        public RegistroH020 RegistroH020 { get; set; }
    }
}