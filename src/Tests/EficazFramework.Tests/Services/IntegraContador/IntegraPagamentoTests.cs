using EficazFramework.SPED.Schemas.IntegraContador.IntegraPagamento;

#nullable enable

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// Integra-Pagamento: PAGAMENTOS71, COMPARRECADACAO72 e CONTACONSDOCARRPG73.
/// </summary>
public class IntegraPagamentoTests : BaseIntegraContadorTests
{
    private static void VerificarPedido(HandlerFalso handler, string idServico, string endpoint)
    {
        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().Be("https://gateway.apiserpro.serpro.gov.br/integra-contador/v1/" + endpoint);
        pedido.Requisicao.PedidoDados.IdSistema.Should().Be("PAGTOWEB");
        pedido.Requisicao.PedidoDados.IdServico.Should().Be(idServico);
        pedido.Requisicao.PedidoDados.VersaoSistema.Should().Be("1.0");
    }

    [Test]
    public async Task ConsultarPagamentos_DeveEnviarFiltrosELerDocumentos()
    {
        // exemplo "Cenário de arrecadação via DARF"
        var handler = new HandlerFalso
        {
            Dados = "[{\"numeroDocumento\":\"9999999999\",\"tipo\":{\"codigo\":\"4\",\"descricao\":\"DOCUMENTO DE ARRECADAÇÃO DE RECEITAS FEDERAIS\",\"descricaoAbreviada\":\"DARF\"},\"periodoApuracao\":\"2019-09-30T00:00:00-03:00\",\"dataArrecadacao\":\"2019-09-30T00:00:00-03:00\",\"dataVencimento\":\"2019-09-30T00:00:00-03:00\",\"receitaPrincipal\":{\"codigo\":\"481\",\"descricao\":\"IRRF - Juros e Comissões em Geral - Residentes no Exterior\",\"extensaoReceita\":null},\"referencia\":null,\"valorTotal\":369176.53,\"valorPrincipal\":369176.53,\"valorMulta\":null,\"valorJuros\":null,\"valorSaldoTotal\":null,\"valorSaldoPrincipal\":null,\"valorSaldoMulta\":null,\"valorSaldoJuros\":null,\"desmembramentos\":[{\"sequencial\":\"1\",\"receitaPrincipal\":{\"codigo\":\"151\",\"descricao\":\"INSS - SImples Nacional - MEI\",\"extensaoReceita\":{\"codigo\":\"1\",\"descricao\":\"INSS - SIMPLES NACIONAL - MEI\"}},\"periodoApuracao\":\"2019-09-30T00:00:00-03:00\",\"dataVencimento\":\"2019-09-30T00:00:00-03:00\",\"valorTotal\":60.6,\"valorPrincipal\":60.6,\"valorMulta\":0,\"valorJuros\":0,\"valorSaldoTotal\":0,\"valorSaldoPrincipal\":0,\"valorSaldoMulta\":0,\"valorSaldoJuros\":0,\"cib\":null}]}]"
        };
        using var service = CriarServico(handler);
        var consulta = new ConsultaPagamentos
        {
            NumeroDocumentoLista = ["9999999999"],
            CodigoReceitaLista = ["0481"],
            IntervaloDataArrecadacao = new IntervaloData { DataInicial = new DateOnly(2019, 9, 1), DataFinal = new DateOnly(2019, 11, 30) },
            IntervaloValorTotalDocumento = new IntervaloValor { ValorInicial = 600, ValorFinal = 13000.50m },
            CodigoTipoDocumentoLista = ["04"],
            PrimeiroDaPagina = 0,
            TamanhoDaPagina = 100
        };

        var resposta = await service.PagtoWebConsultarPagamentosAsync(Contribuinte, consulta);

        VerificarPedido(handler, "PAGAMENTOS71", "Consultar");
        var dados = DadosEnviados(handler);
        dados.EnumerateObject().Select(p => p.Name).Should().BeEquivalentTo(
            "numeroDocumentoLista", "codigoReceitaLista", "intervaloDataArrecadacao", "intervaloValorTotalDocumento",
            "codigoTipoDocumentoLista", "primeiroDaPagina", "tamanhoDaPagina");
        dados.GetProperty("numeroDocumentoLista")[0].GetString().Should().Be("9999999999");
        dados.GetProperty("codigoReceitaLista")[0].GetString().Should().Be("0481");
        dados.GetProperty("intervaloDataArrecadacao").GetProperty("dataInicial").GetString().Should().Be("2019-09-01");
        dados.GetProperty("intervaloDataArrecadacao").GetProperty("dataFinal").GetString().Should().Be("2019-11-30");
        dados.GetProperty("intervaloValorTotalDocumento").GetProperty("valorInicial").GetDecimal().Should().Be(600);
        dados.GetProperty("intervaloValorTotalDocumento").GetProperty("valorFinal").GetDecimal().Should().Be(13000.50m);
        dados.GetProperty("codigoTipoDocumentoLista")[0].GetString().Should().Be("04");
        dados.GetProperty("primeiroDaPagina").GetInt32().Should().Be(0);
        dados.GetProperty("tamanhoDaPagina").GetInt32().Should().Be(100);

        var documento = resposta.Retorno!.Single();
        documento.NumeroDocumento.Should().Be("9999999999");
        documento.Tipo!.Codigo.Should().Be("4");
        documento.Tipo.DescricaoAbreviada.Should().Be("DARF");
        documento.PeriodoApuracao.Should().Be(new DateTimeOffset(2019, 9, 30, 0, 0, 0, TimeSpan.FromHours(-3)));
        documento.DataArrecadacao.Should().Be(new DateTimeOffset(2019, 9, 30, 0, 0, 0, TimeSpan.FromHours(-3)));
        documento.ReceitaPrincipal!.Codigo.Should().Be("481");
        documento.ReceitaPrincipal.ExtensaoReceita.Should().BeNull();
        documento.Referencia.Should().BeNull();
        documento.ValorTotal.Should().Be(369176.53m);
        documento.ValorMulta.Should().BeNull();
        var desmembramento = documento.Desmembramentos!.Single();
        desmembramento.Sequencial.Should().Be("1");
        desmembramento.ReceitaPrincipal!.ExtensaoReceita!.Codigo.Should().Be("1");
        desmembramento.ReceitaPrincipal.ExtensaoReceita.Descricao.Should().Be("INSS - SIMPLES NACIONAL - MEI");
        desmembramento.ValorTotal.Should().Be(60.6m);
        desmembramento.ValorSaldoJuros.Should().Be(0);
        desmembramento.Cib.Should().BeNull();
    }

