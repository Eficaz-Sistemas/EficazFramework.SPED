using System;
using System.Collections.Generic;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.CNAB240
{

    /// <summary>
    /// Registro Header de Lote de Serviço
    /// </summary>
    public class Registro1 : Primitives.Registro
    {
        public Registro1() : base("1")
        {
        }

        public Registro1(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append(CodigoBanco.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 1
            writer.Append(LoteDeServico.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append("1"); // 3
            writer.Append(TipoOperacao.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(string.Format("{0:00}", (int)TipoDePagamento)); // 5
            writer.Append(string.Format("{0:00}", (int)FormaDePagamento)); // 6
            writer.Append(LayoutLote.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 7
            writer.Append(" "); // 8
            writer.Append(TipoInscricao.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 9
            writer.Append(CNPJ.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 10
            writer.Append(Convenio.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 11
            writer.Append(Agencia.ToFixedLenghtString(5, Escrituracao._builder, Alignment.Left, "0")); // 12
            writer.Append(AgenciaDV.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Left, " ")); // 13
            writer.Append(Conta.ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 14
            writer.Append(ContaDV.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Left, " ")); // 15
            writer.Append(DAC.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Left, "0")); // 16
            writer.Append(NomeEmpresa.ToFixedLenghtString(30, Escrituracao._builder, Alignment.Right, " ")); // 17

            // ## MENSAGEM 1
            if (CodigoBanco == "341")
            {
                writer.Append(string.Format("{0:00}", (int)FinalidadeLote).ToFixedLenghtString(30, Alignment.Right, " ")); // 18
            }
            else
            {
                writer.Append(" ".ToFixedLenghtString(30, Alignment.Right, " "));
            } // 18

            writer.Append(HistoricoCC.ToFixedLenghtString(10, Escrituracao._builder, Alignment.Right, " ")); // 19  
            // ## MENSAGEM 2
            writer.Append(EnderecoEmpresa.ToFixedLenghtString(30, Escrituracao._builder, Alignment.Right, " ")); // 20
            if (!EnderecoNumero.IsNumeric())
                EnderecoNumero = 0.ToString();
            writer.Append(EnderecoNumero.ToFixedLenghtString(5, Escrituracao._builder, Alignment.Right, "0")); // 21
            writer.Append(EnderecoComplemento.ToFixedLenghtString(15, Escrituracao._builder, Alignment.Right, " ")); // 22
            writer.Append(EnderecoCidade.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 23
            writer.Append(EnderecoCEP.ToFixedLenghtString(8, Escrituracao._builder, Alignment.Right, " ")); // 24
            writer.Append(EnderecoUF.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 25
            if (CodigoBanco == "237")
            {
                writer.Append("01      "); // 26 Bradesco
            }
            else
            {
                writer.Append("        ");
            } // 26

            writer.Append(Ocorrencias.ToFixedLenghtString(10, Escrituracao._builder, Alignment.Right, " ")); // 25
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoBanco = linha.Substring(0, 3).Trim();
            LoteDeServico = linha.Substring(3, 4).Trim();
            TipoOperacao = linha.Substring(8, 1).Trim();
            TipoDePagamento = (TipoDePagamento)linha.Substring(123, 2).Trim().ToEnum<TipoDePagamento>(TipoDePagamento.Tributos);
            FormaDePagamento = (FormaDePagamento)linha.Substring(123, 2).Trim().ToEnum<FormaDePagamento>(FormaDePagamento.GnreTributosCodBarras);
            LayoutLote = linha.Substring(13, 3).Trim();
            TipoInscricao = linha.Substring(17, 1).Trim();
            CNPJ = linha.Substring(18, 14).Trim();
            Convenio = linha.Substring(32, 20).Trim();
            Agencia = linha.Substring(52, 5).Trim();
            Conta = linha.Substring(58, 12).Trim();
            DAC = linha.Substring(71, 1).Trim();
            NomeEmpresa = linha.Substring(72, 30).Trim();
            FinalidadeLote = (FinalidadeLote)linha.Substring(102, 30).Trim().ToEnum<FinalidadeLote>(FinalidadeLote.FolhaMensal);
            HistoricoCC = linha.Substring(132, 10).Trim();
            EnderecoEmpresa = linha.Substring(142, 30).Trim();
            EnderecoNumero = linha.Substring(172, 5).Trim();
            EnderecoComplemento = linha.Substring(177, 15).Trim();
            EnderecoCidade = linha.Substring(192, 20).Trim();
            EnderecoCEP = linha.Substring(212, 8).Trim();
            EnderecoUF = linha.Substring(220, 2).Trim();
            Ocorrencias = linha.Substring(230, 10).Trim();
        }

        public string CodigoBanco { get; set; }
        public string LoteDeServico { get; set; }
        public string TipoOperacao { get; set; } = "C";
        public TipoDePagamento TipoDePagamento { get; set; } = TipoDePagamento.Tributos;
        public FormaDePagamento FormaDePagamento { get; set; } = FormaDePagamento.GnreTributosCodBarras;
        public string LayoutLote { get; set; } = "040";
        /// <summary>
        /// 1 = CPF
        /// 2 = CNPJ [Default]
        /// </summary>
        public string TipoInscricao { get; set; } = "2";
        public string CNPJ { get; set; }
        public string Convenio { get; set; }
        public string Agencia { get; set; }
        public string AgenciaDV { get; set; }
        public string Conta { get; set; }
        public string ContaDV { get; set; }
        public string DAC { get; set; } = "9";
        public string NomeEmpresa { get; set; }
        public FinalidadeLote FinalidadeLote { get; set; } = FinalidadeLote.FolhaMensal;
        public string HistoricoCC { get; set; }
        public string EnderecoEmpresa { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoComplemento { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoCEP { get; set; }
        public string EnderecoUF { get; set; }
        public string Ocorrencias { get; set; }
        public List<Registro3> Registros3 { get; set; } = new List<Registro3>();
    }
}