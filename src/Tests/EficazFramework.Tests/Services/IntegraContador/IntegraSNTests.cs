using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraSN;
using System.Text.Json;

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// Integra-SN (PGDASD, Regime de Apuração e DEFIS): endpoint, identificação do serviço, campos enviados e
/// desserialização dos exemplos de retorno da documentação.
/// </summary>
public class IntegraSNTests : BaseIntegraContadorTests
{
    private const string PdfBase64 = "JVBERi0xLjQK";

    /// <summary>Verifica endpoint e identificação do serviço na última chamada.</summary>
    private static void VerificarPedido(HandlerFalso handler, string endpoint, string idSistema, string idServico)
    {
        var pedido = handler.Chamadas.Last();
        pedido.Url.Should().Be("https://gateway.apiserpro.serpro.gov.br/integra-contador/v1/" + endpoint);
        pedido.Requisicao.PedidoDados.IdSistema.Should().Be(idSistema);
        pedido.Requisicao.PedidoDados.IdServico.Should().Be(idServico);
        pedido.Requisicao.PedidoDados.VersaoSistema.Should().Be("1.0");
    }

    private static string[] Nomes(JsonElement elemento) => [.. elemento.EnumerateObject().Select(p => p.Name)];

    #region PGDASD

    [Test]
    public async Task Pgdasd_TransmitirDeclaracao()
    {
        var handler = new HandlerFalso
        {
            Dados = $$$"""
                {"idDeclaracao":"00000000202104001","dataHoraTransmissao":"20220803044803",
                 "valoresDevidos":[{"codigoTributo":1001,"valor":44.00},{"codigoTributo":1007,"valor":272.00}],
                 "declaracao":"{{{PdfBase64}}}","recibo":"{{{PdfBase64}}}","notificacaoMaed":"{{{PdfBase64}}}","darf":"{{{PdfBase64}}}",
                 "detalhamentoDarfMaed":{"periodoApuracao":"20210601","numeroDocumento":null,"dataVencimento":"20220902","dataLimiteAcolhimento":"20220902",
                   "valores":{"principal":25.00,"multa":0.00,"juros":0.00,"total":25.00},
                   "observacao1":"DARF válido para pagamento até o vencimento","observacao2":"PGDAS-D v2.1.6","observacao3":null,"composicao":null}}
                """
        };
        using var service = CriarServico(handler);

        var resposta = await service.PgdasdTransmitirDeclaracaoAsync(Contribuinte, new TransmitirDeclaracao
        {
            CnpjCompleto = "00000000000100",
            Pa = 202101,
            IndicadorTransmissao = true,
            IndicadorComparacao = true,
            Declaracao = new DeclaracaoPgdasd
            {
                TipoDeclaracao = 1,
                ReceitaPaCompetenciaInterno = 10000m,
                ReceitaPaCompetenciaExterno = 0m,
                ValorFixoIcms = 100m,
                ReceitasBrutasAnteriores = [new ReceitaBrutaAnterior { Pa = 202001, ValorInterno = 100m, ValorExterno = 200m }],
                FolhasSalario = [new FolhaSalario { Pa = 202001, Valor = 2000m }],
                NaoOptante = new NaoOptante { EsferaAdm = "1", Uf = "SP", CodMunicipio = "7107", Processo = "123" },
                Estabelecimentos =
                [
                    new Estabelecimento
                    {
                        CnpjCompleto = "00000000000100",
                        Atividades =
                        [
                            new Atividade
                            {
                                IdAtividade = 1,
                                ValorAtividade = 4000m,
                                ReceitasAtividade =
                                [
                                    new ReceitaAtividade
                                    {
                                        Valor = 4000m,
                                        CodigoOutroMunicipio = 9701,
                                        OutraUf = "DF",
                                        Isencoes = [new Isencao { CodTributo = 1007, Valor = 100m, Identificador = 1 }],
                                        Reducoes = [new Reducao { CodTributo = 1007, Valor = 1500m, PercentualReducao = 50m, Identificador = 1 }],
                                        QualificacoesTributarias = [new QualificacaoTributaria { CodigoTributo = 1001, Id = 1 }],
                                        ExigibilidadesSuspensas =
                                        [
                                            new ExigibilidadeSuspensa { CodTributo = 1001, NumeroProcesso = "1", CodMunicipio = "7107", Uf = "SP", Vara = "1", ExisteDeposito = true, Motivo = 1 }
                                        ]
                                    }
                                ]
                            }
                        ]
                    }
                ]
            },
            ValoresParaComparacao = [new ValorDevido { CodigoTributo = 1001, Valor = 23.20m }]
        });

        VerificarPedido(handler, "Declarar", "PGDASD", "TRANSDECLARACAO11");
        var dados = DadosEnviados(handler);
        Nomes(dados).Should().Equal("cnpjCompleto", "pa", "indicadorTransmissao", "indicadorComparacao", "declaracao", "valoresParaComparacao");
        dados.GetProperty("pa").GetInt32().Should().Be(202101);
        var declaracao = dados.GetProperty("declaracao");
        Nomes(declaracao).Should().Equal("tipoDeclaracao", "receitaPaCompetenciaInterno", "receitaPaCompetenciaExterno", "valorFixoIcms",
            "receitasBrutasAnteriores", "folhasSalario", "naoOptante", "estabelecimentos");
        Nomes(declaracao.GetProperty("receitasBrutasAnteriores")[0]).Should().Equal("pa", "valorInterno", "valorExterno");
        Nomes(declaracao.GetProperty("folhasSalario")[0]).Should().Equal("pa", "valor");
        Nomes(declaracao.GetProperty("naoOptante")).Should().Equal("esferaAdm", "uf", "codMunicipio", "processo");
        var estabelecimento = declaracao.GetProperty("estabelecimentos")[0];
        Nomes(estabelecimento).Should().Equal("cnpjCompleto", "atividades");
        var atividade = estabelecimento.GetProperty("atividades")[0];
        Nomes(atividade).Should().Equal("idAtividade", "valorAtividade", "receitasAtividade");
        var receita = atividade.GetProperty("receitasAtividade")[0];
        Nomes(receita).Should().Equal("valor", "codigoOutroMunicipio", "outraUf", "isencoes", "reducoes", "qualificacoesTributarias", "exigibilidadesSuspensas");
        Nomes(receita.GetProperty("isencoes")[0]).Should().Equal("codTributo", "valor", "identificador");
        Nomes(receita.GetProperty("reducoes")[0]).Should().Equal("codTributo", "valor", "percentualReducao", "identificador");
        Nomes(receita.GetProperty("qualificacoesTributarias")[0]).Should().Equal("codigoTributo", "id");
        Nomes(receita.GetProperty("exigibilidadesSuspensas")[0]).Should().Equal("codTributo", "numeroProcesso", "codMunicipio", "uf", "vara", "existeDeposito", "motivo");
        Nomes(dados.GetProperty("valoresParaComparacao")[0]).Should().Equal("codigoTributo", "valor");

        var retorno = resposta.Retorno!;
        retorno.IdDeclaracao.Should().Be("00000000202104001");
        retorno.DataHoraTransmissao.Should().Be("20220803044803");
        retorno.ValoresDevidos.Should().HaveCount(2);
        retorno.ValoresDevidos![1].CodigoTributo.Should().Be(1007);
        retorno.ValoresDevidos[1].Valor.Should().Be(272m);
        retorno.Declaracao.Should().Be(PdfBase64);
        retorno.Recibo.Should().Be(PdfBase64);
        retorno.NotificacaoMaed.Should().Be(PdfBase64);
        retorno.Darf.Should().Be(PdfBase64);
        retorno.DetalhamentoDarfMaed!.DataVencimento.Should().Be("20220902");
        retorno.DetalhamentoDarfMaed.Valores!.Total.Should().Be(25m);
        retorno.DetalhamentoDarfMaed.Observacao2.Should().Be("PGDAS-D v2.1.6");
        retorno.DetalhamentoDarfMaed.Composicao.Should().BeNull();
    }

