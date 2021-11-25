
namespace EficazFramework.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Operações Geradoras de Crédito Acumulado nas Fichas 6A ou 6B
    /// </summary>
    /// <remarks></remarks>
    public class Registro5350 : Primitives.Registro
    {
        public double? BaseCalculo { get; set; } = default;
        public double? ICMSDebitado { get; set; } = default;
        public string DeclaracaoExportacao { get; set; } = null;

        public Registro5350() : base("5350")
        {
        }

        public Registro5350(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("5350|");
            writer.Append(string.Format("{0:F2}", BaseCalculo) + "|");
            writer.Append(string.Format("{0:F2}", ICMSDebitado) + "|");
            writer.Append(DeclaracaoExportacao);
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}