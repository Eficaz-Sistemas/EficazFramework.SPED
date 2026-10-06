using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace EficazFramework.SPED.Services.NFSe.Nacional;

/// <summary>
/// Download do DANFSe (PDF) da NFS-e Nacional no ADN, com handler HTTP falso (sem rede).
/// </summary>
public class DanfseTests : BaseNFseTests
{
    private const string Chave = "35503082219574916000183000000000000126010000000001";

    [Test]
    public async Task ObterDanfse_DeveDevolverOPdfDoAdn()
    {
        var pdf = Encoding.ASCII.GetBytes("%PDF-1.7\n%teste\n");
        var handler = new HandlerFalso(HttpStatusCode.OK, pdf, "application/pdf");
        using var service = new NfseNacionalService(handler) { SelecionaCertificado = InstanciaCertificado };

        var retorno = await service.ObterDanfseAsync(Chave, Schemas.NFSe.Nacional.Ambiente.Homologacao);

        handler.Url.Should().Be($"https://adn.producaorestrita.nfse.gov.br/danfse/{Chave}");
        handler.Accept.Should().Be("application/pdf");
        retorno.Sucesso.Should().BeTrue();
        retorno.Pdf.Should().Equal(pdf);
        retorno.ConteudoErro.Should().BeNull();
    }

    [Test]
    public async Task ObterDanfse_RespostaSemPdf_DeveDevolverOErro()
    {
        var corpo = Encoding.UTF8.GetBytes("{\"erro\":{\"codigo\":\"E404\",\"descricao\":\"Nao encontrado\"}}");
        var handler = new HandlerFalso(HttpStatusCode.NotFound, corpo, "application/json");
        using var service = new NfseNacionalService(handler) { SelecionaCertificado = InstanciaCertificado };

        var retorno = await service.ObterDanfseAsync(Chave, Schemas.NFSe.Nacional.Ambiente.Producao);

        handler.Url.Should().Be($"https://adn.nfse.gov.br/danfse/{Chave}");
        retorno.Sucesso.Should().BeFalse();
        retorno.StatusCode.Should().Be(404);
        retorno.Pdf.Should().BeNull();
        retorno.ConteudoErro.Should().Contain("E404");
    }

    [Test]
    public async Task ObterDanfse_ChaveInvalida_DeveLancarAntesDeEnviar()
    {
        var handler = new HandlerFalso(HttpStatusCode.OK, [], "application/pdf");
        using var service = new NfseNacionalService(handler) { SelecionaCertificado = InstanciaCertificado };

        await FluentActions.Awaiting(() => service.ObterDanfseAsync("123"))
            .Should().ThrowAsync<ArgumentException>();
        handler.Url.Should().BeNull();
    }

    /// <summary>Registra a requisição e devolve o conteúdo configurado.</summary>
    private sealed class HandlerFalso(HttpStatusCode status, byte[] conteudo, string tipo) : HttpMessageHandler
    {
        public string? Url { get; private set; }
        public string? Accept { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Url = request.RequestUri!.ToString();
            Accept = request.Headers.Accept.FirstOrDefault()?.MediaType;
            var content = new ByteArrayContent(conteudo);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(tipo);
            return Task.FromResult(new HttpResponseMessage(status) { Content = content });
        }
    }
}
