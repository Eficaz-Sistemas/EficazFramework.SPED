using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraSicalc;
#nullable enable

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// Integra-Sicalc: CONSOLIDARGERARDARF51, CONSULTAAPOIORECEITAS52, GERARDARFCODBARRA53 e CONSOLIDAR54.
/// </summary>
public class IntegraSicalcTests : BaseIntegraContadorTests
{
    private const string Consolidado = "{\"valorPrincipalMoedaCorrente\": 1000.00, \"valorTotalConsolidado\": 1250.00, \"valorMultaMora\": 150.00, \"percentualMultaMora\": 15.00, \"valorJuros\": 100.00, \"percentualJuros\": 10.00, \"termoInicialJuros\": \"2018-02-01T00:00:00\", \"dataArrecadacaoConsolidacao\": \"2022-08-08T00:00:00\", \"dataValidadeCalculo\": \"2022-08-09T00:00:00\"}";

    /// <summary>Entrada do exemplo 1 da documentação (Darf de pessoa física).</summary>
    private static ConsolidarDarf Debito => new()
    {
        Uf = "SP",
        Municipio = "7107",
        CodigoReceita = "0190",
        CodigoReceitaExtensao = "01",
        TipoPA = "ME",
        DataPA = "12/2017",
        Vencimento = new DateTime(2018, 1, 31),
        ValorImposto = 1000.00m,
        DataConsolidacao = new DateTime(2022, 8, 8),
        Observacao = "Darf calculado"
    };

    private static void VerificarPedido(HandlerFalso handler, string idServico, string endpoint)
    {
        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().Be("https://gateway.apiserpro.serpro.gov.br/integra-contador/v1/" + endpoint);
        pedido.Requisicao.PedidoDados.IdSistema.Should().Be("SICALC");
        pedido.Requisicao.PedidoDados.IdServico.Should().Be(idServico);
        pedido.Requisicao.PedidoDados.VersaoSistema.Should().Be("2.9");
    }

    private static void VerificarDebitoEnviado(HandlerFalso handler)
    {
        var dados = DadosEnviados(handler);
        dados.EnumerateObject().Select(p => p.Name).Should().BeEquivalentTo(
            "uf", "municipio", "codigoReceita", "codigoReceitaExtensao", "tipoPA", "dataPA", "vencimento", "valorImposto", "dataConsolidacao", "observacao");
        dados.GetProperty("uf").GetString().Should().Be("SP");
        dados.GetProperty("municipio").GetString().Should().Be("7107");
        dados.GetProperty("codigoReceita").GetString().Should().Be("0190");
        dados.GetProperty("codigoReceitaExtensao").GetString().Should().Be("01");
        dados.GetProperty("tipoPA").GetString().Should().Be("ME");
        dados.GetProperty("dataPA").GetString().Should().Be("12/2017");
        dados.GetProperty("vencimento").GetString().Should().Be("2018-01-31T00:00:00");
        dados.GetProperty("valorImposto").GetString().Should().Be("1000.00");
        dados.GetProperty("dataConsolidacao").GetString().Should().Be("2022-08-08T00:00:00");
        dados.GetProperty("observacao").GetString().Should().Be("Darf calculado");
    }

    private static void VerificarConsolidado(ConsolidadoDarf? consolidado)
    {
        consolidado.Should().NotBeNull();
        consolidado!.ValorPrincipalMoedaCorrente.Should().Be(1000.00m);
        consolidado.ValorTotalConsolidado.Should().Be(1250.00m);
        consolidado.ValorMultaMora.Should().Be(150.00m);
        consolidado.PercentualMultaMora.Should().Be(15.00m);
        consolidado.ValorJuros.Should().Be(100.00m);
        consolidado.PercentualJuros.Should().Be(10.00m);
        consolidado.TermoInicialJuros.Should().Be(new DateTime(2018, 2, 1));
        consolidado.DataArrecadacaoConsolidacao.Should().Be(new DateTime(2022, 8, 8));
        consolidado.DataValidadeCalculo.Should().Be(new DateTime(2022, 8, 9));
    }

    [Test]
    public async Task ConsolidarGerarDarf_DeveEnviarDebitoELerDarf()
    {
        var handler = new HandlerFalso { Dados = $"{{\"consolidado\": {Consolidado}, \"darf\": \"JVBERi0xLjQKJeLjz9MKMy...\", \"numeroDocumento\": \"22080812345678901234\", \"qrCode\": \"00020101021226\"}}" };
        using var service = CriarServico(handler);

        var resposta = await service.SicalcConsolidarGerarDarfAsync(Contribuinte, Debito);

        VerificarPedido(handler, "CONSOLIDARGERARDARF51", "Emitir");
        VerificarDebitoEnviado(handler);
        VerificarConsolidado(resposta.Retorno!.Consolidado);
        resposta.Retorno.Darf.Should().Be("JVBERi0xLjQKJeLjz9MKMy...");
        resposta.Retorno.NumeroDocumento.Should().Be("22080812345678901234");
        resposta.Retorno.QrCode.Should().Be("00020101021226");
    }

