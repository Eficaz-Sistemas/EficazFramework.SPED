using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C171: ARMAZENAMENTO DE COMBUSTÍVEIS (CODIGO 01,55)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC171 : Primitives.Registro
    {
        public RegistroC171() : base("C171")
        {
        }

        public RegistroC171(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C171|"); // 1
            writer.Append(NumTanque + "|"); // 2
            writer.Append(string.Format("{0:0.###}", QuantidadeVolumeArmazenado) + "|"); // 3
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumTanque = data[2].ToString();
            QuantidadeVolumeArmazenado = data[3].ToNullableDouble();
        }

        public string NumTanque { get; set; } = null; // 2
        public double? QuantidadeVolumeArmazenado { get; set; } = default; // 3
    }
}