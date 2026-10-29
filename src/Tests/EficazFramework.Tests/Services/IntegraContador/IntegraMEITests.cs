using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraMEI;
using System.Text.Json;

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// Integra-MEI: PGMEI (21 a 24) e CCMEI (121 a 123), com os exemplos de retorno da documentação.
/// </summary>
public class IntegraMEITests : BaseIntegraContadorTests
{
    private const string DasPdfJson = """
        [{"cnpjCompleto":"00000000000100","razaoSocial":"EXEMPLO","pdf":"JVBERi0xLjQK",
          "detalhamento":[{"periodoApuracao":"201901","numeroDocumento":"00000000000000000","dataVencimento":"20190220",
            "dataLimiteAcolhimento":"20220831","valores":{"principal":55.90,"multa":11.18,"juros":10.71,"total":77.79},
            "observacao1":"CPF: 000.000.000-00","observacao2":"Tributos (R$): INSS 49,90 ICMS 1,00 ISS 5,00","observacao3":"PGMEI(Versao:3.8.0)",
            "composicao":[
              {"periodoApuracao":201901,"codigo":"0151","denominacao":"INSS - SIMPLES NACIONAL - MEI - 01/2019","valores":{"principal":49.90,"multa":9.98,"juros":9.56,"total":69.44}},
              {"periodoApuracao":201901,"codigo":"0083","denominacao":"ICMS - SIMPLES NACIONAL - MEI - PB - 01/2019","valores":{"principal":1.00,"multa":0.20,"juros":0.19,"total":1.39}},
              {"periodoApuracao":201901,"codigo":"0125","denominacao":"ISS - SIMPLES NACIONAL - MEI - SUME (PB) - 01/2019","valores":{"principal":5.00,"multa":1.00,"juros":0.96,"total":6.96}}]}]}]
        """;

    private const string DasCodigoBarrasJson = """
        [{"cnpjCompleto":"11111111111111","razaoSocial":"AAUVAA AAIWWAA",
          "detalhamento":[{"periodoApuracao":"202601","valores":{"juros":0.86,"multa":5.39,"principal":86.05,"total":92.3},
            "dataLimiteAcolhimento":"20260313","dataVencimento":"20260220","numeroDocumento":"00000000000000000",
            "codigoDeBarras":["000000000001","000000000002","000000000003","000000000004"],
            "observacao1":"CPF: 000.000.000-00","observacao2":"Tributos (R$): INSS 81,05 ICMS 0,00 ISS 5,00","observacao3":"PGMEI(Versao:3.16.2)",
            "composicao":[
              {"codigo":"0151","denominacao":"INSS - SIMPLES NACIONAL - MEI - 01/2026","periodoApuracao":202601,"valores":{"juros":0.81,"multa":5.08,"principal":81.05,"total":86.94}},
              {"codigo":"0125","denominacao":"ISS - SIMPLES NACIONAL - MEI - LUCAS DO RIO VERDE (MT) - 01/2026","periodoApuracao":202601,"valores":{"juros":0.05,"multa":0.31,"principal":5.0,"total":5.36}}]}]}]
        """;

    private const string DadosCcmeiJson = """
        {"cnpj":"00000000000000","empresario":{"nomeCivil":"AQUI VAI O NOME CIVIL","nomeSocial":null,"cpf":"99999999999"},
         "dataInicioAtividades":"2020-01-01","nomeEmpresarial":"AQUI VAI O NOME EMPRESARIAL","capitalSocial":1000.00,
         "situacaoCadastralVigente":"ATIVA","dataInicioSituacaoCadastral":"2020-01-01",
         "enderecoComercial":{"cep":"99999999","logradouro":"AQUI VAI O NOME DO LOGRADOURO","numero":"999","complemento":"","bairro":"AQUI VAI O BAIRRO","municipio":"NOME DO MUNICIPIO","uf":"UF"},
         "enquadramento":{"periodosMei":[{"indice":1,"dataInicio":"2020-01-01T00:00:00","dataFim":null}],"situacao":"Enquadrado na condição de MEI","optanteMei":true},
         "atividade":{"formasAtuacao":["Estabelecimento fixo","Internet"],
           "ocupacaoPrincipal":{"descricaoOcupacao":"AQUI VAI A DESCRICAO DA OCUPACAO","codigoCNAE":"9999-9/99","descricaoCNAE":"DESCRICAO DA CNAE"},
           "ocupacoesSecundarias":[{"descricaoOcupacao":"DESCRICAO DA OCUPACAO","codigoCNAE":"9999999","descricaoCNAE":"DESCRICAO DA CNAE"}]},
         "termoCienciaDispensa":{"titulo":"Termo de Ciência e Responsabilidade com Efeito de Dispensa de Alvará e Licença de Funcionamento","texto":"Declaro, sob as penas da Lei, ..."},
         "qrCode":null}
        """;