    [Test]
    public async Task Pgdasd_GerarDas()
    {
        var handler = new HandlerFalso
        {
            Dados = $$$"""
                [{"pdf":"{{{PdfBase64}}}","cnpjCompleto":"00000000000100","detalhamentoDas":{"periodoApuracao":"201801","numeroDocumento":"00000000000000000",
                  "dataVencimento":"20180220","dataLimiteAcolhimento":"20220831","valores":{"principal":40.00,"multa":8.00,"juros":10.15,"total":58.15},
                  "observacao1":"Esta empresa NÃO É OPTANTE pelo Simples Nacional.","observacao2":"","observacao3":"",
                  "composicao":[{"periodoApuracao":"201801","codigo":"1001","denominacao":"01/2018","valores":{"principal":2.20,"multa":0.44,"juros":0.56,"total":3.20}},
                                {"periodoApuracao":"201801","codigo":"1007","denominacao":"SP - 01/2018","valores":{"principal":13.60,"multa":2.72,"juros":3.45,"total":19.77}}]}}]
                """
        };
        using var service = CriarServico(handler);

        var resposta = await service.PgdasdGerarDasAsync(Contribuinte, new GerarDas { PeriodoApuracao = "201801", DataConsolidacao = "20220831" });

        VerificarPedido(handler, "Emitir", "PGDASD", "GERARDAS12");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().Be("{\"periodoApuracao\":\"201801\",\"dataConsolidacao\":\"20220831\"}");

        var das = resposta.Retorno.Should().ContainSingle().Subject;
        das.Pdf.Should().Be(PdfBase64);
        das.CnpjCompleto.Should().Be("00000000000100");
        das.Detalhamento![0].PeriodoApuracao.Should().Be("201801");
        das.Detalhamento![0].NumeroDocumento.Should().Be("00000000000000000");
        das.Detalhamento![0].DataVencimento.Should().Be("20180220");
        das.Detalhamento![0].DataLimiteAcolhimento.Should().Be("20220831");
        das.Detalhamento![0].Valores!.Principal.Should().Be(40m);
        das.Detalhamento![0].Valores.Multa.Should().Be(8m);
        das.Detalhamento![0].Valores.Juros.Should().Be(10.15m);
        das.Detalhamento![0].Valores.Total.Should().Be(58.15m);
        das.Detalhamento![0].Observacao1.Should().StartWith("Esta empresa");
        das.Detalhamento![0].Composicao.Should().HaveCount(2);
        das.Detalhamento![0].Composicao![1].Codigo.Should().Be("1007");
        das.Detalhamento![0].Composicao[1].Denominacao.Should().Be("SP - 01/2018");
        das.Detalhamento![0].Composicao[1].Valores!.Total.Should().Be(19.77m);
    }

