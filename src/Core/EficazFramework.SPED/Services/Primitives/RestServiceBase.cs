using System.Net.Http;

namespace EficazFramework.SPED.Services.Primitives;

public abstract class RestServiceBase : ServiceBase
{
    public RestServiceBase(bool requerCertificado)
    {
        _requerCertificado = requerCertificado;

        if (requerCertificado)
            _httpHandler = new();

        _httpClient = new HttpClient(_httpHandler);
    }

    readonly HttpClient _httpClient;
    public HttpClient HttpClient => _httpClient;


    readonly HttpClientHandler _httpHandler;
    public HttpClientHandler HttpClientHandler => _httpHandler;


    readonly bool _requerCertificado = false;
    public bool RequerCertificado => _requerCertificado;
}