    private static void DeveChamar(HandlerFalso handler, string endpoint, string idSistema, string idServico, string versao)
    {
        var pedido = handler.Chamadas.Single();
        pedido.Url.Should().EndWith("/" + endpoint);
        var requisicao = pedido.Requisicao;
        requisicao.PedidoDados.IdSistema.Should().Be(idSistema);
        requisicao.PedidoDados.IdServico.Should().Be(idServico);
        requisicao.PedidoDados.VersaoSistema.Should().Be(versao);
        requisicao.Contribuinte.Should().Be(Contribuinte);
    }

    // ---------------------------------------------------------------------------------------------- PGMEI

    [Test]
    public async Task PgmeiGerarDasPdf_DeveEnviarPeriodoELerDas()
    {
        var handler = new HandlerFalso { Dados = DasPdfJson };
        using var service = CriarServico(handler);

        var resposta = await service.PgmeiGerarDasPdfAsync(Contribuinte, new GerarDas { PeriodoApuracao = "201901" });

        DeveChamar(handler, "Emitir", "PGMEI", "GERARDASPDF21", "1.0");
        var dados = DadosEnviados(handler);
        dados.GetProperty("periodoApuracao").GetString().Should().Be("201901");
        dados.TryGetProperty("dataConsolidacao", out _).Should().BeFalse("campo opcional nulo não é enviado");

        var das = resposta.Retorno!.Single();
        das.CnpjCompleto.Should().Be("00000000000100");
        das.RazaoSocial.Should().Be("EXEMPLO");
        das.Pdf.Should().Be("JVBERi0xLjQK");
        var detalhe = das.Detalhamento!.Single();
        detalhe.PeriodoApuracao.Should().Be("201901");
        detalhe.NumeroDocumento.Should().Be("00000000000000000");
        detalhe.DataVencimento.Should().Be("20190220");
        detalhe.DataLimiteAcolhimento.Should().Be("20220831");
        detalhe.Valores!.Principal.Should().Be(55.90m);
        detalhe.Valores.Multa.Should().Be(11.18m);
        detalhe.Valores.Juros.Should().Be(10.71m);
        detalhe.Valores.Total.Should().Be(77.79m);
        detalhe.Observacao1.Should().Be("CPF: 000.000.000-00");
        detalhe.Observacao3.Should().Be("PGMEI(Versao:3.8.0)");
        detalhe.CodigoDeBarras.Should().BeNull();
        detalhe.Composicao.Should().HaveCount(3);
        detalhe.Composicao![0].PeriodoApuracao.Should().Be(201901);
        detalhe.Composicao[0].Codigo.Should().Be("0151");
        detalhe.Composicao[0].Denominacao.Should().StartWith("INSS");
        detalhe.Composicao[0].Valores!.Total.Should().Be(69.44m);
    }

    [Test]
    public async Task PgmeiGerarDasCodigoBarras_DeveEnviarConsolidacaoELerCodigoDeBarras()
    {
        var handler = new HandlerFalso { Dados = DasCodigoBarrasJson };
        using var service = CriarServico(handler);

        var resposta = await service.PgmeiGerarDasCodigoBarrasAsync(Contribuinte, new GerarDas { PeriodoApuracao = "202601", DataConsolidacao = "20260313" });

        DeveChamar(handler, "Emitir", "PGMEI", "GERARDASCODBARRA22", "1.0");
        var dados = DadosEnviados(handler);
        dados.GetProperty("periodoApuracao").GetString().Should().Be("202601");
        dados.GetProperty("dataConsolidacao").GetString().Should().Be("20260313");

        var das = resposta.Retorno!.Single();
        das.Pdf.Should().BeNull();
        das.CnpjCompleto.Should().Be("11111111111111");
        var detalhe = das.Detalhamento!.Single();
        detalhe.CodigoDeBarras.Should().Equal("000000000001", "000000000002", "000000000003", "000000000004");
        detalhe.Valores!.Total.Should().Be(92.3m);
        detalhe.Composicao!.Select(c => c.Codigo).Should().Equal("0151", "0125");
        detalhe.Composicao[1].Valores!.Juros.Should().Be(0.05m);
    }

