using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.MFD_ECF
{

    /// <summary>
    /// Detalhe da Redução Z - Meios de Pagamenteo e Troco
    /// </summary>
    /// <remarks></remarks>
    public class RegistroE18 : Primitives.Registro
    {
        public RegistroE18(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("E18"); // 1
            writer.Append(NumeroFabricacaoECF.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append(MFAdicional.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(Modelo.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(NumeroUsuario.ValueToString().ToFixedLenghtString(2, Escrituracao._builder, Alignment.Left, "0")); // 5
            writer.Append(CRZ.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 6
            writer.Append(DescricaoMeioPagto.ToFixedLenghtString(15, Escrituracao._builder, Alignment.Right, " ")); // 7
            writer.Append(ValorAcumulado.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 8
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            NumeroFabricacaoECF = linha.Substring(3, 20).Trim();
            MFAdicional = linha.Substring(23, 1).Trim();
            Modelo = linha.Substring(24, 20).Trim();
            NumeroUsuario = linha.Substring(44, 2).ToNullableInteger();
            CRZ = linha.Substring(46, 6).ToNullableInteger();
            DescricaoMeioPagto = linha.Substring(52, 15).Trim();
            ValorAcumulado = linha.Substring(67, 13).Trim().ToNullableDouble(2);
        }

        public string NumeroFabricacaoECF { get; set; } // campo 2
        public string MFAdicional { get; set; } // 3
        public string Modelo { get; set; } // 4
        public int? NumeroUsuario { get; set; } // 5
        public int? CRZ { get; set; } // 6 Contador de Reduçao Z
        public string DescricaoMeioPagto { get; set; } // 7
        public double? ValorAcumulado { get; set; } // 8 Valor total do meio de pagamento

        public NFe.FormaPagamento FormaPagamento
        {
            get
            {
                if ((DescricaoMeioPagto ?? "").ToLower().Contains("dinhe"))
                {
                    return NFe.FormaPagamento.Dinheiro;
                }
                else if ((DescricaoMeioPagto ?? "").ToLower().RemoveAccents().Contains("cartao"))
                {
                    if ((DescricaoMeioPagto ?? "").ToLower().RemoveAccents().Contains("deb"))
                    {
                        return NFe.FormaPagamento.CartaoDebito;
                    }
                    else
                    {
                        return NFe.FormaPagamento.CartaoCredito;
                    }
                }
                else if ((DescricaoMeioPagto ?? "").ToLower().Contains("vista"))
                {
                    return NFe.FormaPagamento.Dinheiro;
                }
                else if ((DescricaoMeioPagto ?? "").ToLower().Contains("cheque"))
                {
                    return NFe.FormaPagamento.Cheque;
                }
                else if ((DescricaoMeioPagto ?? "").ToLower().Contains("convenio"))
                {
                    return NFe.FormaPagamento.Outros;
                }
                else if ((DescricaoMeioPagto ?? "").ToLower().Contains("vale"))
                {
                    if ((DescricaoMeioPagto ?? "").ToLower().RemoveAccents().Contains("alim"))
                    {
                        return NFe.FormaPagamento.ValeAlimentacao;
                    }
                    else if ((DescricaoMeioPagto ?? "").ToLower().RemoveAccents().Contains("ref"))
                    {
                        return NFe.FormaPagamento.ValeRefeicao;
                    }
                    else if ((DescricaoMeioPagto ?? "").ToLower().RemoveAccents().Contains("comb"))
                    {
                        return NFe.FormaPagamento.ValeCombustivel;
                    }
                    else
                    {
                        return NFe.FormaPagamento.ValePresente;
                    }
                }
                else if ((DescricaoMeioPagto ?? "").ToLower().Contains("boleto"))
                {
                    return NFe.FormaPagamento.BoletoBancario;
                }
                else if ((DescricaoMeioPagto ?? "").ToLower().Contains("cred"))
                {
                    return NFe.FormaPagamento.CreditoLoja;
                }
                else
                {
                    return NFe.FormaPagamento.Outros;
                }
            }
        }

        public double ValorAcumuladoAjustado
        {
            get
            {
                if ((DescricaoMeioPagto ?? "").ToLower().Contains("troco"))
                {
                    return (ValorAcumulado ?? 0d) * -1;
                }
                else
                {
                    return ValorAcumulado ?? 0d;
                }
            }
        }
    }
}