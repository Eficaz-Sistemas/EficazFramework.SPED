using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Abertura do Bloco L
    /// </summary>
    /// <remarks></remarks>
    public class RegistroL001 : Primitives.Registro
    {
        public RegistroL001() : base("L001")
        {
        }

        public RegistroL001(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|L001|");
            writer.Append(((int)IndicadorMovimento).ToString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
        }
    }
}