    [Test]
    public async Task PgmeiGerarDas_DeveAceitarDetalhamentoComoObjetoEPeriodoComoTexto()
    {
        // a tabela da documentação descreve detalhamento como objeto e composicao.periodoApuracao como texto
        var handler = new HandlerFalso
        {
            Dados = """[{"cnpjCompleto":"1","detalhamento":{"periodoApuracao":"Diversos","composicao":[{"periodoApuracao":"201902","codigo":"0151"}]}}]"""
        };
        using var service = CriarServico(handler);

        var resposta = await service.PgmeiGerarDasPdfAsync(Contribuinte, new GerarDas { PeriodoApuracao = "201901" });

        var detalhe = resposta.Retorno!.Single().Detalhamento!.Single();
        detalhe.PeriodoApuracao.Should().Be("Diversos");
        detalhe.Composicao!.Single().PeriodoApuracao.Should().Be(201902);
    }

    [Test]
    public async Task PgmeiAtualizarBeneficio_DeveEnviarBeneficiosELerAgrupamento()
    {
        var handler = new HandlerFalso
        {
            Dados = """[{"paOriginal":"202601","indicadorBeneficio":true,"paAgrupado":"202602"},{"paOriginal":"202602","indicadorBeneficio":true,"paAgrupado":"202601"}]"""
        };
        using var service = CriarServico(handler);

        var resposta = await service.PgmeiAtualizarBeneficioAsync(Contribuinte, new AtualizarBeneficio
        {
            AnoCalendario = 2026,
            InfoBeneficio =
            [
                new InfoBeneficio { PeriodoApuracao = "202601", IndicadorBeneficio = true },
                new InfoBeneficio { PeriodoApuracao = "202602", IndicadorBeneficio = true }
            ]
        });

        DeveChamar(handler, "Emitir", "PGMEI", "ATUBENEFICIO23", "1.0");
        var dados = DadosEnviados(handler);
        dados.GetProperty("anoCalendario").ValueKind.Should().Be(JsonValueKind.Number);
        dados.GetProperty("anoCalendario").GetInt32().Should().Be(2026);
        var beneficio = dados.GetProperty("infoBeneficio")[0];
        beneficio.GetProperty("periodoApuracao").GetString().Should().Be("202601");
        beneficio.GetProperty("indicadorBeneficio").GetBoolean().Should().BeTrue();

        resposta.Retorno.Should().HaveCount(2);
        resposta.Retorno![0].PaOriginal.Should().Be("202601");
        resposta.Retorno[0].IndicadorBeneficio.Should().BeTrue();
        resposta.Retorno[0].PaAgrupado.Should().Be("202602");
    }

    [Test]
    public async Task PgmeiConsultarDividaAtiva_DeveEnviarAnoELerDebitos()
    {
        var handler = new HandlerFalso
        {
            Dados = """[{"periodoApuracao":"201901","tributo":"INSS","valor":49.90,"enteFederado":"Uniao","situacaoDebito":"ENVIADO A  PFN"},{"periodoApuracao":"201902","tributo":"INSS","valor":49.90,"enteFederado":"Uniao","situacaoDebito":"ENVIADO A  PFN"}]"""
        };
        using var service = CriarServico(handler);

        var resposta = await service.PgmeiConsultarDividaAtivaAsync(Contribuinte, new ConsultarDividaAtiva { AnoCalendario = "2019" });

        DeveChamar(handler, "Consultar", "PGMEI", "DIVIDAATIVA24", "1.0");
        DadosEnviados(handler).GetProperty("anoCalendario").GetString().Should().Be("2019");

        resposta.Retorno.Should().HaveCount(2);
        var debito = resposta.Retorno![0];
        debito.PeriodoApuracao.Should().Be("201901");
        debito.Tributo.Should().Be("INSS");
        debito.Valor.Should().Be(49.90m);
        debito.EnteFederado.Should().Be("Uniao");
        debito.SituacaoDebito.Should().Be("ENVIADO A  PFN");
    }

