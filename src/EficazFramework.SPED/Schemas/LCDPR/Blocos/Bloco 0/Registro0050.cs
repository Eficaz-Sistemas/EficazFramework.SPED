
namespace EficazFrameworkCore.SPED.Schemas.LCDPR
{

    /// <summary>
    /// Cadastro das Contas Bancárias do Produtor Rural
    /// </summary>
    /// <remarks></remarks>
    public class Registro0050 : Primitives.Registro
    {
        public Registro0050() : base("0050")
        {
        }

        public Registro0050(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("0050|"); // 1
            writer.Append(CodigoContaBanco + "|"); // 2
            writer.Append(Pais + "|"); // 3
            writer.Append(NumeroInstBancaria + "|"); // 4
            writer.Append(Nome + "|"); // 5
            writer.Append(Agencia + "|"); // 6
            writer.Append(NumeroCC); // 7
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }

        public int? CodigoContaBanco { get; set; } = default;
        public string Pais { get; set; } = "BR";
        public string NumeroInstBancaria { get; set; } = null;
        public string Nome { get; set; } = null;
        public string Agencia { get; set; } = null;
        public string NumeroCC { get; set; } = null;
    }
}