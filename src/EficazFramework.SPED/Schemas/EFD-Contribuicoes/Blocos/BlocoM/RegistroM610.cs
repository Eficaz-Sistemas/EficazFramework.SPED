using EficazFrameworkCore.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da contribuição para o Cofins pasep período
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM610 : Primitives.Registro
    {
        public RegistroM610() : base("M610")
        {
        }

        public RegistroM610(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoContSocialApPeriodo { get; set; } = null;
        public double? VrRecBruta { get; set; }
        public double? VrBcContribuicao { get; set; }
        // 
        public double? VrAjBCAcresc { get; set; }
        public double? VrAjBCRed { get; set; }
        // 
        public double? AliqCofins { get; set; }
        public double? QtdeBcCofins { get; set; }
        public double? AliqCofinsQtde { get; set; }
        public double? VrContSocialApurada { get; set; }
        public double? VrTotalAjAcresc { get; set; }
        public double? VrTotalAjRed { get; set; }
        public double? VrContDiferirPeriodo { get; set; }
        public double? VrContDiferidaPerAnter { get; set; }
        public double? VrTotalContPeriodo { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M610|");
            if (Conversions.ToInteger(Versao) < 5)
            {
                writer.Append(CodigoContSocialApPeriodo + "|");
                writer.Append(VrRecBruta + "|");
                writer.Append(VrBcContribuicao + "|");
                writer.Append(AliqCofins + "|");
                writer.Append(QtdeBcCofins + "|");
                writer.Append(AliqCofinsQtde + "|");
                writer.Append(VrContSocialApurada + "|");
                writer.Append(VrTotalAjAcresc + "|");
                writer.Append(VrTotalAjRed + "|");
                writer.Append(VrContDiferirPeriodo + "|");
                writer.Append(VrContDiferidaPerAnter + "|");
                writer.Append(VrTotalContPeriodo + "|");
            }
            else
            {
                writer.Append(CodigoContSocialApPeriodo + "|");
                writer.Append(VrRecBruta + "|");
                writer.Append(VrBcContribuicao + "|");
                writer.Append(VrAjBCAcresc + "|");
                writer.Append(VrAjBCRed + "|");
                writer.Append((VrBcContribuicao ?? 0d) + (VrAjBCAcresc ?? 0d) - (VrAjBCRed ?? 0d) + "|");
                writer.Append(AliqCofins + "|");
                writer.Append(QtdeBcCofins + "|");
                writer.Append(AliqCofinsQtde + "|");
                writer.Append(VrContSocialApurada + "|");
                writer.Append(VrTotalAjAcresc + "|");
                writer.Append(VrTotalAjRed + "|");
                writer.Append(VrContDiferirPeriodo + "|");
                writer.Append(VrContDiferidaPerAnter + "|");
                writer.Append(VrTotalContPeriodo + "|");
            }

            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoContSocialApPeriodo = data[2];
            VrRecBruta = data[3].ToNullableDouble();
            VrBcContribuicao = data[4].ToNullableDouble();
            AliqCofins = data[5].ToNullableDouble();
            QtdeBcCofins = data[6].ToNullableDouble();
            AliqCofinsQtde = data[7].ToNullableDouble();
            VrContSocialApurada = data[8].ToNullableDouble();
            VrTotalAjAcresc = data[9].ToNullableDouble();
            VrTotalAjRed = data[10].ToNullableDouble();
            VrContDiferirPeriodo = data[11].ToNullableDouble();
            VrContDiferidaPerAnter = data[12].ToNullableDouble();
            VrTotalContPeriodo = data[13].ToNullableDouble();
        }
    }
}