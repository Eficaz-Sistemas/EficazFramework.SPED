using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Cadastro de Bens ou Componentes do Ativo Imobilizado
    /// </summary>
    /// <remarks></remarks>
    public class Registro0300 : Primitives.Registro
    {
        public Registro0300() : base("0300")
        {
        }

        public Registro0300(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0300|"); // 1
            writer.Append(CodigoProduto + "|"); // 2
            writer.Append((int)IdentificacaoTipo + "|"); // 3
            writer.Append(Descricao + "|"); // 4
            writer.Append(CodigoBemPrincipal + "|"); // 5
            writer.Append(CodigoContaContabil + "|"); // 6
            writer.Append(NumeroParcelas + "|"); // 7
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoProduto = data[2];
            IdentificacaoTipo = (TipoMercadoriaImobilizado)data[3].ToEnum<TipoMercadoriaImobilizado>(TipoMercadoriaImobilizado.Bem);
            Descricao = data[4];
            CodigoBemPrincipal = data[5];
            CodigoContaContabil = data[6];
            NumeroParcelas = data[7].ToNullableInteger();
        }

        public string CodigoProduto { get; set; } = null; // 2
        public TipoMercadoriaImobilizado IdentificacaoTipo { get; set; } = TipoMercadoriaImobilizado.Bem; // 3
        public string Descricao { get; set; } = null;  // 4
        public string CodigoBemPrincipal { get; set; } // 5
        public string CodigoContaContabil { get; set; } // 6
        public int? NumeroParcelas { get; set; } // 7

        // Registros Filhos
        public Registro0305 Registro0305 { get; set; }
    }
}