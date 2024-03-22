using EficazFramework.SPED.Interfaces;
using System.ServiceModel.Channels;
using System.ServiceModel;
using EficazFramework.SPED.Services.NFe.Contracts;
using EficazFramework.SPED.Utilities;

namespace EficazFramework.SPED.Services.NFe.SoapClients;

public partial class NFeAutorizacao4SoapClient(Binding binding, EndpointAddress remoteAddress) : ClientBase<INFeAutorizacao4Soap>(binding, remoteAddress), INFeAutorizacao4Soap, ISoapClient
{
    public static NFeAutorizacao4SoapClient Create(Schemas.NFe.OrgaoIBGE uf, string modelo = "55", Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
        => new(ConfigureBinding(), new(ConfigureUrl(uf, modelo, ambiente)));


    public async Task<nfeAutorizacaoLoteResponse> nfeAutorizacaoLoteAsync(nfeAutorizacaoLoteRequest request)
        => await Channel.nfeAutorizacaoLoteAsync(request);

    public nfeAutorizacaoLoteResponse nfeAutorizacaoLote(nfeAutorizacaoLoteRequest request)
        => Channel.nfeAutorizacaoLote(request);


    private static string ConfigureUrl(Schemas.NFe.OrgaoIBGE uf, string modelo = "55", Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
        => ambiente switch
        { 
            Schemas.NFe.Ambiente.Producao => modelo switch
            {
                "55" => uf switch
                {
                    Schemas.NFe.OrgaoIBGE.AC => "",
                    Schemas.NFe.OrgaoIBGE.AL => "",
                    Schemas.NFe.OrgaoIBGE.AM => "",
                    Schemas.NFe.OrgaoIBGE.AP => "",
                    Schemas.NFe.OrgaoIBGE.BA => "",
                    Schemas.NFe.OrgaoIBGE.CE => "",
                    Schemas.NFe.OrgaoIBGE.DF => "",
                    Schemas.NFe.OrgaoIBGE.ES => "",
                    Schemas.NFe.OrgaoIBGE.GO => "",
                    Schemas.NFe.OrgaoIBGE.MA => "",
                    Schemas.NFe.OrgaoIBGE.MG => "",
                    Schemas.NFe.OrgaoIBGE.MS => "",
                    Schemas.NFe.OrgaoIBGE.MT => "",
                    Schemas.NFe.OrgaoIBGE.PA => "",
                    Schemas.NFe.OrgaoIBGE.PB => "",
                    Schemas.NFe.OrgaoIBGE.PE => "",
                    Schemas.NFe.OrgaoIBGE.PI => "",
                    Schemas.NFe.OrgaoIBGE.PR => "",
                    Schemas.NFe.OrgaoIBGE.RJ => "",
                    Schemas.NFe.OrgaoIBGE.RN => "",
                    Schemas.NFe.OrgaoIBGE.RO => "",
                    Schemas.NFe.OrgaoIBGE.RR => "",
                    Schemas.NFe.OrgaoIBGE.RS => "",
                    Schemas.NFe.OrgaoIBGE.SC => "",
                    Schemas.NFe.OrgaoIBGE.SE => "",
                    Schemas.NFe.OrgaoIBGE.SP => "",
                    Schemas.NFe.OrgaoIBGE.TO => "",
                    Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN => "",
                    Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS => "",
                    Schemas.NFe.OrgaoIBGE.SefazNacional_SVCSP => "",
                    _ => ""
                },
                "65" => uf switch
                {
                    Schemas.NFe.OrgaoIBGE.AC => "",
                    Schemas.NFe.OrgaoIBGE.AL => "",
                    Schemas.NFe.OrgaoIBGE.AM => "",
                    Schemas.NFe.OrgaoIBGE.AP => "",
                    Schemas.NFe.OrgaoIBGE.BA => "",
                    Schemas.NFe.OrgaoIBGE.CE => "",
                    Schemas.NFe.OrgaoIBGE.DF => "",
                    Schemas.NFe.OrgaoIBGE.ES => "",
                    Schemas.NFe.OrgaoIBGE.GO => "",
                    Schemas.NFe.OrgaoIBGE.MA => "",
                    Schemas.NFe.OrgaoIBGE.MG => "",
                    Schemas.NFe.OrgaoIBGE.MS => "",
                    Schemas.NFe.OrgaoIBGE.MT => "",
                    Schemas.NFe.OrgaoIBGE.PA => "",
                    Schemas.NFe.OrgaoIBGE.PB => "",
                    Schemas.NFe.OrgaoIBGE.PE => "",
                    Schemas.NFe.OrgaoIBGE.PI => "",
                    Schemas.NFe.OrgaoIBGE.PR => "",
                    Schemas.NFe.OrgaoIBGE.RJ => "",
                    Schemas.NFe.OrgaoIBGE.RN => "",
                    Schemas.NFe.OrgaoIBGE.RO => "",
                    Schemas.NFe.OrgaoIBGE.RR => "",
                    Schemas.NFe.OrgaoIBGE.RS => "",
                    Schemas.NFe.OrgaoIBGE.SC => "",
                    Schemas.NFe.OrgaoIBGE.SE => "",
                    Schemas.NFe.OrgaoIBGE.SP => "",
                    Schemas.NFe.OrgaoIBGE.TO => "",
                    Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN => "",
                    Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS => "",
                    Schemas.NFe.OrgaoIBGE.SefazNacional_SVCSP => "",
                    _ => ""
                },
                _ => ""
            },
            Schemas.NFe.Ambiente.Homologacao => modelo switch
            {
                "55" => uf switch
                {
                    Schemas.NFe.OrgaoIBGE.AC => "",
                    Schemas.NFe.OrgaoIBGE.AL => "",
                    Schemas.NFe.OrgaoIBGE.AM => "",
                    Schemas.NFe.OrgaoIBGE.AP => "",
                    Schemas.NFe.OrgaoIBGE.BA => "",
                    Schemas.NFe.OrgaoIBGE.CE => "",
                    Schemas.NFe.OrgaoIBGE.DF => "",
                    Schemas.NFe.OrgaoIBGE.ES => "",
                    Schemas.NFe.OrgaoIBGE.GO => "",
                    Schemas.NFe.OrgaoIBGE.MA => "",
                    Schemas.NFe.OrgaoIBGE.MG => "",
                    Schemas.NFe.OrgaoIBGE.MS => "",
                    Schemas.NFe.OrgaoIBGE.MT => "",
                    Schemas.NFe.OrgaoIBGE.PA => "",
                    Schemas.NFe.OrgaoIBGE.PB => "",
                    Schemas.NFe.OrgaoIBGE.PE => "",
                    Schemas.NFe.OrgaoIBGE.PI => "",
                    Schemas.NFe.OrgaoIBGE.PR => "",
                    Schemas.NFe.OrgaoIBGE.RJ => "",
                    Schemas.NFe.OrgaoIBGE.RN => "",
                    Schemas.NFe.OrgaoIBGE.RO => "",
                    Schemas.NFe.OrgaoIBGE.RR => "",
                    Schemas.NFe.OrgaoIBGE.RS => "",
                    Schemas.NFe.OrgaoIBGE.SC => "",
                    Schemas.NFe.OrgaoIBGE.SE => "",
                    Schemas.NFe.OrgaoIBGE.SP => "",
                    Schemas.NFe.OrgaoIBGE.TO => "",
                    Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN => "",
                    Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS => "",
                    Schemas.NFe.OrgaoIBGE.SefazNacional_SVCSP => "",
                    _ => ""
                },
                "65" => uf switch
                {
                    Schemas.NFe.OrgaoIBGE.AC => "",
                    Schemas.NFe.OrgaoIBGE.AL => "",
                    Schemas.NFe.OrgaoIBGE.AM => "",
                    Schemas.NFe.OrgaoIBGE.AP => "",
                    Schemas.NFe.OrgaoIBGE.BA => "",
                    Schemas.NFe.OrgaoIBGE.CE => "",
                    Schemas.NFe.OrgaoIBGE.DF => "",
                    Schemas.NFe.OrgaoIBGE.ES => "",
                    Schemas.NFe.OrgaoIBGE.GO => "",
                    Schemas.NFe.OrgaoIBGE.MA => "",
                    Schemas.NFe.OrgaoIBGE.MG => "",
                    Schemas.NFe.OrgaoIBGE.MS => "",
                    Schemas.NFe.OrgaoIBGE.MT => "",
                    Schemas.NFe.OrgaoIBGE.PA => "",
                    Schemas.NFe.OrgaoIBGE.PB => "",
                    Schemas.NFe.OrgaoIBGE.PE => "",
                    Schemas.NFe.OrgaoIBGE.PI => "",
                    Schemas.NFe.OrgaoIBGE.PR => "",
                    Schemas.NFe.OrgaoIBGE.RJ => "",
                    Schemas.NFe.OrgaoIBGE.RN => "",
                    Schemas.NFe.OrgaoIBGE.RO => "",
                    Schemas.NFe.OrgaoIBGE.RR => "",
                    Schemas.NFe.OrgaoIBGE.RS => "",
                    Schemas.NFe.OrgaoIBGE.SC => "",
                    Schemas.NFe.OrgaoIBGE.SE => "",
                    Schemas.NFe.OrgaoIBGE.SP => "",
                    Schemas.NFe.OrgaoIBGE.TO => "",
                    Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN => "",
                    Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS => "",
                    Schemas.NFe.OrgaoIBGE.SefazNacional_SVCSP => "",
                    _ => ""
                },
                _ => ""
            },
            _ => ""
        };

    private static Binding ConfigureBinding()
    {
        var binding = new CustomBinding
        {
            Name = "nfeAutorizacaoLoteSoap",
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
        var client = Create(Enum.Parse<Schemas.NFe.OrgaoIBGE>(args[0]), args[1], Enum.Parse<Schemas.NFe.Ambiente>(args[2]));
#if DEBUG
        client.Endpoint.EndpointBehaviors.Add(new Utilities.WCF.SoapInspectorBehavior());
#endif
        return client;
    }

    async Task<ISoapResponse<TMessage>> ISoapClient.ExecuteAsync<TMessage>(ISoapRequest request, IcpBrasilX509Certificate2 certificate)
    {
        ClientCredentials.ClientCertificate.Certificate = certificate.PrivateInstance;
        return (ISoapResponse<TMessage>)await Channel.nfeAutorizacaoLoteAsync(request as nfeAutorizacaoLoteRequest);
    }
}