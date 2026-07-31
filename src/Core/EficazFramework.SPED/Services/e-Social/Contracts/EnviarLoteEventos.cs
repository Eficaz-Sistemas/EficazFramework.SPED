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
    /// <param name="request">
    /// Objeto do tipo <see cref="RequestEnvioLoteEventos"/> contendo os dados do lote de eventos a ser enviado.
    /// Inclui informações de autenticação, identificação do empregador e estrutura detalhada dos eventos.
    /// Este parâmetro não pode ser nulo.
    /// </param>
    /// <returns>
    /// Retorna um objeto <see cref="ResponseEnvioLoteEventos"/> contendo a resposta do serviço e-Social,
    /// que inclui informações sobre o recebimento e processamento do lote, incluindo ocorrências de validação
    /// e status de cada evento processado.
    /// </returns>
    /// <remarks>
    /// Esta é uma operação de chamada síncrona que bloqueia a execução até a resposta do servidor.
    /// A chamada se completa quando o serviço e-Social recebe e processa o lote de eventos.
    /// 
    /// Tempo de resposta típico: varia conforme a quantidade e complexidade dos eventos enviados.
    /// </remarks>
    /// <exception cref="System.ServiceModel.FaultException">
    /// Lançada quando o serviço e-Social retorna uma falha SOAP indicando erro no processamento.
    /// </exception>
    /// <exception cref="System.ServiceModel.CommunicationException">
    /// Lançada quando há problemas de comunicação com o serviço e-Social.
    /// </exception>
    [System.ServiceModel.OperationContract(
        Action = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0/ServicoEnviarLoteEventos/EnviarLoteEventos",
        ReplyAction = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0/ServicoEnviarLoteEventos/EnviarLoteEventosResponse")]
    ResponseEnvioLoteEventos EnviarLoteEventos(RequestEnvioLoteEventos request);


    /// <summary>
    /// Envia de forma assíncrona um lote de eventos para o serviço e-Social.
    /// </summary>
    /// <param name="request">
    /// Objeto do tipo <see cref="RequestEnvioLoteEventos"/> contendo os dados do lote de eventos a ser enviado.
    /// Inclui informações de autenticação, identificação do empregador e estrutura detalhada dos eventos.
    /// Este parâmetro não pode ser nulo.
    /// </param>
    /// <returns>
    /// Retorna uma tarefa assíncrona (<see cref="System.Threading.Tasks.Task{TResult}"/>) que representa 
    /// o resultado da operação. Quando completada, contém um objeto <see cref="ResponseEnvioLoteEventos"/> 
    /// com a resposta do serviço e-Social.
    /// </returns>
    /// <remarks>
    /// Esta é uma operação de chamada assíncrona que não bloqueia a thread de execução.
    /// Utilize este método em cenários onde a aplicação requer responsividade ou processamento paralelo.
    /// 
    /// A tarefa retornada deve ser aguardada usando a palavra-chave <b>await</b> para obter o resultado.
    /// 
    /// Recomendado para: aplicações com interface gráfica, processamento em background ou múltiplas 
    /// chamadas simultâneas ao serviço.
    /// </remarks>
    /// <exception cref="System.ServiceModel.FaultException">
    /// Lançada quando o serviço e-Social retorna uma falha SOAP indicando erro no processamento.
    /// </exception>
    /// <exception cref="System.ServiceModel.CommunicationException">
    /// Lançada quando há problemas de comunicação com o serviço e-Social.
    /// </exception>
    /// <exception cref="System.OperationCanceledException">
    /// Lançada quando a operação assíncrona é cancelada via CancellationToken.
    /// </exception>
    [System.ServiceModel.OperationContract(
        Action = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0/ServicoEnviarLoteEventos/EnviarLoteEventos",
        ReplyAction = "http://www.esocial.gov.br/servicos/empregador/lote/eventos/envio/v1_1_0/ServicoEnviarLoteEventos/EnviarLoteEventosResponse")]
    System.Threading.Tasks.Task<ResponseEnvioLoteEventos> EnviarLoteEventosAsync(RequestEnvioLoteEventos request);
}