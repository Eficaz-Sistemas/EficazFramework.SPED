using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraCaixaPostal;

/// <summary>
/// Indicador de enquadramento do NI no DTE (Domicílio Tributário Eletrônico).
/// </summary>
public enum IndicadorEnquadramentoDte
{
    /// <summary>-2 - NI inválido.</summary>
    NiInvalido = -2,
    /// <summary>-1 - NI não optante.</summary>
    NaoOptante = -1,
    /// <summary>0 - NI optante DTE.</summary>
    OptanteDte = 0,
    /// <summary>1 - NI optante Simples.</summary>
    OptanteSimples = 1,
    /// <summary>2 - NI optante DTE e Simples.</summary>
    OptanteDteESimples = 2
}

/// <summary>
/// Retorno do serviço CONSULTASITUACAODTE111: situação do contribuinte quanto à adesão ao DTE
/// (Caixa Postal do Simples Nacional e e-CAC).
/// </summary>
public sealed class RetornoSituacaoDte
{
    /// <summary>
    /// Indicador de enquadramento do NI consultado: <br/>
    /// -2 - NI inválido <br/>
    /// -1 - NI não optante <br/>
    /// 0 - NI optante DTE <br/>
    /// 1 - NI optante Simples <br/>
    /// 2 - NI optante DTE e Simples <br/>
    /// </summary>
    [JsonPropertyName("indicadorEnquadramento")]
    [JsonConverter(typeof(EnumNumericoCaixaPostalJsonConverter))]
    public IndicadorEnquadramentoDte? IndicadorEnquadramento { get; set; }

    /// <summary>Texto do status de enquadramento do NI consultado.</summary>
    [JsonPropertyName("statusEnquadramento")]
    public string? StatusEnquadramento { get; set; }
}
