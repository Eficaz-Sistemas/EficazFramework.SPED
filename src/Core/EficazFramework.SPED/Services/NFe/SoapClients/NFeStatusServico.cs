using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Services.NFe.Contracts;
using EficazFramework.SPED.Utilities;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Services.NFe.SoapClients;

public partial class NFeStatusServicoSoapClient(Binding binding, EndpointAddress remoteAddress) : ClientBase<INFeStatusServicoSoap>(binding, remoteAddress), INFeStatusServicoSoap, ISoapClient
{
    public static NFeStatusServicoSoapClient Create(
        Schemas.NFe.OrgaoIBGE uf,
        Schemas.NFe.ModeloDocumento modelo = Schemas.NFe.ModeloDocumento.NFe,
        Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
        => new(ConfigureBinding(), new (ConfigureUrl(uf, modelo, ambiente)));


    public async Task<nfeStatusServicoResponse> nfeStatusServicoNFAsync(nfeStatusServicoRequest request)
        => await Channel.nfeStatusServicoNFAsync(request);

    public nfeStatusServicoResponse nfeStatusServicoNF(nfeStatusServicoRequest request)
        => Channel.nfeStatusServicoNF(request);


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

    private static string ConfigureUrlProducao(Schemas.NFe.OrgaoIBGE uf, Schemas.NFe.ModeloDocumento modelo)
        => modelo switch
        {
            Schemas.NFe.ModeloDocumento.NFe => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AM => "https://nfe.sefaz.am.gov.br/services2/services/NfeStatusServico4",
                Schemas.NFe.OrgaoIBGE.BA => "https://nfe.sefaz.ba.gov.br/webservices/NFeStatusServico4/NFeStatusServico4.asmx",
                Schemas.NFe.OrgaoIBGE.GO => "https://nfe.sefaz.go.gov.br/nfe/services/NFeStatusServico4?wsdl",
                Schemas.NFe.OrgaoIBGE.MG => "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeStatusServico4",
                Schemas.NFe.OrgaoIBGE.MS => "https://nfe.sefaz.ms.gov.br/ws/NFeStatusServico4",
                Schemas.NFe.OrgaoIBGE.MT => "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeStatusServico4?wsdl",
                Schemas.NFe.OrgaoIBGE.PE => "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeStatusServico4",
                Schemas.NFe.OrgaoIBGE.PR => "https://nfe.sefa.pr.gov.br/nfe/NFeStatusServico4?wsdl",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfe.sefazrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://nfe.fazenda.sp.gov.br/ws/nfestatusservico4.asmx",
                Schemas.NFe.OrgaoIBGE.MA => "https://www.sefazvirtual.fazenda.gov.br/NFeStatusServico4/NFeStatusServico4.asmx",
                _ => "https://nfe.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx"
            },
            Schemas.NFe.ModeloDocumento.NFCe => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AM => "https://nfce.sefaz.am.gov.br/nfce-services/services/NfeStatusServico4",
                Schemas.NFe.OrgaoIBGE.GO => "https://nfe.sefaz.go.gov.br/nfe/services/NFeStatusServico4?wsdl",
                Schemas.NFe.OrgaoIBGE.MG => "https://nfce.fazenda.mg.gov.br/nfce/services/NFeStatusServico4",
                Schemas.NFe.OrgaoIBGE.MS => "https://nfce.sefaz.ms.gov.br/ws/NFeStatusServico4",
                Schemas.NFe.OrgaoIBGE.MT => "https://nfce.sefaz.mt.gov.br/nfcews/services/NfeStatusServico4",
                Schemas.NFe.OrgaoIBGE.PR => "https://nfce.sefa.pr.gov.br/nfce/NFeStatusServico4",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfce.sefazrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://nfce.fazenda.sp.gov.br/ws/NFeStatusServico4.asmx",
                _ => "https://nfce.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx"
            },
            _ => "https://nfce.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx"
        };

    private static string ConfigureUrlHomologacao(Schemas.NFe.OrgaoIBGE uf, Schemas.NFe.ModeloDocumento modelo)
        => modelo switch
        {
            Schemas.NFe.ModeloDocumento.NFe => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AM => "https://homnfe.sefaz.am.gov.br/services2/services/NfeStatusServico4",
                Schemas.NFe.OrgaoIBGE.BA => "https://hnfe.sefaz.ba.gov.br/webservices/NFeStatusServico4/NFeStatusServico4.asmx",
                Schemas.NFe.OrgaoIBGE.GO => "https://homolog.sefaz.go.gov.br/nfe/services/NFeStatusServico4?wsdl",
                Schemas.NFe.OrgaoIBGE.MG => "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeStatusServico4",
                Schemas.NFe.OrgaoIBGE.MS => "https://hom.nfe.sefaz.ms.gov.br/ws/NFeStatusServico4",
                Schemas.NFe.OrgaoIBGE.MT => "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/NfeStatusServico4?wsdl",
                Schemas.NFe.OrgaoIBGE.PE => "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeStatusServico4?wsdl",
                Schemas.NFe.OrgaoIBGE.PR => "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeStatusServico4?wsdl",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://homologacao.nfe.fazenda.sp.gov.br/ws/nferecepcaoevento4.asmx",
                Schemas.NFe.OrgaoIBGE.MA => "https://hom.sefazvirtual.fazenda.gov.br/NFeStatusServico4/NFeStatusServico4.asmx",
                _ => "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx"
            },
            Schemas.NFe.ModeloDocumento.NFCe => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AM => "https://homnfce.sefaz.am.gov.br/nfce-services/services/NfeStatusServico4",
                Schemas.NFe.OrgaoIBGE.GO => "https://homolog.sefaz.go.gov.br/nfe/services/NFeStatusServico4?wsdl",
                Schemas.NFe.OrgaoIBGE.MG => "https://hnfce.fazenda.mg.gov.br/nfce/services/NFeStatusServico4",
                Schemas.NFe.OrgaoIBGE.MS => "https://hom.nfce.sefaz.ms.gov.br/ws/NFeStatusServico4",
                Schemas.NFe.OrgaoIBGE.MT => "https://homologacao.sefaz.mt.gov.br/nfcews/services/NfeStatusServico4",
                Schemas.NFe.OrgaoIBGE.PR => "https://homologacao.nfce.sefa.pr.gov.br/nfce/NFeStatusServico4",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfce-homologacao.sefazrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeStatusServico4.asmx",
                _ => "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx"
            },
            _ => "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx"
        };



    private static Binding ConfigureBinding()
    {
        var binding = new CustomBinding
        {
            Name = "nfeStatusServicoNFSoap",
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
        return (ISoapResponse<TMessage>)await Channel.nfeStatusServicoNFAsync(request as nfeStatusServicoRequest);
    }
}