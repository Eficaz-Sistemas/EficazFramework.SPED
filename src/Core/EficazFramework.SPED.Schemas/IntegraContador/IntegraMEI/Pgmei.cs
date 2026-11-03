using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraMEI;

/// <summary>
/// Entrada dos serviços GERARDASPDF21 e GERARDASCODBARRA22 (PGMEI): geração do DAS do MEI.
/// </summary>
public sealed class GerarDas
{
    /// <summary>Período de apuração no formato AAAAMM.</summary>
    [JsonPropertyName("periodoApuracao")]
    public string PeriodoApuracao { get; set; } = string.Empty;

    /// <summary>Data de consolidação no formato AAAAMMDD (opcional).</summary>
    [JsonPropertyName("dataConsolidacao")]
    public string? DataConsolidacao { get; set; }
}

/// <summary>
/// Entrada do serviço ATUBENEFICIO23 (PGMEI): registro de benefício para apurações do PGMEI.
/// </summary>
public sealed class AtualizarBeneficio
{
    /// <summary>Ano-calendário no formato AAAA.</summary>
    [JsonPropertyName("anoCalendario")]
    public int AnoCalendario { get; set; }

    /// <summary>Informações sobre o benefício, por período de apuração.</summary>
    [JsonPropertyName("infoBeneficio")]
    public List<InfoBeneficio> InfoBeneficio { get; set; } = [];
}

/// <summary>
/// Benefício de um período de apuração (ATUBENEFICIO23).
/// </summary>
public sealed class InfoBeneficio
{
    /// <summary>Período de apuração no formato AAAAMM.</summary>
    [JsonPropertyName("periodoApuracao")]
    public string PeriodoApuracao { get; set; } = string.Empty;

    /// <summary>Indica se houve benefício.</summary>
    [JsonPropertyName("indicadorBeneficio")]
    public bool IndicadorBeneficio { get; set; }
}

/// <summary>
/// Retorno do serviço ATUBENEFICIO23 (PGMEI): benefício registrado por período de apuração.
/// </summary>
public sealed class RetornoAtualizarBeneficio
{
    /// <summary>Período de apuração original.</summary>
    [JsonPropertyName("paOriginal")]
    public string? PaOriginal { get; set; }

    /// <summary>Indica se há benefício no período.</summary>
    [JsonPropertyName("indicadorBeneficio")]
    public bool? IndicadorBeneficio { get; set; }

    /// <summary>Período de apuração que agrupa os períodos para emissão do DAS, no formato AAAAMM.</summary>
    [JsonPropertyName("paAgrupado")]
    public string? PaAgrupado { get; set; }
}

/// <summary>
/// Entrada do serviço DIVIDAATIVA24 (PGMEI): consulta de débitos em dívida ativa.
/// </summary>
public sealed class ConsultarDividaAtiva
{
    /// <summary>Ano-calendário no formato AAAA (texto, conforme a documentação).</summary>
    [JsonPropertyName("anoCalendario")]
    public string AnoCalendario { get; set; } = string.Empty;
}

/// <summary>
/// Retorno do serviço DIVIDAATIVA24 (PGMEI): período com inscrição em dívida ativa.
/// </summary>
public sealed class DebitoDividaAtiva
{
    /// <summary>Período de apuração no formato AAAAMM.</summary>
    [JsonPropertyName("periodoApuracao")]
    public string? PeriodoApuracao { get; set; }

    /// <summary>Nome do tributo com débito em dívida ativa (ex.: "INSS").</summary>
    [JsonPropertyName("tributo")]
    public string? Tributo { get; set; }

    /// <summary>Valor do tributo.</summary>
    [JsonPropertyName("valor")]
    public decimal? Valor { get; set; }

    /// <summary>Nome do ente federado onde há o débito (ex.: "União").</summary>
    [JsonPropertyName("enteFederado")]
    public string? EnteFederado { get; set; }

    /// <summary>Situação da dívida do tributo (ex.: "Enviado à PFN").</summary>
    [JsonPropertyName("situacaoDebito")]
    public string? SituacaoDebito { get; set; }
}
