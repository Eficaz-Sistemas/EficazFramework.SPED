using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.Gerenciador;

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// EVENTOSATUALIZACAO: solicitação (lote de NIs) e obtenção (matriz NI x data) dos eventos de atualização.
/// </summary>
public class EventosAtualizacaoTests : BaseIntegraContadorTests
{
    private const string Protocolo = "a65f3455-fa91-419b-b0ad-c4ac50695abf";

    [Test]
    public async Task SolicitarPF_DeveEnviarLoteTipo3ELerProtocolo()
    {
        var handler = new HandlerFalso { Dados = $"{{\"protocolo\":\"{Protocolo}\",\"TempoEsperaMedioEmMs\":5000,\"TempoLimiteEmMin\":20}}" };
        using var service = CriarServico(handler);

        var resposta = await service.EventosSolicitarPFAsync(["00000000000", "11111111111"], CodigoEventoAtualizacao.DctfWeb);

        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().EndWith("/Monitorar");
        var requisicao = pedido.Requisicao;
        requisicao.PedidoDados.IdSistema.Should().Be("EVENTOSATUALIZACAO");
        requisicao.PedidoDados.IdServico.Should().Be("SOLICEVENTOSPF131");
        requisicao.Contribuinte.Should().Be(new Identificacao("00000000000,11111111111", TipoIdentificacao.LotePF));
        pedido.Corpo.Should().Contain("\"tipo\":3");
        DadosEnviados(handler).GetProperty("evento").GetString().Should().Be("E0301");

        resposta.Retorno!.Protocolo.Should().Be(Protocolo);
        resposta.Retorno.TempoEsperaMedioEmMs.Should().Be(5000);
        resposta.Retorno.TempoLimiteEmMin.Should().Be(20);
    }

    [Test]
    public async Task SolicitarPJ_DeveEnviarLoteTipo4()
    {
        var handler = new HandlerFalso { Dados = $"{{\"protocolo\":\"{Protocolo}\",\"TempoEsperaMedioEmMs\":3000,\"TempoLimiteEmMin\":20}}" };
        using var service = CriarServico(handler);

        var resposta = await service.EventosSolicitarPJAsync(["00000000000000", " 11111111111111 ", ""], CodigoEventoAtualizacao.CaixaPostal);

        var requisicao = handler.Chamadas.Single().Requisicao;
        requisicao.PedidoDados.IdServico.Should().Be("SOLICEVENTOSPJ132");
        requisicao.Contribuinte.Should().Be(new Identificacao("00000000000000,11111111111111", TipoIdentificacao.LotePJ));
        DadosEnviados(handler).GetProperty("evento").GetString().Should().Be("E0601");
        resposta.Retorno!.TempoEsperaMedioEmMs.Should().Be(3000);
    }

    [Test]
    public async Task ObterPF_DeveEnviarNumeroVazioELerMatriz()
    {
        var handler = new HandlerFalso { Dados = "[[\"00000000000\",\"\"],[\"11111111111\",\"230407\"],[\"22222222222\",\"230408\"],[\"33333333333\",\"x\"]]" };
        using var service = CriarServico(handler);

        var resposta = await service.EventosObterPFAsync(Protocolo, CodigoEventoAtualizacao.DctfWeb);

        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().EndWith("/Monitorar");
        pedido.Requisicao.PedidoDados.IdServico.Should().Be("OBTEREVENTOSPF133");
        pedido.Requisicao.Contribuinte.Should().Be(new Identificacao("", TipoIdentificacao.LotePF));
        pedido.Corpo.Should().Contain("\"contribuinte\":{\"numero\":\"\",\"tipo\":3}");
        var dados = DadosEnviados(handler);
        dados.GetProperty("protocolo").GetString().Should().Be(Protocolo);
        dados.GetProperty("evento").GetString().Should().Be("E0301");

        var eventos = resposta.Retorno!;
        eventos.Select(e => e.Ni).Should().Equal("00000000000", "11111111111", "22222222222", "33333333333");
        eventos[0].SemAtualizacao.Should().BeTrue();
        eventos[0].DataEvento.Should().BeNull();
        eventos[1].Data.Should().Be("230407");
        eventos[1].DataEvento.Should().Be(new DateTime(2023, 4, 7));
        eventos[1].SemAtualizacao.Should().BeFalse();
        eventos[1].AcessoNegado.Should().BeFalse();
        eventos[3].AcessoNegado.Should().BeTrue();
        eventos[3].DataEvento.Should().BeNull();
    }

    [Test]
    public async Task ObterPJ_DeveEnviarTipo4()
    {
        var handler = new HandlerFalso { Dados = "[[\"11111111111111\",\"230327\"]]" };
        using var service = CriarServico(handler);

        var resposta = await service.EventosObterPJAsync(Protocolo, CodigoEventoAtualizacao.Pagamento);

        var requisicao = handler.Chamadas.Single().Requisicao;
        requisicao.PedidoDados.IdServico.Should().Be("OBTEREVENTOSPJ134");
        requisicao.Contribuinte.Should().Be(new Identificacao("", TipoIdentificacao.LotePJ));
        DadosEnviados(handler).GetProperty("evento").GetString().Should().Be("E0701");
        resposta.Retorno!.Single().DataEvento.Should().Be(new DateTime(2023, 3, 27));
    }

    [Test]
    public void LoteEventos_DeveValidarQuantidadeETipo()
    {
        FluentActions.Invoking(() => IntegraContadorService.LoteEventos(null!, TipoIdentificacao.LotePF)).Should().Throw<ArgumentNullException>();
        FluentActions.Invoking(() => IntegraContadorService.LoteEventos([], TipoIdentificacao.LotePF)).Should().Throw<ArgumentOutOfRangeException>();
        FluentActions.Invoking(() => IntegraContadorService.LoteEventos(Enumerable.Repeat("00000000000", 1001), TipoIdentificacao.LotePF))
            .Should().Throw<ArgumentOutOfRangeException>();
        FluentActions.Invoking(() => IntegraContadorService.LoteEventos(["00000000000"], TipoIdentificacao.CPF)).Should().Throw<ArgumentOutOfRangeException>();

        IntegraContadorService.LoteEventos(Enumerable.Repeat("00000000000", 1000), TipoIdentificacao.LotePF).Numero.Split(',').Should().HaveCount(1000);
    }

    [Test]
    public async Task DadosInvalidos_DevemLancarArgumentNullException()
    {
        var handler = new HandlerFalso();
        using var service = CriarServico(handler);

        await FluentActions.Awaiting(() => service.EventosSolicitarPFAsync(Contribuinte, new SolicitacaoEventos()))
            .Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.EventosObterPJAsync("", CodigoEventoAtualizacao.DctfWeb))
            .Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.EventosObterPJAsync(Protocolo, ""))
            .Should().ThrowAsync<ArgumentNullException>();
        handler.Pedidos.Should().BeEmpty();
    }
}
