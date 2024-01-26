using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.SPED.Utilities.WCF;
internal class SoapMessageInspector : IClientMessageInspector
{
    public void AfterReceiveReply(ref Message reply, object correlationState)
    {
        Console.WriteLine(reply.ToString());
    }

    public object BeforeSendRequest(ref Message request, IClientChannel channel)
    {
        Console.WriteLine(request.ToString());
        return null;
    }
}
