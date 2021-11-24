using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.CNAB240.Itau
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
            writer.Append("3"); // 3
            writer.Append(string.Format("{0:00000}", NumeroSequencial)); // 4
            writer.Append("N"); // 5
            writer.Append(TipoMovimento.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 6
            if (DadosTributo != null)
                writer.Append(DadosTributo.EscreveLinha()); // 7
            writer.Append(SeuNumero.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 8
            writer.Append(NossoNumero.ToFixedLenghtString(15, Escrituracao._builder, Alignment.Right, " ")); // 9
            writer.Append(Ocorrencias.ToFixedLenghtString(10, Escrituracao._builder, Alignment.Right, " ")); // 10
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoBanco = linha.Substring(0, 3).Trim();
            LoteDeServico = linha.Substring(3, 4).Trim();
            NumeroSequencial = linha.Substring(8, 5).Trim().ToNullableInteger();
            TipoMovimento = linha.Substring(14, 3).Trim();
            TipoTributo = linha.Substring(17, 2).Trim();
            Registro3N_AnexoC reg = null;
            switch (TipoTributo ?? "")
            {
                case "01":
                    {
                        reg = new Registro3N_AnexoC_GPS(data[0], Versao);
                        break;
                    }

                case "02":
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

                case "05":
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
            SeuNumero = linha.Substring(195, 20).Trim();
            NossoNumero = linha.Substring(215, 15).Trim();
            Ocorrencias = linha.Substring(230, 10).Trim();
        }

        public string CodigoBanco { get; set; }
        public string LoteDeServico { get; set; }
        public int? NumeroSequencial { get; set; } = 1;
        public string TipoMovimento { get; set; } = "000";
        public string TipoTributo { get; set; } = "00";
        public Registro3N_AnexoC DadosTributo { get; set; } = null;
        public string SeuNumero { get; set; }
        public string NossoNumero { get; set; }
        public string Ocorrencias { get; set; }
    }
}