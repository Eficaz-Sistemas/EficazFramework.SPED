using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Abertura do Bloco 0
/// </summary>
/// <remarks></remarks>
public class Registro0001 : Primitives.Registro
{
    public Registro0001() : base("0001")
    {
    }

    public Registro0001(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0001|"); // 1
        writer.Append(((int)IndicadorMovimento).ToString() + "|"); // 3
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
    }

    public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;

    // Registros Filhos
    public Registro0005 Registro0005 { get; set; } = null;
    public List<Registro0015> Registros0015 { get; set; } = new List<Registro0015>();
    public Registro0100 Registro0100 { get; set; } = null;
    public List<Registro0150> Registros0150 { get; set; } = new List<Registro0150>();
    public List<Registro0190> Registros0190 { get; set; } = new List<Registro0190>();
    public List<Registro0200> Registros0200 { get; set; } = new List<Registro0200>();
    public List<Registro0300> Registros0300 { get; set; } = new List<Registro0300>();
    public List<Registro0400> Registros0400 { get; set; } = new List<Registro0400>();
    public List<Registro0450> Registros0450 { get; set; } = new List<Registro0450>();
    public List<Registro0460> Registros0460 { get; set; } = new List<Registro0460>();
    public List<Registro0500> Registros0500 { get; set; } = new List<Registro0500>();
    public List<Registro0600> Registros0600 { get; set; } = new List<Registro0600>();
}
