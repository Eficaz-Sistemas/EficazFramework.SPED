using SchemaNFSe = EficazFramework.SPED.Schemas.NFSe.Nacional.NFSe;

namespace EficazFramework.SPED.Documents.NFSe;

/// <summary>
/// Geração do DANFSe v2.0 (NT 008 SE/CGNFS-e) a partir de <see cref="SchemaNFSe"/>.
/// </summary>
/// <remarks>
/// A API nacional de DANFSe foi desativada: a geração do documento auxiliar passou a ser responsabilidade do emissor.
/// </remarks>
public static class DanfseExtensions
{
    /// <summary>
    /// Gera o DANFSe em PDF.
    /// </summary>
    /// <param name="nfse">NFS-e autorizada.</param>
    /// <param name="options">Opções de geração.</param>
    /// <returns>Bytes do PDF.</returns>
    public static byte[] GerarDanfse(this SchemaNFSe nfse, DanfseOptions? options = null) =>
        new DanfseDocument(nfse, options).GeneratePdf();

    /// <summary>
    /// Gera o DANFSe em PDF e grava no stream informado.
    /// </summary>
    /// <param name="nfse">NFS-e autorizada.</param>
    /// <param name="destino">Stream de destino.</param>
    /// <param name="options">Opções de geração.</param>
    public static void GerarDanfse(this SchemaNFSe nfse, Stream destino, DanfseOptions? options = null) =>
        new DanfseDocument(nfse, options).GeneratePdf(destino);

    /// <summary>
    /// Gera o DANFSe em PDF a partir do XML da NFS-e autorizada (como devolvido pelo ADN).
    /// </summary>
    /// <param name="xmlNfse">XML da NFS-e (elemento raiz <c>NFSe</c>).</param>
    /// <param name="options">Opções de geração.</param>
    /// <returns>Bytes do PDF.</returns>
    /// <exception cref="ArgumentException">XML vazio.</exception>
    /// <exception cref="InvalidOperationException">O XML não é uma NFS-e Nacional válida.</exception>
    public static byte[] GerarDanfse(string xmlNfse, DanfseOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(xmlNfse))
            throw new ArgumentException("O XML da NFS-e não foi informado.", nameof(xmlNfse));

        return SchemaNFSe.Deserialize(xmlNfse).GerarDanfse(options);
    }
}
