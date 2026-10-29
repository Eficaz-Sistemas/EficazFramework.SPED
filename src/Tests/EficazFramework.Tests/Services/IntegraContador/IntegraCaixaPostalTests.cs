using EficazFramework.SPED.Schemas.IntegraContador.IntegraCaixaPostal;

#nullable enable

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// Integra-CaixaPostal: MSGCONTRIBUINTE61, MSGDETALHAMENTO62, INNOVAMSG63 e DTE / CONSULTASITUACAODTE111.
/// </summary>
public class IntegraCaixaPostalTests : BaseIntegraContadorTests
{
    private static void VerificarPedido(HandlerFalso handler, string idSistema, string idServico, string endpoint)
    {
        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().Be("https://gateway.apiserpro.serpro.gov.br/integra-contador/v1/" + endpoint);
        pedido.Requisicao.PedidoDados.IdSistema.Should().Be(idSistema);
        pedido.Requisicao.PedidoDados.IdServico.Should().Be(idServico);
        pedido.Requisicao.PedidoDados.VersaoSistema.Should().Be("1.0");
    }

    [Test]
    public async Task ListarMensagens_DeveEnviarCodigosComoTextoELerPagina()
    {
        // exemplo "Consulta de Mensagens por Contribuinte" (primeira mensagem)
        var handler = new HandlerFalso
        {
            Dados = "{\"codigo\":\"00\",\"conteudo\":[{\"quantidadeMensagens\":\"50\",\"indicadorUltimaPagina\":\"N\",\"ponteiroPaginaRetornada\":\"202504080929490000000000\",\"ponteiroProximaPagina\":\"202504030937220000000000\",\"cnpjMatriz\":\"03763656000154\",\"listaMensagens\":[{\"codigoSistemaRemetente\":\"00019\",\"codigoModelo\":\"00007\",\"dataEnvio\":\"20250408\",\"horaEnvio\":\"092949\",\"numeroControle\":\"2025/000000000032113\",\"indicadorLeitura\":\"0\",\"dataLeitura\":\"\",\"horaLeitura\":\"\",\"dataExclusao\":\"\",\"horaExclusao\":\"\",\"dataCiencia\":\"20250423\",\"assuntoModelo\":\"Notificação de recebimento de mensagem e-MAC - Mensagem nº ++VARIAVEL++ (complemento)\",\"dataValidade\":\"20250708\",\"origemModelo\":\"1\",\"valorParametroAssunto\":\"00160556\",\"relevancia\":\"2\",\"isn\":\"0001626772\",\"tipoOrigem\":\"0\",\"descricaoOrigem\":\"RECEITA FEDERAL DO BRASIL\",\"indicadorFavorito\":\"0\"}]}]}"
        };
        using var service = CriarServico(handler);
        var filtro = new ListarMensagens
        {
            CnpjReferencia = "03763656000154",
            StatusLeitura = StatusLeitura.NaoLida,
            IndicadorFavorito = IndicadorFavorito.Favorita,
            IndicadorPagina = IndicadorPagina.NaoInicial,
            PonteiroPagina = "000000000000000000000000"
        };

        var resposta = await service.CaixaPostalListarMensagensAsync(Contribuinte, filtro);

        VerificarPedido(handler, "CAIXAPOSTAL", "MSGCONTRIBUINTE61", "Consultar");
        var dados = DadosEnviados(handler);
        dados.EnumerateObject().Select(p => p.Name).Should().BeEquivalentTo("cnpjReferencia", "statusLeitura", "indicadorFavorito", "indicadorPagina", "ponteiroPagina");
        dados.GetProperty("cnpjReferencia").GetString().Should().Be("03763656000154");
        dados.GetProperty("statusLeitura").GetString().Should().Be("2");
        dados.GetProperty("indicadorFavorito").GetString().Should().Be("1");
        dados.GetProperty("indicadorPagina").GetString().Should().Be("1");
        dados.GetProperty("ponteiroPagina").GetString().Should().Be("000000000000000000000000");

        resposta.Retorno!.Codigo.Should().Be("00");
        var pagina = resposta.Retorno.Conteudo!.Single();
        pagina.QuantidadeMensagens.Should().Be(50);
        pagina.IndicadorUltimaPagina.Should().Be("N");
        pagina.UltimaPagina.Should().BeFalse();
        pagina.PonteiroPaginaRetornada.Should().Be("202504080929490000000000");
        pagina.PonteiroProximaPagina.Should().Be("202504030937220000000000");
        pagina.CnpjMatriz.Should().Be("03763656000154");
        var mensagem = pagina.ListaMensagens!.Single();
        mensagem.CodigoSistemaRemetente.Should().Be("00019");
        mensagem.CodigoModelo.Should().Be("00007");
        mensagem.DataEnvio.Should().Be("20250408");
        mensagem.HoraEnvio.Should().Be("092949");
        mensagem.NumeroControle.Should().Be("2025/000000000032113");
        mensagem.IndicadorLeitura.Should().Be("0");
        mensagem.DataLeitura.Should().BeEmpty();
        mensagem.DataCiencia.Should().Be("20250423");
        mensagem.DataValidade.Should().Be("20250708");
        mensagem.OrigemModelo.Should().Be("1");
        mensagem.Relevancia.Should().Be("2");
        mensagem.Isn.Should().Be("0001626772");
        mensagem.TipoOrigem.Should().Be("0");
        mensagem.DescricaoOrigem.Should().Be("RECEITA FEDERAL DO BRASIL");
        mensagem.IndicadorFavorito.Should().Be("0");
        mensagem.AssuntoFormatado.Should().Be("Notificação de recebimento de mensagem e-MAC - Mensagem nº 00160556 (complemento)");
    }

