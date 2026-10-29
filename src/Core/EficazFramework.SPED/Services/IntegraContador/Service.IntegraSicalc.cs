using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraSicalc;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

public partial class IntegraContadorService
{
    /// <summary>
    /// SICALC / CONSOLIDARGERARDARF51: consolida o crédito tributário (multa e juros) e emite o Darf em PDF (Base64),
    /// com o número do documento e o código Pix.
    /// </summary>
    /// <param name="contribuinte">Contribuinte do débito.</param>
    /// <param name="dados">Dados do débito a consolidar.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados não informados.</exception>
    public virtual Task<RespostaIntegraContador<RetornoDarf>> SicalcConsolidarGerarDarfAsync(
        Identificacao contribuinte,
        ConsolidarDarf dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "Os dados do débito a consolidar não foram informados.");

        return ExecutarAsync<ConsolidarDarf, RetornoDarf>(Catalogo.Sicalc.ConsolidarGerarDarf, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// SICALC / CONSULTAAPOIORECEITAS52: consulta as extensões de uma receita e quais campos são obrigatórios/opcionais
    /// para a consolidação (serviço de apoio, não tarifado).
    /// </summary>
    /// <param name="contribuinte">Contribuinte da requisição.</param>
    /// <param name="codigoReceita">Código da receita (Tabela de Receitas da RFB).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Código da receita não informado.</exception>
    public virtual Task<RespostaIntegraContador<RetornoConsultaReceita>> SicalcConsultarReceitaAsync(
        Identificacao contribuinte,
        string codigoReceita,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(codigoReceita))
            throw new ArgumentNullException(nameof(codigoReceita), "O código da receita não foi informado.");

        return ExecutarAsync<ConsultarReceita, RetornoConsultaReceita>(Catalogo.Sicalc.ConsultarReceitas, contribuinte, new ConsultarReceita(codigoReceita), opcoes, ct);
    }

    /// <summary>
    /// SICALC / GERARDARFCODBARRA53: consolida o crédito tributário e gera o código de barras do Darf (e o código Pix).
    /// A receita/extensão deve permitir código de barras (ver <see cref="SicalcConsultarReceitaAsync"/>).
    /// </summary>
    /// <param name="contribuinte">Contribuinte do débito.</param>
    /// <param name="dados">Dados do débito a consolidar.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados não informados.</exception>
    public virtual Task<RespostaIntegraContador<RetornoDarfCodigoBarras>> SicalcGerarDarfCodigoBarrasAsync(
        Identificacao contribuinte,
        ConsolidarDarf dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "Os dados do débito a consolidar não foram informados.");

        return ExecutarAsync<ConsolidarDarf, RetornoDarfCodigoBarras>(Catalogo.Sicalc.GerarDarfCodigoBarras, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// SICALC / CONSOLIDAR54: consolida o crédito tributário (cálculo dos acréscimos legais) sem emitir o Darf.
    /// </summary>
    /// <param name="contribuinte">Contribuinte do débito.</param>
    /// <param name="dados">Dados do débito a consolidar.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados não informados.</exception>
    public virtual Task<RespostaIntegraContador<RetornoConsolidacao>> SicalcConsolidarAsync(
        Identificacao contribuinte,
        ConsolidarDarf dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "Os dados do débito a consolidar não foram informados.");

        return ExecutarAsync<ConsolidarDarf, RetornoConsolidacao>(Catalogo.Sicalc.Consolidar, contribuinte, dados, opcoes, ct);
    }
}
