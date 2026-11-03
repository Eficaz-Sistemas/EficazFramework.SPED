using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraParcelamento;

// Retorno do serviço OBTERPARC{p}4 (Consultar Parcelamento). O campo "dados" traz diretamente o parcelamento
// (numero, dataDoPedido, ...), mas a consolidação original e as alterações da dívida têm layout próprio em cada
// família de modalidades:
//   - PARCSN, PARCSN-ESP, PARCMEI, PARCMEI-ESP => ParcelamentoOrdinario
//   - PERTSN                                    => ParcelamentoPertSn
//   - PERTMEI                                   => ParcelamentoPertMei
//   - RELPSN                                    => ParcelamentoRelpSn
//   - RELPMEI                                   => ParcelamentoRelpMei
// Os nomes dos campos seguem os exemplos de retorno da documentação quando divergem das tabelas.

/// <summary>
/// Dados comuns do retorno do serviço OBTERPARC{p}4 (Consultar Parcelamento), em todas as modalidades.
/// </summary>
/// <remarks>Use o tipo concreto da modalidade: <see cref="ParcelamentoOrdinario"/>, <see cref="ParcelamentoPertSn"/>,
/// <see cref="ParcelamentoPertMei"/>, <see cref="ParcelamentoRelpSn"/> ou <see cref="ParcelamentoRelpMei"/>.</remarks>
public abstract class ParcelamentoDetalhado
{
    /// <summary>Número do parcelamento.</summary>
    [JsonPropertyName("numero")]
    public int? Numero { get; set; }

    /// <summary>Data do pedido (AAAAMMDD).</summary>
    [JsonPropertyName("dataDoPedido")]
    public int? DataDoPedido { get; set; }

    /// <summary>Situação do parcelamento.</summary>
    [JsonPropertyName("situacao")]
    public string? Situacao { get; set; }

    /// <summary>Data da situação (AAAAMMDD).</summary>
    [JsonPropertyName("dataDaSituacao")]
    public int? DataDaSituacao { get; set; }

    /// <summary>Demonstrativo simplificado dos pagamentos.</summary>
    [JsonPropertyName("demonstrativoPagamentos")]
    public List<DemonstrativoPagamento>? DemonstrativoPagamentos { get; set; }
}

/// <summary>
/// Pagamento de parcela no demonstrativo simplificado.
/// </summary>
public sealed class DemonstrativoPagamento
{
    /// <summary>Mês da parcela (AAAAMM).</summary>
    [JsonPropertyName("mesDaParcela")]
    public int? MesDaParcela { get; set; }

    /// <summary>Data de vencimento do DAS (AAAAMMDD).</summary>
    [JsonPropertyName("vencimentoDoDas")]
    public int? VencimentoDoDas { get; set; }

    /// <summary>Data de arrecadação do DAS (AAAAMMDD).</summary>
    [JsonPropertyName("dataDeArrecadacao")]
    public int? DataDeArrecadacao { get; set; }

    /// <summary>Valor pago.</summary>
    [JsonPropertyName("valorPago")]
    public decimal? ValorPago { get; set; }
}

/// <summary>
/// Débito incluído na consolidação (ou na alteração/reconsolidação) da dívida.
/// </summary>
public sealed class DetalheConsolidacao
{
    /// <summary>Período de apuração (AAAAMM).</summary>
    [JsonPropertyName("periodoApuracao")]
    public int? PeriodoApuracao { get; set; }

    /// <summary>Data de vencimento (AAAAMMDD).</summary>
    [JsonPropertyName("vencimento")]
    public int? Vencimento { get; set; }

