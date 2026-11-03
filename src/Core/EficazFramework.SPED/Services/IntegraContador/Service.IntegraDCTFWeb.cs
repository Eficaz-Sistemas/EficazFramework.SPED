using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraDCTFWeb;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

public partial class IntegraContadorService
{
    // DCTFWEB

    /// <summary>
    /// GERARGUIA31: gera o documento de arrecadação (DARF) de uma declaração DCTFWeb ATIVA.
    /// </summary>
    /// <param name="contribuinte">Contribuinte declarante.</param>
    /// <param name="dados">Categoria, período de apuração e opções da guia.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados ou ano do período de apuração não informados.</exception>
    public virtual Task<RespostaIntegraContador<RetornoPdfDctfWeb>> DctfWebGerarGuiaAsync(Identificacao contribuinte, GerarGuiaDctfWeb dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<GerarGuiaDctfWeb, RetornoPdfDctfWeb>(Catalogo.DctfWeb.GerarGuia, contribuinte, ValidarDeclaracaoDctfWeb(dados), opcoes, ct);

    /// <summary>
    /// CONSRECIBO32: consulta o recibo de transmissão de uma declaração DCTFWeb (PDF).
    /// </summary>
    /// <param name="contribuinte">Contribuinte declarante.</param>
    /// <param name="dados">Categoria, período de apuração e, opcionalmente, o número do recibo.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados ou ano do período de apuração não informados.</exception>
    public virtual Task<RespostaIntegraContador<RetornoPdfDctfWeb>> DctfWebConsultarReciboAsync(Identificacao contribuinte, ConsultaDctfWeb dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ConsultaDctfWeb, RetornoPdfDctfWeb>(Catalogo.DctfWeb.ConsultarRecibo, contribuinte, ValidarDeclaracaoDctfWeb(dados), opcoes, ct);

    /// <summary>
    /// CONSDECCOMPLETA33: consulta o relatório da declaração DCTFWeb completa transmitida (PDF).
    /// </summary>
    /// <param name="contribuinte">Contribuinte declarante.</param>
    /// <param name="dados">Categoria, período de apuração e, opcionalmente, o número do recibo.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados ou ano do período de apuração não informados.</exception>
    public virtual Task<RespostaIntegraContador<RetornoPdfDctfWeb>> DctfWebConsultarDeclaracaoCompletaAsync(Identificacao contribuinte, ConsultaDctfWeb dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ConsultaDctfWeb, RetornoPdfDctfWeb>(Catalogo.DctfWeb.ConsultarDeclaracaoCompleta, contribuinte, ValidarDeclaracaoDctfWeb(dados), opcoes, ct);

    /// <summary>
    /// CONSXMLDECLARACAO38: obtém o XML de uma declaração DCTFWeb transmitida (já assinado) ou gera o XML de uma
    /// declaração EM ANDAMENTO, para assinatura e transmissão pelo TRANSDECLARACAO310.
    /// </summary>
    /// <param name="contribuinte">Contribuinte declarante.</param>
    /// <param name="dados">Categoria, período de apuração e, opcionalmente, o número do recibo.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados ou ano do período de apuração não informados.</exception>
    public virtual Task<RespostaIntegraContador<RetornoXmlDctfWeb>> DctfWebConsultarXmlDeclaracaoAsync(Identificacao contribuinte, ConsultaDctfWeb dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ConsultaDctfWeb, RetornoXmlDctfWeb>(Catalogo.DctfWeb.ConsultarXmlDeclaracao, contribuinte, ValidarDeclaracaoDctfWeb(dados), opcoes, ct);

    /// <summary>
    /// TRANSDECLARACAO310: transmite uma declaração DCTFWeb EM ANDAMENTO, a partir do XML do CONSXMLDECLARACAO38
    /// assinado na tag <c>ConteudoDeclaracao</c> com o certificado do autor do pedido de dados.
    /// </summary>
    /// <param name="contribuinte">Contribuinte declarante.</param>
    /// <param name="dados">Categoria, período de apuração e XML assinado em Base64.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados, ano do período de apuração ou XML assinado não informados.</exception>
    public virtual Task<RespostaIntegraContador<RetornoTransmissaoDctfWeb>> DctfWebTransmitirDeclaracaoAsync(Identificacao contribuinte, TransmitirDeclaracaoDctfWeb dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default)
    {
        ValidarDeclaracaoDctfWeb(dados);
        if (string.IsNullOrWhiteSpace(dados.XmlAssinadoBase64))
            throw new ArgumentNullException(nameof(dados), "O XML assinado da declaração DCTFWeb não foi informado.");

        return ExecutarAsync<TransmitirDeclaracaoDctfWeb, RetornoTransmissaoDctfWeb>(Catalogo.DctfWeb.TransmitirDeclaracao, contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// TRANSDECLARACAO310: transmite uma declaração DCTFWeb EM ANDAMENTO a partir do XML já assinado, codificando-o
    /// em Base64 (UTF-8) em <see cref="TransmitirDeclaracaoDctfWeb.XmlAssinadoBase64"/>.
    /// </summary>
    /// <remarks>
    /// O XML deve ser idêntico ao recebido no CONSXMLDECLARACAO38, exceto pela assinatura: carregue-o com
    /// <see cref="XmlDocument.PreserveWhitespace"/> verdadeiro para não alterar espaços e quebras de linha.
    /// </remarks>
    /// <param name="contribuinte">Contribuinte declarante.</param>
    /// <param name="dados">Categoria e período de apuração.</param>
    /// <param name="xmlAssinado">XML da declaração assinado na tag <c>ConteudoDeclaracao</c>.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados, ano do período de apuração ou XML assinado não informados.</exception>
    public virtual Task<RespostaIntegraContador<RetornoTransmissaoDctfWeb>> DctfWebTransmitirDeclaracaoAsync(Identificacao contribuinte, TransmitirDeclaracaoDctfWeb dados, XmlDocument xmlAssinado, OpcoesRequisicao? opcoes = null, CancellationToken ct = default)
    {
        ValidarDeclaracaoDctfWeb(dados);
        if (xmlAssinado?.DocumentElement is null)
            throw new ArgumentNullException(nameof(xmlAssinado), "O XML assinado da declaração DCTFWeb não foi informado.");

        dados.XmlAssinadoBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(xmlAssinado.OuterXml));
        return DctfWebTransmitirDeclaracaoAsync(contribuinte, dados, opcoes, ct);
    }

    /// <summary>
    /// GERARGUIAANDAMENTO313: gera o documento de arrecadação (DARF) de uma declaração DCTFWeb EM ANDAMENTO
    /// (para o MIT, use a categoria <see cref="CategoriaDctfWeb.GeralMensal"/>).
    /// </summary>
    /// <param name="contribuinte">Contribuinte declarante.</param>
    /// <param name="dados">Categoria, período de apuração e sistemas de origem das receitas.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados ou ano do período de apuração não informados.</exception>
    public virtual Task<RespostaIntegraContador<RetornoPdfDctfWeb>> DctfWebGerarGuiaEmAndamentoAsync(Identificacao contribuinte, GerarGuiaAndamentoDctfWeb dados, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<GerarGuiaAndamentoDctfWeb, RetornoPdfDctfWeb>(Catalogo.DctfWeb.GerarGuiaEmAndamento, contribuinte, ValidarDeclaracaoDctfWeb(dados), opcoes, ct);

    private static T ValidarDeclaracaoDctfWeb<T>(T dados) where T : DeclaracaoDctfWeb
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "Os dados da declaração DCTFWeb não foram informados.");

        if (string.IsNullOrWhiteSpace(dados.AnoPA))
            throw new ArgumentNullException(nameof(dados), "O ano do período de apuração (anoPA) da declaração DCTFWeb não foi informado.");

        return dados;
    }


    // MIT

    /// <summary>
    /// ENCAPURACAO314: inicia o encerramento de uma apuração do MIT. A apuração é enviada à DCTFWeb posteriormente;
    /// acompanhe pelo <see cref="MitConsultarSituacaoEncerramentoAsync"/> com o protocolo retornado.
    /// </summary>
    /// <remarks>Os dados são serializados no leiaute do MIT (chaves em PascalCase, ver <see cref="ApuracaoMit.SerializarDados"/>).</remarks>
    /// <param name="contribuinte">Contribuinte (PJ) da apuração.</param>
    /// <param name="apuracao">Apuração a encerrar.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Apuração ou período de apuração não informados.</exception>
    public virtual Task<RespostaIntegraContador<RetornoEncerrarApuracaoMit>> MitEncerrarApuracaoAsync(Identificacao contribuinte, ApuracaoMit apuracao, OpcoesRequisicao? opcoes = null, CancellationToken ct = default)
    {
        if (apuracao is null)
            throw new ArgumentNullException(nameof(apuracao), "A apuração do MIT não foi informada.");

        if (apuracao.PeriodoApuracao is null)
            throw new ArgumentNullException(nameof(apuracao), "O período da apuração do MIT não foi informado.");

        return ExecutarAsync<string, RetornoEncerrarApuracaoMit>(Catalogo.Mit.EncerrarApuracao, contribuinte, apuracao.SerializarDados(), opcoes, ct);
    }

    /// <summary>
    /// SITUACAOENC315: consulta a situação do encerramento de uma apuração do MIT (serviço não tarifado).
    /// </summary>
    /// <param name="contribuinte">Contribuinte (PJ) da apuração.</param>
    /// <param name="protocoloEncerramento">Protocolo retornado pelo ENCAPURACAO314.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Protocolo de encerramento não informado.</exception>
    public virtual Task<RespostaIntegraContador<RetornoSituacaoEncerramentoMit>> MitConsultarSituacaoEncerramentoAsync(Identificacao contribuinte, string protocoloEncerramento, OpcoesRequisicao? opcoes = null, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(protocoloEncerramento))
            throw new ArgumentNullException(nameof(protocoloEncerramento), "O protocolo de encerramento da apuração do MIT não foi informado.");

        return ExecutarAsync<ConsultaSituacaoEncerramentoMit, RetornoSituacaoEncerramentoMit>(Catalogo.Mit.SituacaoEncerramento, contribuinte,
            new ConsultaSituacaoEncerramentoMit { ProtocoloEncerramento = protocoloEncerramento }, opcoes, ct);
    }

    /// <summary>
    /// CONSAPURACAO316: consulta a situação e os dados de uma apuração do MIT.
    /// </summary>
    /// <param name="contribuinte">Contribuinte (PJ) da apuração.</param>
    /// <param name="idApuracao">Identificador da apuração retornado pelo ENCAPURACAO314.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<RetornoConsultaApuracaoMit>> MitConsultarApuracaoAsync(Identificacao contribuinte, long idApuracao, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ConsultaApuracaoMit, RetornoConsultaApuracaoMit>(Catalogo.Mit.ConsultarApuracao, contribuinte,
            new ConsultaApuracaoMit { IdApuracao = idApuracao }, opcoes, ct);

    /// <summary>
    /// LISTAAPURACOES317: lista as apurações do MIT de um ano ou de um ano e mês.
    /// </summary>
    /// <param name="contribuinte">Contribuinte (PJ) das apurações.</param>
    /// <param name="anoApuracao">Ano das apurações (AAAA).</param>
    /// <param name="mesApuracao">Mês das apurações (opcional).</param>
    /// <param name="situacaoApuracao">Situação das apurações (opcional).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<RetornoListaApuracoesMit>> MitListarApuracoesAsync(Identificacao contribuinte, int anoApuracao, int? mesApuracao = null, SituacaoApuracaoMit? situacaoApuracao = null, OpcoesRequisicao? opcoes = null, CancellationToken ct = default) =>
        ExecutarAsync<ListaApuracoesMit, RetornoListaApuracoesMit>(Catalogo.Mit.ListarApuracoes, contribuinte,
            new ListaApuracoesMit { AnoApuracao = anoApuracao, MesApuracao = mesApuracao, SituacaoApuracao = situacaoApuracao }, opcoes, ct);
}
