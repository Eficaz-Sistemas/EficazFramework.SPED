using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Valores Declaratórios (por UF)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroE115 : Primitives.Registro
    {
        public RegistroE115() : base("E115")
        {
        }

        public RegistroE115(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|E115|"); // 01
            writer.Append(CodigoInformacao + "|"); // 02
            writer.Append(string.Format("{0:0.##}", Valor) + "|"); // 03
            writer.Append(DescricaoComplementar + "|"); // 04
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoInformacao = data[2];
            Valor = data[3].ToNullableDouble();
            DescricaoComplementar = data[4];
        }

        public string CodigoInformacao { get; set; } = null; // 02
        public double? Valor { get; set; } // 03
        public string DescricaoComplementar { get; set; } = null; // 04
    }
}