using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{
    public class Registro0210 : Primitives.Registro
    {
        public Registro0210() : base("0210")
        {
        }

        public Registro0210(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0210|"); // 1
            writer.Append(CodigoItem + "|"); // 2
            writer.Append(string.Format("{0:0.######}", QuantidadeItem) + "|"); // 3
            writer.Append(string.Format("{0:0.####}", Perda) + "|"); // 4
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoItem = data[2].ToString();
            QuantidadeItem = data[3].ToNullableDouble();
            Perda = data[4].ToNullableDouble();
        }

        public string CodigoItem { get; set; } = null;
        public double? QuantidadeItem { get; set; } = default;
        public double? Perda { get; set; } = default;
    }
}