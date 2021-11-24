
namespace EficazFrameworkCore.SPED.Schemas.LCDPR
{

    /// <summary>
    /// Dados do Contabilista
    /// </summary>
    /// <remarks></remarks>
    public class Registro9999 : Primitives.Registro
    {
        public Registro9999() : base("9999")
        {
        }

        public Registro9999(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("9999|"); // 1
            writer.Append(Nome + "|"); // 2
            writer.Append(CPF + "|"); // 3
            writer.Append(CRC + "|"); // 4
            writer.Append(eMail + "|"); // 5
            writer.Append(Fone + "|"); // 6
            writer.Append(QuantidadeLinhas); // 7
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }

        public string Nome { get; set; } = null;
        public string CPF { get; set; } = null;
        public string CRC { get; set; } = null;
        public string eMail { get; set; } = null;
        public string Fone { get; set; } = null;
        public int QuantidadeLinhas { get; set; } = 0;
    }
}