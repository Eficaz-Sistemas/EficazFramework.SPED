using EficazFramework.SPED.Services.Primitives;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.ServiceModel;
using System.Xml;
using System.Xml.Schema;

namespace EficazFramework.SPED.Services.eSocial;
public class ESocialServices : SoapServiceBase
{
    public ESocialServices() { }


    /// <summary>
    /// Efetua a requisição à API REST recepcao/lotes do e-Social para transmissão do lote de eventos
    /// </summary>
    /// <param name="eventos">Lote de Eventos a serem transmitidos. Respeitar o limite de 50 eventos por lote</param>
    /// <param name="contribuinte">Identificação do Contribuinte</param>
    /// <param name="ambiente">Ambiente de Produção ou Testes</param>
    /// <param name="versao">Versão do Serviço REST</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="System.ServiceModel.FaultException">
    /// Lançada quando o serviço e-Social retorna uma falha SOAP indicando erro no processamento.
    /// </exception>
    /// <exception cref="System.ServiceModel.CommunicationException">
    /// Lançada quando há problemas de comunicação com o serviço e-Social.
    /// </exception>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<ResponseEnvioLoteEventos> EnviaEventosAsync(
        IList<Schemas.eSocial.Evento> eventos,
        Schemas.eSocial.Empregador empregador,
        Schemas.eSocial.Ambiente ambiente = Schemas.eSocial.Ambiente.Producao,
        VersaoSoap versaoLote = VersaoSoap.v1_1_1)
    {
        //! validações iniciais:
        if (!ValidaCertificado())
#pragma warning disable CA2208 // Instanciar exceções de argumentos corretamente
            throw new ArgumentNullException("Certificado","Nenhum certificado digital foi fornecido para a requisição.");

        if (eventos == null || !eventos.Any())
            throw new ArgumentNullException("Eventos", "Não há nenhum evento no lote de envios da requisição.");

        if (empregador == null)
            throw new ArgumentNullException("Contribuinte", "O empregador responsável pelo envio dos eventos não foi informado.");

        if (eventos.Count > 50)
            throw new ArgumentOutOfRangeException("Eventos", "Favor não ultrapassar o limite de 50 eventos por lote de envio.");
#pragma warning restore CA2208 // Instanciar exceções de argumentos corretamente


        // montando body
        var request = new RequestEnvioLoteEventos
        {
            Versao = versaoLote,
            envioLoteEventos = new()
            {
                ideEmpregador = empregador,
                eventos = []
            }
        };
        XmlDocument xmlBody = new();
        xmlBody.LoadXml(request.Write());


        //! Gera ID's dos eventos,
        //! serializa para XmlDocument,
        //! efetua a assinatura digital e
        //! anexa o evento em xmlBody
        ProcessaXmlEventosEnvio(eventos, xmlBody, versaoLote);
        request = request.Read(xmlBody.OuterXml);
        Logger?.LogDebug($"e-Social Services: Request{Environment.NewLine}{xmlBody.OuterXml}");


        //! execução:
        var result = await ExecuteAsync<SoapClients.EnviarLoteEventosSoapClient, ResponseEnvioLoteEventos>(request, ambiente.ToString());


        if (result == null)
            throw new NullReferenceException("Nenhum retorno foi obtido na requisição");

        var resultString = result.Write();
        Logger?.LogDebug($"e-Social Services: Response{Environment.NewLine}Body: {resultString}");


        return result;
    }


    ///// <summary>
    ///// Efetua a requisição à API REST consulta/lotes do e-Social para consulta de processamento de lote enviado
    ///// </summary>
    ///// <param name="protocolo">Número do protocolo para consulta</param>
    ///// <param name="ambiente">Ambiente de Produção ou Testes</param>
    //public async Task<ResponseEnvioLoteEventos> ConsultaLoteAsync(string protocolo,
    //                                              Schemas.eSocial.Ambiente ambiente = Schemas.eSocial.Ambiente.Producao,
    //                                              VersaoSoap versao = VersaoSoap.v1_1_1)
    //{
    //    //! validações iniciais:
    //    if (!ValidaCertificado())
    //        throw new ArgumentNullException("Certificado", "Nenhum certificado digital foi fornecido para a requisição.");

    //    if (string.IsNullOrEmpty(protocolo))
    //        throw new ArgumentOutOfRangeException("Protocolo", "O Número do Protocolo para consulta não foi devidamente informado.");


    //    //! definindo o Certificado Digitral no HttpClientHandler:
    //    HttpClientHandler.ClientCertificates.Clear();
    //    HttpClientHandler.ClientCertificates.Add(Certificado);


    //    //! definindo o EndPoint conforme ambiente:
    //    HttpClient.BaseAddress = ambiente switch
    //    {
    //        Schemas.eSocial.Ambiente.ProducaoRestrita_DadosReais => new Uri($"http://www.hom.esocial.gov.br/servicos/empregador/lote/eventos/consultar/{versao}"),
    //        _ => new Uri($"http://www.esocial.gov.br/servicos/empregador/lote/eventos/consultar/{versao}")
    //    };


    //    //! post
    //    var post = await HttpClient.GetAsync($"");
    //    var resultString = await post.Content.ReadAsStringAsync();

    //    if (string.IsNullOrEmpty(resultString))
    //        resultString = post.ReasonPhrase;

    //    Logger?.LogDebug($"e-Social Services: POST Response{Environment.NewLine}Status Code: {(int)post.StatusCode}{Environment.NewLine}Result:{Environment.NewLine}{resultString}");
    //    if (post.IsSuccessStatusCode)
    //    {
    //        ResponseEnvioLoteEventos response = new()
    //        {
    //            Versao = versao
    //        };
    //        response = response.Read(resultString);
    //        return response;
    //    }
    //    else
    //    {
    //        Exception ex = (int)post.StatusCode switch
    //        {
    //            401 or 403 => new UnauthorizedAccessException($"A autenticação com o servidor do SPED foi recusada com as credenciais informadas. Detalhes: {resultString}"),
    //            404 => new KeyNotFoundException("Lote não encontrado"),
    //            422 => new XmlSchemaValidationException($"Houveram falhas na validação do conteúdo do(s) evento(s) enviados. Detalhes: {Environment.NewLine} {resultString}"),
    //            495 or 496 => new UnauthorizedAccessException($"O Certificado Digital fornecido não foi aceito pelo servidor. Detalhes: {resultString}"),
    //            _ => new Exception($"Ocorreu uma falha ao enviar o(s) evento(s): {resultString}")
    //        };
    //        throw ex;
    //    }
    //}




    // AUXILIARES

    private void ProcessaXmlEventosEnvio(IEnumerable<Schemas.eSocial.Evento> eventos,
                                         XmlDocument xmlBody,
                                         VersaoSoap versao = VersaoSoap.v1_1_0)
    {
        int contador = 0;
        foreach (var evento in eventos)
        {
            contador++;
            //! gerando ID de evento
            evento.GeraEventoID();


            //! gerando XML e assinando com certificado digital
            XmlDocument xmlEvento = new();
            xmlEvento.LoadXml(evento.Write());
            Certificado.SignXml(xmlEvento, evento.TagToSign, evento.TagId, true);


            //! instanciando estrutura necessária para anexar ao body
            TArquivoEsocial root = new()
            {
                Any = (XElement)Utilities.XML.Operations.ToXElement(xmlEvento.DocumentElement),
                Id = $"ID{contador}",
                Versao = versao
            };
            xmlEvento.LoadXml(root.Write());
            xmlBody.GetElementsByTagName("eventos").Item(0).AppendChild(xmlBody.ImportNode(xmlEvento.DocumentElement, true));

        }
    }
}
