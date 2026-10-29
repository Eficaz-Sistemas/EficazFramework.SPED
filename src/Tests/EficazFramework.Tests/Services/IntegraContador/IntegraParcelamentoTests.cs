using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraParcelamento;

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// Integra-Parcelamento: mapeamento idSistema/idServico das 8 modalidades e (des)serialização dos serviços.
/// </summary>
public class IntegraParcelamentoTests : BaseIntegraContadorTests
{
    private static readonly object[] Modalidades =
    [
        new object[] { ModalidadeParcelamento.PARCSN, "PARCSN", 16 },
        new object[] { ModalidadeParcelamento.PARCSN_ESP, "PARCSN-ESP", 17 },
        new object[] { ModalidadeParcelamento.PERTSN, "PERTSN", 18 },
        new object[] { ModalidadeParcelamento.RELPSN, "RELPSN", 19 },
        new object[] { ModalidadeParcelamento.PARCMEI, "PARCMEI", 20 },
        new object[] { ModalidadeParcelamento.PARCMEI_ESP, "PARCMEI-ESP", 21 },
        new object[] { ModalidadeParcelamento.PERTMEI, "PERTMEI", 22 },
        new object[] { ModalidadeParcelamento.RELPMEI, "RELPMEI", 23 }
    ];

    private static void ValidarPedido(HandlerFalso handler, string endpoint, string idSistema, string idServico)
    {
        var pedido = handler.Chamadas.Last();
        pedido.Url.Should().EndWith("/" + endpoint);
        var requisicao = pedido.Requisicao;
        requisicao.PedidoDados.IdSistema.Should().Be(idSistema);
        requisicao.PedidoDados.IdServico.Should().Be(idServico);
        requisicao.PedidoDados.VersaoSistema.Should().Be("1.0");
    }

    [TestCaseSource(nameof(Modalidades))]
    public async Task GerarDas_DeveEnviarParcelaELerPdf(ModalidadeParcelamento modalidade, string idSistema, int prefixo)
    {
        var handler = new HandlerFalso { Dados = "{\"docArrecadacaoPdfB64\":\"JVBERi0xLjUK\"}" };
        using var service = CriarServico(handler);

        var resposta = await service.ParcelamentoGerarDasAsync(modalidade, Contribuinte, new GerarDasParcela { ParcelaParaEmitir = 202306 });

        ValidarPedido(handler, "Emitir", idSistema, $"GERARDAS{prefixo}1");
        DadosEnviados(handler).GetProperty("parcelaParaEmitir").GetInt32().Should().Be(202306);
        resposta.Retorno!.DocArrecadacaoPdfB64.Should().Be("JVBERi0xLjUK");
    }

    [TestCaseSource(nameof(Modalidades))]
    public async Task ParcelasParaGerar_DeveEnviarSemDadosELerLista(ModalidadeParcelamento modalidade, string idSistema, int prefixo)
    {
        // RELPSN devolve "parcela" como texto no exemplo da documentação
        var handler = new HandlerFalso { Dados = "{\"listaParcelas\":[{\"parcela\":202304,\"valor\":441.83},{\"parcela\":\"202305\",\"valor\":441.83}]}" };
        using var service = CriarServico(handler);

        var resposta = await service.ParcelamentoConsultarParcelasParaGerarAsync(modalidade, Contribuinte);

        ValidarPedido(handler, "Consultar", idSistema, $"PARCELASPARAGERAR{prefixo}2");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().BeEmpty();
        resposta.Retorno!.ListaParcelas.Should().HaveCount(2);
        resposta.Retorno.ListaParcelas![1].Parcela.Should().Be(202305);
        resposta.Retorno.ListaParcelas[1].Valor.Should().Be(441.83m);
    }

