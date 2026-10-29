using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraSN;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

// Integra-SN: PGDASD, Regime de Apuração e DEFIS.
public partial class IntegraContadorService
{
    private const string MensagemDadosIntegraSN = "Os dados de entrada do serviço não foram informados.";

    #region PGDASD

    /// <summary>
    /// PGDASD / TRANSDECLARACAO11: entrega a declaração mensal do Simples Nacional, original ou retificadora
    /// (ou apenas calcula os valores devidos, quando <see cref="TransmitirDeclaracao.IndicadorTransmissao"/> é <c>false</c>).
    /// </summary>
    /// <param name="contribuinte">Contribuinte a que se refere a declaração.</param>
    /// <param name="dados">Dados da declaração.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<DeclaracaoTransmitida>> PgdasdTransmitirDeclaracaoAsync(Identificacao contribuinte, TransmitirDeclaracao dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<TransmitirDeclaracao, DeclaracaoTransmitida>(Catalogo.Pgdasd.TransmitirDeclaracao, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    /// <summary>
    /// PGDASD / GERARDAS12: gera o DAS de uma declaração previamente transmitida (opcionalmente para data de consolidação futura).
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Período de apuração e data de consolidação.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<List<Das>>> PgdasdGerarDasAsync(Identificacao contribuinte, GerarDas dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<GerarDas, List<Das>>(Catalogo.Pgdasd.GerarDas, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    /// <summary>
    /// PGDASD / CONSDECLARACAO13: consulta o índice das declarações transmitidas por ano-calendário ou período de apuração.
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Ano-calendário ou período de apuração.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<DeclaracoesEntregues>> PgdasdConsultarDeclaracoesAsync(Identificacao contribuinte, ConsultarDeclaracoes dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ConsultarDeclaracoes, DeclaracoesEntregues>(Catalogo.Pgdasd.ConsultarDeclaracoes, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    /// <summary>
    /// PGDASD / CONSULTIMADECREC14: consulta a última declaração/recibo transmitida no período de apuração (e a MAED, se houver).
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Período de apuração.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<DeclaracaoRecibo>> PgdasdConsultarUltimaDeclaracaoAsync(Identificacao contribuinte, ConsultarUltimaDeclaracao dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ConsultarUltimaDeclaracao, DeclaracaoRecibo>(Catalogo.Pgdasd.ConsultarUltimaDeclaracao, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    /// <summary>
    /// PGDASD / CONSDECREC15: consulta uma declaração/recibo específica (e a MAED, se houver).
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Número da declaração.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<DeclaracaoRecibo>> PgdasdConsultarDeclaracaoAsync(Identificacao contribuinte, ConsultarDeclaracao dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ConsultarDeclaracao, DeclaracaoRecibo>(Catalogo.Pgdasd.ConsultarDeclaracao, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    /// <summary>
    /// PGDASD / CONSEXTRATO16: consulta o extrato detalhado de um DAS gerado.
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Número do DAS.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<ExtratoDas>> PgdasdConsultarExtratoDasAsync(Identificacao contribuinte, ConsultarExtratoDas dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ConsultarExtratoDas, ExtratoDas>(Catalogo.Pgdasd.ConsultarExtratoDas, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    /// <summary>
    /// PGDASD / GERARDASCOBRANCA17: gera o DAS com os débitos em sistema de cobrança.
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Período de apuração.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<Das>> PgdasdGerarDasCobrancaAsync(Identificacao contribuinte, GerarDasCobranca dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<GerarDasCobranca, Das>(Catalogo.Pgdasd.GerarDasCobranca, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    /// <summary>
    /// PGDASD / GERARDASPROCESSO18: gera o DAS com os débitos de processo em sistema de cobrança.
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Número do processo.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<Das>> PgdasdGerarDasProcessoAsync(Identificacao contribuinte, GerarDasProcesso dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<GerarDasProcesso, Das>(Catalogo.Pgdasd.GerarDasProcesso, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    /// <summary>
    /// PGDASD / GERARDASAVULSO19: gera um DAS avulso.
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Período de apuração e tributos.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<Das>> PgdasdGerarDasAvulsoAsync(Identificacao contribuinte, GerarDasAvulso dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<GerarDasAvulso, Das>(Catalogo.Pgdasd.GerarDasAvulso, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    #endregion

    #region REGIMEAPURACAO

    /// <summary>
    /// REGIMEAPURACAO / EFETUAROPCAOREGIME101: efetua a opção anual pelo regime de apuração de receitas (competência ou caixa).
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Ano e regime escolhido.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<OpcaoRegime>> RegimeApuracaoEfetuarOpcaoAsync(Identificacao contribuinte, EfetuarOpcaoRegime dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<EfetuarOpcaoRegime, OpcaoRegime>(Catalogo.RegimeApuracao.EfetuarOpcao, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    /// <summary>
    /// REGIMEAPURACAO / CONSULTARANOSCALENDARIOS102: consulta todas as opções pelo regime de apuração efetivadas.
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<List<AnoCalendarioRegime>>> RegimeApuracaoConsultarAnosCalendarioAsync(Identificacao contribuinte, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<object, List<AnoCalendarioRegime>>(Catalogo.RegimeApuracao.ConsultarAnosCalendario, contribuinte, (object?)null, opcoes, ct);

    /// <summary>
    /// REGIMEAPURACAO / CONSULTAROPCAOREGIME103: consulta a opção pelo regime de apuração de um ano-calendário.
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Ano-calendário.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<OpcaoRegime>> RegimeApuracaoConsultarOpcaoAsync(Identificacao contribuinte, ConsultarOpcaoRegime dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ConsultarOpcaoRegime, OpcaoRegime>(Catalogo.RegimeApuracao.ConsultarOpcao, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    /// <summary>
    /// REGIMEAPURACAO / CONSULTARRESOLUCAO104: consulta o texto da resolução para o regime de caixa.
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Ano-calendário.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<ResolucaoRegime>> RegimeApuracaoConsultarResolucaoAsync(Identificacao contribuinte, ConsultarResolucaoRegime dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ConsultarResolucaoRegime, ResolucaoRegime>(Catalogo.RegimeApuracao.ConsultarResolucao, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    #endregion

    #region DEFIS

    /// <summary>
    /// DEFIS / TRANSDECLARACAO141: transmite a Declaração de Informações Socioeconômicas e Fiscais.
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Dados da declaração.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<ReciboDefis>> DefisTransmitirDeclaracaoAsync(Identificacao contribuinte, TransmitirDeclaracaoDefis dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<TransmitirDeclaracaoDefis, ReciboDefis>(Catalogo.Defis.TransmitirDeclaracao, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    /// <summary>
    /// DEFIS / CONSDECLARACAO142: consulta todas as declarações transmitidas no período não decadente.
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<List<DeclaracaoDefis>>> DefisConsultarDeclaracoesAsync(Identificacao contribuinte, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<object, List<DeclaracaoDefis>>(Catalogo.Defis.ConsultarDeclaracoes, contribuinte, (object?)null, opcoes, ct);

    /// <summary>
    /// DEFIS / CONSULTIMADECREC143: consulta a última declaração/recibo transmitida no ano-calendário.
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Ano-calendário.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<ReciboDefis>> DefisConsultarUltimaDeclaracaoAsync(Identificacao contribuinte, ConsultarUltimaDeclaracaoDefis dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ConsultarUltimaDeclaracaoDefis, ReciboDefis>(Catalogo.Defis.ConsultarUltimaDeclaracao, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    /// <summary>
    /// DEFIS / CONSDECREC144: consulta uma declaração/recibo específica.
    /// </summary>
    /// <param name="contribuinte">Contribuinte.</param>
    /// <param name="dados">Identificador da DEFIS.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<ReciboDefis>> DefisConsultarDeclaracaoAsync(Identificacao contribuinte, ConsultarDeclaracaoDefis dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ConsultarDeclaracaoDefis, ReciboDefis>(Catalogo.Defis.ConsultarDeclaracao, contribuinte, dados ?? throw new ArgumentNullException(nameof(dados), MensagemDadosIntegraSN), opcoes, ct);

    #endregion
}
