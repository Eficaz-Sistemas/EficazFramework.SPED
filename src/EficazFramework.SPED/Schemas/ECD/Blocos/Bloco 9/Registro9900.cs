
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Registros do Arquivo
    /// </summary>
    /// <remarks></remarks>

    public class Registro9900 : Primitives.Registro
    {
        public Registro9900() : base("9900")
        {
        }

        public Registro9900(string linha, string versao) : base(linha, versao)
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

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|9900|");
            writer.Append(Registro + "|");
            writer.Append(TotalLinhas + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Registro = data[2];
            TotalLinhas = data[3].ToNullableInteger();
        }
    }
}