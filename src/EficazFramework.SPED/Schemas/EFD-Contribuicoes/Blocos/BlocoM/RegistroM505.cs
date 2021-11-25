using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da base de calculo do crédito apurado no período Cofins
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM505 : Primitives.Registro
    {
        public RegistroM505() : base("M505")
        {
        }

        public RegistroM505(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string NatBcCredito { get; set; } = null;
        public string CSTCofins { get; set; } = null;
        public double? VrTotalBc { get; set; }
        public double? VrTotalBcCumulativa { get; set; }
        public double? VrTotalBCNcumulativa { get; set; }
        public double? VrBcCofins { get; set; }
        public double? QtdeBcCofinsTotal { get; set; }
        public double? QtdeBcCofins { get; set; }
        public string DescCredito { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M505|");
            writer.Append(string.Format("{0:00}", Conversions.ToInteger(NatBcCredito)) + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalBc) + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalBcCumulativa) + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalBCNcumulativa) + "|");
            writer.Append(string.Format("{0:0.##}", VrBcCofins) + "|");
            writer.Append(string.Format("{0:0.###}", QtdeBcCofinsTotal) + "|");
            writer.Append(string.Format("{0:0.###}", QtdeBcCofins) + "|");
            writer.Append(DescCredito + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NatBcCredito = data[2];
            CSTCofins = data[3];
            VrTotalBc = data[4].ToNullableDouble();
            VrTotalBcCumulativa = data[5].ToNullableDouble();
            VrTotalBCNcumulativa = data[6].ToNullableDouble();
            VrBcCofins = data[7].ToNullableDouble();
            QtdeBcCofinsTotal = data[8].ToNullableDouble();
            QtdeBcCofins = data[9].ToNullableDouble();
            DescCredito = data[10];
        }
    }
}