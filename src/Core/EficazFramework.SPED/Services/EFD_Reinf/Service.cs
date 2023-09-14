using EficazFramework.SPED.Services.Primitives;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Xml;
using System.Xml.Schema;

namespace EficazFramework.SPED.Services.EFD_Reinf;
public class EfdReinfServices : RestServiceBase
{
    public EfdReinfServices() : base(true) { }


    /// <summary>
    /// Efetua a requisição à API REST recepcao/lotes da EFD-REINF para transmissão do lote de eventos
    /// </summary>
    /// <param name="eventos">Lote de Eventos a serem transmitidos. Respeitar o limite de 50 eventos por lote</param>
    /// <param name="contribuinte">Identificação do Contribuinte</param>
    /// <param name="ambiente">Ambiente de Produção ou Testes</param>
    /// <param name="versao">Versão do Serviço REST</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<object> EnviaEventosAsync(IList<Schemas.EFD_Reinf.Evento> eventos,
                                                Schemas.EFD_Reinf.IdentificacaoContribuinte contribuinte,
                                                Schemas.EFD_Reinf.Ambiente ambiente = Schemas.EFD_Reinf.Ambiente.Producao,
                                                VersaoRest versao = VersaoRest.v1_00_00)
    {
        //! validações iniciais:
        if (!ValidaCertificado())
            throw new ArgumentNullException("Certificado","Nenhum certificado digital foi fornecido para a requisição.");

        if (eventos == null || eventos.Any())
            throw new ArgumentNullException("Eventos", "Não há nenhum evento no lote de envios da requisição.");

        if (contribuinte == null)
            throw new ArgumentNullException("Contribuinte", "O contribuinte responsável pelo envio dos eventos não foi informado.");

        if (eventos.Count > 50)
            throw new ArgumentOutOfRangeException("Eventos", "Favor não ultrapassar o limite de 50 eventos por lote de envio.");


        //! definindo o Certificado Digitral no HttpClientHandler:
        HttpClientHandler.ClientCertificates.Clear();
        HttpClientHandler.ClientCertificates.Add(Certificado);


        //! definindo o EndPoint conforme ambiente:
        HttpClient.BaseAddress = ambiente switch
        {
            Schemas.EFD_Reinf.Ambiente.ProducaoRestrita_DadosReais => new Uri("https://pre-reinf.receita.economia.gov.br/"),
            _ => new Uri("https://reinf.receita.economia.gov.br/")
        };


        //! definindo o body da request
        XmlDocument xmlBody = new();
        xmlBody.LoadXml(new Body
        {
            Versao = versao,
            envioLoteEventos = new()
            {
                ideContribuinte = contribuinte,
                eventos = new()
            }
        }.Write(BodySchemaName.envioLoteEventosAssincrono));


        //! Gera ID's dos eventos,
        //! serializa para XmlDocument,
        //! efetua a assinatura digital e
        //! anexa o evento em xmlBody
        ProcessaXmlEventosEnvio(eventos, xmlBody, versao);
        Logger?.LogDebug($"EFD Reinf Services: POST Request {Environment.NewLine}{xmlBody.OuterXml}");


        //! post
        var post = await HttpClient.PostAsync("recepcao/lotes", new StringContent(xmlBody.OuterXml, Encoding.UTF8, "application/xml"));
        var resultString = await post.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(resultString))
            resultString = post.ReasonPhrase;


        Logger?.LogDebug($"EFD Reinf Services: POST Response{Environment.NewLine}Status Code: {(int)post.StatusCode}{Environment.NewLine}Result:{Environment.NewLine}{resultString}");
        if (post.IsSuccessStatusCode)
        {
            Body response = new()
            {
                Versao = versao
            };
            response.Read(resultString, BodySchemaName.retornoLoteEventosAssincrono);

            //? desserializando a correta instância de retorno entre R-9001, R-9005, R-9011 e R-9015
            for (int i = 0; i < response.retornoLoteEventosAssincrono.retornoEventos.evento.Length; i++)
                response.retornoLoteEventosAssincrono.retornoEventos.evento[i].ParseXml(eventos[i].Versao);

            return response;
        }
        else
        {
            Exception ex = (int)post.StatusCode switch
            {
                401 | 403 => new UnauthorizedAccessException($"A autenticação com o servidor do SPED foi recusada com as credenciais informadas. Detalhes: {resultString}"),
                415 | 422 => new XmlSchemaValidationException($"Houveram falhas na validação do conteúdo do(s) evento(s) enviados. Detalhes: {Environment.NewLine} {resultString}"),
                _ => new Exception($"Ocorreu uma falha ao enviar o(s) evento(s): {resultString}")
            };
            throw ex;
        }
    }






    // AUXILIARES

    private void ProcessaXmlEventosEnvio(IEnumerable<Schemas.EFD_Reinf.Evento> eventos,
                                         XmlDocument xmlBody,
                                         VersaoRest versao = VersaoRest.v1_00_00)
    {
        int contador = 0;
        foreach (var evento in eventos)
        {
            contador++;
            //! gerando ID de evento
            evento.GeraEventoID();


            //! gerando XML e assinando com certificado digital
            XmlDocument xmlEvento = new();
            xmlEvento.Load(evento.Write());
            Certificado.SignXml(xmlEvento, "Reinf", evento.TagToSign, true);


            //! instanciando estrutura necessária para anexar ao body
            ConteudoReinf root = new()
            {
                Any = (XElement)Utilities.XML.Operations.ToXElement(xmlEvento.DocumentElement),
                Id = $"ID{contador}",
                Versao = versao
            };
            xmlEvento.Load(root.Write());
            xmlBody.GetElementsByTagName("eventos").Item(0).AppendChild(xmlBody.ImportNode(xmlEvento.DocumentElement, true));

        }
    }
}
