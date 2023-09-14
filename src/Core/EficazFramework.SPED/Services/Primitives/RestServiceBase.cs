using System.Net.Http;

namespace EficazFramework.SPED.Services.Primitives;
internal abstract class RestServiceBase : ServiceBase
{
    HttpClient _httpClient;
    public HttpClient HttpClient => _httpClient;

    public bool RequerCertificado { get; set; }


}
