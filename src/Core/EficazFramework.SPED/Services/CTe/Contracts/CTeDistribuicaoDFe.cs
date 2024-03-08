using EficazFramework.SPED.Interfaces;

namespace EficazFramework.SPED.Services.CTe.Contracts;

[System.ServiceModel.ServiceContract(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/CTeDistribuicaoDFe", ConfigurationName = "SPED.Services.NFe.CTeDistribuicaoDFe")]
public partial interface ICTeDistribuicaoDFeSoap
{
    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe/cteDistDFeInteresse", ReplyAction = "*")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    CTeDistribuicaoDFeResponse cteDistDFeInteresse(CTeDistribuicaoDFeRequest request);

    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe/cteDistDFeInteresse", ReplyAction = "*")]
    Task<CTeDistribuicaoDFeResponse> cteDistDFeInteresseAsync(CTeDistribuicaoDFeRequest request);
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class CTeDistribuicaoDFeRequest : ISoapRequest
{
    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/CTeDistribuicaoDFe", Order = 0)]
    public CTeDistribuicaoDFeRequestBody cteDistDFeInteresse;
}

public partial class CTeDistribuicaoDFeRequestBody
{
    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/CTeDistribuicaoDFe", Order = 0)]
    public XmlNode nfeDadosMsg;
}




[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class CTeDistribuicaoDFeResponse : ISoapResponse<Schemas.CTe.RetornoDistribuicaoDFe>
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe", Order = 0)]
    [XmlElement(IsNullable = true)]
    public CTeDistribuicaoDFeResponseBody cteDistDFeInteresseResponse;

    public CTeDistribuicaoDFeResponse() : base() { }

    public CTeDistribuicaoDFeResponse(CTeDistribuicaoDFeResponseBody cteDistDFeInteresseResult) : base()
        => cteDistDFeInteresseResponse = cteDistDFeInteresseResult;

    public Schemas.CTe.RetornoDistribuicaoDFe UnWrap()
        => Schemas.CTe.RetornoDistribuicaoDFe.Deserialize(cteDistDFeInteresseResponse.cteDistDFeInteresseResult.OuterXml);
}

public partial class CTeDistribuicaoDFeResponseBody
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe", Order = 0)]
    [XmlElement(IsNullable = true)]
    public XmlNode cteDistDFeInteresseResult;

    public CTeDistribuicaoDFeResponseBody() : base() { }

    public CTeDistribuicaoDFeResponseBody(XmlNode cteDistDFeInteresseResult) : base()
        => this.cteDistDFeInteresseResult = cteDistDFeInteresseResult;

    public Schemas.CTe.RetornoDistribuicaoDFe UnWrap()
        => Schemas.CTe.RetornoDistribuicaoDFe.Deserialize(cteDistDFeInteresseResult.OuterXml);
}