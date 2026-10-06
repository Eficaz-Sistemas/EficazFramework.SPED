using EficazFramework.SPED.Schemas.NFSe.Nacional;
using EficazFramework.SPED.Services.Primitives;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace EficazFramework.SPED.Services.NFSe.Nacional;

#nullable enable

/// <summary>
/// Serviço de comunicação REST com o Ambiente de Dados Nacional (ADN) da NFS-e (Sefin Nacional / Receita Federal / Serpro).
/// Suporta emissão síncrona de DPS com assinatura digital XMLDSig RSA-SHA256, consulta de NFS-e por chave de acesso e consulta por identificador do DPS.
/// </summary>
/// <remarks>
/// Use uma instância por certificado e descarte-a ao terminar (<see cref="RestServiceBase.Dispose()"/>): o cliente HTTP
/// é criado na primeira requisição e reutilizado por todos os métodos e ambientes (URLs completas, sem <c>BaseAddress</c>).
/// </remarks>
public partial class NfseNacionalService : RestServiceBase
{
    /// <summary>Cria o serviço; o certificado é obtido por <see cref="ServiceBase.SelecionaCertificado"/> na primeira requisição.</summary>
    public NfseNacionalService() : base() { }

    /// <summary>Cria o serviço com um handler HTTP próprio (testes, proxy); o certificado não é anexado ao handler.</summary>
    /// <param name="handler">Handler usado pelo cliente HTTP (não é descartado pelo serviço).</param>
    public NfseNacionalService(HttpMessageHandler handler) : base(handler) { }

    /// <summary>
    /// URL base para o ambiente de Produção do ADN.
    /// </summary>
    public Uri UrlProducao { get; set; } = new("https://sefin.nfse.gov.br/");


    public Uri UrlDistribuicaoProducao { get; set; } = new("https://adn.nfse.gov.br/");

    /// <summary>
    /// URL base para o ambiente de Homologação / Produção Restrita do ADN.
    /// </summary>
    public Uri UrlHomologacao { get; set; } = new("https://sefin.producaorestrita.nfse.gov.br/SefinNacional/");

    public Uri UrlDistribuicaoHomologacao { get; set; } = new("https://adn.producaorestrita.nfse.gov.br/");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>
    /// URL completa do endpoint no ambiente: Sefin Nacional (emissão, consultas, eventos) ou ADN (distribuição).
    /// </summary>
    /// <param name="ambiente">Produção ou Homologação (Produção Restrita).</param>
    /// <param name="caminho">Caminho relativo do endpoint (ex.: <c>nfse/{chave}</c>).</param>
    /// <param name="distribuicao">Usa a URL do ADN (distribuição de DF-e) em vez da Sefin Nacional.</param>
    protected virtual Uri Endereco(
        Schemas.NFSe.Nacional.Ambiente ambiente,
        string caminho,
        bool distribuicao = false)
    {
        var baseUri = ambiente == Ambiente.Producao
            ? (distribuicao ? UrlDistribuicaoProducao : UrlProducao)
            : (distribuicao ? UrlDistribuicaoHomologacao : UrlHomologacao);
        return new Uri(baseUri, caminho);
    }

    /// <summary>
    /// Envia a requisição pelo cliente HTTP do serviço (certificado no mTLS), aceitando JSON.
    /// </summary>
    /// <exception cref="ArgumentNullException">Nenhum certificado digital ICP-Brasil foi fornecido.</exception>
    protected async Task<HttpResponseMessage> EnviarAsync(
        HttpMethod metodo,
        Uri endereco,
        HttpContent? conteudo,
        CancellationToken ct)
    {
        using var request = new HttpRequestMessage(metodo, endereco) { Content = conteudo };
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return await ObterHttpClient().SendAsync(request, ct);
    }