    [TestCaseSource(nameof(Modalidades))]
    public async Task Pedidos_DeveEnviarSemDadosELerParcelamentos(ModalidadeParcelamento modalidade, string idSistema, int prefixo)
    {
        var handler = new HandlerFalso { Dados = "{\"parcelamentos\":[{\"numero\":1,\"dataDoPedido\":20160211,\"situacao\":\"Encerrado a Pedido do Contribuinte\",\"dataDaSituacao\":20170125}]}" };
        using var service = CriarServico(handler);

        var resposta = await service.ParcelamentoConsultarPedidosAsync(modalidade, Contribuinte);

        ValidarPedido(handler, "Consultar", idSistema, $"PEDIDOSPARC{prefixo}3");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().BeEmpty();
        var pedido = resposta.Retorno!.Parcelamentos!.Single();
        pedido.Numero.Should().Be(1);
        pedido.DataDoPedido.Should().Be(20160211);
        pedido.Situacao.Should().Be("Encerrado a Pedido do Contribuinte");
        pedido.DataDaSituacao.Should().Be(20170125);
    }

    [TestCaseSource(nameof(Modalidades))]
    public async Task Obter_DeveEnviarNumeroParaOServicoDaModalidade(ModalidadeParcelamento modalidade, string idSistema, int prefixo)
    {
        var handler = new HandlerFalso { Dados = "{\"numero\":9001,\"situacao\":\"Em parcelamento\"}" };
        using var service = CriarServico(handler);

        var resposta = await service.ParcelamentoObterAsync<ParcelamentoOrdinario>(modalidade, Contribuinte, new ConsultaParcelamento { NumeroParcelamento = 9001 });

        ValidarPedido(handler, "Consultar", idSistema, $"OBTERPARC{prefixo}4");
        DadosEnviados(handler).GetProperty("numeroParcelamento").GetInt32().Should().Be(9001);
        resposta.Retorno!.Numero.Should().Be(9001);
    }

    [TestCaseSource(nameof(Modalidades))]
    public async Task DetalhePagamento_DeveEnviarParcelaELerDebitos(ModalidadeParcelamento modalidade, string idSistema, int prefixo)
    {
        var handler = new HandlerFalso
        {
            Dados = "{\"numeroDas\":\"07181817050461249\",\"dataVencimento\":20180629,\"paDasGerado\":201806,\"geradoEm\":\"20180619155840\","
                + "\"numeroParcelamento\":\"9102\",\"numeroParcela\":\"01\",\"dataLimiteAcolhimento\":20180629,"
                + "\"pagamentoDebitos\":[{\"paDebito\":201511,\"processo\":\"\",\"discriminacoesDebito\":["
                + "{\"tributo\":\"IRPJ\",\"principal\":17.11,\"multa\":3.42,\"juros\":4.51,\"total\":25.04,\"enteFederadoDestino\":\"União\"},"
                + "{\"tributo\":\"ISS\",\"principal\":2.80,\"multa\":0.28,\"juros\":0.33,\"total\":3.41,\"enteFederadoDestino\":\"SAO PAULO\"}]}],"
                + "\"dataPagamento\":20180628,\"bancoAgencia\":\"0/49\",\"valorPagoArrecadacao\":334.84}"
        };
        using var service = CriarServico(handler);

        var resposta = await service.ParcelamentoConsultarDetalhePagamentoAsync(modalidade, Contribuinte,
            new ConsultaDetalhePagamento { NumeroParcelamento = 9102, AnoMesParcela = 201806 });

        ValidarPedido(handler, "Consultar", idSistema, $"DETPAGTOPARC{prefixo}5");
        var dados = DadosEnviados(handler);
        dados.GetProperty("numeroParcelamento").GetInt32().Should().Be(9102);
        dados.GetProperty("anoMesParcela").GetInt32().Should().Be(201806);

        var detalhe = resposta.Retorno!;
        detalhe.NumeroDas.Should().Be("07181817050461249");
        detalhe.DataVencimento.Should().Be(20180629);
        detalhe.PaDasGerado.Should().Be(201806);
        detalhe.GeradoEm.Should().Be("20180619155840");
        detalhe.NumeroParcelamento.Should().Be("9102");
        detalhe.NumeroParcela.Should().Be("01");
        detalhe.DataLimiteAcolhimento.Should().Be(20180629);
        detalhe.DataPagamento.Should().Be(20180628);
        detalhe.BancoAgencia.Should().Be("0/49");
        detalhe.ValorPagoArrecadacao.Should().Be(334.84m);
        var debito = detalhe.PagamentoDebitos!.Single();
        debito.PaDebito.Should().Be(201511);
        debito.Processo.Should().BeEmpty();
        debito.DiscriminacoesDebito.Should().HaveCount(2);
        debito.DiscriminacoesDebito![1].Tributo.Should().Be("ISS");
        debito.DiscriminacoesDebito[1].Principal.Should().Be(2.80m);
        debito.DiscriminacoesDebito[1].Multa.Should().Be(0.28m);
        debito.DiscriminacoesDebito[1].Juros.Should().Be(0.33m);
        debito.DiscriminacoesDebito[1].Total.Should().Be(3.41m);
        debito.DiscriminacoesDebito[1].EnteFederadoDestino.Should().Be("SAO PAULO");
    }

