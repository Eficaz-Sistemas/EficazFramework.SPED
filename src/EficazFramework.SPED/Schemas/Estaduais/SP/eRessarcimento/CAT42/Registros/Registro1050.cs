// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.


namespace EficazFramework.SPED.Schemas.SP.eRessarcimento.CAT42
{

    /// <summary>
    /// REGISTRO DE SALDOS
    /// </summary>
    /// <remarks></remarks>
    public class Registro1050 : Primitives.Registro
    {
        public string CodigoProduto { get; set; }
        public double? QuantidadeInicial { get; set; }
        public double? ICMS_TotalInicial { get; set; }
        public double? QuantidadeFinal { get; set; }
        public double? ICMS_TotalFinal { get; set; }

        public Registro1050() : base("1050")
        {
        }

        public Registro1050(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("1050|"); // 1
            writer.Append(CodigoProduto + "|"); // 2
            writer.Append(string.Format("{0:0.000}", QuantidadeInicial) + "|"); // 3
            writer.Append(string.Format("{0:0.00}", ICMS_TotalInicial) + "|"); // 4
            writer.Append(string.Format("{0:0.000}", QuantidadeFinal) + "|"); // 5
            writer.Append(string.Format("{0:0.00}", ICMS_TotalFinal)); // 6
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}