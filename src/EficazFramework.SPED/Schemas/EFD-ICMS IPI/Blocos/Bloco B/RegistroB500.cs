using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Deduções do ISS
    /// </summary>
    /// <remarks></remarks>

    public class RegistroB500 : Primitives.Registro
    {
        public RegistroB500() : base("B500")
        {
        }

        public RegistroB500(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|B500|"); // 1
            writer.Append(string.Format("{0:0.##}", VrMensalReceitasSocUniprofissional) + "|"); // 2
            writer.Append(QuantProfissionaisHabilitados + "|"); // 3
            writer.Append(string.Format("{0:0.##}", VrISSDevido) + "|"); // 4
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            VrMensalReceitasSocUniprofissional = data[2].ToNullableDouble();
            QuantProfissionaisHabilitados = data[3].ToNullableInteger();
            VrISSDevido = data[4].ToNullableDouble();
        }

        public double? VrMensalReceitasSocUniprofissional { get; set; } = default; // 2
        public int? QuantProfissionaisHabilitados { get; set; } = default; // 3
        public double? VrISSDevido { get; set; } = default; // 4
    }
}