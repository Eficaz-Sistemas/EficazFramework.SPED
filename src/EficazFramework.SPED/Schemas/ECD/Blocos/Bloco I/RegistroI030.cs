using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Termo de Abertura do Livro
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI030 : Primitives.Registro
    {
        public RegistroI030() : base("I030")
        {
        }

        public RegistroI030(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public short? NumeroOrdemEscrituracao { get; set; }
        public string NaturezaLivro { get; set; } = null;
        public long? QtdeLinhasArquivo { get; set; }
        public string NomeEmpresarial { get; set; } = null;
        public string Nire { get; set; } = null;
        public string CNPJ { get; set; } = null;
        public DateTime? DataArquivamentoAtos { get; set; }
        public DateTime? DataArquivAtoConversao { get; set; }
        public string Municipio { get; set; } = null;
        public DateTime? DataEncerrExSocial { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I030|TERMO DE ABERTURA|");
            writer.Append(NumeroOrdemEscrituracao + "|");
            writer.Append(NaturezaLivro + "|");
            writer.Append(QtdeLinhasArquivo + "|");
            writer.Append(NomeEmpresarial + "|");
            writer.Append(Nire + "|");
            writer.Append(CNPJ + "|");
            writer.Append(DataArquivamentoAtos.ToSpedString() + "|");
            writer.Append(DataArquivAtoConversao.ToSpedString() + "|");
            writer.Append(Municipio + "|");
            writer.Append(DataEncerrExSocial.ToSpedString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroOrdemEscrituracao = data[3].ToNullableShort();
            NaturezaLivro = data[4];
            QtdeLinhasArquivo = data[5].ToNullableLong();
            NomeEmpresarial = data[6];
            Nire = data[7];
            CNPJ = data[8];
            DataArquivamentoAtos = data[9].ToDate();
            DataArquivAtoConversao = data[10].ToDate();
            Municipio = data[11];
            DataEncerrExSocial = data[12].ToDate();
        }
    }
}