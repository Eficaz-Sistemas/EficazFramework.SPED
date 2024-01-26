using EficazFramework.SPED.Interfaces;

namespace EficazFramework.SPED.Services.NFe.Contracts;


[System.ServiceModel.ServiceContract(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4", ConfigurationName = "SPED.Services.NFe.ConsultaProtocolo4")]
public partial interface INFeConsultaProtocolo4Soap
{
    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4/nfeConsultaNF", ReplyAction = "*")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    nfeConsultaNFResponse nfeConsultaNF(nfeConsultaNFRequest request);

    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4/nfeConsultaNF", ReplyAction = "*")]
    Task<nfeConsultaNFResponse> nfeConsultaNFAsync(nfeConsultaNFRequest request);
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class nfeConsultaNFRequest : ISoapRequest
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4", Order = 0)]
    public XmlNode nfeDadosMsg;
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class nfeConsultaNFResponse : ISoapResponse<Schemas.NFe.RetornoConsultaSituacaoNFe>
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4", Order = 0)]
    [XmlElement(IsNullable = true)]
    public XmlNode nfeResultMsg;

    public nfeConsultaNFResponse() : base() { }

    public nfeConsultaNFResponse(XmlNode nfeResultMsg) : base()
        => this.nfeResultMsg = nfeResultMsg;

    public Schemas.NFe.RetornoConsultaSituacaoNFe UnWrap()
        => Schemas.NFe.RetornoConsultaSituacaoNFe.Deserialize(nfeResultMsg.OuterXml);
}