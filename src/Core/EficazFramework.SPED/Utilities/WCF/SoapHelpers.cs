using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Utilities.WCF;

internal class SoapHelpers
{
    /// <summary>
    /// Cria uma instância de <see cref="BasicHttpBinding"/> para uso no envio de eventos dos 
    /// documentos, eventos ou escriturações cujo schema é baseado em XML.
    /// </summary>
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

    /// <summary>
    /// Cria uma instância de <see cref="CustomBinding"/> para uso no envio de eventos dos 
    /// documentos, eventos ou escriturações cujo schema é baseado em XML. <br/>
    /// Utilize este método para os serviços que não aceitam <see cref="BasicHttpBinding"/>
    /// </summary>
    internal static CustomBinding CreateCustomBinding(string name, long? maxSize = default)
    {
        var b = new CustomBinding
        {
            Name = name
        };
        b.Elements.Add(new TextMessageEncodingBindingElement() { MessageVersion = MessageVersion.Soap12WSAddressing10 });
        var httptranspelement = new HttpsTransportBindingElement() { RequireClientCertificate = true };

        if (maxSize.HasValue == true)
            httptranspelement.MaxReceivedMessageSize = maxSize.Value;

        b.Elements.Add(httptranspelement);
        return b;
    }

    /// <summary>
    /// Cria a instância definindo o EndPoint da comunicação SOAP com os servidores do Governo,
    /// na <paramref name="uri"/> especificada.
    /// </summary>
    internal static EndpointAddress CreateDefaultEndPoint(string uri) =>
        new EndpointAddress(uri);
}
