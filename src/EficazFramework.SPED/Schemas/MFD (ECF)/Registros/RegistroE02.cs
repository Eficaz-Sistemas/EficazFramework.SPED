using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.MFD_ECF
{

    /// <summary>
    /// Identificação do Atual Contribuinte Usuário do ECF
    /// </summary>
    /// <remarks></remarks>
    public class RegistroE02 : Primitives.Registro
    {
        public RegistroE02(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("E02"); // 1
            writer.Append(NumeroFabricacaoECF.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append(MFAdicional.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(Modelo.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(CNPJ.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 5
            writer.Append(InscricaoEstadual.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 6
            writer.Append(RazaoSocial.ToFixedLenghtString(40, Escrituracao._builder, Alignment.Right, " ")); // 7
            writer.Append(Endereco.ToFixedLenghtString(120, Escrituracao._builder, Alignment.Right, " ")); // 8
            writer.Append(DataCadastro.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 9
            writer.Append("000000"); // 10
            writer.Append(CRO.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 11
            writer.Append(GrandeTotal.ValueToString().ToFixedLenghtString(18, Escrituracao._builder, Alignment.Left, "0")); // 12
            writer.Append(NumeroUsuario.ValueToString().ToFixedLenghtString(2, Escrituracao._builder, Alignment.Left, "0")); // 13
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            NumeroFabricacaoECF = linha.Substring(3, 20).Trim();
            MFAdicional = linha.Substring(23, 1).Trim();
            Modelo = linha.Substring(24, 20).Trim();
            CNPJ = linha.Substring(44, 14).Trim();
            InscricaoEstadual = linha.Substring(58, 14).Trim();
            RazaoSocial = linha.Substring(72, 40).Trim();
            Endereco = linha.Substring(112, 120).Trim();
            DataCadastro = linha.Substring(232, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
            // Me.HoraCadastro = Nothing
            CRO = linha.Substring(246, 6).Trim().ToNullableInteger();
            GrandeTotal = linha.Substring(252, 18).Trim().ToNullableDouble(2);
            NumeroUsuario = linha.Substring(270, 2).Trim().ToNullableInteger();
        }

        public string NumeroFabricacaoECF { get; set; } // campo 2
        public string MFAdicional { get; set; } // 3
        public string Modelo { get; set; } // 4
        public string CNPJ { get; set; } // 5
        public string InscricaoEstadual { get; set; } // 6
        public string RazaoSocial { get; set; } // 7
        public string Endereco { get; set; } // 8
        public DateTime? DataCadastro { get; set; } // 9
        public TimeSpan? HoraCadastro { get; set; } // 10 # IGNORAR #
        public int? CRO { get; set; } // 11 Contador Reinício de Operações
        public double? GrandeTotal { get; set; } // 12
        public int? NumeroUsuario { get; set; }
    }
}