    /// <summary>Número do processo.</summary>
    [JsonPropertyName("numeroProcesso")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? NumeroProcesso { get; set; }

    /// <summary>Saldo devedor original.</summary>
    [JsonPropertyName("saldoDevedorOriginal")]
    public decimal? SaldoDevedorOriginal { get; set; }

    /// <summary>Valor atualizado.</summary>
    [JsonPropertyName("valorAtualizado")]
    public decimal? ValorAtualizado { get; set; }
}


// PARCSN / PARCSN-ESP / PARCMEI / PARCMEI-ESP

/// <summary>
/// OBTERPARC das modalidades ordinárias e especiais: PARCSN, PARCSN-ESP, PARCMEI e PARCMEI-ESP.
/// </summary>
public sealed class ParcelamentoOrdinario : ParcelamentoDetalhado
{
    /// <summary>Consolidação original.</summary>
    [JsonPropertyName("consolidacaoOriginal")]
    public ConsolidacaoOrdinaria? ConsolidacaoOriginal { get; set; }

    /// <summary>Alterações da dívida.</summary>
    [JsonPropertyName("alteracoesDivida")]
    public List<AlteracaoDividaOrdinaria>? AlteracoesDivida { get; set; }
}

/// <summary>
/// Consolidação original (PARCSN, PARCSN-ESP, PARCMEI e PARCMEI-ESP).
/// </summary>
public sealed class ConsolidacaoOrdinaria
{
    /// <summary>Valor total consolidado.</summary>
    [JsonPropertyName("valorTotalConsolidado")]
    public decimal? ValorTotalConsolidado { get; set; }

    /// <summary>Quantidade de parcelas.</summary>
    [JsonPropertyName("quantidadeParcelas")]
    public int? QuantidadeParcelas { get; set; }

    /// <summary>Valor da primeira parcela.</summary>
    [JsonPropertyName("primeiraParcela")]
    public decimal? PrimeiraParcela { get; set; }

    /// <summary>Valor da parcela básica.</summary>
    [JsonPropertyName("parcelaBasica")]
    public decimal? ParcelaBasica { get; set; }

    /// <summary>Data e hora da consolidação (AAAAMMDDHHMMSS).</summary>
    [JsonPropertyName("dataConsolidacao")]
    public long? DataConsolidacao { get; set; }

    /// <summary>Débitos consolidados.</summary>
    [JsonPropertyName("detalhesConsolidacao")]
    public List<DetalheConsolidacao>? DetalhesConsolidacao { get; set; }
}

/// <summary>
/// Alteração da dívida (PARCSN, PARCSN-ESP, PARCMEI e PARCMEI-ESP).
/// </summary>
/// <remarks>A documentação do PARCSN/PARCSN-ESP nomeia os débitos <c>detalhesConsolidacao</c> e a do
/// PARCMEI/PARCMEI-ESP, <c>detalhesAlteracaoDivida</c>; ambos são mapeados.</remarks>
public sealed class AlteracaoDividaOrdinaria
{
    /// <summary>Valor total consolidado.</summary>
    [JsonPropertyName("valorTotalConsolidado")]
    public decimal? ValorTotalConsolidado { get; set; }

    /// <summary>Quantidade de parcelas remanescentes.</summary>
    [JsonPropertyName("parcelasRemanescentes")]
    public int? ParcelasRemanescentes { get; set; }

    /// <summary>Valor da parcela básica.</summary>
    [JsonPropertyName("parcelaBasica")]
    public decimal? ParcelaBasica { get; set; }

    /// <summary>Data da alteração da dívida (AAAAMMDD).</summary>
    [JsonPropertyName("dataAlteracaoDivida")]
    public long? DataAlteracaoDivida { get; set; }

    /// <summary>Débitos da alteração (PARCSN e PARCSN-ESP).</summary>
    [JsonPropertyName("detalhesConsolidacao")]
    public List<DetalheConsolidacao>? DetalhesConsolidacao { get; set; }

    /// <summary>Débitos da alteração (PARCMEI e PARCMEI-ESP).</summary>
    [JsonPropertyName("detalhesAlteracaoDivida")]
    public List<DetalheConsolidacao>? DetalhesAlteracaoDivida { get; set; }
}


// PERTSN

/// <summary>
/// OBTERPARC do PERTSN (Programa Especial de Regularização Tributária do Simples Nacional).
/// </summary>
public sealed class ParcelamentoPertSn : ParcelamentoDetalhado
{
    /// <summary>Consolidação original.</summary>
    [JsonPropertyName("consolidacaoOriginal")]
    public ConsolidacaoPertSn? ConsolidacaoOriginal { get; set; }

