using EficazFramework.SPED.Utilities;

namespace EficazFramework.SPED.Services.Primitives;

/// <summary>
/// Define as regras comumns para todos os serviços da biblioteca.
/// </summary>
internal abstract class ServiceBase
{
    private IcpBrasil_X509Certificate2  _certificado;
    /// <summary>
    /// Certificado digital a ser utilizado nas requests
    /// </summary>
    public IcpBrasil_X509Certificate2 Certificado => _certificado;


    /// <summary>
    /// Função executada para retornar a instância de Certificado Digital que deve ser utilizada nas requests.
    /// É chamada apenas quando <see cref="Certificado"/> é null
    /// </summary>
    public Func<IcpBrasil_X509Certificate2> SelecionaCertificado;


    /// <summary>
    /// Executa a validação da instância de Certificado Digital antes de qualquer requisição.
    /// </summary>
    /// <returns></returns>
    internal bool ValidaCertificado()
    {
        _certificado ??= SelecionaCertificado?.Invoke();
        return _certificado is not null;
    }
}
