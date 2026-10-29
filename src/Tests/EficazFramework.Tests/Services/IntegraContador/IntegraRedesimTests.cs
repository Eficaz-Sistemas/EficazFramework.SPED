using EficazFramework.SPED.Schemas.IntegraContador.IntegraRedesim;

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// PNRCONTADOR (Integra-Redesim): vínculos, solicitação/situação de renúncia, consulta de renúncias e comprovante.
/// </summary>
public class IntegraRedesimTests : BaseIntegraContadorTests
{
    private const string IdSolicitacao = "PNRCONTADOR-20250212-af81730aeb29c9fdac15";

    private static void ValidarPedido(HandlerFalso handler, string endpoint, string idServico)
    {
        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().EndWith("/" + endpoint);
        pedido.Requisicao.PedidoDados.IdSistema.Should().Be("PNRCONTADOR");
        pedido.Requisicao.PedidoDados.IdServico.Should().Be(idServico);
        pedido.Requisicao.PedidoDados.VersaoSistema.Should().Be("1.0");
    }

    [Test]
    public async Task ConsultarVinculos_DeveEnviarPaginacaoELerEmpresas()
    {
        var handler = new HandlerFalso
        {
            Dados = "{\"cnpjs\":[{\"cnpj\":\"99999999999999\",\"tipoEstabelecimento\":\"Matriz\",\"situacaoCadastral\":{\"codigo\":\"02\",\"descricao\":\"Ativa\"},"
                + "\"uf\":\"BA\",\"codigoMunicipio\":\"3287\",\"nomeMunicipio\":null}],\"totalInThePage\":1,\"totalInTheDatabase\":16,\"lastCnpj\":\"99999999999999\"}"
        };
        using var service = CriarServico(handler);

        var resposta = await service.PnrContadorConsultarVinculosAsync(Contribuinte, new ConsultaVinculos { Pagination = { Size = 50 } });

        ValidarPedido(handler, "Consultar", "CONSVINCULOS261");
        var paginacao = DadosEnviados(handler).GetProperty("pagination");
        paginacao.GetProperty("size").GetInt32().Should().Be(50);
        paginacao.TryGetProperty("lastCnpj", out _).Should().BeFalse("o cursor é opcional na primeira requisição");

        var pagina = resposta.Retorno!;
        pagina.TotalInThePage.Should().Be(1);
        pagina.TotalInTheDatabase.Should().Be(16);
        pagina.LastCnpj.Should().Be("99999999999999");
        var empresa = pagina.Cnpjs!.Single();
        empresa.Cnpj.Should().Be("99999999999999");
        empresa.TipoEstabelecimento.Should().Be("Matriz");
        empresa.SituacaoCadastral!.Codigo.Should().Be("02");
        empresa.SituacaoCadastral.Descricao.Should().Be("Ativa");
        empresa.Uf.Should().Be("BA");
        empresa.CodigoMunicipio.Should().Be("3287");
        empresa.NomeMunicipio.Should().BeNull();
    }

    [Test]
    public async Task ConsultarVinculos_DeveEnviarCursor()
    {
        var handler = new HandlerFalso();
        using var service = CriarServico(handler);

        await service.PnrContadorConsultarVinculosAsync(Contribuinte, new ConsultaVinculos { Pagination = { Size = 5, LastCnpj = "99999999999999" } });

        DadosEnviados(handler).GetProperty("pagination").GetProperty("lastCnpj").GetString().Should().Be("99999999999999");
    }

