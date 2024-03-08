using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Schemas.NFe;

namespace EficazFramework.SPED.Services.NFe.Contracts;

[System.ServiceModel.ServiceContract(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/RecepcaoEvento", ConfigurationName = "SPED.Services.NFe.RecepcaoEvento4")]
public partial interface IRecepcaoEvento4Soap
{
    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4/nfeRecepcaoEventoNF", ReplyAction = "*")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    RecepcaoEvento4Response nfeRecepcaoEventoNF(RecepcaoEvento4Request request);

    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4/nfeRecepcaoEventoNF", ReplyAction = "*")]
    Task<RecepcaoEvento4Response> nfeRecepcaoEventoNFAsync(RecepcaoEvento4Request request);
}



[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class RecepcaoEvento4Request : ISoapRequest
{
    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4", Order = 0)]
    public XmlNode nfeDadosMsg;
}


[System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
public partial class RecepcaoEvento4Response : ISoapResponse<Schemas.NFe.RetornoEnvioEvento>
{
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4")]
    [XmlElement(IsNullable = true)]
    public XmlNode nfeRecepcaoEventoNFResult;


    public RetornoEnvioEvento UnWrap()
        => Schemas.NFe.RetornoEnvioEvento.Deserialize(nfeRecepcaoEventoNFResult?.OuterXml);
}