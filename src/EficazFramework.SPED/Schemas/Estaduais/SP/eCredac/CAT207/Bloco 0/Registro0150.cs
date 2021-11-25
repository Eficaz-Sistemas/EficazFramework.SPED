
namespace EficazFramework.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Tabela de Cadastro do Participante
    /// </summary>
    /// <remarks></remarks>
    public class Registro0150 : Primitives.Registro
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public int CodigoPais { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Telefone { get; set; }

        public Registro0150() : base("0150")
        {
        }

        public Registro0150(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("0150|"); // texto fixo
            writer.Append(ID + "|");
            writer.Append(Nome + "|");
            writer.Append(string.Format("{0:00000}", CodigoPais) + "|"); // 05 dígitos
            writer.Append(TrataCNPJ_CPF() + "|");
            writer.Append(InscricaoEstadual + "|");
            writer.Append(UF + "|");
            writer.Append(CEP + "|");
            writer.Append(Endereco + "|");
            writer.Append(Numero + "|");
            writer.Append(Complemento + "|");
            writer.Append(Bairro + "|");
            writer.Append(string.Format("{0:0000000}", CodigoMunicipio) + "|"); // 07 dígitos
            writer.Append(Telefone);
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }

        private string TrataCNPJ_CPF()
        {
            if (CNPJ == null)
                return string.Empty;
            int len = CNPJ.Length;
            string prefix = string.Empty;
            for (int i = len + 1; i <= 14; i++)
                prefix = prefix + "0";
            return prefix + CNPJ;
        }
    }
}