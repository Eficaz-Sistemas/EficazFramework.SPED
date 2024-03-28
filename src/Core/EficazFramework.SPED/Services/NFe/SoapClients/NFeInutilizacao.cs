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
                Schemas.NFe.OrgaoIBGE.AM => "https://nfe.sefaz.am.gov.br/services2/services/NfeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.BA => "https://nfe.sefaz.ba.gov.br/webservices/NFeInutilizacao4/NFeInutilizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.GO => "https://nfe.sefaz.go.gov.br/nfe/services/NFeInutilizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.MG => "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.MS => "https://nfe.sefaz.ms.gov.br/ws/NFeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.MT => "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeInutilizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.PE => "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.PR => "https://nfe.sefa.pr.gov.br/nfe/NFeInutilizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfe.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://nfe.fazenda.sp.gov.br/ws/nfeinutilizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.MA => "https://www.sefazvirtual.fazenda.gov.br/NFeInutilizacao4/NFeInutilizacao4.asmx",
                _ => "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx"
            },
            Schemas.NFe.ModeloDocumento.NFCe => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AM => "https://nfce.sefaz.am.gov.br/nfce-services/services/NfeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.GO => "https://nfe.sefaz.go.gov.br/nfe/services/NFeInutilizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.MG => "https://nfce.fazenda.mg.gov.br/nfce/services/NFeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.MS => "https://nfce.sefaz.ms.gov.br/ws/NFeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.MT => "https://nfce.sefaz.mt.gov.br/nfcews/services/NfeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.PR => "https://nfce.sefa.pr.gov.br/nfce/NFeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfce.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://nfce.fazenda.sp.gov.br/ws/NFeInutilizacao4.asmx",
                _ => "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx"
            },
            _ => "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx"
        };

    private static string ConfigureUrlHomologacao(
    Schemas.NFe.OrgaoIBGE uf,
    Schemas.NFe.ModeloDocumento modelo)
        => modelo switch
        {
            Schemas.NFe.ModeloDocumento.NFe => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AM => "https://homnfe.sefaz.am.gov.br/services2/services/NfeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.BA => "https://hnfe.sefaz.ba.gov.br/webservices/NFeInutilizacao4/NFeInutilizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.GO => "https://homolog.sefaz.go.gov.br/nfe/services/NFeInutilizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.MG => "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.MS => "https://hom.nfe.sefaz.ms.gov.br/ws/NFeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.MT => "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/NfeInutilizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.PE => "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeInutilizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.PR => "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeInutilizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfe-homologacao.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeinutilizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.MA => "https://hom.sefazvirtual.fazenda.gov.br/NFeInutilizacao4/NFeInutilizacao4.asmx",
                _ => "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx"
            },
            Schemas.NFe.ModeloDocumento.NFCe => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AM => "https://homnfce.sefaz.am.gov.br/nfce-services/services/NfeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.GO => "https://homolog.sefaz.go.gov.br/nfe/services/NFeInutilizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.MG => "https://hnfce.fazenda.mg.gov.br/nfce/services/NFeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.MS => "https://hom.nfce.sefaz.ms.gov.br/ws/NFeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.MT => "https://homologacao.sefaz.mt.gov.br/nfcews/services/NfeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.PR => "https://homologacao.nfce.sefa.pr.gov.br/nfce/NFeInutilizacao4",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfce-homologacao.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeInutilizacao4.asmx",
                _ => "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx"
            },
            _ => "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx"
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