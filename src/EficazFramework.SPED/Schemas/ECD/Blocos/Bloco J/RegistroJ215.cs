using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Fato Contábil que Altera a Conta Lucros Acumulados ou a Conta Prejuízos Acumulados ou Todo o Patrimônio Líquido
    /// </summary>
    /// <remarks></remarks>

    public class RegistroJ215 : Primitives.Registro
    {
        public RegistroJ215() : base("J215")
        {
        }

        // Campos'
        public string CodigoHistFatoContabil { get; set; } = null;
        public string DescricaoFatoContabil { get; set; } = null;
        public double? VrFatoContabil { get; set; }
        public string IndicadorSitSaldoFatoContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|J215|");
            writer.Append(CodigoHistFatoContabil + "|");
            if (Conversions.ToInteger(Versao) / 100d >= 7d)
                writer.Append(DescricaoFatoContabil + "|");
            writer.Append(VrFatoContabil + "|");
            writer.Append(IndicadorSitSaldoFatoContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            if (Conversions.ToInteger(Versao) / 100d >= 7d)
            {
                CodigoHistFatoContabil = data[2];
                DescricaoFatoContabil = data[3];
                VrFatoContabil = data[4].ToNullableDouble();
                IndicadorSitSaldoFatoContabil = data[5];
            }
            else
            {
                CodigoHistFatoContabil = data[2];
                VrFatoContabil = data[3].ToNullableDouble();
                IndicadorSitSaldoFatoContabil = data[4];
            }
        }
    }
}