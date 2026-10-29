using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Services.Primitives;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

/// <summary>
/// Opções de uma requisição à API Integra Contador; os valores nulos usam os padrões do serviço.
/// </summary>
/// <param name="Ambiente">Ambiente da requisição (padrão: <see cref="IntegraContadorService.Ambiente"/>).</param>
/// <param name="AutorPedidoDados">Autor do pedido de dados (padrão: <see cref="IntegraContadorService.AutorPedidoDados"/> ou o contratante).</param>
/// <param name="TokenProcurador">Token do procurador, cabeçalho <c>autenticar_procurador_token</c> (padrão: <see cref="IntegraContadorService.TokenProcurador"/>).</param>
/// <param name="RequestTag">Identificador livre da requisição (até 32 caracteres), cabeçalho <c>X-Request-Tag</c>.</param>
public sealed record OpcoesRequisicao(
    Ambiente? Ambiente = null,
    Identificacao? AutorPedidoDados = null,
    string? TokenProcurador = null,
    string? RequestTag = null);

/// <summary>
/// Serviço de comunicação REST com a API Integra Contador (SERPRO): autenticação na Loja Serpro (OAuth2
/// client_credentials com mTLS do e-CNPJ do contratante) e chamada dos serviços dos endpoints
/// Apoiar, Consultar, Declarar, Emitir e Monitorar.
/// </summary>
/// <remarks>
/// <para>Use uma instância por certificado (contratante) e descarte-a ao terminar (<see cref="RestServiceBase.Dispose()"/>):
/// o cliente HTTP é criado na primeira requisição e reutilizado (URLs completas, sem <c>BaseAddress</c>).</para>
/// <para>Os tokens temporários são obtidos na primeira requisição, mantidos em memória e renovados antes de expirar
/// (ou ao receber HTTP 401).</para>
/// <para>Erros HTTP não lançam exceção: o retorno traz <see cref="RespostaIntegraContador.StatusCode"/> e as mensagens.</para>
/// </remarks>
public partial class IntegraContadorService : RestServiceBase
{
    private readonly SemaphoreSlim _travaToken = new(1, 1);

    /// <summary>Cria o serviço; o certificado é obtido por <see cref="ServiceBase.SelecionaCertificado"/> na primeira requisição.</summary>
    public IntegraContadorService() : base() { }

    /// <summary>Cria o serviço com um handler HTTP próprio (testes, proxy); o certificado não é anexado ao handler.</summary>
    /// <param name="handler">Handler usado pelo cliente HTTP (não é descartado pelo serviço).</param>
    public IntegraContadorService(HttpMessageHandler handler) : base(handler) { }

    /// <summary>Consumer Key do contrato na Loja Serpro (área do cliente).</summary>
    public string? ConsumerKey { get; set; }

    /// <summary>Consumer Secret do contrato na Loja Serpro (área do cliente).</summary>
    public string? ConsumerSecret { get; set; }

    /// <summary>Contratante do produto (CNPJ do certificado digital usado no mTLS).</summary>
    public Identificacao? Contratante { get; set; }

    /// <summary>Autor do pedido de dados padrão; quando nulo, é o próprio <see cref="Contratante"/>.</summary>
    public Identificacao? AutorPedidoDados { get; set; }

    /// <summary>Token do procurador padrão (ver <see cref="AutenticarProcuradorAsync"/>).</summary>
    public string? TokenProcurador { get; set; }

    /// <summary>Ambiente padrão das requisições.</summary>
    public Ambiente Ambiente { get; set; } = Ambiente.Producao;

    /// <summary>URL de autenticação da Loja Serpro.</summary>
    public Uri UrlAutenticacao { get; set; } = new("https://autenticacao.sapi.serpro.gov.br/authenticate");

    /// <summary>URL base da API em Produção.</summary>
    public Uri UrlProducao { get; set; } = new("https://gateway.apiserpro.serpro.gov.br/integra-contador/v1/");

