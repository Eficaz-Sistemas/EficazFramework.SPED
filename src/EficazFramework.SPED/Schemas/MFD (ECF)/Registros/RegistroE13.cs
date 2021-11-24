using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.MFD_ECF
{

    /// <summary>
    /// Detalhe da Redução Z - Totalizadores Parciais
    /// </summary>
    /// <remarks></remarks>
    public class RegistroE13 : Primitives.Registro
    {
        public RegistroE13(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("E13"); // 1
            writer.Append(NumeroFabricacaoECF.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append(MFAdicional.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 3
            writer.Append(Modelo.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(NumeroUsuario.ValueToString().ToFixedLenghtString(2, Escrituracao._builder, Alignment.Left, "0")); // 5
            writer.Append(CRZ.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 6
            writer.Append(TotalizadorParcial.ToFixedLenghtString(7, Escrituracao._builder, Alignment.Right, " ")); // 7
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
            TotalizadorParcial = linha.Substring(52, 7).Trim();
            ValorAcumulado = linha.Substring(59, 13).Trim().ToNullableDouble(2);
        }

        public string NumeroFabricacaoECF { get; set; } // campo 2
        public string MFAdicional { get; set; } // 3
        public string Modelo { get; set; } // 4
        public int? NumeroUsuario { get; set; } // 5
        public int? CRZ { get; set; } // 6 Contador de Reduçao Z
        public string TotalizadorParcial { get; set; } // 7
        public double? ValorAcumulado { get; set; } // 8 Valor total desta tributação para a Redução Z
    }
}