    [Test]
    public void Pgdasd_Das_DeveAceitarChavesDetalhamentoEDetalhamentoDas()
    {
        var das = JsonSerializer.Deserialize<Das>("{\"pdf\":\"x\",\"detalhamento\":{\"numeroDocumento\":\"07202408201918950\"}}")!;
        das.Detalhamento![0].NumeroDocumento.Should().Be("07202408201918950");

        var dasLista = JsonSerializer.Deserialize<Das>("{\"pdf\":\"x\",\"detalhamentoDas\":[{\"numeroDocumento\":\"1\"},{\"numeroDocumento\":\"2\"}]}")!;
        dasLista.Detalhamento!.Select(d => d.NumeroDocumento).Should().Equal("1", "2");

        var json = JsonSerializer.Serialize(das);
        json.Should().Contain("\"detalhamento\"").And.NotContain("\"detalhamentoDas\"");
    }

    [Test]
    public async Task Pgdasd_ConsultarDeclaracoes()
    {
        var handler = new HandlerFalso
        {
            Dados = """
                {"anoCalendario":2018,"periodos":[
                  {"periodoApuracao":201801,"operacoes":[
                    {"tipoOperacao":"Original","indiceDeclaracao":{"numeroDeclaracao":"00000000201801001","dataHoraTransmissao":"20220331032512","malha":""},"indiceDas":null},
                    {"tipoOperacao":"Geração de DAS","indiceDeclaracao":null,"indiceDas":{"numeroDas":"07202215764027873","datahoraEmissaoDas":"20220606033456","dasPago":false}}]},
                  {"periodoApuracao":201802,"operacoes":[
                    {"tipoOperacao":"Retificadora","indiceDeclaracao":{"numeroDeclaracao":"00000000201802002","dataHoraTransmissao":"20220606033046","malha":""},"indiceDas":null}]}],
                 "mensagens":null}
                """
        };
        using var service = CriarServico(handler);

        var resposta = await service.PgdasdConsultarDeclaracoesAsync(Contribuinte, new ConsultarDeclaracoes { AnoCalendario = "2018" });

        VerificarPedido(handler, "Consultar", "PGDASD", "CONSDECLARACAO13");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().Be("{\"anoCalendario\":\"2018\"}");

        var retorno = resposta.Retorno!;
        retorno.AnoCalendario.Should().Be(2018);
        retorno.Periodo.Should().BeNull();
        retorno.Periodos.Should().HaveCount(2);
        var operacoes = retorno.Periodos![0].Operacoes!;
        retorno.Periodos[0].PeriodoApuracao.Should().Be(201801);
        operacoes[0].TipoOperacao.Should().Be("Original");
        operacoes[0].IndiceDeclaracao!.NumeroDeclaracao.Should().Be("00000000201801001");
        operacoes[0].IndiceDeclaracao!.DataHoraTransmissao.Should().Be(20220331032512);
        operacoes[0].IndiceDeclaracao!.Malha.Should().BeEmpty();
        operacoes[0].IndiceDas.Should().BeNull();
        operacoes[1].IndiceDas!.NumeroDas.Should().Be("07202215764027873");
        operacoes[1].IndiceDas!.DataHoraEmissaoDas.Should().Be(20220606033456);
        operacoes[1].IndiceDas!.DasPago.Should().BeFalse();
    }

    [Test]
    public async Task Pgdasd_ConsultarDeclaracoes_PorPeriodo()
    {
        var handler = new HandlerFalso
        {
            Dados = """{"anoCalendario":2018,"periodo":{"periodoApuracao":201801,"operacoes":[{"tipoOperacao":"Original","indiceDeclaracao":{"numeroDeclaracao":"00000000201801001","dataHoraTransmissao":20220331032512,"malha":null}}]}}"""
        };
        using var service = CriarServico(handler);

        var resposta = await service.PgdasdConsultarDeclaracoesAsync(Contribuinte, new ConsultarDeclaracoes { PeriodoApuracao = "201801" });

        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().Be("{\"periodoApuracao\":\"201801\"}");
        resposta.Retorno!.Periodo!.PeriodoApuracao.Should().Be(201801);
        resposta.Retorno.Periodo.Operacoes![0].IndiceDeclaracao!.DataHoraTransmissao.Should().Be(20220331032512);
    }