    [Test]
    public async Task DetalhePagamento_CamposTextoDevemAceitarNumero()
    {
        // a documentação de algumas modalidades tipa geradoEm/numeroParcelamento como número
        var handler = new HandlerFalso { Dados = "{\"geradoEm\":20161213125856,\"numeroParcelamento\":1,\"numeroParcela\":11}" };
        using var service = CriarServico(handler);

        var resposta = await service.ParcelamentoConsultarDetalhePagamentoAsync(ModalidadeParcelamento.PARCMEI, Contribuinte,
            new ConsultaDetalhePagamento { NumeroParcelamento = 1, AnoMesParcela = 201612 });

        resposta.Retorno!.GeradoEm.Should().Be("20161213125856");
        resposta.Retorno.NumeroParcelamento.Should().Be("1");
        resposta.Retorno.NumeroParcela.Should().Be("11");
    }

    [TestCase(ModalidadeParcelamento.PARCSN)]
    [TestCase(ModalidadeParcelamento.PARCSN_ESP)]
    [TestCase(ModalidadeParcelamento.PARCMEI)]
    [TestCase(ModalidadeParcelamento.PARCMEI_ESP)]
    public async Task ObterOrdinario_DeveLerConsolidacaoEAlteracoes(ModalidadeParcelamento modalidade)
    {
        var handler = new HandlerFalso
        {
            Dados = "{\"numero\":1,\"dataDoPedido\":20160211,\"situacao\":\"Encerrado a Pedido do Contribuinte\",\"dataDaSituacao\":20170125,"
                + "\"consolidacaoOriginal\":{\"valorTotalConsolidado\":5127.39,\"quantidadeParcelas\":17,\"primeiraParcela\":301.61,\"parcelaBasica\":301.61,"
                + "\"dataConsolidacao\":20160211124844,\"detalhesConsolidacao\":[{\"periodoApuracao\":201511,\"vencimento\":20151221,\"numeroProcesso\":\"\","
                + "\"saldoDevedorOriginal\":2296.80,\"valorAtualizado\":2803.42}]},"
                + "\"alteracoesDivida\":[{\"valorTotalConsolidado\":1000.50,\"parcelasRemanescentes\":10,\"parcelaBasica\":100.05,\"dataAlteracaoDivida\":20170101,"
                + "\"detalhesConsolidacao\":[{\"periodoApuracao\":201512}],\"detalhesAlteracaoDivida\":[{\"periodoApuracao\":201601}]}],"
                + "\"demonstrativoPagamentos\":[{\"mesDaParcela\":201602,\"vencimentoDoDas\":20160229,\"dataDeArrecadacao\":20160212,\"valorPago\":301.61}]}"
        };
        using var service = CriarServico(handler);

        var resposta = await service.ParcelamentoObterOrdinarioAsync(modalidade, Contribuinte, new ConsultaParcelamento { NumeroParcelamento = 1 });

        var parc = resposta.Retorno!;
        parc.Numero.Should().Be(1);
        parc.DataDoPedido.Should().Be(20160211);
        parc.Situacao.Should().Be("Encerrado a Pedido do Contribuinte");
        parc.DataDaSituacao.Should().Be(20170125);
        var consolidacao = parc.ConsolidacaoOriginal!;
        consolidacao.ValorTotalConsolidado.Should().Be(5127.39m);
        consolidacao.QuantidadeParcelas.Should().Be(17);
        consolidacao.PrimeiraParcela.Should().Be(301.61m);
        consolidacao.ParcelaBasica.Should().Be(301.61m);
        consolidacao.DataConsolidacao.Should().Be(20160211124844);
        var detalhe = consolidacao.DetalhesConsolidacao!.Single();
        detalhe.PeriodoApuracao.Should().Be(201511);
        detalhe.Vencimento.Should().Be(20151221);
        detalhe.NumeroProcesso.Should().BeEmpty();
        detalhe.SaldoDevedorOriginal.Should().Be(2296.80m);
        detalhe.ValorAtualizado.Should().Be(2803.42m);
        var alteracao = parc.AlteracoesDivida!.Single();
        alteracao.ValorTotalConsolidado.Should().Be(1000.50m);
        alteracao.ParcelasRemanescentes.Should().Be(10);
        alteracao.ParcelaBasica.Should().Be(100.05m);
        alteracao.DataAlteracaoDivida.Should().Be(20170101);
        alteracao.DetalhesConsolidacao!.Single().PeriodoApuracao.Should().Be(201512);
        alteracao.DetalhesAlteracaoDivida!.Single().PeriodoApuracao.Should().Be(201601);
        var pagamento = parc.DemonstrativoPagamentos!.Single();
        pagamento.MesDaParcela.Should().Be(201602);
        pagamento.VencimentoDoDas.Should().Be(20160229);
        pagamento.DataDeArrecadacao.Should().Be(20160212);
        pagamento.ValorPago.Should().Be(301.61m);
    }

