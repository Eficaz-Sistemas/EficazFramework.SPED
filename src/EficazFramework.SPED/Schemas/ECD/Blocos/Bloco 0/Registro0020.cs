using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Escrituração Contábil Descentralizada
    /// </summary>
    /// <remarks></remarks>

    public class Registro0020 : Primitives.Registro
    {
        public Registro0020() : base("0020")
        {
        }

        public Registro0020(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public IndicadorDescentralizacao IndicadorDescentralizacao { get; set; } = IndicadorDescentralizacao.EscrituracaoMatriz;
        public string CNPJ { get; set; } = null;
        public string UF { get; set; } = null;
        public string InscEstadual { get; set; } = null;
        public string CodigoMunicipal { get; set; } = null;
        public string InscMunicipal { get; set; } = null;
        public string Nire { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0020|");
            writer.Append(((int)IndicadorDescentralizacao).ToString() + "|");
            writer.Append(CNPJ + "|");
            writer.Append(UF + "|");
            writer.Append(InscEstadual + "|");
            writer.Append(CodigoMunicipal + "|");
            writer.Append(InscMunicipal + "|");
            writer.Append(Nire + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorDescentralizacao = (IndicadorDescentralizacao)data[2].ToEnum<IndicadorDescentralizacao>(IndicadorDescentralizacao.EscrituracaoMatriz);
            CNPJ = data[3];
            UF = data[4];
            InscEstadual = data[5];
            CodigoMunicipal = data[6];
            InscMunicipal = data[7];
            Nire = data[8];
        }
    }
}