    private static string DeclaracaoReciboJson => $$$"""
        {"numeroDeclaracao":"00000000201801001",
         "recibo":{"nomeArquivo":"PGDASD-RECIBO-00000000201801001.pdf","pdf":"{{{PdfBase64}}}"},
         "declaracao":{"nomeArquivo":"PGDASD-DECLARACAO-00000000201801001.pdf","pdf":"{{{PdfBase64}}}"},
         "maed":{"nomeArquivoNotificacao":"PGDASD-NOTIFICACAO-MAED-00000000201801001.pdf","pdfNotificacao":"{{{PdfBase64}}}",
                 "nomeArquivoDarf":"PGDASD-DARF-MAED-00000000201801001.pdf","pdfDarf":"{{{PdfBase64}}}"}}
        """;

    private static void VerificarDeclaracaoRecibo(DeclaracaoRecibo retorno)
    {
        retorno!.NumeroDeclaracao.Should().Be("00000000201801001");
        retorno.Recibo!.NomeArquivo.Should().Be("PGDASD-RECIBO-00000000201801001.pdf");
        retorno.Recibo.Pdf.Should().Be(PdfBase64);
        retorno.Declaracao!.NomeArquivo.Should().Be("PGDASD-DECLARACAO-00000000201801001.pdf");
        retorno.Declaracao.Pdf.Should().Be(PdfBase64);
        retorno.Maed!.NomeArquivoNotificacao.Should().Be("PGDASD-NOTIFICACAO-MAED-00000000201801001.pdf");
        retorno.Maed.PdfNotificacao.Should().Be(PdfBase64);
        retorno.Maed.NomeArquivoDarf.Should().Be("PGDASD-DARF-MAED-00000000201801001.pdf");
        retorno.Maed.PdfDarf.Should().Be(PdfBase64);
    }

    [Test]
    public async Task Pgdasd_ConsultarUltimaDeclaracao()
    {
        var handler = new HandlerFalso { Dados = DeclaracaoReciboJson };
        using var service = CriarServico(handler);

        var resposta = await service.PgdasdConsultarUltimaDeclaracaoAsync(Contribuinte, new ConsultarUltimaDeclaracao { PeriodoApuracao = "201801" });

        VerificarPedido(handler, "Consultar", "PGDASD", "CONSULTIMADECREC14");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().Be("{\"periodoApuracao\":\"201801\"}");
        VerificarDeclaracaoRecibo(resposta.Retorno);
    }

    [Test]
    public async Task Pgdasd_ConsultarDeclaracao()
    {
        var handler = new HandlerFalso { Dados = DeclaracaoReciboJson };
        using var service = CriarServico(handler);

        var resposta = await service.PgdasdConsultarDeclaracaoAsync(Contribuinte, new ConsultarDeclaracao { NumeroDeclaracao = "00000000201801001" });

        VerificarPedido(handler, "Consultar", "PGDASD", "CONSDECREC15");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().Be("{\"numeroDeclaracao\":\"00000000201801001\"}");
        VerificarDeclaracaoRecibo(resposta.Retorno);
    }

    [Test]
    public async Task Pgdasd_ConsultarExtratoDas()
    {
        var handler = new HandlerFalso
        {
            Dados = $$$"""{"numeroDas":"07202136999997159","extrato":{"nomeArquivo":"PGDASD-EXTRATO-07202136999997159.pdf","pdf":"{{{PdfBase64}}}"}}"""
        };
        using var service = CriarServico(handler);

        var resposta = await service.PgdasdConsultarExtratoDasAsync(Contribuinte, new ConsultarExtratoDas { NumeroDas = "07202136999997159" });

        VerificarPedido(handler, "Consultar", "PGDASD", "CONSEXTRATO16");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().Be("{\"numeroDas\":\"07202136999997159\"}");
        resposta.Retorno!.NumeroDas.Should().Be("07202136999997159");
        resposta.Retorno.Extrato!.NomeArquivo.Should().Be("PGDASD-EXTRATO-07202136999997159.pdf");
        resposta.Retorno.Extrato.Pdf.Should().Be(PdfBase64);
    }

    [Test]
    public async Task Pgdasd_GerarDasCobranca()
    {
        var handler = new HandlerFalso
        {
            Dados = $$$"""
                {"pdf":"{{{PdfBase64}}}","cnpjCompleto":"00000000000000","detalhamentoDas":{"periodoApuracao":"202301","numeroDocumento":"00000000000000000",
                 "dataVencimento":"20230222","dataLimiteAcolhimento":"20240228","valores":{"principal":1548.20,"multa":309.64,"juros":189.50,"total":2047.34},
                 "observacao1":null,"observacao2":null,"observacao3":null,
                 "composicao":[{"periodoApuracao":"202301","codigo":"1001","denominacao":"01/2023","valores":{"principal":88.0,"multa":17.59,"juros":10.77,"total":116.36}}]}}
                """
        };
        using var service = CriarServico(handler);

        var resposta = await service.PgdasdGerarDasCobrancaAsync(Contribuinte, new GerarDasCobranca { PeriodoApuracao = "202301" });

        VerificarPedido(handler, "Emitir", "PGDASD", "GERARDASCOBRANCA17");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().Be("{\"periodoApuracao\":\"202301\"}");
        resposta.Retorno!.Pdf.Should().Be(PdfBase64);
        resposta.Retorno.Detalhamento![0].Valores!.Total.Should().Be(2047.34m);
        resposta.Retorno.Detalhamento![0].Observacao1.Should().BeNull();
        resposta.Retorno.Detalhamento![0].Composicao![0].Valores!.Multa.Should().Be(17.59m);
    }

