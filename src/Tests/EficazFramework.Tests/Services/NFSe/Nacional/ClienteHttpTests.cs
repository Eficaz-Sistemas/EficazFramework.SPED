using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace EficazFramework.SPED.Services.NFSe.Nacional;

/// <summary>
/// Cliente HTTP do <see cref="NfseNacionalService"/>: uma instância atende a várias chamadas e ambientes
/// (URLs completas, sem BaseAddress), sem rede (handler falso).
/// </summary>
public class ClienteHttpTests : BaseNFseTests
{
    private const string Chave = "35503082219574916000183000000000000126010000000001";

    /// <summary>Registra as requisições e responde 404 com um erro do ADN.</summary>
    private sealed class HandlerFalso : HttpMessageHandler
    {
        public List<(HttpMethod Metodo, string Url, string? Accept)> Pedidos { get; } = [];

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Pedidos.Add((request.Method, request.RequestUri!.ToString(), request.Headers.Accept.FirstOrDefault()?.MediaType));
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("{\"tipoAmbiente\":2,\"erro\":{\"codigo\":\"E404\",\"descricao\":\"Nao encontrado\"}}", Encoding.UTF8, "application/json")
            });
        }
    }

    [Test]
    public async Task MesmaInstancia_DeveAtenderVariasChamadasEAmbientes()
    {
        var handler = new HandlerFalso();
        using var service = new NfseNacionalService(handler) { SelecionaCertificado = InstanciaCertificado };

        var porChave = await service.ConsultarNfsePorChaveAsync(Chave, Schemas.NFSe.Nacional.Ambiente.Homologacao);
        await service.ConsultarNfsePorDpsAsync("DPS1", Schemas.NFSe.Nacional.Ambiente.Producao);
        await service.ConsultarDfePorNsuAsync(1, ambiente: Schemas.NFSe.Nacional.Ambiente.Homologacao);
        await service.ConsultarNfsePorChaveAsync(Chave, Schemas.NFSe.Nacional.Ambiente.Producao);

        handler.Pedidos.Select(p => p.Url).Should().Equal(
            $"https://sefin.producaorestrita.nfse.gov.br/SefinNacional/nfse/{Chave}",
            "https://sefin.nfse.gov.br/dps/DPS1",
            "https://adn.producaorestrita.nfse.gov.br/DFe/1",
            $"https://sefin.nfse.gov.br/nfse/{Chave}");
        handler.Pedidos.Should().OnlyContain(p => p.Metodo == HttpMethod.Get && p.Accept == "application/json");

        porChave.StatusCode.Should().Be(404);
        porChave.Erro!.Codigo.Should().Be("E404");
    }

    [Test]
    public async Task SemCertificado_DeveLancarAntesDeEnviar()
    {
        var handler = new HandlerFalso();
        using var service = new NfseNacionalService(handler);

        await FluentActions.Awaiting(() => service.ConsultarNfsePorChaveAsync(Chave))
            .Should().ThrowAsync<ArgumentNullException>();
        handler.Pedidos.Should().BeEmpty();
    }

    [Test]
    public async Task Descartado_DeveLancarObjectDisposed()
    {
        var service = new NfseNacionalService(new HandlerFalso()) { SelecionaCertificado = InstanciaCertificado };
        service.Dispose();

        await FluentActions.Awaiting(() => service.ConsultarNfsePorChaveAsync(Chave))
            .Should().ThrowAsync<ObjectDisposedException>();
    }
}
