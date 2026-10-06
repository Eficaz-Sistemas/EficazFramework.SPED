using EficazFramework.SPED.Interfaces;
using Microsoft.Extensions.Logging;
using System.ServiceModel;

namespace EficazFramework.SPED.Services.Primitives;

/// <summary>
/// Base dos serviços SOAP (NF-e, CT-e, eSocial): um cliente WCF por chamada, sempre fechado ao final.
/// </summary>
public class SoapServiceBase : ServiceBase 
{
    /// <summary>
    /// Cria o cliente WCF, executa a requisição com o certificado e fecha o canal: <c>Close</c> no sucesso,
    /// <c>Abort</c> em falha (ou se o <c>Close</c> falhar), para não deixar canais e conexões abertos.
    /// </summary>
    internal async Task<TResult> ExecuteAsync<TClient, TResult>(ISoapRequest request, params string[] args) 
        where TClient : ISoapClient
        where TResult : class
    {
        ISoapClient client = TClient.Create(args);
        try
        {
            var svcresult = await client.ExecuteAsync<TResult>(request, Certificado);
            await FecharAsync(client);
            return svcresult.UnWrap();
        }
        catch
        {
            Abortar(client);
            throw;
        }
    }

    /// <summary>Fecha o canal; se estiver em falha ou o fechamento falhar, aborta.</summary>
    private async Task FecharAsync(ISoapClient client)
    {
        if (client is not ICommunicationObject canal)
            return;

        if (canal.State == CommunicationState.Faulted)
        {
            canal.Abort();
            return;
        }

        try
        {
            await Task.Factory.FromAsync(canal.BeginClose, canal.EndClose, null);
        }
        catch (Exception ex) when (ex is CommunicationException or TimeoutException)
        {
            Logger?.LogDebug(ex, "Falha ao fechar o canal SOAP; canal abortado.");
            canal.Abort();
        }
    }

    /// <summary>Aborta o canal (libera a conexão imediatamente, sem lançar exceções).</summary>
    private static void Abortar(ISoapClient client)
    {
        if (client is ICommunicationObject canal && canal.State != CommunicationState.Closed)
            canal.Abort();
    }
}
