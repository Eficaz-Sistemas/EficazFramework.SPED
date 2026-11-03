using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraProcuracoes;

/// <summary>
/// Entrada do serviço OBTERPROCURACAO41 (PROCURACOES): procurações eletrônicas entre um outorgante e seu procurador.
/// </summary>
public sealed class ObterProcuracao
{
    /// <summary>CPF (11) ou CNPJ (14) do outorgante, somente números.</summary>
    [JsonPropertyName("outorgante")]
    public string Outorgante { get; set; } = string.Empty;

    /// <summary>Tipo do outorgante: "1" - CPF; "2" - CNPJ.</summary>
    [JsonPropertyName("tipoOutorgante")]
    public string TipoOutorgante { get; set; } = string.Empty;

    /// <summary>CPF (11) ou CNPJ (14) do outorgado (procurador), somente números.</summary>
    [JsonPropertyName("outorgado")]
    public string Outorgado { get; set; } = string.Empty;

    /// <summary>Tipo do outorgado: "1" - CPF; "2" - CNPJ.</summary>
    [JsonPropertyName("tipoOutorgado")]
    public string TipoOutorgado { get; set; } = string.Empty;

    /// <summary>
    /// Cria a entrada a partir das identificações do outorgante e do outorgado.
    /// </summary>
    /// <param name="outorgante">Outorgante (titular).</param>
    /// <param name="outorgado">Outorgado (procurador).</param>
    public static ObterProcuracao Criar(Identificacao outorgante, Identificacao outorgado) => new()
    {
        Outorgante = outorgante.Numero,
        TipoOutorgante = ((int)outorgante.Tipo).ToString(System.Globalization.CultureInfo.InvariantCulture),
        Outorgado = outorgado.Numero,
        TipoOutorgado = ((int)outorgado.Tipo).ToString(System.Globalization.CultureInfo.InvariantCulture)
    };
}

/// <summary>
/// Retorno do serviço OBTERPROCURACAO41 (PROCURACOES): procuração eletrônica encontrada.
/// </summary>
public sealed class Procuracao
{
    /// <summary>Data de expiração no formato AAAAMMDD.</summary>
    [JsonPropertyName("dtexpiracao")]
    public string? DtExpiracao { get; set; }

    /// <summary>Quantidade de sistemas contidos na lista.</summary>
    [JsonPropertyName("nrsistemas")]
    public int? NrSistemas { get; set; }

    /// <summary>Sistemas contidos na procuração.</summary>
    [JsonPropertyName("sistemas")]
    public List<string>? Sistemas { get; set; }
}
