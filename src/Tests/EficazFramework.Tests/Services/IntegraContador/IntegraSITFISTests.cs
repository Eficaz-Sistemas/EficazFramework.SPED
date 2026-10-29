using EficazFramework.SPED.Schemas.IntegraContador;
using System.Net;
using System.Net.Http;
using System.Threading;

#nullable enable

namespace EficazFramework.SPED.Services.IntegraContador;

/// <summary>
/// Integra-SITFIS: SOLICITARPROTOCOLO91, RELATORIOSITFIS92 e a obtenção do relatório com novas tentativas.
/// </summary>
public class IntegraSITFISTests : BaseIntegraContadorTests
{
    private const string Protocolo = "+S7N6c04XNZUVzmxWT7SzpkZA4xeDQC9Z2T2GBJ5usn8LyouyWXbsy6mKsLyEImRkDjF4NAL25KiSXOLjnzAaZu/FC+G1pYOtTMYqokKYYr/yZ6aqUiCuWPfujDQ2/udw+Dyh56GSe28B5Ev25jDnzpvVJPhiebO5hpy1YESP5gnEhaP3bocCiZZrYG26F8avRRBJhRTsfv3op+bxvYJZsVym270eO8oZTDIr3OJj==";
    private const string Pdf = "JVBERi0xLjUKJcOkw7zDtsOfCjIgMCBvYmoK";

    /// <summary>Serviço que registra as esperas em vez de aguardar.</summary>
    private sealed class ServicoSemEspera(HttpMessageHandler handler) : IntegraContadorService(handler)
    {
        public List<TimeSpan> Esperas { get; } = [];

        protected override Task AguardarAsync(TimeSpan espera, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            Esperas.Add(espera);
            return Task.CompletedTask;
        }
    }

    private ServicoSemEspera CriarServicoSemEspera(HandlerFalso handler) => new(handler)
    {
        SelecionaCertificado = InstanciaCertificado,
        ConsumerKey = "chave",
        ConsumerSecret = "segredo",
        Contratante = Identificacao.Cnpj(CnpjContratante)
    };

    private static string ProtocoloJson(int tempoEspera) =>
        $"{{\"protocoloRelatorio\":\"{Protocolo}\", \"tempoEspera\":{tempoEspera}}}";

    private static void VerificarChamada(BaseIntegraContadorTests.Pedido pedido, string idServico, string endpoint)
    {
        pedido.Url.Should().Be("https://gateway.apiserpro.serpro.gov.br/integra-contador/v1/" + endpoint);
        pedido.Requisicao.PedidoDados.IdSistema.Should().Be("SITFIS");
        pedido.Requisicao.PedidoDados.IdServico.Should().Be(idServico);
        pedido.Requisicao.PedidoDados.VersaoSistema.Should().Be("2.0");
    }

    [Test]
    public async Task SolicitarProtocolo_DeveEnviarDadosVazioELerProtocolo()
    {
        var handler = new HandlerFalso { Dados = ProtocoloJson(30) };
        using var service = CriarServico(handler);

        var resposta = await service.SitfisSolicitarProtocoloAsync(Contribuinte);

        VerificarChamada(handler.Chamadas.Single(), "SOLICITARPROTOCOLO91", "Apoiar");
        handler.Chamadas.Single().Requisicao.PedidoDados.Dados.Should().BeEmpty();
        resposta.Retorno!.ProtocoloRelatorio.Should().Be(Protocolo);
        resposta.Retorno.TempoEspera.Should().Be(30);
    }

    [Test]
    public async Task SolicitarProtocolo_304_DeveLerProtocoloDoETag()
    {
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() =>
        {
            var r = new HttpResponseMessage(HttpStatusCode.NotModified) { Content = new StringContent("") };
            r.Headers.TryAddWithoutValidation("ETag", $"\"protocoloRelatorio:{Protocolo}\"");
            return r;
        });
        using var service = CriarServico(handler);

        var resposta = await service.SitfisSolicitarProtocoloAsync(Contribuinte);

