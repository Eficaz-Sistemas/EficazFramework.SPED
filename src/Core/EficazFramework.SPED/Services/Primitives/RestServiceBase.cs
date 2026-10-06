using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace EficazFramework.SPED.Services.Primitives;

#nullable enable

/// <summary>
/// Base dos serviços REST (NFS-e Nacional, EFD-Reinf): um único <see cref="System.Net.Http.HttpClient"/> por instância,
/// criado na primeira requisição com o certificado digital (mTLS) e reutilizado nas seguintes.
/// </summary>
/// <remarks>
/// <para>O cliente não tem <c>BaseAddress</c>: cada requisição usa a URL completa do ambiente (produção, homologação,
/// distribuição), então a mesma instância atende a qualquer ambiente e endpoint. Cabeçalhos são definidos por requisição.</para>
/// <para>O certificado é lido uma vez (<see cref="ServiceBase.ValidaCertificado"/>); para usar outro certificado, crie outra instância.</para>
/// <para>Descarte a instância (<see cref="Dispose()"/>) ao terminar para liberar as conexões.</para>
/// </remarks>
public abstract class RestServiceBase : ServiceBase, IDisposable
{
    private readonly HttpMessageHandler? _handlerExterno;
    private readonly object _trava = new();
    private HttpClient? _httpClient;
    private bool _descartado;

    /// <summary>Cria o serviço; o cliente HTTP (com o certificado) é criado na primeira requisição.</summary>
    protected RestServiceBase() { }

    /// <summary>
    /// Cria o serviço com um handler próprio (testes, proxy). O handler não é descartado pelo serviço
    /// e o certificado não é anexado a ele.
    /// </summary>
    /// <param name="handler">Handler usado pelo cliente HTTP.</param>
    protected RestServiceBase(HttpMessageHandler handler)
    {
        _handlerExterno = handler ?? throw new ArgumentNullException(nameof(handler));
    }

    /// <summary>Tempo máximo de cada requisição (padrão 100 s). Só vale se definido antes da primeira requisição.</summary>
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(100);

    /// <summary>
    /// Cliente HTTP do serviço: na primeira chamada valida o certificado e cria o cliente com ele (mTLS).
    /// </summary>
    /// <exception cref="ArgumentNullException">Nenhum certificado digital ICP-Brasil foi fornecido.</exception>
    /// <exception cref="ObjectDisposedException">O serviço já foi descartado.</exception>
    protected HttpClient ObterHttpClient()
    {
        ObjectDisposedException.ThrowIf(_descartado, this);

        if (_httpClient is not null)
            return _httpClient;

        lock (_trava)
        {
            ObjectDisposedException.ThrowIf(_descartado, this);
            if (_httpClient is not null)
                return _httpClient;

            if (!ValidaCertificado())
                throw new ArgumentNullException(nameof(Certificado), "Nenhum certificado digital ICP-Brasil válido foi fornecido para a requisição.");

            _httpClient = _handlerExterno is null
                ? new HttpClient(CriarHandler(), disposeHandler: true) { Timeout = Timeout }
                : new HttpClient(_handlerExterno, disposeHandler: false) { Timeout = Timeout };
            return _httpClient;
        }
    }

    /// <summary>
    /// Handler com o certificado do cliente (mTLS). Usa <see cref="Utilities.IcpBrasilX509Certificate2.PrivateInstance"/>,
    /// a instância com a chave privada (necessária quando o certificado vem do repositório do sistema).
    /// </summary>
    protected virtual HttpMessageHandler CriarHandler()
    {
        var handler = new SocketsHttpHandler
        {
            // Renova as conexões periodicamente (mudança de DNS dos servidores do governo).
            PooledConnectionLifetime = TimeSpan.FromMinutes(5)
        };
        handler.SslOptions.ClientCertificates = new X509CertificateCollection { Certificado.PrivateInstance ?? Certificado };
        return handler;
    }

    /// <summary>Libera o cliente HTTP e as conexões.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Libera o cliente HTTP e as conexões.</summary>
    /// <param name="disposing"><see langword="true"/> quando chamado por <see cref="Dispose()"/>.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (_descartado)
            return;

        _descartado = true;
        if (disposing)
            _httpClient?.Dispose();
        _httpClient = null;
    }
}
