using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da Contribuição Social Extemporânea
    /// </summary>
    /// <remarks></remarks>

    public class Registro1210 : Primitives.Registro
    {
        public Registro1210() : base("1210")
        {
        }

        public Registro1210(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string NumeroCNPJCampoRegistro0140 { get; set; } = null;
        public string CSTPis { get; set; } = null;
        public string CodParticipante { get; set; } = null;
        public DateTime? DataOperacao { get; set; }
        public double? ValorOperacao { get; set; }
        public double? ValorBCPis { get; set; }
        public double? AliqPis { get; set; }
        public double? VrPis { get; set; }
        public string CodigoContaContabil { get; set; } = null;
        public string DescComplementarDoc { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1210|");
            writer.Append(NumeroCNPJCampoRegistro0140 + "|");
            writer.Append(CSTPis + "|");
            writer.Append(CodParticipante + "|");
            writer.Append(DataOperacao + "|");
            writer.Append(ValorOperacao + "|");
            writer.Append(ValorBCPis + "|");
            writer.Append(AliqPis + "|");
            writer.Append(VrPis + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(DescComplementarDoc + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroCNPJCampoRegistro0140 = data[2];
            CSTPis = data[3];
            CodParticipante = data[4];
            DataOperacao = data[5].ToDate();
            ValorOperacao = data[6].ToNullableDouble();
            ValorBCPis = data[7].ToNullableDouble();
            AliqPis = data[8].ToNullableDouble();
            VrPis = data[9].ToNullableDouble();
            CodigoContaContabil = data[10];
            DescComplementarDoc = data[11];
        }
    }
}