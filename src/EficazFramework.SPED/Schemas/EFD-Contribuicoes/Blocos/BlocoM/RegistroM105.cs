using EficazFrameworkCore.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da base de calculo do crédito apurado no período Pis
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM105 : Primitives.Registro
    {
        public RegistroM105() : base("M105")
        {
        }

        public RegistroM105(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string NatBcCredito { get; set; } = null;
        public string CSTPis { get; set; } = null;
        public double? VrTotalBc { get; set; }
        public double? VrTotalBcCumulativa { get; set; }
        public double? VrTotalBCNcumulativa { get; set; }
        public double? VrBcPis { get; set; }
        public double? QtdeBcPisTotal { get; set; }
        public double? QtdeBcPis { get; set; }
        public string DescCredito { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M105|");
            writer.Append(string.Format("{0:00}", Conversions.ToInteger(NatBcCredito)) + "|");
            writer.Append(CSTPis + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalBc) + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalBcCumulativa) + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalBCNcumulativa) + "|");
            writer.Append(string.Format("{0:0.##}", VrBcPis) + "|");
            writer.Append(string.Format("{0:0.###}", QtdeBcPisTotal) + "|");
            writer.Append(string.Format("{0:0.###}", QtdeBcPis) + "|");
            writer.Append(DescCredito + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NatBcCredito = data[2];
            CSTPis = data[3];
            VrTotalBc = data[4].ToNullableDouble();
            VrTotalBcCumulativa = data[5].ToNullableDouble();
            VrTotalBCNcumulativa = data[6].ToNullableDouble();
            VrBcPis = data[7].ToNullableDouble();
            QtdeBcPisTotal = data[8].ToNullableDouble();
            QtdeBcPis = data[9].ToNullableDouble();
            DescCredito = data[10];
        }
    }
}