    [Test]
    public async Task ObterPertSn_DeveLerLayoutDoPert()
    {
        var handler = new HandlerFalso
        {
            Dados = "{\"numero\":9102,\"dataDoPedido\":20180619,\"situacao\":\"Em parcelamento\",\"dataDaSituacao\":20230831,"
                + "\"consolidacaoOriginal\":{\"valorTotalConsolidadoDaEntrada\":2687.15,\"quantidadeParcelasDeEntrada\":5,\"parcelaDeEntrada\":537.43,"
                + "\"dataConsolidacao\":20180619155825,\"valorConsolidadoDaDivida\":53742.98,\"detalhesConsolidacao\":[{\"periodoApuracao\":201511,"
                + "\"vencimento\":20151221,\"numeroProcesso\":\"\",\"saldoDevedorOriginal\":3156.80,\"valorAtualizado\":4619.91}]},"
                + "\"alteracoesDivida\":[{\"totalConsolidado\":45089.05,\"parcelasRemanescentes\":145,\"parcelaBasica\":310.96,\"dataAlteracaoDivida\":202308311053,"
                + "\"valorConsolidadoPrincipal\":40435.41,\"detalhesAlteracaoDivida\":[{\"periodoApuracao\":201511,\"vencimento\":20151221,"
                + "\"numeroProcesso\":\"12376094286201915\",\"saldoDevedorOriginal\":1679.07,\"valorAtualizado\":1935.42}]}],"
                + "\"demonstrativoPagamentos\":[{\"mesDaParcela\":201806,\"vencimentoDoDas\":20180629,\"dataDeArrecadacao\":20180628,\"valorPago\":537.43}]}"
        };
        using var service = CriarServico(handler);

        var resposta = await service.ParcelamentoObterPertSnAsync(Contribuinte, new ConsultaParcelamento { NumeroParcelamento = 9102 });

        ValidarPedido(handler, "Consultar", "PERTSN", "OBTERPARC184");
        var parc = resposta.Retorno!;
        parc.Numero.Should().Be(9102);
        var consolidacao = parc.ConsolidacaoOriginal!;
        consolidacao.ValorTotalConsolidadoDaEntrada.Should().Be(2687.15m);
        consolidacao.QuantidadeParcelasDeEntrada.Should().Be(5);
        consolidacao.ParcelaDeEntrada.Should().Be(537.43m);
        consolidacao.DataConsolidacao.Should().Be(20180619155825);
        consolidacao.ValorConsolidadoDaDivida.Should().Be(53742.98m);
        consolidacao.DetalhesConsolidacao.Should().HaveCount(1);
        var alteracao = parc.AlteracoesDivida!.Single();
        alteracao.TotalConsolidado.Should().Be(45089.05m);
        alteracao.ParcelasRemanescentes.Should().Be(145);
        alteracao.ParcelaBasica.Should().Be(310.96m);
        alteracao.DataAlteracaoDivida.Should().Be(202308311053);
        alteracao.ValorConsolidadoPrincipal.Should().Be(40435.41m);
        alteracao.DetalhesAlteracaoDivida!.Single().NumeroProcesso.Should().Be("12376094286201915");
        parc.DemonstrativoPagamentos.Should().HaveCount(1);
    }