    [Test]
    public async Task SolicitarRenuncia_DeveEnviarSolicitacaoELerId()
    {
        var handler = new HandlerFalso { Dados = $"{{\"idSolicitacao\": \"{IdSolicitacao}\"}}" };
        using var service = CriarServico(handler);

        var resposta = await service.PnrContadorSolicitarRenunciaAsync(Contribuinte, new SolicitacaoRenuncia
        {
            SolicitacaoRenunciaContador = new DadosSolicitacaoRenuncia
            {
                Cnpj = "99999999999999",
                CpfContador = "00000000011",
                CpfPreenchedor = "00000000011"
            },
            CienciaDeclaracoes = true
        });

        ValidarPedido(handler, "Declarar", "SOLICRENUNCIA262");
        var dados = DadosEnviados(handler);
        dados.GetProperty("cienciaDeclaracoes").GetBoolean().Should().BeTrue();
        var solicitacao = dados.GetProperty("solicitacaoRenunciaContador");
        solicitacao.GetProperty("cnpj").GetString().Should().Be("99999999999999");
        solicitacao.GetProperty("cpfContador").GetString().Should().Be("00000000011");
        solicitacao.GetProperty("cpfPreenchedor").GetString().Should().Be("00000000011");
        solicitacao.TryGetProperty("cnpjEmpresaContabil", out _).Should().BeFalse();
        resposta.Retorno!.IdSolicitacao.Should().Be(IdSolicitacao);
    }

    [Test]
    public async Task ConsultarRenuncias_DeveEnviarPeriodoELerPagina()
    {
        var handler = new HandlerFalso
        {
            Dados = "{\"content\":[{\"id\":1234,\"cnpjRenunciada\":\"99999999999999\",\"dataRenuncia\":\"1739242800000\",\"cnpjSolicitante\":null,"
                + "\"cnpjRenunciante\":null,\"cpfSolicitante\":\"00000000011\",\"cpfRenunciante\":\"00000000011\",\"cpfLogado\":\"00000000011\"}],"
                + "\"pageable\":{\"pageNumber\":0,\"pageSize\":10,\"sort\":{\"sorted\":false,\"empty\":true,\"unsorted\":true},\"offset\":0,\"paged\":true,\"unpaged\":false},"
                + "\"last\":false,\"totalElements\":1,\"totalPages\":1,\"size\":10,\"number\":0,\"sort\":{\"sorted\":false,\"empty\":true,\"unsorted\":true},"
                + "\"numberOfElements\":1,\"first\":true,\"empty\":false}"
        };
        using var service = CriarServico(handler);

        var resposta = await service.PnrContadorConsultarRenunciasAsync(Contribuinte,
            ConsultaRenuncias.Periodo(new DateTime(2025, 1, 1), new DateTime(2025, 2, 28), 0, 10));

        ValidarPedido(handler, "Consultar", "CONSRENUNCIA263");
        var dados = DadosEnviados(handler);
        dados.GetProperty("dtInicio").GetString().Should().Be("2025-01-01");
        dados.GetProperty("dtFim").GetString().Should().Be("2025-02-28");
        dados.GetProperty("page").GetInt32().Should().Be(0);
        dados.GetProperty("pageSize").GetInt32().Should().Be(10);

        var pagina = resposta.Retorno!;
        pagina.Empty.Should().BeFalse();
        pagina.First.Should().BeTrue();
        pagina.Last.Should().BeFalse();
        pagina.Number.Should().Be(0);
        pagina.NumberOfElements.Should().Be(1);
        pagina.Size.Should().Be(10);
        pagina.TotalElements.Should().Be(1);
        pagina.TotalPages.Should().Be(1);
        pagina.Sort!.Unsorted.Should().BeTrue();
        pagina.Pageable!.PageSize.Should().Be(10);
        pagina.Pageable.Offset.Should().Be(0);
        pagina.Pageable.Paged.Should().BeTrue();
        pagina.Pageable.Unpaged.Should().BeFalse();
        pagina.Pageable.Sort!.Empty.Should().BeTrue();
        var renuncia = pagina.Content!.Single();
        renuncia.Id.Should().Be(1234);
        renuncia.CnpjRenunciada.Should().Be("99999999999999");
        renuncia.DataRenuncia.Should().Be(1739242800000);
        renuncia.DataRenunciaUtc.Should().Be(DateTimeOffset.FromUnixTimeMilliseconds(1739242800000));
        renuncia.CnpjSolicitante.Should().BeNull();
        renuncia.CpfSolicitante.Should().Be("00000000011");
        renuncia.CpfRenunciante.Should().Be("00000000011");
        renuncia.CpfLogado.Should().Be("00000000011");
    }

