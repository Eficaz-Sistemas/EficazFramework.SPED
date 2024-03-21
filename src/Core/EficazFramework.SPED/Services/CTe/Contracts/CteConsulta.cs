using EficazFramework.SPED.Interfaces;

namespace EficazFramework.SPED.Services.CTe.Contracts;

[System.ServiceModel.ServiceContract(Namespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeConsultaV4", ConfigurationName = "SPED.Services.CTe.CteConsulta")]
public partial interface ICteConsultaSoap
{
    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/cte/wsdl/CTeConsultaV4/cteConsultaCT", ReplyAction = "*")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    CteConsultaCTResponse cteConsultaCT(CteConsultaCTRequest request);

    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/cte/wsdl/CTeConsultaV4/cteConsultaCT", ReplyAction = "*")]
    Task<CteConsultaCTResponse> cteConsultaCTAsync(CteConsultaCTRequest request);
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class CteConsultaCTRequest : ISoapRequest
{
    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeConsultaV4", Order = 0)]
    public XmlNode cteDadosMsg;
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class CteConsultaCTResponse : ISoapResponse<Schemas.CTe.RetornoConsultaSituacaoCTe>
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeConsultaV4", Order = 0)]
    [XmlElement(IsNullable = true)]
    public XmlNode cteConsultaCTResult ;

    public CteConsultaCTResponse() : base() { }

    public CteConsultaCTResponse(XmlNode cteDistDFeInteresseResult) : base()
        => cteConsultaCTResult = cteDistDFeInteresseResult;

    public Schemas.CTe.RetornoConsultaSituacaoCTe UnWrap()
        => Schemas.CTe.RetornoConsultaSituacaoCTe.Deserialize(cteConsultaCTResult.OuterXml);
}