using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraDCTFWeb;
using EficazFramework.SPED.Schemas.MIT;
using System.Text;
using System.Text.Json;

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// Integra-DCTFWeb: serviços DCTFWEB e MIT (endpoint, identificação do serviço, campos enviados e retorno tipado).
/// </summary>
public class IntegraDCTFWebTests : BaseIntegraContadorTests
{
    private const string PdfBase64 = "JVBERi0xLjcNCg==";

    private static void VerificarPedido(HandlerFalso handler, string endpoint, string idSistema, string idServico, string versao = "1.0")
    {
        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().EndWith("/" + endpoint);
        var requisicao = pedido.Requisicao;
        requisicao.PedidoDados.IdSistema.Should().Be(idSistema);
        requisicao.PedidoDados.IdServico.Should().Be(idServico);
        requisicao.PedidoDados.VersaoSistema.Should().Be(versao);
        requisicao.Contribuinte.Should().Be(Contribuinte);
    }

    private static string[] Campos(JsonElement json) => json.EnumerateObject().Select(p => p.Name).ToArray();


    // DCTFWEB

    [Test]
    public async Task DctfWebGerarGuia_DeveEnviarCamposERetornarPdf()
    {
        var handler = new HandlerFalso { Dados = $"{{\"PDFByteArrayBase64\":\"{PdfBase64}\"}}" };
        using var service = CriarServico(handler);

        var resposta = await service.DctfWebGerarGuiaAsync(Contribuinte, new GerarGuiaDctfWeb
        {
            Categoria = CategoriaDctfWeb.ReclamatoriaTrabalhista,
            AnoPA = "2022",
            MesPA = "12",
            NumProcReclamatoria = "00365354520004013400",
            DataAcolhimentoProposta = 20230731,
            IdsSistemaOrigem = [SistemaOrigemDctfWeb.ESocial, SistemaOrigemDctfWeb.Mit]
        });

        VerificarPedido(handler, "Emitir", "DCTFWEB", "GERARGUIA31");
        var dados = DadosEnviados(handler);
        Campos(dados).Should().BeEquivalentTo("categoria", "anoPA", "mesPA", "numProcReclamatoria", "DataAcolhimentoProposta", "idsSistemaOrigem");
        dados.GetProperty("categoria").GetInt32().Should().Be(46);
        dados.GetProperty("anoPA").GetString().Should().Be("2022");
        dados.GetProperty("mesPA").GetString().Should().Be("12");
        dados.GetProperty("numProcReclamatoria").GetString().Should().Be("00365354520004013400");
        dados.GetProperty("DataAcolhimentoProposta").GetInt32().Should().Be(20230731);
        dados.GetProperty("idsSistemaOrigem").EnumerateArray().Select(e => e.GetInt32()).Should().Equal(1, 8);

        resposta.Retorno!.PdfBase64.Should().Be(PdfBase64);
        Encoding.ASCII.GetString(resposta.Retorno.ObterPdf()!).Should().StartWith("%PDF-1.7");
    }

    [Test]
    public async Task DctfWebConsultarRecibo_DeveEnviarCamposDaCategoria()
    {
        var handler = new HandlerFalso { Dados = $"{{\"PDFByteArrayBase64\":\"{PdfBase64}\"}}" };
        using var service = CriarServico(handler);

        var resposta = await service.DctfWebConsultarReciboAsync(Contribuinte, new ConsultaDctfWeb
        {
            Categoria = CategoriaDctfWeb.Afericao,
            AnoPA = "2022",
            MesPA = "03",
            CnoAfericao = 28151,
            NumeroReciboEntrega = 24781
        });

        VerificarPedido(handler, "Consultar", "DCTFWEB", "CONSRECIBO32");
        var dados = DadosEnviados(handler);
        Campos(dados).Should().BeEquivalentTo("categoria", "anoPA", "mesPA", "cnoAfericao", "numeroReciboEntrega");
        dados.GetProperty("categoria").GetInt32().Should().Be(44);
        dados.GetProperty("cnoAfericao").GetInt64().Should().Be(28151);
        dados.GetProperty("numeroReciboEntrega").GetInt64().Should().Be(24781);
        resposta.Retorno!.PdfBase64.Should().Be(PdfBase64);
    }

