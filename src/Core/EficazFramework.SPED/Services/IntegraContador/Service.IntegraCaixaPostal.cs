using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraCaixaPostal;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

public partial class IntegraContadorService
{
    /// <summary>
    /// CAIXAPOSTAL / MSGCONTRIBUINTE61: obtém a lista de mensagens da Caixa Postal do contribuinte (até 50 por página).
    /// </summary>
    /// <param name="contribuinte">Contribuinte das mensagens.</param>
    /// <param name="filtro">Filtros e paginação (padrão: todas as mensagens, página inicial).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<RetornoListaMensagens>> CaixaPostalListarMensagensAsync(
        Identificacao contribuinte,
        ListarMensagens? filtro = null,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ExecutarAsync<ListarMensagens, RetornoListaMensagens>(Catalogo.CaixaPostal.ListarMensagens, contribuinte, filtro ?? new ListarMensagens(), opcoes, ct);

    /// <summary>
    /// CAIXAPOSTAL / MSGDETALHAMENTO62: obtém os detalhes (corpo e variáveis) de uma mensagem da Caixa Postal.
    /// </summary>
    /// <remarks>
    /// Assim como no portal e-CAC, a execução deste serviço caracteriza ciência da intimação
    /// (art. 23, § 2º, inciso III, do Decreto nº 70.235/1972).
    /// </remarks>
    /// <param name="contribuinte">Contribuinte da mensagem.</param>
    /// <param name="isn">Identificador único da mensagem (<see cref="MensagemCaixaPostalBase.Isn"/>).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">ISN não informado.</exception>
    public virtual Task<RespostaIntegraContador<RetornoDetalheMensagem>> CaixaPostalDetalharMensagemAsync(
        Identificacao contribuinte,
        string isn,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(isn))
            throw new ArgumentNullException(nameof(isn), "O identificador (ISN) da mensagem não foi informado.");

        return ExecutarAsync<DetalharMensagem, RetornoDetalheMensagem>(Catalogo.CaixaPostal.DetalharMensagem, contribuinte, new DetalharMensagem(isn), opcoes, ct);
    }

    /// <summary>
    /// CAIXAPOSTAL / INNOVAMSG63: obtém o indicador de mensagens novas (não lidas por ninguém) da Caixa Postal.
    /// </summary>
    /// <param name="contribuinte">Contribuinte das mensagens.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<RetornoIndicadorNovasMensagens>> CaixaPostalIndicadorNovasMensagensAsync(
        Identificacao contribuinte,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ExecutarAsync<object?, RetornoIndicadorNovasMensagens>(Catalogo.CaixaPostal.IndicadorNovasMensagens, contribuinte, (object?)null, opcoes, ct);

    /// <summary>
    /// DTE / CONSULTASITUACAODTE111: consulta a situação do contribuinte quanto à adesão ao DTE
    /// (Caixa Postal do Simples Nacional e e-CAC).
    /// </summary>
    /// <param name="contribuinte">Contribuinte a consultar.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<RetornoSituacaoDte>> DteConsultarSituacaoAsync(
        Identificacao contribuinte,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ExecutarAsync<object?, RetornoSituacaoDte>(Catalogo.Dte.ConsultarSituacao, contribuinte, (object?)null, opcoes, ct);
}
