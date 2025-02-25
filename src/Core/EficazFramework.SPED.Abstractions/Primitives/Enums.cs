namespace EficazFramework.SPED.Schemas.Primitives;

/// <summary>
/// Código da Finalidade do Arquivo
/// </summary>
public enum Finalidade
{
    /// <summary>
    /// Remessa do Arquivo Original
    /// </summary>
    [System.ComponentModel.Description("Remessa do Arquivo Original")]
    Original = 0,
    /// <summary>
    /// Remessa do Arquivo Substituto
    /// </summary>
    [System.ComponentModel.Description("Remessa do Arquivo Substituto")]
    Substituto = 1
}

/// <summary>
/// Indicador de Tipo de Atividade
/// </summary>
public enum TipoAtividade
{
    /// <summary>
    /// Industrial ou Equiparado a Industrial
    /// </summary>
    [System.ComponentModel.Description("Industrial ou Equiparado a Industrial")]
    Industrial = 0,
    /// <summary>
    /// Outros
    /// </summary>
    [System.ComponentModel.Description("Outros")]
    Outros = 1
}

/// <summary>
/// Indicador de Movimento
/// </summary>
public enum IndicadorMovimento
{
    /// <summary>
    /// Bloco com dados informados
    /// </summary>
    [System.ComponentModel.Description("Bloco com dados informados")]
    ComDados = 0,
    /// <summary>
    /// Bloco sem dados informados
    /// </summary>
    [System.ComponentModel.Description("Bloco sem dados informados")]
    SemDados = 1
}
