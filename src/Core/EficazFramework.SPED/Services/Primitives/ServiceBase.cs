using EficazFramework.SPED.Utilities;
using Microsoft.Extensions.Logging;

namespace EficazFramework.SPED.Services.Primitives;

/// <summary>
/// Define as regras comumns para todos os serviços da biblioteca.
/// </summary>
public abstract class ServiceBase
{
    private IcpBrasilX509Certificate2  _certificado;
    /// <summary>
    /// Certificado digital a ser utilizado nas requests
    /// </summary>
    public IcpBrasilX509Certificate2 Certificado => _certificado;


    /// <summary>
    /// Função executada para retornar a instância de Certificado Digital que deve ser utilizada nas requests.
    /// É chamada apenas quando <see cref="Certificado"/> é null
    /// </summary>
    public Func<IcpBrasilX509Certificate2> SelecionaCertificado;


    /// <summary>
    /// Executa a validação da instância de Certificado Digital antes de qualquer requisição.
    /// </summary>
    /// <returns></returns>
    public bool ValidaCertificado()
    {
        _certificado ??= SelecionaCertificado?.Invoke();
        return _certificado is not null;
    }


    public ILogger Logger { get; set; }
}
