using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Encerramento do Bloco G
    /// </summary>
    /// <remarks></remarks>
    public class RegistroG990 : Primitives.Registro
    {
        public RegistroG990() : base("G990")
        {
        }

        public RegistroG990(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|G990|"); // 1
            writer.Append(QuantidadeLinhas + "|"); // 2
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            QuantidadeLinhas = data[2].ToNullableInteger();
        }

        public int? QuantidadeLinhas { get; set; }
    }
}