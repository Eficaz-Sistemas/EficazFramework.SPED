using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.MFD_ECF
{

    /// <summary>
    /// Identificação do ECF
    /// </summary>
    /// <remarks></remarks>
    public class RegistroE01 : Primitives.Registro
    {
        public RegistroE01(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("E01"); // 1
            writer.Append(NumeroFabricacaoECF.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append(MFAdicional.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(TipoECF.ToFixedLenghtString(7, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(Marca.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 5
            writer.Append(Modelo.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 6
            writer.Append(VersaoSoftwareBasico.ToFixedLenghtString(10, Escrituracao._builder, Alignment.Right, " ")); // 7
            writer.Append(DataSoftwareBasico.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 8
            writer.Append("000000"); // 9
            writer.Append(NumeroSequencialECF.ValueToString().ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 10
            writer.Append(CNPJ.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 11
            writer.Append(ComandoGeracao.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Right, " ")); // 12
            writer.Append(CRZ_Inicial.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 13
            writer.Append(CRZ_Final.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 14
            writer.Append(DataInicial.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 15
            writer.Append(DataFInal.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 16
            writer.Append(VersaoDLL.ToFixedLenghtString(8, Escrituracao._builder, Alignment.Right, " ")); // 17
            writer.Append(Versao.ToFixedLenghtString(15, Escrituracao._builder, Alignment.Right, " ")); // 18
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            NumeroFabricacaoECF = linha.Substring(3, 20).Trim();
            MFAdicional = linha.Substring(23, 1).Trim();
            TipoECF = linha.Substring(24, 7).Trim();
            Marca = linha.Substring(31, 20).Trim();
            Modelo = linha.Substring(51, 20).Trim();
            VersaoSoftwareBasico = linha.Substring(71, 10).Trim();
            DataSoftwareBasico = linha.Substring(81, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
            // Me.HoraSoftwareBasico = Nothing
            NumeroSequencialECF = linha.Substring(95, 3).Trim().ToNullableInteger();
            CNPJ = linha.Substring(98, 14).Trim();
            ComandoGeracao = linha.Substring(112, 3).Trim();
            CRZ_Inicial = linha.Substring(115, 6).Trim().ToNullableInteger();
            CRZ_Final = linha.Substring(121, 6).Trim().ToNullableInteger();
            DataInicial = linha.Substring(127, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
            DataFInal = linha.Substring(135, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
            VersaoDLL = linha.Substring(143, 8).Trim();
        } // 

        public string NumeroFabricacaoECF { get; set; } // campo 2
        public string MFAdicional { get; set; } // 3
        public string TipoECF { get; set; } // 4
        public string Marca { get; set; } // 5
        public string Modelo { get; set; } // 6
        public string VersaoSoftwareBasico { get; set; } // 7
        public DateTime? DataSoftwareBasico { get; set; } // 8
        public TimeSpan? HoraSoftwareBasico { get; set; }
        public int? NumeroSequencialECF { get; set; } // 10
        public string CNPJ { get; set; } // 11
        public string ComandoGeracao { get; set; } // 12
        public int? CRZ_Inicial { get; set; } // 13 Contador de Redução Z Inicial
        public int? CRZ_Final { get; set; } // 14 Contador de Redução Z Final
        public DateTime? DataInicial { get; set; } // 15
        public DateTime? DataFInal { get; set; } // 16
        public string VersaoDLL { get; set; } // 17
        // ignorar versao ATO COTEPE pois já existe a property versão na classe-base e ela já foi vinculada na leitura do arquivo TXT.

    }
}