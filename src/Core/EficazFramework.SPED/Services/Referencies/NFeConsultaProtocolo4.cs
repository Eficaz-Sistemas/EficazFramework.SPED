namespace EficazFramework.SPED.Referencies.NFe;

[System.ServiceModel.ServiceContract(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4", ConfigurationName = "NFe.Services.ConsultaProtocolo4.NFeConsultaProtocolo4Soap")]
public partial interface INFeConsultaProtocolo4Soap
{

    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4/nfeConsultaNF", ReplyAction = "*")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    nfeConsultaNFResponse nfeConsultaNF(nfeConsultaNFRequest request);

    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4/nfeConsultaNF", ReplyAction = "*")]
    Task<nfeConsultaNFResponse> nfeConsultaNFAsync(nfeConsultaNFRequest request);
}

[DebuggerStepThrough()]
[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class nfeConsultaNFRequest
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4", Order = 0)]
    public XmlNode nfeDadosMsg;

    public nfeConsultaNFRequest() : base() { }

    public nfeConsultaNFRequest(XmlNode nfeDadosMsg) : base()
        => this.nfeDadosMsg = nfeDadosMsg;
}

[DebuggerStepThrough()]
[System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
public partial class nfeConsultaNFResponse
{

    [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4", Order = 0)]
    [System.Xml.Serialization.XmlElement(IsNullable = true)]
    public System.Xml.XmlNode nfeResultMsg;

    public nfeConsultaNFResponse() : base() { }

    public nfeConsultaNFResponse(System.Xml.XmlNode nfeResultMsg) : base()
        => this.nfeResultMsg = nfeResultMsg;
}

public partial interface NFeConsultaProtocolo4SoapChannel : INFeConsultaProtocolo4Soap, System.ServiceModel.IClientChannel { }


public partial class NFeConsultaProtocolo4SoapClient : System.ServiceModel.ClientBase<INFeConsultaProtocolo4Soap>, INFeConsultaProtocolo4Soap
{

    public static NFeConsultaProtocolo4SoapClient Create(Schemas.NFe.OrgaoIBGE uf, string modelo = "55")
    {
        return new NFeConsultaProtocolo4SoapClient(SPED.Utilities.Services.CreateCustomBinding("nfeConsultaNFSoap"), SPED.Utilities.Services.CreateDefaultEndPoint(ResolveSitNFeURI(uf, modelo)));
    }

    public NFeConsultaProtocolo4SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : base(binding, remoteAddress) { }

    public nfeConsultaNFResponse NFe_Services_ConsultaProtocolo4_NFeConsultaProtocolo4Soap_nfeConsultaNF(nfeConsultaNFRequest request)
    {
        return Channel.nfeConsultaNF(request);
    }

    nfeConsultaNFResponse nfeConsultaNF(nfeConsultaNFRequest request) => NFe_Services_ConsultaProtocolo4_NFeConsultaProtocolo4Soap_nfeConsultaNF(request);

    public XmlNode nfeConsultaNF(XmlNode nfeDadosMsg)
    {
        var inValue = new nfeConsultaNFRequest();
        inValue.nfeDadosMsg = nfeDadosMsg;
        var retVal = ((INFeConsultaProtocolo4Soap)this).nfeConsultaNF(inValue);
        return retVal.nfeResultMsg;
    }

    public async Task<nfeConsultaNFResponse> NFe_Services_ConsultaProtocolo4_NFeConsultaProtocolo4Soap_nfeConsultaNFAsync(nfeConsultaNFRequest request)
    {
        return await Channel.nfeConsultaNFAsync(request);
    }

    async Task<nfeConsultaNFResponse> INFeConsultaProtocolo4Soap.nfeConsultaNFAsync(nfeConsultaNFRequest request) => await NFe_Services_ConsultaProtocolo4_NFeConsultaProtocolo4Soap_nfeConsultaNFAsync(request);

    public Task<nfeConsultaNFResponse> nfeConsultaNFAsync(XmlNode nfeDadosMsg)
    {
        var inValue = new nfeConsultaNFRequest();
        inValue.nfeDadosMsg = nfeDadosMsg;
        return ((INFeConsultaProtocolo4Soap)this).nfeConsultaNFAsync(inValue);
    }

    private static string ResolveSitNFeURI(Schemas.NFe.OrgaoIBGE uf, string modelo = "55")
    {
        if (modelo == "55")
            return uf switch
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
                _ => ""
            };
        else if (modelo == "65")
            return uf switch
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
                _ => ""
            };
        else
            return "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
    }

        //{
        //    switch (uf)
        //    {
        //        case var @case when @case == Schemas.NFe.OrgaoIBGE.AC:
        //            {
        //                return "";
        //            }
        //        case var case1 when case1 == Schemas.NFe.OrgaoIBGE.AL:
        //            {
        //                return "";
        //            }
        //        case var case2 when case2 == Schemas.NFe.OrgaoIBGE.AM:
        //            {
        //                return "";
        //            }
        //        case var case3 when case3 == Schemas.NFe.OrgaoIBGE.AP:
        //            {
        //                return "";
        //            }
        //        case var case4 when case4 == Schemas.NFe.OrgaoIBGE.BA:
        //            {
        //                return "";
        //            }
        //        case var case5 when case5 == Schemas.NFe.OrgaoIBGE.CE:
        //            {
        //                return "";
        //            }
        //        case var case6 when case6 == Schemas.NFe.OrgaoIBGE.DF:
        //            {
        //                return "";
        //            }
        //        case var case7 when case7 == Schemas.NFe.OrgaoIBGE.ES:
        //            {
        //                return "";
        //            }
        //        case var case8 when case8 == Schemas.NFe.OrgaoIBGE.GO:
        //            {
        //                return "";
        //            }
        //        case var case9 when case9 == Schemas.NFe.OrgaoIBGE.MA:
        //            {
        //                return "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
        //            }
        //        case var case10 when case10 == Schemas.NFe.OrgaoIBGE.MG:
        //            {
        //                return "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeConsultaProtocolo4";
        //            }
        //        case var case11 when case11 == Schemas.NFe.OrgaoIBGE.MS:
        //            {
        //                return "https://nfe.sefaz.ms.gov.br/ws/NFeConsultaProtocolo4";
        //            }
        //        case var case12 when case12 == Schemas.NFe.OrgaoIBGE.MT:
        //            {
        //                return "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeConsulta4?wsdl";
        //            }
        //        case var case13 when case13 == Schemas.NFe.OrgaoIBGE.PA:
        //            {
        //                return "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
        //            }
        //        case var case14 when case14 == Schemas.NFe.OrgaoIBGE.PB:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case15 when case15 == Schemas.NFe.OrgaoIBGE.PE:
        //            {
        //                return "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeConsultaProtocolo4";
        //            }
        //        case var case16 when case16 == Schemas.NFe.OrgaoIBGE.PI:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case17 when case17 == Schemas.NFe.OrgaoIBGE.PR:
        //            {
        //                return "https://nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4?wsdl";
        //            }
        //        case var case18 when case18 == Schemas.NFe.OrgaoIBGE.RJ:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case19 when case19 == Schemas.NFe.OrgaoIBGE.RN:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case20 when case20 == Schemas.NFe.OrgaoIBGE.RO:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case21 when case21 == Schemas.NFe.OrgaoIBGE.RR:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case22 when case22 == Schemas.NFe.OrgaoIBGE.RS:
        //            {
        //                return "https://nfe.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case23 when case23 == Schemas.NFe.OrgaoIBGE.SC:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case24 when case24 == Schemas.NFe.OrgaoIBGE.SE:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case25 when case25 == Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN:
        //            {
        //                return "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
        //            }
        //        case var case26 when case26 == Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case27 when case27 == Schemas.NFe.OrgaoIBGE.SP:
        //            {
        //                return "https://nfe.fazenda.sp.gov.br/ws/nfeconsultaprotocolo4.asmx";
        //            }
        //        case var case28 when case28 == Schemas.NFe.OrgaoIBGE.TO:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }

        //        default:
        //            {
        //                return null;
        //            }
        //    }
        //}
        //else if (modelo == "65")
        //{
        //    switch (uf)
        //    {
        //        case var case29 when case29 == Schemas.NFe.OrgaoIBGE.AC:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case30 when case30 == Schemas.NFe.OrgaoIBGE.AL:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case31 when case31 == Schemas.NFe.OrgaoIBGE.AM:
        //            {
        //                return "https://nfe.sefaz.am.gov.br/services2/services/NfeConsulta4";
        //            }
        //        case var case32 when case32 == Schemas.NFe.OrgaoIBGE.AP:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case33 when case33 == Schemas.NFe.OrgaoIBGE.BA:
        //            {
        //                return "https://nfe.sefaz.ba.gov.br/webservices/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
        //            }
        //        case var case34 when case34 == Schemas.NFe.OrgaoIBGE.CE:
        //            {
        //                return "https://nfe.sefaz.ce.gov.br/nfe4/services/NFeConsultaProtocolo4?wsdl";
        //            }
        //        case var case35 when case35 == Schemas.NFe.OrgaoIBGE.DF:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case36 when case36 == Schemas.NFe.OrgaoIBGE.ES:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case37 when case37 == Schemas.NFe.OrgaoIBGE.GO:
        //            {
        //                return "https://nfe.sefaz.go.gov.br/nfe/services/NFeConsultaProtocolo4?wsdl";
        //            }
        //        case var case38 when case38 == Schemas.NFe.OrgaoIBGE.MA:
        //            {
        //                return "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
        //            }
        //        case var case39 when case39 == Schemas.NFe.OrgaoIBGE.MG:
        //            {
        //                return "https://nfce.fazenda.mg.gov.br/nfce/services/NFeConsultaProtocolo4"; // working
        //            }
        //        case var case40 when case40 == Schemas.NFe.OrgaoIBGE.MS:
        //            {
        //                return "https://nfe.sefaz.ms.gov.br/ws/NFeConsultaProtocolo4";
        //            }
        //        case var case41 when case41 == Schemas.NFe.OrgaoIBGE.MT:
        //            {
        //                return "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeConsulta4?wsdl";
        //            }
        //        case var case42 when case42 == Schemas.NFe.OrgaoIBGE.PA:
        //            {
        //                return "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
        //            }
        //        case var case43 when case43 == Schemas.NFe.OrgaoIBGE.PB:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case44 when case44 == Schemas.NFe.OrgaoIBGE.PE:
        //            {
        //                return "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeConsultaProtocolo4";
        //            }
        //        case var case45 when case45 == Schemas.NFe.OrgaoIBGE.PI:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case46 when case46 == Schemas.NFe.OrgaoIBGE.PR:
        //            {
        //                return "https://nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4?wsdl";
        //            }
        //        case var case47 when case47 == Schemas.NFe.OrgaoIBGE.RJ:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case48 when case48 == Schemas.NFe.OrgaoIBGE.RN:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case49 when case49 == Schemas.NFe.OrgaoIBGE.RO:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case50 when case50 == Schemas.NFe.OrgaoIBGE.RR:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case51 when case51 == Schemas.NFe.OrgaoIBGE.RS:
        //            {
        //                return "https://nfe.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case52 when case52 == Schemas.NFe.OrgaoIBGE.SC:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case53 when case53 == Schemas.NFe.OrgaoIBGE.SE:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case54 when case54 == Schemas.NFe.OrgaoIBGE.SefazNacional_SVCAN:
        //            {
        //                return "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
        //            }
        //        case var case55 when case55 == Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }
        //        case var case56 when case56 == Schemas.NFe.OrgaoIBGE.SP:
        //            {
        //                return "https://nfce.fazenda.sp.gov.br/ws/NFeConsultaProtocolo4.asmx"; // working
        //            }
        //        case var case57 when case57 == Schemas.NFe.OrgaoIBGE.TO:
        //            {
        //                return "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
        //            }

        //        default:
        //            {
        //                return null;
        //            }
        //    }
        //}
        //else
        //{
        //    return "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
        }
    }
}