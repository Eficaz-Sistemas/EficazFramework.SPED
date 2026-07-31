namespace EficazFramework.SPED.Services.eSocial.Contracts;

/// <summary>
/// Define o contrato de serviço SOAP para envio de lote de eventos para a plataforma e-Social.
/// </summary>
/// <remarks>
/// Esta interface base fornece assinaturas padrão para operações de envio de lotes de eventos,
/// com suporte tanto para operações síncronas quanto assíncronas. As implementações herdam
/// desta interface para manter compatibilidade com diferentes versões do serviço e-Social.
/// </remarks>
public interface IServicoEnviarLoteEventosSoap
{
    /// <summary>
    /// Envia de forma síncrona um lote de eventos para o serviço e-Social.
    /// </summary>
    /// <param name="request">
    /// Objeto contendo os dados do lote de eventos a ser enviado, incluindo informações
    /// de identificação e estrutura dos eventos.
    /// </param>
    /// <returns>
    /// Retorna um objeto <see cref="Response"/> contendo a resposta do serviço e-Social,
    /// que inclui informações sobre o recebimento e processamento do lote.
    /// </returns>
    /// <remarks>
    /// Este método fornece uma implementação padrão que retorna <c>null</c> por padrão.
    /// Implementações específicas devem sobrescrever este método com a lógica adequada
    /// de chamada ao serviço SOAP do e-Social.
    /// </remarks>
    virtual Response EnviarLoteEventos(Request request) => null;

    /// <summary>
    /// Envia de forma assíncrona um lote de eventos para o serviço e-Social.
    /// </summary>
    /// <param name="request">
    /// Objeto contendo os dados do lote de eventos a ser enviado, incluindo informações
    /// de identificação e estrutura dos eventos.
    /// </param>
    /// <returns>
    /// Retorna uma tarefa assíncrona que representa o resultado da operação, contendo
    /// um objeto <see cref="Response"/> com a resposta do serviço e-Social.
    /// </returns>
    /// <remarks>
    /// Este método fornece uma implementação padrão que retorna uma tarefa com uma resposta
    /// vazia. Implementações específicas devem sobrescrever este método com a lógica adequada
    /// de chamada assíncrona ao serviço SOAP do e-Social, permitindo operações não-bloqueantes.
    /// </remarks>
    virtual async System.Threading.Tasks.Task<Response> EnviarLoteEventosAsync(Request request) =>
        await Task.FromResult(new Response());

}

/// <summary>
/// Define o contrato de serviço SOAP para envio de lote de eventos à plataforma e-Social na versão 1.1.0.
/// </summary>
/// <remarks>
/// <para>
/// Esta interface herda de <see cref="IServicoEnviarLoteEventosSoap"/> e especifica o contrato de serviço WCF/SOAP
/// para comunicação com o serviço de envio de lotes de eventos do e-Social. Ela implementa operações
/// SOAP que seguem o padrão de namespace e ações especificadas pela plataforma e-Social.
/// </para>
/// <para>
/// A interface fornece suporte para:
/// <list type="bullet">
/// <item><description>Envio síncrono de lotes de eventos via <see cref="EnviarLoteEventos(Request)"/></description></item>
/// <item><description>Envio assíncrono de lotes de eventos via <see cref="EnviarLoteEventosAsync(Request)"/></description></item>
/// </list>
/// </para>
/// <para>
/// O namespace do serviço é <c>http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0</c>
/// e o nome de configuração é <c>SPED.Services.eSocial.Contracts</c>.
/// </para>
/// </remarks>
[System.ServiceModel.ServiceContract(
    Namespace = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0", 
    ConfigurationName = "SPED.Services.eSocial.Contracts")]
public partial interface IServicoEnviarLoteEventosSoap_v1_1_0 : IServicoEnviarLoteEventosSoap
{
    /// <inheritdoc />
    [System.ServiceModel.OperationContract(
        Action = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0/ServicoEnviarLoteEventos/EnviarLoteEventos", 
        ReplyAction = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0/ServicoEnviarLoteEventos/EnviarLoteEventosResponse")]
    new Response EnviarLoteEventos(Request request);


    /// <inheritdoc />
    [System.ServiceModel.OperationContract(
        Action = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0/ServicoEnviarLoteEventos/EnviarLoteEventos", 
        ReplyAction = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0/ServicoEnviarLoteEventos/EnviarLoteEventosResponse")]
    new System.Threading.Tasks.Task<Response> EnviarLoteEventosAsync(Request request);
}