    [Test]
    public async Task DctfWebConsultarDeclaracaoCompleta_DeveOmitirMesNo13Salario()
    {
        var handler = new HandlerFalso { Dados = $"{{\"PDFByteArrayBase64\":\"{PdfBase64}\"}}" };
        using var service = CriarServico(handler);

        var resposta = await service.DctfWebConsultarDeclaracaoCompletaAsync(Contribuinte, new ConsultaDctfWeb { Categoria = CategoriaDctfWeb.Geral13Salario, AnoPA = "2022" });

        VerificarPedido(handler, "Consultar", "DCTFWEB", "CONSDECCOMPLETA33");
        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().Be("{\"categoria\":41,\"anoPA\":\"2022\"}");
        resposta.Retorno!.PdfBase64.Should().Be(PdfBase64);
    }

    [Test]
    public async Task DctfWebConsultarXmlDeclaracao_DeveRetornarXmlBase64()
    {
        var xml = Convert.ToBase64String(Encoding.UTF8.GetBytes("<Declaracao><ConteudoDeclaracao/></Declaracao>"));
        var handler = new HandlerFalso { Dados = $"{{\"XMLStringBase64\":\"{xml}\"}}" };
        using var service = CriarServico(handler);

        var resposta = await service.DctfWebConsultarXmlDeclaracaoAsync(Contribuinte, new ConsultaDctfWeb { Categoria = CategoriaDctfWeb.PfMensal, AnoPA = "2022", MesPA = "06" });

        VerificarPedido(handler, "Consultar", "DCTFWEB", "CONSXMLDECLARACAO38");
        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().Be("{\"categoria\":50,\"anoPA\":\"2022\",\"mesPA\":\"06\"}");
        resposta.Retorno!.XmlBase64.Should().Be(xml);
        Encoding.UTF8.GetString(resposta.Retorno.ObterXml()!).Should().Be("<Declaracao><ConteudoDeclaracao/></Declaracao>");
    }

    [Test]
    public async Task DctfWebTransmitirDeclaracao_DeveEnviarXmlAssinadoERetornarRecibo()
    {
        var handler = new HandlerFalso { Dados = "{\"NumeroRecibo\":24781}" };
        using var service = CriarServico(handler);

        var resposta = await service.DctfWebTransmitirDeclaracaoAsync(Contribuinte, new TransmitirDeclaracaoDctfWeb
        {
            Categoria = CategoriaDctfWeb.EspetaculoDesportivo,
            AnoPA = "2022",
            MesPA = "04",
            DiaPA = "19",
            XmlAssinadoBase64 = "AQUI_VAI_TEXTOBASE64ASSINADO"
        });

        VerificarPedido(handler, "Declarar", "DCTFWEB", "TRANSDECLARACAO310");
        var dados = DadosEnviados(handler);
        Campos(dados).Should().BeEquivalentTo("categoria", "anoPA", "mesPA", "diaPA", "xmlAssinadoBase64");
        dados.GetProperty("categoria").GetInt32().Should().Be(45);
        dados.GetProperty("diaPA").GetString().Should().Be("19");
        dados.GetProperty("xmlAssinadoBase64").GetString().Should().Be("AQUI_VAI_TEXTOBASE64ASSINADO");
        resposta.Retorno!.NumeroRecibo.Should().Be(24781);
    }

    [Test]
    public async Task DctfWebTransmitirDeclaracao_XmlDocument_DeveCodificarEmBase64()
    {
        var handler = new HandlerFalso { Dados = "{\"NumeroRecibo\":24781}" };
        using var service = CriarServico(handler);
        var xml = new XmlDocument { PreserveWhitespace = true };
        xml.LoadXml("<Declaracao><ConteudoDeclaracao id=\"id_1\">á</ConteudoDeclaracao></Declaracao>");

        await service.DctfWebTransmitirDeclaracaoAsync(Contribuinte, new TransmitirDeclaracaoDctfWeb { AnoPA = "2022", MesPA = "04" }, xml);

        var base64 = DadosEnviados(handler).GetProperty("xmlAssinadoBase64").GetString()!;
        Encoding.UTF8.GetString(Convert.FromBase64String(base64)).Should().Be(xml.OuterXml);
    }

