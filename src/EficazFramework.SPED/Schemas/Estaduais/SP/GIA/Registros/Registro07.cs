using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.SP.GIA
{

    /// <summary>
    /// Detalhes Pagamentos
    /// </summary>
    public class Registro07 : Primitives.Registro
    {
        public Registro07() : base("07")
        {
        }

        public Registro07(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("07"); // 1 Código Registro
            writer.Append(Convert.ToInt32((int)Operacao)); // 2
            writer.Append(Imposto.ValueToString().ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 3
            writer.Append(DataVencimento.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 4
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            Operacao = (Operacao)linha.Substring(2, 1).Trim().ToEnum<Operacao>(Operacao.Propria);
            Imposto = linha.Substring(3, 15).ToNullableDouble(2);
            DataVencimento = linha.Substring(18, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
        }

        public Operacao Operacao { get; set; } = Operacao.Propria;
        public double? Imposto { get; set; } = 0;
        public DateTime? DataVencimento { get; set; } = default;
    }
}