using EficazFramework.SPED.Interfaces;
using EficazFramework.SPED.Services.eSocial.Contracts;
using EficazFramework.SPED.Utilities;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EficazFramework.SPED.Services.eSocial.SoapClients;

/// <summary>
/// Cliente SOAP para envio de lotes de eventos para o sistema e-Social.
/// 
/// Esta classe gerencia a comunicação com o serviço de e-Social responsável pelo envio de lotes de eventos,
/// fornecendo métodos para envio síncrono e assíncrono. Suporta múltiplos ambientes (Produção e Produção Restrita).
/// </summary>
/// <remarks>
/// A classe é parcial e estende <see cref="ClientBase{TChannel}"/> para integração com Windows Communication Foundation (WCF).
/// Implementa configuração automática de binding SOAP 1.2 com HTTPS e certificados de cliente.
/// </remarks>
public partial class EnviarLoteEventosSoapClient(Binding binding, EndpointAddress remoteAddress) : ClientBase<IServicoEnviarLoteEventosSoap>(binding, remoteAddress), IServicoEnviarLoteEventosSoap, ISoapClient
{
    /// <summary>
    /// Cria uma instância do cliente SOAP através da interface <see cref="ISoapClient"/>.
    /// </summary>
    /// <param name="args">Array contendo o ambiente desejado como primeiro elemento (ex: "Producao", "ProducaoRestrita_DadosReais").</param>
    /// <returns>Uma instância configurada de <see cref="EnviarLoteEventosSoapClient"/>.</returns>
    /// <remarks>
    /// Em modo DEBUG, adiciona um comportamento de inspeção de mensagens SOAP para facilitar o diagnóstico.
    /// O ambiente é parseado a partir do primeiro argumento fornecido.
    /// </remarks>
    static ISoapClient ISoapClient.Create(params string[] args)
    {
        var client = Create(Enum.Parse<Schemas.eSocial.Ambiente>(args[0]));
#if DEBUG
        client.Endpoint.EndpointBehaviors.Add(new Utilities.WCF.SoapInspectorBehavior());
#endif
        return client;
    }


    /// <summary>
    /// Cria e configura uma instância do cliente para um ambiente específico do e-Social.
    /// </summary>
    /// <param name="ambiente">O ambiente alvo (padrão: Produção). Pode ser Produção ou Produção Restrita com Dados Reais.</param>
    /// <returns>Uma instância totalmente configurada de <see cref="EnviarLoteEventosSoapClient"/>.</returns>
    /// <remarks>
    /// Para o ambiente "ProducaoRestrita_DadosReais", desativa a validação de certificado SSL.
    /// A configuração de binding e URL é realizada automaticamente conforme o ambiente.
    /// </remarks>
    public static EnviarLoteEventosSoapClient Create(Schemas.eSocial.Ambiente ambiente = Schemas.eSocial.Ambiente.Producao)
    {
        EnviarLoteEventosSoapClient client = new(ConfigureBinding(), new(ConfigureUrl(ambiente)));

        if (ambiente == Schemas.eSocial.Ambiente.ProducaoRestrita_DadosReais)
            client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new()
            {
                CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None
            };

        return client;
    }


    /// Envia um lote de eventos de forma síncrona para o servidor e-Social.
    /// </summary>
    /// <param name="request">A requisição contendo os eventos a serem processados.</param>
    /// <returns>A resposta do servidor com o resultado do processamento.</returns>
    /// <exception cref="System.ServiceModel.FaultException">Lançada quando ocorre erro na comunicação ou validação do servidor.</exception>
    ResponseEnvioLoteEventos IServicoEnviarLoteEventosSoap.EnviarLoteEventos(RequestEnvioLoteEventos request) =>
        Channel.EnviarLoteEventos(request);


