using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Consolidação da contribuição previdenciária sobre a receita bruta
/// </summary>
/// <remarks></remarks>

public class RegistroP200 : Primitives.Registro
{
    public RegistroP200() : base("P200")
    {
    }

    public RegistroP200(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public DateTime? PeriodoRefEscrit { get; set; }
    public double? VrTotalApurContribPrevRecBruta { get; set; }
    public double? VrTotalAjusteReducao { get; set; }
    public double? VrTotalAjusteAcrescimo { get; set; }
    public double? VrTotalContribPrevRecolher { get; set; }
    public string CodigoReceitaContribPrevDCTF { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|P200|");
        writer.Append(PeriodoRefEscrit + "|");
        writer.Append(VrTotalApurContribPrevRecBruta + "|");
        writer.Append(VrTotalAjusteReducao + "|");
        writer.Append(VrTotalAjusteAcrescimo + "|");
        writer.Append(VrTotalContribPrevRecolher + "|");
        writer.Append(CodigoReceitaContribPrevDCTF + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        PeriodoRefEscrit = data[2].ToDate();
        VrTotalApurContribPrevRecBruta = data[3].ToNullableDouble();
        VrTotalAjusteReducao = data[4].ToNullableDouble();
        VrTotalAjusteAcrescimo = data[5].ToNullableDouble();
        VrTotalContribPrevRecolher = data[6].ToNullableDouble();
        CodigoReceitaContribPrevDCTF = data[7];
    }
}
