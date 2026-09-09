using EficazFramework.SPED.Schemas.NFe;

namespace EficazFramework.SPED.Documents.NFe;

/// <summary>
/// Métodos de extensão para geração do DANFE a partir de <see cref="ProcessoNFe"/>.
/// </summary>
public static class DanfeExtensions
{
    /// <summary>
    /// Gera o DANFE em PDF e retorna os bytes resultantes.
    /// A orientação (retrato/paisagem/simplificado) é determinada automaticamente pelo campo
    /// <c>IdentificacaoOperacao.TipoImpressao</c> da NF-e.
    /// </summary>
    public static byte[] GerarDanfe(this ProcessoNFe processo, DanfeOptions? options = null)
    {
        options ??= new DanfeOptions();
        AplicarMarcaDaguaAutomatica(processo, options);
        return new DanfeDocument(processo, options).GeneratePdf();
    }

    /// <summary>
    /// Gera o DANFE em PDF e grava no stream fornecido.
    /// </summary>
    public static void GerarDanfe(this ProcessoNFe processo, Stream destino, DanfeOptions? options = null)
    {
        options ??= new DanfeOptions();
        AplicarMarcaDaguaAutomatica(processo, options);
        new DanfeDocument(processo, options).GeneratePdf(destino);
    }

    private static void AplicarMarcaDaguaAutomatica(ProcessoNFe processo, DanfeOptions options)
    {
        if (processo.ProtocoloAutorizacao?.InformacoesProtocolo?.Ambiente == Ambiente.Homologacao
            || processo.NFe?.InformacoesNFe?.IdentificacaoOperacao?.Ambiente == Ambiente.Homologacao)
        {
            options.MostrarMarcaDagua = true;
        }
    }
}