    [Test]
    public async Task Pgdasd_GerarDasProcesso()
    {
        var handler = new HandlerFalso
        {
            Dados = $$$"""
                {"pdf":"{{{PdfBase64}}}","cnpjCompleto":"00000000000000","detalhamentoDas":{"periodoApuracao":"202201","numeroDocumento":"00000000000000000",
                 "dataVencimento":"20220530","dataLimiteAcolhimento":"20240305","valores":{"principal":24.80,"multa":4.96,"juros":5.59,"total":35.35},
                 "observacao1":"Nrº Processo: 00000.000.000/0000-00","observacao2":null,"observacao3":null,
                 "composicao":[{"periodoApuracao":"202201","codigo":"1004","denominacao":"01/2022","valores":{"principal":20.38,"multa":4.08,"juros":4.60,"total":29.06}},
                               {"periodoApuracao":"202201","codigo":"1005","denominacao":"01/2022","valores":{"principal":4.42,"multa":0.88,"juros":0.99,"total":6.29}}]}}
                """
        };
        using var service = CriarServico(handler);

        var resposta = await service.PgdasdGerarDasProcessoAsync(Contribuinte, new GerarDasProcesso { NumeroProcesso = "00000000000000000" });

        VerificarPedido(handler, "Emitir", "PGDASD", "GERARDASPROCESSO18");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().Be("{\"numeroProcesso\":\"00000000000000000\"}");
        resposta.Retorno!.Detalhamento![0].Observacao1.Should().Be("Nrº Processo: 00000.000.000/0000-00");
        resposta.Retorno.Detalhamento![0].Composicao.Should().HaveCount(2);
        resposta.Retorno.Detalhamento![0].Valores!.Juros.Should().Be(5.59m);
    }

    [Test]
    public async Task Pgdasd_GerarDasAvulso()
    {
        var handler = new HandlerFalso
        {
            Dados = $$$"""
                {"pdf":"{{{PdfBase64}}}","cnpjCompleto":"00000333000110","detalhamentoDas":{"periodoApuracao":"202401","numeroDocumento":"07202408201918950",
                 "dataVencimento":"20240220","dataLimiteAcolhimento":"20240322","valores":{"principal":231.72,"multa":23.69,"juros":2.31,"total":257.72},
                 "observacao1":null,"observacao2":"","observacao3":null,
                 "composicao":[{"periodoApuracao":"202401","codigo":"1010","denominacao":"ABEL FIGUEIREDO (PA) - 01/2024","valores":{"principal":111.22,"multa":11.37,"juros":1.11,"total":123.70}}]}}
                """
        };
        using var service = CriarServico(handler);

        var resposta = await service.PgdasdGerarDasAvulsoAsync(Contribuinte, new GerarDasAvulso
        {
            PeriodoApuracao = 202401,
            ListaTributos =
            [
                new TributoDasAvulso { Codigo = 1010, Valor = 111.22m, CodMunicipio = 375, Uf = "PA" },
                new TributoDasAvulso { Codigo = 1001, Valor = 100m }
            ],
            DataConsolidacao = 20240322
        });

        VerificarPedido(handler, "Emitir", "PGDASD", "GERARDASAVULSO19");
        var dados = DadosEnviados(handler);
        Nomes(dados).Should().Equal("periodoApuracao", "listaTributos", "dataConsolidacao");
        dados.GetProperty("periodoApuracao").GetInt32().Should().Be(202401);
        Nomes(dados.GetProperty("listaTributos")[0]).Should().Equal("codigo", "valor", "codMunicipio", "uf");
        Nomes(dados.GetProperty("listaTributos")[1]).Should().Equal("codigo", "valor");

        resposta.Retorno!.CnpjCompleto.Should().Be("00000333000110");
        resposta.Retorno.Detalhamento![0].NumeroDocumento.Should().Be("07202408201918950");
        resposta.Retorno.Detalhamento![0].Composicao![0].Denominacao.Should().Be("ABEL FIGUEIREDO (PA) - 01/2024");
    }

    [Test]
    public async Task Pgdasd_DadosNulos_DeveLancarArgumentNullException()
    {
        using var service = CriarServico(new HandlerFalso());

        await FluentActions.Awaiting(() => service.PgdasdGerarDasAsync(Contribuinte, null!))
            .Should().ThrowAsync<ArgumentNullException>().WithParameterName("dados");
    }

    #endregion

    #region REGIMEAPURACAO

