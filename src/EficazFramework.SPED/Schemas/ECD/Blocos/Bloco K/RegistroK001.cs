using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Abertura do Bloco K
    /// </summary>
    /// <remarks></remarks>
    public class RegistroK001 : Primitives.Registro
    {
        public RegistroK001() : base("K001")
        {
        }

        public RegistroK001(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|K001|");
            writer.Append(((int)IndicadorMovimento).ToString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
        }
    }
}