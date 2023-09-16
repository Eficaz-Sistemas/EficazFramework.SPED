using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Abertura do Bloco 0
/// </summary>
/// <remarks>
/// Nível hierárquico - 1 <br/>
/// Ocorrência - um por arquivo.
/// </remarks>
/// <registrosped/>
/// <example>
/// ```csharp
/// string _versao = "017";
/// var reg0001 = new Registro0001(null, _versao)
/// {
///     IndicadorMovimento = Primitives.IndicadorMovimento.ComDados
/// };
/// ```
/// </example>
public class Registro0001 : Primitives.Registro
{
    public Registro0001() : base("0001")
    {
    }

    public Registro0001(string linha, string versao) : base(linha, versao)
    {
    }

    /// <inheritdoc/>
    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0001|"); // 1
        writer.Append(((int)IndicadorMovimento).ToString() + "|"); // 3
        return writer.ToString();
    }

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
    }

    /// <summary>
    /// Indicador de movimento: <br/>
    /// 0 - Bloco com Dados Informados <br/>
    /// 1 - Bloco som Dados Informados <br/>
    /// </summary>
    public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;

    // Registros Filhos

    /// <summary>
    /// Propriedade de navegação para registro filho.
    /// </summary>
    public Registro0005 Registro0005 { get; set; } = null;
    /// <summary>
    /// Propriedade de navegação para lista de registros filhos.
    /// </summary>
    public List<Registro0015> Registros0015 { get; set; } = new List<Registro0015>();
    /// <summary>
    /// Propriedade de navegação para registro filho.
    /// </summary>
    public Registro0100 Registro0100 { get; set; } = null;
    /// <summary>
    /// Propriedade de navegação para lista de registros filhos.
    /// </summary>
    public List<Registro0150> Registros0150 { get; set; } = new List<Registro0150>();
    /// <summary>
    /// Propriedade de navegação para lista de registros filhos.
    /// </summary>
    public List<Registro0190> Registros0190 { get; set; } = new List<Registro0190>();
    /// <summary>
    /// Propriedade de navegação para lista de registros filhos.
    /// </summary>
    public List<Registro0200> Registros0200 { get; set; } = new List<Registro0200>();
    /// <summary>
    /// Propriedade de navegação para lista de registros filhos.
    /// </summary>
    public List<Registro0300> Registros0300 { get; set; } = new List<Registro0300>();
    /// <summary>
    /// Propriedade de navegação para lista de registros filhos.
    /// </summary>
    public List<Registro0400> Registros0400 { get; set; } = new List<Registro0400>();
    /// <summary>
    /// Propriedade de navegação para lista de registros filhos.
    /// </summary>
    public List<Registro0450> Registros0450 { get; set; } = new List<Registro0450>();
    /// <summary>
    /// Propriedade de navegação para lista de registros filhos.
    /// </summary>
    public List<Registro0460> Registros0460 { get; set; } = new List<Registro0460>();
    /// <summary>
    /// Propriedade de navegação para lista de registros filhos.
    /// </summary>
    public List<Registro0500> Registros0500 { get; set; } = new List<Registro0500>();
    /// <summary>
    /// Propriedade de navegação para lista de registros filhos.
    /// </summary>
    public List<Registro0600> Registros0600 { get; set; } = new List<Registro0600>();
}
