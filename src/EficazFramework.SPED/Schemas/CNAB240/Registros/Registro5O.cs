using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.CNAB240
{

    /// <summary>
    /// Registro Trailer de Lote de Serviço: Pagamentos de Contas de Concessionárias e Tributos com Código de Barras
    /// </summary>
    public class Registro5O : Primitives.Registro
    {
        public Registro5O() : base("5")
        {
        }

        public Registro5O(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append(CodigoBanco.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 1
            writer.Append(LoteDeServico.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append('5'); // 3
            writer.Append("         "); // 4
            writer.Append(QuantidadeRegistros.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 5
            writer.Append(ValorPagamentos.ValueToString(2).ToFixedLenghtString(18, Escrituracao._builder, Alignment.Left, "0")); // 6
            writer.Append(ValorQuantidadeMoeda.ValueToString(8).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 7
            writer.Append("".ToFixedLenghtString(174, Escrituracao._builder, Alignment.Right, " ")); // 8
            writer.Append(Ocorrencias.ToFixedLenghtString(10, Escrituracao._builder, Alignment.Right, " ")); // 9
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoBanco = linha[..3].Trim();
            LoteDeServico = linha.Substring(3, 4).Trim();
            QuantidadeRegistros = linha.Substring(17, 6).Trim().ToNullableInteger();
            ValorPagamentos = linha.Substring(23, 16).Trim().ToNullableDouble(2);
            ValorQuantidadeMoeda = linha.Substring(41, 7).Trim().ToNullableDouble(8);
            Ocorrencias = linha.Substring(230, 105).Trim();
        }

        public string CodigoBanco { get; set; }
        public string LoteDeServico { get; set; }
        public int? QuantidadeRegistros { get; set; }
        public double? ValorPagamentos { get; set; }
        public double? ValorQuantidadeMoeda { get; set; }
        public string Ocorrencias { get; set; }
    }
}