    [Test]
    public async Task ObterPertMei_DeveLerConsolidacoesDoRestanteDaDivida()
    {
        var handler = new HandlerFalso
        {
            Dados = "{\"numero\":9101,\"dataDoPedido\":20180623,\"situacao\":\"Em parcelamento\",\"dataDaSituacao\":20181119,"
                + "\"consolidacaoOriginal\":{\"valorTotalConsolidadoDaEntrada\":211.48,\"quantidadeParcelasDaEntrada\":4,\"parcelaBasicaDaEntrada\":52.87,"
                + "\"dataConsolidacao\":20180623121350,\"valorTotalConsolidadoDaDivida\":4229.59,\"detalhesConsolidacao\":[{\"periodoApuracao\":201208,"
                + "\"vencimento\":20120920,\"numeroProcesso\":\"\",\"saldoDevedorOriginal\":31.10,\"valorAtualizado\":55.64}]},"
                + "\"consolidacoesRestanteDivida\":[{\"valorTotalConsolidadoDivida\":3145.56,\"parcelasRemanescentes\":62,\"parcelaBasica\":50.73,"
                + "\"dataConfirmacaoConsolidacao\":20181119,\"detalhesConsolidacao\":[{\"periodoApuracao\":201211,\"valorAtualizado\":30.17}]}],"
                + "\"demonstrativoPagamentos\":[]}"
        };
        using var service = CriarServico(handler);

        var resposta = await service.ParcelamentoObterPertMeiAsync(Contribuinte, new ConsultaParcelamento { NumeroParcelamento = 9101 });

        ValidarPedido(handler, "Consultar", "PERTMEI", "OBTERPARC224");
        var parc = resposta.Retorno!;
        var consolidacao = parc.ConsolidacaoOriginal!;
        consolidacao.ValorTotalConsolidadoDaEntrada.Should().Be(211.48m);
        consolidacao.QuantidadeParcelasDaEntrada.Should().Be(4);
        consolidacao.ParcelaBasicaDaEntrada.Should().Be(52.87m);
        consolidacao.DataConsolidacao.Should().Be(20180623121350);
        consolidacao.ValorTotalConsolidadoDaDivida.Should().Be(4229.59m);
        consolidacao.DetalhesConsolidacao!.Single().ValorAtualizado.Should().Be(55.64m);
        var restante = parc.ConsolidacoesRestanteDivida!.Single();
        restante.ValorTotalConsolidadoDivida.Should().Be(3145.56m);
        restante.ParcelasRemanescentes.Should().Be(62);
        restante.ParcelaBasica.Should().Be(50.73m);
        restante.DataConfirmacaoConsolidacao.Should().Be(20181119);
        restante.DetalhesConsolidacao!.Single().ValorAtualizado.Should().Be(30.17m);
        parc.DemonstrativoPagamentos.Should().BeEmpty();
    }