    [Test]
    public async Task DctfWebTransmitirDeclaracao_SemXml_DeveLancarExcecao()
    {
        using var service = CriarServico(new HandlerFalso());

        var acao = () => service.DctfWebTransmitirDeclaracaoAsync(Contribuinte, new TransmitirDeclaracaoDctfWeb { AnoPA = "2022", MesPA = "04" });

        await acao.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task DctfWeb_SemDadosOuAno_DeveLancarExcecao()
    {
        using var service = CriarServico(new HandlerFalso());

        await ((Func<Task>)(() => service.DctfWebGerarGuiaAsync(Contribuinte, null!))).Should().ThrowAsync<ArgumentNullException>();
        await ((Func<Task>)(() => service.DctfWebConsultarReciboAsync(Contribuinte, new ConsultaDctfWeb()))).Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task DctfWebGerarGuiaEmAndamento_DeveEnviarSistemasDeOrigem()
    {
        var handler = new HandlerFalso { Dados = $"{{\"PDFByteArrayBase64\":\"{PdfBase64}\"}}" };
        using var service = CriarServico(handler);

        var resposta = await service.DctfWebGerarGuiaEmAndamentoAsync(Contribuinte, new GerarGuiaAndamentoDctfWeb
        {
            Categoria = CategoriaDctfWeb.GeralMensal,
            AnoPA = "2025",
            MesPA = "01",
            IdsSistemaOrigem = [SistemaOrigemDctfWeb.Mit]
        });

        VerificarPedido(handler, "Emitir", "DCTFWEB", "GERARGUIAANDAMENTO313");
        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().Be("{\"categoria\":40,\"anoPA\":\"2025\",\"mesPA\":\"01\",\"idsSistemaOrigem\":[8]}");
        resposta.Retorno!.PdfBase64.Should().Be(PdfBase64);
    }


    // MIT

    [Test]
    public async Task MitEncerrarApuracao_SemMovimento_DeveSeguirExemploDaDocumentacao()
    {
        var handler = new HandlerFalso { Dados = "{\"protocoloEncerramento\":\"2fc4NTscrGXWTl4xbCX9rw==\",\"idApuracao\":0}" };
        using var service = CriarServico(handler);
        var apuracao = new ApuracaoMit
        {
            PeriodoApuracao = new PeriodoApuracao { MesApuracao = 8, AnoApuracao = 2025 },
            DadosIniciais = new DadosIniciais
            {
                SemMovimento = true,
                QualificacaoPj = 11,
                ResponsavelApuracao = new ResponsavelApuracao { CpfResponsavel = "12345678900" }
            },
            TransmissaoImediata = false
        };

        var resposta = await service.MitEncerrarApuracaoAsync(Contribuinte, apuracao);

        VerificarPedido(handler, "Declarar", "MIT", "ENCAPURACAO314");
        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().Be(
            "{\"PeriodoApuracao\":{\"MesApuracao\":8,\"AnoApuracao\":2025},\"DadosIniciais\":{\"SemMovimento\":true,\"QualificacaoPj\":11,\"ResponsavelApuracao\":{\"CpfResponsavel\":\"12345678900\"}},\"TransmissaoImediata\":false}");

        resposta.Retorno!.ProtocoloEncerramento.Should().Be("2fc4NTscrGXWTl4xbCX9rw==");
        resposta.Retorno.IdApuracao.Should().Be(0);
    }

    [Test]
    public void ApuracaoMit_ComDebitosESuspensoes_DeveSeguirExemploDaDocumentacao()
    {
        var debitos = new Debitos { Irpj = new Irpj(), Iof = new Iof(), ContribuicoesDiversas = new ContribuicoesDiversas() };
        debitos.Irpj.AddDebito(new DetalhamentoDebito { CodigoDebito = "159901", ValorDebito = 24000.00m });
        debitos.Iof.AddDebito(new DetalhamentoDebito { CodigoDebito = "115003", PaDebito = 3, ValorDebito = 4000.00m });
        debitos.ContribuicoesDiversas.AddDebito(new DetalhamentoDebito { CodigoDebito = "874101", CnpjEstabelecimento = "000100", ValorDebito = 300.00m });
        // AddDebito numera por grupo: ajusta os identificadores para a numeração única da apuração
        debitos.Iof.ListaDebitos![0].IdDebito = 2;
        debitos.ContribuicoesDiversas.ListaDebitos![0].IdDebito = 3;

        var escrituracao = new Escrituracao
        {
            PeriodoApuracao = new PeriodoApuracao { MesApuracao = 12, AnoApuracao = 2025 },
            DadosIniciais = new DadosIniciais
            {
                SemMovimento = false,
                QualificacaoPj = 2,
                TributacaoLucro = 2,
                VariacoesMonetarias = 1,
                RegimePisCofins = 1,
                ResponsavelApuracao = new ResponsavelApuracao
                {
                    CpfResponsavel = "12345678900",
                    RegistroCrc = new RegistroCrc { UfRegistro = "SP", NumRegistro = "123456O3TMG" }
                }
            },
            Debitos = debitos,
            ListaSuspensoes =
            [
                new Suspensao
                {
                    TipoSuspensao = 2, MotivoSuspensao = 1, ComDeposito = true, NumeroProcesso = "98765431220251017777",
                    ProcessoTerceiro = false, DataDecisao = 20240920, VaraJudiciaria = 1, CodigoMunicipioSj = "5002704",
                    ListaDebitosSuspensos = [new DebitoSuspenso { IdDebitoSuspenso = 2, ValorSuspenso = 2000.00m }]
                },
                new Suspensao
                {
                    TipoSuspensao = 1, NumeroProcesso = "12345987654202450",
                    ListaDebitosSuspensos = [new DebitoSuspenso { IdDebitoSuspenso = 3, ValorSuspenso = 300.00m }]
                }
            ]
        };

        var json = new ApuracaoMit(escrituracao).SerializarDados();

        var esperado = JsonDocument.Parse("{\"PeriodoApuracao\":{\"MesApuracao\":12,\"AnoApuracao\":2025},\"DadosIniciais\":{\"SemMovimento\":false,\"QualificacaoPj\":2,\"TributacaoLucro\":2,\"VariacoesMonetarias\":1,\"RegimePisCofins\":1,\"ResponsavelApuracao\":{\"CpfResponsavel\":\"12345678900\",\"RegistroCrc\":{\"UfRegistro\":\"SP\",\"NumRegistro\":\"123456O3TMG\"}}},\"Debitos\":{\"Irpj\":{\"ListaDebitos\":[{\"IdDebito\":1,\"CodigoDebito\":\"159901\",\"ValorDebito\":24000.00}]},\"Iof\":{\"ListaDebitos\":[{\"IdDebito\":2,\"CodigoDebito\":\"115003\",\"PaDebito\":3,\"ValorDebito\":4000.00}]},\"ContribuicoesDiversas\":{\"ListaDebitos\":[{\"IdDebito\":3,\"CodigoDebito\":\"874101\",\"CnpjEstabelecimento\":\"000100\",\"ValorDebito\":300.00}]}},\"ListaSuspensoes\":[{\"TipoSuspensao\":2,\"MotivoSuspensao\":1,\"ComDeposito\":true,\"NumeroProcesso\":\"98765431220251017777\",\"ProcessoTerceiro\":false,\"DataDecisao\":20240920,\"VaraJudiciaria\":1,\"CodigoMunicipioSj\":\"5002704\",\"ListaDebitosSuspensos\":[{\"IdDebitoSuspenso\":2,\"ValorSuspenso\":2000.00}]},{\"TipoSuspensao\":1,\"NumeroProcesso\":\"12345987654202450\",\"ListaDebitosSuspensos\":[{\"IdDebitoSuspenso\":3,\"ValorSuspenso\":300.00}]}]}").RootElement;
        JsonElement.DeepEquals(JsonDocument.Parse(json).RootElement, esperado).Should().BeTrue(json);
    }

    [Test]
    public async Task MitConsultarSituacaoEncerramento_DeveEnviarProtocoloERetornarSituacao()
    {
        var handler = new HandlerFalso { Dados = "{\"idApuracao\":0,\"situacaoApuracao\":3,\"textoSituacao\":\"ENCERRADA\",\"avisosDctf\":null,\"dataEncerramento\":\"20250305\"}" };
        using var service = CriarServico(handler);

        var resposta = await service.MitConsultarSituacaoEncerramentoAsync(Contribuinte, "2fc4NTscrGXWTl4xbCX9rw==");

        VerificarPedido(handler, "Apoiar", "MIT", "SITUACAOENC315");
        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().Be(JsonSerializer.Serialize(new { protocoloEncerramento = "2fc4NTscrGXWTl4xbCX9rw==" }));
        DadosEnviados(handler).GetProperty("protocoloEncerramento").GetString().Should().Be("2fc4NTscrGXWTl4xbCX9rw==");
        var retorno = resposta.Retorno!;
        retorno.IdApuracao.Should().Be(0);
        retorno.SituacaoApuracao.Should().Be(SituacaoApuracaoMit.Encerrada);
        retorno.TextoSituacao.Should().Be("ENCERRADA");
        retorno.AvisosDctf.Should().BeNull();
        retorno.DataEncerramento.Should().Be("20250305");
    }

    [Test]
    public async Task MitConsultarSituacaoEncerramento_SemProtocolo_DeveLancarExcecao()
    {
        using var service = CriarServico(new HandlerFalso());

        await ((Func<Task>)(() => service.MitConsultarSituacaoEncerramentoAsync(Contribuinte, " "))).Should().ThrowAsync<ArgumentNullException>();
        await ((Func<Task>)(() => service.MitEncerrarApuracaoAsync(Contribuinte, new ApuracaoMit()))).Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MitConsultarApuracao_DeveRetornarDadosDaApuracao()
    {
        var handler = new HandlerFalso { Dados = "{\"situacaoApuracao\":3,\"textoSituacao\":\"ENCERRADA\",\"dadosApuracaoMit\":{\"PeriodoApuracao\":{\"MesApuracao\":2,\"AnoApuracao\":2025},\"DadosIniciais\":{\"SemMovimento\":true,\"QualificacaoPj\":1,\"ResponsavelApuracao\":{\"CpfResponsavel\":\"00000000000\"}},\"TransmissaoImediata\":false}}" };
        using var service = CriarServico(handler);

        var resposta = await service.MitConsultarApuracaoAsync(Contribuinte, 0);

        VerificarPedido(handler, "Consultar", "MIT", "CONSAPURACAO316");
        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().Be("{\"idApuracao\":0}");
        var retorno = resposta.Retorno!;
        retorno.SituacaoApuracao.Should().Be(SituacaoApuracaoMit.Encerrada);
        retorno.TextoSituacao.Should().Be("ENCERRADA");
        retorno.DadosApuracaoMit!.PeriodoApuracao!.MesApuracao.Should().Be(2);
        retorno.DadosApuracaoMit.PeriodoApuracao.AnoApuracao.Should().Be(2025);
        retorno.DadosApuracaoMit.DadosIniciais!.SemMovimento.Should().BeTrue();
        retorno.DadosApuracaoMit.DadosIniciais.QualificacaoPj.Should().Be(1);
        retorno.DadosApuracaoMit.DadosIniciais.ResponsavelApuracao!.CpfResponsavel.Should().Be("00000000000");
        retorno.DadosApuracaoMit.TransmissaoImediata.Should().BeFalse();
    }

    [Test]
    public async Task MitListarApuracoes_DeveEnviarFiltrosERetornarApuracoes()
    {
        var handler = new HandlerFalso { Dados = "{\"Apuracoes\": [{\"periodoApuracao\":202512,\"idApuracao\":0,\"situacao\":3,\"dataEncerramento\":\"20250218\",\"eventoEspecial\":false,\"valorTotalApurado\":1000.0},{\"periodoApuracao\":202512,\"idApuracao\":1,\"situacao\":3,\"dataEncerramento\":\"20250219\",\"eventoEspecial\":false,\"valorTotalApurado\":1500.0}]}" };
        using var service = CriarServico(handler);

        var resposta = await service.MitListarApuracoesAsync(Contribuinte, 2025, 2, SituacaoApuracaoMit.Encerrada);

        VerificarPedido(handler, "Consultar", "MIT", "LISTAAPURACOES317");
        var dados = DadosEnviados(handler);
        Campos(dados).Should().BeEquivalentTo("anoApuracao", "mesApuracao", "situacaoApuracao");
        dados.GetProperty("anoApuracao").GetInt32().Should().Be(2025);
        dados.GetProperty("mesApuracao").GetInt32().Should().Be(2);
        dados.GetProperty("situacaoApuracao").GetInt32().Should().Be(3);

        var apuracoes = resposta.Retorno!.Apuracoes!;
        apuracoes.Should().HaveCount(2);
        apuracoes[1].PeriodoApuracao.Should().Be(202512);
        apuracoes[1].IdApuracao.Should().Be(1);
        apuracoes[1].Situacao.Should().Be(SituacaoApuracaoMit.Encerrada);
        apuracoes[1].DataEncerramento.Should().Be("20250219");
        apuracoes[1].EventoEspecial.Should().BeFalse();
        apuracoes[1].ValorTotalApurado.Should().Be(1500.0m);
    }

    [Test]
    public async Task MitListarApuracoes_SoAno_DeveOmitirFiltrosOpcionais()
    {
        var handler = new HandlerFalso { Dados = "{\"Apuracoes\":[]}" };
        using var service = CriarServico(handler);

        await service.MitListarApuracoesAsync(Contribuinte, 2025);

        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().Be("{\"anoApuracao\":2025}");
    }
}
