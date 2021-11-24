using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.MFD_ECF
{

    /// <summary>
    /// Detalhe do Cupom Fiscal, da Nota Fiscal de Venda a Consumidor ou do Bilhete de Passagem.
    /// </summary>
    /// <remarks></remarks>
    public class RegistroE15 : Primitives.Registro
    {
        public RegistroE15(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("E15"); // 1
            writer.Append(NumeroFabricacaoECF.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append(MFAdicional.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(Modelo.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(NumeroUsuario.ValueToString().ToFixedLenghtString(2, Escrituracao._builder, Alignment.Left, "0")); // 5
            writer.Append(COO.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 7
            writer.Append(CCF_CVC_CBP.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 6
            writer.Append(NumeroItem.ValueToString().ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 8
            writer.Append(CodigoProduto.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 9
            writer.Append(Descricao.ToFixedLenghtString(100, Escrituracao._builder, Alignment.Right, " ")); // 10
            if (CasasDecimaisQtdade.HasValue == true)
            {
                writer.Append((Quantidade * Math.Pow(10, (double)CasasDecimaisQtdade)).ValueToString().ToFixedLenghtString(7, Escrituracao._builder, Alignment.Left, "0")); // 11
            }
            else
            {
                writer.Append(Quantidade.ValueToString().ToFixedLenghtString(7, Escrituracao._builder, Alignment.Left, "0"));
            } // 11

            writer.Append(UnidadeMedida.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Right, " ")); // 12
            if (CasasDecimaisUnitario.HasValue == true)
            {
                writer.Append((ValorUnitario * Math.Pow(10, (double)CasasDecimaisQtdade)).ValueToString().ToFixedLenghtString(8, Escrituracao._builder, Alignment.Left, "0")); // 13
            }
            else
            {
                writer.Append(ValorUnitario.ValueToString().ToFixedLenghtString(8, Escrituracao._builder, Alignment.Left, "0"));
            } // 13

            writer.Append(Desconto.ValueToString(2).ToFixedLenghtString(8, Escrituracao._builder, Alignment.Left, "0")); // 14
            writer.Append(Acrescimo.ValueToString(2).ToFixedLenghtString(8, Escrituracao._builder, Alignment.Left, "0")); // 15
            writer.Append(TotalLiquido.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 16
            writer.Append(TotalizadorParcial.ToFixedLenghtString(7, Escrituracao._builder, Alignment.Right, " ")); // 17
            if (Cancelamento == true == true)
                writer.Append("S");
            else
                writer.Append("N"); // 18
            if (CasasDecimaisQtdade.HasValue == true)
            {
                writer.Append((QuantidadeCancelada * Math.Pow(10, (double)CasasDecimaisQtdade)).ValueToString().ToFixedLenghtString(7, Escrituracao._builder, Alignment.Left, "0")); // 19
            }
            else
            {
                writer.Append(QuantidadeCancelada.ValueToString().ToFixedLenghtString(7, Escrituracao._builder, Alignment.Left, "0"));
            } // 19

            writer.Append(ValorCancelado.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 20
            writer.Append(CancelamentoAcrescimo.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 21
            if (IAT_TotalLiquido == IndicadorArredTruncam.Arredondamento)
                writer.Append("A");
            else
                writer.Append("T"); // 22
            writer.Append(CasasDecimaisQtdade.ValueToString().ToFixedLenghtString(1, Escrituracao._builder, Alignment.Left, "0")); // 23
            writer.Append(CasasDecimaisUnitario.ValueToString().ToFixedLenghtString(1, Escrituracao._builder, Alignment.Left, "0")); // 24
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            NumeroFabricacaoECF = linha.Substring(3, 20).Trim();
            MFAdicional = linha.Substring(23, 1).Trim();
            Modelo = linha.Substring(24, 20).Trim();
            NumeroUsuario = linha.Substring(44, 2).ToNullableInteger();
            COO = linha.Substring(46, 6).ToNullableInteger();
            CCF_CVC_CBP = linha.Substring(52, 6).ToNullableInteger();
            NumeroItem = linha.Substring(58, 3).ToNullableInteger();
            CodigoProduto = linha.Substring(61, 14).Trim();
            Descricao = linha.Substring(75, 100).Trim();
            CasasDecimaisQtdade = linha.Substring(265, 1).ToNullableInteger();
            if (CasasDecimaisQtdade.HasValue == true)
            {
                Quantidade = linha.Substring(175, 7).ToNullableDouble((int)CasasDecimaisQtdade);
            }
            else
            {
                Quantidade = linha.Substring(175, 7).ToNullableDouble(0);
            }

            UnidadeMedida = linha.Substring(182, 3).Trim();
            CasasDecimaisUnitario = linha.Substring(266, 1).ToNullableInteger();
            if (CasasDecimaisUnitario.HasValue == true)
            {
                ValorUnitario = linha.Substring(185, 8).ToNullableDouble((int)CasasDecimaisUnitario);
            }
            else
            {
                ValorUnitario = linha.Substring(185, 8).ToNullableDouble(0);
            }

            Desconto = linha.Substring(193, 8).ToNullableDouble(2);
            Acrescimo = linha.Substring(201, 8).ToNullableDouble(2);
            TotalLiquido = linha.Substring(209, 14).ToNullableDouble(2);
            TotalizadorParcial = linha.Substring(223, 7).Trim();
            string indcanc = linha.Substring(230, 1);
            if (indcanc == "S")
                Cancelamento = true;
            else
                Cancelamento = false;
            if (CasasDecimaisQtdade.HasValue == true)
            {
                QuantidadeCancelada = linha.Substring(231, 7).ToNullableDouble((int)CasasDecimaisQtdade);
            }
            else
            {
                QuantidadeCancelada = linha.Substring(231, 7).ToNullableDouble(0);
            }

            ValorCancelado = linha.Substring(238, 13).ToNullableDouble(2);
            CancelamentoAcrescimo = linha.Substring(251, 13).ToNullableDouble(2);
            string iat = linha.Substring(264, 1);
            if (iat == "T")
                IAT_TotalLiquido = IndicadorArredTruncam.Truncamento;
            else
                IAT_TotalLiquido = IndicadorArredTruncam.Arredondamento;
        }

        public string NumeroFabricacaoECF { get; set; } // campo 2
        public string MFAdicional { get; set; } // 3
        public string Modelo { get; set; } // 4
        public int? NumeroUsuario { get; set; } // 5
        public int? CCF_CVC_CBP { get; set; } // 6 Contadordo respectivo documento emitido
        public int? COO { get; set; } // 7
        public int? NumeroItem { get; set; } // 8
        public string CodigoProduto { get; set; } // 9
        public string Descricao { get; set; } // 10
        public double? Quantidade { get; set; } // 11
        public string UnidadeMedida { get; set; } // 12
        public double? ValorUnitario { get; set; } // 13
        public double? Desconto { get; set; } // 14
        public double? Acrescimo { get; set; } // 15
        public double? TotalLiquido { get; set; } // 16
        public string TotalizadorParcial { get; set; } // 17
        public bool? Cancelamento { get; set; } // 18
        public double? QuantidadeCancelada { get; set; } // 19
        public double? ValorCancelado { get; set; } // 20
        public double? CancelamentoAcrescimo { get; set; } // 21
        public IndicadorArredTruncam IAT_TotalLiquido { get; set; } // 22
        public int? CasasDecimaisQtdade { get; set; } // 23
        public int? CasasDecimaisUnitario { get; set; } // 24
    }
}