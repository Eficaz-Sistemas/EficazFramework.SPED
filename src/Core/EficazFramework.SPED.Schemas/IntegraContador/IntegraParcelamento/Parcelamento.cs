using System.Buffers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraParcelamento;

// Tipos comuns às 8 modalidades (PARCSN, PARCSN-ESP, PERTSN, RELPSN, PARCMEI, PARCMEI-ESP, PERTMEI e RELPMEI)
// para os serviços GERARDAS, PARCELASPARAGERAR, PEDIDOSPARC e DETPAGTOPARC.
// O detalhamento de um parcelamento (OBTERPARC) varia por modalidade: ver ParcelamentoDetalhado.cs.

/// <summary>
/// Entrada do serviço GERARDAS{p}1 (Emitir Documento de Arrecadação): parcela para a qual o DAS será emitido.
/// </summary>
public sealed class GerarDasParcela
{
    /// <summary>Ano e mês da parcela para emitir o DAS (AAAAMM).</summary>
    [JsonPropertyName("parcelaParaEmitir")]
    public int ParcelaParaEmitir { get; set; }
}

/// <summary>
/// Retorno do serviço GERARDAS{p}1: DAS da parcela em PDF.
/// </summary>
public sealed class RetornoGerarDasParcela
{
    /// <summary>PDF do DAS codificado em Base64.</summary>
    [JsonPropertyName("docArrecadacaoPdfB64")]
    public string? DocArrecadacaoPdfB64 { get; set; }
}

/// <summary>
/// Retorno do serviço PARCELASPARAGERAR{p}2 (Consultar Parcelas Disponíveis para Impressão) do parcelamento ativo.
/// </summary>
/// <remarks>A tabela da documentação cita <c>listaParcela</c>, mas todos os exemplos de retorno trazem <c>listaParcelas</c>.</remarks>
public sealed class ParcelasParaGerar
{
    /// <summary>Parcelas disponíveis para emissão do DAS.</summary>
    [JsonPropertyName("listaParcelas")]
    public List<ParcelaParaGerar>? ListaParcelas { get; set; }
}

/// <summary>
/// Parcela disponível para emissão do DAS.
/// </summary>
public sealed class ParcelaParaGerar
{
    /// <summary>Ano e mês da parcela (AAAAMM).</summary>
    [JsonPropertyName("parcela")]
    public int? Parcela { get; set; }

    /// <summary>Valor da parcela.</summary>
    [JsonPropertyName("valor")]
    public decimal? Valor { get; set; }
}

/// <summary>
/// Retorno do serviço PEDIDOSPARC{p}3 (Consultar Pedidos de Parcelamento): todos os pedidos da modalidade.
/// </summary>
public sealed class PedidosParcelamento
{
    /// <summary>Pedidos de parcelamento do contribuinte.</summary>
    [JsonPropertyName("parcelamentos")]
    public List<PedidoParcelamento>? Parcelamentos { get; set; }
}

/// <summary>
/// Pedido de parcelamento (dados resumidos).
/// </summary>
public sealed class PedidoParcelamento
{
    /// <summary>Número do parcelamento.</summary>
    [JsonPropertyName("numero")]
    public int? Numero { get; set; }

    /// <summary>Data do pedido (AAAAMMDD).</summary>
    [JsonPropertyName("dataDoPedido")]
    public int? DataDoPedido { get; set; }

    /// <summary>Situação do parcelamento (ex.: "Em parcelamento", "Encerrado a Pedido do Contribuinte").</summary>
    [JsonPropertyName("situacao")]
    public string? Situacao { get; set; }

    /// <summary>Data da situação (AAAAMMDD).</summary>
    [JsonPropertyName("dataDaSituacao")]
    public int? DataDaSituacao { get; set; }
}

/// <summary>
/// Entrada do serviço OBTERPARC{p}4 (Consultar Parcelamento): número do parcelamento a detalhar.
/// </summary>
public sealed class ConsultaParcelamento
{
    /// <summary>Número do parcelamento (ver <see cref="PedidoParcelamento.Numero"/>).</summary>
    [JsonPropertyName("numeroParcelamento")]
    public int NumeroParcelamento { get; set; }
}

