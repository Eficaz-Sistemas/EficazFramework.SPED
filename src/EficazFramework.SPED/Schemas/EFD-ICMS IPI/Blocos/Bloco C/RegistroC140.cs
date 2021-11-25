using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C140: FATURA (CÓDIGO 01)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC140 : Primitives.Registro
    {
        public RegistroC140() : base("C140")
        {
        }

        public RegistroC140(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C140|"); // 1
            writer.Append(((int)Indicador_emitente_titulo).ToString() + "|"); // 2
            writer.Append(string.Format("{0:00}", (int)Indicador_Tipo_titulo) + "|"); // 3
            writer.Append(Descricao_Compl_titulo + "|"); // 4
            writer.Append(Num_tituto + "|"); // 5
            writer.Append(Qtd_Parcelas + "|"); // 6
            writer.Append(string.Format("{0:0.##}", Vr_titulototal) + "|"); // 7
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Indicador_emitente_titulo = (IndicadorEmitente)data[2].ToEnum<IndicadorEmitente>(IndicadorEmitente.Propria);
            Indicador_Tipo_titulo = (IndicadorTituloCredito)data[3].ToEnum<IndicadorTituloCredito>(IndicadorTituloCredito.Duplicata);
            Descricao_Compl_titulo = data[4];
            Num_tituto = data[5];
            Qtd_Parcelas = data[6].ToNullableInteger();
            Vr_titulototal = data[7].ToNullableDouble();
        }

        public IndicadorEmitente Indicador_emitente_titulo { get; set; } = IndicadorEmitente.Propria; // 2
        public IndicadorTituloCredito Indicador_Tipo_titulo { get; set; } = IndicadorTituloCredito.Duplicata; // 3
        public string Descricao_Compl_titulo { get; set; } // 4
        public string Num_tituto { get; set; } // 5
        public int? Qtd_Parcelas { get; set; } // 6
        public double? Vr_titulototal { get; set; } // 7

        // // Navigation Properties:
        public List<RegistroC141> RegistrosC141 { get; set; } = new List<RegistroC141>();
    }
}