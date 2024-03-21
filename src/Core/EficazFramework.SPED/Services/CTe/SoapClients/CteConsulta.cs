using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Services.CTe.Contracts;
using EficazFramework.SPED.Utilities;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Services.CTe.SoapClients;

internal class CteConsultaSoapClient(Binding binding, EndpointAddress remoteAddress) : ClientBase<ICteConsultaSoap>(binding, remoteAddress), ICteConsultaSoap, ISoapClient
{
    public static CteConsultaSoapClient Create(Schemas.NFe.OrgaoIBGE uf)
        => new(ConfigureBinding(), new(ConfigureUrl(uf)));


    public CteConsultaCTResponse cteConsultaCT(CteConsultaCTRequest request)
        => Channel.cteConsultaCT(request);

    public async Task<CteConsultaCTResponse> cteConsultaCTAsync(CteConsultaCTRequest request)
        => await Channel.cteConsultaCTAsync(request);


    private static string ConfigureUrl(Schemas.NFe.OrgaoIBGE uf)
        => uf switch
        {
            Schemas.NFe.OrgaoIBGE.AC => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.AL => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.AM => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.AP => "https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.BA => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.CE => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.DF => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.ES => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.GO => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.MA => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.MG => "https://cte.fazenda.mg.gov.br/cte/services/CTeConsultaV4",
            Schemas.NFe.OrgaoIBGE.MS => "https://producao.cte.ms.gov.br/ws/CTeConsultaV4",
            Schemas.NFe.OrgaoIBGE.MT => "https://cte.sefaz.mt.gov.br/ctews2/services/CTeConsultaV4?wsdl",
            Schemas.NFe.OrgaoIBGE.PA => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.PB => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.PE => "https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.PI => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.PR => "https://cte.fazenda.pr.gov.br/cte4/CTeConsultaV4?wsdl",
            Schemas.NFe.OrgaoIBGE.RJ => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.RN => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.RO => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.RR => "https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.RS => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.SC => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.SE => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.SP => "https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.TO => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS => "https://cte.svrs.rs.gov.br/ws/CTeConsultaV4/CTeConsultaV4.asmx",
            Schemas.NFe.OrgaoIBGE.SefazNacional_SVCSP => "https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeConsultaV4.asmx",
            _ => ""
        };


    private static Binding ConfigureBinding()
    {
        var binding = new CustomBinding
        {
            Name = "CteConsultaCTSoap",
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
        var client = Create(Enum.Parse<Schemas.NFe.OrgaoIBGE>(args[0]));
#if DEBUG
        client.Endpoint.EndpointBehaviors.Add(new Utilities.WCF.SoapInspectorBehavior());
#endif
        return client;
    }

    async Task<ISoapResponse<TMessage>> ISoapClient.ExecuteAsync<TMessage>(ISoapRequest request, IcpBrasilX509Certificate2 certificate)
    {
        ClientCredentials.ClientCertificate.Certificate = certificate.PrivateInstance;
        return (ISoapResponse<TMessage>)await Channel.cteConsultaCTAsync(request as CteConsultaCTRequest);
    }
}
