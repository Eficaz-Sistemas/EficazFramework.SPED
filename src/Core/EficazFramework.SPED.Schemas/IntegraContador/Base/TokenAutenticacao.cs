using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador;

/// <summary>
/// Tokens temporários retornados pela autenticação da Loja Serpro (POST /authenticate).
/// </summary>
public sealed class TokenAutenticacao
{
    /// <summary>Token de acesso (Bearer).</summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>Token JWT enviado no cabeçalho <c>jwt_token</c> de cada requisição.</summary>
    [JsonPropertyName("jwt_token")]
    public string? JwtToken { get; set; }

    /// <summary>Validade do token, em segundos.</summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    /// <summary>Escopo do token.</summary>
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    /// <summary>Tipo do token (Bearer).</summary>
    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }

    /// <summary>Momento em que o token foi obtido.</summary>
    [JsonIgnore]
    public DateTimeOffset ObtidoEm { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>Momento em que o token expira (<see cref="ObtidoEm"/> + <see cref="ExpiresIn"/>).</summary>
    [JsonIgnore]
    public DateTimeOffset ExpiraEm => ObtidoEm.AddSeconds(ExpiresIn);

    /// <summary>Indica se o token expira antes de agora mais a margem informada.</summary>
    /// <param name="margem">Antecedência para considerar o token expirado.</param>
    public bool Expirado(TimeSpan margem) => DateTimeOffset.UtcNow.Add(margem) >= ExpiraEm;
}
