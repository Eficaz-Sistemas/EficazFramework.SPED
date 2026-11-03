using EficazFramework.SPED.Schemas.IntegraContador;
using System.Net;
using System.Net.Http;

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// Autenticação, envelope e cabeçalhos do <see cref="IntegraContadorService"/>, sem rede (handler falso).
/// </summary>
public class ServicoTests : BaseIntegraContadorTests
{
    private sealed record RetornoTeste(string? Valor, int Numero);

    [Test]
    public async Task Autenticacao_DeveEnviarBasicRoleTypeEFormulario()
    {
        var handler = new HandlerFalso();
        using var service = CriarServico(handler);

        var token = await service.AutenticarAsync();

        var pedido = handler.Autenticacoes.Single();
        pedido.Metodo.Should().Be(HttpMethod.Post);
        pedido.Url.Should().Be("https://autenticacao.sapi.serpro.gov.br/authenticate");
        pedido.Cabecalho("Authorization").Should().Be("Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("chave:segredo")));
        pedido.Cabecalho("Role-Type").Should().Be("TERCEIROS");
        pedido.Cabecalho("Content-Type").Should().StartWith("application/x-www-form-urlencoded");
        pedido.Corpo.Should().Be("grant_type=client_credentials");

        token.AccessToken.Should().Be("af012866-daae-3aef-8b40-bd14e8cfac99");
        token.JwtToken.Should().Be("eyJhbGciOi.jwt");
        token.ExpiresIn.Should().Be(2008);
        token.Expirado(TimeSpan.Zero).Should().BeFalse();
    }

    [Test]
    public async Task Token_DeveSerReaproveitadoERenovadoQuandoExpirado()
    {
        var handler = new HandlerFalso();
        using var service = CriarServico(handler);

        await service.ExecutarAsync(Catalogo.Pgdasd.GerarDas, Contribuinte, "{}");
        await service.ExecutarAsync(Catalogo.Pgdasd.GerarDas, Contribuinte, "{}");
        handler.Autenticacoes.Should().HaveCount(1);

        service.Token!.ObtidoEm = DateTimeOffset.UtcNow.AddHours(-1);
        await service.ExecutarAsync(Catalogo.Pgdasd.GerarDas, Contribuinte, "{}");
        handler.Autenticacoes.Should().HaveCount(2);
    }

    [Test]
    public async Task Status401_DeveRenovarTokenERepetirUmaVez()
    {
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() => HandlerFalso.Json(HttpStatusCode.Unauthorized, ""));
        using var service = CriarServico(handler);

        var resposta = await service.ExecutarAsync(Catalogo.Pgdasd.GerarDas, Contribuinte, "{}");

        resposta.StatusCode.Should().Be(200);
        handler.Autenticacoes.Should().HaveCount(2);
        handler.Chamadas.Should().HaveCount(2);
    }

    [Test]
    public async Task AutenticacaoRecusada_DeveLancarUnauthorized()
    {
        var handler = new HandlerFalso { RespostaAutenticacao = () => HandlerFalso.Json(HttpStatusCode.Unauthorized, "{\"error\":\"invalid_client\"}") };
        using var service = CriarServico(handler);

        await FluentActions.Awaiting(() => service.ExecutarAsync(Catalogo.Pgdasd.GerarDas, Contribuinte, "{}"))
            .Should().ThrowAsync<UnauthorizedAccessException>().WithMessage("*invalid_client*");
        handler.Chamadas.Should().BeEmpty();
    }

