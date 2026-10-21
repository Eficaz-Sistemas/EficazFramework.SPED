using EficazFramework.SPED.Interfaces;

namespace EficazFramework.SPED.Services.CTe.Contracts;

[System.ServiceModel.ServiceContract(Namespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeRecepcaoEventoV4", ConfigurationName = "SPED.Services.CTe.CTeRecepcaoEventoV4")]
public partial interface ICTeRecepcaoEventoV4Soap
{
    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/cte/wsdl/CTeRecepcaoEventoV4/cteRecepcaoEvento", ReplyAction = "*")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    CTeRecepcaoEventoV4Response cteRecepcaoEvento(CTeRecepcaoEventoV4Request request);

    [System.ServiceModel.OperationContract(Action = "http://www.portalfiscal.inf.br/cte/wsdl/CTeRecepcaoEventoV4/cteRecepcaoEvento", ReplyAction = "*")]
    Task<CTeRecepcaoEventoV4Response> cteRecepcaoEventoAsync(CTeRecepcaoEventoV4Request request);
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class CTeRecepcaoEventoV4Request : ISoapRequest
{
    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeRecepcaoEventoV4", Order = 0)]
    public XmlNode cteDadosMsg;
}


[System.ServiceModel.MessageContract(IsWrapped = false)]
public partial class CTeRecepcaoEventoV4Response : ISoapResponse<Schemas.CTe.RetornoEvento>
{
    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeRecepcaoEventoV4", Order = 0)]
    [XmlElement(IsNullable = true)]
    public XmlNode cteRecepcaoEventoResult;

    public CTeRecepcaoEventoV4Response() : base() { }

    public CTeRecepcaoEventoV4Response(XmlNode cteRecepcaoEventoResult) : base()
        => this.cteRecepcaoEventoResult = cteRecepcaoEventoResult;

    public Schemas.CTe.RetornoEvento UnWrap()
        => Schemas.CTe.RetornoEvento.Deserialize(cteRecepcaoEventoResult.OuterXml);
}
