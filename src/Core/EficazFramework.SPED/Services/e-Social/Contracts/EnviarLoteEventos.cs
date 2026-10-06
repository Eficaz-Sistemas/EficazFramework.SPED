namespace EficazFramework.SPED.Services.eSocial.Contracts;

/// <summary>
/// Define o contrato de serviço SOAP para envio de lotes de eventos ao serviço e-Social.
/// </summary>
/// <remarks>
/// Esta interface representa os pontos de extremidade do serviço e-Social responsáveis pelo processamento
/// e recebimento de lotes de eventos gerados pela folha de pagamento e outras operações de recursos humanos.
/// 
/// Protocolo: SOAP (Simple Object Access Protocol)
/// Versão: v1.1.0
/// Entidade: Serviço de Envio de Lote de Eventos - Empregador
/// 
/// A interface fornece duas operações equivalentes: uma síncrona e outra assíncrona, permitindo flexibilidade
/// no padrão de chamada conforme a necessidade da aplicação cliente.
/// </remarks>
[System.ServiceModel.ServiceContract(Namespace = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0", ConfigurationName = "SPED.Services.eSocial.EnviarLoteEventos")]
public partial interface IServicoEnviarLoteEventosSoap
{
    /// <summary>
    /// Envia de forma síncrona um lote de eventos para o serviço e-Social.
    /// </summary>
    [System.ServiceModel.OperationContract(
        Action = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0/ServicoEnviarLoteEventos/EnviarLoteEventos",
        ReplyAction = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0/ServicoEnviarLoteEventos/EnviarLoteEventosResponse")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    EnviarLoteEventosResponse EnviarLoteEventos(EnviarLoteEventosRequest request);


    /// <summary>
    /// Envia de forma assíncrona um lote de eventos para o serviço e-Social.
    /// </summary>
    [System.ServiceModel.OperationContract(
        Action = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0/ServicoEnviarLoteEventos/EnviarLoteEventos",
        ReplyAction = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0/ServicoEnviarLoteEventos/EnviarLoteEventosResponse")]
    [System.ServiceModel.XmlSerializerFormat(SupportFaults = true)]
    System.Threading.Tasks.Task<EnviarLoteEventosResponse> EnviarLoteEventosAsync(EnviarLoteEventosRequest request);
}

[System.ServiceModel.MessageContract(WrapperName = "EnviarLoteEventos", WrapperNamespace = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0", IsWrapped = true)]
public partial class EnviarLoteEventosRequest : Interfaces.ISoapRequest
{
    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0", Order = 0)]
    public LoteEventos loteEventos { get; set; } = new();

    public EnviarLoteEventosRequest() { }

    public EnviarLoteEventosRequest(System.Xml.XmlElement xmlESocial)
    {
        loteEventos = new LoteEventos { Any = xmlESocial };
    }
}

public class LoteEventos
{
    [System.Xml.Serialization.XmlAnyElement]
    public System.Xml.XmlElement Any { get; set; }
}

[System.ServiceModel.MessageContract(WrapperName = "EnviarLoteEventosResponse", WrapperNamespace = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0", IsWrapped = true)]
public partial class EnviarLoteEventosResponse : Interfaces.ISoapResponse<ResponseEnvioLoteEventos>
{
    [System.ServiceModel.MessageBodyMember(Namespace = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0", Order = 0)]
    public EnviarLoteEventosResult EnviarLoteEventosResult { get; set; }

    public EnviarLoteEventosResponse() { }

    public EnviarLoteEventosResponse(EnviarLoteEventosResult result)
    {
        EnviarLoteEventosResult = result;
    }

    public ResponseEnvioLoteEventos UnWrap()
    {
        if (EnviarLoteEventosResult?.Any == null)
            return null;

        var xmlString = EnviarLoteEventosResult.Any.OuterXml;
        var response = new ResponseEnvioLoteEventos().Read(xmlString);
        return response;
    }
}

public class EnviarLoteEventosResult
{
    [System.Xml.Serialization.XmlAnyElement]
    public System.Xml.XmlElement Any { get; set; }
}