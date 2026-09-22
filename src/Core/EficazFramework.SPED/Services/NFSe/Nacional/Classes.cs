using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Services.NFSe.Nacional;

public record RetornoProcessamento(
    StatusProcessamentoEnum StatusProcessamento,
    List<LoteDFeItem> LoteDFe,
    List<MensagemProcessamento> Alertas,
    List<MensagemProcessamento> Erros,
    TipoAmbienteEnum TipoAmbiente,
    string VersaoAplicativo,
    DateTime DataHoraProcessamento
);

public record LoteDFeItem(
    int NSU,
    string ChaveAcesso,
    string TipoDocumento,
    string TipoEvento,
    string ArquivoXml,
    DateTime DataHoraGeracao
);

public record MensagemProcessamento(
    object Mensagem,
    List<string> Parametros,
    string Codigo,
    string Descricao,
    string Complemento
);

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StatusProcessamentoEnum
{
    REJEICAO,
    NENHUM_DOCUMENTO_LOCALIZADO,
    DOCUMENTOS_LOCALIZADOS
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TipoAmbienteEnum
{
    PRODUCAO,
    HOMOLOGACAO
}

public record PedidoEnvioDps(
    [property: JsonPropertyName("dpsXmlGZipB64")] string DpsXmlGZipB64
);

public record PedidoEventoNfse(
    [property: JsonPropertyName("eventoXmlGZipB64")] string EventoXmlGZipB64
);

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

    public static string DecompressFromGZipBase64(string compressedBase64OrRaw)
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
