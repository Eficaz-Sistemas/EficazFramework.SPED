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
    /// Quando true, imprime o canhoto de recebimento no topo da primeira folha (facultativo na NT 2026.010).
    /// </summary>
    public bool ExibirCanhoto { get; set; } = false;

    /// <summary>
    /// Quando true, imprime sempre os quadros facultativos do leiaute da NT 2026.010 (destacados em azul),
    /// ainda que sem dados no XML. Quando false (padrão), são suprimidos se o XML não os informar. O quadro de ISSQN e as linhas
    /// facultativas do Total do ICMS/IPI aparecem somente quando o XML as informa, independentemente desta opção.
    /// </summary>
    public bool ExibirQuadrosFacultativos { get; set; } = false;

    /// <summary>
    /// Texto personalizado exibido no rodapé do documento. Opcional.
    /// </summary>
    public Action<IContainer>? MensagemRodape { get; set; }
}
