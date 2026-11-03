using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraSITFIS;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

public partial class IntegraContadorService
{
    /// <summary>Tempo de espera usado quando a API não informa o <c>tempoEspera</c> de uma nova tentativa do SITFIS.</summary>
    public TimeSpan EsperaPadraoSitfis { get; set; } = TimeSpan.FromSeconds(2);

    /// <summary>
    /// SITFIS / SOLICITARPROTOCOLO91: solicita o protocolo para emissão do relatório de situação fiscal (serviço de apoio).
    /// </summary>
    /// <remarks>
    /// Se já houver protocolo válido e não utilizado (HTTP 304), ele é lido do cabeçalho ETag e atribuído a
    /// <see cref="ProtocoloRelatorioSitfis.ProtocoloRelatorio"/>.
    /// </remarks>
    /// <param name="contribuinte">Contribuinte do relatório.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual async Task<RespostaIntegraContador<ProtocoloRelatorioSitfis>> SitfisSolicitarProtocoloAsync(
        Identificacao contribuinte,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        var resposta = await ExecutarAsync<object?, ProtocoloRelatorioSitfis>(Catalogo.Sitfis.SolicitarProtocolo, contribuinte, (object?)null, opcoes, ct);

        if (string.IsNullOrEmpty(resposta.Retorno?.ProtocoloRelatorio) && LerETagSitfis(resposta.ETag, "protocoloRelatorio") is { Length: > 0 } protocolo)
        {
            resposta.Retorno ??= new ProtocoloRelatorioSitfis();
            resposta.Retorno.ProtocoloRelatorio = protocolo;
        }
        return resposta;
    }

    /// <summary>
    /// SITFIS / RELATORIOSITFIS92: emite o relatório de situação fiscal (PDF em Base64) a partir do protocolo.
    /// </summary>
    /// <remarks>
    /// Enquanto o relatório estiver em processamento, a resposta é HTTP 202 (ou 204, com o tempo no cabeçalho ETag) e
    /// <see cref="RelatorioSitfis.TempoEspera"/> indica quantos milissegundos aguardar antes de nova tentativa.
    /// Ver também <see cref="SitfisObterRelatorioAsync"/>.
    /// </remarks>
    /// <param name="contribuinte">Contribuinte do relatório.</param>
    /// <param name="protocoloRelatorio">Protocolo obtido em <see cref="SitfisSolicitarProtocoloAsync"/>.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Protocolo não informado.</exception>
    public virtual async Task<RespostaIntegraContador<RelatorioSitfis>> SitfisEmitirRelatorioAsync(
        Identificacao contribuinte,
        string protocoloRelatorio,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(protocoloRelatorio))
            throw new ArgumentNullException(nameof(protocoloRelatorio), "O protocolo do relatório de situação fiscal não foi informado.");

        var resposta = await ExecutarAsync<EmissaoRelatorioSitfis, RelatorioSitfis>(
            Catalogo.Sitfis.EmitirRelatorio, contribuinte, new EmissaoRelatorioSitfis(protocoloRelatorio), opcoes, ct);

        if (resposta.Retorno?.TempoEspera is null && string.IsNullOrEmpty(resposta.Retorno?.Pdf)
            && int.TryParse(LerETagSitfis(resposta.ETag, "tempoEspera"), NumberStyles.Integer, CultureInfo.InvariantCulture, out var tempo))
        {
            resposta.Retorno ??= new RelatorioSitfis();
            resposta.Retorno.TempoEspera = tempo;
        }
        return resposta;
    }

    /// <summary>
    /// Obtém o relatório de situação fiscal: solicita o protocolo (SOLICITARPROTOCOLO91) e aciona a emissão
    /// (RELATORIOSITFIS92), aguardando o <c>tempoEspera</c> informado pela API entre as tentativas enquanto o relatório
    /// estiver em processamento (HTTP 202/204).
    /// </summary>
    /// <param name="contribuinte">Contribuinte do relatório.</param>
    /// <param name="maxTentativas">Quantidade máxima de chamadas da emissão (padrão 5).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento (também interrompe as esperas).</param>
    /// <returns>
    /// A resposta da última emissão (com o PDF, quando concluída) ou, se a solicitação do protocolo falhar, a resposta
    /// dessa solicitação (sem <see cref="RespostaIntegraContador{T}.Retorno"/>).
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">Quantidade de tentativas menor que 1.</exception>
    public virtual async Task<RespostaIntegraContador<RelatorioSitfis>> SitfisObterRelatorioAsync(
        Identificacao contribuinte,
        int maxTentativas = 5,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (maxTentativas < 1)
            throw new ArgumentOutOfRangeException(nameof(maxTentativas), "A quantidade máxima de tentativas deve ser maior que zero.");

        var protocolo = await SitfisSolicitarProtocoloAsync(contribuinte, opcoes, ct);
        if (!protocolo.Sucesso || string.IsNullOrEmpty(protocolo.Retorno?.ProtocoloRelatorio))
            return CopiarEnvelopeSitfis<RelatorioSitfis>(protocolo);

        if (protocolo.Retorno.TempoEspera is > 0 and var esperaInicial)
            await AguardarAsync(TimeSpan.FromMilliseconds(esperaInicial), ct);

        RespostaIntegraContador<RelatorioSitfis> resposta = null!;
        for (var tentativa = 1; tentativa <= maxTentativas; tentativa++)
        {
            resposta = await SitfisEmitirRelatorioAsync(contribuinte, protocolo.Retorno.ProtocoloRelatorio, opcoes, ct);

            var emProcessamento = resposta.StatusCode is (int)HttpStatusCode.Accepted or (int)HttpStatusCode.NoContent
                && string.IsNullOrEmpty(resposta.Retorno?.Pdf);
            if (!emProcessamento || tentativa == maxTentativas)
                break;

            var espera = resposta.Retorno?.TempoEspera is > 0 and var tempo ? TimeSpan.FromMilliseconds(tempo) : EsperaPadraoSitfis;
            await AguardarAsync(espera, ct);
        }
        return resposta;
    }

    /// <summary>
    /// Aguarda o tempo indicado entre as tentativas do SITFIS (sobrescreva em testes para não esperar).
    /// </summary>
    /// <param name="espera">Tempo de espera.</param>
    /// <param name="ct">Token de cancelamento.</param>
    protected virtual Task AguardarAsync(TimeSpan espera, CancellationToken ct) => Task.Delay(espera, ct);

    /// <summary>
    /// Lê o valor de <c>chave:valor</c> do cabeçalho ETag (ex.: <c>"tempoEspera:4000"</c>).
    /// </summary>
    private static string? LerETagSitfis(string? etag, string chave)
    {
        if (string.IsNullOrWhiteSpace(etag))
            return null;

        var valor = Regex.Replace(etag.Trim(), "^(W/)?\"|\"$", string.Empty);
        var prefixo = chave + ":";
        return valor.StartsWith(prefixo, StringComparison.OrdinalIgnoreCase) ? valor[prefixo.Length..].Trim() : null;
    }

    /// <summary>
    /// Copia o envelope de uma resposta (sem o retorno tipado) para uma resposta de outro tipo.
    /// </summary>
    private static RespostaIntegraContador<T> CopiarEnvelopeSitfis<T>(RespostaIntegraContador origem) => new()
    {
        Contratante = origem.Contratante,
        AutorPedidoDados = origem.AutorPedidoDados,
        Contribuinte = origem.Contribuinte,
        PedidoDados = origem.PedidoDados,
        Status = origem.Status,
        Dados = origem.Dados,
        Mensagens = origem.Mensagens,
        ResponseId = origem.ResponseId,
        ResponseDateTime = origem.ResponseDateTime,
        StatusCode = origem.StatusCode,
        ETag = origem.ETag,
        Expires = origem.Expires
    };
}
