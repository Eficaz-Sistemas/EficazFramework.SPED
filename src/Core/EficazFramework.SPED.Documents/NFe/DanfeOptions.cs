namespace EficazFramework.SPED.Documents.NFe;

/// <summary>
/// Opções de configuração para geração do DANFE em PDF.
/// </summary>
public class DanfeOptions
{
    /// <summary>
    /// Imagem do logotipo do emitente (PNG ou JPEG como byte[]). Opcional.
    /// Se não fornecida, será usada a propriedade <c>Emitente.Logo</c> do próprio schema.
    /// </summary>
    public byte[]? LogoEmitente { get; set; }

    /// <summary>
    /// Quando true, exibe a marca d'água "SEM VALOR FISCAL" no documento.
    /// Aplicado automaticamente quando o ambiente do protocolo for Homologação.
    /// </summary>
    public bool MostrarMarcaDagua { get; set; } = false;

    /// <summary>
    /// Texto personalizado exibido no rodapé do documento. Opcional.
    /// </summary>
    public string? MensagemRodape { get; set; }
}
