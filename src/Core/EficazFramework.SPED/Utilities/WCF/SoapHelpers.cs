using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Utilities.WCF;

internal class SoapHelpers
{
    internal static BasicHttpBinding CreateDefaultBinding(string name, long? maxSize = default)
    {
        var b = new BasicHttpBinding
        {
            Name = name
        };
        b.Security.Mode = BasicHttpSecurityMode.Transport;
        b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
        if (maxSize.HasValue == true)
            b.MaxReceivedMessageSize = maxSize.Value;
        return b;
    }

    internal static CustomBinding CreateCustomBinding(string name, long? maxSize = default)
    {
        var b = new CustomBinding
        {
            Name = name
        };
        b.Elements.Add(new TextMessageEncodingBindingElement() { MessageVersion = MessageVersion.Soap12WSAddressing10 });
        // b.Elements.Add(SecurityBindingElement.CreateMutualCertificateBindingElement())
        var httptranspelement = new HttpsTransportBindingElement() { RequireClientCertificate = true };
        if (maxSize.HasValue == true)
            httptranspelement.MaxReceivedMessageSize = maxSize.Value;
        b.Elements.Add(httptranspelement);
        return b;
    }

    internal static EndpointAddress CreateDefaultEndPoint(string uri)
    {
        return new EndpointAddress(uri);
    }
}
