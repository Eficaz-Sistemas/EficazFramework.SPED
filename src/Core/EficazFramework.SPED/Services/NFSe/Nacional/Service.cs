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
public class NfseNacionalService : RestServiceBase
{
    public NfseNacionalService() : base(requerCertificado: true) { }

    /// <summary>
    /// URL base para o ambiente de Produção do ADN.
    /// </summary>
    public Uri UrlProducao { get; set; } = new("https://sefin.nfse.gov.br/");

    /// <summary>
    /// URL base para o ambiente de Homologação / Produção Restrita do ADN.
    /// </summary>
    public Uri UrlHomologacao { get; set; } = new("https://sefin.producaorestrita.nfse.gov.br/SefinNacional/");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>
    /// Configura o certificado digital no HttpClientHandler e define a BaseAddress de acordo com o ambiente.
    /// </summary>
    protected virtual void PrepareClient(Schemas.NFSe.Nacional.Ambiente  ambiente)
    {
        if (!ValidaCertificado())
            throw new ArgumentNullException(nameof(Certificado), "Nenhum certificado digital ICP-Brasil válido foi fornecido para a requisição.");

        HttpClientHandler.ClientCertificates.Clear();
        HttpClientHandler.ClientCertificates.Add(Certificado);

        HttpClient.BaseAddress = ambiente == Ambiente.Producao ? UrlProducao : UrlHomologacao;

        HttpClient.DefaultRequestHeaders.Clear();
        HttpClient.DefaultRequestHeaders.Accept.Clear();
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
        PrepareClient(ambiente);

        var xmlDocAssinado = AssinarDps(dps);
        var xmlAssinadoString = xmlDocAssinado.OuterXml;

        var gzipBase64 = NfseNacionalCompression.CompressToGZipBase64(xmlAssinadoString);
        var payload = new PedidoEnvioDps(gzipBase64);

        var jsonString = JsonSerializer.Serialize(payload, JsonOptions);
        using var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var response = await HttpClient.PostAsync("nfse", content, ct);
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

        PrepareClient(ambiente);

        var response = await HttpClient.GetAsync($"nfse/{chaveAcesso}", ct);
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

        PrepareClient(ambiente);

        var response = await HttpClient.GetAsync($"dps/{idDps}", ct);
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
        PrepareClient(ambiente);

        var queryParams = new List<string>();
        if (!string.IsNullOrWhiteSpace(cnpjConsulta))
            queryParams.Add($"cnpjConsulta={Uri.EscapeDataString(cnpjConsulta)}");
        if (lote.HasValue)
            queryParams.Add($"lote={lote.Value.ToString().ToLowerInvariant()}");

        var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;
        var requestUri = $"DFe/{nsu}{queryString}";

        var response = await HttpClient.GetAsync(requestUri, ct);
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
