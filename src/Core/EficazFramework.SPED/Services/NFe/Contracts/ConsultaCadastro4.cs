using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Schemas.NFe;

namespace EficazFramework.SPED.Services.NFe.Contracts;


[System.ServiceModel.ServiceContract(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro4", ConfigurationName = "SPED.Services.NFe.ConsultaCadastro4")]
public partial interface ICadConsultaCadastro4Soap
{
    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro4/consultaCadastro", ReplyAction = "*")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    consultaCadastroResponse consultaCadastro(consultaCadastroRequest request);

    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro4/consultaCadastro", ReplyAction = "*")]
    Task<consultaCadastroResponse> consultaCadastroAsync(consultaCadastroRequest request);
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class consultaCadastroRequest : ISoapRequest
{
    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro4", Order = 0)]
    public XmlNode nfeDadosMsg;
}


[System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
public partial class consultaCadastroResponse : ISoapResponse<Schemas.NFe.RetornoConsultaCadastro>
{
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro4")]
    [XmlElement(IsNullable = true)]
    public XmlNode nfeResultMsg;

    [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro4")]
    [XmlElement(IsNullable = true)]
    public XmlNode consultaCadastro4Result;


    public RetornoConsultaCadastro UnWrap()
        => Schemas.NFe.RetornoConsultaCadastro.Deserialize(nfeResultMsg?.OuterXml ?? consultaCadastro4Result?.OuterXml.Replace("xmlns=\"http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro4\"", "").Replace(":ns2",""));
}