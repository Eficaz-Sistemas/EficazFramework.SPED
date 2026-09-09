using EficazFramework.SPED.Schemas.CTe;

namespace EficazFramework.SPED.Documents.CTe;

/// <summary>
/// Métodos de extensão para geração do DACTE a partir de <see cref="ProcessoCTe"/>.
/// </summary>
public static class DacteExtensions
{
    /// <summary>
    /// Gera o DACTE em PDF e retorna os bytes resultantes.
    /// </summary>
    public static byte[] GerarDacte(this ProcessoCTe processo, DacteOptions? options = null)
    {
        options ??= new DacteOptions();
        AplicarMarcaDaguaAutomatica(processo, options);
        return new DacteDocument(processo, options).GeneratePdf();
    }

    /// <summary>
    /// Gera o DACTE em PDF e grava no stream fornecido.
    /// </summary>
    public static void GerarDacte(this ProcessoCTe processo, Stream destino, DacteOptions? options = null)
    {
        options ??= new DacteOptions();
        AplicarMarcaDaguaAutomatica(processo, options);
        new DacteDocument(processo, options).GeneratePdf(destino);
    }

    private static void AplicarMarcaDaguaAutomatica(ProcessoCTe processo, DacteOptions options)
    {
        // CTe reutiliza NFe.Ambiente; o protocolo CTe usa infProt.tpAmb
        if (processo.ProtocoloAutorizacao?.infProt?.tpAmb == Schemas.NFe.Ambiente.Homologacao
            || processo.CTe?.Informacoes?.IdentificacaoOperacao?.Ambiente == Schemas.NFe.Ambiente.Homologacao)
        {
            options.MostrarMarcaDagua = true;
        }
    }
}
