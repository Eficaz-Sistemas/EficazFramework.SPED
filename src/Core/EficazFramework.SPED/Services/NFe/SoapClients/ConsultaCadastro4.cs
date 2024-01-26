using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Services.NFe.Contracts;
using EficazFramework.SPED.Utilities;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Services.NFe.SoapClients;

public partial class CadConsultaCadastro4SoapClient : System.ServiceModel.ClientBase<ICadConsultaCadastro4Soap>, ICadConsultaCadastro4Soap, ISoapClient
{

    public static CadConsultaCadastro4SoapClient Create(Schemas.NFe.OrgaoIBGE uf)
        => new CadConsultaCadastro4SoapClient(ConfigureBinding(), new(ConfigureUrl(uf)));

    public CadConsultaCadastro4SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : base(binding, remoteAddress) { }


    public async Task<consultaCadastroResponse> consultaCadastroAsync(consultaCadastroRequest request)
        => await Channel.consultaCadastroAsync(request);

    public consultaCadastroResponse consultaCadastro(consultaCadastroRequest request)
        => Channel.consultaCadastro(request);


    private static string ConfigureUrl(Schemas.NFe.OrgaoIBGE uf)
    => uf switch
    {
        //Schemas.NFe.OrgaoIBGE.AC => "",
        //Schemas.NFe.OrgaoIBGE.AL => "",
        //Schemas.NFe.OrgaoIBGE.AM => "",
        //Schemas.NFe.OrgaoIBGE.AP => "",
        Schemas.NFe.OrgaoIBGE.BA => "https://nfe.sefaz.ba.gov.br/webservices/CadConsultaCadastro4/CadConsultaCadastro4.asmx",
        Schemas.NFe.OrgaoIBGE.CE => "https://nfe.sefaz.ce.gov.br/nfe4/services/CadConsultaCadastro4?wsdl",
        //Schemas.NFe.OrgaoIBGE.DF => "",
        //Schemas.NFe.OrgaoIBGE.ES => "",
        Schemas.NFe.OrgaoIBGE.GO => "https://nfe.sefaz.go.gov.br/nfe/services/CadConsultaCadastro4?wsdl",
        //Schemas.NFe.OrgaoIBGE.MA => "",
        Schemas.NFe.OrgaoIBGE.MG => "https://nfe.fazenda.mg.gov.br/nfe2/services/CadConsultaCadastro4",
        Schemas.NFe.OrgaoIBGE.MS => "https://nfe.sefaz.ms.gov.br/ws/CadConsultaCadastro4",
        Schemas.NFe.OrgaoIBGE.MT => "https://nfe.sefaz.mt.gov.br/nfews/v2/services/CadConsultaCadastro4?wsdl",
        //Schemas.NFe.OrgaoIBGE.PA => "",
        //Schemas.NFe.OrgaoIBGE.PB => "",
        Schemas.NFe.OrgaoIBGE.PE => "https://nfe.sefaz.pe.gov.br/nfe-service/services/CadConsultaCadastro4?wsdl",
        //Schemas.NFe.OrgaoIBGE.PI => "",
        Schemas.NFe.OrgaoIBGE.PR => "https://nfe.sefa.pr.gov.br/nfe/CadConsultaCadastro4?wsdl",
        //Schemas.NFe.OrgaoIBGE.RJ => "",
        //Schemas.NFe.OrgaoIBGE.RN => "",
        //Schemas.NFe.OrgaoIBGE.RO => "",
        //Schemas.NFe.OrgaoIBGE.RR => "",
        Schemas.NFe.OrgaoIBGE.RS => "https://cad.sefazrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx",
        //Schemas.NFe.OrgaoIBGE.SC => "",
        //Schemas.NFe.OrgaoIBGE.SE => "",
        Schemas.NFe.OrgaoIBGE.SP => "https://nfe.fazenda.sp.gov.br/ws/cadconsultacadastro4.asmx",
        //Schemas.NFe.OrgaoIBGE.TO => "",
        //Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN => "",
        //Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS => "",
        _ => "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx"
    };

    private static Binding ConfigureBinding()
    {
        var binding = new CustomBinding
        {
            Name = "CadConsultaCadastro4Soap",
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
        var client = Create(Enum.Parse<Schemas.NFe.OrgaoIBGE>(args[0]));
#if DEBUG
        client.Endpoint.EndpointBehaviors.Add(new Utilities.WCF.SoapInspectorBehavior());
#endif
        return client;
    }

    async Task<ISoapResponse<TMessage>> ISoapClient.ExecuteAsync<TMessage>(ISoapRequest request, IcpBrasilX509Certificate2 certificate)
    {
        ClientCredentials.ClientCertificate.Certificate = certificate.PrivateInstance;
        return (ISoapResponse<TMessage>)await Channel.consultaCadastroAsync(request as consultaCadastroRequest);
    }
}