    /// <summary>
    /// Assina digitalmente a Declaração de Prestação de Serviço (DPS) com o certificado digital ICP-Brasil
    /// utilizando o padrão XMLDSig RSA-SHA256 e EnvelopedSignatureTransform.
    /// </summary>
    /// <param name="dps">Instância da DPS a ser assinada.</param>
    /// <returns>Objeto XmlDocument assinado.</returns>
    public virtual XmlDocument AssinarDps(DeclaracaoPrestacaoServico dps)
    {
        if (dps == null)
            throw new ArgumentNullException(nameof(dps), "A DPS não foi informada para assinatura.");

        if (!ValidaCertificado())
            throw new ArgumentNullException(nameof(Certificado), "Certificado digital não selecionado para assinatura da DPS.");

        var xml = dps.Serialize();
        var xmlDoc = new XmlDocument { PreserveWhitespace = false };
        xmlDoc.LoadXml(xml);

        Certificado.SignXml(xmlDoc, "DPS", "infDPS", signAsSHA256: true, emptyURI: false);
        return xmlDoc;
    }

    /// <summary>
    /// Recepciona a DPS e gera a NFS-e de forma síncrona (POST /nfse).
    /// Padrão canônico de segurança: HOMOLOGAÇÃO.
    /// </summary>
    public virtual async Task<RetornoEnvioDps> EmitirDpsAsync(
        DeclaracaoPrestacaoServico dps,
        Schemas.NFSe.Nacional.Ambiente ambiente = Schemas.NFSe.Nacional.Ambiente.Homologacao,
        CancellationToken ct = default)
    {
        var xmlDocAssinado = AssinarDps(dps);
        var xmlAssinadoString = xmlDocAssinado.OuterXml;

        var gzipBase64 = NfseNacionalCompression.CompressToGZipBase64(xmlAssinadoString);
        var payload = new PedidoEnvioDps(gzipBase64);

        var jsonString = JsonSerializer.Serialize(payload, JsonOptions);
        using var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        using var response = await EnviarAsync(HttpMethod.Post, Endereco(ambiente, "nfse"), content, ct);
        var responseJson = await response.Content.ReadAsStringAsync(ct);

        RetornoEnvioDps retorno;
        try
        {
            retorno = JsonSerializer.Deserialize<RetornoEnvioDps>(responseJson, JsonOptions) ?? new RetornoEnvioDps();
        }
        catch (JsonException)
        {
            retorno = new RetornoEnvioDps
            {
                TipoAmbiente = ambiente,
                DataHoraProcessamento = DateTime.UtcNow,
                Erros = [new MensagemProcessamento(response.StatusCode.ToString(), response.ReasonPhrase ?? "Erro HTTP", responseJson)]
            };
        }

        retorno.StatusCode = (int)response.StatusCode;
        return retorno;
    }

    /// <summary>
    /// Consulta uma NFS-e autorizada no ADN pela Chave de Acesso de 50 dígitos (GET /nfse/{chaveAcesso}).
    /// </summary>
    public virtual async Task<RetornoConsultaNfse> ConsultarNfsePorChaveAsync(
        string chaveAcesso,
        Schemas.NFSe.Nacional.Ambiente ambiente = Schemas.NFSe.Nacional.Ambiente.Homologacao,
        CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(chaveAcesso))
            throw new ArgumentNullException(nameof(chaveAcesso), "A chave de acesso deve ser informada.");

        using var response = await EnviarAsync(HttpMethod.Get, Endereco(ambiente, $"nfse/{chaveAcesso}"), null, ct);
        var responseJson = await response.Content.ReadAsStringAsync(ct);

        RetornoConsultaNfse retorno;
        try
        {
            retorno = JsonSerializer.Deserialize<RetornoConsultaNfse>(responseJson, JsonOptions) ?? new RetornoConsultaNfse();
        }
        catch (JsonException)
        {
            retorno = new RetornoConsultaNfse
            {
                TipoAmbiente = ambiente,
                DataHoraProcessamento = DateTime.UtcNow,
                Erro = new MensagemProcessamento(response.StatusCode.ToString(), response.ReasonPhrase ?? "Erro HTTP", responseJson)
            };
        }

