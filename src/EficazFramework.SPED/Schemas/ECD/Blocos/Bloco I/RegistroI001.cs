using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Abertura do Bloco I
    /// </summary>
    /// <remarks></remarks>
    public class RegistroI001 : Primitives.Registro
    {
        public RegistroI001() : base("I001")
        {
        }

        public RegistroI001(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I001|");
            writer.Append(((int)IndicadorMovimento).ToString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
        }
    }
}