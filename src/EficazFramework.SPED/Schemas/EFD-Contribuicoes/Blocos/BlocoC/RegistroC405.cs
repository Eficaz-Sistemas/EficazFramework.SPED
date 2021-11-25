using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Redução Z
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC405 : Primitives.Registro
    {
        public RegistroC405() : base("C405")
        {
        }

        public RegistroC405(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public DateTime? DataMovimentoReducaoZ { get; set; }
        public int? PosicaoContadorReinicioOperacao { get; set; }
        public int? PosicaoContadorReducaoZ { get; set; }
        public int? NumeroContadorOrdemOperacaoUltimoDocEmitDia { get; set; }
        public double? ValorGrandeTotalFinal { get; set; }
        public double? ValorVendaBruta { get; set; }
        public List<RegistroC481> RegistrosC481 { get; set; } = new List<RegistroC481>();
        public List<RegistroC485> RegistrosC485 { get; set; } = new List<RegistroC485>();

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C405|");
            writer.Append(DataMovimentoReducaoZ + "|");
            writer.Append(PosicaoContadorReinicioOperacao + "|");
            writer.Append(PosicaoContadorReducaoZ + "|");
            writer.Append(NumeroContadorOrdemOperacaoUltimoDocEmitDia + "|");
            writer.Append(ValorGrandeTotalFinal + "|");
            writer.Append(ValorVendaBruta + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataMovimentoReducaoZ = data[2].ToDate();
            PosicaoContadorReinicioOperacao = data[3].ToNullableInteger();
            PosicaoContadorReducaoZ = data[4].ToNullableInteger();
            NumeroContadorOrdemOperacaoUltimoDocEmitDia = data[5].ToNullableInteger();
            ValorGrandeTotalFinal = data[6].ToNullableDouble();
            ValorVendaBruta = data[7].ToNullableDouble();
        }
    }
}