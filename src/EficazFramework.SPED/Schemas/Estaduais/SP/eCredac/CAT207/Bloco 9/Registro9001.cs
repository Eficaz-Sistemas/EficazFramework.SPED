
namespace EficazFrameworkCore.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Abertura do Bloco 9
    /// </summary>
    public class Registro9001 : Primitives.Registro
    {
        public Registro9001() : base("9001")
        {
        }

        public Registro9001(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            {
                var withBlock = writer;
                withBlock.Append("9001|"); // texto fixo
                writer.Append((int)IndicadorMovimento); // 3
            }

            string result = writer.ToString();
            writer = null;
            return result;
        }

        public override void LeParametros(string[] data)
        {
        }

        /// <summary>
            /// Indicador de Movimento no Bloco 9
            /// </summary>
        public IndicadorMovimento IndicadorMovimento { get; set; } = IndicadorMovimento.ComMovimento;
    }
}