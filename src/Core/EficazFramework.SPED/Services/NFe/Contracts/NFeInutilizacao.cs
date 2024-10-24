using EficazFramework.SPED.Interfaces;

namespace EficazFramework.SPED.Services.NFe.Contracts;


[System.ServiceModel.ServiceContract(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeInutilizacao4", ConfigurationName = "SPED.Services.NFe.StatusServico")]
public partial interface INFeInutilizacaoSoap
{
    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeInutilizacao4/nfeInutilizacaoNF", ReplyAction = "*")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    nfeInutilizacaoResponse nfeInutilizacaoNF(nfeInutilizacaoRequest request);

    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeInutilizacao4/nfeInutilizacaoNF", ReplyAction = "*")]
    Task<nfeInutilizacaoResponse> nfeInutilizacaoNFAsync(nfeInutilizacaoRequest request);
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class nfeInutilizacaoRequest : ISoapRequest
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeInutilizacao4", Order = 0)]
    public XmlNode nfeDadosMsg;
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class nfeInutilizacaoResponse : ISoapResponse<Schemas.NFe.InutilizacaoRetorno>
{

    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeInutilizacao4", Order = 0)]
    [XmlElement(IsNullable = true)]
    public XmlNode nfeResultMsg;

    public nfeInutilizacaoResponse() : base() { }

    public nfeInutilizacaoResponse(XmlNode nfeResultMsg) : base()
        => this.nfeResultMsg = nfeResultMsg;

    public Schemas.NFe.InutilizacaoRetorno UnWrap()
        => Schemas.NFe.InutilizacaoRetorno.Deserialize(nfeResultMsg.OuterXml);
}