    [Test]
    public async Task ConsolidarGerarDarf_DeveEnviarCotaComoTextoESemVencimento()
    {
        var handler = new HandlerFalso();
        using var service = CriarServico(handler);
        var debito = Debito;
        debito.Vencimento = null;
        debito.Cota = 1;
        debito.GanhoCapital = true;
        debito.DataAlienacao = new DateTime(2022, 3, 4, 10, 20, 30);
        debito.ValorMulta = 12.5m;

        await service.SicalcConsolidarGerarDarfAsync(Contribuinte, debito);

        var dados = DadosEnviados(handler);
        dados.TryGetProperty("vencimento", out _).Should().BeFalse();
        dados.GetProperty("cota").GetString().Should().Be("1");
        dados.GetProperty("ganhoCapital").GetBoolean().Should().BeTrue();
        dados.GetProperty("dataAlienacao").GetString().Should().Be("2022-03-04T10:20:30");
        dados.GetProperty("valorMulta").GetString().Should().Be("12.5");
    }

    [Test]
    public async Task ConsultarReceita_DeveEnviarCodigoELerExtensoes()
    {
        // exemplo "Consultar os atributos de uma receita" (codigoReceita numérico)
        var handler = new HandlerFalso
        {
            Dados = "{\"receita\": {\"codigoReceita\":6106,\"descricaoReceita\":\"Simples - Pagamento de Micro Empresa e Empresa de Pequeno Porte\",\"extensoes\":[{\"obrigatorios\":{\"codigoReceita\":true,\"codigoReceitaExtensao\":true,\"cota\":false,\"dataConsolidacao\":true,\"dataPA\":true,\"referencia\":false,\"tipoPA\":true,\"valorImposto\":true,\"vencimento\":false},\"informacoes\":{\"calculado\":true,\"codigoBarras\":true,\"codigoReceitaExtensao\":1,\"criacao\":\"1997-01-01T00:00:00\",\"descricaoReceitaExtensao\":\"SIMPLES - PAGAMENTO ME/EPP\",\"descricaoReferencia\":\"SEM REFERÊNCIA\",\"exigeMatriz\":true,\"extincao\":\"2007-06-30T00:00:00\",\"manual\":false,\"pf\":false,\"pj\":false,\"tipoPeriodoApuracao\":\"ME\",\"vedaValor\":true},\"opcionais\":{\"cno\":false,\"cnpjPrestador\":false,\"municipio\":true,\"observacao\":true,\"referencia\":true,\"uf\":true,\"valorJuros\":false,\"valorMulta\":false}}]}}"
        };
        using var service = CriarServico(handler);

        var resposta = await service.SicalcConsultarReceitaAsync(Contribuinte, "6106");

        VerificarPedido(handler, "CONSULTAAPOIORECEITAS52", "Apoiar");
        DadosEnviados(handler).GetProperty("codigoReceita").GetString().Should().Be("6106");

        var receita = resposta.Retorno!.Receita!;
        receita.CodigoReceita.Should().Be("6106");
        receita.DescricaoReceita.Should().StartWith("Simples - Pagamento");
        var extensao = receita.Extensoes!.Single();
        extensao.Obrigatorios!.CodigoReceita.Should().BeTrue();
        extensao.Obrigatorios.Cota.Should().BeFalse();
        extensao.Obrigatorios.TipoPA.Should().BeTrue();
        extensao.Obrigatorios.Vencimento.Should().BeFalse();
        extensao.Opcionais!.Municipio.Should().BeTrue();
        extensao.Opcionais.ValorMulta.Should().BeFalse();
        extensao.Informacoes!.CodigoReceitaExtensao.Should().Be("1");
        extensao.Informacoes.CodigoBarras.Should().BeTrue();
        extensao.Informacoes.Criacao.Should().Be(new DateTime(1997, 1, 1));
        extensao.Informacoes.Extincao.Should().Be(new DateTime(2007, 6, 30));
        extensao.Informacoes.DescricaoReferencia.Should().Be("SEM REFERÊNCIA");
        extensao.Informacoes.ExigeMatriz.Should().BeTrue();
        extensao.Informacoes.TipoPeriodoApuracao.Should().Be("ME");
        extensao.Informacoes.VedaValor.Should().BeTrue();
    }