    /// <summary>
    /// Envia um lote de eventos de forma assíncrona para o servidor e-Social.
    /// </summary>
    /// <param name="request">A requisição contendo os eventos a serem processados.</param>
    /// <returns>Uma tarefa que retorna a resposta do servidor com o resultado do processamento.</returns>
    /// <remarks>
    /// Este método é recomendado para aplicações de alta performance ou que processam múltiplos lotes simultaneamente.
    /// </remarks>
    async Task<ResponseEnvioLoteEventos> IServicoEnviarLoteEventosSoap.EnviarLoteEventosAsync(RequestEnvioLoteEventos request) =>
        await Channel.EnviarLoteEventosAsync(request);


    /// <summary>
    /// Executa uma requisição genérica do SOAP com certificado de autenticação.
    /// </summary>
    /// <typeparam name="TMessage">O tipo de mensagem esperada na resposta.</typeparam>
    /// <param name="request">A requisição SOAP a ser enviada.</param>
    /// <param name="certificate">O certificado X.509 para autenticação ICP-Brasil.</param>
    /// <returns>Uma tarefa contendo a resposta SOAP encapsulada.</returns>
    /// <exception cref="NotImplementedException">Este método não está implementado nesta versão do cliente.</exception>
    /// <remarks>
    /// Esta implementação é reservada para extensões futuras e fornece um ponto para integração de autenticação por certificado.
    /// </remarks>
    async Task<ISoapResponse<TMessage>> ISoapClient.ExecuteAsync<TMessage>(ISoapRequest request, IcpBrasilX509Certificate2 certificate)
    {
        ClientCredentials.ClientCertificate.Certificate = certificate.PrivateInstance;
        ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new()
        {
            CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None
        };
        return (ISoapResponse<TMessage>)await Channel.EnviarLoteEventosAsync(request as RequestEnvioLoteEventos);
    }


    /// <summary>
    /// Configura o binding SOAP 1.2 com HTTPS para comunicação segura com o servidor e-Social.
    /// </summary>
    /// <returns>Um <see cref="CustomBinding"/> configurado com as especificações necessárias.</returns>
    /// <remarks>
    /// Utiliza SOAP 1.1 sem suporte a WS-Addressing, requer certificado de cliente e limita o tamanho da mensagem recebida a 64KB.
    /// </remarks>
    private static Binding ConfigureBinding()
    {
        var binding = new CustomBinding
        {
            Name = "ServicoEnviarLoteEventos",
        };
        binding.Elements.Add(new TextMessageEncodingBindingElement
        {
            MessageVersion = MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap11, AddressingVersion.None),
        });
        binding.Elements.Add((BindingElement)new HttpsTransportBindingElement
        {
            RequireClientCertificate = true,
            MaxReceivedMessageSize = 65536,
        });
        return binding;
    }


    /// <summary>
    /// Determina a URL do servidor e-Social conforme o ambiente alvo.
    /// </summary>
    /// <param name="ambiente">O ambiente desejado (padrão: Produção).</param>
    /// <returns>A URL base do serviço e-Social para o ambiente especificado.</returns>
    /// <remarks>
    /// - Produção: http://www.esocial.gov.br/schema/lote/eventos/envio/v1_1_1
    /// - Produção Restrita (Dados Reais): http://www.hom.esocial.gov.br/schema/lote/eventos/envio/v1_1_1
    /// Ambientes não reconhecidos retornam uma string vazia.
    /// </remarks>
    private static string ConfigureUrl(Schemas.eSocial.Ambiente ambiente = Schemas.eSocial.Ambiente.Producao)
        => ambiente switch
        {
            Schemas.eSocial.Ambiente.Producao => "https://webservices.esocial.gov.br/servicos/empregador/enviarloteeventos/WsEnviarLoteEventos.svc",
            Schemas.eSocial.Ambiente.ProducaoRestrita_DadosReais => "https://webservices.producaorestrita.esocial.gov.br/servicos/empregador/enviarloteeventos/WsEnviarLoteEventos.svc",
            _ => ""
        };
}
