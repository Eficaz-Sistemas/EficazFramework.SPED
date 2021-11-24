using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Operações com ISSQN
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC172 : Primitives.Registro
    {
        public RegistroC172() : base("C172")
        {
        }

        public RegistroC172(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C172|"); // 1
            writer.Append(string.Format("{0:0.##}", ValorBaseCalculo) + "|"); // 2
            writer.Append(string.Format("{0:0.##}", Aliquota) + "|"); // 3
            writer.Append(string.Format("{0:0.##}", Valor) + "|"); // 4
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            ValorBaseCalculo = data[2].ToNullableDouble();
            Aliquota = data[3].ToNullableDouble();
            Valor = data[4].ToNullableDouble();
        }

        public double? ValorBaseCalculo { get; set; } = default; // 2
        public double? Aliquota { get; set; } = default; // 3
        public double? Valor { get; set; } = default; // 4
    }
}