    [Test]
    public async Task ConsultarRenuncias_SemFiltro_DeveEnviarObjetoVazio()
    {
        var handler = new HandlerFalso();
        using var service = CriarServico(handler);

        await service.PnrContadorConsultarRenunciasAsync(Contribuinte);

        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().Be("{}");
    }

    [Test]
    public async Task EmitirComprovante_DeveEnviarIdELerPdf()
    {
        var handler = new HandlerFalso { Dados = "JVBERi0xLjMK" };
        using var service = CriarServico(handler);

        var resposta = await service.PnrContadorEmitirComprovanteAsync(Contribuinte, new EmissaoComprovanteRenuncia { IdRenuncia = 2558 });

        ValidarPedido(handler, "Emitir", "COMPRENUNCIA264");
        DadosEnviados(handler).GetProperty("idRenuncia").GetInt64().Should().Be(2558);
        resposta.Retorno.Should().Be("JVBERi0xLjMK");
    }

    [Test]
    public async Task SituacaoSolicitacao_DeveEnviarIdELerRenuncia()
    {
        var handler = new HandlerFalso
        {
            Dados = "{\"resultado\":true,\"mensagemRetorno\":\"Sua renúncia à empresa 99999999999999 foi efetuada com sucesso!\","
                + "\"renuncia\":{\"id\":123,\"cnpjRenunciada\":\"99999999999999\",\"dataRenuncia\":\"1740682249338\",\"cnpjSolicitante\":null,"
                + "\"cnpjRenunciante\":null,\"cpfSolicitante\":\"00000000011\",\"cpfRenunciante\":\"00000000011\",\"cpfLogado\":\"00000000011\"}}"
        };
        using var service = CriarServico(handler);

        var resposta = await service.PnrContadorSituacaoSolicitacaoAsync(Contribuinte, new ConsultaSituacaoRenuncia { IdSolicitacao = IdSolicitacao });

        ValidarPedido(handler, "Consultar", "SITSOLICRENUNCIA265");
        DadosEnviados(handler).GetProperty("idSolicitacao").GetString().Should().Be(IdSolicitacao);
        resposta.Retorno!.Resultado.Should().BeTrue();
        resposta.Retorno.MensagemRetorno.Should().StartWith("Sua renúncia");
        resposta.Retorno.Renuncia!.Id.Should().Be(123);
        resposta.Retorno.Renuncia.DataRenuncia.Should().Be(1740682249338);
    }

    [Test]
    public async Task SituacaoSolicitacao_NaoEfetivada_DeveTerRenunciaNula()
    {
        var handler = new HandlerFalso { Dados = "{\"resultado\":false,\"mensagemRetorno\":\"Em processamento\",\"renuncia\":null}" };
        using var service = CriarServico(handler);

        var resposta = await service.PnrContadorSituacaoSolicitacaoAsync(Contribuinte, new ConsultaSituacaoRenuncia { IdSolicitacao = IdSolicitacao });

        resposta.Retorno!.Resultado.Should().BeFalse();
        resposta.Retorno.Renuncia.Should().BeNull();
    }

    [Test]
    public async Task DadosInvalidos_DevemLancarArgumentNullException()
    {
        var handler = new HandlerFalso();
        using var service = CriarServico(handler);

        await FluentActions.Awaiting(() => service.PnrContadorConsultarVinculosAsync(Contribuinte, null!))
            .Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.PnrContadorSolicitarRenunciaAsync(Contribuinte, new SolicitacaoRenuncia()))
            .Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.PnrContadorEmitirComprovanteAsync(Contribuinte, null!))
            .Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.PnrContadorSituacaoSolicitacaoAsync(Contribuinte, new ConsultaSituacaoRenuncia()))
            .Should().ThrowAsync<ArgumentNullException>();
        handler.Pedidos.Should().BeEmpty();
    }
}
