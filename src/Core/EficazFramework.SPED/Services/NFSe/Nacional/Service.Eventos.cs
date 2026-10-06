using EficazFramework.SPED.Schemas.NFSe.Nacional;
using System.Net.Http;
using System.Text.Json;
using System.Threading;

namespace EficazFramework.SPED.Services.NFSe.Nacional;

#nullable enable

/// <summary>
/// Eventos da NFS-e Nacional: cancelamento (e101101), registro de eventos e consulta de eventos da nota.
/// </summary>
public partial class NfseNacionalService
{

    // ─── Eventos (cancelamento e consulta) ───

    /// <summary>
    /// Versão do aplicativo informada nos pedidos de registro de evento (<c>verAplic</c>, 1 a 20 caracteres).
    /// </summary>
    public string VersaoAplicativo { get; set; } = "EficazFramework.SPED";

    /// <summary>
    /// Assina o pedido de registro de evento (<see cref="PedidoRegistroEvento"/>) com o certificado: XMLDSig RSA-SHA256
    /// sobre o <c>infPedReg</c>, com a assinatura ao final do <c>pedRegEvento</c> (mesmo padrão de <see cref="AssinarDps"/>).
    /// </summary>
    /// <param name="pedido">Pedido montado por <see cref="EventosNfseNacional.MontarPedido"/> ou <see cref="EventosNfseNacional.MontarPedidoCancelamento"/>.</param>
    /// <returns>XmlDocument assinado.</returns>
    /// <exception cref="ArgumentNullException">Pedido ou certificado ausente.</exception>
    public virtual XmlDocument AssinarPedidoEvento(PedidoRegistroEvento pedido)
    {
        ArgumentNullException.ThrowIfNull(pedido);

        if (!ValidaCertificado())
            throw new ArgumentNullException(nameof(Certificado), "Certificado digital não selecionado para assinatura do pedido de registro de evento.");

        var xmlDoc = new XmlDocument { PreserveWhitespace = false };
        xmlDoc.LoadXml(pedido.Serialize());

        Certificado.SignXml(xmlDoc, "pedRegEvento", "infPedReg", signAsSHA256: true, emptyURI: false);
        return xmlDoc;
    }

    /// <summary>
    /// Cancela a NFS-e (evento e101101): monta o pedido, assina e registra (POST /nfse/{chaveAcesso}/eventos).
    /// </summary>
    /// <param name="chaveAcesso">Chave de acesso da NFS-e (50 dígitos).</param>
    /// <param name="motivo">Código da justificativa (1 - Erro na emissão; 2 - Serviço não prestado; 9 - Outros).</param>
    /// <param name="descricaoMotivo">Descrição do motivo (15 a 255 caracteres).</param>
    /// <param name="ambiente">Ambiente de destino. Padrão canônico de segurança: HOMOLOGAÇÃO.</param>
    /// <param name="cnpjCpfAutor">CNPJ/CPF do autor (o emitente); padrão: o do certificado.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentException">Chave, autor ou motivo fora do leiaute.</exception>
    public virtual Task<RetornoRegistroEvento> CancelarNfseAsync(
        string chaveAcesso,
        MotivoCancelamentoNfse motivo,
        string descricaoMotivo,
        Schemas.NFSe.Nacional.Ambiente ambiente = Schemas.NFSe.Nacional.Ambiente.Homologacao,
        string? cnpjCpfAutor = null,
        CancellationToken ct = default)
    {
        if (!ValidaCertificado())
            throw new ArgumentNullException(nameof(Certificado), "Nenhum certificado digital ICP-Brasil válido foi fornecido para a requisição.");

        var pedido = EventosNfseNacional.MontarPedidoCancelamento(
            chaveAcesso,
            string.IsNullOrWhiteSpace(cnpjCpfAutor) ? Certificado.CNPJ_CPF : cnpjCpfAutor,
            motivo,
            descricaoMotivo,
            ambiente,
            VersaoAplicativo);

        return RegistrarEventoAsync(chaveAcesso, pedido, ambiente, ct);
    }

