using System.Collections.Generic;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
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

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0150|"); // 1
            writer.Append(ID + "|"); // 2
            writer.Append(Nome + "|"); // 3
            writer.Append(CodigoPais + "|"); // 4
            writer.Append(CNPJ + "|"); // 5
            writer.Append(CPF + "|"); // 6
            writer.Append(InscricaoEstadual + "|"); // 7
            writer.Append(CodigoMunicipio + "|"); // 8
            writer.Append(Suframa + "|"); // 9
            writer.Append(Endereco + "|"); // 10
            writer.Append(Numero + "|"); // 11
            writer.Append(Complemento + "|"); // 12
            writer.Append(Bairro + "|"); // 13
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            ID = data[2];
            Nome = data[3];
            CodigoPais = data[4];
            CNPJ = data[5];
            CPF = data[6];
            InscricaoEstadual = data[7];
            CodigoMunicipio = data[8];
            if (string.IsNullOrEmpty(CodigoMunicipio) | string.IsNullOrWhiteSpace(CodigoMunicipio))
            {
                CodigoMunicipio = "9999999";
            }

            Suframa = data[9];
            Endereco = data[10];
            Numero = data[11];
            Complemento = data[12];
            Bairro = data[13];
        }

        public string ID { get; set; } = null;
        public string Nome { get; set; } = null;
        public string CodigoPais { get; set; } = null;
        public string CNPJ { get; set; } = null;
        public string CPF { get; set; } = null;
        public string InscricaoEstadual { get; set; } = null;
        public string CodigoMunicipio { get; set; } = null;
        public string Suframa { get; set; } = null;
        public string Endereco { get; set; } = null;
        public string Numero { get; set; } = null;
        public string Complemento { get; set; } = null;
        public string Bairro { get; set; } = null;

        // Registros Filhos
        public List<Registro0175> Registros0175 { get; set; } = new List<Registro0175>();
    }
}