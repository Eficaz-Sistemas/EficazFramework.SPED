using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Services.CTe.Contracts;
using EficazFramework.SPED.Utilities;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Services.CTe.SoapClients;

internal class CTeRecepcaoEventoV4SoapClient(Binding binding, EndpointAddress remoteAddress) : ClientBase<ICTeRecepcaoEventoV4Soap>(binding, remoteAddress), ICTeRecepcaoEventoV4Soap, ISoapClient
{
    public static CTeRecepcaoEventoV4SoapClient Create(
        Schemas.NFe.OrgaoIBGE uf,
        Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
        => new(ConfigureBinding(), new(ConfigureUrl(uf, ambiente)));


    public CTeRecepcaoEventoV4Response cteRecepcaoEvento(CTeRecepcaoEventoV4Request request)
        => Channel.cteRecepcaoEvento(request);

    public async Task<CTeRecepcaoEventoV4Response> cteRecepcaoEventoAsync(CTeRecepcaoEventoV4Request request)
        => await Channel.cteRecepcaoEventoAsync(request);


    private static string ConfigureUrl(Schemas.NFe.OrgaoIBGE uf, Schemas.NFe.Ambiente ambiente)
        => ambiente == Schemas.NFe.Ambiente.Producao ? ConfigureUrlProducao(uf) : ConfigureUrlHomologacao(uf);


    private static string ConfigureUrlProducao(Schemas.NFe.OrgaoIBGE uf)
        => uf switch
        {
            // SVRS
            Schemas.NFe.OrgaoIBGE.AC or Schemas.NFe.OrgaoIBGE.AL or Schemas.NFe.OrgaoIBGE.AM or Schemas.NFe.OrgaoIBGE.BA or
            Schemas.NFe.OrgaoIBGE.CE or Schemas.NFe.OrgaoIBGE.DF or Schemas.NFe.OrgaoIBGE.ES or Schemas.NFe.OrgaoIBGE.GO or
            Schemas.NFe.OrgaoIBGE.MA or Schemas.NFe.OrgaoIBGE.PA or Schemas.NFe.OrgaoIBGE.PB or Schemas.NFe.OrgaoIBGE.PI or
            Schemas.NFe.OrgaoIBGE.RJ or Schemas.NFe.OrgaoIBGE.RN or Schemas.NFe.OrgaoIBGE.RO or Schemas.NFe.OrgaoIBGE.RS or
            Schemas.NFe.OrgaoIBGE.SC or Schemas.NFe.OrgaoIBGE.SE or Schemas.NFe.OrgaoIBGE.TO or
            Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN or Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS
                => "https://cte.svrs.rs.gov.br/ws/CTeRecepcaoEventoV4/CTeRecepcaoEventoV4.asmx",
            // SVSP
            Schemas.NFe.OrgaoIBGE.AP or Schemas.NFe.OrgaoIBGE.PE or Schemas.NFe.OrgaoIBGE.RR or Schemas.NFe.OrgaoIBGE.SP or
            Schemas.NFe.OrgaoIBGE.SefazNacional_SVCSP
                => "https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoEventoV4.asmx",
            Schemas.NFe.OrgaoIBGE.MG => "https://cte.fazenda.mg.gov.br/cte/services/CTeRecepcaoEventoV4",
            Schemas.NFe.OrgaoIBGE.MS => "https://producao.cte.ms.gov.br/ws/CTeRecepcaoEventoV4",
            Schemas.NFe.OrgaoIBGE.MT => "https://cte.sefaz.mt.gov.br/ctews2/services/CTeRecepcaoEventoV4?wsdl",
            Schemas.NFe.OrgaoIBGE.PR => "https://cte.fazenda.pr.gov.br/cte4/CTeRecepcaoEventoV4?wsdl",
            _ => throw new ArgumentOutOfRangeException(nameof(uf), uf, "Não há autorizador de CT-e para o órgão informado.")
        };


    // URLs conferidas em https://hom.cte.fazenda.gov.br/portal/webServices.aspx (CTeRecepcaoEventoV4)
    private static string ConfigureUrlHomologacao(Schemas.NFe.OrgaoIBGE uf)
        => uf switch
        {
            // SVRS
            Schemas.NFe.OrgaoIBGE.AC or Schemas.NFe.OrgaoIBGE.AL or Schemas.NFe.OrgaoIBGE.AM or Schemas.NFe.OrgaoIBGE.BA or
            Schemas.NFe.OrgaoIBGE.CE or Schemas.NFe.OrgaoIBGE.DF or Schemas.NFe.OrgaoIBGE.ES or Schemas.NFe.OrgaoIBGE.GO or
            Schemas.NFe.OrgaoIBGE.MA or Schemas.NFe.OrgaoIBGE.PA or Schemas.NFe.OrgaoIBGE.PB or Schemas.NFe.OrgaoIBGE.PI or
            Schemas.NFe.OrgaoIBGE.RJ or Schemas.NFe.OrgaoIBGE.RN or Schemas.NFe.OrgaoIBGE.RO or Schemas.NFe.OrgaoIBGE.RS or
            Schemas.NFe.OrgaoIBGE.SC or Schemas.NFe.OrgaoIBGE.SE or Schemas.NFe.OrgaoIBGE.TO or
            Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN or Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS
                => "https://cte-homologacao.svrs.rs.gov.br/ws/CTeRecepcaoEventoV4/CTeRecepcaoEventoV4.asmx",
            // SVSP
            Schemas.NFe.OrgaoIBGE.AP or Schemas.NFe.OrgaoIBGE.PE or Schemas.NFe.OrgaoIBGE.RR or Schemas.NFe.OrgaoIBGE.SP or
            Schemas.NFe.OrgaoIBGE.SefazNacional_SVCSP
                => "https://homologacao.nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoEventoV4.asmx",
            Schemas.NFe.OrgaoIBGE.MG => "https://hcte.fazenda.mg.gov.br/cte/services/CTeRecepcaoEventoV4",
            Schemas.NFe.OrgaoIBGE.MS => "https://homologacao.cte.ms.gov.br/ws/CTeRecepcaoEventoV4",
            Schemas.NFe.OrgaoIBGE.MT => "https://homologacao.sefaz.mt.gov.br/ctews2/services/CTeRecepcaoEventoV4?wsdl",
            Schemas.NFe.OrgaoIBGE.PR => "https://homologacao.cte.fazenda.pr.gov.br/cte4/CTeRecepcaoEventoV4?wsdl",
            _ => throw new ArgumentOutOfRangeException(nameof(uf), uf, "Não há autorizador de CT-e para o órgão informado.")
        };


    private static Binding ConfigureBinding()
    {
        var binding = new CustomBinding
        {
            Name = "CTeRecepcaoEventoV4Soap",
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
        var client = Create(
            Enum.Parse<Schemas.NFe.OrgaoIBGE>(args[0]),
            args.Length > 1 ? Enum.Parse<Schemas.NFe.Ambiente>(args[1]) : Schemas.NFe.Ambiente.Producao);
#if DEBUG
        client.Endpoint.EndpointBehaviors.Add(new Utilities.WCF.SoapInspectorBehavior());
#endif
        return client;
    }


    async Task<ISoapResponse<TMessage>> ISoapClient.ExecuteAsync<TMessage>(ISoapRequest request, IcpBrasilX509Certificate2 certificate)
    {
        ClientCredentials.ClientCertificate.Certificate = certificate.PrivateInstance;
        return (ISoapResponse<TMessage>)await Channel.cteRecepcaoEventoAsync(request as CTeRecepcaoEventoV4Request);
    }
}
