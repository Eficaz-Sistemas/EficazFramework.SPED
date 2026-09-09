namespace EficazFramework.SPED.Documents.NFSe;

/// <summary>
/// Opções de configuração para geração do DANFSE Nacional em PDF.
/// </summary>
public class DanfseOptions
{
    /// <summary>
    /// Imagem do logotipo do prestador (PNG ou JPEG como byte[]). Opcional.
    /// </summary>
    public byte[]? LogoPrestador { get; set; }

    /// <summary>
    /// Quando true, exibe a marca d'água "SEM VALOR FISCAL" no documento.
    /// Aplicado automaticamente quando o ambiente for Homologação.
    /// </summary>
    public bool MostrarMarcaDagua { get; set; } = false;

    /// <summary>
    /// Texto personalizado exibido no rodapé do documento. Opcional.
    /// </summary>
    public string? MensagemRodape { get; set; }
}
