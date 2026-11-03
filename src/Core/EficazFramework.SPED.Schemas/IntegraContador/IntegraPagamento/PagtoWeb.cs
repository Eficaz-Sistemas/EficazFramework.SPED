using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraPagamento;

// ENTRADAS

/// <summary>
/// Intervalo de datas da pesquisa (formato AAAA-MM-DD).
/// </summary>
public sealed class IntervaloData
{
    /// <summary>Data inicial.</summary>
    [JsonPropertyName("dataInicial")]
    public DateOnly? DataInicial { get; set; }

    /// <summary>Data final.</summary>
    [JsonPropertyName("dataFinal")]
    public DateOnly? DataFinal { get; set; }
}

/// <summary>
/// Intervalo de valores da pesquisa.
/// </summary>
public sealed class IntervaloValor
{
    /// <summary>Valor inicial.</summary>
    [JsonPropertyName("valorInicial")]
    public decimal? ValorInicial { get; set; }

    /// <summary>Valor final.</summary>
    [JsonPropertyName("valorFinal")]
    public decimal? ValorFinal { get; set; }
}

/// <summary>
/// Filtros da pesquisa de documentos de arrecadação pagos, usados no serviço CONTACONSDOCARRPG73 (contagem).
/// Os filtros podem ser combinados e sempre se referem ao contribuinte da requisição.
/// </summary>
public class FiltroPagamentos
{
    /// <summary>Números dos documentos de arrecadação (até 17 posições cada).</summary>
    [JsonPropertyName("numeroDocumentoLista")]
    public List<string>? NumeroDocumentoLista { get; set; }

    /// <summary>Códigos de receita (até 4 posições cada).</summary>
    [JsonPropertyName("codigoReceitaLista")]
    public List<string>? CodigoReceitaLista { get; set; }

    /// <summary>Intervalo da data de arrecadação (data contábil da efetivação do pagamento).</summary>
    [JsonPropertyName("intervaloDataArrecadacao")]
    public IntervaloData? IntervaloDataArrecadacao { get; set; }

    /// <summary>Intervalo do valor total do documento.</summary>
    [JsonPropertyName("intervaloValorTotalDocumento")]
    public IntervaloValor? IntervaloValorTotalDocumento { get; set; }

    /// <summary>
    /// Tipos de documento a retornar (código numérico de até 2 posições): <br/>
    /// 04 - DARF <br/>
    /// 07 - DJE <br/>
    /// 08 - DARF SIMPLES <br/>
    /// 09 - DAS <br/>
    /// </summary>
    [JsonPropertyName("codigoTipoDocumentoLista")]
    public List<string>? CodigoTipoDocumentoLista { get; set; }
}

/// <summary>
/// Entrada do serviço PAGAMENTOS71: filtros e paginação da consulta de documentos de arrecadação pagos.
/// </summary>
public sealed class ConsultaPagamentos : FiltroPagamentos
{
    /// <summary>Índice do primeiro registro da página (começa em 0).</summary>
    [JsonPropertyName("primeiroDaPagina")]
    public int PrimeiroDaPagina { get; set; }

    /// <summary>Quantidade de registros por página (máximo 100).</summary>
    [JsonPropertyName("tamanhoDaPagina")]
    public int TamanhoDaPagina { get; set; } = 100;
}

/// <summary>
/// Entrada do serviço COMPARRECADACAO72: número do documento de arrecadação.
/// </summary>
/// <param name="NumeroDocumento">Número do documento (até 17 posições).</param>
public sealed record EmissaoComprovante([property: JsonPropertyName("numeroDocumento")] string NumeroDocumento);


// SAÍDAS

/// <summary>
/// Retorno do serviço COMPARRECADACAO72: comprovante de arrecadação.
/// </summary>
public sealed class ComprovanteArrecadacao
{
    /// <summary>PDF do comprovante de arrecadação, em Base64.</summary>
    [JsonPropertyName("pdf")]
    public string? Pdf { get; set; }
}

/// <summary>
/// Documento de arrecadação pago (item do retorno do serviço PAGAMENTOS71).
/// </summary>
public sealed class DocumentoArrecadacao
{
    /// <summary>Número do documento de arrecadação.</summary>
    [JsonPropertyName("numeroDocumento")]
    public string? NumeroDocumento { get; set; }

    /// <summary>Tipo do documento de arrecadação (DARF, DAS, DAE, DJE).</summary>
    [JsonPropertyName("tipo")]
    public TipoDocumentoArrecadacao? Tipo { get; set; }

    /// <summary>Período de apuração do débito/tributo do pagamento.</summary>
    [JsonPropertyName("periodoApuracao")]
    public DateTimeOffset? PeriodoApuracao { get; set; }

    /// <summary>Data contábil da efetivação do pagamento.</summary>
    [JsonPropertyName("dataArrecadacao")]
    public DateTimeOffset? DataArrecadacao { get; set; }

    /// <summary>Data de vencimento do pagamento.</summary>
    [JsonPropertyName("dataVencimento")]
    public DateTimeOffset? DataVencimento { get; set; }

    /// <summary>Receita principal do pagamento.</summary>
    [JsonPropertyName("receitaPrincipal")]
    public ReceitaArrecadacao? ReceitaPrincipal { get; set; }

    /// <summary>Número de referência do pagamento.</summary>
    [JsonPropertyName("referencia")]
    public string? Referencia { get; set; }

    /// <summary>Valor total do pagamento.</summary>
    [JsonPropertyName("valorTotal")]
    public decimal? ValorTotal { get; set; }