    private static string OpcaoRegimeJson => $$$"""
        {"cnpjMatriz":"00000000000000","anoCalendario":2023,"regimeEscolhido":"CAIXA","dataHoraOpcao":20221220025818,
         "demonstrativoPdf":"{{{PdfBase64}}}","textoResolucao":"Resolução CGSN nº 140, de 22 de maio de 2018."}
        """;

    private static void VerificarOpcaoRegime(OpcaoRegime retorno)
    {
        retorno!.CnpjMatriz.Should().Be("00000000000000");
        retorno.AnoCalendario.Should().Be(2023);
        retorno.RegimeEscolhido.Should().Be("CAIXA");
        retorno.DataHoraOpcao.Should().Be(20221220025818);
        retorno.DemonstrativoPdf.Should().Be(PdfBase64);
        retorno.TextoResolucao.Should().StartWith("Resolução CGSN nº 140");
    }

    [Test]
    public async Task RegimeApuracao_EfetuarOpcao()
    {
        var handler = new HandlerFalso { Dados = OpcaoRegimeJson };
        using var service = CriarServico(handler);

        var resposta = await service.RegimeApuracaoEfetuarOpcaoAsync(Contribuinte, new EfetuarOpcaoRegime
        {
            AnoOpcao = 2023,
            TipoRegime = 1,
            DescritivoRegime = "CAIXA",
            DeAcordoResolucao = true
        });

        VerificarPedido(handler, "Declarar", "REGIMEAPURACAO", "EFETUAROPCAOREGIME101");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should()
            .Be("{\"anoOpcao\":2023,\"tipoRegime\":1,\"descritivoRegime\":\"CAIXA\",\"deAcordoResolucao\":true}");
        VerificarOpcaoRegime(resposta.Retorno);
    }

    [Test]
    public async Task RegimeApuracao_ConsultarAnosCalendario()
    {
        var handler = new HandlerFalso
        {
            Dados = """[{"anoCalendario":2023,"regimeApurado":"CAIXA"},{"anoCalendario":2017,"regimeApurado":"COMPETENCIA"}]"""
        };
        using var service = CriarServico(handler);

        var resposta = await service.RegimeApuracaoConsultarAnosCalendarioAsync(Contribuinte);

        VerificarPedido(handler, "Consultar", "REGIMEAPURACAO", "CONSULTARANOSCALENDARIOS102");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().BeEmpty();
        resposta.Retorno.Should().HaveCount(2);
        resposta.Retorno![0].AnoCalendario.Should().Be(2023);
        resposta.Retorno[0].RegimeApurado.Should().Be("CAIXA");
        resposta.Retorno[1].RegimeApurado.Should().Be("COMPETENCIA");
    }

    [Test]
    public async Task RegimeApuracao_ConsultarOpcao()
    {
        var handler = new HandlerFalso { Dados = OpcaoRegimeJson };
        using var service = CriarServico(handler);

        var resposta = await service.RegimeApuracaoConsultarOpcaoAsync(Contribuinte, new ConsultarOpcaoRegime { AnoCalendario = 2023 });

        VerificarPedido(handler, "Consultar", "REGIMEAPURACAO", "CONSULTAROPCAOREGIME103");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().Be("{\"anoCalendario\":2023}");
        VerificarOpcaoRegime(resposta.Retorno);
    }

    [Test]
    public async Task RegimeApuracao_ConsultarResolucao()
    {
        var handler = new HandlerFalso { Dados = """{"textoResolucao":"Resolução CGSN nº 140, de 22 de maio de 2018."}""" };
        using var service = CriarServico(handler);

        var resposta = await service.RegimeApuracaoConsultarResolucaoAsync(Contribuinte, new ConsultarResolucaoRegime { AnoCalendario = 2021 });

        VerificarPedido(handler, "Consultar", "REGIMEAPURACAO", "CONSULTARRESOLUCAO104");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().Be("{\"anoCalendario\":2021}");
        resposta.Retorno!.TextoResolucao.Should().StartWith("Resolução CGSN nº 140");
    }

    #endregion

    #region DEFIS

    private static string ReciboDefisJson => $$$"""{"declaracaoPdf":"{{{PdfBase64}}}","reciboPdf":"{{{PdfBase64}}}","idDefis":"000000002021002"}""";

