namespace EficazFramework.SPED.Documents.CTe;

/// <summary>
/// Opções de configuração para geração do DACTE em PDF.
/// </summary>
public class DacteOptions
{
    /// <summary>
    /// Imagem do logotipo da transportadora (PNG ou JPEG como byte[]). Opcional.
    /// </summary>
    public byte[]? LogoTransportadora { get; set; }

    /// <summary>
    /// Quando true, exibe a marca d'água "SEM VALOR FISCAL" no documento.
    /// Aplicado automaticamente quando o ambiente do protocolo for Homologação.
    /// </summary>
    public bool MostrarMarcaDagua { get; set; } = false;

    /// <summary>
    /// Quando true (padrão), imprime o canhoto de recebimento no topo da primeira folha, como no modelo do DACTE.
    /// </summary>
    public bool ExibirCanhoto { get; set; } = true;

    /// <summary>
    /// Texto personalizado exibido no rodapé do documento. Opcional.
    /// </summary>
    public string? MensagemRodape { get; set; }
}
