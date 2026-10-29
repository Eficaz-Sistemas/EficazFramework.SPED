using System.Text.Json;
using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador;

/// <summary>
/// Mensagem de retorno (sucesso, aviso ou erro) da API Integra Contador.
/// </summary>
/// <param name="Codigo">Código da mensagem (ex.: Sucesso-PGDASD, [AcessoNegado-ICGERENCIADOR-016]).</param>
/// <param name="Texto">Texto descritivo da mensagem.</param>
public sealed record Mensagem(
    [property: JsonPropertyName("codigo")] string? Codigo,
    [property: JsonPropertyName("texto")] string? Texto);

/// <summary>
/// Corpo da resposta comum a todos os endpoints da API Integra Contador. O conteúdo do serviço vem em
/// <see cref="Dados"/> como string (JSON serializado ou Base64, conforme o serviço).
/// </summary>
public class RespostaIntegraContador
{
    /// <summary>Contratante informado na requisição.</summary>
    [JsonPropertyName("contratante")]
    public Identificacao? Contratante { get; set; }

    /// <summary>Autor do pedido de dados informado na requisição.</summary>
    [JsonPropertyName("autorPedidoDados")]
    public Identificacao? AutorPedidoDados { get; set; }

    /// <summary>Contribuinte informado na requisição.</summary>
    [JsonPropertyName("contribuinte")]
    public Identificacao? Contribuinte { get; set; }

    /// <summary>Pedido de dados informado na requisição.</summary>
    [JsonPropertyName("pedidoDados")]
    public PedidoDados? PedidoDados { get; set; }

    /// <summary>Status HTTP informado no corpo da resposta.</summary>
    [JsonPropertyName("status")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int? Status { get; set; }

    /// <summary>Conteúdo de retorno do serviço, sem desserialização (JSON serializado como string ou Base64).</summary>
    [JsonPropertyName("dados")]
    [JsonConverter(typeof(DadosJsonConverter))]
    public string? Dados { get; set; }

    /// <summary>Mensagens de retorno.</summary>
    [JsonPropertyName("mensagens")]
    public List<Mensagem>? Mensagens { get; set; }

    /// <summary>Identificador da resposta (informar ao suporte Serpro em caso de problemas).</summary>
    [JsonPropertyName("responseId")]
    public string? ResponseId { get; set; }

    /// <summary>Data e hora da resposta.</summary>
    [JsonPropertyName("responseDateTime")]
    public string? ResponseDateTime { get; set; }

    /// <summary>Status HTTP da resposta.</summary>
    [JsonIgnore]
    public int? StatusCode { get; set; }

    /// <summary>Indica status HTTP 2xx (inclusive 202 - em processamento e 204 - sem conteúdo ainda).</summary>
    [JsonIgnore]
    public bool Sucesso => StatusCode is >= 200 and < 300;

    /// <summary>Cabeçalho ETag da resposta (204: nova estimativa de espera; 304: token do procurador em cache).</summary>
    [JsonIgnore]
    public string? ETag { get; set; }

    /// <summary>Cabeçalho Expires da resposta (304 do AUTENTICAPROCURADOR: expiração do token em cache).</summary>
    [JsonIgnore]
    public DateTimeOffset? Expires { get; set; }
}

/// <summary>
/// Resposta da API Integra Contador com o conteúdo de <see cref="RespostaIntegraContador.Dados"/> desserializado.
/// </summary>
/// <typeparam name="T">Tipo do retorno do serviço (<see cref="string"/> para conteúdo Base64/texto puro).</typeparam>
public class RespostaIntegraContador<T> : RespostaIntegraContador
{
    /// <summary>Conteúdo de retorno do serviço desserializado (nulo quando não há dados).</summary>
    [JsonIgnore]
    public T? Retorno { get; set; }
}

/// <summary>
/// Lê o campo <c>dados</c> como string: valores string são mantidos; objetos/arrays (fora do padrão) viram o JSON bruto.
/// </summary>
public sealed class DadosJsonConverter : JsonConverter<string?>
{
    /// <inheritdoc/>
    public override bool HandleNull => true;

    /// <inheritdoc/>
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.String:
                return reader.GetString();
            default:
                using (var doc = JsonDocument.ParseValue(ref reader))
                    return doc.RootElement.GetRawText();
        }
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        if (value is null)
            writer.WriteNullValue();
        else
            writer.WriteStringValue(value);
    }
}
