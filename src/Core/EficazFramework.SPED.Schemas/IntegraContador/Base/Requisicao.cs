using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador;

/// <summary>
/// Identificação (NI) de contratante, autor do pedido de dados ou contribuinte.
/// </summary>
/// <param name="Numero">CPF ou CNPJ, somente números (ou lista separada por vírgula nos tipos de lote).</param>
/// <param name="Tipo">Tipo do número de identificação.</param>
public sealed record Identificacao(
    [property: JsonPropertyName("numero")] string Numero,
    [property: JsonPropertyName("tipo")] TipoIdentificacao Tipo)
{
    /// <summary>Identificação por CPF.</summary>
    public static Identificacao Cpf(string numero) => new(numero, TipoIdentificacao.CPF);

    /// <summary>Identificação por CNPJ.</summary>
    public static Identificacao Cnpj(string numero) => new(numero, TipoIdentificacao.CNPJ);
}

/// <summary>
/// Dados do pedido: serviço solicitado e o conteúdo de entrada, serializado como string JSON.
/// </summary>
public sealed class PedidoDados
{
    /// <summary>Identificador do sistema (ex.: PGDASD, PGMEI, DCTFWEB).</summary>
    [JsonPropertyName("idSistema")]
    public string IdSistema { get; set; } = string.Empty;

    /// <summary>Identificador do serviço (ex.: GERARDAS12).</summary>
    [JsonPropertyName("idServico")]
    public string IdServico { get; set; } = string.Empty;

    /// <summary>Versão do sistema (ex.: 1.0).</summary>
    [JsonPropertyName("versaoSistema")]
    public string? VersaoSistema { get; set; }

    /// <summary>Dados de entrada do serviço, como string JSON (vazio quando o serviço não tem entrada).</summary>
    [JsonPropertyName("dados")]
    public string Dados { get; set; } = string.Empty;
}

/// <summary>
/// Corpo da requisição (DadosEntrada) comum a todos os endpoints da API Integra Contador.
/// </summary>
public sealed class RequisicaoIntegraContador
{
    /// <summary>Contratante do produto na Loja Serpro (sempre CNPJ, o mesmo do certificado digital).</summary>
    [JsonPropertyName("contratante")]
    public Identificacao Contratante { get; set; } = null!;

    /// <summary>Autor do pedido de dados: o próprio contratante ou o procurador do contribuinte.</summary>
    [JsonPropertyName("autorPedidoDados")]
    public Identificacao AutorPedidoDados { get; set; } = null!;

    /// <summary>Contribuinte a que se referem os dados.</summary>
    [JsonPropertyName("contribuinte")]
    public Identificacao Contribuinte { get; set; } = null!;

    /// <summary>Serviço solicitado e dados de entrada.</summary>
    [JsonPropertyName("pedidoDados")]
    public PedidoDados PedidoDados { get; set; } = new();
}
