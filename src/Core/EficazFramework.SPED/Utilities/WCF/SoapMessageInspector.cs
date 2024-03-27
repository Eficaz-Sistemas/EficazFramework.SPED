using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace EficazFramework.SPED.Utilities.WCF;
internal class SoapMessageInspector : IClientMessageInspector
{
    public void AfterReceiveReply(ref Message reply, object correlationState)
    {
        Console.WriteLine(reply.ToString());
    }

    public object BeforeSendRequest(ref Message request, IClientChannel channel)
    {
        Console.WriteLine($"RemoteAddress: {channel.RemoteAddress}");
        Console.WriteLine(request.ToString());
        return null;
    }
}
