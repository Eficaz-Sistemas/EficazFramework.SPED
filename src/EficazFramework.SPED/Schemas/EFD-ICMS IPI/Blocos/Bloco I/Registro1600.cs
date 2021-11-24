using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO 1600: TOTAL DAS OPERAÇÕES COM CARTÃO DE CRÉDITO E/OU DÉBITO
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

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1600|"); // 1
            writer.Append(CodigoParticipante + "|"); // 2
            writer.Append(string.Format("{0:0.##}", TotalCredito) + "|"); // 3
            writer.Append(string.Format("{0:0.##}", TotalDebito) + "|");  // 4
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoParticipante = data[2];
            TotalCredito = data[3].ToNullableDouble();
            TotalDebito = data[4].ToNullableDouble();
        }

        public string CodigoParticipante { get; set; } = null; // 2
        public double? TotalCredito { get; set; } = default; // 3
        public double? TotalDebito { get; set; } = default; // 4
    }
}