    /// <summary>Alterações da dívida.</summary>
    [JsonPropertyName("alteracoesDivida")]
    public List<AlteracaoDividaPertSn>? AlteracoesDivida { get; set; }
}

/// <summary>
/// Consolidação original do PERTSN.
/// </summary>
/// <remarks>Campos conforme o exemplo de retorno (a tabela da documentação cita <c>parcelasRemanescentes</c> e
/// <c>parcelaBasicaDaEntrada</c>, ausentes do exemplo).</remarks>
public sealed class ConsolidacaoPertSn
{
    /// <summary>Valor total consolidado da entrada.</summary>
    [JsonPropertyName("valorTotalConsolidadoDaEntrada")]
    public decimal? ValorTotalConsolidadoDaEntrada { get; set; }

    /// <summary>Quantidade de parcelas de entrada.</summary>
    [JsonPropertyName("quantidadeParcelasDeEntrada")]
    public int? QuantidadeParcelasDeEntrada { get; set; }

    /// <summary>Valor da parcela de entrada.</summary>
    [JsonPropertyName("parcelaDeEntrada")]
    public decimal? ParcelaDeEntrada { get; set; }

    /// <summary>Data e hora da consolidação (AAAAMMDDHHMMSS).</summary>
    [JsonPropertyName("dataConsolidacao")]
    public long? DataConsolidacao { get; set; }

    /// <summary>Valor consolidado da dívida.</summary>
    [JsonPropertyName("valorConsolidadoDaDivida")]
    public decimal? ValorConsolidadoDaDivida { get; set; }

    /// <summary>Débitos consolidados.</summary>
    [JsonPropertyName("detalhesConsolidacao")]
    public List<DetalheConsolidacao>? DetalhesConsolidacao { get; set; }
}

/// <summary>
/// Alteração da dívida do PERTSN.
/// </summary>
public sealed class AlteracaoDividaPertSn
{
    /// <summary>Valor total consolidado.</summary>
    [JsonPropertyName("totalConsolidado")]
    public decimal? TotalConsolidado { get; set; }

    /// <summary>Quantidade de parcelas remanescentes.</summary>
    [JsonPropertyName("parcelasRemanescentes")]
    public int? ParcelasRemanescentes { get; set; }

    /// <summary>Valor da parcela básica.</summary>
    [JsonPropertyName("parcelaBasica")]
    public decimal? ParcelaBasica { get; set; }

    /// <summary>Data e hora da alteração da dívida (AAAAMMDDHHMM).</summary>
    [JsonPropertyName("dataAlteracaoDivida")]
    public long? DataAlteracaoDivida { get; set; }

    /// <summary>Valor consolidado do principal.</summary>
    [JsonPropertyName("valorConsolidadoPrincipal")]
    public decimal? ValorConsolidadoPrincipal { get; set; }

    /// <summary>Débitos da alteração.</summary>
    [JsonPropertyName("detalhesAlteracaoDivida")]
    public List<DetalheConsolidacao>? DetalhesAlteracaoDivida { get; set; }
}


// PERTMEI

/// <summary>
/// OBTERPARC do PERTMEI (Programa Especial de Regularização Tributária do MEI).
/// </summary>
public sealed class ParcelamentoPertMei : ParcelamentoDetalhado
{
    /// <summary>Consolidação original.</summary>
    [JsonPropertyName("consolidacaoOriginal")]
    public ConsolidacaoPertMei? ConsolidacaoOriginal { get; set; }

    /// <summary>Consolidações do restante da dívida (com redução).</summary>
    [JsonPropertyName("consolidacoesRestanteDivida")]
    public List<ConsolidacaoRestanteDivida>? ConsolidacoesRestanteDivida { get; set; }
}

/// <summary>
/// Consolidação original do PERTMEI.
/// </summary>
public sealed class ConsolidacaoPertMei
{
    /// <summary>Valor total consolidado da entrada.</summary>
    [JsonPropertyName("valorTotalConsolidadoDaEntrada")]
    public decimal? ValorTotalConsolidadoDaEntrada { get; set; }

