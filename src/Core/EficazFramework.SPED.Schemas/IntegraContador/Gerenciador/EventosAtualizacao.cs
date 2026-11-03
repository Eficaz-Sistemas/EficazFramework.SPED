using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.Gerenciador;

/// <summary>
/// Códigos dos eventos de atualização monitoráveis (Mapa dos Eventos de Atualização).
/// </summary>
public static class CodigoEventoAtualizacao
{
    /// <summary>E0301 - DCTFWeb: recebimento de apuração ou transmissão de declaração (PF ou PJ).</summary>
    public const string DctfWeb = "E0301";

    /// <summary>E0601 - Caixa Postal: nova mensagem para o contribuinte (PF ou PJ).</summary>
    public const string CaixaPostal = "E0601";

    /// <summary>E0701 - Pagamento: novo documento, alteração, cancelamento ou bloqueio de pagamento (PF ou PJ).</summary>
    public const string Pagamento = "E0701";
}

/// <summary>
/// Entrada dos serviços SOLICEVENTOSPF131 e SOLICEVENTOSPJ132: evento a consultar para o lote de contribuintes
/// informado em <c>contribuinte.numero</c> (tipo 3 - <see cref="TipoIdentificacao.LotePF"/> ou 4 - <see cref="TipoIdentificacao.LotePJ"/>).
/// </summary>
public sealed class SolicitacaoEventos
{
    /// <summary>Código do evento (ver <see cref="CodigoEventoAtualizacao"/>).</summary>
    [JsonPropertyName("evento")]
    public string Evento { get; set; } = string.Empty;
}

/// <summary>
/// Retorno dos serviços SOLICEVENTOSPF131 e SOLICEVENTOSPJ132: protocolo para obtenção dos eventos.
/// </summary>
public sealed class RetornoSolicitacaoEventos
{
    /// <summary>Identificador exclusivo da solicitação (36 caracteres).</summary>
    [JsonPropertyName("protocolo")]
    public string? Protocolo { get; set; }

    /// <summary>Tempo médio de espera, em milissegundos, até que os eventos possam ser obtidos.</summary>
    [JsonPropertyName("TempoEsperaMedioEmMs")]
    public int? TempoEsperaMedioEmMs { get; set; }

    /// <summary>Tempo máximo, em minutos, em que o protocolo fica disponível para obtenção.</summary>
    [JsonPropertyName("TempoLimiteEmMin")]
    public int? TempoLimiteEmMin { get; set; }
}

/// <summary>
/// Entrada dos serviços OBTEREVENTOSPF133 e OBTEREVENTOSPJ134. O <c>contribuinte.numero</c> deve ser vazio, com o
/// tipo do lote (3 - PF ou 4 - PJ).
/// </summary>
public sealed class ObtencaoEventos
{
    /// <summary>Protocolo obtido na solicitação dos eventos.</summary>
    [JsonPropertyName("protocolo")]
    public string Protocolo { get; set; } = string.Empty;

    /// <summary>Código do evento (o mesmo da solicitação).</summary>
    [JsonPropertyName("evento")]
    public string Evento { get; set; } = string.Empty;
}

/// <summary>
/// Linha da matriz de eventos retornada por OBTEREVENTOSPF133 / OBTEREVENTOSPJ134: <c>["NI", "AAMMDD"]</c>.
/// </summary>
/// <remarks>A data vem vazia quando o contribuinte não teve atualização e "x" quando não há procuração (acesso negado).</remarks>
[JsonConverter(typeof(EventoAtualizacaoJsonConverter))]
public sealed class EventoAtualizacao
{
    /// <summary>Valor de <see cref="Data"/> quando não há procuração outorgada para o contribuinte.</summary>
    public const string SemProcuracao = "x";

    /// <summary>CPF ou CNPJ do contribuinte.</summary>
    public string Ni { get; set; } = string.Empty;

    /// <summary>Data da última atualização (AAMMDD), vazio (sem atualização) ou "x" (acesso negado).</summary>
    public string Data { get; set; } = string.Empty;

    /// <summary>Indica que o contribuinte não recebeu atualização.</summary>
    public bool SemAtualizacao => string.IsNullOrEmpty(Data);

    /// <summary>Indica que o acesso foi negado por falta de procuração.</summary>
    public bool AcessoNegado => string.Equals(Data, SemProcuracao, StringComparison.OrdinalIgnoreCase);

    /// <summary>Data da última atualização, quando informada.</summary>
    public DateTime? DataEvento =>
        DateTime.TryParseExact(Data, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var data) ? data : null;
}

/// <summary>
/// (Des)serializa <see cref="EventoAtualizacao"/> como array de duas strings <c>[NI, data]</c>.
/// </summary>
public sealed class EventoAtualizacaoJsonConverter : JsonConverter<EventoAtualizacao>
{
    /// <inheritdoc/>
    public override EventoAtualizacao? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException("O evento de atualização deve ser um array [NI, data].");

        var valores = new List<string>(2);
        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            valores.Add(reader.TokenType switch
            {
                JsonTokenType.String => reader.GetString() ?? string.Empty,
                JsonTokenType.Null => string.Empty,
                JsonTokenType.Number => reader.GetDecimal().ToString(CultureInfo.InvariantCulture),
                _ => throw new JsonException("Valor inesperado no evento de atualização.")
            });
        }

        return new EventoAtualizacao
        {
            Ni = valores.Count > 0 ? valores[0] : string.Empty,
            Data = valores.Count > 1 ? valores[1] : string.Empty
        };
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, EventoAtualizacao value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        writer.WriteStringValue(value.Ni);
        writer.WriteStringValue(value.Data);
        writer.WriteEndArray();
    }
}
