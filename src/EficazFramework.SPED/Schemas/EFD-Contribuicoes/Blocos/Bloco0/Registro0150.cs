
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Tabela de Cadastro do Participante
    /// </summary>
    /// <remarks></remarks>

    public class Registro0150 : Primitives.Registro
    {
        public Registro0150() : base("0150")
        {
        }

        public Registro0150(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoParticipante { get; set; } = null; // tamanho 60'
        public string NomePessoalEmpresarial { get; set; } = null; // tamanho 100'
        public string CodigoPais { get; set; } = null; // tamanho 5'
        public string CNPJ { get; set; } = null; // tamanho 14'
        public string CPF { get; set; } = null; // tamanho 11'
        public string IEParticipante { get; set; } = null; // tamanho 14'
        public string CodigoMunicipioIBGE { get; set; } = null; // tamanho 7'
        public string SUFRAMA { get; set; } = null; // tamanho 9'
        public string LogradouroEndereco { get; set; } = null; // tamanho 60'
        public string NumeroEndereco { get; set; } = null;
        public string ComplementoEndereco { get; set; } = null; // tamanho 60'
        public string Bairro { get; set; } = null; // tamanho 60'

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0150|");
            writer.Append(CodigoParticipante + "|");
            writer.Append(NomePessoalEmpresarial + "|");
            writer.Append(CodigoPais + "|");
            writer.Append(CNPJ + "|");
            writer.Append(CPF + "|");
            writer.Append(IEParticipante + "|");
            writer.Append(CodigoMunicipioIBGE + "|");
            writer.Append(SUFRAMA + "|");
            writer.Append(LogradouroEndereco + "|");
            writer.Append(NumeroEndereco + "|");
            writer.Append(ComplementoEndereco + "|");
            writer.Append(Bairro + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoParticipante = data[2];
            NomePessoalEmpresarial = data[3];
            CodigoPais = data[4];
            CNPJ = data[5];
            CPF = data[6];
            IEParticipante = data[7];
            CodigoMunicipioIBGE = data[8];
            SUFRAMA = data[9];
            LogradouroEndereco = data[10];
            NumeroEndereco = data[11];
            ComplementoEndereco = data[12];
            Bairro = data[13];
        }
    }
}