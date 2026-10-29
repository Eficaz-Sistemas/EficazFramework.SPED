using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraSN;

/// <summary>
/// Entrada do serviço REGIMEAPURACAO / EFETUAROPCAOREGIME101: opção anual pelo regime de apuração de receitas.
/// </summary>
public sealed class EfetuarOpcaoRegime
{
    /// <summary>Ano da opção.</summary>
    [JsonPropertyName("anoOpcao")]
    public int AnoOpcao { get; set; }

    /// <summary>Tipo do regime: 0 - Competência; 1 - Caixa.</summary>
    [JsonPropertyName("tipoRegime")]
    public int TipoRegime { get; set; }

    /// <summary>Descritivo do regime ("COMPETENCIA" ou "CAIXA"), que reforça a escolha de <see cref="TipoRegime"/>.</summary>
    [JsonPropertyName("descritivoRegime")]
    public string DescritivoRegime { get; set; } = string.Empty;

    /// <summary>Deve ser enviado como <c>true</c> para que a opção seja efetivada.</summary>
    [JsonPropertyName("deAcordoResolucao")]
    public bool DeAcordoResolucao { get; set; }
}

/// <summary>
/// Entrada do serviço REGIMEAPURACAO / CONSULTAROPCAOREGIME103.
/// </summary>
public sealed class ConsultarOpcaoRegime
{
    /// <summary>Ano-calendário.</summary>
    [JsonPropertyName("anoCalendario")]
    public int AnoCalendario { get; set; }
}

/// <summary>
/// Entrada do serviço REGIMEAPURACAO / CONSULTARRESOLUCAO104.
/// </summary>
public sealed class ConsultarResolucaoRegime
{
    /// <summary>Ano-calendário.</summary>
    [JsonPropertyName("anoCalendario")]
    public int AnoCalendario { get; set; }
}

/// <summary>
/// Item do retorno do serviço REGIMEAPURACAO / CONSULTARANOSCALENDARIOS102: opção efetivada em um ano-calendário.
/// </summary>
public sealed class AnoCalendarioRegime
{
    /// <summary>Ano-calendário.</summary>
    [JsonPropertyName("anoCalendario")]
    public int AnoCalendario { get; set; }

    /// <summary>Regime efetivado: "COMPETENCIA" ou "CAIXA".</summary>
    [JsonPropertyName("regimeApurado")]
    public string? RegimeApurado { get; set; }
}

/// <summary>
/// Retorno dos serviços REGIMEAPURACAO / EFETUAROPCAOREGIME101 e CONSULTAROPCAOREGIME103.
/// </summary>
public sealed class OpcaoRegime
{
    /// <summary>CNPJ da matriz.</summary>
    [JsonPropertyName("cnpjMatriz")]
    public string? CnpjMatriz { get; set; }

    /// <summary>Ano-calendário solicitado.</summary>
    [JsonPropertyName("anoCalendario")]
    public int AnoCalendario { get; set; }

    /// <summary>Regime escolhido: "COMPETENCIA" ou "CAIXA".</summary>
    [JsonPropertyName("regimeEscolhido")]
    public string? RegimeEscolhido { get; set; }

    /// <summary>Data e horário da opção no formato AAAAMMDDHHMMSS.</summary>
    [JsonPropertyName("dataHoraOpcao")]
    public long? DataHoraOpcao { get; set; }

    /// <summary>Demonstrativo da opção pelo regime (PDF em Base64).</summary>
    [JsonPropertyName("demonstrativoPdf")]
    public string? DemonstrativoPdf { get; set; }

    /// <summary>Texto da resolução (no caso de regime de caixa).</summary>
    [JsonPropertyName("textoResolucao")]
    public string? TextoResolucao { get; set; }
}

/// <summary>
/// Retorno do serviço REGIMEAPURACAO / CONSULTARRESOLUCAO104.
/// </summary>
public sealed class ResolucaoRegime
{
    /// <summary>Texto fixo da resolução para o regime de caixa.</summary>
    [JsonPropertyName("textoResolucao")]
    public string? TextoResolucao { get; set; }
}