    /// <summary>URL base da API de demonstração (Trial).</summary>
    public Uri UrlTrial { get; set; } = new("https://gateway.apiserpro.serpro.gov.br/integra-contador-trial/v1/");

    /// <summary>Token Bearer fixo do ambiente de demonstração (Trial).</summary>
    public string TokenTrial { get; set; } = "06aef429-a981-3ec5-a1f8-71d38d86481e";

    /// <summary>Antecedência com que o token é renovado antes de expirar (padrão 60 s).</summary>
    public TimeSpan MargemRenovacaoToken { get; set; } = TimeSpan.FromSeconds(60);

    /// <summary>Tokens temporários atuais (obtidos por <see cref="AutenticarAsync"/>); pode ser atribuído para reaproveitar tokens.</summary>
    public TokenAutenticacao? Token { get; set; }

    /// <summary>Opções JSON para corpo da requisição/resposta e para o conteúdo de <c>dados</c>.</summary>
    protected static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    /// <summary>URL completa do endpoint no ambiente.</summary>
    /// <param name="ambiente">Produção ou Trial.</param>
    /// <param name="endpoint">Endpoint do serviço.</param>
    protected virtual Uri Endereco(Ambiente ambiente, TipoEndpoint endpoint) =>
        new(ambiente == Ambiente.Trial ? UrlTrial : UrlProducao, endpoint.ToString());


    // AUTENTICAÇÃO

    /// <summary>
    /// Obtém os tokens temporários (access_token e jwt_token) na Loja Serpro, reaproveitando o token atual enquanto válido.
    /// </summary>
    /// <param name="forcar">Ignora o token atual e solicita um novo.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Consumer Key/Secret ou certificado digital não informados.</exception>
    /// <exception cref="UnauthorizedAccessException">A Loja Serpro recusou as credenciais.</exception>
    public async Task<TokenAutenticacao> AutenticarAsync(bool forcar = false, CancellationToken ct = default)
    {
        if (!forcar && Token is { } atual && !atual.Expirado(MargemRenovacaoToken))
            return atual;

        if (string.IsNullOrWhiteSpace(ConsumerKey) || string.IsNullOrWhiteSpace(ConsumerSecret))
            throw new ArgumentNullException(nameof(ConsumerKey), "Consumer Key e Consumer Secret da Loja Serpro devem ser informados.");

        var tokenAnterior = Token;
        await _travaToken.WaitAsync(ct);
        try
        {
            // outra chamada pode ter renovado o token enquanto esta aguardava
            if (Token is { } renovado && !ReferenceEquals(renovado, tokenAnterior) && !renovado.Expirado(MargemRenovacaoToken))
                return renovado;

            using var request = new HttpRequestMessage(HttpMethod.Post, UrlAutenticacao)
            {
                Content = new FormUrlEncodedContent([new("grant_type", "client_credentials")])
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ConsumerKey}:{ConsumerSecret}")));
            request.Headers.Add("Role-Type", "TERCEIROS");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var response = await ObterHttpClient().SendAsync(request, ct);
            var resultString = await response.Content.ReadAsStringAsync(ct);
            Logger?.LogDebug($"Integra Contador Services: Autenticação{Environment.NewLine}Status Code: {(int)response.StatusCode}");

            if (!response.IsSuccessStatusCode)
                throw new UnauthorizedAccessException($"A autenticação na Loja Serpro foi recusada (HTTP {(int)response.StatusCode}). Detalhes: {(string.IsNullOrEmpty(resultString) ? response.ReasonPhrase : resultString)}");

            var token = JsonSerializer.Deserialize<TokenAutenticacao>(resultString, JsonOptions);
            if (token is null || string.IsNullOrEmpty(token.AccessToken))
                throw new UnauthorizedAccessException($"A Loja Serpro não retornou o token de acesso. Detalhes: {resultString}");

            token.ObtidoEm = DateTimeOffset.UtcNow;
            Token = token;
            return token;
        }
        finally
        {
            _travaToken.Release();
        }
    }


