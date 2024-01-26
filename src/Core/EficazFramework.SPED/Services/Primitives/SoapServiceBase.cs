using EficazFramework.SPED.Interfaces;

namespace EficazFramework.SPED.Services.Primitives;

public class SoapServiceBase : ServiceBase 
{
    internal async Task<TResult> ExecuteAsync<TClient, TResult>(ISoapRequest request, params string[] args) 
        where TClient : ISoapClient
        where TResult : class
    {
        ISoapClient client = TClient.Create(args);
        var svcresult = await client.ExecuteAsync<TResult>(request, Certificado);
        var result = svcresult.UnWrap();
        return result;
    }

}
