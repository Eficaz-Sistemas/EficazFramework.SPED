using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.Sintegra
{
    public class Registro10 : Primitives.Registro
    {
        public Registro10(string linha, string versao) : base(linha, versao)
        {
        }

        public Registro10() : base("10")
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("10"); // 1
            writer.Append(CNPJ.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append(InscricaoEstadual.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(NomeComercial.ToFixedLenghtString(35, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(Municipio.ToFixedLenghtString(30, Escrituracao._builder, Alignment.Right, " ")); // 5
            writer.Append(UF.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 6
            writer.Append(NumeroFax.ToFixedLenghtString(10, Escrituracao._builder, Alignment.Left, "0")); // 7
            writer.Append(DataInicio.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 8
            writer.Append(DataFinal.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 9
            writer.Append(((int)CodigoIndentificacaoArquivoEntregue).ToString().ToFixedLenghtString(1, Escrituracao._builder, Alignment.Left, "0")); // 10
            writer.Append(((int)CodigoIdentificacaoNatOp).ToString().ToFixedLenghtString(1, Escrituracao._builder, Alignment.Left, "0")); // 11
            writer.Append(((int)CodigoFinalidadeApresentacao).ToString().ToFixedLenghtString(1, Escrituracao._builder, Alignment.Left, "0")); // 12
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CNPJ = linha.Substring(2, 14).Trim();
            InscricaoEstadual = linha.Substring(16, 14).Trim();
            NomeComercial = linha.Substring(30, 35).Trim();
            Municipio = linha.Substring(65, 30).Trim();
            UF = linha.Substring(95, 2).Trim();
            NumeroFax = linha.Substring(97, 10).Trim();
            DataInicio = linha.Substring(107, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
            DataFinal = linha.Substring(115, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
            CodigoIndentificacaoArquivoEntregue = (CodigoIDArquivo)linha.Substring(123, 1).Trim().ToEnum<CodigoIDArquivo>(CodigoIDArquivo.Convenio_76_03_e_20_04);
            CodigoIdentificacaoNatOp = (NaturezaOperacoes)linha.Substring(124, 1).Trim().ToEnum<NaturezaOperacoes>(NaturezaOperacoes.Totalidade);
            CodigoFinalidadeApresentacao = (FinalidadeApresentacao)linha.Substring(125, 1).Trim().ToEnum<FinalidadeApresentacao>(FinalidadeApresentacao.Normal);
        }

        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string NomeComercial { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string NumeroFax { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }
        public CodigoIDArquivo CodigoIndentificacaoArquivoEntregue { get; set; }
        public NaturezaOperacoes CodigoIdentificacaoNatOp { get; set; }
        public FinalidadeApresentacao CodigoFinalidadeApresentacao { get; set; }
    }
}