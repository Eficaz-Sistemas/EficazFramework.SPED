using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraParcelamento;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

// Integra-Parcelamento: PARCSN, PARCSN-ESP, PERTSN, RELPSN, PARCMEI, PARCMEI-ESP, PERTMEI e RELPMEI.
public partial class IntegraContadorService
{
    /// <summary>
    /// Emite o DAS de uma parcela (GERARDAS{p}1) da modalidade de parcelamento.
    /// </summary>
    /// <param name="modalidade">Modalidade de parcelamento.</param>
    /// <param name="contribuinte">Contribuinte (CNPJ).</param>
    /// <param name="dados">Parcela (AAAAMM) a emitir.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <returns>Resposta com o PDF do DAS em <see cref="RetornoGerarDasParcela.DocArrecadacaoPdfB64"/>.</returns>
    public virtual Task<RespostaIntegraContador<RetornoGerarDasParcela>> ParcelamentoGerarDasAsync(
        ModalidadeParcelamento modalidade,
        Identificacao contribuinte,
        GerarDasParcela dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "A parcela para emissão do DAS não foi informada.");

        return ExecutarAsync<GerarDasParcela, RetornoGerarDasParcela>(
            Catalogo.Parcelamento.Servicos(modalidade).GerarDas, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// Consulta as parcelas disponíveis para emissão do DAS (PARCELASPARAGERAR{p}2) no parcelamento ativo da modalidade.
    /// </summary>
    /// <param name="modalidade">Modalidade de parcelamento.</param>
    /// <param name="contribuinte">Contribuinte (CNPJ).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<ParcelasParaGerar>> ParcelamentoConsultarParcelasParaGerarAsync(
        ModalidadeParcelamento modalidade,
        Identificacao contribuinte,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ExecutarAsync<string, ParcelasParaGerar>(
            Catalogo.Parcelamento.Servicos(modalidade).ParcelasParaGerar, contribuinte, null, opcoes, ct);

    /// <summary>
    /// Consulta todos os pedidos de parcelamento (PEDIDOSPARC{p}3) do contribuinte na modalidade.
    /// </summary>
    /// <param name="modalidade">Modalidade de parcelamento.</param>
    /// <param name="contribuinte">Contribuinte (CNPJ).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<PedidosParcelamento>> ParcelamentoConsultarPedidosAsync(
        ModalidadeParcelamento modalidade,
        Identificacao contribuinte,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ExecutarAsync<string, PedidosParcelamento>(
            Catalogo.Parcelamento.Servicos(modalidade).Pedidos, contribuinte, null, opcoes, ct);

    /// <summary>
    /// Consulta um parcelamento específico (OBTERPARC{p}4), desserializando o retorno no layout <typeparamref name="T"/>.
    /// </summary>
    /// <remarks>
    /// O layout depende da modalidade (ver <see cref="TipoParcelamentoDetalhado"/>); prefira os métodos tipados
    /// <see cref="ParcelamentoObterOrdinarioAsync"/>, <see cref="ParcelamentoObterPertSnAsync"/>,
    /// <see cref="ParcelamentoObterPertMeiAsync"/>, <see cref="ParcelamentoObterRelpSnAsync"/> e
    /// <see cref="ParcelamentoObterRelpMeiAsync"/>.
    /// </remarks>
    /// <typeparam name="T">Layout do parcelamento da modalidade.</typeparam>
    /// <param name="modalidade">Modalidade de parcelamento.</param>
    /// <param name="contribuinte">Contribuinte (CNPJ).</param>
    /// <param name="dados">Número do parcelamento.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<T>> ParcelamentoObterAsync<T>(
        ModalidadeParcelamento modalidade,
        Identificacao contribuinte,
        ConsultaParcelamento dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) where T : ParcelamentoDetalhado
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "O número do parcelamento não foi informado.");

        return ExecutarAsync<ConsultaParcelamento, T>(
            Catalogo.Parcelamento.Servicos(modalidade).ObterParcelamento, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// Consulta um parcelamento (OBTERPARC{p}4) das modalidades PARCSN, PARCSN-ESP, PARCMEI ou PARCMEI-ESP.
    /// </summary>
    /// <param name="modalidade">PARCSN, PARCSN_ESP, PARCMEI ou PARCMEI_ESP.</param>
    /// <param name="contribuinte">Contribuinte (CNPJ).</param>
    /// <param name="dados">Número do parcelamento.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentOutOfRangeException">Modalidade com outro layout de retorno.</exception>
    public virtual Task<RespostaIntegraContador<ParcelamentoOrdinario>> ParcelamentoObterOrdinarioAsync(
        ModalidadeParcelamento modalidade,
        Identificacao contribuinte,
        ConsultaParcelamento dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (TipoParcelamentoDetalhado(modalidade) != typeof(ParcelamentoOrdinario))
            throw new ArgumentOutOfRangeException(nameof(modalidade), modalidade, $"A modalidade {modalidade} não usa o layout de parcelamento ordinário; use {TipoParcelamentoDetalhado(modalidade).Name}.");

        return ParcelamentoObterAsync<ParcelamentoOrdinario>(modalidade, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// Consulta um parcelamento do PERTSN (OBTERPARC184).
    /// </summary>
    /// <param name="contribuinte">Contribuinte (CNPJ).</param>
    /// <param name="dados">Número do parcelamento.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<ParcelamentoPertSn>> ParcelamentoObterPertSnAsync(
        Identificacao contribuinte,
        ConsultaParcelamento dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ParcelamentoObterAsync<ParcelamentoPertSn>(ModalidadeParcelamento.PERTSN, contribuinte, dados, opcoes, ct);

    /// <summary>
    /// Consulta um parcelamento do PERTMEI (OBTERPARC224).
    /// </summary>
    /// <param name="contribuinte">Contribuinte (CNPJ).</param>
    /// <param name="dados">Número do parcelamento.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<ParcelamentoPertMei>> ParcelamentoObterPertMeiAsync(
        Identificacao contribuinte,
        ConsultaParcelamento dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ParcelamentoObterAsync<ParcelamentoPertMei>(ModalidadeParcelamento.PERTMEI, contribuinte, dados, opcoes, ct);

    /// <summary>
    /// Consulta um parcelamento do RELPSN (OBTERPARC194).
    /// </summary>
    /// <param name="contribuinte">Contribuinte (CNPJ).</param>
    /// <param name="dados">Número do parcelamento.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<ParcelamentoRelpSn>> ParcelamentoObterRelpSnAsync(
        Identificacao contribuinte,
        ConsultaParcelamento dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ParcelamentoObterAsync<ParcelamentoRelpSn>(ModalidadeParcelamento.RELPSN, contribuinte, dados, opcoes, ct);

    /// <summary>
    /// Consulta um parcelamento do RELPMEI (OBTERPARC234).
    /// </summary>
    /// <param name="contribuinte">Contribuinte (CNPJ).</param>
    /// <param name="dados">Número do parcelamento.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<ParcelamentoRelpMei>> ParcelamentoObterRelpMeiAsync(
        Identificacao contribuinte,
        ConsultaParcelamento dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ParcelamentoObterAsync<ParcelamentoRelpMei>(ModalidadeParcelamento.RELPMEI, contribuinte, dados, opcoes, ct);

    /// <summary>
    /// Consulta os detalhes de pagamento de uma parcela (DETPAGTOPARC{p}5) da modalidade.
    /// </summary>
    /// <param name="modalidade">Modalidade de parcelamento.</param>
    /// <param name="contribuinte">Contribuinte (CNPJ).</param>
    /// <param name="dados">Número do parcelamento e mês (AAAAMM) da parcela paga.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<DetalhePagamentoParcela>> ParcelamentoConsultarDetalhePagamentoAsync(
        ModalidadeParcelamento modalidade,
        Identificacao contribuinte,
        ConsultaDetalhePagamento dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "O parcelamento e a parcela a consultar não foram informados.");

        return ExecutarAsync<ConsultaDetalhePagamento, DetalhePagamentoParcela>(
            Catalogo.Parcelamento.Servicos(modalidade).DetalhePagamento, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// Layout (tipo derivado de <see cref="ParcelamentoDetalhado"/>) do retorno do OBTERPARC da modalidade.
    /// </summary>
    /// <param name="modalidade">Modalidade de parcelamento.</param>
    public static Type TipoParcelamentoDetalhado(ModalidadeParcelamento modalidade) => modalidade switch
    {
        ModalidadeParcelamento.PERTSN => typeof(ParcelamentoPertSn),
        ModalidadeParcelamento.PERTMEI => typeof(ParcelamentoPertMei),
        ModalidadeParcelamento.RELPSN => typeof(ParcelamentoRelpSn),
        ModalidadeParcelamento.RELPMEI => typeof(ParcelamentoRelpMei),
        _ => typeof(ParcelamentoOrdinario)
    };
}