    [Test]
    public async Task Requisicao_DeveMontarEnvelopeECabecalhos()
    {
        var handler = new HandlerFalso();
        using var service = CriarServico(handler);

        await service.ExecutarAsync<object, string>(Catalogo.Pgdasd.GerarDas, Contribuinte,
            new { periodoApuracao = "202401" },
            new OpcoesRequisicao(TokenProcurador: "b06feea3-1ca8-49f4-bdb4-211ab006cb92", RequestTag: "TAG1"));

        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().Be("https://gateway.apiserpro.serpro.gov.br/integra-contador/v1/Emitir");
        pedido.Cabecalho("Authorization").Should().Be("Bearer af012866-daae-3aef-8b40-bd14e8cfac99");
        pedido.Cabecalho("jwt_token").Should().Be("eyJhbGciOi.jwt");
        pedido.Cabecalho("autenticar_procurador_token").Should().Be("b06feea3-1ca8-49f4-bdb4-211ab006cb92");
        pedido.Cabecalho("X-Request-Tag").Should().Be("TAG1");
        pedido.Cabecalho("Content-Type").Should().StartWith("application/json");

        var requisicao = pedido.Requisicao;
        requisicao.Contratante.Should().Be(Identificacao.Cnpj(CnpjContratante));
        requisicao.AutorPedidoDados.Should().Be(Identificacao.Cnpj(CnpjContratante));
        requisicao.Contribuinte.Should().Be(Contribuinte);
        requisicao.PedidoDados.IdSistema.Should().Be("PGDASD");
        requisicao.PedidoDados.IdServico.Should().Be("GERARDAS12");
        requisicao.PedidoDados.VersaoSistema.Should().Be("1.0");
        requisicao.PedidoDados.Dados.Should().Be("{\"periodoApuracao\":\"202401\"}");
        pedido.Corpo.Should().Contain("\"tipo\":2");
    }

    [Test]
    public async Task EndpointApoiar_NaoDeveEnviarTokenProcurador()
    {
        var handler = new HandlerFalso();
        using var service = CriarServico(handler);
        service.TokenProcurador = "b06feea3-1ca8-49f4-bdb4-211ab006cb92";

        await service.ExecutarAsync(Catalogo.Sitfis.SolicitarProtocolo, Contribuinte, null);
        await service.ExecutarAsync(Catalogo.Sitfis.EmitirRelatorio, Contribuinte, null);

        handler.Chamadas.First().Url.Should().EndWith("/Apoiar");
        handler.Chamadas.First().Cabecalho("autenticar_procurador_token").Should().BeNull();
        handler.Chamadas.Last().Cabecalho("autenticar_procurador_token").Should().Be("b06feea3-1ca8-49f4-bdb4-211ab006cb92");
    }

    [Test]
    public async Task Trial_DeveUsarTokenFixoSemAutenticar()
    {
        var handler = new HandlerFalso();
        using var service = CriarServico(handler);
        service.Ambiente = Ambiente.Trial;

        await service.ExecutarAsync(Catalogo.Ccmei.Emitir, Contribuinte, null);

        handler.Autenticacoes.Should().BeEmpty();
        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().Be("https://gateway.apiserpro.serpro.gov.br/integra-contador-trial/v1/Emitir");
        pedido.Cabecalho("Authorization").Should().Be("Bearer 06aef429-a981-3ec5-a1f8-71d38d86481e");
        pedido.Cabecalho("jwt_token").Should().BeNull();
        pedido.Requisicao.PedidoDados.Dados.Should().BeEmpty();
    }

    [Test]
    public async Task Resposta_DeveDesserializarDadosEMensagens()
    {
        var handler = new HandlerFalso { Dados = "{\"valor\":\"abc\",\"numero\":\"10\"}" };
        using var service = CriarServico(handler);

        var resposta = await service.ExecutarAsync<object, RetornoTeste>(Catalogo.Pgdasd.GerarDas, Contribuinte, null);

        resposta.Sucesso.Should().BeTrue();
        resposta.Status.Should().Be(200);
        resposta.Mensagens!.Single().Codigo.Should().Be("Sucesso-TESTE");
        resposta.Dados.Should().Be("{\"valor\":\"abc\",\"numero\":\"10\"}");
        resposta.Retorno.Should().Be(new RetornoTeste("abc", 10));
    }

    [Test]
    public async Task Resposta_DadosComoObjetoOuBase64()
    {
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() => HandlerFalso.Json(HttpStatusCode.OK, "{\"status\":\"200\",\"dados\":{\"valor\":\"x\",\"numero\":1},\"mensagens\":[]}"));
        handler.Respostas.Enqueue(() => HandlerFalso.Envelope(200, "JVBERi0xLjQ="));
        using var service = CriarServico(handler);

        var objeto = await service.ExecutarAsync<object, RetornoTeste>(Catalogo.Pgdasd.GerarDas, Contribuinte, null);
        var base64 = await service.ExecutarAsync<object, string>(Catalogo.PagtoWeb.EmitirComprovante, Contribuinte, null);

