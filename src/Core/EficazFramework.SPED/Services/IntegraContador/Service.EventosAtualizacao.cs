using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.Gerenciador;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

// Integra-Contador-Gerenciador: EVENTOSATUALIZACAO (endpoint Monitorar, não tarifado).
public partial class IntegraContadorService
{
    /// <summary>Quantidade máxima de NIs por lote nos Eventos de Atualização.</summary>
    public const int MaximoNisLoteEventos = 1000;

    /// <summary>
    /// Monta a identificação do lote de contribuintes dos Eventos de Atualização (NIs separados por vírgula).
    /// </summary>
    /// <param name="nis">CPFs (lote PF) ou CNPJs (lote PJ), somente números; de 1 a 1000.</param>
    /// <param name="tipo"><see cref="TipoIdentificacao.LotePF"/> ou <see cref="TipoIdentificacao.LotePJ"/>.</param>
    /// <exception cref="ArgumentNullException">Lista não informada.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Lista vazia, com mais de 1000 NIs ou tipo que não é de lote.</exception>
    public static Identificacao LoteEventos(IEnumerable<string> nis, TipoIdentificacao tipo)
    {
        if (nis is null)
            throw new ArgumentNullException(nameof(nis), "A lista de contribuintes do lote não foi informada.");

        if (tipo is not (TipoIdentificacao.LotePF or TipoIdentificacao.LotePJ))
            throw new ArgumentOutOfRangeException(nameof(tipo), tipo, "O tipo do lote deve ser LotePF (3) ou LotePJ (4).");

        var lista = nis.Where(ni => !string.IsNullOrWhiteSpace(ni)).Select(ni => ni.Trim()).ToList();
        if (lista.Count is 0 or > MaximoNisLoteEventos)
            throw new ArgumentOutOfRangeException(nameof(nis), lista.Count, $"O lote deve conter de 1 a {MaximoNisLoteEventos} contribuintes.");

        return new Identificacao(string.Join(",", lista), tipo);
    }

