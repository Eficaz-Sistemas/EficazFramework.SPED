using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.CNAB240
{

    /// <summary>
    /// Registro Detalhe
    /// </summary>
    public class Registro3W : Registro3
    {
        public Registro3W() : base()
        {
        }

        public Registro3W(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append(CodigoBanco.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 1
            writer.Append(LoteDeServico.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append('3'); // 3
            writer.Append(string.Format("{0:00000}", NumeroSequencial)); // 4
            writer.Append('W'); // 5
            writer.Append(UsoInfoComplementar.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Left, " ")); // 6.1
            writer.Append(Informacao1.ToFixedLenghtString(40, Escrituracao._builder, Alignment.Right, " ")); // 7
            writer.Append(Informacao2.ToFixedLenghtString(40, Escrituracao._builder, Alignment.Right, " ")); // 8
            writer.Append(Informacao3.ToFixedLenghtString(40, Escrituracao._builder, Alignment.Right, " ")); // 9
            writer.Append(Informacao4.ToFixedLenghtString(40, Escrituracao._builder, Alignment.Right, " ")); // 10
            writer.Append("".ToFixedLenghtString(64, Escrituracao._builder, Alignment.Right, " ")); // 6 
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoBanco = linha[..3].Trim();
            LoteDeServico = linha.Substring(3, 4).Trim();
            NumeroSequencial = linha.Substring(8, 5).Trim().ToNullableInteger();
            Informacao1 = linha.Substring(16, 40).Trim();
            Informacao2 = linha.Substring(56, 40).Trim();
            Informacao3 = linha.Substring(96, 40).Trim();
            Informacao4 = linha.Substring(136, 40).Trim();
        }

        public string CodigoBanco { get; set; }
        public string LoteDeServico { get; set; }
        public int? NumeroSequencial { get; set; } = 1;
        public string UsoInfoComplementar { get; set; } = "";
        public string Informacao1 { get; set; }
        public string Informacao2 { get; set; }
        public string Informacao3 { get; set; }
        public string Informacao4 { get; set; }
    }
}