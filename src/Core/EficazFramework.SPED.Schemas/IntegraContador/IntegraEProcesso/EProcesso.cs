using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraEProcesso;

/// <summary>
/// Retorno do serviço CONSPROCPORINTER271 (EPROCESSO): processo em que o contribuinte é interessado.
/// </summary>
public sealed class Processo
{
    /// <summary>Número do processo.</summary>
    [JsonPropertyName("numeroDoProcesso")]
    public string? NumeroDoProcesso { get; set; }

    /// <summary>Tipo de relação do interessado com o processo.</summary>
    [JsonPropertyName("relacaoDoInteressadoComOProcesso")]
    public string? RelacaoDoInteressadoComOProcesso { get; set; }

    /// <summary>Data de protocolo do processo no formato DD/MM/AAAA.</summary>
    [JsonPropertyName("dataDeProtocolo")]
    public string? DataDeProtocolo { get; set; }

    /// <summary>Tipo do processo.</summary>
    [JsonPropertyName("tipoDoProcesso")]
    public string? TipoDoProcesso { get; set; }

    /// <summary>Subtipo do processo.</summary>
    [JsonPropertyName("subtipoDoProcesso")]
    public string? SubtipoDoProcesso { get; set; }

    /// <summary>Localização do processo.</summary>
    [JsonPropertyName("localizacao")]
    public string? Localizacao { get; set; }

    /// <summary>Situação do processo.</summary>
    [JsonPropertyName("situacao")]
    public string? Situacao { get; set; }

    /// <summary>Último encaminhamento externo do processo.</summary>
    [JsonPropertyName("ultimoEncaminhamentoExterno")]
    public string? UltimoEncaminhamentoExterno { get; set; }
}