    private const string AlteracaoRelp =
        "{\"dataAlteracaoDivida\":202301201620,\"identificadorConsolidacao\":1,\"saldoDevedorOriginalSemReducoes\":14457.75,"
        + "\"valorRemanescenteComReducoes\":20810.71,\"partePrevidenciaria\":9037.79,\"demaisDebitos\":11778.92,"
        + "\"detalhesConsolidacao\":[{\"periodoApuracao\":201812,\"vencimento\":20190121,\"numeroProcesso\":\"\",\"saldoDevedorOriginal\":8310.35,\"valorAtualizado\":12054.06}],"
        + "\"parcelasAlteracao\":[{\"faixaParcelas\":\"1ª a 12ª\",\"parcelaInicial\":202301,\"vencimentoInicial\":20230131,\"parcelaBasica\":300.00}]}";

    private static void ValidarAlteracaoRelp(AlteracaoDividaRelp alteracao)
    {
        alteracao.DataAlteracaoDivida.Should().Be(202301201620);
        alteracao.IdentificadorConsolidacao.Should().Be(1);
        alteracao.SaldoDevedorOriginalSemReducoes.Should().Be(14457.75m);
        alteracao.ValorRemanescenteComReducoes.Should().Be(20810.71m);
        alteracao.PartePrevidenciaria.Should().Be(9037.79m);
        alteracao.DemaisDebitos.Should().Be(11778.92m);
        alteracao.DetalhesConsolidacao!.Single().SaldoDevedorOriginal.Should().Be(8310.35m);
        var faixa = alteracao.ParcelasAlteracao!.Single();
        faixa.FaixaParcelas.Should().Be("1ª a 12ª");
        faixa.ParcelaInicial.Should().Be(202301);
        faixa.VencimentoInicial.Should().Be(20230131);
        faixa.ParcelaBasica.Should().Be(300.00m);
    }

    [Test]
    public async Task ObterRelpSn_DeveLerLayoutDoRelp()
    {
        var handler = new HandlerFalso
        {
            Dados = "{\"numero\":9131,\"dataDoPedido\":20220520,\"situacao\":\"Em parcelamento\",\"dataDaSituacao\":20230120,"
                + "\"consolidacaoOriginal\":{\"valorTotalConsolidadoDeEntrada\":2801.50,\"quantidadeParcelasDeEntrada\":8,\"parcelaDeEntrada\":350.18,"
                + "\"dataConsolidacao\":20220520164440,\"valorConsolidadoDivida\":22412.05,\"detalhesConsolidacao\":[{\"periodoApuracao\":201812}]},"
                + "\"alteracoesDivida\":[" + AlteracaoRelp + "],\"demonstrativoPagamentos\":[]}"
        };
        using var service = CriarServico(handler);

        var resposta = await service.ParcelamentoObterRelpSnAsync(Contribuinte, new ConsultaParcelamento { NumeroParcelamento = 9131 });

        ValidarPedido(handler, "Consultar", "RELPSN", "OBTERPARC194");
        var consolidacao = resposta.Retorno!.ConsolidacaoOriginal!;
        consolidacao.ValorTotalConsolidadoDeEntrada.Should().Be(2801.50m);
        consolidacao.QuantidadeParcelasDeEntrada.Should().Be(8);
        consolidacao.ParcelaDeEntrada.Should().Be(350.18m);
        consolidacao.DataConsolidacao.Should().Be(20220520164440);
        consolidacao.ValorConsolidadoDivida.Should().Be(22412.05m);
        ValidarAlteracaoRelp(resposta.Retorno.AlteracoesDivida!.Single());
    }

