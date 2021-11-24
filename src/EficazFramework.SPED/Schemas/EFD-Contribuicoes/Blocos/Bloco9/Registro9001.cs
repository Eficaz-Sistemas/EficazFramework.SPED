using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
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
                withBlock.Append("|9001|"); // texto fixo
                writer.Append(((int)IndicadorMovimento).ToString() + "|"); // 3
            }

            string result = writer.ToString();
            writer = null;
            return result;
        }

        public override void LeParametros(string[] data)
        {
            IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
        }

        /// <summary>
        /// Indicador de Movimento no Bloco 9
        /// </summary>
        public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;
    }
}