    /// <summary>
    /// Registra um evento na NFS-e (POST /nfse/{chaveAcesso}/eventos). O pedido é assinado aqui
    /// (<see cref="AssinarPedidoEvento"/>) se ainda não tiver assinatura.
    /// </summary>
    /// <param name="chaveAcesso">Chave de acesso da NFS-e (50 dígitos).</param>
    /// <param name="pedido">Pedido de registro de evento.</param>
    /// <param name="ambiente">Ambiente de destino. Padrão canônico de segurança: HOMOLOGAÇÃO.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentException">Chave inválida.</exception>
    public virtual Task<RetornoRegistroEvento> RegistrarEventoAsync(
        string chaveAcesso,
        PedidoRegistroEvento pedido,
        Schemas.NFSe.Nacional.Ambiente ambiente = Schemas.NFSe.Nacional.Ambiente.Homologacao,
        CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(pedido);

        XmlDocument xml;
        if (pedido.Signature is null)
        {
            xml = AssinarPedidoEvento(pedido);
        }
        else
        {
            xml = new XmlDocument { PreserveWhitespace = false };
            xml.LoadXml(pedido.Serialize());
        }

        return RegistrarEventoAsync(chaveAcesso, xml, ambiente, ct);
    }

    /// <summary>
    /// Registra um evento na NFS-e (POST /nfse/{chaveAcesso}/eventos) a partir do XML do pedido já assinado.
    /// </summary>
    /// <param name="chaveAcesso">Chave de acesso da NFS-e (50 dígitos).</param>
    /// <param name="pedidoAssinado">XML do <c>pedRegEvento</c> assinado (ex.: retorno de <see cref="AssinarPedidoEvento"/>).</param>
    /// <param name="ambiente">Ambiente de destino. Padrão canônico de segurança: HOMOLOGAÇÃO.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentException">Chave inválida, documento que não é um <c>pedRegEvento</c> ou sem assinatura.</exception>
    public virtual async Task<RetornoRegistroEvento> RegistrarEventoAsync(
        string chaveAcesso,
        XmlDocument pedidoAssinado,
        Schemas.NFSe.Nacional.Ambiente ambiente = Schemas.NFSe.Nacional.Ambiente.Homologacao,
        CancellationToken ct = default)
    {
        var chave = ChaveValida(chaveAcesso);
        ArgumentNullException.ThrowIfNull(pedidoAssinado);
        if (pedidoAssinado.DocumentElement?.LocalName != "pedRegEvento")
            throw new ArgumentException("O documento informado não é um pedido de registro de evento (pedRegEvento).", nameof(pedidoAssinado));
        if (pedidoAssinado.GetElementsByTagName("Signature", "http://www.w3.org/2000/09/xmldsig#").Count == 0)
            throw new ArgumentException("O pedido de registro de evento não está assinado.", nameof(pedidoAssinado));

        var payload = new PedidoEnvioEvento(NfseNacionalCompression.CompressToGZipBase64(pedidoAssinado.OuterXml));
        using var content = new StringContent(JsonSerializer.Serialize(payload, JsonOptions), Encoding.UTF8, "application/json");
        using var response = await EnviarAsync(HttpMethod.Post, Endereco(ambiente, $"nfse/{chave}/eventos"), content, ct);
        var corpo = await response.Content.ReadAsStringAsync(ct);

        RetornoRegistroEvento retorno;
        try
        {
            using var json = JsonDocument.Parse(corpo);
            var raiz = json.RootElement;
            var lido = DeserializarOuNovo<RetornoRegistroEvento>(raiz);
            retorno = lido with
            {
                Erros = EventosNfseNacional.LerMensagens(raiz, "erro", "erros"),
                Alertas = EventosNfseNacional.LerMensagens(raiz, "alertas"),
                Evento = EventosNfseNacional.LerEvento(lido.XmlEvento) ?? EventosNfseNacional.LerEventosDoJson(raiz).FirstOrDefault(),
                ConteudoResposta = corpo
            };
        }
        catch (JsonException)
        {
            retorno = new RetornoRegistroEvento
            {
                TipoAmbiente = ambiente,
                DataHoraProcessamento = DateTime.UtcNow,
                Erros = [new MensagemProcessamento(((int)response.StatusCode).ToString(), response.ReasonPhrase ?? "Erro HTTP", corpo)],
                ConteudoResposta = corpo
            };
        }

        retorno.StatusCode = (int)response.StatusCode;
        return retorno;
    }

