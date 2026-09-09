using SchemaNFSe = EficazFramework.SPED.Schemas.NFSe.Nacional.NFSe;
using EficazFramework.SPED.Schemas.NFSe.Nacional;

namespace EficazFramework.SPED.Documents.NFSe;

/// <summary>
/// Métodos de extensão para geração do DANFSE Nacional a partir de <see cref="SchemaNFSe"/>.
/// </summary>
public static class DanfseExtensions
{
    /// <summary>
    /// Gera o DANFSE Nacional em PDF e retorna os bytes resultantes.
    /// </summary>
    public static byte[] GerarDanfse(this SchemaNFSe nfse, DanfseOptions? options = null)
    {
        options ??= new DanfseOptions();
        AplicarMarcaDaguaAutomatica(nfse, options);
        return new DanfseDocument(nfse, options).GeneratePdf();
    }

    /// <summary>
    /// Gera o DANFSE Nacional em PDF e grava no stream fornecido.
    /// </summary>
    public static void GerarDanfse(this SchemaNFSe nfse, Stream destino, DanfseOptions? options = null)
    {
        options ??= new DanfseOptions();
        AplicarMarcaDaguaAutomatica(nfse, options);
        new DanfseDocument(nfse, options).GeneratePdf(destino);
    }

    private static void AplicarMarcaDaguaAutomatica(SchemaNFSe nfse, DanfseOptions options)
    {
        if (nfse.InfNFSe?.DPS?.InfDPS?.Ambiente == Ambiente.Homologacao)
        {
            options.MostrarMarcaDagua = true;
        }
    }
}
