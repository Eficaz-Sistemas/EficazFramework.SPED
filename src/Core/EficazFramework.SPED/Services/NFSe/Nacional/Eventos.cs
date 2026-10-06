using EficazFramework.SPED.Schemas.NFSe.Nacional;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Services.NFSe.Nacional;

#nullable enable

/// <summary>
/// Payload do registro de evento (POST /nfse/{chaveAcesso}/eventos): pedido de registro assinado, GZip + Base64.
/// </summary>
public record PedidoEnvioEvento(
    [property: JsonPropertyName("pedidoRegistroEventoXmlGZipB64")] string PedidoRegistroEventoXmlGZipB64
);

/// <summary>
/// Resposta do registro de evento (POST /nfse/{chaveAcesso}/eventos).
/// </summary>
public record RetornoRegistroEvento : RespostaBaseNfseNacional
{
    /// <summary>XML do evento registrado (GZip + Base64).</summary>
    [JsonPropertyName("eventoXmlGZipB64")]
    public string? EventoXmlGZipB64 { get; init; }

    /// <summary>Erros (a API usa ora <c>erro</c>, ora <c>erros</c>; ambos são reunidos aqui).</summary>
    [JsonIgnore]
    public List<MensagemProcessamento> Erros { get; init; } = [];

    /// <summary>Alertas devolvidos com o registro.</summary>
    [JsonIgnore]
    public List<MensagemProcessamento> Alertas { get; init; } = [];

    /// <summary>XML do evento descompactado.</summary>
    [JsonIgnore]
    public string? XmlEvento => NfseNacionalCompression.DecompressFromGZipBase64(EventoXmlGZipB64);

    /// <summary>Evento registrado (<see cref="EventoNfse"/>, desserializado do XML devolvido).</summary>
    [JsonIgnore]
    public EventoNfse? Evento { get; init; }

    /// <summary>Conteúdo bruto da resposta, para diagnóstico.</summary>
    [JsonIgnore]
    public string? ConteudoResposta { get; init; }
}

/// <summary>
/// Resposta da consulta de eventos de uma NFS-e (GET /nfse/{chaveAcesso}/eventos[/{tipoEvento}[/{numSeqEvento}]]).
/// </summary>
public record RetornoConsultaEventos : RespostaBaseNfseNacional
{
    /// <summary>Eventos encontrados (vazio se não houver nenhum, inclusive na resposta 404).</summary>
    [JsonIgnore]
    public List<EventoNfse> Eventos { get; init; } = [];

    /// <summary>Erros devolvidos pela API.</summary>
    [JsonIgnore]
    public List<MensagemProcessamento> Erros { get; init; } = [];

    /// <summary>Algum evento cancela a NFS-e (ver <see cref="EventoNfse.CancelaNfse"/>).</summary>
    [JsonIgnore]
    public bool NfseCancelada => Eventos.Any(e => e.CancelaNfse);

    /// <summary>Conteúdo bruto da resposta, para diagnóstico.</summary>
    [JsonIgnore]
    public string? ConteudoResposta { get; init; }
}

/// <summary>
/// Montagem do pedido de registro de evento (<see cref="PedidoRegistroEvento"/>, leiaute v1.01) e leitura das respostas da API.
/// </summary>
public static class EventosNfseNacional
{
    /// <summary>Versão do leiaute do pedido.</summary>
    public const string Versao = "1.01";

