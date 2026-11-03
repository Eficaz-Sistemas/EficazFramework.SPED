using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraRedesim;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

// Integra-Redesim: PNRCONTADOR (renúncia de responsabilidade contábil).
public partial class IntegraContadorService
{
    /// <summary>
    /// Consulta as empresas com vínculo contabilista ativo com o contador (CONSVINCULOS261).
    /// </summary>
    /// <remarks>O autor do pedido de dados deve ser o contador (PF ou PJ). Para a próxima página, informe
    /// <see cref="PaginaVinculos.LastCnpj"/> em <see cref="PaginacaoVinculos.LastCnpj"/>.</remarks>
    /// <param name="contribuinte">Contribuinte (o próprio contador).</param>
    /// <param name="dados">Paginação (tamanho e cursor).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<PaginaVinculos>> PnrContadorConsultarVinculosAsync(
        Identificacao contribuinte,
        ConsultaVinculos dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados?.Pagination is null)
            throw new ArgumentNullException(nameof(dados), "A paginação da consulta de vínculos não foi informada.");

        return ExecutarAsync<ConsultaVinculos, PaginaVinculos>(Catalogo.PnrContador.ConsultarVinculos, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// Solicita a renúncia a um vínculo contabilista (SOLICRENUNCIA262).
    /// </summary>
    /// <param name="contribuinte">Contribuinte da requisição.</param>
    /// <param name="dados">Dados da solicitação e aceite das declarações.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <returns>Resposta com o ID da solicitação, para <see cref="PnrContadorSituacaoSolicitacaoAsync"/>.</returns>
    public virtual Task<RespostaIntegraContador<RetornoSolicitacaoRenuncia>> PnrContadorSolicitarRenunciaAsync(
        Identificacao contribuinte,
        SolicitacaoRenuncia dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados?.SolicitacaoRenunciaContador is null)
            throw new ArgumentNullException(nameof(dados), "Os dados da solicitação de renúncia não foram informados.");

        if (string.IsNullOrWhiteSpace(dados.SolicitacaoRenunciaContador.Cnpj))
            throw new ArgumentNullException(nameof(dados), "O CNPJ da empresa renunciada não foi informado.");

        if (string.IsNullOrWhiteSpace(dados.SolicitacaoRenunciaContador.CpfPreenchedor))
            throw new ArgumentNullException(nameof(dados), "O CPF do preenchedor não foi informado.");

        return ExecutarAsync<SolicitacaoRenuncia, RetornoSolicitacaoRenuncia>(Catalogo.PnrContador.SolicitarRenuncia, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// Consulta as renúncias de vínculo contabilista realizadas (CONSRENUNCIA263).
    /// </summary>
    /// <param name="contribuinte">Contribuinte da requisição.</param>
    /// <param name="dados">Período e paginação (opcionais; nulo consulta a primeira página sem período).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<PaginaRenuncias>> PnrContadorConsultarRenunciasAsync(
        Identificacao contribuinte,
        ConsultaRenuncias? dados = null,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ExecutarAsync<ConsultaRenuncias, PaginaRenuncias>(Catalogo.PnrContador.ConsultarRenuncias, contribuinte, dados ?? new ConsultaRenuncias(), opcoes, ct);

    /// <summary>
    /// Emite o comprovante de uma renúncia (COMPRENUNCIA264).
    /// </summary>
    /// <param name="contribuinte">Contribuinte da requisição.</param>
    /// <param name="dados">ID da renúncia.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <returns>Resposta com o PDF do comprovante em Base64 em <see cref="RespostaIntegraContador{T}.Retorno"/>.</returns>
    public virtual Task<RespostaIntegraContador<string>> PnrContadorEmitirComprovanteAsync(
        Identificacao contribuinte,
        EmissaoComprovanteRenuncia dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "O ID da renúncia não foi informado.");

        return ExecutarAsync<EmissaoComprovanteRenuncia, string>(Catalogo.PnrContador.EmitirComprovanteRenuncia, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// Consulta a situação de uma solicitação de renúncia (SITSOLICRENUNCIA265).
    /// </summary>
    /// <remarks>Recomenda-se aguardar ao menos 30 segundos após a solicitação.</remarks>
    /// <param name="contribuinte">Contribuinte da requisição.</param>
    /// <param name="dados">ID da solicitação.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<SituacaoSolicitacaoRenuncia>> PnrContadorSituacaoSolicitacaoAsync(
        Identificacao contribuinte,
        ConsultaSituacaoRenuncia dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados is null || string.IsNullOrWhiteSpace(dados.IdSolicitacao))
            throw new ArgumentNullException(nameof(dados), "O ID da solicitação de renúncia não foi informado.");

        return ExecutarAsync<ConsultaSituacaoRenuncia, SituacaoSolicitacaoRenuncia>(Catalogo.PnrContador.SituacaoSolicitacaoRenuncia, contribuinte, dados, opcoes, ct);
    }
}
