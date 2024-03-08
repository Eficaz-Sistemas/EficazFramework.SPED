using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Services.NFe.Contracts;
using EficazFramework.SPED.Utilities;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Services.NFe.SoapClients;

internal class RecepcaoEvento4SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : System.ServiceModel.ClientBase<IRecepcaoEvento4Soap>(binding, remoteAddress), IRecepcaoEvento4Soap, ISoapClient
{
    public static RecepcaoEvento4SoapClient Create()
        => new(ConfigureBinding(), new("https://www.nfe.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx"));


    public async Task<RecepcaoEvento4Response> nfeRecepcaoEventoNFAsync(RecepcaoEvento4Request request)
    => await Channel.nfeRecepcaoEventoNFAsync(request);

    public RecepcaoEvento4Response nfeRecepcaoEventoNF(RecepcaoEvento4Request request)
        => Channel.nfeRecepcaoEventoNF(request);


    private static Binding ConfigureBinding()
    {
        var binding = new CustomBinding
        {
            Name = "NFeRecepcaoEvento4Soap",
        };
        binding.Elements.Add(new TextMessageEncodingBindingElement
        {
            MessageVersion = MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, AddressingVersion.None),
        });
        binding.Elements.Add((BindingElement)new HttpsTransportBindingElement
        {
            RequireClientCertificate = true,
            MaxReceivedMessageSize = 65536,
        });
        return binding;
    }

    static ISoapClient ISoapClient.Create(params string[] args)
    {
        var client = Create();
#if DEBUG
        client.Endpoint.EndpointBehaviors.Add(new Utilities.WCF.SoapInspectorBehavior());
#endif
        return client;
    }

    async Task<ISoapResponse<TMessage>> ISoapClient.ExecuteAsync<TMessage>(ISoapRequest request, IcpBrasilX509Certificate2 certificate)
    {
        ClientCredentials.ClientCertificate.Certificate = certificate.PrivateInstance;
        return (ISoapResponse<TMessage>)await Channel.nfeRecepcaoEventoNFAsync(request as RecepcaoEvento4Request);
    }
}
