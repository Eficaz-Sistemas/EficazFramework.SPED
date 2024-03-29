﻿using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Contribuição de Cofins diferida em períodos anteriores - valores a pagar no período
/// </summary>
/// <remarks></remarks>

public class RegistroM700 : Primitives.Registro
{
    public RegistroM700() : base("M700")
    {
    }

    public RegistroM700(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoContribDiferidaPerAnter { get; set; } = null;
    public double? VrContribApuradaDiferidaPerAnter { get; set; }
    public NaturezaCreditoDiferido NatCreditoDiferidoVincRecMerInterno { get; set; } = NaturezaCreditoDiferido.CreditoAliquotaBasica;
    public double? VrCreditoDescontarVincContribDiferida { get; set; }
    public double? VrContribRecolherDiferidaPerAnteriores { get; set; }
    public DateTime? PeriodoApuracaoContribCredDiferidos { get; set; }
    public DateTime? DataRecebReceitaDiferimento { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|M700|");
        writer.Append(CodigoContribDiferidaPerAnter + "|");
        writer.Append(VrContribApuradaDiferidaPerAnter + "|");
        writer.Append(((int)NatCreditoDiferidoVincRecMerInterno).ToString() + "|");
        writer.Append(VrCreditoDescontarVincContribDiferida + "|");
        writer.Append(VrContribRecolherDiferidaPerAnteriores + "|");
        writer.Append(PeriodoApuracaoContribCredDiferidos + "|");
        writer.Append(DataRecebReceitaDiferimento + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoContribDiferidaPerAnter = data[2];
        VrContribApuradaDiferidaPerAnter = data[3].ToNullableDouble();
        NatCreditoDiferidoVincRecMerInterno = (NaturezaCreditoDiferido)data[4].ToEnum<NaturezaCreditoDiferido>(NaturezaCreditoDiferido.CreditoAliquotaBasica);
        VrCreditoDescontarVincContribDiferida = data[5].ToNullableDouble();
        VrContribRecolherDiferidaPerAnteriores = data[6].ToNullableDouble();
        PeriodoApuracaoContribCredDiferidos = data[7].ToDate();
        DataRecebReceitaDiferimento = data[8].ToDate();
    }
}