/// <summary>
/// Entrada do serviço DETPAGTOPARC{p}5 (Consultar Detalhes de Pagamento de Parcela).
/// </summary>
public sealed class ConsultaDetalhePagamento
{
    /// <summary>Número do parcelamento.</summary>
    [JsonPropertyName("numeroParcelamento")]
    public int NumeroParcelamento { get; set; }

    /// <summary>Ano e mês da parcela paga (AAAAMM).</summary>
    [JsonPropertyName("anoMesParcela")]
    public int AnoMesParcela { get; set; }
}

/// <summary>
/// Retorno do serviço DETPAGTOPARC{p}5: detalhes do pagamento (DAS) de uma parcela.
/// </summary>
public sealed class DetalhePagamentoParcela
{
    /// <summary>Número do DAS pago.</summary>
    [JsonPropertyName("numeroDas")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? NumeroDas { get; set; }

    /// <summary>Data de vencimento do DAS (AAAAMMDD).</summary>
    [JsonPropertyName("dataVencimento")]
    public int? DataVencimento { get; set; }

    /// <summary>Período de apuração do DAS gerado (AAAAMM).</summary>
    [JsonPropertyName("paDasGerado")]
    public int? PaDasGerado { get; set; }

    /// <summary>Data e hora de geração do DAS (AAAAMMDDHHMMSS).</summary>
    [JsonPropertyName("geradoEm")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? GeradoEm { get; set; }

    /// <summary>Número do parcelamento (texto, ex.: "0001").</summary>
    [JsonPropertyName("numeroParcelamento")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? NumeroParcelamento { get; set; }

    /// <summary>Número da parcela (texto, ex.: "01").</summary>
    [JsonPropertyName("numeroParcela")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? NumeroParcela { get; set; }

    /// <summary>Data limite para acolhimento (AAAAMMDD).</summary>
    [JsonPropertyName("dataLimiteAcolhimento")]
    public int? DataLimiteAcolhimento { get; set; }

    /// <summary>Débitos pagos pelo DAS.</summary>
    [JsonPropertyName("pagamentoDebitos")]
    public List<PagamentoDebito>? PagamentoDebitos { get; set; }

    /// <summary>Data do pagamento (AAAAMMDD).</summary>
    [JsonPropertyName("dataPagamento")]
    public int? DataPagamento { get; set; }

    /// <summary>Banco/agência do pagamento.</summary>
    [JsonPropertyName("bancoAgencia")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? BancoAgencia { get; set; }

    /// <summary>Valor arrecadado.</summary>
    [JsonPropertyName("valorPagoArrecadacao")]
    public decimal? ValorPagoArrecadacao { get; set; }
}

/// <summary>
/// Débito pago pelo DAS da parcela.
/// </summary>
public sealed class PagamentoDebito
{
    /// <summary>Período de apuração do débito (AAAAMM).</summary>
    [JsonPropertyName("paDebito")]
    public int? PaDebito { get; set; }

    /// <summary>Número do processo.</summary>
    [JsonPropertyName("processo")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? Processo { get; set; }

    /// <summary>Discriminação do débito por tributo.</summary>
    [JsonPropertyName("discriminacoesDebito")]
    public List<DiscriminacaoDebito>? DiscriminacoesDebito { get; set; }
}

/// <summary>
/// Discriminação de um débito por tributo.
/// </summary>
public sealed class DiscriminacaoDebito
{
    /// <summary>Nome do tributo (ex.: IRPJ, CSLL, INSS, ICMS, ISS).</summary>
    [JsonPropertyName("tributo")]
    public string? Tributo { get; set; }

    /// <summary>Valor do principal.</summary>
    [JsonPropertyName("principal")]
    public decimal? Principal { get; set; }

    /// <summary>Valor da multa.</summary>
    [JsonPropertyName("multa")]
    public decimal? Multa { get; set; }

    /// <summary>Valor dos juros.</summary>
    [JsonPropertyName("juros")]
    public decimal? Juros { get; set; }

    /// <summary>Valor total.</summary>
    [JsonPropertyName("total")]
    public decimal? Total { get; set; }

    /// <summary>Ente federado de destino (ex.: União, UF ou município).</summary>
    [JsonPropertyName("enteFederadoDestino")]
    public string? EnteFederadoDestino { get; set; }
}

