using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.CNAB240
{

    /// <summary>
    /// Registro Detalhe
    /// </summary>
    public class Registro3Z : Registro3
    {
        public Registro3Z() : base()
        {
        }

        public Registro3Z(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append(CodigoBanco.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 1
            writer.Append(LoteDeServico.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append('3'); // 3
            writer.Append(string.Format("{0:00000}", NumeroSequencial)); // 4
            writer.Append('Z'); // 5
            writer.Append(Autenticacao.ToFixedLenghtString(64, Escrituracao._builder, Alignment.Right, " ")); // 6
            writer.Append(SeuNumero.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 7
            writer.Append("     ");
            writer.Append(NossoNumero.ToFixedLenghtString(15, Escrituracao._builder, Alignment.Right, " ")); // 9
            writer.Append("".ToFixedLenghtString(122, Escrituracao._builder, Alignment.Right, " ")); // 6 
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoBanco = linha[..3].Trim();
            LoteDeServico = linha.Substring(3, 4).Trim();
            NumeroSequencial = linha.Substring(8, 5).Trim().ToNullableInteger();
            Autenticacao = linha.Substring(14, 64).Trim();
            SeuNumero = linha.Substring(78, 20).Trim();
            NossoNumero = linha.Substring(103, 15).Trim();
        }

        public string CodigoBanco { get; set; }
        public string LoteDeServico { get; set; }
        public int? NumeroSequencial { get; set; } = 1;
        public string Autenticacao { get; set; }
        public string SeuNumero { get; set; }
        public string NossoNumero { get; set; }
    }
}