        retorno.StatusCode = (int)response.StatusCode;
        return retorno;
    }

    /// <summary>
    /// Consulta a chave de acesso da NFS-e a partir do identificador da DPS (GET /dps/{id}).
    /// </summary>
    public virtual async Task<RetornoConsultaDps> ConsultarNfsePorDpsAsync(
        string idDps,
        Schemas.NFSe.Nacional.Ambiente ambiente = Schemas.NFSe.Nacional.Ambiente.Homologacao,
        CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(idDps))
            throw new ArgumentNullException(nameof(idDps), "O identificador da DPS deve ser informado.");

        using var response = await EnviarAsync(HttpMethod.Get, Endereco(ambiente, $"dps/{idDps}"), null, ct);
        var responseJson = await response.Content.ReadAsStringAsync(ct);

        RetornoConsultaDps retorno;
        try
        {
            retorno = JsonSerializer.Deserialize<RetornoConsultaDps>(responseJson, JsonOptions) ?? new RetornoConsultaDps();
        }
        catch (JsonException)
        {
            retorno = new RetornoConsultaDps
            {
                TipoAmbiente = ambiente,
                DataHoraProcessamento = DateTime.UtcNow,
                Erro = new MensagemProcessamento(response.StatusCode.ToString(), response.ReasonPhrase ?? "Erro HTTP", responseJson)
            };
        }

        retorno.StatusCode = (int)response.StatusCode;
        return retorno;
    }

    /// <summary>
    /// Retorna o Documento Fiscal de Serviço correspondente ao NSU informado (GET /DFe/{NSU}).
    /// </summary>
    /// <param name="nsu">Número de Sequência Única do Documento Fiscal de Serviço.</param>
    /// <param name="cnpjConsulta">CNPJ da empresa consultada (opcional).</param>
    /// <param name="lote">Indica se a consulta é para um lote de documentos (opcional).</param>
    /// <param name="ambiente">Ambiente de destino (Produção ou Homologação).</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <returns>Resultado da consulta contendo os itens do lote de DFe, alertas e erros.</returns>
    public virtual async Task<RetornoConsultaDfe> ConsultarDfePorNsuAsync(
        long nsu,
        string? cnpjConsulta = null,
        bool? lote = null,
        Schemas.NFSe.Nacional.Ambiente ambiente = Schemas.NFSe.Nacional.Ambiente.Homologacao,
        CancellationToken ct = default)
    {
        var queryParams = new List<string>();
        if (!string.IsNullOrWhiteSpace(cnpjConsulta))
            queryParams.Add($"cnpjConsulta={Uri.EscapeDataString(cnpjConsulta)}");
        if (lote.HasValue && lote == false)
            queryParams.Add($"lote={lote.Value.ToString().ToLowerInvariant()}");

        var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;
        var requestUri = $"DFe/{nsu}{queryString}";

        using var response = await EnviarAsync(HttpMethod.Get, Endereco(ambiente, requestUri, distribuicao: true), null, ct);
        var responseJson = await response.Content.ReadAsStringAsync(ct);

        RetornoConsultaDfe retorno;
        try
        {
            retorno = JsonSerializer.Deserialize<RetornoConsultaDfe>(responseJson, JsonOptions) ?? new RetornoConsultaDfe();
        }
        catch (JsonException)
        {
            retorno = new RetornoConsultaDfe
            {
                TipoAmbiente = ambiente,
                DataHoraProcessamento = DateTime.UtcNow,
                Erros = [new MensagemProcessamento(response.StatusCode.ToString(), response.ReasonPhrase ?? "Erro HTTP", responseJson)]
            };
        }

        retorno.StatusCode = (int)response.StatusCode;
        return retorno;
    }
}
