using System.Text.Json;
using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraSITFIS;

/// <summary>
/// Retorno do serviço SOLICITARPROTOCOLO91: protocolo para emissão do relatório de situação fiscal.
/// </summary>
/// <remarks>
/// O protocolo é válido apenas na data da solicitação. Se ainda não utilizado, nova solicitação responde HTTP 304 com o
/// protocolo no cabeçalho ETag (<c>protocoloRelatorio:...</c>), que o serviço atribui a <see cref="ProtocoloRelatorio"/>.
/// </remarks>
public sealed class ProtocoloRelatorioSitfis
{
    /// <summary>Protocolo a ser informado no serviço RELATORIOSITFIS92.</summary>
    [JsonPropertyName("protocoloRelatorio")]
    public string? ProtocoloRelatorio { get; set; }

    /// <summary>Tempo de espera estimado, em milissegundos, antes de acionar a emissão do relatório.</summary>
    [JsonPropertyName("tempoEspera")]
    public int? TempoEspera { get; set; }
}

/// <summary>
/// Entrada do serviço RELATORIOSITFIS92: protocolo obtido em SOLICITARPROTOCOLO91.
/// </summary>
/// <param name="ProtocoloRelatorio">Protocolo do relatório de situação fiscal.</param>
public sealed record EmissaoRelatorioSitfis([property: JsonPropertyName("protocoloRelatorio")] string ProtocoloRelatorio);

/// <summary>
/// Retorno do serviço RELATORIOSITFIS92: relatório em PDF (HTTP 200) ou novo tempo de espera, enquanto o relatório
/// estiver em processamento (HTTP 202, ou HTTP 204 com o cabeçalho ETag <c>tempoEspera:...</c>).
/// </summary>
/// <remarks>Aceita o conteúdo como objeto ou como array de um objeto (formato do exemplo da documentação).</remarks>
[JsonConverter(typeof(RelatorioSitfisJsonConverter))]
public sealed class RelatorioSitfis
{
    /// <summary>PDF do relatório de situação fiscal, em Base64 (retornado com HTTP 200).</summary>
    [JsonPropertyName("pdf")]
    public string? Pdf { get; set; }

    /// <summary>Tempo de espera estimado, em milissegundos, para nova tentativa (retornado com HTTP 202/204).</summary>
    [JsonPropertyName("tempoEspera")]
    public int? TempoEspera { get; set; }
}

/// <summary>
/// Lê o <see cref="RelatorioSitfis"/> de um objeto ou do primeiro item de um array.
/// </summary>
internal sealed class RelatorioSitfisJsonConverter : JsonConverter<RelatorioSitfis>
{
    public override RelatorioSitfis? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var elemento = doc.RootElement;
        if (elemento.ValueKind == JsonValueKind.Array)
            elemento = elemento.EnumerateArray().FirstOrDefault(e => e.ValueKind == JsonValueKind.Object);
        if (elemento.ValueKind != JsonValueKind.Object)
            return elemento.ValueKind == JsonValueKind.Undefined || elemento.ValueKind == JsonValueKind.Null
                ? null
                : throw new JsonException("Conteúdo inesperado para o relatório de situação fiscal.");

        var relatorio = new RelatorioSitfis();
        foreach (var propriedade in elemento.EnumerateObject())
        {
            if (propriedade.NameEquals("pdf") && propriedade.Value.ValueKind == JsonValueKind.String)
                relatorio.Pdf = propriedade.Value.GetString();
            else if (propriedade.NameEquals("tempoEspera"))
                relatorio.TempoEspera = propriedade.Value.ValueKind switch
                {
                    JsonValueKind.Number => propriedade.Value.GetInt32(),
                    JsonValueKind.String when int.TryParse(propriedade.Value.GetString(), out var tempo) => tempo,
                    _ => null
                };
        }
        return relatorio;
    }

    public override void Write(Utf8JsonWriter writer, RelatorioSitfis value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        if (value.Pdf is not null)
            writer.WriteString("pdf", value.Pdf);
        if (value.TempoEspera is not null)
            writer.WriteNumber("tempoEspera", value.TempoEspera.Value);
        writer.WriteEndObject();
    }
}
