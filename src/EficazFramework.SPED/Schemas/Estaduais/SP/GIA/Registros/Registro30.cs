using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.SP.GIA
{

    /// <summary>
    /// DIPAM-B
    /// </summary>
    public class Registro30 : Primitives.Registro
    {
        public Registro30() : base("30")
        {
        }

        public Registro30(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("30"); // 1 Código Registro
            writer.Append(CodigoDipamB.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Right, " ")); // 2
            writer.Append(CodigoMunicipioSP.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 3
            writer.Append(Valor.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 4
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoDipamB = linha.Substring(2, 2).Trim();
            CodigoMunicipioSP = linha.Substring(4, 9).Trim();
            Valor = linha.Substring(9, 15).ToNullableDouble(2);
        }

        public string CodigoDipamB { get; set; } = null;
        public string CodigoMunicipioSP { get; set; } = null;
        public double? Valor { get; set; } = 0;
    }
}