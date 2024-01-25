using EficazFramework.SPED.Interfaces;

namespace EficazFramework.SPED.Services;

internal interface ISoapClient
{
    internal abstract static ISoapClient Create(params string[] args);

    internal Task<ISoapResponse> ExecuteAsync(ISoapRequest request, Utilities.IcpBrasilX509Certificate2 certificate);

}
