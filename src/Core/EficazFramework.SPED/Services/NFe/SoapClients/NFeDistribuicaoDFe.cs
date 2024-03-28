using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Services.NFe.Contracts;
using EficazFramework.SPED.Utilities;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Services.NFe.SoapClients;

internal class NFeDistribuicaoDFeSoapClient(Binding binding, EndpointAddress remoteAddress) : ClientBase<INFeDistribuicaoDFeSoap>(binding, remoteAddress), INFeDistribuicaoDFeSoap, ISoapClient
{
    public static NFeDistribuicaoDFeSoapClient Create(Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
        => new(ConfigureBinding(), 
            ambiente == Schemas.NFe.Ambiente.Producao ? 
                new("https://www1.nfe.fazenda.gov.br/NFeDistribuicaoDFe/NFeDistribuicaoDFe.asmx") : 
                new("https://hom1.nfe.fazenda.gov.br/NFeDistribuicaoDFe/NFeDistribuicaoDFe.asmx"));


    public NFeDistribuicaoDFeResponse nfeDistDFeInteresse(NFeDistribuicaoDFeRequest request)
        => Channel.nfeDistDFeInteresse(request);

    public async Task<NFeDistribuicaoDFeResponse> nfeDistDFeInteresseAsync(NFeDistribuicaoDFeRequest request)
        => await Channel.nfeDistDFeInteresseAsync(request);


    private static Binding ConfigureBinding()
    {
        var binding = new CustomBinding
        {
            Name = "NFeDistribuicaoDFeSoap",
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
        var client = Create(Enum.Parse<Schemas.NFe.Ambiente>(args[0]));
#if DEBUG
        client.Endpoint.EndpointBehaviors.Add(new Utilities.WCF.SoapInspectorBehavior());
#endif
        return client;
    }

    async Task<ISoapResponse<TMessage>> ISoapClient.ExecuteAsync<TMessage>(ISoapRequest request, IcpBrasilX509Certificate2 certificate)
    {
        ClientCredentials.ClientCertificate.Certificate = certificate.PrivateInstance;
        return (ISoapResponse<TMessage>)await Channel.nfeDistDFeInteresseAsync(request as NFeDistribuicaoDFeRequest);
    }
}