    [Test]
    public async Task ListarMensagens_SemFiltro_DeveEnviarPaginaInicialDeTodas()
    {
        var handler = new HandlerFalso();
        using var service = CriarServico(handler);

        await service.CaixaPostalListarMensagensAsync(Contribuinte);

        DadosEnviados(handler).GetRawText().Should().Be("{\"statusLeitura\":\"0\",\"indicadorPagina\":\"0\"}");
    }

    [Test]
    public async Task ListarMensagens_DeveAceitarCamposNumericos()
    {
        var handler = new HandlerFalso { Dados = "{\"codigo\":0,\"conteudo\":[{\"quantidadeMensagens\":1,\"indicadorUltimaPagina\":\"S\",\"ponteiroProximaPagina\":20250403093722,\"listaMensagens\":[{\"isn\":1626772,\"indicadorLeitura\":1}]}]}" };
        using var service = CriarServico(handler);

        var resposta = await service.CaixaPostalListarMensagensAsync(Contribuinte);

        resposta.Retorno!.Codigo.Should().Be("0");
        var pagina = resposta.Retorno.Conteudo!.Single();
        pagina.UltimaPagina.Should().BeTrue();
        pagina.PonteiroProximaPagina.Should().Be("20250403093722");
        pagina.ListaMensagens!.Single().Isn.Should().Be("1626772");
        pagina.ListaMensagens!.Single().IndicadorLeitura.Should().Be("1");
    }