        objeto.Status.Should().Be(200);
        objeto.Retorno.Should().Be(new RetornoTeste("x", 1));
        base64.Retorno.Should().Be("JVBERi0xLjQ=");
    }

    [Test]
    public async Task RespostaDeErro_NaoDeveLancar()
    {
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() => HandlerFalso.Envelope(403, "", "[AcessoNegado-ICGERENCIADOR-022]", "Procuração inexistente"));
        handler.Respostas.Enqueue(() => HandlerFalso.Json(HttpStatusCode.BadGateway, "<html>Bad gateway</html>"));
        using var service = CriarServico(handler);

        var negado = await service.ExecutarAsync<object, RetornoTeste>(Catalogo.Pgdasd.GerarDas, Contribuinte, null);
        var gateway = await service.ExecutarAsync(Catalogo.Pgdasd.GerarDas, Contribuinte, null);

        negado.Sucesso.Should().BeFalse();
        negado.StatusCode.Should().Be(403);
        negado.Retorno.Should().BeNull();
        negado.Mensagens!.Single().Codigo.Should().Be("[AcessoNegado-ICGERENCIADOR-022]");

        gateway.StatusCode.Should().Be(502);
        gateway.Mensagens!.Single().Texto.Should().Contain("Bad gateway");
    }

    [Test]
    public async Task Status204_DeveLerETag()
    {
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() =>
        {
            var r = new HttpResponseMessage(HttpStatusCode.NoContent);
            r.Headers.TryAddWithoutValidation("ETag", "\"tempoEspera:5000\"");
            return r;
        });
        using var service = CriarServico(handler);

        var resposta = await service.ExecutarAsync(Catalogo.Sitfis.EmitirRelatorio, Contribuinte, "{}");

        resposta.StatusCode.Should().Be(204);
        resposta.Sucesso.Should().BeTrue();
        resposta.ETag.Should().Contain("tempoEspera:5000");
    }

    [Test]
    public async Task Validacoes_DevemLancarAntesDeEnviar()
    {
        var handler = new HandlerFalso();
        using var semContratante = CriarServico(handler);
        semContratante.Contratante = null;
        using var semCredenciais = CriarServico(handler);
        semCredenciais.ConsumerKey = null;
        using var semCertificado = new IntegraContadorService(handler) { ConsumerKey = "a", ConsumerSecret = "b", Contratante = Identificacao.Cnpj(CnpjContratante) };
        using var service = CriarServico(handler);

        await FluentActions.Awaiting(() => semContratante.ExecutarAsync(Catalogo.Pgdasd.GerarDas, Contribuinte, null))
            .Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => semCredenciais.ExecutarAsync(Catalogo.Pgdasd.GerarDas, Contribuinte, null))
            .Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => semCertificado.ExecutarAsync(Catalogo.Pgdasd.GerarDas, Contribuinte, null))
            .Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.ExecutarAsync(Catalogo.Pgdasd.GerarDas, Contribuinte, null, new OpcoesRequisicao(RequestTag: new string('X', 33))))
            .Should().ThrowAsync<ArgumentOutOfRangeException>();
        handler.Pedidos.Should().BeEmpty();
    }

    [Test]
    public async Task Descartado_DeveLancarObjectDisposed()
    {
        var service = CriarServico(new HandlerFalso());
        service.Dispose();

        await FluentActions.Awaiting(() => service.ExecutarAsync(Catalogo.Pgdasd.GerarDas, Contribuinte, null))
            .Should().ThrowAsync<ObjectDisposedException>();
    }

    [Test]
    public void Catalogo_Parcelamento_DeveMontarCodigosDaModalidade()
    {
        var relpmei = Catalogo.Parcelamento.Servicos(ModalidadeParcelamento.RELPMEI);
        relpmei.GerarDas.Should().Be(new ServicoIntegraContador("RELPMEI", "GERARDAS231", "1.0", TipoEndpoint.Emitir));
        relpmei.DetalhePagamento.IdServico.Should().Be("DETPAGTOPARC235");

        var parcsnEsp = Catalogo.Parcelamento.Servicos(ModalidadeParcelamento.PARCSN_ESP);
        parcsnEsp.ObterParcelamento.Should().Be(new ServicoIntegraContador("PARCSN-ESP", "OBTERPARC174", "1.0", TipoEndpoint.Consultar));
    }
}