    /// <summary>
    /// Monta o pedido de cancelamento (e101101), ainda sem assinatura.
    /// </summary>
    /// <param name="chaveAcesso">Chave de acesso da NFS-e (50 dígitos).</param>
    /// <param name="cnpjCpfAutor">CNPJ (14) ou CPF (11) do autor do pedido (o emitente).</param>
    /// <param name="motivo">Código da justificativa.</param>
    /// <param name="descricaoMotivo">Descrição do motivo (15 a 255 caracteres).</param>
    /// <param name="ambiente">Ambiente de destino.</param>
    /// <param name="versaoAplicativo">Versão do aplicativo que gera o pedido (1 a 20 caracteres).</param>
    /// <param name="dataHoraEvento">Data/hora do evento; padrão: agora, no horário de Brasília.</param>
    /// <exception cref="ArgumentException">Chave, autor, motivo ou versão fora do leiaute.</exception>
    public static PedidoRegistroEvento MontarPedidoCancelamento(
        string chaveAcesso,
        string cnpjCpfAutor,
        MotivoCancelamentoNfse motivo,
        string descricaoMotivo,
        Ambiente ambiente,
        string versaoAplicativo,
        DateTimeOffset? dataHoraEvento = null)
    {
        var motivoTexto = (descricaoMotivo ?? string.Empty).Trim();
        if (motivoTexto.Length is < 15 or > 255)
            throw new ArgumentException("A descrição do motivo do cancelamento deve ter de 15 a 255 caracteres.", nameof(descricaoMotivo));

        if (!Enum.IsDefined(typeof(MotivoCancelamentoNfse), motivo))
            throw new ArgumentException("Motivo de cancelamento inválido (1 - Erro na emissão; 2 - Serviço não prestado; 9 - Outros).", nameof(motivo));

        var detalhe = new EventoCancelamento
        {
            Motivo = motivo,
            DescricaoMotivo = motivoTexto
        };

        return MontarPedido(chaveAcesso, cnpjCpfAutor, detalhe, ambiente, versaoAplicativo, dataHoraEvento);
    }

    /// <summary>
    /// Monta um pedido de registro de evento com o grupo informado, ainda sem assinatura.
    /// O <c>Id</c> do <c>infPedReg</c> é <c>PRE</c> + chave de acesso (50) + código do evento (6), conforme TSIdPedRegEvt.
    /// </summary>
    /// <exception cref="ArgumentException">Chave, autor ou versão fora do leiaute.</exception>
    public static PedidoRegistroEvento MontarPedido(
        string chaveAcesso,
        string cnpjCpfAutor,
        DetalheEventoNfse detalheEvento,
        Ambiente ambiente,
        string versaoAplicativo,
        DateTimeOffset? dataHoraEvento = null)
    {
        ArgumentNullException.ThrowIfNull(detalheEvento);

        var chave = SomenteDigitos(chaveAcesso);
        if (chave.Length != 50)
            throw new ArgumentException("A chave de acesso da NFS-e deve ter 50 dígitos.", nameof(chaveAcesso));

        var autor = SomenteDigitos(cnpjCpfAutor);
        if (autor.Length is not (11 or 14))
            throw new ArgumentException("Informe o CNPJ (14 dígitos) ou o CPF (11 dígitos) do autor do evento.", nameof(cnpjCpfAutor));

        var versao = (versaoAplicativo ?? string.Empty).Trim();
        if (versao.Length is < 1 or > 20)
            throw new ArgumentException("A versão do aplicativo deve ter de 1 a 20 caracteres.", nameof(versaoAplicativo));

        var codigo = ((int)detalheEvento.Tipo).ToString(CultureInfo.InvariantCulture);
        return new PedidoRegistroEvento
        {
            versao = Versao,
            InfPedReg = new InformacoesPedidoRegistroEvento
            {
                Id = $"PRE{chave}{codigo}",
                TipoAmbiente = ambiente,
                VersaoAplicativo = versao,
                DataHoraEvento = SemFracaoDeSegundo(dataHoraEvento ?? AgoraEmBrasilia()),
                CNPJAutor = autor.Length == 14 ? autor : null,
                CPFAutor = autor.Length == 11 ? autor : null,
                ChaveAcesso = chave,
                Detalhe = detalheEvento
            }
        };
    }

