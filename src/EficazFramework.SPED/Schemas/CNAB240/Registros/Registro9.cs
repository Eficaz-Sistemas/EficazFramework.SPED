using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.CNAB240
{

    /// <summary>
    /// Registro Trailer de Arquivo
    /// </summary>
    public class Registro9 : Primitives.Registro
    {
        public Registro9() : base("9")
        {
        }

        public Registro9(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append(CodigoBanco.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 1
            writer.Append(LoteDeServico.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append('9'); // 3
            writer.Append("         "); // 4
            writer.Append(QuantidadeLotes.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 5
            writer.Append(QuantidadeRegistros.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 6
            if (CodigoBanco != "237")
            {
                writer.Append("                                                                                                    "); // 7
            }
            else
            {
                writer.Append("000000"); // BRADESCO - Contas para conciliação (Lotes)
                writer.Append("                                                                                              ");
            } // 7

            writer.Append("                                                                                                    "); // 7
            writer.Append("           "); // 7
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoBanco = linha[..3].Trim();
            LoteDeServico = linha.Substring(3, 4).Trim();
            QuantidadeLotes = linha.Substring(17, 6).ToNullableInteger();
            QuantidadeRegistros = linha.Substring(23, 6).ToNullableInteger();
        }

        public string CodigoBanco { get; set; }
        public string LoteDeServico { get; set; } = "9999";
        public int? QuantidadeLotes { get; set; } = 0;
        public int? QuantidadeRegistros { get; set; } = 0;
    }
}