    [Test]
    public async Task ConsultarPagamentos_DeveOmitirFiltrosNaoInformados()
    {
        var handler = new HandlerFalso { Dados = "[]" };
        using var service = CriarServico(handler);

        var resposta = await service.PagtoWebConsultarPagamentosAsync(Contribuinte, new ConsultaPagamentos { CodigoReceitaLista = ["9999", "9999"], TamanhoDaPagina = 10 });

        var dados = DadosEnviados(handler);
        dados.EnumerateObject().Select(p => p.Name).Should().BeEquivalentTo("codigoReceitaLista", "primeiroDaPagina", "tamanhoDaPagina");
        dados.GetProperty("tamanhoDaPagina").GetInt32().Should().Be(10);
        resposta.Retorno.Should().BeEmpty();
    }

    [Test]
    public async Task EmitirComprovante_DeveEnviarNumeroELerPdf()
    {
        var handler = new HandlerFalso { Dados = "{\"pdf\":\"JVBERi0xLjcNJeLjz9MNCjEgMCBvYmo=\"}" };
        using var service = CriarServico(handler);

        var resposta = await service.PagtoWebEmitirComprovanteAsync(Contribuinte, "07082216654265000");

        VerificarPedido(handler, "COMPARRECADACAO72", "Emitir");
        var dados = DadosEnviados(handler);
        dados.EnumerateObject().Select(p => p.Name).Should().Equal("numeroDocumento");
        dados.GetProperty("numeroDocumento").GetString().Should().Be("07082216654265000");
        resposta.Retorno!.Pdf.Should().Be("JVBERi0xLjcNJeLjz9MNCjEgMCBvYmo=");
    }

    [Test]
    public async Task EmitirComprovante_DeveAceitarBase64Puro()
    {
        var handler = new HandlerFalso { Dados = "JVBERi0xLjcNJeLjz9MNCjEgMCBvYmo=" };
        using var service = CriarServico(handler);

        var resposta = await service.PagtoWebEmitirComprovanteAsync(Contribuinte, "99999999999999999");

        resposta.Retorno!.Pdf.Should().Be("JVBERi0xLjcNJeLjz9MNCjEgMCBvYmo=");
    }

    [Test]
    public async Task ContarPagamentos_DeveEnviarSomenteFiltrosELerQuantidade()
    {
        var handler = new HandlerFalso { Dados = "1" };
        using var service = CriarServico(handler);
        FiltroPagamentos filtro = new ConsultaPagamentos { NumeroDocumentoLista = ["9999999999"] };

        var resposta = await service.PagtoWebContarPagamentosAsync(Contribuinte, filtro);

        VerificarPedido(handler, "CONTACONSDOCARRPG73", "Consultar");
        var dados = DadosEnviados(handler);
        dados.EnumerateObject().Select(p => p.Name).Should().Equal("numeroDocumentoLista");
        resposta.Retorno.Should().Be(1);
    }

    [Test]
    public async Task ArgumentosNulos_DevemLancarArgumentNullException()
    {
        using var service = CriarServico(new HandlerFalso());

        await FluentActions.Awaiting(() => service.PagtoWebConsultarPagamentosAsync(Contribuinte, null!)).Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.PagtoWebEmitirComprovanteAsync(Contribuinte, "")).Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.PagtoWebContarPagamentosAsync(Contribuinte, null!)).Should().ThrowAsync<ArgumentNullException>();
    }
}
