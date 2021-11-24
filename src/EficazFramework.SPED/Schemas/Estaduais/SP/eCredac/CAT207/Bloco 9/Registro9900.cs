
namespace EficazFrameworkCore.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Encerramento do Bloco 9
    /// </summary>
    public class Registro9900 : Primitives.Registro
    {
        public Registro9900() : base("9900")
        {
        }

        public Registro9900(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            {
                var withBlock = writer;
                withBlock.Append("9900|"); // texto fixo
                withBlock.Append(Registro + "|");
                withBlock.Append(TotalLinhas);
            }

            string result = writer.ToString();
            writer = null;
            return result;
        }

        public override void LeParametros(string[] data)
        {
        }

        /// <summary>
        /// Registro Totalizado
        /// </summary>
        /// <returns></returns>
        public string Registro { get; set; }
        /// <summary>
        /// Total de Linhas do Bloco
        /// </summary>
        public int? TotalLinhas { get; set; }
    }
}