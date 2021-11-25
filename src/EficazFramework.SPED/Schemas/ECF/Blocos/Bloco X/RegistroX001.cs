using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Abertura do Bloco Xs
    /// </summary>
    /// <remarks></remarks>
    public class RegistroX001 : Primitives.Registro
    {
        public RegistroX001() : base("X001")
        {
        }

        public RegistroX001(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|X001|");
            writer.Append(((int)IndicadorMovimento).ToString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
        }
    }
}