        resposta.StatusCode.Should().Be(304);
        resposta.Retorno!.ProtocoloRelatorio.Should().Be(Protocolo);
    }

    [Test]
    public async Task EmitirRelatorio_DeveEnviarProtocoloELerPdfDeArray()
    {
        // o exemplo da documentação retorna "dados" como array de um objeto
        var handler = new HandlerFalso { Dados = $"[{{\"pdf\":\"{Pdf}\"}}]" };
        using var service = CriarServico(handler);

        var resposta = await service.SitfisEmitirRelatorioAsync(Contribuinte, Protocolo);

        VerificarChamada(handler.Chamadas.Single(), "RELATORIOSITFIS92", "Emitir");
        var dados = DadosEnviados(handler);
        dados.EnumerateObject().Select(p => p.Name).Should().Equal("protocoloRelatorio");
        dados.GetProperty("protocoloRelatorio").GetString().Should().Be(Protocolo);
        resposta.Retorno!.Pdf.Should().Be(Pdf);
        resposta.Retorno.TempoEspera.Should().BeNull();
    }

    [Test]
    public async Task EmitirRelatorio_DeveLerPdfDeObjeto()
    {
        var handler = new HandlerFalso { Dados = $"{{\"pdf\":\"{Pdf}\"}}" };
        using var service = CriarServico(handler);

        var resposta = await service.SitfisEmitirRelatorioAsync(Contribuinte, Protocolo);

        resposta.Retorno!.Pdf.Should().Be(Pdf);
    }

    [Test]
    public async Task EmitirRelatorio_202_DeveLerTempoEspera()
    {
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() => HandlerFalso.Envelope(202, "{\"tempoEspera\":4000}", "[Sucesso-Sitfis-SC02]", "A emissão relatório de situação fiscal está em processamento."));
        using var service = CriarServico(handler);

        var resposta = await service.SitfisEmitirRelatorioAsync(Contribuinte, Protocolo);

        resposta.StatusCode.Should().Be(202);
        resposta.Retorno!.TempoEspera.Should().Be(4000);
        resposta.Retorno.Pdf.Should().BeNull();
    }

    [Test]
    public async Task EmitirRelatorio_204_DeveLerTempoEsperaDoETag()
    {
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() =>
        {
            var r = new HttpResponseMessage(HttpStatusCode.NoContent);
            r.Headers.TryAddWithoutValidation("ETag", "\"tempoEspera:4000\"");
            return r;
        });
        using var service = CriarServico(handler);

        var resposta = await service.SitfisEmitirRelatorioAsync(Contribuinte, Protocolo);

        resposta.StatusCode.Should().Be(204);
        resposta.Retorno!.TempoEspera.Should().Be(4000);
    }

    [Test]
    public async Task ObterRelatorio_DeveAguardarTempoEsperaEnquantoEmProcessamento()
    {
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() => HandlerFalso.Envelope(200, ProtocoloJson(30)));
        handler.Respostas.Enqueue(() => HandlerFalso.Envelope(202, "{\"tempoEspera\":4000}"));
        handler.Respostas.Enqueue(() =>
        {
            var r = new HttpResponseMessage(HttpStatusCode.NoContent);
            r.Headers.TryAddWithoutValidation("ETag", "\"tempoEspera:1500\"");
            return r;
        });
        handler.Respostas.Enqueue(() => HandlerFalso.Envelope(200, $"[{{\"pdf\":\"{Pdf}\"}}]"));
        using var service = CriarServicoSemEspera(handler);

        var resposta = await service.SitfisObterRelatorioAsync(Contribuinte);

        resposta.StatusCode.Should().Be(200);
        resposta.Retorno!.Pdf.Should().Be(Pdf);
        var chamadas = handler.Chamadas.ToList();
        chamadas.Should().HaveCount(4);
        VerificarChamada(chamadas[0], "SOLICITARPROTOCOLO91", "Apoiar");
        chamadas.Skip(1).Should().AllSatisfy(c => VerificarChamada(c, "RELATORIOSITFIS92", "Emitir"));
        service.Esperas.Should().Equal(TimeSpan.FromMilliseconds(30), TimeSpan.FromMilliseconds(4000), TimeSpan.FromMilliseconds(1500));
    }

    [Test]
    public async Task ObterRelatorio_DevePararNoMaximoDeTentativas()
    {
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() => HandlerFalso.Envelope(200, ProtocoloJson(0)));
        for (var i = 0; i < 5; i++)
            handler.Respostas.Enqueue(() => HandlerFalso.Envelope(202, "{\"tempoEspera\":100}"));
        using var service = CriarServicoSemEspera(handler);

        var resposta = await service.SitfisObterRelatorioAsync(Contribuinte, maxTentativas: 3);

        resposta.StatusCode.Should().Be(202);
        resposta.Retorno!.TempoEspera.Should().Be(100);
        handler.Chamadas.Should().HaveCount(4);
        service.Esperas.Should().Equal(TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100));
    }

    [Test]
    public async Task ObterRelatorio_FalhaNoProtocolo_DeveRetornarEnvelopeSemEmitir()
    {
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() => HandlerFalso.Envelope(400, "", "[Erro-Sitfis-ER01]", "Contribuinte inválido."));
        using var service = CriarServicoSemEspera(handler);

        var resposta = await service.SitfisObterRelatorioAsync(Contribuinte);

        resposta.StatusCode.Should().Be(400);
        resposta.Retorno.Should().BeNull();
        resposta.Mensagens!.Single().Codigo.Should().Be("[Erro-Sitfis-ER01]");
        handler.Chamadas.Should().HaveCount(1);
        service.Esperas.Should().BeEmpty();
    }

    [Test]
    public async Task ObterRelatorio_DeveRespeitarCancelamento()
    {
        // cancela após o protocolo: a espera (Task.Delay) deve ser interrompida
        using var cts = new CancellationTokenSource();
        var handler = new HandlerFalso();
        handler.Respostas.Enqueue(() =>
        {
            cts.Cancel();
            return HandlerFalso.Envelope(200, ProtocoloJson(60000));
        });
        using var service = CriarServico(handler);

        await FluentActions.Awaiting(() => service.SitfisObterRelatorioAsync(Contribuinte, ct: cts.Token))
            .Should().ThrowAsync<OperationCanceledException>();
        handler.Chamadas.Should().HaveCount(1);
    }

    [Test]
    public async Task ArgumentosInvalidos_DevemLancarExcecao()
    {
        using var service = CriarServico(new HandlerFalso());

        await FluentActions.Awaiting(() => service.SitfisEmitirRelatorioAsync(Contribuinte, "")).Should().ThrowAsync<ArgumentNullException>();
        await FluentActions.Awaiting(() => service.SitfisObterRelatorioAsync(Contribuinte, 0)).Should().ThrowAsync<ArgumentOutOfRangeException>();
    }
}