    /// <summary>
    /// Solicita os eventos de atualização de pessoas físicas (SOLICEVENTOSPF131).
    /// </summary>
    /// <param name="contribuinte">Lote de CPFs separados por vírgula, tipo 3 (ver <see cref="LoteEventos"/>).</param>
    /// <param name="dados">Evento a consultar.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <returns>Resposta com o protocolo e o tempo de espera para <see cref="EventosObterPFAsync(string, string, OpcoesRequisicao?, CancellationToken)"/>.</returns>
    public virtual Task<RespostaIntegraContador<RetornoSolicitacaoEventos>> EventosSolicitarPFAsync(
        Identificacao contribuinte,
        SolicitacaoEventos dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        SolicitarEventosAsync(Catalogo.EventosAtualizacao.SolicitarEventosPF, contribuinte, dados, opcoes, ct);

    /// <summary>
    /// Solicita os eventos de atualização de um lote de CPFs (SOLICEVENTOSPF131).
    /// </summary>
    /// <param name="cpfs">CPFs, somente números (1 a 1000).</param>
    /// <param name="evento">Código do evento (ver <see cref="CodigoEventoAtualizacao"/>).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<RetornoSolicitacaoEventos>> EventosSolicitarPFAsync(
        IEnumerable<string> cpfs,
        string evento,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        EventosSolicitarPFAsync(LoteEventos(cpfs, TipoIdentificacao.LotePF), new SolicitacaoEventos { Evento = evento }, opcoes, ct);

    /// <summary>
    /// Solicita os eventos de atualização de pessoas jurídicas (SOLICEVENTOSPJ132).
    /// </summary>
    /// <param name="contribuinte">Lote de CNPJs completos separados por vírgula, tipo 4 (ver <see cref="LoteEventos"/>).</param>
    /// <param name="dados">Evento a consultar.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <returns>Resposta com o protocolo e o tempo de espera para <see cref="EventosObterPJAsync(string, string, OpcoesRequisicao?, CancellationToken)"/>.</returns>
    public virtual Task<RespostaIntegraContador<RetornoSolicitacaoEventos>> EventosSolicitarPJAsync(
        Identificacao contribuinte,
        SolicitacaoEventos dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        SolicitarEventosAsync(Catalogo.EventosAtualizacao.SolicitarEventosPJ, contribuinte, dados, opcoes, ct);

    /// <summary>
    /// Solicita os eventos de atualização de um lote de CNPJs (SOLICEVENTOSPJ132).
    /// </summary>
    /// <param name="cnpjs">CNPJs completos, somente números (1 a 1000).</param>
    /// <param name="evento">Código do evento (ver <see cref="CodigoEventoAtualizacao"/>).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<RetornoSolicitacaoEventos>> EventosSolicitarPJAsync(
        IEnumerable<string> cnpjs,
        string evento,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        EventosSolicitarPJAsync(LoteEventos(cnpjs, TipoIdentificacao.LotePJ), new SolicitacaoEventos { Evento = evento }, opcoes, ct);

    /// <summary>
    /// Obtém os eventos de atualização de pessoas físicas (OBTEREVENTOSPF133), após o tempo de espera da solicitação.
    /// </summary>
    /// <param name="contribuinte">Identificação com número vazio e tipo 3 (LotePF).</param>
    /// <param name="dados">Protocolo e evento da solicitação.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <returns>Resposta com a matriz de eventos (NI e data AAMMDD).</returns>
    public virtual Task<RespostaIntegraContador<List<EventoAtualizacao>>> EventosObterPFAsync(
        Identificacao contribuinte,
        ObtencaoEventos dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ObterEventosAsync(Catalogo.EventosAtualizacao.ObterEventosPF, contribuinte, dados, opcoes, ct);

    /// <summary>
    /// Obtém os eventos de atualização de pessoas físicas (OBTEREVENTOSPF133) do protocolo.
    /// </summary>
    /// <param name="protocolo">Protocolo obtido na solicitação.</param>
    /// <param name="evento">Código do evento da solicitação.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<List<EventoAtualizacao>>> EventosObterPFAsync(
        string protocolo,
        string evento,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        EventosObterPFAsync(new Identificacao(string.Empty, TipoIdentificacao.LotePF), new ObtencaoEventos { Protocolo = protocolo, Evento = evento }, opcoes, ct);

    /// <summary>
    /// Obtém os eventos de atualização de pessoas jurídicas (OBTEREVENTOSPJ134), após o tempo de espera da solicitação.
    /// </summary>
    /// <param name="contribuinte">Identificação com número vazio e tipo 4 (LotePJ).</param>
    /// <param name="dados">Protocolo e evento da solicitação.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <returns>Resposta com a matriz de eventos (NI e data AAMMDD).</returns>
    public virtual Task<RespostaIntegraContador<List<EventoAtualizacao>>> EventosObterPJAsync(
        Identificacao contribuinte,
        ObtencaoEventos dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ObterEventosAsync(Catalogo.EventosAtualizacao.ObterEventosPJ, contribuinte, dados, opcoes, ct);

    /// <summary>
    /// Obtém os eventos de atualização de pessoas jurídicas (OBTEREVENTOSPJ134) do protocolo.
    /// </summary>
    /// <param name="protocolo">Protocolo obtido na solicitação.</param>
    /// <param name="evento">Código do evento da solicitação.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<List<EventoAtualizacao>>> EventosObterPJAsync(
        string protocolo,
        string evento,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        EventosObterPJAsync(new Identificacao(string.Empty, TipoIdentificacao.LotePJ), new ObtencaoEventos { Protocolo = protocolo, Evento = evento }, opcoes, ct);

    private Task<RespostaIntegraContador<RetornoSolicitacaoEventos>> SolicitarEventosAsync(
        ServicoIntegraContador servico,
        Identificacao contribuinte,
        SolicitacaoEventos dados,
        OpcoesRequisicao? opcoes,
        CancellationToken ct)
    {
        if (dados is null || string.IsNullOrWhiteSpace(dados.Evento))
            throw new ArgumentNullException(nameof(dados), "O evento a consultar não foi informado.");

        return ExecutarAsync<SolicitacaoEventos, RetornoSolicitacaoEventos>(servico, contribuinte, dados, opcoes, ct);
    }

    private Task<RespostaIntegraContador<List<EventoAtualizacao>>> ObterEventosAsync(
        ServicoIntegraContador servico,
        Identificacao contribuinte,
        ObtencaoEventos dados,
        OpcoesRequisicao? opcoes,
        CancellationToken ct)
    {
        if (dados is null || string.IsNullOrWhiteSpace(dados.Protocolo))
            throw new ArgumentNullException(nameof(dados), "O protocolo da solicitação de eventos não foi informado.");

        if (string.IsNullOrWhiteSpace(dados.Evento))
            throw new ArgumentNullException(nameof(dados), "O evento a obter não foi informado.");

        return ExecutarAsync<ObtencaoEventos, List<EventoAtualizacao>>(servico, contribuinte, dados, opcoes, ct);
    }
}
