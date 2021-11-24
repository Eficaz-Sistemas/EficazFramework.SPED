using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Consolidação da contribuição para o pis do período
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM200 : Primitives.Registro
    {
        public RegistroM200() : base("M200")
        {
        }

        public RegistroM200(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public double? VrTotalContNcumulativa { get; set; }
        public double? VrCreditoDescontApPerEscrit { get; set; }
        public double? VrCreditoDescontApPerAnt { get; set; }
        public double? VrTotalContNCumulatDevida { get; set; }
        public double? VrRetFonteDedPeriodo { get; set; }
        public double? OutrasDedPeriodo { get; set; }
        public double? VrContNcumulativaPg { get; set; }
        public double? VrTotalContCumulativa { get; set; }
        public double? VrRetFonteDedPeriodoCum { get; set; }
        public double? OutrasDedPeriodoCum { get; set; }
        public double? VrContCumulativaPg { get; set; }
        public double? VrTotalContRecolherPeriodo { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M200|");
            writer.Append(VrTotalContNcumulativa + "|");
            writer.Append(VrCreditoDescontApPerEscrit + "|");
            writer.Append(VrCreditoDescontApPerAnt + "|");
            writer.Append(VrTotalContNCumulatDevida + "|");
            writer.Append(VrRetFonteDedPeriodo + "|");
            writer.Append(OutrasDedPeriodo + "|");
            writer.Append(VrContNcumulativaPg + "|");
            writer.Append(VrTotalContCumulativa + "|");
            writer.Append(VrRetFonteDedPeriodoCum + "|");
            writer.Append(OutrasDedPeriodoCum + "|");
            writer.Append(VrContCumulativaPg + "|");
            writer.Append(VrTotalContRecolherPeriodo + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            VrTotalContNCumulatDevida = data[2].ToNullableDouble();
            VrCreditoDescontApPerEscrit = data[3].ToNullableDouble();
            VrCreditoDescontApPerAnt = data[4].ToNullableDouble();
            VrTotalContNCumulatDevida = data[5].ToNullableDouble();
            VrRetFonteDedPeriodo = data[6].ToNullableDouble();
            OutrasDedPeriodo = data[7].ToNullableDouble();
            VrContNcumulativaPg = data[8].ToNullableDouble();
            VrTotalContCumulativa = data[9].ToNullableDouble();
            VrRetFonteDedPeriodoCum = data[10].ToNullableDouble();
            OutrasDedPeriodoCum = data[11].ToNullableDouble();
            VrContCumulativaPg = data[12].ToNullableDouble();
            VrTotalContRecolherPeriodo = data[13].ToNullableDouble();
        }
    }
}