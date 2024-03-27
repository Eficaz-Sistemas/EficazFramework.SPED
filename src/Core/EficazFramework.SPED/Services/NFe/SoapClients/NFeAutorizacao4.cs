using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Services.NFe.Contracts;
using EficazFramework.SPED.Utilities;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Services.NFe.SoapClients;

public partial class NFeAutorizacao4SoapClient(Binding binding, EndpointAddress remoteAddress) : ClientBase<INFeAutorizacao4Soap>(binding, remoteAddress), INFeAutorizacao4Soap, ISoapClient
{
    public static NFeAutorizacao4SoapClient Create(
        Schemas.NFe.OrgaoIBGE uf,
        Schemas.NFe.ModeloDocumento modelo = Schemas.NFe.ModeloDocumento.NFe, 
        Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
    {
        NFeAutorizacao4SoapClient client = new(ConfigureBinding(), new(ConfigureUrl(uf, modelo, ambiente)));

        if (ambiente == Schemas.NFe.Ambiente.Homologacao)
            client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new()
            {
                CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None
            };

        return client;
    }


    public async Task<nfeAutorizacaoLoteResponse> nfeAutorizacaoLoteAsync(nfeAutorizacaoLoteRequest request)
        => await Channel.nfeAutorizacaoLoteAsync(request);

    public nfeAutorizacaoLoteResponse nfeAutorizacaoLote(nfeAutorizacaoLoteRequest request)
        => Channel.nfeAutorizacaoLote(request);


    private static string ConfigureUrl(
        Schemas.NFe.OrgaoIBGE uf,
        Schemas.NFe.ModeloDocumento modelo = Schemas.NFe.ModeloDocumento.NFe,
        Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
        => ambiente switch
        { 
            Schemas.NFe.Ambiente.Producao => ConfigureUrlProducao(uf, modelo),
            Schemas.NFe.Ambiente.Homologacao => ConfigureUrlHomologacao(uf, modelo),
            _ => ConfigureUrlHomologacao(uf, modelo)
        };

    private static string ConfigureUrlProducao(Schemas.NFe.OrgaoIBGE uf, Schemas.NFe.ModeloDocumento modelo)
        => modelo switch
        {
            Schemas.NFe.ModeloDocumento.NFe => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AM => "https://nfe.sefaz.am.gov.br/services2/services/NfeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.BA => "https://nfe.sefaz.ba.gov.br/webservices/NFeAutorizacao4/NFeAutorizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.GO => "https://nfe.sefaz.go.gov.br/nfe/services/NFeAutorizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.MG => "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.MS => "https://nfe.sefaz.ms.gov.br/ws/NFeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.MT => "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeAutorizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.PE => "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.PR => "https://nfe.sefa.pr.gov.br/nfe/NFeAutorizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfe.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://nfe.fazenda.sp.gov.br/ws/nfeautorizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.MA => "https://www.sefazvirtual.fazenda.gov.br/NFeAutorizacao4/NFeAutorizacao4.asmx",
                _ => "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx"
            },
            Schemas.NFe.ModeloDocumento.NFCe => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AM => "https://nfce.sefaz.am.gov.br/nfce-services/services/NfeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.GO => "https://nfe.sefaz.go.gov.br/nfe/services/NFeAutorizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.MG => "https://nfce.fazenda.mg.gov.br/nfce/services/NFeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.MS => "https://nfce.sefaz.ms.gov.br/ws/NFeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.MT => "https://nfce.sefaz.mt.gov.br/nfcews/services/NfeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.PR => "https://nfce.sefa.pr.gov.br/nfce/NFeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfce.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://nfce.fazenda.sp.gov.br/ws/NFeAutorizacao4.asmx",
                _ => "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx"
            },
            _ => "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx"
        };

    private static string ConfigureUrlHomologacao(Schemas.NFe.OrgaoIBGE uf, Schemas.NFe.ModeloDocumento modelo)
        => modelo switch
        {
            Schemas.NFe.ModeloDocumento.NFe => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AM => "https://homnfe.sefaz.am.gov.br/services2/services/NfeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.BA => "https://hnfe.sefaz.ba.gov.br/webservices/NFeAutorizacao4/NFeAutorizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.GO => "https://homolog.sefaz.go.gov.br/nfe/services/NFeAutorizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.MG => "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.MS => "https://hom.nfe.sefaz.ms.gov.br/ws/NFeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.MT => "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/NfeAutorizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.PE => "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeAutorizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.PR => "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeAutorizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeautorizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.MA => "https://hom.sefazvirtual.fazenda.gov.br/NFeAutorizacao4/NFeAutorizacao4.asmx",
                _ => "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx"
            },
            Schemas.NFe.ModeloDocumento.NFCe => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AM => "https://homnfce.sefaz.am.gov.br/nfce-services/services/NfeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.GO => "https://homolog.sefaz.go.gov.br/nfe/services/NFeAutorizacao4?wsdl",
                Schemas.NFe.OrgaoIBGE.MG => "https://hnfce.fazenda.mg.gov.br/nfce/services/NFeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.MS => "https://hom.nfce.sefaz.ms.gov.br/ws/NFeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.MT => "https://homologacao.sefaz.mt.gov.br/nfcews/services/NfeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.PR => "https://homologacao.nfce.sefa.pr.gov.br/nfce/NFeAutorizacao4",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfce-homologacao.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeAutorizacao4.asmx",
                _ => "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx"
            },
            _ => "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx"
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
        return (ISoapResponse<TMessage>)await Channel.nfeAutorizacaoLoteAsync(request as nfeAutorizacaoLoteRequest);
    }
}