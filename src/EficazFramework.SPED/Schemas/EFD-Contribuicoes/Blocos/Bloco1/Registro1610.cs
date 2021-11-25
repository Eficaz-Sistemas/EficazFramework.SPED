using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da Contribuição Social Extemporânea
    /// </summary>
    /// <remarks></remarks>

    public class Registro1610 : Primitives.Registro
    {
        public Registro1610() : base("1610")
        {
        }

        public Registro1610(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string NumeroCNPJCampoRegistro0140 { get; set; } = null;
        public string CSTCofins { get; set; } = null;
        public string CodParticipante { get; set; } = null;
        public DateTime? DataOperacao { get; set; }
        public double? ValorOperacao { get; set; }
        public double? ValorBCCofins { get; set; }
        public double? AliqCofins { get; set; }
        public double? VrCofins { get; set; }
        public string CodigoContaContabil { get; set; } = null;
        public string DescComplementarDoc { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1610|");
            writer.Append(NumeroCNPJCampoRegistro0140 + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(CodParticipante + "|");
            writer.Append(DataOperacao + "|");
            writer.Append(ValorOperacao + "|");
            writer.Append(ValorBCCofins + "|");
            writer.Append(AliqCofins + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(DescComplementarDoc + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroCNPJCampoRegistro0140 = data[2];
            CSTCofins = data[3];
            CodParticipante = data[4];
            DataOperacao = data[5].ToDate();
            ValorOperacao = data[6].ToNullableDouble();
            ValorBCCofins = data[7].ToNullableDouble();
            AliqCofins = data[8].ToNullableDouble();
            VrCofins = data[9].ToNullableDouble();
            CodigoContaContabil = data[10];
            DescComplementarDoc = data[11];
        }
    }
}