    /// <summary>
    /// Consulta os eventos da NFS-e (GET /nfse/{chaveAcesso}/eventos, opcionalmente por tipo e nº sequencial).
    /// Use <see cref="RetornoConsultaEventos.NfseCancelada"/> para saber se a nota foi cancelada.
    /// </summary>
    /// <param name="chaveAcesso">Chave de acesso da NFS-e (50 dígitos).</param>
    /// <param name="ambiente">Ambiente de destino. Padrão canônico de segurança: HOMOLOGAÇÃO.</param>
    /// <param name="tipo">Filtra por tipo de evento (GET .../eventos/{tipoEvento}).</param>
    /// <param name="numeroSequencial">Com <paramref name="tipo"/>, um evento específico (GET .../eventos/{tipoEvento}/{numSeqEvento}).</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentException">Chave inválida, ou nº sequencial sem o tipo.</exception>
    public virtual async Task<RetornoConsultaEventos> ConsultarEventosAsync(
        string chaveAcesso,
        Schemas.NFSe.Nacional.Ambiente ambiente = Schemas.NFSe.Nacional.Ambiente.Homologacao,
        TipoEventoNfse? tipo = null,
        int? numeroSequencial = null,
        CancellationToken ct = default)
    {
        var chave = ChaveValida(chaveAcesso);
        if (numeroSequencial.HasValue && tipo is null)
            throw new ArgumentException("Informe o tipo do evento para consultar pelo número sequencial.", nameof(numeroSequencial));

        var caminho = $"nfse/{chave}/eventos";
        if (tipo is { } t)
        {
            caminho += $"/{(int)t}";
            if (numeroSequencial is { } n)
                caminho += $"/{n}";
        }

        using var response = await EnviarAsync(HttpMethod.Get, Endereco(ambiente, caminho), null, ct);
        var corpo = await response.Content.ReadAsStringAsync(ct);

        RetornoConsultaEventos retorno;
        if (corpo.TrimStart().StartsWith('<'))
        {
            // Algumas respostas trazem o XML do evento direto no corpo.
            var evento = EventosNfseNacional.LerEvento(corpo);
            retorno = new RetornoConsultaEventos
            {
                TipoAmbiente = ambiente,
                Eventos = evento is null ? [] : [evento],
                ConteudoResposta = corpo
            };
        }
        else
        {
            try
            {
                using var json = JsonDocument.Parse(corpo);
                var raiz = json.RootElement;
                retorno = DeserializarOuNovo<RetornoConsultaEventos>(raiz) with
                {
                    Eventos = EventosNfseNacional.LerEventosDoJson(raiz),
                    Erros = EventosNfseNacional.LerMensagens(raiz, "erro", "erros"),
                    ConteudoResposta = corpo
                };
            }
            catch (JsonException)
            {
                retorno = new RetornoConsultaEventos
                {
                    TipoAmbiente = ambiente,
                    DataHoraProcessamento = DateTime.UtcNow,
                    Erros = string.IsNullOrWhiteSpace(corpo)
                        ? []
                        : [new MensagemProcessamento(((int)response.StatusCode).ToString(), response.ReasonPhrase ?? "Erro HTTP", corpo)],
                    ConteudoResposta = corpo
                };
            }
        }

        retorno.StatusCode = (int)response.StatusCode;
        return retorno;
    }

    /// <summary>Chave de acesso com 50 dígitos.</summary>
    /// <exception cref="ArgumentException">Chave ausente ou com tamanho diferente de 50 dígitos.</exception>
    private static string ChaveValida(string chaveAcesso)
    {
        if (string.IsNullOrWhiteSpace(chaveAcesso) || chaveAcesso.Length != 50 || !chaveAcesso.All(char.IsDigit))
            throw new ArgumentException("A chave de acesso da NFS-e deve ter 50 dígitos.", nameof(chaveAcesso));
        return chaveAcesso;
    }

    /// <summary>Desserializa os campos comuns; se algum vier em formato inesperado, devolve uma instância vazia (os demais campos são lidos à parte).</summary>
    private static T DeserializarOuNovo<T>(JsonElement raiz) where T : new()
    {
        try
        {
            return raiz.Deserialize<T>(JsonOptions) ?? new T();
        }
        catch (JsonException)
        {
            return new T();
        }
    }
}
