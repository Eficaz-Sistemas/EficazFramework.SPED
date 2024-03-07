using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Services.NFe.Contracts;
using EficazFramework.SPED.Utilities;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Services.NFe.SoapClients;

public partial class NFeConsultaProtocolo4SoapClient(Binding binding, EndpointAddress remoteAddress) : ClientBase<INFeConsultaProtocolo4Soap>(binding, remoteAddress), INFeConsultaProtocolo4Soap, ISoapClient
{
    public static NFeConsultaProtocolo4SoapClient Create(Schemas.NFe.OrgaoIBGE uf, string modelo = "55")
        => new(ConfigureBinding(), new (ConfigureUrl(uf, modelo)));


    public async Task<nfeConsultaNFResponse> nfeConsultaNFAsync(nfeConsultaNFRequest request)
        => await Channel.nfeConsultaNFAsync(request);

    public nfeConsultaNFResponse nfeConsultaNF(nfeConsultaNFRequest request)
        => Channel.nfeConsultaNF(request);


    private static string ConfigureUrl(Schemas.NFe.OrgaoIBGE uf, string modelo = "55") 
        => modelo switch
        {
            "55" => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AC => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.AL => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.AM => "https://nfe.sefaz.am.gov.br/services2/services/NfeConsulta4",
                Schemas.NFe.OrgaoIBGE.AP => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.BA => "https://nfe.sefaz.ba.gov.br/webservices/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx",
                Schemas.NFe.OrgaoIBGE.CE => "https://nfe.sefaz.ce.gov.br/nfe4/services/NFeConsultaProtocolo4?wsdl",
                Schemas.NFe.OrgaoIBGE.DF => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.ES => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.GO => "https://nfe.sefaz.go.gov.br/nfe/services/NFeConsultaProtocolo4?wsdl",
                Schemas.NFe.OrgaoIBGE.MA => "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx",
                Schemas.NFe.OrgaoIBGE.MG => "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeConsultaProtocolo4",
                Schemas.NFe.OrgaoIBGE.MS => "https://nfe.sefaz.ms.gov.br/ws/NFeConsultaProtocolo4",
                Schemas.NFe.OrgaoIBGE.MT => "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeConsulta4?wsdl",
                Schemas.NFe.OrgaoIBGE.PA => "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx",
                Schemas.NFe.OrgaoIBGE.PB => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.PE => "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeConsultaProtocolo4",
                Schemas.NFe.OrgaoIBGE.PI => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.PR => "https://nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4?wsdl",
                Schemas.NFe.OrgaoIBGE.RJ => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.RN => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.RO => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.RR => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfe.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.SC => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.SE => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://nfe.fazenda.sp.gov.br/ws/nfeconsultaprotocolo4.asmx",
                Schemas.NFe.OrgaoIBGE.TO => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN => "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx",
                Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                _ => ""
            },
            "65" => uf switch
            {
                Schemas.NFe.OrgaoIBGE.AC => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.AL => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.AM => "https://nfe.sefaz.am.gov.br/services2/services/NfeConsulta4",
                Schemas.NFe.OrgaoIBGE.AP => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.BA => "https://nfe.sefaz.ba.gov.br/webservices/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx",
                Schemas.NFe.OrgaoIBGE.CE => "https://nfe.sefaz.ce.gov.br/nfe4/services/NFeConsultaProtocolo4?wsdl",
                Schemas.NFe.OrgaoIBGE.DF => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.ES => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.GO => "https://nfe.sefaz.go.gov.br/nfe/services/NFeConsultaProtocolo4?wsdl",
                Schemas.NFe.OrgaoIBGE.MA => "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx",
                Schemas.NFe.OrgaoIBGE.MG => "https://nfce.fazenda.mg.gov.br/nfce/services/NFeConsultaProtocolo4",
                Schemas.NFe.OrgaoIBGE.MS => "https://nfe.sefaz.ms.gov.br/ws/NFeConsultaProtocolo4",
                Schemas.NFe.OrgaoIBGE.MT => "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeConsulta4?wsdl",
                Schemas.NFe.OrgaoIBGE.PA => "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx",
                Schemas.NFe.OrgaoIBGE.PB => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.PE => "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeConsultaProtocolo4",
                Schemas.NFe.OrgaoIBGE.PI => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.PR => "https://nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4?wsdl",
                Schemas.NFe.OrgaoIBGE.RJ => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.RN => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.RO => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.RR => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.RS => "https://nfe.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.SC => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.SE => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.SP => "https://nfce.fazenda.sp.gov.br/ws/NFeConsultaProtocolo4.asmx",
                Schemas.NFe.OrgaoIBGE.TO => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN => "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx",
                Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
                _ => ""
            },
            _ => ""
        };

    private static Binding ConfigureBinding()
    {
        var binding = new CustomBinding
        {
            Name = "nfeConsultaNFSoap",
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
        var client = Create(Enum.Parse<Schemas.NFe.OrgaoIBGE>(args[0]), args[1]);
#if DEBUG
        client.Endpoint.EndpointBehaviors.Add(new Utilities.WCF.SoapInspectorBehavior());
#endif
        return client;
    }

    async Task<ISoapResponse<TMessage>> ISoapClient.ExecuteAsync<TMessage>(ISoapRequest request, IcpBrasilX509Certificate2 certificate)
    {
        ClientCredentials.ClientCertificate.Certificate = certificate.PrivateInstance;
        return (ISoapResponse<TMessage>)await Channel.nfeConsultaNFAsync(request as nfeConsultaNFRequest);
    }
}