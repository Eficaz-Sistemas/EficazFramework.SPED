using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Services.NFSe.Nacional;

#nullable enable



/// <summary>
/// Mensagem de alerta ou erro retornada pelo ADN.
/// </summary>
public record MensagemProcessamento(
    [property: JsonPropertyName("codigo")] string? Codigo,
    [property: JsonPropertyName("descricao")] string? Descricao,
    [property: JsonPropertyName("complemento")] string? Complemento
);

/// <summary>
/// Contrato base de resposta do ADN.
/// </summary>
public abstract record RespostaBaseNfseNacional
{
    [JsonPropertyName("tipoAmbiente")]
    public Schemas.NFSe.Nacional.Ambiente? TipoAmbiente { get; init; }

    [JsonPropertyName("versaoAplicativo")]
    public string? VersaoAplicativo { get; init; }

    [JsonPropertyName("dataHoraProcessamento")]
    public DateTime? DataHoraProcessamento { get; init; }

    [JsonIgnore]
    public int? StatusCode { get; internal set; }

    [JsonIgnore]
    public bool Sucesso => StatusCode is >= 200 and < 300;
}

/// <summary>
/// Resposta de recepção síncrona de DPS e geração de NFS-e (POST /nfse).
/// Retornos esperados: 201 (sucesso), 400, 403, 500 (erros).
/// </summary>
public record RetornoEnvioDps : RespostaBaseNfseNacional
{
    [JsonPropertyName("idDps")]
    public string? IdDps { get; init; }

    [JsonPropertyName("chaveAcesso")]
    public string? ChaveAcesso { get; init; }

    [JsonPropertyName("nfseXmlGZipB64")]
    public string? NfseXmlGZipB64 { get; init; }

    [JsonPropertyName("alertas")]
    public List<MensagemProcessamento>? Alertas { get; init; }

    [JsonPropertyName("erros")]
    public List<MensagemProcessamento>? Erros { get; init; }

    /// <summary>
    /// Retorna o XML da NFS-e descompactado a partir de <see cref="NfseXmlGZipB64"/>.
    /// </summary>
    [JsonIgnore]
    public string? XmlNfse => NfseNacionalCompression.DecompressFromGZipBase64(NfseXmlGZipB64);
}

/// <summary>
/// Resposta da consulta de NFS-e por chave de acesso de 50 dígitos (GET /nfse/{chaveAcesso}).
/// Retornos esperados: 200 (sucesso), 400, 401, 403, 404 (erros).
/// </summary>
public record RetornoConsultaNfse : RespostaBaseNfseNacional
{
    [JsonPropertyName("chaveAcesso")]
    public string? ChaveAcesso { get; init; }

    [JsonPropertyName("nfseXmlGZipB64")]
    public string? NfseXmlGZipB64 { get; init; }

    [JsonPropertyName("erro")]
    public MensagemProcessamento? Erro { get; init; }

    /// <summary>
    /// Retorna o XML da NFS-e descompactado a partir de <see cref="NfseXmlGZipB64"/>.
    /// </summary>
    [JsonIgnore]
    public string? XmlNfse => NfseNacionalCompression.DecompressFromGZipBase64(NfseXmlGZipB64);
}

/// <summary>
/// Resposta da consulta de chave de acesso pelo Id da DPS (GET /dps/{id}).
/// Retornos esperados: 200 (sucesso), 400, 404 (erros).
/// </summary>
public record RetornoConsultaDps : RespostaBaseNfseNacional
{
    [JsonPropertyName("idDps")]
    public string? IdDps { get; init; }

    [JsonPropertyName("chaveAcesso")]
    public string? ChaveAcesso { get; init; }

    [JsonPropertyName("erro")]
    public MensagemProcessamento? Erro { get; init; }
}

/// <summary>
/// Payload para recepção da DPS compactada (POST /nfse).
/// </summary>
public record PedidoEnvioDps(
    [property: JsonPropertyName("dpsXmlGZipB64")] string DpsXmlGZipB64
);

/// <summary>
/// Utilitário para compactação e descompactação GZip Base64 conforme especificado pelo ADN.
/// </summary>
public static class NfseNacionalCompression
{
    public static string CompressToGZipBase64(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        var bytes = System.Text.Encoding.UTF8.GetBytes(text);
        using var ms = new System.IO.MemoryStream();
        using (var gz = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionLevel.Optimal, leaveOpen: true))
        {
            gz.Write(bytes, 0, bytes.Length);
        }
        return Convert.ToBase64String(ms.ToArray());
    }

    public static string DecompressFromGZipBase64(string? compressedBase64OrRaw)
    {
        if (string.IsNullOrWhiteSpace(compressedBase64OrRaw))
            return string.Empty;

        if (compressedBase64OrRaw.TrimStart().StartsWith("<"))
            return compressedBase64OrRaw;

        try
        {
            var bytes = Convert.FromBase64String(compressedBase64OrRaw);
            if (bytes.Length > 2 && bytes[0] == 0x1F && bytes[1] == 0x8B)
            {
                using var ms = new System.IO.MemoryStream(bytes);
                using var gz = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress);
                using var reader = new System.IO.StreamReader(gz, System.Text.Encoding.UTF8);
                return reader.ReadToEnd();
            }
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
        catch
        {
            return compressedBase64OrRaw;
        }
    }
}
