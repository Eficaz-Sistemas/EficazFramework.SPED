
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Dados do Contabilista
    /// </summary>
    /// <remarks></remarks>

    public class Registro0100 : Primitives.Registro
    {
        public Registro0100() : base("0100")
        {
        }

        public Registro0100(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string NomeContabilista { get; set; } = null;
        public string NumeroCPFContabilista { get; set; } = null;
        public string NumeroCRCContabilista { get; set; } = null;
        public string NumeroCNPJEscrContabilidade { get; set; } = null;
        public string CEP { get; set; } = null;
        public string LogradouroImovel { get; set; } = null;
        public string NumeroImovel { get; set; } = null;
        public string DadosComplementaresEndereco { get; set; } = null;
        public string Bairro { get; set; } = null;
        public string Fone { get; set; } = null;
        public string Fax { get; set; } = null;
        public string Email { get; set; } = null;
        public string CodigoMunicipio { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0100|"); // 01
            writer.Append(NomeContabilista + "|"); // 02
            writer.Append(NumeroCPFContabilista + "|"); // 03
            writer.Append(NumeroCRCContabilista + "|"); // 04
            writer.Append(NumeroCNPJEscrContabilidade + "|"); // 05
            writer.Append(CEP + "|"); // 06
            writer.Append(LogradouroImovel + "|"); // 07
            writer.Append(NumeroImovel + "|"); // 08
            writer.Append(DadosComplementaresEndereco + "|"); // 09
            writer.Append(Bairro + "|"); // 10
            writer.Append(Fone + "|"); // 11
            writer.Append(Fax + "|"); // 12
            writer.Append(Email + "|"); // 13
            writer.Append(CodigoMunicipio + "|"); // 14
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NomeContabilista = data[2];
            NumeroCPFContabilista = data[3];
            NumeroCRCContabilista = data[4];
            NumeroCNPJEscrContabilidade = data[5];
            CEP = data[6];
            LogradouroImovel = data[7];
            NumeroImovel = data[8];
            DadosComplementaresEndereco = data[9];
            Bairro = data[10];
            Fone = data[11];
            Fax = data[12];
            Email = data[13];
            CodigoMunicipio = data[14];
        }
    }
}