using EficazFrameworkCore.SPED.Extensions;
using System;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Informações complementares das operações de devolução de saídas de mercadorias sujeitas à
    /// substituição tributária(código 01, 1B, 04 e 55).
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC181 : Primitives.Registro
    {
        public RegistroC181() : base("C181")
        {
        }

        public RegistroC181(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C181|"); // 1
            writer.Append(CodMotivoRestituicao + "|"); // 2
            writer.Append(string.Format("{0:0.######}", QuantidadeItem) + "|"); // 3
            writer.Append(Unidade + "|"); // 4
            writer.Append(EspecieDocSaida + "|"); // 5
            writer.Append(SerieDocSaida + "|"); // 6
            writer.Append(ECFNumSerieSaida + "|"); // 7
            writer.Append(NumeroDocSaida + "|"); // 8
            writer.Append(ChaveDocSaida + "|"); // 9
            writer.Append(DataDocSaida.ToSpedString() + "|"); //10
            writer.Append(string.Format("{0:##0}", NumeroItemDocSaida) + "|"); // 11
            writer.Append(string.Format("{0:0.######}", VrUnitarioSaida) + "|"); // 12
            writer.Append(string.Format("{0:0.######}", VrUnitarioOpPropriaEstoqueSaida) + "|"); // 13
            writer.Append(string.Format("{0:0.######}", VrUnitarioSTSaida) + "|"); // 14
            writer.Append(string.Format("{0:0.######}", VrUnitarioFCP_STSaida) + "|"); // 15
            writer.Append(string.Format("{0:0.######}", VrUnitarioICMSSaida) + "|"); // 16
            writer.Append(string.Format("{0:0.######}", VrUnitarioOpPropriaSaida) + "|"); // 17
            writer.Append(string.Format("{0:0.######}", VrUnitarioST_TotalRestituir) + "|"); // 18
            writer.Append(string.Format("{0:0.######}", VrUnitarioST_FCPRestituir) + "|"); // 19
            writer.Append(string.Format("{0:0.######}", VrUnitarioST_TotalComplementar) + "|"); // 20
            writer.Append(string.Format("{0:0.######}", VrUnitarioST_FCPComplementar) + "|"); // 21
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }

        public string CodMotivoRestituicao { get; set; } // 2
        public double? QuantidadeItem { get; set; } // 3
        public string Unidade { get; set; } // 4
        public string EspecieDocSaida { get; set; } // 5
        public string SerieDocSaida { get; set; } // 6
        public string ECFNumSerieSaida { get; set; } // 7
        public long? NumeroDocSaida { get; set; } // 8
        public string ChaveDocSaida { get; set; } // 9
        public DateTime? DataDocSaida { get; set; } // 10
        public short? NumeroItemDocSaida { get; set; } // 11
        public double? VrUnitarioSaida { get; set; } // 12
        public double? VrUnitarioOpPropriaEstoqueSaida { get; set; } // 13
        public double? VrUnitarioSTSaida { get; set; } // 14
        public double? VrUnitarioFCP_STSaida { get; set; } // 15
        public double? VrUnitarioICMSSaida { get; set; } // 16
        public double? VrUnitarioOpPropriaSaida { get; set; } // 17
        public double? VrUnitarioST_TotalRestituir { get; set; } // 18
        public double? VrUnitarioST_FCPRestituir { get; set; } // 19
        public double? VrUnitarioST_TotalComplementar { get; set; } // 20
        public double? VrUnitarioST_FCPComplementar { get; set; } // 21

    }
}