    [Test]
    public async Task ObterRelpMei_DeveLerAlteracoesDividas()
    {
        var handler = new HandlerFalso
        {
            Dados = "{\"numero\":9001,\"dataDoPedido\":20220519,\"situacao\":\"Em parcelamento\",\"dataDaSituacao\":20230406,"
                + "\"consolidacaoOriginal\":{\"valorTotalConsolidadoDeEntrada\":453.85,\"quantidadeParcelasDeEntrada\":8,\"parcelaDeEntrada\":56.73,"
                + "\"dataConsolidacao\":20220519143508,\"detalhesConsolidacao\":[]},"
                + "\"alteracoesDividas\":[" + AlteracaoRelp + "],\"demonstrativoPagamentos\":[]}"
        };
        using var service = CriarServico(handler);

        var resposta = await service.ParcelamentoObterRelpMeiAsync(Contribuinte, new ConsultaParcelamento { NumeroParcelamento = 9001 });

        ValidarPedido(handler, "Consultar", "RELPMEI", "OBTERPARC234");
        var consolidacao = resposta.Retorno!.ConsolidacaoOriginal!;
        consolidacao.ValorTotalConsolidadoDeEntrada.Should().Be(453.85m);
        consolidacao.ParcelaDeEntrada.Should().Be(56.73m);
        consolidacao.ValorConsolidadoDivida.Should().BeNull();
        ValidarAlteracaoRelp(resposta.Retorno.AlteracoesDividas!.Single());
    }

    [TestCase(ModalidadeParcelamento.PARCSN, typeof(ParcelamentoOrdinario))]
    [TestCase(ModalidadeParcelamento.PARCSN_ESP, typeof(ParcelamentoOrdinario))]
    [TestCase(ModalidadeParcelamento.PERTSN, typeof(ParcelamentoPertSn))]
    [TestCase(ModalidadeParcelamento.RELPSN, typeof(ParcelamentoRelpSn))]
    [TestCase(ModalidadeParcelamento.PARCMEI, typeof(ParcelamentoOrdinario))]
    [TestCase(ModalidadeParcelamento.PARCMEI_ESP, typeof(ParcelamentoOrdinario))]
    [TestCase(ModalidadeParcelamento.PERTMEI, typeof(ParcelamentoPertMei))]
    [TestCase(ModalidadeParcelamento.RELPMEI, typeof(ParcelamentoRelpMei))]
    public void TipoParcelamentoDetalhado_DeveCorresponderAModalidade(ModalidadeParcelamento modalidade, Type tipo) =>
        IntegraContadorService.TipoParcelamentoDetalhado(modalidade).Should().Be(tipo);

    [TestCase(ModalidadeParcelamento.PERTSN)]
    [TestCase(ModalidadeParcelamento.PERTMEI)]
    [TestCase(ModalidadeParcelamento.RELPSN)]
    [TestCase(ModalidadeParcelamento.RELPMEI)]
    public async Task ObterOrdinario_ModalidadeComOutroLayout_DeveLancar(ModalidadeParcelamento modalidade)
    {
        var handler = new HandlerFalso();
        using var service = CriarServico(handler);

        await FluentActions.Awaiting(() => service.ParcelamentoObterOrdinarioAsync(modalidade, Contribuinte, new ConsultaParcelamento { NumeroParcelamento = 1 }))
            .Should().ThrowAsync<ArgumentOutOfRangeException>();
        handler.Pedidos.Should().BeEmpty();
    }

    [Test]
    public async Task DadosNulos_DevemLancarArgumentNullException()
    {
        using var service = CriarServico(new HandlerFalso());

        await FluentActions.Awaiting(() => service.ParcelamentoGerarDasAsync(ModalidadeParcelamento.PARCSN, Contribuinte, null!))
            .Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.ParcelamentoObterAsync<ParcelamentoOrdinario>(ModalidadeParcelamento.PARCSN, Contribuinte, null!))
            .Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.ParcelamentoConsultarDetalhePagamentoAsync(ModalidadeParcelamento.PARCSN, Contribuinte, null!))
            .Should().ThrowAsync<ArgumentNullException>();
    }
}
