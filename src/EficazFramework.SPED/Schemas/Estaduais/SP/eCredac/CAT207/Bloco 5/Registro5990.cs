using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Encerramento do Bloco 5
    /// </summary>
    /// <remarks></remarks>
    public class Registro5990 : Primitives.Registro
    {
        public int? QuantidadeLinhas { get; set; }

        public Registro5990() : base("5990")
        {
        }

        public Registro5990(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("5990|"); // 1
            writer.Append(QuantidadeLinhas); // 2
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            QuantidadeLinhas = data[2].ToNullableInteger();
        }
    }
}