    // EXECUÇÃO DOS SERVIÇOS

    /// <summary>
    /// Executa um serviço do catálogo, serializando <paramref name="dados"/> e desserializando o retorno em <typeparamref name="TRetorno"/>.
    /// </summary>
    /// <typeparam name="TDados">Tipo dos dados de entrada (<see cref="string"/> é enviado como JSON já serializado).</typeparam>
    /// <typeparam name="TRetorno">Tipo do retorno (<see cref="string"/> mantém o conteúdo bruto, ex.: PDF em Base64).</typeparam>
    /// <param name="servico">Serviço do <see cref="Catalogo"/>.</param>
    /// <param name="contribuinte">Contribuinte a que se referem os dados.</param>
    /// <param name="dados">Dados de entrada do serviço (nulo quando o serviço não tem entrada).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual async Task<RespostaIntegraContador<TRetorno>> ExecutarAsync<TDados, TRetorno>(
        ServicoIntegraContador servico,
        Identificacao contribuinte,
        TDados? dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        var dadosJson = dados switch
        {
            null => string.Empty,
            string s => s,
            _ => JsonSerializer.Serialize(dados, JsonOptions)
        };

        var resposta = await EnviarServicoAsync<RespostaIntegraContador<TRetorno>>(servico, contribuinte, dadosJson, opcoes, ct);
        resposta.Retorno = LerDados<TRetorno>(resposta);
        return resposta;
    }

    /// <summary>
    /// Executa um serviço do catálogo sem tipagem: <paramref name="dadosJson"/> é enviado como está e o retorno
    /// fica em <see cref="RespostaIntegraContador.Dados"/>.
    /// </summary>
    /// <param name="servico">Serviço do <see cref="Catalogo"/>.</param>
    /// <param name="contribuinte">Contribuinte a que se referem os dados.</param>
    /// <param name="dadosJson">Dados de entrada já serializados em JSON (vazio quando o serviço não tem entrada).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador> ExecutarAsync(
        ServicoIntegraContador servico,
        Identificacao contribuinte,
        string? dadosJson,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        EnviarServicoAsync<RespostaIntegraContador>(servico, contribuinte, dadosJson ?? string.Empty, opcoes, ct);

    /// <summary>
    /// Monta o corpo, envia ao endpoint do serviço (renovando o token uma vez em caso de HTTP 401) e lê o envelope de resposta.
    /// </summary>
    protected async Task<TResposta> EnviarServicoAsync<TResposta>(
        ServicoIntegraContador servico,
        Identificacao contribuinte,
        string dadosJson,
        OpcoesRequisicao? opcoes,
        CancellationToken ct) where TResposta : RespostaIntegraContador, new()
    {
        //! validações iniciais:
        if (servico is null)
            throw new ArgumentNullException(nameof(servico), "O serviço a ser executado não foi informado.");

        if (contribuinte is null)
            throw new ArgumentNullException(nameof(contribuinte), "O contribuinte da requisição não foi informado.");

        if (Contratante is null)
            throw new ArgumentNullException(nameof(Contratante), "O contratante do produto Integra Contador não foi informado.");

        if (opcoes?.RequestTag is { Length: > 32 })
            throw new ArgumentOutOfRangeException(nameof(opcoes), "O X-Request-Tag deve ter no máximo 32 caracteres.");

        var ambiente = opcoes?.Ambiente ?? Ambiente;
        var requisicao = new RequisicaoIntegraContador
        {
            Contratante = Contratante,
            AutorPedidoDados = opcoes?.AutorPedidoDados ?? AutorPedidoDados ?? Contratante,
            Contribuinte = contribuinte,
            PedidoDados = new()
            {
                IdSistema = servico.IdSistema,
                IdServico = servico.IdServico,
                VersaoSistema = servico.VersaoSistema,
                Dados = dadosJson
            }
        };
        var json = JsonSerializer.Serialize(requisicao, JsonOptions);
        Logger?.LogDebug($"Integra Contador Services: POST {servico.Endpoint} Request{Environment.NewLine}{json}");

        // o token do procurador não é aceito no endpoint Apoiar
        var tokenProcurador = servico.Endpoint == TipoEndpoint.Apoiar ? null : opcoes?.TokenProcurador ?? TokenProcurador;

        var response = await PostAsync(ambiente, servico.Endpoint, json, tokenProcurador, opcoes?.RequestTag, false, ct);
        if (response.StatusCode == HttpStatusCode.Unauthorized && ambiente == Ambiente.Producao)
        {
            response.Dispose();
            response = await PostAsync(ambiente, servico.Endpoint, json, tokenProcurador, opcoes?.RequestTag, true, ct);
        }

        using (response)
        {
            var resultString = await response.Content.ReadAsStringAsync(ct);
            Logger?.LogDebug($"Integra Contador Services: POST {servico.Endpoint} Response{Environment.NewLine}Status Code: {(int)response.StatusCode}{Environment.NewLine}Result:{Environment.NewLine}{resultString}");

            TResposta resposta;
            if (string.IsNullOrWhiteSpace(resultString))
                resposta = new TResposta();
            else
            {
                try
                {
                    resposta = JsonSerializer.Deserialize<TResposta>(resultString, JsonOptions) ?? new TResposta();
                }
                catch (JsonException)
                {
                    resposta = new TResposta
                    {
                        Mensagens = [new Mensagem(((int)response.StatusCode).ToString(), $"{response.ReasonPhrase}: {resultString}")]
                    };
                }
            }

            resposta.StatusCode = (int)response.StatusCode;
            resposta.ETag = response.Headers.ETag?.Tag
                ?? (response.Headers.TryGetValues("etag", out var etag) ? etag.FirstOrDefault() : null);
            resposta.Expires = response.Content.Headers.Expires;
            return resposta;
        }
    }

    /// <summary>
    /// Envia o POST ao endpoint com os cabeçalhos de autenticação (Bearer e jwt_token) e os opcionais.
    /// </summary>
    private async Task<HttpResponseMessage> PostAsync(
        Ambiente ambiente,
        TipoEndpoint endpoint,
        string json,
        string? tokenProcurador,
        string? requestTag,
        bool renovarToken,
        CancellationToken ct)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, Endereco(ambiente, endpoint))
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        if (ambiente == Ambiente.Trial)
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", TokenTrial);
        else
        {
            var token = await AutenticarAsync(renovarToken, ct);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            if (!string.IsNullOrEmpty(token.JwtToken))
                request.Headers.TryAddWithoutValidation("jwt_token", token.JwtToken);
        }

        if (!string.IsNullOrWhiteSpace(tokenProcurador))
            request.Headers.TryAddWithoutValidation("autenticar_procurador_token", tokenProcurador);

        if (!string.IsNullOrWhiteSpace(requestTag))
            request.Headers.TryAddWithoutValidation("X-Request-Tag", requestTag);

        return await ObterHttpClient().SendAsync(request, ct);
    }

    /// <summary>
    /// Desserializa o conteúdo de <c>dados</c>; <see cref="string"/> mantém o conteúdo bruto.
    /// Conteúdo que não é JSON válido para o tipo é mantido apenas em <see cref="RespostaIntegraContador.Dados"/>.
    /// </summary>
    protected T? LerDados<T>(RespostaIntegraContador resposta)
    {
        if (string.IsNullOrWhiteSpace(resposta.Dados))
            return default;

        if (typeof(T) == typeof(string))
            return (T)(object)resposta.Dados;

        try
        {
            return JsonSerializer.Deserialize<T>(resposta.Dados, JsonOptions);
        }
        catch (JsonException ex)
        {
            Logger?.LogWarning(ex, "Integra Contador Services: não foi possível interpretar o conteúdo de 'dados' como {Tipo}.", typeof(T).Name);
            return default;
        }
    }
}
