using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.Sintegra
{

    /// <summary>
    /// Código EAN/GTIN do produto
    /// </summary>
    /// <remarks></remarks>
    public class Registro88EAN : Primitives.Registro
    {
        public Registro88EAN(string linha, string versao) : base(linha, versao)
        {
        }

        public Registro88EAN() : base("88EAN")
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("88EAN"); // 1
            writer.Append(Modo.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append(CodigoProduto.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(Descricao.ToFixedLenghtString(53, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(UnidadeMedida.ToFixedLenghtString(6, Escrituracao._builder, Alignment.Right, " ")); // 7
            writer.Append(EAN.ToFixedLenghtString(13, Escrituracao._builder, Alignment.Right, " ")); // 7
            writer.Append(Brancos.ToFixedLenghtString(33, Escrituracao._builder, Alignment.Right, " ")); // 7
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            Modo = linha.Substring(5, 2).Trim();
            CodigoProduto = linha.Substring(7, 14).Trim();
            Descricao = linha.Substring(21, 53).Trim();
            UnidadeMedida = linha.Substring(74, 6).Trim();
            EAN = linha.Substring(80, 13).Trim();
            // Me.Brancos = linha.Substring(93, 33).Trim
        }

        public string Modo { get; set; }
        public string CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public string UnidadeMedida { get; set; }
        public string EAN { get; set; }
        public string Brancos { get; set; }
    }
}