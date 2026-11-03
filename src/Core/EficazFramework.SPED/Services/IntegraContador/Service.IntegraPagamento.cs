using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraPagamento;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

public partial class IntegraContadorService
{
    /// <summary>
    /// PAGTOWEB / PAGAMENTOS71: consulta os documentos de arrecadação pagos do contribuinte, com seus desmembramentos.
    /// </summary>
    /// <param name="contribuinte">Contribuinte dos pagamentos.</param>
    /// <param name="consulta">Filtros e paginação da consulta.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Consulta não informada.</exception>
    public virtual Task<RespostaIntegraContador<List<DocumentoArrecadacao>>> PagtoWebConsultarPagamentosAsync(
        Identificacao contribuinte,
        ConsultaPagamentos consulta,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (consulta is null)
            throw new ArgumentNullException(nameof(consulta), "Os filtros da consulta de pagamentos não foram informados.");

        return ExecutarAsync<ConsultaPagamentos, List<DocumentoArrecadacao>>(Catalogo.PagtoWeb.ConsultarPagamentos, contribuinte, consulta, opcoes, ct);
    }

    /// <summary>
    /// PAGTOWEB / COMPARRECADACAO72: emite o comprovante de arrecadação (PDF em Base64) de um documento pago.
    /// </summary>
    /// <remarks>
    /// Os exemplos da documentação retornam <c>{"pdf": "..."}</c>; se o retorno vier apenas com o Base64 (como descrito
    /// na tabela de saída), ele é atribuído a <see cref="ComprovanteArrecadacao.Pdf"/>.
    /// </remarks>
    /// <param name="contribuinte">Contribuinte do pagamento.</param>
    /// <param name="numeroDocumento">Número do documento de arrecadação (até 17 posições).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Número do documento não informado.</exception>
    public virtual async Task<RespostaIntegraContador<ComprovanteArrecadacao>> PagtoWebEmitirComprovanteAsync(
        Identificacao contribuinte,
        string numeroDocumento,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(numeroDocumento))
            throw new ArgumentNullException(nameof(numeroDocumento), "O número do documento de arrecadação não foi informado.");

        var resposta = await ExecutarAsync<EmissaoComprovante, ComprovanteArrecadacao>(
            Catalogo.PagtoWeb.EmitirComprovante, contribuinte, new EmissaoComprovante(numeroDocumento), opcoes, ct);

        if (resposta.Retorno is null && resposta.Dados is { } dados && !string.IsNullOrWhiteSpace(dados) && !dados.TrimStart().StartsWith('{'))
            resposta.Retorno = new ComprovanteArrecadacao { Pdf = dados.Trim() };
        return resposta;
    }

    /// <summary>
    /// PAGTOWEB / CONTACONSDOCARRPG73: conta os documentos de arrecadação pagos do contribuinte que atendem aos filtros.
    /// </summary>
    /// <param name="contribuinte">Contribuinte dos pagamentos.</param>
    /// <param name="filtro">Filtros da contagem.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Filtro não informado.</exception>
    public virtual Task<RespostaIntegraContador<int>> PagtoWebContarPagamentosAsync(
        Identificacao contribuinte,
        FiltroPagamentos filtro,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (filtro is null)
            throw new ArgumentNullException(nameof(filtro), "Os filtros da contagem de pagamentos não foram informados.");

        return ExecutarAsync<FiltroPagamentos, int>(Catalogo.PagtoWeb.ContarPagamentos, contribuinte, filtro, opcoes, ct);
    }
}
