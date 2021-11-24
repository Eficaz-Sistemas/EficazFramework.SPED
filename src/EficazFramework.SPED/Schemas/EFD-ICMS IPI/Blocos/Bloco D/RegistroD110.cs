using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO D110: ITEMS DO DOCUMENTO FISCAL
    /// </summary>
    /// <remarks></remarks>
    public class RegistroD110 : Primitives.Registro
    {
        public RegistroD110() : base("D110")
        {
        }

        public RegistroD110(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|D110|"); // 1
            writer.Append(string.Format("{0:##0}", NumeroSequencialItem) + "|"); // 2
            writer.Append(CodigoProduto + "|"); // 3
            writer.Append(string.Format("{0:0.##}", ValorServico) + "|"); // 4
            writer.Append(string.Format("{0:0.##}", OutrosValores) + "|"); // 5
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroSequencialItem = data[2].ToNullableInteger();
            CodigoProduto = data[3];
            ValorServico = data[4].ToNullableDouble();
            OutrosValores = data[5].ToNullableDouble();
        }

        public int? NumeroSequencialItem { get; set; } // 2
        public string CodigoProduto { get; set; } // 3
        public double? ValorServico { get; set; } // 4
        public double? OutrosValores { get; set; } // 5
    }
}