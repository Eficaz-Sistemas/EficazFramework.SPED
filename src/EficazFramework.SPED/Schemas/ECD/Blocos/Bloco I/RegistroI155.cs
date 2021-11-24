﻿using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Detalhe dos Saldos Periódicos
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI155 : Primitives.Registro
    {
        public RegistroI155() : base("I155")
        {
        }

        public RegistroI155(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoConta { get; set; } = null;
        public string CodigoCentroCusto { get; set; } = null;
        public double? VrSaldoInicialPeriodo { get; set; }
        public string IndicadorSituacaoSaldoInicial { get; set; } = null;
        public double? VrTotalDebitosPeriodo { get; set; }
        public double? VrTotalCreditosPeriodo { get; set; }
        public double? VrSaldoFinalPeriodo { get; set; }
        public string IndicadorSituacaoSaldoFinal { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I155|");
            writer.Append(CodigoConta + "|");
            writer.Append(CodigoCentroCusto + "|");
            writer.Append(string.Format("{0:F2}", VrSaldoInicialPeriodo) + "|");
            writer.Append(IndicadorSituacaoSaldoInicial + "|");
            writer.Append(string.Format("{0:F2}", VrTotalDebitosPeriodo) + "|");
            writer.Append(string.Format("{0:F2}", VrTotalCreditosPeriodo) + "|");
            writer.Append(string.Format("{0:F2}", VrSaldoFinalPeriodo) + "|");
            writer.Append(IndicadorSituacaoSaldoFinal + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoConta = data[2];
            CodigoCentroCusto = data[3];
            VrSaldoInicialPeriodo = data[4].ToNullableDouble();
            IndicadorSituacaoSaldoInicial = data[5];
            VrTotalDebitosPeriodo = data[6].ToNullableDouble();
            VrTotalCreditosPeriodo = data[7].ToNullableDouble();
            VrSaldoFinalPeriodo = data[8].ToNullableDouble();
            IndicadorSituacaoSaldoFinal = data[9];
        }
    }
}