    [Test]
    public async Task Defis_TransmitirDeclaracao()
    {
        var handler = new HandlerFalso { Dados = ReciboDefisJson };
        using var service = CriarServico(handler);
        var valor = new ValorMunicipio { Uf = "SP", CodigoMunicipio = 7107, Valor = 20m };

        var resposta = await service.DefisTransmitirDeclaracaoAsync(Contribuinte, new TransmitirDeclaracaoDefis
        {
            Ano = 2021,
            SituacaoEspecial = new SituacaoEspecial { TipoEvento = 1, DataEvento = 20210630 },
            Inatividade = 2,
            Empresa = new EmpresaDefis
            {
                GanhoCapital = 10m,
                QtdEmpregadoInicial = 2,
                QtdEmpregadoFinal = 0,
                LucroContabil = 20m,
                ReceitaExportacaoDireta = 10m,
                ComerciaisExportadoras = [new ComercialExportadora { CnpjCompleto = "00000000000000", Valor = 123m }],
                Socios = [new Socio { Cpf = "00000000000", RendimentosIsentos = 50m, RendimentosTributaveis = 20m, ParticipacaoCapitalSocial = 90m, IrRetidoFonte = 10m }],
                ParticipacaoCotasTesouraria = 10m,
                GanhoRendaVariavel = 10m,
                DoacoesCampanhaEleitoral = [new DoacaoCampanhaEleitoral { CnpjBeneficiario = "00000000000000", TipoBeneficiario = 1, FormaDoacao = 1, Valor = 10m }],
                Estabelecimentos =
                [
                    new EstabelecimentoDefis
                    {
                        CnpjCompleto = "00000000000000",
                        EstoqueInicial = 10m,
                        EstoqueFinal = 20m,
                        SaldoCaixaInicial = -100m,
                        SaldoCaixaFinal = -50m,
                        AquisicoesMercadoInterno = 20m,
                        Importacoes = 50m,
                        TotalEntradasPorTransferencia = 200m,
                        TotalSaidasPorTransferencia = 200m,
                        TotalDevolucoesVendas = 300m,
                        TotalEntradas = 5000m,
                        TotalDevolucoesCompras = 200m,
                        TotalDespesas = 10000m,
                        OperacoesInterestaduais = [new OperacaoInterestadual { Uf = "SP", Valor = 15m, TipoOperacao = 1 }],
                        IssRetidosFonte = [valor],
                        PrestacaoServicosComunicacao = [valor],
                        MudancasOutroMunicipio =
                        [
                            new MudancaOutroMunicipio { UfOrigem = "SP", CodigoMunicipioOrigem = 7107, UfDestino = "RJ", CodigoMunicipioDestino = 6001, DataMudanca = 20210701 }
                        ],
                        PrestacoesServicoTransporte = [valor],
                        InformacaoOpcional = new InformacaoOpcional
                        {
                            SaidaTransferenciaMercadoria = 20m,
                            VendasRevendedorAmbulante = [valor],
                            PreparosComercializacaoRefeicoes = [valor],
                            ProducoesRurais = [valor],
                            AquisicoesProdutoresRurais = [valor],
                            AquisicoesDispensadosInscricao = [valor],
                            AutoInfracaoPago = 20m,
                            RateiosReceitaRegimeEspecial = [new RateioRegimeEspecial { Uf = "SP", CodigoMunicipio = 7107, Valor = 20m, NumeroRegime = "999999" }],
                            RateiosDecisaoJudicial = [new RateioDecisaoJudicial { Uf = "SP", CodigoMunicipio = 7107, Valor = 20m, IdentificacaoDecisao = "teste" }],
                            RateiosReceitaOutrosRateios = [new RateioOutrosRateios { Uf = "SP", CodigoMunicipio = 7107, Valor = 20m, OrigemExigencia = "teste" }]
                        }
                    }
                ]
            },
            NaoOptante = new NaoOptanteDefis { AdministracaoTributaria = 3, Uf = "SP", CodigoMunicipio = 7107, NumeroProcesso = "123" }
        });

        VerificarPedido(handler, "Declarar", "DEFIS", "TRANSDECLARACAO141");
        var dados = DadosEnviados(handler);
        Nomes(dados).Should().Equal("ano", "situacaoEspecial", "inatividade", "empresa", "naoOptante");
        Nomes(dados.GetProperty("situacaoEspecial")).Should().Equal("tipoEvento", "dataEvento");
        Nomes(dados.GetProperty("naoOptante")).Should().Equal("administracaoTributaria", "uf", "codigoMunicipio", "numeroProcesso");
        var empresa = dados.GetProperty("empresa");
        Nomes(empresa).Should().Equal("ganhoCapital", "qtdEmpregadoInicial", "qtdEmpregadoFinal", "lucroContabil", "receitaExportacaoDireta",
            "comerciaisExportadoras", "socios", "participacaoCotasTesouraria", "ganhoRendaVariavel", "doacoesCampanhaEleitoral", "estabelecimentos");
        Nomes(empresa.GetProperty("comerciaisExportadoras")[0]).Should().Equal("cnpjCompleto", "valor");
        Nomes(empresa.GetProperty("socios")[0]).Should().Equal("cpf", "rendimentosIsentos", "rendimentosTributaveis", "participacaoCapitalSocial", "irRetidoFonte");
        Nomes(empresa.GetProperty("doacoesCampanhaEleitoral")[0]).Should().Equal("cnpjBeneficiario", "tipoBeneficiario", "formaDoacao", "valor");
        var estabelecimento = empresa.GetProperty("estabelecimentos")[0];
        Nomes(estabelecimento).Should().Equal("cnpjCompleto", "estoqueInicial", "estoqueFinal", "saldoCaixaInicial", "saldoCaixaFinal",
            "aquisicoesMercadoInterno", "importacoes", "totalEntradasPorTransferencia", "totalSaidasPorTransferencia", "totalDevolucoesVendas",
            "totalEntradas", "totalDevolucoesCompras", "totalDespesas", "operacoesInterestaduais", "issRetidosFonte",
            "prestacaoServicosComunicacao", "mudancasOutroMunicipio", "prestacoesServicoTransporte", "informacaoOpcional");
        Nomes(estabelecimento.GetProperty("operacoesInterestaduais")[0]).Should().Equal("uf", "valor", "tipoOperacao");
        Nomes(estabelecimento.GetProperty("issRetidosFonte")[0]).Should().Equal("uf", "codigoMunicipio", "valor");
        Nomes(estabelecimento.GetProperty("mudancasOutroMunicipio")[0]).Should().Equal("ufOrigem", "codigoMunicipioOrigem", "ufDestino", "codigoMunicipioDestino", "dataMudanca");
        var opcional = estabelecimento.GetProperty("informacaoOpcional");
        Nomes(opcional).Should().Equal("saidaTransferenciaMercadoria", "vendasRevendedorAmbulante", "preparosComercializacaoRefeicoes", "producoesRurais",
            "aquisicoesProdutoresRurais", "aquisicoesDispensadosInscricao", "autoInfracaoPago", "rateiosReceitaRegimeEspecial",
            "rateiosDecisaoJudicial", "rateiosReceitaOutrosRateios");
        Nomes(opcional.GetProperty("rateiosReceitaRegimeEspecial")[0]).Should().Equal("uf", "codigoMunicipio", "valor", "numeroRegime");
        Nomes(opcional.GetProperty("rateiosDecisaoJudicial")[0]).Should().Equal("uf", "codigoMunicipio", "valor", "identificacaoDecisao");
        Nomes(opcional.GetProperty("rateiosReceitaOutrosRateios")[0]).Should().Equal("uf", "codigoMunicipio", "valor", "origemExigencia");
        estabelecimento.GetProperty("saldoCaixaInicial").GetDecimal().Should().Be(-100m);

        resposta.Retorno!.DeclaracaoPdf.Should().Be(PdfBase64);
        resposta.Retorno.ReciboPdf.Should().Be(PdfBase64);
        resposta.Retorno.IdDefis.Should().Be("000000002021002");
    }

