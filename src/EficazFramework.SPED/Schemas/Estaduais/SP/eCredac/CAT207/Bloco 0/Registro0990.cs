using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Encerramento do Bloco 0
    /// </summary>
    /// <remarks></remarks>
    public class Registro0990 : Primitives.Registro
    {
        public int? QuantidadeLinhas { get; set; }

        public Registro0990() : base("0990")
        {
        }

        public Registro0990(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("0990|"); // 1
            writer.Append(QuantidadeLinhas); // 2
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            QuantidadeLinhas = data[2].ToNullableInteger();
        }
    }
}