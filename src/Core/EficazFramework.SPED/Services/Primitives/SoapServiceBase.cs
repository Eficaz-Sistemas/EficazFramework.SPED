using EficazFramework.SPED.Interfaces;

namespace EficazFramework.SPED.Services.Primitives;

public class SoapServiceBase : ServiceBase 
{
    internal async Task<ISoapResponse> ExecuteAsync<TClient>(ISoapRequest request, params string[] args) where TClient : ISoapClient
    {
        ISoapClient client = TClient.Create(args);
        var result = await client.ExecuteAsync(request, Certificado);
        return result;
    }

}
