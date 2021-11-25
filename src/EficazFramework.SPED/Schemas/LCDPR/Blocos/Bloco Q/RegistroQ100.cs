using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.LCDPR
{

    /// <summary>
    /// Demonstração da Atividade Rural
    /// </summary>
    /// <remarks></remarks>
    public class RegistroQ100 : Primitives.Registro
    {
        public RegistroQ100() : base("Q100")
        {
        }

        public RegistroQ100(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("Q100|"); // 1
            writer.Append(DataMov.ToSpedString() + "|");  // 2
            writer.Append(CodImovel + "|");  // 3
            writer.Append(CodigoContaBanco + "|"); // 4
            writer.Append(NumeroDoc + "|"); // 5
            writer.Append((int)TipoDocumento + "|"); // 6
            writer.Append(Historico + "|"); // 7
            writer.Append(TerceiroID + "|"); // 8
            writer.Append((int)TipoLancamento + "|"); // 9
            writer.Append(ValorEntrada.ValueToString(2) + "|"); // 10
            writer.Append(ValorSaida.ValueToString(2) + "|"); // 11
            writer.Append(SaldoFinal.ValueToString(2) + "|"); // 12
            writer.Append(SaldoFinal_Natureza); // 13
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }

        public DateTime? DataMov { get; set; } = default;
        public int? CodImovel { get; set; } = default;
        public string CodigoContaBanco { get; set; } = null;
        public string NumeroDoc { get; set; } = "BR";
        public TipoDocumento TipoDocumento { get; set; } = TipoDocumento.NF;
        public string Historico { get; set; } = null;
        /// <summary>
        /// CPF ou CNPJ do Terceiro. Caso TipoDocumento = FolhaPagto utilizar o CPF do próprio declarante.
        /// </summary>
        public string TerceiroID { get; set; } = null;
        public TipoLancamento TipoLancamento { get; set; } = TipoLancamento.Receita;
        public double? ValorEntrada { get; set; } = default;
        public double? ValorSaida { get; set; } = default;
        public double? SaldoFinal { get; set; } = default;
        /// <summary>
        /// [N/P]
        /// </summary>
        public string SaldoFinal_Natureza { get; set; } = null;
    }
}