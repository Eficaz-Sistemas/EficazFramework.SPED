using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.Sintegra
{

    /// <summary>
    /// 60 Diário: Registro de mercadoria/produto constante em PDV / ECF totalizado por dia.
    /// </summary>
    /// <remarks></remarks>
    public class Registro60D : Primitives.Registro
    {
        public Registro60D(string linha, string versao) : base(linha, versao)
        {
        }

        public Registro60D() : base("60D")
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("60D"); // 1 & 2
            writer.Append(DataEmissao.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3
            writer.Append(NumeroSerieFabEquip.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(CodigoProduto.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 5
            writer.Append(Quantidade.ValueToString(3).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 6
            writer.Append(ValorLiquido.ValueToString(2).ToFixedLenghtString(16, Escrituracao._builder, Alignment.Left, "0")); // 7
            writer.Append(BaseCalculo.ValueToString(2).ToFixedLenghtString(16, Escrituracao._builder, Alignment.Left, "0")); // 8
            writer.Append(SituacaoTributariaAliquota.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Right, " ")); // 9
            writer.Append(ICMS.ValueToString(2).ToFixedLenghtString(13, Escrituracao._builder, Alignment.Left, "0")); // 10
            writer.Append(Brancos.ToFixedLenghtString(19, Escrituracao._builder, Alignment.Right, " ")); // 11
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            DataEmissao = linha.Substring(3, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
            NumeroSerieFabEquip = linha.Substring(11, 20).Trim();
            CodigoProduto = linha.Substring(31, 14).Trim();
            Quantidade = (decimal?)linha.Substring(45, 13).ToNullableDouble(3);
            ValorLiquido = linha.Substring(58, 16).ToNullableDouble(2);
            BaseCalculo = linha.Substring(74, 16).ToNullableDouble(2);
            SituacaoTributariaAliquota = linha.Substring(90, 4).Trim();
            ICMS = linha.Substring(94, 13).Trim().ToNullableDouble(2);
            Brancos = linha.Substring(107, 19).Trim();
        }

        public DateTime? DataEmissao { get; set; }
        public string NumeroSerieFabEquip { get; set; }
        public string CodigoProduto { get; set; }
        public decimal? Quantidade { get; set; }
        public double? ValorLiquido { get; set; }
        public double? BaseCalculo { get; set; }
        public string SituacaoTributariaAliquota { get; set; }
        public double? ICMS { get; set; }
        public string Brancos { get; set; }
    }
}