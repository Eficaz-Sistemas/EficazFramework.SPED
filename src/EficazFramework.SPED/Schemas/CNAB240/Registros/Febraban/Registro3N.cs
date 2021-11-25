using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.CNAB240.Febraban
{

    /// <summary>
    /// Registro Detalhe
    /// </summary>
    public class Registro3N : Registro3
    {
        public Registro3N()
        {
        }

        public Registro3N(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append(CodigoBanco.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 1
            writer.Append(LoteDeServico.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append('3'); // 3
            writer.Append(string.Format("{0:00000}", NumeroSequencial)); // 4
            writer.Append('N'); // 5
            writer.Append(TipoMovimento.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 6, 7
            writer.Append(SeuNumero.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 8
            writer.Append(NossoNumero.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 9
            writer.Append(ContribuinteNome.ToFixedLenghtString(30, Escrituracao._builder, Alignment.Right, " ")); // 8
            writer.Append(string.Format("{0:ddMMyyyy}", DataArrecadacao)); // 10
            writer.Append(ValorArrecadado.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 10
            if (DadosTributo != null)
                writer.Append(DadosTributo.EscreveLinha()); // 7
            writer.Append(Ocorrencias.ToFixedLenghtString(10, Escrituracao._builder, Alignment.Right, " ")); // 10
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoBanco = linha[..3].Trim();
            LoteDeServico = linha.Substring(3, 4).Trim();
            NumeroSequencial = linha.Substring(8, 5).Trim().ToNullableInteger();
            TipoMovimento = linha.Substring(14, 3).Trim();
            SeuNumero = linha.Substring(17, 20).Trim();
            NossoNumero = linha.Substring(37, 20).Trim();
            ContribuinteNome = linha.Substring(57, 30).Trim();
            DataArrecadacao = linha.Substring(87, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
            ValorArrecadado = linha.Substring(95, 13).Trim().ToNullableDouble(2);
            TipoTributo = linha.Substring(132, 2).Trim();
            Registro3N_AnexoC reg = null;
            switch (TipoTributo ?? "")
            {
                case "17":
                    {
                        reg = new Registro3N_AnexoC_GPS(data[0], Versao);
                        break;
                    }

                case "16":
                    {
                        reg = new Registro3N_AnexoC_DARF(data[0], Versao);
                        break;
                    }

                case "03":
                    {
                        break;
                    }
                // DARF SIMPLES: Fodam-se, todos vocês

                case "04":
                    {
                        break;
                    }
                // DARJ: Não curtimos o Rio, que nunca foi lindo

                case "22":
                case "23":
                case "24":
                    {
                        reg = new Registro3N_AnexoC_GARE_SP(data[0], Versao);
                        break;
                    }

                default:
                    {
                        break;
                    }
                    // ah mas nao vou perder tempo com isso agora né!

            }

            DadosTributo = reg;
            Ocorrencias = linha.Substring(230, 10).Trim();
        }

        public string CodigoBanco { get; set; }
        public string LoteDeServico { get; set; }
        public int? NumeroSequencial { get; set; } = 1;
        public string TipoMovimento { get; set; } = "000";
        public string TipoTributo { get; set; } = "00";
        public string SeuNumero { get; set; }
        public string NossoNumero { get; set; }
        public string ContribuinteNome { get; set; }
        public double? ValorArrecadado { get; set; }
        public DateTime? DataArrecadacao { get; set; }
        public Registro3N_AnexoC DadosTributo { get; set; } = null;
        public string Ocorrencias { get; set; }
    }
}