    /// <summary>Agora, no fuso de Brasília (o leiaute aceita só deslocamentos de hora cheia), sem frações de segundo.</summary>
    public static DateTimeOffset AgoraEmBrasilia()
    {
        var agora = DateTimeOffset.UtcNow;
        try
        {
            agora = TimeZoneInfo.ConvertTime(agora, TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo"));
        }
        catch (Exception ex) when (ex is TimeZoneNotFoundException or InvalidTimeZoneException)
        {
            agora = agora.ToOffset(TimeSpan.FromHours(-3));
        }
        return SemFracaoDeSegundo(agora);
    }

    /// <summary>
    /// Lê o XML de um evento (<c>evento</c>) devolvido pela API.
    /// </summary>
    /// <returns>O evento, ou <see langword="null"/> se o XML não for um evento válido.</returns>
    public static EventoNfse? LerEvento(string? xml)
    {
        if (string.IsNullOrWhiteSpace(xml) || !xml.Contains("<evento", StringComparison.Ordinal) && !xml.Contains(":evento", StringComparison.Ordinal))
            return null;

        EventoNfse evento = null!;
        return EventoNfse.CanDeserialize(xml, ref evento) ? evento : null;
    }

    /// <summary>
    /// Lê os eventos de uma resposta JSON da API: qualquer propriedade <c>*XmlGZipB64</c> (no objeto, em listas
    /// ou em objetos aninhados) que contenha um XML de evento. Tolera variações de nomes entre versões da API.
    /// </summary>
    public static List<EventoNfse> LerEventosDoJson(JsonElement raiz)
    {
        var eventos = new List<EventoNfse>();
        Coletar(raiz, eventos);
        return eventos;

        static void Coletar(JsonElement elemento, List<EventoNfse> destino)
        {
            switch (elemento.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (var propriedade in elemento.EnumerateObject())
                    {
                        if (propriedade.Value.ValueKind == JsonValueKind.String
                            && propriedade.Name.EndsWith("XmlGZipB64", StringComparison.OrdinalIgnoreCase))
                        {
                            var evento = LerEvento(NfseNacionalCompression.DecompressFromGZipBase64(propriedade.Value.GetString()));
                            if (evento is not null)
                                destino.Add(evento);
                        }
                        else
                        {
                            Coletar(propriedade.Value, destino);
                        }
                    }
                    break;
                case JsonValueKind.Array:
                    foreach (var item in elemento.EnumerateArray())
                        Coletar(item, destino);
                    break;
            }
        }
    }

    /// <summary>Mensagens de <c>erro</c> (objeto) e <c>erros</c> (lista), ou de <c>alertas</c>, sem diferenciar maiúsculas.</summary>
    public static List<MensagemProcessamento> LerMensagens(JsonElement raiz, params string[] nomes)
    {
        var mensagens = new List<MensagemProcessamento>();
        if (raiz.ValueKind != JsonValueKind.Object)
            return mensagens;

        foreach (var propriedade in raiz.EnumerateObject())
        {
            if (!nomes.Any(n => string.Equals(n, propriedade.Name, StringComparison.OrdinalIgnoreCase)))
                continue;

            if (propriedade.Value.ValueKind == JsonValueKind.Object)
                mensagens.Add(LerMensagem(propriedade.Value));
            else if (propriedade.Value.ValueKind == JsonValueKind.Array)
                mensagens.AddRange(propriedade.Value.EnumerateArray().Where(i => i.ValueKind == JsonValueKind.Object).Select(LerMensagem));
        }
        return mensagens;

        static MensagemProcessamento LerMensagem(JsonElement m) => new(
            Texto(m, "codigo") ?? Texto(m, "Codigo"),
            Texto(m, "descricao") ?? Texto(m, "Descricao") ?? Texto(m, "mensagem") ?? Texto(m, "Mensagem"),
            Texto(m, "complemento") ?? Texto(m, "Complemento"));

        static string? Texto(JsonElement m, string nome) =>
            m.TryGetProperty(nome, out var v) ? (v.ValueKind == JsonValueKind.String ? v.GetString() : v.ToString()) : null;
    }

    /// <summary>O leiaute (TSDateTimeUTC) não aceita frações de segundo.</summary>
    private static DateTimeOffset SemFracaoDeSegundo(DateTimeOffset valor) =>
        new(valor.Year, valor.Month, valor.Day, valor.Hour, valor.Minute, valor.Second, valor.Offset);

    private static string SomenteDigitos(string? valor) =>
        new((valor ?? string.Empty).Where(char.IsDigit).ToArray());
}
