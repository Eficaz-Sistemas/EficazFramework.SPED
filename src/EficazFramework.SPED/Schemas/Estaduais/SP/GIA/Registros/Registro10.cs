using System.Collections.Generic;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.SP.GIA
{

    /// <summary>
    /// Detalhes CFOP's
    /// </summary>
    public class Registro10 : Primitives.Registro
    {
        public Registro10() : base("10")
        {
        }

        public Registro10(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("10"); // 1 Código Registro
            writer.Append(CFOP.ToFixedLenghtString(6, Escrituracao._builder, Alignment.Right, "0")); // 2
            writer.Append(ValorContabil.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 3
            writer.Append(BaseCalculo.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 4
            writer.Append(Imposto.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 5
            writer.Append(IsentasNaoTributadas.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 6
            writer.Append(Outras.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 7
            writer.Append(ImpostoRetidoST.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 8
            writer.Append(ImpostoRetidoSubstitutoST.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 9
            writer.Append(ImpostoRetidoSubstituido.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 10
            writer.Append(OutrosImpostos.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 11
            writer.Append(Registros14.Count.ToString().PadLeft(4, '0')); // 12
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CFOP = linha.Substring(2, 4).Trim();
            ValorContabil = linha.Substring(8, 15).ToNullableDouble(2);
            BaseCalculo = linha.Substring(23, 15).ToNullableDouble(2);
            Imposto = linha.Substring(38, 15).ToNullableDouble(2);
            IsentasNaoTributadas = linha.Substring(53, 15).ToNullableDouble(2);
            Outras = linha.Substring(68, 15).ToNullableDouble(2);
            ImpostoRetidoST = linha.Substring(83, 15).ToNullableDouble(2);
            ImpostoRetidoSubstitutoST = linha.Substring(98, 15).ToNullableDouble(2);
            ImpostoRetidoSubstituido = linha.Substring(113, 15).ToNullableDouble(2);
            OutrosImpostos = linha.Substring(128, 15).ToNullableDouble(2);
        }

        public string CFOP { get; set; } = null;
        public double? ValorContabil { get; set; } = 0;
        public double? BaseCalculo { get; set; } = 0;
        public double? Imposto { get; set; } = 0;
        public double? IsentasNaoTributadas { get; set; } = 0;
        public double? Outras { get; set; } = 0;
        public double? ImpostoRetidoST { get; set; } = 0;
        public double? ImpostoRetidoSubstitutoST { get; set; } = 0;
        public double? ImpostoRetidoSubstituido { get; set; } = 0;
        public double? OutrosImpostos { get; set; } = 0;
        public List<Registro14> Registros14 { get; set; } = new List<Registro14>();
    }
}