    [Test]
    public async Task ConsultarReceita_DeveAceitarExtensoesSeparadasECodigoTexto()
    {
        // exemplo da página do serviço: um objeto por categoria no array extensoes
        var handler = new HandlerFalso
        {
            Dados = "{\"receita\": {\"codigoReceita\": \"6106\", \"descricaoReceita\": \"IRPF - Ganhos de Capital\", \"extensoes\": [{\"obrigatorios\": {\"codigoReceita\": true, \"codigoReceitaExtensao\": true, \"dataPA\": true, \"valorImposto\": true, \"dataConsolidacao\": true}}, {\"opcionais\": {\"dataAlienacao\": true, \"ganhoCapital\": true, \"observacao\": true}}, {\"informacoes\": {\"calculado\": true, \"codigoBarras\": true, \"pf\": true, \"pj\": false}}]}}"
        };
        using var service = CriarServico(handler);

        var resposta = await service.SicalcConsultarReceitaAsync(Contribuinte, "6106");

        var receita = resposta.Retorno!.Receita!;
        receita.CodigoReceita.Should().Be("6106");
        receita.Extensoes.Should().HaveCount(3);
        receita.Extensoes![0].Obrigatorios!.DataPA.Should().BeTrue();
        receita.Extensoes[1].Opcionais!.GanhoCapital.Should().BeTrue();
        receita.Extensoes[2].Informacoes!.Pf.Should().BeTrue();
        receita.Extensoes[2].Informacoes!.Pj.Should().BeFalse();
    }

    [Test]
    public async Task GerarDarfCodigoBarras_DeveLerCodigoDeBarras()
    {
        var handler = new HandlerFalso { Dados = $"{{\"consolidado\": {Consolidado}, \"codigoDeBarras\": {{\"codigo44\": \"11620000011500071071162019202201\", \"campo1ComDV\": \"11620.00001\", \"campo2ComDV\": \"11500.007107\", \"campo3ComDV\": \"71162.019202\", \"campo4ComDV\": \"201\"}}, \"numeroDocumento\": \"22080812345678901234\"}}" };
        using var service = CriarServico(handler);

        var resposta = await service.SicalcGerarDarfCodigoBarrasAsync(Contribuinte, Debito);

        VerificarPedido(handler, "GERARDARFCODBARRA53", "Emitir");
        VerificarDebitoEnviado(handler);
        VerificarConsolidado(resposta.Retorno!.Consolidado);
        var codigo = resposta.Retorno.CodigoDeBarras!;
        codigo.Codigo44.Should().Be("11620000011500071071162019202201");
        codigo.Campo1ComDV.Should().Be("11620.00001");
        codigo.Campo2ComDV.Should().Be("11500.007107");
        codigo.Campo3ComDV.Should().Be("71162.019202");
        codigo.Campo4ComDV.Should().Be("201");
        resposta.Retorno.NumeroDocumento.Should().Be("22080812345678901234");
        resposta.Retorno.QrCode.Should().BeNull();
    }

    [Test]
    public async Task Consolidar_DeveLerValoresComoTexto()
    {
        // exemplo "Consolidar DARF com CNPJ alfanumérico": valores retornados como texto
        var handler = new HandlerFalso { Dados = "{\"consolidado\": {\"dataArrecadacaoConsolidacao\":\"2026-06-22T00:00:00\",\"dataValidadeCalculo\":\"2026-06-30T00:00:00\",\"percentualJuros\":\"58.49\",\"percentualMultaMora\":\"20.00\",\"termoInicialJuros\":\"2021-03-01T00:00:00\",\"valorJuros\":\"584.90\",\"valorMultaMora\":\"200.00\",\"valorPrincipalMoedaCorrente\":\"1000.00\",\"valorTotalConsolidado\":\"1784.90\"}}" };
        using var service = CriarServico(handler);
        var debito = new ConsolidarDarf
        {
            Uf = "SP",
            Municipio = "7107",
            CodigoReceita = "1162",
            CodigoReceitaExtensao = "1",
            DataPA = "01/2021",
            ValorImposto = 1000.00m,
            CnpjPrestador = "QZRC7JM7205500",
            DataConsolidacao = new DateTime(2026, 6, 22)
        };

        var resposta = await service.SicalcConsolidarAsync(Identificacao.Cnpj("YV9IAOAXNTRV65"), debito);

        VerificarPedido(handler, "CONSOLIDAR54", "Consultar");
        DadosEnviados(handler).GetProperty("cnpjPrestador").GetString().Should().Be("QZRC7JM7205500");
        var consolidado = resposta.Retorno!.Consolidado!;
        consolidado.ValorTotalConsolidado.Should().Be(1784.90m);
        consolidado.PercentualJuros.Should().Be(58.49m);
        consolidado.ValorJuros.Should().Be(584.90m);
        consolidado.TermoInicialJuros.Should().Be(new DateTime(2021, 3, 1));
        consolidado.DataValidadeCalculo.Should().Be(new DateTime(2026, 6, 30));
    }

    [Test]
    public async Task ArgumentosNulos_DevemLancarArgumentNullException()
    {
        using var service = CriarServico(new HandlerFalso());

        await FluentActions.Awaiting(() => service.SicalcConsolidarGerarDarfAsync(Contribuinte, null!)).Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.SicalcGerarDarfCodigoBarrasAsync(Contribuinte, null!)).Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.SicalcConsolidarAsync(Contribuinte, null!)).Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.SicalcConsultarReceitaAsync(Contribuinte, " ")).Should().ThrowAsync<ArgumentNullException>();
    }
}
