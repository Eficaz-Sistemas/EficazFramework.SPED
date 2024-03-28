using EficazFramework.SPED.Interfaces;

namespace EficazFramework.SPED.Services.NFe.Contracts;

[System.ServiceModel.ServiceContract(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4", ConfigurationName = "SPED.Services.NFe.ConsultaProtocolo4")]
public partial interface INFeAutorizacao4Soap
{
    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4/nfeAutorizacaoLote", ReplyAction = "*")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    nfeAutorizacaoLoteResponse nfeAutorizacaoLote(nfeAutorizacaoLoteRequest request);

    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4/nfeAutorizacaoLote", ReplyAction = "*")]
    Task<nfeAutorizacaoLoteResponse> nfeAutorizacaoLoteAsync(nfeAutorizacaoLoteRequest request);
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class nfeAutorizacaoLoteRequest : ISoapRequest
{
    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4", Order = 0)]
    public XmlNode nfeDadosMsg;
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class nfeAutorizacaoLoteResponse : ISoapResponse<Schemas.NFe.RetornoAutorizacaoNFe>
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4", Order = 0)]
    [XmlElement(IsNullable = true)]
    public XmlNode nfeResultMsg;

    public nfeAutorizacaoLoteResponse() : base() { }

    public nfeAutorizacaoLoteResponse(XmlNode nfeResultMsg) : base()
        => this.nfeResultMsg = nfeResultMsg;

    public Schemas.NFe.RetornoAutorizacaoNFe UnWrap()
        => Schemas.NFe.RetornoAutorizacaoNFe.Deserialize(nfeResultMsg.OuterXml);
}