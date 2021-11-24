using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.SP.GIA
{

    /// <summary>
    /// IE's
    /// </summary>
    public class Registro25 : Primitives.Registro
    {
        public Registro25() : base("25")
        {
        }

        public Registro25(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("25"); // 1 Código Registro
            writer.Append(InscricaoEstadual.ToFixedLenghtString(12, Escrituracao._builder, Alignment.Right, " ")); // 2
            writer.Append(Valor.ValueToString().ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 3
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            InscricaoEstadual = linha.Substring(2, 12).Trim();
            Valor = linha.Substring(14, 15).ToNullableDouble(2);
        }

        public string InscricaoEstadual { get; set; } = null;
        public double? Valor { get; set; } = 0;
    }
}