    [Test]
    public async Task Pgmei_DadosNulos_DeveLancarArgumentNull()
    {
        using var service = CriarServico(new HandlerFalso());

        await FluentActions.Awaiting(() => service.PgmeiGerarDasPdfAsync(Contribuinte, null!)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dados");
        await FluentActions.Awaiting(() => service.PgmeiGerarDasCodigoBarrasAsync(Contribuinte, null!)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dados");
        await FluentActions.Awaiting(() => service.PgmeiAtualizarBeneficioAsync(Contribuinte, null!)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dados");
        await FluentActions.Awaiting(() => service.PgmeiConsultarDividaAtivaAsync(Contribuinte, null!)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dados");
    }

    // ---------------------------------------------------------------------------------------------- CCMEI

    [Test]
    public async Task CcmeiEmitir_DeveEnviarDadosVaziosELerPdf()
    {
        var handler = new HandlerFalso { Dados = """[{"cnpj":"00000000000000","pdf":"JVBERi0xLjQK"}]""" };
        using var service = CriarServico(handler);

        var resposta = await service.CcmeiEmitirAsync(Contribuinte);

        DeveChamar(handler, "Emitir", "CCMEI", "EMITIRCCMEI121", "1.0");
        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().BeEmpty();
        var ccmei = resposta.Retorno!.Single();
        ccmei.Cnpj.Should().Be("00000000000000");
        ccmei.Pdf.Should().Be("JVBERi0xLjQK");
    }

    [Test]
    public async Task CcmeiConsultarDados_DeveLerDadosDoCertificado()
    {
        var handler = new HandlerFalso { Dados = DadosCcmeiJson };
        using var service = CriarServico(handler);

        var resposta = await service.CcmeiConsultarDadosAsync(Contribuinte);

        DeveChamar(handler, "Consultar", "CCMEI", "DADOSCCMEI122", "1.0");
        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().BeEmpty();

        var dados = resposta.Retorno!;
        dados.Cnpj.Should().Be("00000000000000");
        dados.Empresario!.NomeCivil.Should().Be("AQUI VAI O NOME CIVIL");
        dados.Empresario.NomeSocial.Should().BeNull();
        dados.Empresario.Cpf.Should().Be("99999999999");
        dados.DataInicioAtividades.Should().Be("2020-01-01");
        dados.NomeEmpresarial.Should().Be("AQUI VAI O NOME EMPRESARIAL");
        dados.CapitalSocial.Should().Be(1000m);
        dados.SituacaoCadastralVigente.Should().Be("ATIVA");
        dados.DataInicioSituacaoCadastral.Should().Be("2020-01-01");
        dados.EnderecoComercial!.Cep.Should().Be("99999999");
        dados.EnderecoComercial.Numero.Should().Be("999");
        dados.EnderecoComercial.Uf.Should().Be("UF");
        dados.EnderecoComercial.Municipio.Should().Be("NOME DO MUNICIPIO");
        var periodo = dados.Enquadramento!.PeriodosMei!.Single();
        periodo.Indice.Should().Be(1);
        periodo.DataInicio.Should().Be("2020-01-01T00:00:00");
        periodo.DataFim.Should().BeNull();
        dados.Enquadramento.Situacao.Should().Be("Enquadrado na condição de MEI");
        dados.Enquadramento.OptanteMei.Should().BeTrue();
        dados.Atividade!.FormasAtuacao.Should().Equal("Estabelecimento fixo", "Internet");
        dados.Atividade.OcupacaoPrincipal!.CodigoCnae.Should().Be("9999-9/99");
        dados.Atividade.OcupacaoPrincipal.DescricaoCnae.Should().Be("DESCRICAO DA CNAE");
        dados.Atividade.OcupacoesSecundarias!.Single().DescricaoOcupacao.Should().Be("DESCRICAO DA OCUPACAO");
        dados.TermoCienciaDispensa!.Titulo.Should().StartWith("Termo de Ciência");
        dados.TermoCienciaDispensa.Texto.Should().StartWith("Declaro");
        dados.QrCode.Should().BeNull();
    }

    [Test]
    public async Task CcmeiConsultarSituacaoCadastral_DeveLerCnpjs()
    {
        var handler = new HandlerFalso
        {
            Dados = """[{"cnpj":"00000000000000","situacao":"BAIXADA","enquadradoMei":true},{"cnpj":"11111111111111","situacao":"ATIVA","enquadradoMei":true}]"""
        };
        using var service = CriarServico(handler);

        var resposta = await service.CcmeiConsultarSituacaoCadastralAsync(Contribuinte);

        DeveChamar(handler, "Consultar", "CCMEI", "CCMEISITCADASTRAL123", "1.0");
        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().BeEmpty();
        resposta.Retorno.Should().HaveCount(2);
        resposta.Retorno![0].Cnpj.Should().Be("00000000000000");
        resposta.Retorno[0].Situacao.Should().Be("BAIXADA");
        resposta.Retorno[0].EnquadradoMei.Should().BeTrue();
        resposta.Retorno[1].Situacao.Should().Be("ATIVA");
    }
}
