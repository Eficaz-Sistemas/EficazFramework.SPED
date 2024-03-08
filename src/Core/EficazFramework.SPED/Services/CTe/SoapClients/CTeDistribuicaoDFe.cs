using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Services.CTe.Contracts;
using EficazFramework.SPED.Utilities;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Services.CTe.SoapClients;

internal class CTeDistribuicaoDFeSoapClient(Binding binding, EndpointAddress remoteAddress) : ClientBase<ICTeDistribuicaoDFeSoap>(binding, remoteAddress), ICTeDistribuicaoDFeSoap, ISoapClient
{
    public static CTeDistribuicaoDFeSoapClient Create()
        => new(ConfigureBinding(), new("https://www1.cte.fazenda.gov.br/CTeDistribuicaoDFe/CTeDistribuicaoDFe.asmx"));


    public CTeDistribuicaoDFeResponse cteDistDFeInteresse(CTeDistribuicaoDFeRequest request)
    => Channel.cteDistDFeInteresse(request);

    public async Task<CTeDistribuicaoDFeResponse> cteDistDFeInteresseAsync(CTeDistribuicaoDFeRequest request)
        => await Channel.cteDistDFeInteresseAsync(request);


    private static Binding ConfigureBinding()
    {
        var binding = new CustomBinding
        {
            Name = "CTeDistribuicaoDFeSoap",
        };
        binding.Elements.Add(new TextMessageEncodingBindingElement
        {
            MessageVersion = MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, AddressingVersion.None),
        });
        binding.Elements.Add((BindingElement)new HttpsTransportBindingElement
        {
            RequireClientCertificate = true,
            MaxReceivedMessageSize = 650000,
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
        return (ISoapResponse<TMessage>)await Channel.cteDistDFeInteresseAsync(request as CTeDistribuicaoDFeRequest);
    }
}
