using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Encerramento do Bloco C
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC990 : Primitives.Registro
    {
        public RegistroC990() : base("C990")
        {
        }

        public RegistroC990(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C990|"); // 1
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