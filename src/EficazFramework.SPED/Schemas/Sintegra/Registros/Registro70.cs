using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.Sintegra
{
    public class Registro70 : Primitives.Registro
    {
        public Registro70(string linha, string versao) : base(linha, versao)
        {
        }

        public Registro70() : base("70")
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("70"); // 1
            writer.Append(CNPJ.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append(InscricaoEstadual.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(Data.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 4
            writer.Append(UF.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 5
            writer.Append(Modelo.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 6
            writer.Append(Serie.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 7
            writer.Append(SubSerie.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 8
            writer.Append(Numero.ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 9
            writer.Append(CFOP.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 10
            writer.Append(ValorTotal.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 11
            writer.Append(BaseCalculo.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 12
            writer.Append(ICMS.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 13
            writer.Append(Isentas.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 14
            writer.Append(Outras.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 15
            writer.Append(Modalidade.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 16
            switch (Situacao)
            {
                case EFD_ICMS_IPI.SituacaoDocumento.Complementar:
                case EFD_ICMS_IPI.SituacaoDocumento.ComplementarExtemporaneo:
                case EFD_ICMS_IPI.SituacaoDocumento.RegimeEspecial:
                case EFD_ICMS_IPI.SituacaoDocumento.Regular:
                case EFD_ICMS_IPI.SituacaoDocumento.RegularExtemporaneo:
                    {
                        writer.Append("N");
                        break;
                    }

                case EFD_ICMS_IPI.SituacaoDocumento.Pendente:
                case EFD_ICMS_IPI.SituacaoDocumento.Inutilizado:
                case EFD_ICMS_IPI.SituacaoDocumento.Denegado:
                case EFD_ICMS_IPI.SituacaoDocumento.CanceladoExtemporaneo:
                case EFD_ICMS_IPI.SituacaoDocumento.Cancelado:
                    {
                        writer.Append("S");
                        break;
                    }

                default:
                    {
                        writer.Append("S");
                        break;
                    }
            }

            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CNPJ = linha.Substring(2, 14).Trim();
            InscricaoEstadual = linha.Substring(16, 14).Trim();
            Data = linha.Substring(30, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
            UF = linha.Substring(38, 2).Trim();
            Modelo = linha.Substring(40, 2).Trim();
            Serie = linha.Substring(42, 1).Trim();
            SubSerie = linha.Substring(43, 2).Trim();
            Numero = linha.Substring(45, 6).Trim();
            CFOP = linha.Substring(51, 4).Trim();
            ValorTotal = linha.Substring(56, 13).ToNullableDouble(2);
            BaseCalculo = linha.Substring(68, 14).ToNullableDouble(2);
            ICMS = linha.Substring(82, 14).ToNullableDouble(2);
            Isentas = linha.Substring(96, 14).ToNullableDouble(2);
            Outras = linha.Substring(110, 14).ToNullableDouble(2);
            Modalidade = linha.Substring(124, 1).Trim();
            string sitstr = linha.Substring(125, 1);
            if (sitstr.ToUpper() == "N")
                Situacao = EFD_ICMS_IPI.SituacaoDocumento.Regular;
            else
                Situacao = EFD_ICMS_IPI.SituacaoDocumento.Cancelado;
        }

        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime? Data { get; set; }
        public string UF { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string SubSerie { get; set; }
        public string Numero { get; set; }
        public string CFOP { get; set; }
        public double? ValorTotal { get; set; }
        public double? BaseCalculo { get; set; }
        public double? ICMS { get; set; }
        public double? Isentas { get; set; }
        public double? Outras { get; set; }
        public string Modalidade { get; set; }
        public EFD_ICMS_IPI.SituacaoDocumento Situacao { get; set; } = EFD_ICMS_IPI.SituacaoDocumento.Regular;
    }
}