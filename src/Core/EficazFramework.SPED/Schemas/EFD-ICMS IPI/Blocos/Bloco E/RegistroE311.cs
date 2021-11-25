using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Ajustes da Apuração do ICMS Difal
/// </summary>
/// <remarks></remarks>
public class RegistroE311 : Primitives.Registro
{
    public RegistroE311() : base("E311")
    {
    }

    public RegistroE311(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|E311|"); // 01
        writer.Append(CodigoAjuste + "|"); // 02
        writer.Append(DescricaoComplementar + "|"); // 03
        writer.Append(string.Format("{0:0.##}", ValorAjuste) + "|"); // 04
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoAjuste = data[2];
        DescricaoComplementar = data[3];
        ValorAjuste = data[4].ToNullableDouble();
    }

    public string CodigoAjuste { get; set; } = null; // 02
    public string DescricaoComplementar { get; set; } = null; // 03
    public double? ValorAjuste { get; set; } // 04

    // Navigation Properties
    public List<RegistroE312> RegistrosE312 { get; set; } = new List<RegistroE312>();
    public List<RegistroE313> RegistrosE313 { get; set; } = new List<RegistroE313>();
}
