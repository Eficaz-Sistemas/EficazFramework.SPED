namespace EficazFramework.SPED.Documents.NFSe;

/// <summary>
/// Situação da NFS-e exibida no DANFSe por marca d'água (NT 008, Anexo I).
/// </summary>
public enum SituacaoDanfse
{
    /// <summary>Sem marca d'água.</summary>
    Normal = 0,
    /// <summary>Marca d'água diagonal "CANCELADA".</summary>
    Cancelada = 1,
    /// <summary>Marca d'água diagonal "SUBSTITUÍDA".</summary>
    Substituida = 2
}

/// <summary>
/// Opções de geração do DANFSe v2.0 (NT 008 SE/CGNFS-e).
/// </summary>
public class DanfseOptions
{
    /// <summary>
    /// Logotipo oficial da NFS-e (PNG ou JPEG), exibido no canto esquerdo do cabeçalho (0,85 x 4,00 cm).
    /// Opcional: sem ele, o espaço fica em branco.
    /// </summary>
    public byte[]? LogoNfse { get; set; }

    /// <summary>
    /// Situação da NFS-e para a marca d'água. O XML autorizado não informa eventos posteriores
    /// (cancelamento/substituição): quem gera o DANFSe informa a situação conhecida.
    /// </summary>
    public SituacaoDanfse Situacao { get; set; } = SituacaoDanfse.Normal;

    /// <summary>Exibe o canhoto (opcional na NT) ao final da página.</summary>
    public bool ExibirCanhoto { get; set; }

    /// <summary>Exibe os e-mails das partes (a NT permite suprimi-los).</summary>
    public bool ExibirEmails { get; set; } = true;

    /// <summary>
    /// Resolve o nome do município pelo código IBGE (7 dígitos). O XML da NFS-e só traz o nome dos municípios de
    /// emissão, prestação e incidência; para o endereço das partes, sem este resolvedor, só a UF é exibida.
    /// </summary>
    public Func<string, string?>? NomeMunicipio { get; set; }
}