    /// <summary>Quantidade de parcelas da entrada.</summary>
    [JsonPropertyName("quantidadeParcelasDaEntrada")]
    public int? QuantidadeParcelasDaEntrada { get; set; }

    /// <summary>Valor da parcela básica da entrada.</summary>
    [JsonPropertyName("parcelaBasicaDaEntrada")]
    public decimal? ParcelaBasicaDaEntrada { get; set; }

    /// <summary>Data e hora da consolidação (AAAAMMDDHHMMSS).</summary>
    [JsonPropertyName("dataConsolidacao")]
    public long? DataConsolidacao { get; set; }

    /// <summary>Valor total consolidado da dívida.</summary>
    [JsonPropertyName("valorTotalConsolidadoDaDivida")]
    public decimal? ValorTotalConsolidadoDaDivida { get; set; }

    /// <summary>Débitos consolidados.</summary>
    [JsonPropertyName("detalhesConsolidacao")]
    public List<DetalheConsolidacao>? DetalhesConsolidacao { get; set; }
}

/// <summary>
/// Consolidação do restante da dívida (PERTMEI).
/// </summary>
public sealed class ConsolidacaoRestanteDivida
{
    /// <summary>Valor total consolidado da dívida.</summary>
    [JsonPropertyName("valorTotalConsolidadoDivida")]
    public decimal? ValorTotalConsolidadoDivida { get; set; }

    /// <summary>Quantidade de parcelas remanescentes.</summary>
    [JsonPropertyName("parcelasRemanescentes")]
    public int? ParcelasRemanescentes { get; set; }

    /// <summary>Valor da parcela básica.</summary>
    [JsonPropertyName("parcelaBasica")]
    public decimal? ParcelaBasica { get; set; }

    /// <summary>Data de confirmação da consolidação (AAAAMMDD).</summary>
    [JsonPropertyName("dataConfirmacaoConsolidacao")]
    public int? DataConfirmacaoConsolidacao { get; set; }

    /// <summary>Débitos consolidados.</summary>
    [JsonPropertyName("detalhesConsolidacao")]
    public List<DetalheConsolidacao>? DetalhesConsolidacao { get; set; }
}


// RELPSN / RELPMEI

/// <summary>
/// OBTERPARC do RELPSN (Programa de Reescalonamento do Pagamento de Débitos do Simples Nacional).
/// </summary>
public sealed class ParcelamentoRelpSn : ParcelamentoDetalhado
{
    /// <summary>Consolidação original.</summary>
    [JsonPropertyName("consolidacaoOriginal")]
    public ConsolidacaoRelp? ConsolidacaoOriginal { get; set; }

    /// <summary>Alterações da dívida.</summary>
    [JsonPropertyName("alteracoesDivida")]
    public List<AlteracaoDividaRelp>? AlteracoesDivida { get; set; }
}

/// <summary>
/// OBTERPARC do RELPMEI (Programa de Reescalonamento do Pagamento de Débitos do MEI).
/// </summary>
/// <remarks>Difere do <see cref="ParcelamentoRelpSn"/> pelo nome da lista (<c>alteracoesDividas</c>, no plural) e pela
/// ausência de <see cref="ConsolidacaoRelp.ValorConsolidadoDivida"/>.</remarks>
public sealed class ParcelamentoRelpMei : ParcelamentoDetalhado
{
    /// <summary>Consolidação original.</summary>
    [JsonPropertyName("consolidacaoOriginal")]
    public ConsolidacaoRelp? ConsolidacaoOriginal { get; set; }

    /// <summary>Alterações das dívidas.</summary>
    [JsonPropertyName("alteracoesDividas")]
    public List<AlteracaoDividaRelp>? AlteracoesDividas { get; set; }
}

/// <summary>
/// Consolidação original do RELPSN e do RELPMEI.
/// </summary>
/// <remarks>Campos conforme os exemplos de retorno (a tabela do RELPSN cita <c>valorTotalConsolidadoDaEntrada</c>;
/// os exemplos de ambas as modalidades trazem <c>valorTotalConsolidadoDeEntrada</c>).</remarks>
public sealed class ConsolidacaoRelp
{
    /// <summary>Valor total consolidado de entrada.</summary>
    [JsonPropertyName("valorTotalConsolidadoDeEntrada")]
    public decimal? ValorTotalConsolidadoDeEntrada { get; set; }

