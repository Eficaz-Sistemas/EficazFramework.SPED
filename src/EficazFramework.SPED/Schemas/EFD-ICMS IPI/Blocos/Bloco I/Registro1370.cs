
namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Bico da Bomca
    /// </summary>
    /// <remarks></remarks>
    public class Registro1370 : Primitives.Registro
    {
        public Registro1370() : base("1370")
        {
        }

        public Registro1370(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1370|"); // 1
            writer.Append(NumeroBico + "|"); // 2
            writer.Append(CodigoCombustivel0200 + "|");   // 3
            writer.Append(NumeroTanque + "|"); // 4
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroBico = data[2];
            CodigoCombustivel0200 = data[3];
            NumeroTanque = data[4];
        }

        public string NumeroBico { get; set; } = null; // 2
        public string CodigoCombustivel0200 { get; set; } = null; // 3
        public string NumeroTanque { get; set; } = null; // 4
    }
}