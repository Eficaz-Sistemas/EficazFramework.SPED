using EficazFramework.SPED.Schemas.IntegraContador;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// Base dos testes do <see cref="IntegraContadorService"/>: handler falso (sem rede) e certificado de teste.
/// </summary>
public class BaseIntegraContadorTests : Tests.BaseTest
{
    internal const string CnpjContratante = "99999999999999";
    internal const string TokenJson = "{\"expires_in\":2008,\"scope\":\"default\",\"token_type\":\"Bearer\",\"access_token\":\"af012866-daae-3aef-8b40-bd14e8cfac99\",\"jwt_token\":\"eyJhbGciOi.jwt\"}";

    /// <summary>Requisição registrada pelo <see cref="HandlerFalso"/>.</summary>
    internal sealed record Pedido(HttpMethod Metodo, string Url, Dictionary<string, string> Cabecalhos, string? Corpo)
    {
        public string? Cabecalho(string nome) => Cabecalhos.TryGetValue(nome, out var valor) ? valor : null;

        /// <summary>Corpo desserializado como requisição do Integra Contador.</summary>
        public RequisicaoIntegraContador Requisicao => JsonSerializer.Deserialize<RequisicaoIntegraContador>(Corpo!)!;
    }

    /// <summary>
    /// Registra as requisições; responde o token em /authenticate e, nos endpoints, a resposta configurada
    /// (padrão: envelope 200 com <see cref="Dados"/>).
    /// </summary>
    internal sealed class HandlerFalso : HttpMessageHandler
    {
        public List<Pedido> Pedidos { get; } = [];

        /// <summary>Conteúdo do campo <c>dados</c> da resposta padrão (já como string JSON).</summary>
        public string Dados { get; set; } = "";

        /// <summary>Respostas dos endpoints, consumidas em ordem; vazia usa a resposta padrão.</summary>
        public Queue<Func<HttpResponseMessage>> Respostas { get; } = new();

        public Func<HttpResponseMessage> RespostaAutenticacao { get; set; } = () => Json(HttpStatusCode.OK, TokenJson);

        public IEnumerable<Pedido> Autenticacoes => Pedidos.Where(p => p.Url.EndsWith("/authenticate"));

        public IEnumerable<Pedido> Chamadas => Pedidos.Where(p => !p.Url.EndsWith("/authenticate"));

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var cabecalhos = request.Headers.ToDictionary(h => h.Key, h => string.Join(",", h.Value), StringComparer.OrdinalIgnoreCase);
            if (request.Content is not null)
                foreach (var h in request.Content.Headers)
                    cabecalhos[h.Key] = string.Join(",", h.Value);

            var corpo = request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken);
            Pedidos.Add(new Pedido(request.Method, request.RequestUri!.ToString(), cabecalhos, corpo));

            if (request.RequestUri!.AbsolutePath.EndsWith("/authenticate"))
                return RespostaAutenticacao();

            if (Respostas.Count > 0)
                return Respostas.Dequeue()();

            return Envelope(200, Dados);
        }

        public static HttpResponseMessage Json(HttpStatusCode status, string json) =>
            new(status) { Content = new StringContent(json, Encoding.UTF8, "application/json") };

        /// <summary>Envelope de resposta do Integra Contador com o <c>dados</c> informado.</summary>
        public static HttpResponseMessage Envelope(int status, string dados, string codigo = "Sucesso-TESTE", string texto = "Requisição efetuada com sucesso.") =>
            Json((HttpStatusCode)status, JsonSerializer.Serialize(new
            {
                status,
                dados,
                mensagens = new[] { new { codigo, texto } }
            }));
    }

    /// <summary>Serviço configurado com o handler falso, credenciais e contratante de teste.</summary>
    internal IntegraContadorService CriarServico(HandlerFalso handler) => new(handler)
    {
        SelecionaCertificado = InstanciaCertificado,
        ConsumerKey = "chave",
        ConsumerSecret = "segredo",
        Contratante = Identificacao.Cnpj(CnpjContratante)
    };

    /// <summary>Contribuinte de teste.</summary>
    internal static Identificacao Contribuinte => Identificacao.Cnpj("00000000000100");

    /// <summary>
    /// Define o certificado digital a ser utilizado nas requests.
    /// </summary>
    internal Func<Utilities.IcpBrasilX509Certificate2> InstanciaCertificado => () =>
        new Utilities.IcpBrasilX509Certificate2(Resources.Certificados.WayneEnterprisesInc, "1234");

    /// <summary>Desserializa o <c>dados</c> enviado na última chamada.</summary>
    internal static JsonElement DadosEnviados(HandlerFalso handler) =>
        JsonDocument.Parse(handler.Chamadas.Last().Requisicao.PedidoDados.Dados).RootElement;
}