    /// <summary>Valor principal do pagamento.</summary>
    [JsonPropertyName("valorPrincipal")]
    public decimal? ValorPrincipal { get; set; }

    /// <summary>Valor da multa do pagamento.</summary>
    [JsonPropertyName("valorMulta")]
    public decimal? ValorMulta { get; set; }

    /// <summary>Valor dos juros do pagamento.</summary>
    [JsonPropertyName("valorJuros")]
    public decimal? ValorJuros { get; set; }

    /// <summary>Saldo total do pagamento.</summary>
    [JsonPropertyName("valorSaldoTotal")]
    public decimal? ValorSaldoTotal { get; set; }

    /// <summary>Saldo principal do pagamento.</summary>
    [JsonPropertyName("valorSaldoPrincipal")]
    public decimal? ValorSaldoPrincipal { get; set; }

    /// <summary>Saldo da multa do pagamento.</summary>
    [JsonPropertyName("valorSaldoMulta")]
    public decimal? ValorSaldoMulta { get; set; }

    /// <summary>Saldo dos juros do pagamento.</summary>
    [JsonPropertyName("valorSaldoJuros")]
    public decimal? ValorSaldoJuros { get; set; }

    /// <summary>Composição (desmembramentos) do documento de arrecadação.</summary>
    [JsonPropertyName("desmembramentos")]
    public List<DesmembramentoArrecadacao>? Desmembramentos { get; set; }
}

/// <summary>
/// Tipo do documento de arrecadação.
/// </summary>
public sealed class TipoDocumentoArrecadacao
{
    /// <summary>Código do tipo de documento (ex.: 4 - DARF, 9 - DAS).</summary>
    [JsonPropertyName("codigo")]
    public string? Codigo { get; set; }

    /// <summary>Descrição do tipo de documento.</summary>
    [JsonPropertyName("descricao")]
    public string? Descricao { get; set; }

    /// <summary>Descrição abreviada do tipo de documento.</summary>
    [JsonPropertyName("descricaoAbreviada")]
    public string? DescricaoAbreviada { get; set; }
}

/// <summary>
/// Receita de um documento de arrecadação ou desmembramento.
/// </summary>
public sealed class ReceitaArrecadacao
{
    /// <summary>Código da receita.</summary>
    [JsonPropertyName("codigo")]
    public string? Codigo { get; set; }

    /// <summary>Descrição da receita.</summary>
    [JsonPropertyName("descricao")]
    public string? Descricao { get; set; }

    /// <summary>
    /// Extensão do código de receita, que identifica datas de vencimento ou alíquotas de um tributo dentro de um
    /// mesmo código de receita.
    /// </summary>
    [JsonPropertyName("extensaoReceita")]
    public ExtensaoReceitaArrecadacao? ExtensaoReceita { get; set; }
}

/// <summary>
/// Extensão do código de receita.
/// </summary>
public sealed class ExtensaoReceitaArrecadacao
{
    /// <summary>Código da extensão da receita.</summary>
    [JsonPropertyName("codigo")]
    public string? Codigo { get; set; }

    /// <summary>Descrição da extensão da receita.</summary>
    [JsonPropertyName("descricao")]
    public string? Descricao { get; set; }
}

/// <summary>
/// Desmembramento (composição) de um documento de arrecadação.
/// </summary>
public sealed class DesmembramentoArrecadacao
{
    /// <summary>Sequencial do desmembramento.</summary>
    [JsonPropertyName("sequencial")]
    public string? Sequencial { get; set; }

    /// <summary>Receita principal do desmembramento.</summary>
    [JsonPropertyName("receitaPrincipal")]
    public ReceitaArrecadacao? ReceitaPrincipal { get; set; }

    /// <summary>Período de apuração do débito/tributo do desmembramento.</summary>
    [JsonPropertyName("periodoApuracao")]
    public DateTimeOffset? PeriodoApuracao { get; set; }

    /// <summary>Data de vencimento do desmembramento.</summary>
    [JsonPropertyName("dataVencimento")]
    public DateTimeOffset? DataVencimento { get; set; }

    /// <summary>Valor total do desmembramento.</summary>
    [JsonPropertyName("valorTotal")]
    public decimal? ValorTotal { get; set; }

    /// <summary>Valor principal do desmembramento.</summary>
    [JsonPropertyName("valorPrincipal")]
    public decimal? ValorPrincipal { get; set; }

    /// <summary>Valor da multa do desmembramento.</summary>
    [JsonPropertyName("valorMulta")]
    public decimal? ValorMulta { get; set; }

    /// <summary>Valor dos juros do desmembramento.</summary>
    [JsonPropertyName("valorJuros")]
    public decimal? ValorJuros { get; set; }

    /// <summary>Saldo total do desmembramento.</summary>
    [JsonPropertyName("valorSaldoTotal")]
    public decimal? ValorSaldoTotal { get; set; }

    /// <summary>Saldo principal do desmembramento.</summary>
    [JsonPropertyName("valorSaldoPrincipal")]
    public decimal? ValorSaldoPrincipal { get; set; }

    /// <summary>Saldo da multa do desmembramento.</summary>
    [JsonPropertyName("valorSaldoMulta")]
    public decimal? ValorSaldoMulta { get; set; }

    /// <summary>Saldo dos juros do desmembramento.</summary>
    [JsonPropertyName("valorSaldoJuros")]
    public decimal? ValorSaldoJuros { get; set; }

    /// <summary>Cadastro Imobiliário Brasileiro (CIB).</summary>
    [JsonPropertyName("cib")]
    public string? Cib { get; set; }
}
