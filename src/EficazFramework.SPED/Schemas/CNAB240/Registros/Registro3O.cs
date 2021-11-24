using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.CNAB240
{

    /// <summary>
    /// Registro Detalhe
    /// </summary>
    public class Registro3O : Registro3
    {
        public Registro3O()
        {
        }

        public Registro3O(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            switch (CodigoBanco ?? "")
            {
                case "341": // Banco Itaú
                    {
                        writer.Append(CodigoBanco.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 1
                        writer.Append(LoteDeServico.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 2
                        writer.Append("3"); // 3
                        writer.Append(string.Format("{0:00000}", NumeroSequencial)); // 4
                        writer.Append("O"); // 5
                        writer.Append(TipoMovimento.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 6
                        writer.Append(CodigoBarras.ToFixedLenghtString(48, Escrituracao._builder, Alignment.Right, " ")); // 7
                        writer.Append(ContribuinteNome.ToFixedLenghtString(30, Escrituracao._builder, Alignment.Right, " ")); // 8
                        writer.Append(string.Format("{0:ddMMyyyy}", DataVencimento)); // 9
                        writer.Append(Moeda.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Right, " ")); // 10
                        writer.Append(QuantidadeMoeda.ValueToString(8).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 11
                        writer.Append(ValorPrincipal.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 12
                        writer.Append(string.Format("{0:ddMMyyyy}", DataPagamento)); // 13
                        writer.Append(ValorPago.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 14
                        writer.Append("   "); // 15
                        writer.Append(NotaFiscal.ToFixedLenghtString(9, Escrituracao._builder, Alignment.Left, " ")); // 16
                        writer.Append("   "); // 17
                        writer.Append(SeuNumero.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 18
                        writer.Append("                     "); // 19
                        writer.Append(NossoNumero.ToFixedLenghtString(15, Escrituracao._builder, Alignment.Right, " ")); // 20
                        writer.Append(Ocorrencias.ToFixedLenghtString(10, Escrituracao._builder, Alignment.Right, " ")); // 21
                        break;
                    }

                default:
                    {
                        // Padrão Original Febraban
                        writer.Append(CodigoBanco.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 1
                        writer.Append(LoteDeServico.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 2
                        writer.Append("3"); // 3
                        writer.Append(string.Format("{0:00000}", NumeroSequencial)); // 4
                        writer.Append("O"); // 5
                        writer.Append(TipoMovimento.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 6
                        writer.Append(CodigoBarras.ToFixedLenghtString(44, Escrituracao._builder, Alignment.Right, " ")); // 7
                        writer.Append(ContribuinteNome.ToFixedLenghtString(30, Escrituracao._builder, Alignment.Right, " ")); // 8
                        writer.Append(string.Format("{0:ddMMyyyy}", DataVencimento)); // 9
                        writer.Append(string.Format("{0:ddMMyyyy}", DataPagamento)); // 10 - data pagamento
                        writer.Append(ValorPago.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 11
                        writer.Append(SeuNumero.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 12
                        writer.Append(NossoNumero.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 13
                        writer.Append("".ToFixedLenghtString(68, Alignment.Right, " ")); // 14
                        writer.Append(Ocorrencias.ToFixedLenghtString(10, Escrituracao._builder, Alignment.Right, " ")); // 15
                        break;
                    }
            }

            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoBanco = linha.Substring(0, 3).Trim();
            LoteDeServico = linha.Substring(3, 4).Trim();
            NumeroSequencial = linha.Substring(8, 5).Trim().ToNullableInteger();
            TipoMovimento = linha.Substring(14, 3).Trim();
            switch (CodigoBanco ?? "")
            {
                case "341": // Banco Itaú
                    {
                        CodigoBarras = linha.Substring(17, 48).Trim();
                        ContribuinteNome = linha.Substring(65, 30).Trim();
                        DataVencimento = linha.Substring(95, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
                        Moeda = linha.Substring(103, 3).Trim();
                        QuantidadeMoeda = linha.Substring(106, 15).Trim().ToNullableDouble(8);
                        ValorPrincipal = linha.Substring(121, 15).Trim().ToNullableDouble(2);
                        DataPagamento = linha.Substring(136, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
                        ValorPago = linha.Substring(144, 15).Trim().ToNullableDouble(2);
                        NotaFiscal = linha.Substring(162, 9).Trim();
                        SeuNumero = linha.Substring(174, 20).Trim();
                        NossoNumero = linha.Substring(215, 15).Trim();
                        Ocorrencias = linha.Substring(230, 10).Trim();
                        break;
                    }

                default:
                    {
                        // Padrão Original Febraban
                        CodigoBarras = linha.Substring(17, 44).Trim();
                        ContribuinteNome = linha.Substring(61, 30).Trim();
                        DataVencimento = linha.Substring(91, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
                        DataPagamento = linha.Substring(99, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
                        ValorPago = linha.Substring(107, 15).Trim().ToNullableDouble(2);
                        SeuNumero = linha.Substring(122, 20).Trim();
                        NossoNumero = linha.Substring(142, 20).Trim();
                        Ocorrencias = linha.Substring(230, 10).Trim();
                        break;
                    }
            }
        }

        public string CodigoBanco { get; set; }
        public string LoteDeServico { get; set; }
        public int? NumeroSequencial { get; set; } = 1;
        public string TipoMovimento { get; set; } = "000";
        public string TipoTributo { get; set; } = "00";
        public string CodigoBarras { get; set; }
        public string ContribuinteNome { get; set; }
        public DateTime? DataVencimento { get; set; }
        public string Moeda { get; set; } = "REA";
        public double? QuantidadeMoeda { get; set; } = 0;
        public double? ValorPrincipal { get; set; }
        public DateTime? DataPagamento { get; set; }
        public double? ValorPago { get; set; }
        public string NotaFiscal { get; set; }
        public string SeuNumero { get; set; }
        public string NossoNumero { get; set; }
        public string Ocorrencias { get; set; }

        public string CodigoDeBarrasSemDv()
        {
            if (string.IsNullOrEmpty(CodigoBarras))
                return CodigoBarras;
            if (CodigoBarras.Length == 44)
            {
                return CodigoBarras;
            }
            else if (CodigoBarras.Length == 48)
            {
                string tmp = CodigoBarras;
                tmp = tmp.Remove(11, 1).Remove(22, 1).Remove(33, 1).Remove(44, 1);
                return tmp;
            }

            return CodigoBarras;
        }

        public Registro3Z Detalhamento_Z { get; set; } = null;
    }
}