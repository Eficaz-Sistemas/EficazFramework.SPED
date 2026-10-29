using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraMEI;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

public partial class IntegraContadorService
{
    // ------------------------------------------------------------------------------------------------
    // PGMEI
    // ------------------------------------------------------------------------------------------------

    /// <summary>
    /// PGMEI / GERARDASPDF21: gera o DAS do MEI, com o PDF em Base64.
    /// </summary>
    /// <param name="contribuinte">CNPJ do MEI.</param>
    /// <param name="dados">Período de apuração e, opcionalmente, data de consolidação.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<List<Das>>> PgmeiGerarDasPdfAsync(
        Identificacao contribuinte,
        GerarDas dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "Os dados para geração do DAS não foram informados.");

        return ExecutarAsync<GerarDas, List<Das>>(Catalogo.Pgmei.GerarDasPdf, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// PGMEI / GERARDASCODBARRA22: gera o DAS do MEI somente com o código de barras, sem o PDF.
    /// </summary>
    /// <param name="contribuinte">CNPJ do MEI.</param>
    /// <param name="dados">Período de apuração e, opcionalmente, data de consolidação.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<List<Das>>> PgmeiGerarDasCodigoBarrasAsync(
        Identificacao contribuinte,
        GerarDas dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "Os dados para geração do DAS não foram informados.");

        return ExecutarAsync<GerarDas, List<Das>>(Catalogo.Pgmei.GerarDasCodigoBarras, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// PGMEI / ATUBENEFICIO23: registra benefício para as apurações informadas do PGMEI.
    /// </summary>
    /// <param name="contribuinte">CNPJ do MEI.</param>
    /// <param name="dados">Ano-calendário e benefícios por período de apuração.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<List<RetornoAtualizarBeneficio>>> PgmeiAtualizarBeneficioAsync(
        Identificacao contribuinte,
        AtualizarBeneficio dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "Os dados do benefício não foram informados.");

        return ExecutarAsync<AtualizarBeneficio, List<RetornoAtualizarBeneficio>>(Catalogo.Pgmei.AtualizarBeneficio, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// PGMEI / DIVIDAATIVA24: consulta os períodos do ano-calendário com inscrição em dívida ativa.
    /// </summary>
    /// <param name="contribuinte">CNPJ do MEI.</param>
    /// <param name="dados">Ano-calendário.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<List<DebitoDividaAtiva>>> PgmeiConsultarDividaAtivaAsync(
        Identificacao contribuinte,
        ConsultarDividaAtiva dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "O ano-calendário da consulta não foi informado.");

        return ExecutarAsync<ConsultarDividaAtiva, List<DebitoDividaAtiva>>(Catalogo.Pgmei.ConsultarDividaAtiva, contribuinte, dados, opcoes, ct);
    }

    // ------------------------------------------------------------------------------------------------
    // CCMEI
    // ------------------------------------------------------------------------------------------------

    /// <summary>
    /// CCMEI / EMITIRCCMEI121: emite o Certificado da Condição de Microempreendedor Individual (PDF em Base64).
    /// </summary>
    /// <remarks>O exemplo de retorno da documentação traz uma lista com um único item.</remarks>
    /// <param name="contribuinte">CNPJ do MEI.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<List<RetornoEmitirCcmei>>> CcmeiEmitirAsync(
        Identificacao contribuinte,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ExecutarAsync<object, List<RetornoEmitirCcmei>>(Catalogo.Ccmei.Emitir, contribuinte, (object?)null, opcoes, ct);

    /// <summary>
    /// CCMEI / DADOSCCMEI122: consulta os dados atualizados do CCMEI do CNPJ informado.
    /// </summary>
    /// <param name="contribuinte">CNPJ do MEI.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<DadosCcmei>> CcmeiConsultarDadosAsync(
        Identificacao contribuinte,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ExecutarAsync<object, DadosCcmei>(Catalogo.Ccmei.ConsultarDados, contribuinte, (object?)null, opcoes, ct);

    /// <summary>
    /// CCMEI / CCMEISITCADASTRAL123: consulta a situação cadastral dos CNPJs (que tenham sido MEI) vinculados ao CPF.
    /// </summary>
    /// <param name="contribuinte">CPF do contribuinte.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<List<SituacaoCadastralCcmei>>> CcmeiConsultarSituacaoCadastralAsync(
        Identificacao contribuinte,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ExecutarAsync<object, List<SituacaoCadastralCcmei>>(Catalogo.Ccmei.ConsultarSituacaoCadastral, contribuinte, (object?)null, opcoes, ct);
}
