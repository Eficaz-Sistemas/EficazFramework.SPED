using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Services.NFe.Contracts;
using EficazFramework.SPED.Utilities;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Services.NFe.SoapClients;

public partial class NFeInutilizacaoSoapClient(Binding binding, EndpointAddress remoteAddress) : ClientBase<INFeInutilizacaoSoap>(binding, remoteAddress), INFeInutilizacaoSoap, ISoapClient
{
    public static NFeInutilizacaoSoapClient Create(
        Schemas.NFe.OrgaoIBGE uf,
        Schemas.NFe.ModeloDocumento modelo = Schemas.NFe.ModeloDocumento.NFe, 
        Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
        => new(ConfigureBinding(), new(ConfigureUrl(uf, modelo, ambiente)));


    public async Task<nfeInutilizacaoResponse> nfeInutilizacaoNFAsync(nfeInutilizacaoRequest request)
        => await Channel.nfeInutilizacaoNFAsync(request);

    public nfeInutilizacaoResponse nfeInutilizacaoNF(nfeInutilizacaoRequest request)
        => Channel.nfeInutilizacaoNF(request);



    private static string ConfigureUrl(
        Schemas.NFe.OrgaoIBGE uf,
        Schemas.NFe.ModeloDocumento modelo = Schemas.NFe.ModeloDocumento.NFe,
        Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
        => ambiente switch
        {
            Schemas.NFe.Ambiente.Producao => ConfigureUrlProducao(uf, modelo),
            Schemas.NFe.Ambiente.Homologacao => ConfigureUrlHomologacao(uf, modelo),
            _ => ConfigureUrlProducao(uf, modelo)
        };

    private static string ConfigureUrlProducao(
        Schemas.NFe.OrgaoIBGE uf,
        Schemas.NFe.ModeloDocumento modelo)
        => modelo switch
        {
            Schemas.NFe.ModeloDocumento.NFe => uf switch
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
                Schemas.NFe.OrgaoIBGE.MG => "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4",
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
            Schemas.NFe.ModeloDocumento.NFCe => uf switch
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
                Schemas.NFe.OrgaoIBGE.MG => "https://nfce.fazenda.mg.gov.br/nfce/services/NFeInutilizacao4",
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
            _ => "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4"
        };

    private static string ConfigureUrlHomologacao(
    Schemas.NFe.OrgaoIBGE uf,
    Schemas.NFe.ModeloDocumento modelo)
    => modelo switch
    {
        Schemas.NFe.ModeloDocumento.NFe => uf switch
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
            Schemas.NFe.OrgaoIBGE.MG => "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4",
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
        Schemas.NFe.ModeloDocumento.NFCe => uf switch
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
            Schemas.NFe.OrgaoIBGE.MG => "https://hnfce.fazenda.mg.gov.br/nfce/services/NFeInutilizacao4",
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
        _ => "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4"
    };



    private static Binding ConfigureBinding()
    {
        var binding = new CustomBinding
        {
            Name = "nfeInutilizacaoSoap",
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
        var client = Create(
            Enum.Parse<Schemas.NFe.OrgaoIBGE>(args[0]), 
            Enum.Parse<Schemas.NFe.ModeloDocumento>(args[1]),
            Enum.Parse<Schemas.NFe.Ambiente>(args[2]));
#if DEBUG
        client.Endpoint.EndpointBehaviors.Add(new Utilities.WCF.SoapInspectorBehavior());
#endif
        return client;
    }

    async Task<ISoapResponse<TMessage>> ISoapClient.ExecuteAsync<TMessage>(ISoapRequest request, IcpBrasilX509Certificate2 certificate)
    {
        ClientCredentials.ClientCertificate.Certificate = certificate.PrivateInstance;
        ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new()
        {
            CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None
        };
        return (ISoapResponse<TMessage>)await Channel.nfeInutilizacaoNFAsync(request as nfeInutilizacaoRequest);
    }
}