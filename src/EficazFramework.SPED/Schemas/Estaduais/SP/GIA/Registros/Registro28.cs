using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.SP.GIA
{

    /// <summary>
    /// Crédito Acumulado
    /// </summary>
    public class Registro28 : Primitives.Registro
    {
        public Registro28() : base("28")
        {
        }

        public Registro28(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("28"); // 1 Código Registro
            writer.Append(CodigoAutorizacao.ToFixedLenghtString(12, Escrituracao._builder, Alignment.Right, " ")); // 2
            writer.Append(Valor.ValueToString().ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 3
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoAutorizacao = linha.Substring(2, 12).Trim();
            Valor = linha.Substring(14, 15).ToNullableDouble(2);
        }

        public string CodigoAutorizacao { get; set; } = null;
        public double? Valor { get; set; } = 0;
    }
}