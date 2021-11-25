using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Abertura do Bloco 5
    /// </summary>
    /// <remarks></remarks>
    public class Registro5001 : Primitives.Registro
    {
        public IndicadorMovimento IndicadorMovimento { get; set; } = IndicadorMovimento.ComMovimento;

        public Registro5001() : base("5001")
        {
        }

        public Registro5001(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("5001|"); // 1
            writer.Append((int)IndicadorMovimento); // 3
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorMovimento = (IndicadorMovimento)data[2].ToEnum<IndicadorMovimento>(IndicadorMovimento.ComMovimento);
        }
    }
}