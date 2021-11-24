using System;
using System.Collections.Generic;
using EficazFrameworkCore.Extensions;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.MFD_ECF
{

    /// <summary>
    /// Cupom Fiscal, Nota Fiscal de Venda a Consumidor e Bilhete de Passagem
    /// </summary>
    /// <remarks></remarks>
    public class RegistroE14 : Primitives.Registro
    {
        public RegistroE14(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("E14"); // 1
            writer.Append(NumeroFabricacaoECF.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append(MFAdicional.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(Modelo.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(NumeroUsuario.ValueToString().ToFixedLenghtString(2, Escrituracao._builder, Alignment.Left, "0")); // 5
            writer.Append(CCF_CVC_CBP.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 6
            writer.Append(COO.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 7
            writer.Append(DataEmissao.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 8
            writer.Append(SubTotal.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 9
            writer.Append(DescontoSubTotal.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 10
            if (IndicadorDesconto == IndicadorValor.Valor)
                writer.Append("V");
            else
                writer.Append("P"); // 11
            writer.Append(AcrescimoSubTotal.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 12
            if (IndicadorAcrescimo == IndicadorValor.Valor)
                writer.Append("V");
            else
                writer.Append("P"); // 13
            writer.Append(ValorTotalLiquido.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 14
            if (Cancelamento == true == true)
                writer.Append("S");
            else
                writer.Append("N"); // 15
            writer.Append(CancelamentoAcrescimo.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 16
            if (OrdemDescontoAcrescimo.HasValue == false)
            {
                writer.Append(" "); // 17
            }
            else if ((int?)OrdemDescontoAcrescimo == (int?)MFD_ECF.OrdemDescontoAcrescimo.DescontoAcrescimo == true)
            {
                writer.Append("D"); // 17
            }
            else
            {
                writer.Append("A");
            } // 17

            writer.Append(NomeAdquirente.ToFixedLenghtString(40, Escrituracao._builder, Alignment.Right, " ")); // 18
            writer.Append(CNPJ_CPF.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 19
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            NumeroFabricacaoECF = linha.Substring(3, 20).Trim();
            MFAdicional = linha.Substring(23, 1).Trim();
            Modelo = linha.Substring(24, 20).Trim();
            NumeroUsuario = linha.Substring(44, 2).ToNullableInteger();
            CCF_CVC_CBP = linha.Substring(46, 6).ToNullableInteger();
            COO = linha.Substring(52, 6).ToNullableInteger();
            DataEmissao = linha.Substring(58, 8).ToDate(Extensions.DateFormat.AAAAMMDD);
            SubTotal = linha.Substring(66, 14).ToNullableDouble(2);
            DescontoSubTotal = linha.Substring(80, 13).ToNullableDouble(2);
            string inddesc = linha.Substring(93, 1);
            if (inddesc == "P")
                IndicadorDesconto = IndicadorValor.Percentual;
            else
                IndicadorDesconto = IndicadorValor.Valor;
            AcrescimoSubTotal = linha.Substring(94, 13).ToNullableDouble(2);
            string indacres = linha.Substring(107, 1);
            if (indacres == "P")
                IndicadorAcrescimo = IndicadorValor.Percentual;
            else
                IndicadorAcrescimo = IndicadorValor.Valor;
            ValorTotalLiquido = linha.Substring(108, 14).ToNullableDouble(2);
            string indcanc = linha.Substring(122, 1);
            if (indcanc == "S")
                Cancelamento = true;
            else
                Cancelamento = false;
            CancelamentoAcrescimo = linha.Substring(123, 13).ToNullableDouble(2);
            string ordem = linha.Substring(136, 1);
            if (string.IsNullOrEmpty(ordem) | string.IsNullOrWhiteSpace(ordem))
            {
                OrdemDescontoAcrescimo = default;
            }
            else if (ordem == "A")
                OrdemDescontoAcrescimo = MFD_ECF.OrdemDescontoAcrescimo.AcrescimoDesconto;
            else
                OrdemDescontoAcrescimo = MFD_ECF.OrdemDescontoAcrescimo.DescontoAcrescimo;
            NomeAdquirente = linha.Substring(137, 40).Trim();
            CNPJ_CPF = linha.Substring(177, 14).Trim();
            if (CNPJ_CPF.IsValidCNPJ() == false & CNPJ_CPF.Substring(0, 3) == "000" & CNPJ_CPF.Substring(3).IsValidCPF())
            {
                CNPJ_CPF = CNPJ_CPF.Substring(3);
            }
        }

        public string NumeroFabricacaoECF { get; set; } // campo 2
        public string MFAdicional { get; set; } // 3
        public string Modelo { get; set; } // 4
        public int? NumeroUsuario { get; set; } // 5
        public int? CCF_CVC_CBP { get; set; } // 6 Contadordo respectivo documento emitido
        public int? COO { get; set; } // 7
        public DateTime? DataEmissao { get; set; } // 8
        public double? SubTotal { get; set; } // 9
        public double? DescontoSubTotal { get; set; } // 10 'Valor do desconto ou % aplicado
        public IndicadorValor IndicadorDesconto { get; set; } // 11
        public double? AcrescimoSubTotal { get; set; } // 12
        public IndicadorValor IndicadorAcrescimo { get; set; } // 13
        public double? ValorTotalLiquido { get; set; } // 14
        public bool? Cancelamento { get; set; } // 15
        public double? CancelamentoAcrescimo { get; set; } // 16
        public OrdemDescontoAcrescimo? OrdemDescontoAcrescimo { get; set; } = default; // 17
        public string NomeAdquirente { get; set; } // 18
        public string CNPJ_CPF { get; set; } // 19

        // // Navigation Properties

        public List<RegistroE15> RegistrosE15 { get; set; } = new List<RegistroE15>();
    }
}