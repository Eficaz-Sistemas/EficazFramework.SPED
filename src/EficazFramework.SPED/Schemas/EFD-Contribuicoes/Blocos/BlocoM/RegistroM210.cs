using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da contribuição para o pis pasep período
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM210 : Primitives.Registro
    {
        public RegistroM210() : base("M210")
        {
        }

        public RegistroM210(string linha, string versao) : base(linha, versao)
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
        public double? AliqPis { get; set; }
        public double? QtdeBcPis { get; set; }
        public double? AliqPisQtde { get; set; }
        public double? VrContSocialApurada { get; set; }
        public double? VrTotalAjAcresc { get; set; }
        public double? VrTotalAjRed { get; set; }
        public double? VrContDiferirPeriodo { get; set; }
        public double? VrContDiferidaPerAnter { get; set; }
        public double? VrTotalContPeriodo { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M210|");
            if (Conversions.ToInteger(Versao) < 5)
            {
                writer.Append(CodigoContSocialApPeriodo + "|");
                writer.Append(VrRecBruta + "|");
                writer.Append(VrBcContribuicao + "|");
                writer.Append(AliqPis + "|");
                writer.Append(QtdeBcPis + "|");
                writer.Append(AliqPisQtde + "|");
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
                writer.Append(AliqPis + "|");
                writer.Append(QtdeBcPis + "|");
                writer.Append(AliqPisQtde + "|");
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
            AliqPis = data[5].ToNullableDouble();
            QtdeBcPis = data[6].ToNullableDouble();
            AliqPisQtde = data[7].ToNullableDouble();
            VrContSocialApurada = data[8].ToNullableDouble();
            VrTotalAjAcresc = data[9].ToNullableDouble();
            VrTotalAjRed = data[10].ToNullableDouble();
            VrContDiferirPeriodo = data[11].ToNullableDouble();
            VrContDiferidaPerAnter = data[12].ToNullableDouble();
            VrTotalContPeriodo = data[13].ToNullableDouble();
        }
    }
}