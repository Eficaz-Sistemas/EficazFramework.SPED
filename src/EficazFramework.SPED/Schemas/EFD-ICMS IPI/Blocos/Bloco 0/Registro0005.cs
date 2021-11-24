
namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Dados Complementares da entidade
    /// </summary>
    /// <remarks></remarks>
    public class Registro0005 : Primitives.Registro
    {
        public Registro0005() : base("0005")
        {
        }

        public Registro0005(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0005|"); // 1
            writer.Append(NomeFantasia + "|"); // 2
            writer.Append(CEP + "|"); // 3
            writer.Append(Endereco + "|"); // 4
            writer.Append(Numero + "|"); // 5
            writer.Append(Complemento + "|"); // 6
            writer.Append(Bairro + "|"); // 7
            writer.Append(Fone + "|"); // 8
            writer.Append(Fax + "|"); // 9
            writer.Append(eMail + "|"); // 10
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NomeFantasia = data[2];
            CEP = data[3];
            Endereco = data[4];
            Numero = data[5];
            Complemento = data[6];
            Bairro = data[7];
            Fone = data[8];
            Fax = data[9];
            eMail = data[10];
        }

        public string NomeFantasia { get; set; } = null;
        public string CEP { get; set; } = null;
        public string Endereco { get; set; } = null;
        public string Numero { get; set; } = null;
        public string Complemento { get; set; } = null;
        public string Bairro { get; set; } = null;
        public string Fone { get; set; } = null;
        public string Fax { get; set; } = null;
        public string eMail { get; set; } = null;
    }
}