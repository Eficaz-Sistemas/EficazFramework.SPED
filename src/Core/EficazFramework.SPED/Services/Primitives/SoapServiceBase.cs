using System.Net;
using System.ServiceModel;
using System.Threading.Channels;

namespace EficazFramework.SPED.Services.Primitives;

public class SoapServiceBase : ServiceBase 
{
    internal async Task<XmlNode> ExecuteAsync<TClient>(XmlNode request, params string[] args) where TClient : ISoapClient
    {
        ISoapClient client = TClient.Create(args);
        var result = await client.ExecuteAsync(request);
        return result.FirstChild;
    }

}
