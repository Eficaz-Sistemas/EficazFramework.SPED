using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Abertura do Bloco 0
    /// </summary>
    /// <remarks></remarks>
    public class Registro0001 : Primitives.Registro
    {
        public IndicadorMovimento IndicadorMovimento { get; set; } = IndicadorMovimento.ComMovimento;

        public Registro0001() : base("0001")
        {
        }

        public Registro0001(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("0001|"); // 1
            writer.Append((int)IndicadorMovimento); // 3
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorMovimento = (IndicadorMovimento)data[2].ToEnum<IndicadorMovimento>(IndicadorMovimento.ComMovimento);
        }
    }
}