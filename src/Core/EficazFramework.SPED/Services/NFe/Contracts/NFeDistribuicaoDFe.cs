using EficazFramework.SPED.Interfaces;

namespace EficazFramework.SPED.Services.NFe.Contracts;


[System.ServiceModel.ServiceContract(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe", ConfigurationName = "SPED.Services.NFe.NFeDistribuicaoDFe")]
public partial interface INFeDistribuicaoDFeSoap
{
    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe/nfeDistDFeInteresse", ReplyAction = "*")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    NFeDistribuicaoDFeResponse nfeDistDFeInteresse(NFeDistribuicaoDFeRequest request);

    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe/nfeDistDFeInteresse", ReplyAction = "*")]
    Task<NFeDistribuicaoDFeResponse> nfeDistDFeInteresseAsync(NFeDistribuicaoDFeRequest request);
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class NFeDistribuicaoDFeRequest : ISoapRequest
{
    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe", Order = 0)]
    public NFeDistribuicaoDFeRequestBody nfeDistDFeInteresse;
}

public partial class NFeDistribuicaoDFeRequestBody
{
    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe", Order = 0)]
    public XmlNode nfeDadosMsg;
}



[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class NFeDistribuicaoDFeResponse : ISoapResponse<Schemas.NFe.RetornoDistribuicaoDFe>
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe", Order = 0)]
    [XmlElement(IsNullable = true)]
    public NFeDistribuicaoDFeResponseBody nfeDistDFeInteresseResponse;

    public NFeDistribuicaoDFeResponse() : base() { }

    public NFeDistribuicaoDFeResponse(NFeDistribuicaoDFeResponseBody nfeDistDFeInteresseResult) : base()
        => this.nfeDistDFeInteresseResponse = nfeDistDFeInteresseResult;

    public Schemas.NFe.RetornoDistribuicaoDFe UnWrap()
        => Schemas.NFe.RetornoDistribuicaoDFe.Deserialize(nfeDistDFeInteresseResponse.nfeDistDFeInteresseResult.OuterXml);
}

public partial class NFeDistribuicaoDFeResponseBody
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe", Order = 0)]
    [XmlElement(IsNullable = true)]
    public XmlNode nfeDistDFeInteresseResult;

    public NFeDistribuicaoDFeResponseBody() : base() { }

    public NFeDistribuicaoDFeResponseBody(XmlNode nfeDistDFeInteresseResult) : base()
        => this.nfeDistDFeInteresseResult = nfeDistDFeInteresseResult;

    public Schemas.NFe.RetornoDistribuicaoDFe UnWrap()
        => Schemas.NFe.RetornoDistribuicaoDFe.Deserialize(nfeDistDFeInteresseResult.OuterXml);
}