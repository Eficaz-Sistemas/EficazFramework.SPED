using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador;

/// <summary>
/// DAS (Documento de Arrecadação do Simples Nacional) emitido pelo PGDAS-D (GERARDAS12, GERARDASCOBRANCA17,
/// GERARDASPROCESSO18, GERARDASAVULSO19) ou pelo PGMEI (GERARDASPDF21, GERARDASCODBARRA22).
/// </summary>
public sealed class Das
{
    /// <summary>PDF do DAS no formato texto Base64 (ausente no DAS por código de barras).</summary>
    [JsonPropertyName("pdf")]
    public string? Pdf { get; set; }

    /// <summary>Número do CNPJ, sem formatação.</summary>
    [JsonPropertyName("cnpjCompleto")]
    public string? CnpjCompleto { get; set; }

    /// <summary>Razão social do contribuinte (presente nos exemplos de retorno do PGMEI).</summary>
    [JsonPropertyName("razaoSocial")]
    public string? RazaoSocial { get; set; }

    /// <summary>
    /// Detalhamento do DAS. A documentação diverge entre objeto e lista e entre as chaves <c>detalhamento</c>
    /// (tabelas de campos e PGMEI) e <c>detalhamentoDas</c> (exemplos do PGDAS-D); todas as formas são aceitas na leitura.
    /// </summary>
    [JsonPropertyName("detalhamento")]
    [JsonConverter(typeof(ListaOuObjetoJsonConverter<DetalhamentoDas>))]
    public List<DetalhamentoDas>? Detalhamento { get; set; }

    /// <summary>Leitura alternativa da chave <c>detalhamentoDas</c>, usada nos exemplos de retorno do PGDAS-D.</summary>
    [JsonInclude]
    [JsonPropertyName("detalhamentoDas")]
    [JsonConverter(typeof(ListaOuObjetoJsonConverter<DetalhamentoDas>))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    private List<DetalhamentoDas>? DetalhamentoAlternativo
    {
        get => null;
        set => Detalhamento ??= value;
    }
}

/// <summary>
/// Detalhamento de um DAS (ou do DARF da MAED, no retorno da transmissão da declaração do PGDAS-D).
/// </summary>
public sealed class DetalhamentoDas
{
    /// <summary>
    /// Período de apuração no formato AAAAMM. No DAS com mais de um período é retornado o texto "Diversos".
    /// </summary>
    [JsonPropertyName("periodoApuracao")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? PeriodoApuracao { get; set; }

    /// <summary>Número do documento gerado.</summary>
    [JsonPropertyName("numeroDocumento")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? NumeroDocumento { get; set; }

    /// <summary>Data de vencimento no formato AAAAMMDD.</summary>
    [JsonPropertyName("dataVencimento")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? DataVencimento { get; set; }

    /// <summary>Data limite para acolhimento no formato AAAAMMDD.</summary>
    [JsonPropertyName("dataLimiteAcolhimento")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? DataLimiteAcolhimento { get; set; }

    /// <summary>Discriminação dos valores.</summary>
    [JsonPropertyName("valores")]
    public ValoresDas? Valores { get; set; }

    /// <summary>
    /// Lista de códigos de barras gerados; cada item representa um conjunto de números do código de barras
    /// (somente PGMEI GERARDASCODBARRA22).
    /// </summary>
    [JsonPropertyName("codigoDeBarras")]
    public List<string>? CodigoDeBarras { get; set; }

    /// <summary>Observação 1.</summary>
    [JsonPropertyName("observacao1")]
    public string? Observacao1 { get; set; }

    /// <summary>Observação 2.</summary>
    [JsonPropertyName("observacao2")]
    public string? Observacao2 { get; set; }

    /// <summary>Observação 3.</summary>
    [JsonPropertyName("observacao3")]
    public string? Observacao3 { get; set; }

    /// <summary>Composição do DAS gerado (nula no DARF da MAED).</summary>
    [JsonPropertyName("composicao")]
    public List<ComposicaoDas>? Composicao { get; set; }
}

/// <summary>
/// Discriminação dos valores de um DAS ou de um tributo da sua composição.
/// </summary>
public sealed class ValoresDas
{
    /// <summary>Valor do principal.</summary>
    [JsonPropertyName("principal")]
    public decimal? Principal { get; set; }

    /// <summary>Valor da multa.</summary>
    [JsonPropertyName("multa")]
    public decimal? Multa { get; set; }

    /// <summary>Valor dos juros.</summary>
    [JsonPropertyName("juros")]
    public decimal? Juros { get; set; }

    /// <summary>Valor total.</summary>
    [JsonPropertyName("total")]
    public decimal? Total { get; set; }
}

/// <summary>
/// Item da composição de um DAS (tributo).
/// </summary>
public sealed class ComposicaoDas
{
    /// <summary>
    /// Período de apuração do tributo no formato AAAAMM (a documentação o descreve como texto, mas há exemplos
    /// com número; ambos são aceitos).
    /// </summary>
    [JsonPropertyName("periodoApuracao")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? PeriodoApuracao { get; set; }

    /// <summary>Código do tributo.</summary>
    [JsonPropertyName("codigo")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? Codigo { get; set; }

    /// <summary>Descrição do nome/destino do tributo.</summary>
    [JsonPropertyName("denominacao")]
    public string? Denominacao { get; set; }

    /// <summary>Discriminação dos valores do tributo.</summary>
    [JsonPropertyName("valores")]
    public ValoresDas? Valores { get; set; }
}
