using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Encerramento do Arquivo Eletrônico
    /// </summary>
    public class Registro9999 : Primitives.Registro
    {
        public Registro9999(string linha, string versao) : base(linha, versao)
        {
        }

        public Registro9999() : base("9999")
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            {
                var withBlock = writer;
                withBlock.Append("|9999|"); // texto fixo
                withBlock.Append(TotalLinhas + "|");
            }

            string result = writer.ToString();
            return result;
        }

        public override void LeParametros(string[] data)
        {
            TotalLinhas = data[1].ToNullableInteger();
        }

        /// <summary>
        /// Total de Linhas do Arquivo
        /// </summary>
        public int? TotalLinhas { get; set; }
    }
}