using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using EficazFramework.SPED.Schemas.NFSe.Nacional;
using EficazFramework.SPED.Services.Primitives;

namespace EficazFramework.SPED.Services.NFSe.Nacional;

/// <summary>
/// Serviço de comunicação REST com o Ambiente de Dados Nacional (ADN) da NFS-e (Sefin Nacional / Receita Federal / Serpro).
/// Suporta emissão de DPS com assinatura digital XMLDSig RSA-SHA256, consulta de NFS-e, download de DANFSE e eventos de cancelamento.
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
    public Uri UrlHomologacao { get; set; } = new("https://hom-nfse.receita.fazenda.gov.br/");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>
    /// Configura o certificado digital no HttpClientHandler e define a BaseAddress de acordo com o ambiente.
    /// </summary>
    protected virtual void PrepareClient(TipoAmbienteEnum ambiente)
    {
        if (!ValidaCertificado())
            throw new ArgumentNullException(nameof(Certificado), "Nenhum certificado digital ICP-Brasil válido foi fornecido para a requisição.");

        HttpClientHandler.ClientCertificates.Clear();
        HttpClientHandler.ClientCertificates.Add(Certificado);

        HttpClient.BaseAddress = ambiente == TipoAmbienteEnum.PRODUCAO ? UrlProducao : UrlHomologacao;

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
    /// Emite uma Declaração de Prestação de Serviço (DPS) enviando-a assinada e comprimida (GZip Base64) ao ADN.
    /// Padrão canônico de segurança: HOMOLOGAÇÃO.
    /// </summary>
    public virtual async Task<RetornoProcessamento> EmitirDpsAsync(
        DeclaracaoPrestacaoServico dps,
        TipoAmbienteEnum ambiente = TipoAmbienteEnum.HOMOLOGACAO,
        CancellationToken ct = default)
    {
        PrepareClient(ambiente);

        var xmlDocAssinado = AssinarDps(dps);
        var xmlAssinadoString = xmlDocAssinado.OuterXml;

        var gzipBase64 = NfseNacionalCompression.CompressToGZipBase64(xmlAssinadoString);
        var payload = new PedidoEnvioDps(gzipBase64);

        var jsonString = JsonSerializer.Serialize(payload, JsonOptions);
        using var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var response = await HttpClient.PostAsync("dps", content, ct);
        var responseJson = await response.Content.ReadAsStringAsync(ct);

        RetornoProcessamento? retorno = null;
        try
        {
            retorno = JsonSerializer.Deserialize<RetornoProcessamento>(responseJson, JsonOptions);
        }
        catch (JsonException)
        {
            // Se o retorno não for o JSON esperado (ex: erro HTTP puro)
            retorno = new RetornoProcessamento(
                StatusProcessamento: StatusProcessamentoEnum.REJEICAO,
                LoteDFe: [],
                Alertas: [],
                Erros: [new MensagemProcessamento(responseJson, [], response.StatusCode.ToString(), response.ReasonPhrase ?? "Erro HTTP", "")],
                TipoAmbiente: ambiente,
                VersaoAplicativo: "1.0",
                DataHoraProcessamento: DateTime.UtcNow
            );
        }

        if (retorno?.LoteDFe != null)
        {
            for (int i = 0; i < retorno.LoteDFe.Count; i++)
            {
                var item = retorno.LoteDFe[i];
                var xmlDecomp = NfseNacionalCompression.DecompressFromGZipBase64(item.ArquivoXml);
                retorno.LoteDFe[i] = item with { ArquivoXml = xmlDecomp };
            }
        }

        return retorno!;
    }

    /// <summary>
    /// Consulta uma NFS-e autorizada no ADN pela Chave de Acesso (50 dígitos).
    /// </summary>
    public virtual async Task<RetornoProcessamento> ConsultarNfsePorChaveAsync(
        string chaveAcesso,
        TipoAmbienteEnum ambiente = TipoAmbienteEnum.HOMOLOGACAO,
        CancellationToken ct = default)
    {
        PrepareClient(ambiente);

        var response = await HttpClient.GetAsync($"nfse/{chaveAcesso}", ct);
        var responseJson = await response.Content.ReadAsStringAsync(ct);

        RetornoProcessamento? retorno = null;
        try
        {
            retorno = JsonSerializer.Deserialize<RetornoProcessamento>(responseJson, JsonOptions);
        }
        catch (JsonException)
        {
            retorno = new RetornoProcessamento(
                StatusProcessamento: StatusProcessamentoEnum.NENHUM_DOCUMENTO_LOCALIZADO,
                LoteDFe: [],
                Alertas: [],
                Erros: [new MensagemProcessamento(responseJson, [], response.StatusCode.ToString(), response.ReasonPhrase ?? "Documento não localizado", "")],
                TipoAmbiente: ambiente,
                VersaoAplicativo: "1.0",
                DataHoraProcessamento: DateTime.UtcNow
            );
        }

        if (retorno?.LoteDFe != null)
        {
            for (int i = 0; i < retorno.LoteDFe.Count; i++)
            {
                var item = retorno.LoteDFe[i];
                var xmlDecomp = NfseNacionalCompression.DecompressFromGZipBase64(item.ArquivoXml);
                retorno.LoteDFe[i] = item with { ArquivoXml = xmlDecomp };
            }
        }

        return retorno!;
    }

    /// <summary>
    /// Efetua o download do arquivo binário PDF do DANFSE gerado pelo ADN para uma NFS-e autorizada.
    /// </summary>
    public virtual async Task<byte[]> ObterDanfseAsync(
        string chaveAcesso,
        TipoAmbienteEnum ambiente = TipoAmbienteEnum.HOMOLOGACAO,
        CancellationToken ct = default)
    {
        PrepareClient(ambiente);

        HttpClient.DefaultRequestHeaders.Accept.Clear();
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/pdf"));

        var response = await HttpClient.GetAsync($"danfse/{chaveAcesso}", ct);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsByteArrayAsync(ct);
    }

    /// <summary>
    /// Envia um pedido de cancelamento de NFS-e ao ADN.
    /// </summary>
    public virtual async Task<RetornoProcessamento> CancelarNfseAsync(
        string chaveAcesso,
        string codigoMotivo,
        string justificativa,
        TipoAmbienteEnum ambiente = TipoAmbienteEnum.HOMOLOGACAO,
        CancellationToken ct = default)
    {
        PrepareClient(ambiente);

        var payload = new
        {
            chaveAcesso,
            codigoMotivo,
            justificativa
        };

        var jsonString = JsonSerializer.Serialize(payload, JsonOptions);
        using var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var response = await HttpClient.PostAsync($"nfse/{chaveAcesso}/eventos", content, ct);
        var responseJson = await response.Content.ReadAsStringAsync(ct);

        RetornoProcessamento? retorno = null;
        try
        {
            retorno = JsonSerializer.Deserialize<RetornoProcessamento>(responseJson, JsonOptions);
        }
        catch (JsonException)
        {
            retorno = new RetornoProcessamento(
                StatusProcessamento: StatusProcessamentoEnum.REJEICAO,
                LoteDFe: [],
                Alertas: [],
                Erros: [new MensagemProcessamento(responseJson, [], response.StatusCode.ToString(), response.ReasonPhrase ?? "Erro ao cancelar", "")],
                TipoAmbiente: ambiente,
                VersaoAplicativo: "1.0",
                DataHoraProcessamento: DateTime.UtcNow
            );
        }

        return retorno!;
    }
}
