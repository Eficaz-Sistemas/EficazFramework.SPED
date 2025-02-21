using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Contribuição Previdenciária Sobre a Receita Bruta
/// </summary>
/// <remarks></remarks>

public class RegistroP100 : Primitives.Registro
{
    public RegistroP100() : base("P100")
    {
    }

    public RegistroP100(string linha, string versao) : base(linha, versao)
    {
    }

    // campos'
    public DateTime? DataInicialApuracao { get; set; }
    public DateTime? DataFinalApuracao { get; set; }
    public double? VrRecBrutaTotalPeriodo { get; set; }
    public string CodigoAtividadeSujIncidencia { get; set; } = null;
    public double? VrRecBrutaAtividade { get; set; }
    public double? VrExclusoesRecBruta { get; set; }
    public double? VrBCContribPrev { get; set; }
    public double? AliqContribPrev { get; set; }
    public double? VrContribPrev { get; set; }
    public string CodigoContaContabil { get; set; } = null;
    public string InfoComplementar { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|P100|");
        writer.Append(DataInicialApuracao + "|");
        writer.Append(DataFinalApuracao + "|");
        writer.Append(VrRecBrutaTotalPeriodo + "|");
        writer.Append(CodigoAtividadeSujIncidencia + "|");
        writer.Append(VrRecBrutaAtividade + "|");
        writer.Append(VrExclusoesRecBruta + "|");
        writer.Append(VrBCContribPrev + "|");
        writer.Append(AliqContribPrev + "|");
        writer.Append(VrContribPrev + "|");
        writer.Append(CodigoContaContabil + "|");
        writer.Append(InfoComplementar + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DataInicialApuracao = data[2].ToDate();
        DataFinalApuracao = data[3].ToDate();
        VrRecBrutaTotalPeriodo = data[4].ToNullableDouble();
        CodigoAtividadeSujIncidencia = data[5];
        VrRecBrutaAtividade = data[6].ToNullableDouble();
        VrExclusoesRecBruta = data[7].ToNullableDouble();
        VrBCContribPrev = data[8].ToNullableDouble();
        AliqContribPrev = data[9].ToNullableDouble();
        VrContribPrev = data[10].ToNullableDouble();
        CodigoContaContabil = data[11];
        InfoComplementar = data[12];
    }
}
