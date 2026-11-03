using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador;

/// <summary>
/// Lê um campo texto que pode vir como string, número ou booleano (a documentação alterna entre os formatos,
/// ex.: códigos com zeros à esquerda); números são mantidos com o texto original. Escreve sempre como string.
/// </summary>
public sealed class TextoOuNumeroJsonConverter : JsonConverter<string?>
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
            case JsonTokenType.True:
                return "true";
            case JsonTokenType.False:
                return "false";
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

/// <summary>
/// Lê uma lista aceitando também um objeto único (convertido em lista de um item), para campos em que a
/// documentação diverge entre objeto e array.
/// </summary>
/// <typeparam name="T">Tipo do item.</typeparam>
public sealed class ListaOuObjetoJsonConverter<T> : JsonConverter<List<T>?>
{
    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, List<T>? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}

/// <summary>
/// Enum com valor numérico escrito como texto (ex.: <c>"0"</c>) e lido de número ou texto (texto vazio é nulo).
/// </summary>
public sealed class EnumNumericoJsonConverter : JsonConverterFactory
{
    /// <inheritdoc/>
    public override bool CanConvert(Type typeToConvert) => (Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert).IsEnum;

    /// <inheritdoc/>
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var subjacente = Nullable.GetUnderlyingType(typeToConvert);
        var tipo = subjacente is null
            ? typeof(Conversor<>).MakeGenericType(typeToConvert)
            : typeof(ConversorNulavel<>).MakeGenericType(subjacente);
        return (JsonConverter)Activator.CreateInstance(tipo)!;
    }

    private static TEnum? Ler<TEnum>(ref Utf8JsonReader reader) where TEnum : struct, Enum
    {
        long valor;
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.Number:
                valor = reader.GetInt64();
                break;
            case JsonTokenType.String:
                var texto = reader.GetString();
                if (string.IsNullOrWhiteSpace(texto))
                    return null;
                if (!long.TryParse(texto, NumberStyles.Integer, CultureInfo.InvariantCulture, out valor))
                    return Enum.TryParse<TEnum>(texto, true, out var nome) ? nome : throw new JsonException($"Valor '{texto}' inválido para {typeof(TEnum).Name}.");
                break;
            default:
                throw new JsonException($"Valor inesperado ({reader.TokenType}) para {typeof(TEnum).Name}.");
        }
        return (TEnum)Enum.ToObject(typeof(TEnum), valor);
    }

    private static void Escrever<TEnum>(Utf8JsonWriter writer, TEnum valor) where TEnum : struct, Enum =>
        writer.WriteStringValue(Convert.ToInt64(valor, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture));

    private sealed class Conversor<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
    {
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            Ler<TEnum>(ref reader) ?? default;

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options) => Escrever(writer, value);
    }

    private sealed class ConversorNulavel<TEnum> : JsonConverter<TEnum?> where TEnum : struct, Enum
    {
        public override TEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            Ler<TEnum>(ref reader);

        public override void Write(Utf8JsonWriter writer, TEnum? value, JsonSerializerOptions options)
        {
            if (value is null)
                writer.WriteNullValue();
            else
                Escrever(writer, value.Value);
        }
    }
}
