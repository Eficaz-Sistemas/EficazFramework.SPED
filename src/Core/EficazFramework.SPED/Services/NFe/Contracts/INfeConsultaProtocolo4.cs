using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Services.NFe.Contracts;

[System.ServiceModel.ServiceContract(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4")]
internal interface INfeConsultaProtocolo4
{
    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4/nfeConsultaNF", ReplyAction = "*")]
    internal Task<XmlNode> ExecuteAsync([XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4")] XmlNode request);


    internal static Binding ConfigureBinding()
    {
        var binding = new System.ServiceModel.BasicHttpBinding
        {
            MaxReceivedMessageSize = 65536
        };
        binding.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
        binding.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Certificate;
        return binding;
    }

    internal static string ConfigureUrl(params string[] args) => args[0] switch
    {
        "55" => Enum.Parse<Schemas.NFe.OrgaoIBGE>(args[1]) switch
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
            Schemas.NFe.OrgaoIBGE.SE => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx\"",
            Schemas.NFe.OrgaoIBGE.SP => "https://nfe.fazenda.sp.gov.br/ws/nfeconsultaprotocolo4.asmx",
            Schemas.NFe.OrgaoIBGE.TO => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
            Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN => "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx",
            Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS => "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx",
            _ => ""
        },
        "65" => Enum.Parse<Schemas.NFe.OrgaoIBGE>(args[1]) switch
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
}