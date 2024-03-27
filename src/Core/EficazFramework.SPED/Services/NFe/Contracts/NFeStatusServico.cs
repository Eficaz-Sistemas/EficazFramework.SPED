using EficazFramework.SPED.Interfaces;

namespace EficazFramework.SPED.Services.NFe.Contracts;


[System.ServiceModel.ServiceContract(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeStatusServico4", ConfigurationName = "SPED.Services.NFe.StatusServico")]
public partial interface INFeStatusServicoSoap
{
    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeStatusServico4/nfeStatusServicoNF", ReplyAction = "*")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    nfeStatusServicoResponse nfeStatusServicoNF(nfeStatusServicoRequest request);

    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeStatusServico4/nfeStatusServicoNF", ReplyAction = "*")]
    Task<nfeStatusServicoResponse> nfeStatusServicoNFAsync(nfeStatusServicoRequest request);
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class nfeStatusServicoRequest : ISoapRequest
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeStatusServico4", Order = 0)]
    public XmlNode nfeDadosMsg;
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class nfeStatusServicoResponse : ISoapResponse<Schemas.NFe.RetornoConsultaStatusServicoNFe>
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeStatusServico4", Order = 0)]
    [XmlElement(IsNullable = true)]
    public XmlNode nfeResultMsg;

    public nfeStatusServicoResponse() : base() { }

    public nfeStatusServicoResponse(XmlNode nfeResultMsg) : base()
        => this.nfeResultMsg = nfeResultMsg;

    public Schemas.NFe.RetornoConsultaStatusServicoNFe UnWrap()
        => Schemas.NFe.RetornoConsultaStatusServicoNFe.Deserialize(nfeResultMsg.OuterXml);
}