    [Test]
    public async Task Defis_ConsultarDeclaracoes()
    {
        var handler = new HandlerFalso
        {
            Dados = """
                [{"anoCalendario":2019,"idDefis":"000000002019001","tipo":1,"dataHora":"20230725102410"},
                 {"anoCalendario":2018,"idDefis":"000000002018003","tipo":2,"dataHora":"20230801145404"}]
                """
        };
        using var service = CriarServico(handler);

        var resposta = await service.DefisConsultarDeclaracoesAsync(Contribuinte);

        VerificarPedido(handler, "Consultar", "DEFIS", "CONSDECLARACAO142");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().BeEmpty();
        resposta.Retorno.Should().HaveCount(2);
        resposta.Retorno![0].AnoCalendario.Should().Be(2019);
        resposta.Retorno[0].IdDefis.Should().Be("000000002019001");
        resposta.Retorno[0].Tipo.Should().Be(1);
        resposta.Retorno[0].DataHora.Should().Be(20230725102410);
        resposta.Retorno[1].Tipo.Should().Be(2);
    }

    [Test]
    public async Task Defis_ConsultarUltimaDeclaracao()
    {
        var handler = new HandlerFalso { Dados = ReciboDefisJson };
        using var service = CriarServico(handler);

        var resposta = await service.DefisConsultarUltimaDeclaracaoAsync(Contribuinte, new ConsultarUltimaDeclaracaoDefis { Ano = 2021 });

        VerificarPedido(handler, "Consultar", "DEFIS", "CONSULTIMADECREC143");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().Be("{\"ano\":2021}");
        resposta.Retorno!.DeclaracaoPdf.Should().Be(PdfBase64);
        resposta.Retorno.ReciboPdf.Should().Be(PdfBase64);
        resposta.Retorno.IdDefis.Should().Be("000000002021002");
    }

    [Test]
    public async Task Defis_ConsultarDeclaracao()
    {
        var handler = new HandlerFalso { Dados = $$$"""{"declaracaoPdf":"{{{PdfBase64}}}","reciboPdf":"{{{PdfBase64}}}"}""" };
        using var service = CriarServico(handler);

        var resposta = await service.DefisConsultarDeclaracaoAsync(Contribuinte, new ConsultarDeclaracaoDefis { IdDefis = "000000002021002" });

        VerificarPedido(handler, "Consultar", "DEFIS", "CONSDECREC144");
        handler.Chamadas.Last().Requisicao.PedidoDados.Dados.Should().Be("{\"idDefis\":\"000000002021002\"}");
        resposta.Retorno!.DeclaracaoPdf.Should().Be(PdfBase64);
        resposta.Retorno.ReciboPdf.Should().Be(PdfBase64);
        resposta.Retorno.IdDefis.Should().BeNull();
    }

    #endregion
}