    [Test]
    public async Task DetalharMensagem_DeveEnviarIsnELerCorpo()
    {
        var handler = new HandlerFalso
        {
            Dados = "{\"codigo\": \"00\", \"conteudo\": [{\"codigoSistemaRemetente\": \"00014\", \"codigoModelo\": \"00009\", \"assuntoModelo\": \"[e-Processo] Dossiê: ++VARIAVEL++ - Abertura do Dossiê\", \"origemModelo\": \"1\", \"dataEnvio\": \"20220620\", \"valorParametroAssunto\": \"11111.111111/2022-11\", \"dataLeitura\": \"20220623\", \"horaLeitura\": \"170051\", \"dataExpiracao\": \"20230621\", \"numeroControle\": \"\", \"dataCiencia\": \"\", \"enquadramento\": \"0\", \"dataAcessoExterno\": \"\", \"horaAcessoExterno\": \"\", \"tipoAutenticacaoUsuario\": \"0\", \"codigoAcesso\": \"\", \"numeroSerieCertificadoDigital\": \"\", \"emissorCertificadoDigital\": \"\", \"tipoUsuario\": \"0\", \"niUsuario\": \"00000000000000\", \"papelUsuario\": \"0\", \"codigoAplicacao\": \"00000\", \"tipoOrigem\": \"0\", \"descricaoOrigem\": \"\", \"corpoModelo\": \"<p>Atendimento nº ++1++, do dia/hora ++2++ / ++3++ (++12++)</p>\", \"variaveis\": [\"202200000263\", \"20/06/2022\", \"14:31:05\"]}]}"
        };
        using var service = CriarServico(handler);

        var resposta = await service.CaixaPostalDetalharMensagemAsync(Contribuinte, "0001488766");

        VerificarPedido(handler, "CAIXAPOSTAL", "MSGDETALHAMENTO62", "Consultar");
        DadosEnviados(handler).GetRawText().Should().Be("{\"isn\":\"0001488766\"}");

        resposta.Retorno!.Codigo.Should().Be("00");
        var detalhe = resposta.Retorno.Conteudo!.Single();
        detalhe.CodigoSistemaRemetente.Should().Be("00014");
        detalhe.CodigoModelo.Should().Be("00009");
        detalhe.DataEnvio.Should().Be("20220620");
        detalhe.HoraLeitura.Should().Be("170051");
        detalhe.DataExpiracao.Should().Be("20230621");
        detalhe.Enquadramento.Should().Be("0");
        detalhe.TipoAutenticacaoUsuario.Should().Be("0");
        detalhe.NiUsuario.Should().Be("00000000000000");
        detalhe.CodigoAplicacao.Should().Be("00000");
        detalhe.Variaveis.Should().Equal("202200000263", "20/06/2022", "14:31:05");
        detalhe.AssuntoFormatado.Should().Be("[e-Processo] Dossiê: 11111.111111/2022-11 - Abertura do Dossiê");
        detalhe.CorpoFormatado.Should().Be("<p>Atendimento nº 202200000263, do dia/hora 20/06/2022 / 14:31:05 (++12++)</p>");
    }

    [Test]
    public async Task IndicadorNovasMensagens_DeveEnviarDadosVazioELerIndicador()
    {
        var handler = new HandlerFalso { Dados = "{\"codigo\":\"00\",\"conteudo\":[{\"indicadorMensagensNovas\":\"2\"}]}" };
        using var service = CriarServico(handler);

        var resposta = await service.CaixaPostalIndicadorNovasMensagensAsync(Contribuinte);

        VerificarPedido(handler, "CAIXAPOSTAL", "INNOVAMSG63", "Monitorar");
        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().BeEmpty();
        resposta.Retorno!.Codigo.Should().Be("00");
        resposta.Retorno.IndicadorMensagensNovas.Should().Be(IndicadorMensagensNovas.MensagensNovas);
    }

    [Test]
    public async Task DteConsultarSituacao_DeveEnviarDadosVazioELerEnquadramento()
    {
        var handler = new HandlerFalso { Dados = "{\"indicadorEnquadramento\":0,\"statusEnquadramento\":\"CNPJ Optante DTE\"}" };
        using var service = CriarServico(handler);

        var resposta = await service.DteConsultarSituacaoAsync(Contribuinte);

        VerificarPedido(handler, "DTE", "CONSULTASITUACAODTE111", "Consultar");
        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().BeEmpty();
        resposta.Retorno!.IndicadorEnquadramento.Should().Be(IndicadorEnquadramentoDte.OptanteDte);
        resposta.Retorno.StatusEnquadramento.Should().Be("CNPJ Optante DTE");
    }

    [TestCase("-2", IndicadorEnquadramentoDte.NiInvalido)]
    [TestCase("\"-1\"", IndicadorEnquadramentoDte.NaoOptante)]
    [TestCase("2", IndicadorEnquadramentoDte.OptanteDteESimples)]
    public async Task DteConsultarSituacao_DeveLerIndicadorNumericoOuTexto(string json, IndicadorEnquadramentoDte esperado)
    {
        var handler = new HandlerFalso { Dados = $"{{\"indicadorEnquadramento\":{json},\"statusEnquadramento\":\"\"}}" };
        using var service = CriarServico(handler);

        var resposta = await service.DteConsultarSituacaoAsync(Contribuinte);

        resposta.Retorno!.IndicadorEnquadramento.Should().Be(esperado);
    }

    [Test]
    public async Task ArgumentosNulos_DevemLancarArgumentNullException()
    {
        using var service = CriarServico(new HandlerFalso());

        await FluentActions.Awaiting(() => service.CaixaPostalDetalharMensagemAsync(Contribuinte, " ")).Should().ThrowAsync<ArgumentNullException>();
    }
}
