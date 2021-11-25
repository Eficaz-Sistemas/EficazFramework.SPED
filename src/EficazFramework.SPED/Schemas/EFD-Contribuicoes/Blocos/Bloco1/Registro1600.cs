using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Contribuição social extemporânea - Cofins
    /// </summary>
    /// <remarks></remarks>

    public class Registro1600 : Primitives.Registro
    {
        public Registro1600() : base("1600")
        {
        }

        public Registro1600(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public DateTime? PeriodoApContExtemporanea { get; set; }
        public string NaturezaContRecolher { get; set; } = null;
        public double? VrContribuicaoApurada { get; set; }
        public double? VrCreditoCofinsDescontarContSocialExtemporanea { get; set; }
        public double? VrContSocialDevida { get; set; }
        public double? VrOutrasDeducoes { get; set; }
        public double? VrContSocialExtemporaneaPg { get; set; }
        public double? VrMulta { get; set; }
        public double? VrJuros { get; set; }
        public DateTime? DataRecolhimento { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1600|");
            writer.Append(PeriodoApContExtemporanea + "|");
            writer.Append(NaturezaContRecolher + "|");
            writer.Append(VrContribuicaoApurada + "|");
            writer.Append(VrCreditoCofinsDescontarContSocialExtemporanea + "|");
            writer.Append(VrContSocialDevida + "|");
            writer.Append(VrOutrasDeducoes + "|");
            writer.Append(VrContSocialExtemporaneaPg + "|");
            writer.Append(VrMulta + "|");
            writer.Append(VrJuros + "|");
            writer.Append(DataRecolhimento + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            PeriodoApContExtemporanea = data[2].ToDate();
            NaturezaContRecolher = data[3];
            VrContribuicaoApurada = data[4].ToNullableDouble();
            VrCreditoCofinsDescontarContSocialExtemporanea = data[5].ToNullableDouble();
            VrContSocialDevida = data[6].ToNullableDouble();
            VrOutrasDeducoes = data[7].ToNullableDouble();
            VrContSocialExtemporaneaPg = data[8].ToNullableDouble();
            VrMulta = data[9].ToNullableDouble();
            VrJuros = data[10].ToNullableDouble();
            DataRecolhimento = data[11].ToDate();
        }
    }
}