using System.Text.Json;
using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraMEI;

/// <summary>
/// DAS (Documento de Arrecadação do Simples Nacional) emitido pelo PGMEI (GERARDASPDF21 / GERARDASCODBARRA22).
/// </summary>
public sealed class Das
{
    /// <summary>PDF do DAS no formato texto Base64 (somente GERARDASPDF21).</summary>
    [JsonPropertyName("pdf")]
    public string? Pdf { get; set; }

    /// <summary>Número do CNPJ sem formatação.</summary>
    [JsonPropertyName("cnpjCompleto")]
    public string? CnpjCompleto { get; set; }

    /// <summary>Razão social do contribuinte (presente nos exemplos de retorno da documentação).</summary>
    [JsonPropertyName("razaoSocial")]
    public string? RazaoSocial { get; set; }

    /// <summary>
    /// Detalhamento do DAS. A tabela da documentação o descreve como objeto, mas os exemplos de retorno trazem uma
    /// lista; ambos os formatos são aceitos.
    /// </summary>
    [JsonPropertyName("detalhamento")]
    [JsonConverter(typeof(ListaOuObjetoJsonConverter<DetalhamentoDas>))]
    public List<DetalhamentoDas>? Detalhamento { get; set; }
}

/// <summary>
/// Detalhamento do DAS emitido pelo PGMEI.
/// </summary>
public sealed class DetalhamentoDas
{
    /// <summary>Período de apuração no formato AAAAMM ou "Diversos" no caso de mais de um período acumulado.</summary>
    [JsonPropertyName("periodoApuracao")]
    public string? PeriodoApuracao { get; set; }

    /// <summary>Número do documento gerado.</summary>
    [JsonPropertyName("numeroDocumento")]
    public string? NumeroDocumento { get; set; }

    /// <summary>Data de vencimento no formato AAAAMMDD.</summary>
    [JsonPropertyName("dataVencimento")]
    public string? DataVencimento { get; set; }

    /// <summary>Data limite para acolhimento no formato AAAAMMDD.</summary>
    [JsonPropertyName("dataLimiteAcolhimento")]
    public string? DataLimiteAcolhimento { get; set; }

    /// <summary>Discriminação dos valores.</summary>
    [JsonPropertyName("valores")]
    public ValoresDas? Valores { get; set; }

    /// <summary>
    /// Lista de códigos de barras gerados; cada item representa um conjunto de números do código de barras
    /// (somente GERARDASCODBARRA22).
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

    /// <summary>Composição do DAS gerado.</summary>
    [JsonPropertyName("composicao")]
    public List<ComposicaoDas>? Composicao { get; set; }
}

/// <summary>
/// Discriminação dos valores do DAS ou de um tributo da composição.
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
/// Item da composição do DAS (tributo).
/// </summary>
public sealed class ComposicaoDas
{
    /// <summary>
    /// Período de apuração do tributo no formato AAAAMM (a documentação o descreve como texto, mas os exemplos
    /// trazem número; ambos são aceitos).
    /// </summary>
    [JsonPropertyName("periodoApuracao")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int? PeriodoApuracao { get; set; }

    /// <summary>Código do tributo.</summary>
    [JsonPropertyName("codigo")]
    public string? Codigo { get; set; }

    /// <summary>Descrição do nome/destino do tributo.</summary>
    [JsonPropertyName("denominacao")]
    public string? Denominacao { get; set; }

    /// <summary>Discriminação dos valores do tributo.</summary>
    [JsonPropertyName("valores")]
    public ValoresDas? Valores { get; set; }
}

/// <summary>
/// Lê uma lista aceitando também um objeto único (convertido em lista de um item), para campos em que a
/// documentação diverge entre objeto e array.
/// </summary>
/// <typeparam name="T">Tipo do item.</typeparam>
internal sealed class ListaOuObjetoJsonConverter<T> : JsonConverter<List<T>?>
{
    public override List<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.StartObject:
                var item = JsonSerializer.Deserialize<T>(ref reader, options);
                return item is null ? [] : [item];
            default:
                return JsonSerializer.Deserialize<List<T>>(ref reader, options);
        }
    }

    public override void Write(Utf8JsonWriter writer, List<T>? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
