using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Transferência de Saldos de Plano de Contas Anterior
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI157 : Primitives.Registro
    {
        public RegistroI157() : base("I157")
        {
        }

        public RegistroI157(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodConta { get; set; } = null;
        public string CodCentroCusto { get; set; } = null;
        public double? VrSaldoInicialPeriodo { get; set; }
        public string IndicadorSituacaoSaldoInicial { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I157|");
            writer.Append(CodConta + "|");
            writer.Append(CodCentroCusto + "|");
            writer.Append(VrSaldoInicialPeriodo + "|");
            writer.Append(IndicadorSituacaoSaldoInicial + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodConta = data[2];
            CodCentroCusto = data[3];
            VrSaldoInicialPeriodo = data[4].ToNullableDouble();
            IndicadorSituacaoSaldoInicial = data[5];
        }
    }
}