    /// <summary>Quantidade de parcelas de entrada.</summary>
    [JsonPropertyName("quantidadeParcelasDeEntrada")]
    public int? QuantidadeParcelasDeEntrada { get; set; }

    /// <summary>Valor da parcela de entrada.</summary>
    [JsonPropertyName("parcelaDeEntrada")]
    public decimal? ParcelaDeEntrada { get; set; }

    /// <summary>Data e hora da consolidação (AAAAMMDDHHMMSS).</summary>
    [JsonPropertyName("dataConsolidacao")]
    public long? DataConsolidacao { get; set; }

    /// <summary>Valor consolidado da dívida (somente RELPSN).</summary>
    [JsonPropertyName("valorConsolidadoDivida")]
    public decimal? ValorConsolidadoDivida { get; set; }

    /// <summary>Débitos consolidados.</summary>
    [JsonPropertyName("detalhesConsolidacao")]
    public List<DetalheConsolidacao>? DetalhesConsolidacao { get; set; }
}

/// <summary>
/// Alteração (consolidação do restante ou reconsolidação) da dívida do RELPSN e do RELPMEI.
/// </summary>
public sealed class AlteracaoDividaRelp
{
    /// <summary>Data e hora da alteração da dívida (AAAAMMDDHHMM).</summary>
    [JsonPropertyName("dataAlteracaoDivida")]
    public long? DataAlteracaoDivida { get; set; }

    /// <summary>1 = consolidação do restante da dívida; 2 = reconsolidação por alteração de débitos no sistema de cobrança.</summary>
    [JsonPropertyName("identificadorConsolidacao")]
    public int? IdentificadorConsolidacao { get; set; }

    /// <summary>Saldo devedor original sem reduções.</summary>
    [JsonPropertyName("saldoDevedorOriginalSemReducoes")]
    public decimal? SaldoDevedorOriginalSemReducoes { get; set; }

    /// <summary>Valor remanescente com reduções.</summary>
    [JsonPropertyName("valorRemanescenteComReducoes")]
    public decimal? ValorRemanescenteComReducoes { get; set; }

    /// <summary>Valor dos débitos previdenciários.</summary>
    [JsonPropertyName("partePrevidenciaria")]
    public decimal? PartePrevidenciaria { get; set; }

    /// <summary>Valor dos demais débitos (exceto previdenciários).</summary>
    [JsonPropertyName("demaisDebitos")]
    public decimal? DemaisDebitos { get; set; }

    /// <summary>Débitos consolidados.</summary>
    [JsonPropertyName("detalhesConsolidacao")]
    public List<DetalheConsolidacao>? DetalhesConsolidacao { get; set; }

    /// <summary>Faixas de parcelas resultantes da alteração.</summary>
    [JsonPropertyName("parcelasAlteracao")]
    public List<ParcelaAlteracao>? ParcelasAlteracao { get; set; }
}

/// <summary>
/// Faixa de parcelas resultante da alteração da dívida (RELPSN e RELPMEI).
/// </summary>
public sealed class ParcelaAlteracao
{
    /// <summary>Faixa do número de parcelas (ex.: "1ª a 12ª").</summary>
    [JsonPropertyName("faixaParcelas")]
    public string? FaixaParcelas { get; set; }

    /// <summary>Parcela inicial (AAAAMM).</summary>
    [JsonPropertyName("parcelaInicial")]
    public int? ParcelaInicial { get; set; }

    /// <summary>Vencimento inicial (AAAAMMDD).</summary>
    [JsonPropertyName("vencimentoInicial")]
    public int? VencimentoInicial { get; set; }

    /// <summary>Valor da parcela básica.</summary>
    [JsonPropertyName("parcelaBasica")]
    public decimal? ParcelaBasica { get; set; }
}
