namespace EficazFramework.SPED.Schemas.IntegraContador;

/// <summary>
/// Serviço da API Integra Contador: sistema, serviço, versão e endpoint em que é chamado.
/// </summary>
/// <param name="IdSistema">Identificador do sistema (pedidoDados.idSistema).</param>
/// <param name="IdServico">Identificador do serviço (pedidoDados.idServico).</param>
/// <param name="VersaoSistema">Versão do sistema (pedidoDados.versaoSistema).</param>
/// <param name="Endpoint">Endpoint (rota) do serviço.</param>
public sealed record ServicoIntegraContador(string IdSistema, string IdServico, string VersaoSistema, TipoEndpoint Endpoint);

/// <summary>
/// Serviços de uma modalidade de parcelamento (Integra-Parcelamento).
/// </summary>
public sealed record ServicosParcelamento(
    ServicoIntegraContador GerarDas,
    ServicoIntegraContador ParcelasParaGerar,
    ServicoIntegraContador Pedidos,
    ServicoIntegraContador ObterParcelamento,
    ServicoIntegraContador DetalhePagamento);

/// <summary>
/// Catálogo dos serviços da API Integra Contador em produção.
/// </summary>
/// <remarks>Fonte: https://apicenter.estaleiro.serpro.gov.br/documentacao/api-integra-contador/pt/catalogo_de_servicos/</remarks>
public static class Catalogo
{
    /// <summary>Integra-SN: PGDAS-D (Programa Gerador do DAS do Simples Nacional).</summary>
    public static class Pgdasd
    {
        /// <summary>11 - Entregar declaração mensal.</summary>
        public static readonly ServicoIntegraContador TransmitirDeclaracao = new("PGDASD", "TRANSDECLARACAO11", "1.0", TipoEndpoint.Declarar);
        /// <summary>12 - Gerar DAS.</summary>
        public static readonly ServicoIntegraContador GerarDas = new("PGDASD", "GERARDAS12", "1.0", TipoEndpoint.Emitir);
        /// <summary>13 - Consultar declarações transmitidas.</summary>
        public static readonly ServicoIntegraContador ConsultarDeclaracoes = new("PGDASD", "CONSDECLARACAO13", "1.0", TipoEndpoint.Consultar);
        /// <summary>14 - Consultar a última declaração/recibo transmitida.</summary>
        public static readonly ServicoIntegraContador ConsultarUltimaDeclaracao = new("PGDASD", "CONSULTIMADECREC14", "1.0", TipoEndpoint.Consultar);
        /// <summary>15 - Consultar declaração/recibo.</summary>
        public static readonly ServicoIntegraContador ConsultarDeclaracao = new("PGDASD", "CONSDECREC15", "1.0", TipoEndpoint.Consultar);
        /// <summary>16 - Consultar extrato do DAS.</summary>
        public static readonly ServicoIntegraContador ConsultarExtratoDas = new("PGDASD", "CONSEXTRATO16", "1.0", TipoEndpoint.Consultar);
        /// <summary>17 - Gerar DAS de cobrança.</summary>
        public static readonly ServicoIntegraContador GerarDasCobranca = new("PGDASD", "GERARDASCOBRANCA17", "1.0", TipoEndpoint.Emitir);
        /// <summary>18 - Gerar DAS de processo.</summary>
        public static readonly ServicoIntegraContador GerarDasProcesso = new("PGDASD", "GERARDASPROCESSO18", "1.0", TipoEndpoint.Emitir);
        /// <summary>19 - Gerar DAS avulso.</summary>
        public static readonly ServicoIntegraContador GerarDasAvulso = new("PGDASD", "GERARDASAVULSO19", "1.0", TipoEndpoint.Emitir);
    }

    /// <summary>Integra-SN: Regime de Apuração (caixa / competência).</summary>
    public static class RegimeApuracao
    {
        /// <summary>101 - Efetuar a opção pelo regime de apuração.</summary>
        public static readonly ServicoIntegraContador EfetuarOpcao = new("REGIMEAPURACAO", "EFETUAROPCAOREGIME101", "1.0", TipoEndpoint.Declarar);
        /// <summary>102 - Consultar anos-calendário com opção efetuada.</summary>
        public static readonly ServicoIntegraContador ConsultarAnosCalendario = new("REGIMEAPURACAO", "CONSULTARANOSCALENDARIOS102", "1.0", TipoEndpoint.Consultar);
        /// <summary>103 - Consultar a opção pelo regime.</summary>
        public static readonly ServicoIntegraContador ConsultarOpcao = new("REGIMEAPURACAO", "CONSULTAROPCAOREGIME103", "1.0", TipoEndpoint.Consultar);
        /// <summary>104 - Consultar a resolução do regime de caixa.</summary>
        public static readonly ServicoIntegraContador ConsultarResolucao = new("REGIMEAPURACAO", "CONSULTARRESOLUCAO104", "1.0", TipoEndpoint.Consultar);
    }

    /// <summary>Integra-SN: DEFIS (Declaração de Informações Socioeconômicas e Fiscais).</summary>
    public static class Defis
    {
        /// <summary>141 - Transmitir declaração.</summary>
        public static readonly ServicoIntegraContador TransmitirDeclaracao = new("DEFIS", "TRANSDECLARACAO141", "1.0", TipoEndpoint.Declarar);
        /// <summary>142 - Consultar declarações transmitidas.</summary>
        public static readonly ServicoIntegraContador ConsultarDeclaracoes = new("DEFIS", "CONSDECLARACAO142", "1.0", TipoEndpoint.Consultar);
        /// <summary>143 - Consultar a última declaração/recibo transmitida.</summary>
        public static readonly ServicoIntegraContador ConsultarUltimaDeclaracao = new("DEFIS", "CONSULTIMADECREC143", "1.0", TipoEndpoint.Consultar);
        /// <summary>144 - Consultar declaração/recibo específica.</summary>
        public static readonly ServicoIntegraContador ConsultarDeclaracao = new("DEFIS", "CONSDECREC144", "1.0", TipoEndpoint.Consultar);
    }

    /// <summary>Integra-MEI: PGMEI (Programa Gerador do DAS do MEI).</summary>
    public static class Pgmei
    {
        /// <summary>21 - Gerar DAS (PDF).</summary>
        public static readonly ServicoIntegraContador GerarDasPdf = new("PGMEI", "GERARDASPDF21", "1.0", TipoEndpoint.Emitir);
        /// <summary>22 - Gerar DAS (código de barras).</summary>
        public static readonly ServicoIntegraContador GerarDasCodigoBarras = new("PGMEI", "GERARDASCODBARRA22", "1.0", TipoEndpoint.Emitir);
        /// <summary>23 - Atualizar benefício.</summary>
        public static readonly ServicoIntegraContador AtualizarBeneficio = new("PGMEI", "ATUBENEFICIO23", "1.0", TipoEndpoint.Emitir);
        /// <summary>24 - Consultar dívida ativa.</summary>
        public static readonly ServicoIntegraContador ConsultarDividaAtiva = new("PGMEI", "DIVIDAATIVA24", "1.0", TipoEndpoint.Consultar);
    }

    /// <summary>Integra-MEI: CCMEI (Certificado da Condição de Microempreendedor Individual).</summary>
    public static class Ccmei
    {
        /// <summary>121 - Emitir CCMEI (PDF).</summary>
        public static readonly ServicoIntegraContador Emitir = new("CCMEI", "EMITIRCCMEI121", "1.0", TipoEndpoint.Emitir);
        /// <summary>122 - Consultar dados do CCMEI.</summary>
        public static readonly ServicoIntegraContador ConsultarDados = new("CCMEI", "DADOSCCMEI122", "1.0", TipoEndpoint.Consultar);
        /// <summary>123 - Consultar situação cadastral dos CNPJs MEI vinculados ao CPF.</summary>
        public static readonly ServicoIntegraContador ConsultarSituacaoCadastral = new("CCMEI", "CCMEISITCADASTRAL123", "1.0", TipoEndpoint.Consultar);
    }

    /// <summary>Integra-DCTFWeb: DCTFWeb.</summary>
    public static class DctfWeb
    {
        /// <summary>31 - Gerar guia (DARF).</summary>
        public static readonly ServicoIntegraContador GerarGuia = new("DCTFWEB", "GERARGUIA31", "1.0", TipoEndpoint.Emitir);
        /// <summary>32 - Consultar recibo de transmissão.</summary>
        public static readonly ServicoIntegraContador ConsultarRecibo = new("DCTFWEB", "CONSRECIBO32", "1.0", TipoEndpoint.Consultar);
        /// <summary>33 - Consultar declaração completa.</summary>
        public static readonly ServicoIntegraContador ConsultarDeclaracaoCompleta = new("DCTFWEB", "CONSDECCOMPLETA33", "1.0", TipoEndpoint.Consultar);
        /// <summary>38 - Consultar XML da declaração.</summary>
        public static readonly ServicoIntegraContador ConsultarXmlDeclaracao = new("DCTFWEB", "CONSXMLDECLARACAO38", "1.0", TipoEndpoint.Consultar);
        /// <summary>310 - Transmitir declaração.</summary>
        public static readonly ServicoIntegraContador TransmitirDeclaracao = new("DCTFWEB", "TRANSDECLARACAO310", "1.0", TipoEndpoint.Declarar);
        /// <summary>313 - Gerar guia de declaração em andamento.</summary>
        public static readonly ServicoIntegraContador GerarGuiaEmAndamento = new("DCTFWEB", "GERARGUIAANDAMENTO313", "1.0", TipoEndpoint.Emitir);
    }

    /// <summary>Integra-DCTFWeb: MIT (Módulo de Inclusão de Tributos).</summary>
    public static class Mit
    {
        /// <summary>314 - Encerrar apuração.</summary>
        public static readonly ServicoIntegraContador EncerrarApuracao = new("MIT", "ENCAPURACAO314", "1.0", TipoEndpoint.Declarar);
        /// <summary>315 - Consultar situação do encerramento.</summary>
        public static readonly ServicoIntegraContador SituacaoEncerramento = new("MIT", "SITUACAOENC315", "1.0", TipoEndpoint.Apoiar);
        /// <summary>316 - Consultar apuração.</summary>
        public static readonly ServicoIntegraContador ConsultarApuracao = new("MIT", "CONSAPURACAO316", "1.0", TipoEndpoint.Consultar);
        /// <summary>317 - Listar apurações por ano/mês.</summary>
        public static readonly ServicoIntegraContador ListarApuracoes = new("MIT", "LISTAAPURACOES317", "1.0", TipoEndpoint.Consultar);
    }

    /// <summary>Integra-Procurações.</summary>
    public static class Procuracoes
    {
        /// <summary>41 - Obter procurações eletrônicas.</summary>
        public static readonly ServicoIntegraContador ObterProcuracao = new("PROCURACOES", "OBTERPROCURACAO41", "1", TipoEndpoint.Consultar);
    }

    /// <summary>Integra-Sicalc.</summary>
    public static class Sicalc
    {
        /// <summary>51 - Consolidar e emitir DARF (PDF).</summary>
        public static readonly ServicoIntegraContador ConsolidarGerarDarf = new("SICALC", "CONSOLIDARGERARDARF51", "2.9", TipoEndpoint.Emitir);
        /// <summary>52 - Apoio: consultar receitas do Sicalc.</summary>
        public static readonly ServicoIntegraContador ConsultarReceitas = new("SICALC", "CONSULTAAPOIORECEITAS52", "2.9", TipoEndpoint.Apoiar);
        /// <summary>53 - Consolidar e emitir DARF (código de barras).</summary>
        public static readonly ServicoIntegraContador GerarDarfCodigoBarras = new("SICALC", "GERARDARFCODBARRA53", "2.9", TipoEndpoint.Emitir);
        /// <summary>54 - Consolidar sem emitir DARF (sem página de detalhamento publicada; versão presumida).</summary>
        public static readonly ServicoIntegraContador Consolidar = new("SICALC", "CONSOLIDAR54", "2.9", TipoEndpoint.Consultar);
    }

    /// <summary>Integra-CaixaPostal: Caixa Postal do e-CAC.</summary>
    public static class CaixaPostal
    {
        /// <summary>61 - Obter lista de mensagens.</summary>
        public static readonly ServicoIntegraContador ListarMensagens = new("CAIXAPOSTAL", "MSGCONTRIBUINTE61", "1.0", TipoEndpoint.Consultar);
        /// <summary>62 - Obter detalhes de uma mensagem.</summary>
        public static readonly ServicoIntegraContador DetalharMensagem = new("CAIXAPOSTAL", "MSGDETALHAMENTO62", "1.0", TipoEndpoint.Consultar);
        /// <summary>63 - Obter indicador de novas mensagens.</summary>
        public static readonly ServicoIntegraContador IndicadorNovasMensagens = new("CAIXAPOSTAL", "INNOVAMSG63", "1.0", TipoEndpoint.Monitorar);
    }

    /// <summary>Integra-CaixaPostal: DTE (Domicílio Tributário Eletrônico).</summary>
    public static class Dte
    {
        /// <summary>111 - Consultar situação do DTE.</summary>
        public static readonly ServicoIntegraContador ConsultarSituacao = new("DTE", "CONSULTASITUACAODTE111", "1.0", TipoEndpoint.Consultar);
    }

    /// <summary>Integra-Pagamento: PagtoWeb.</summary>
    public static class PagtoWeb
    {
        /// <summary>71 - Consultar pagamentos.</summary>
        public static readonly ServicoIntegraContador ConsultarPagamentos = new("PAGTOWEB", "PAGAMENTOS71", "1.0", TipoEndpoint.Consultar);
        /// <summary>72 - Emitir comprovante de arrecadação.</summary>
        public static readonly ServicoIntegraContador EmitirComprovante = new("PAGTOWEB", "COMPARRECADACAO72", "1.0", TipoEndpoint.Emitir);
        /// <summary>73 - Contar documentos de arrecadação pagos.</summary>
        public static readonly ServicoIntegraContador ContarPagamentos = new("PAGTOWEB", "CONTACONSDOCARRPG73", "1.0", TipoEndpoint.Consultar);
    }

    /// <summary>Integra-Contador-Gerenciador: Autenticação de Procurador.</summary>
    public static class AutenticaProcurador
    {
        /// <summary>81 - Enviar termo de autorização assinado (obtém o token do procurador).</summary>
        public static readonly ServicoIntegraContador EnviarXmlAssinado = new("AUTENTICAPROCURADOR", "ENVIOXMLASSINADO81", "1.0", TipoEndpoint.Apoiar);
    }

    /// <summary>Integra-Contador-Gerenciador: Eventos de Atualização.</summary>
    public static class EventosAtualizacao
    {
        /// <summary>131 - Solicitar eventos de pessoas físicas.</summary>
        public static readonly ServicoIntegraContador SolicitarEventosPF = new("EVENTOSATUALIZACAO", "SOLICEVENTOSPF131", "1.0", TipoEndpoint.Monitorar);
        /// <summary>132 - Solicitar eventos de pessoas jurídicas.</summary>
        public static readonly ServicoIntegraContador SolicitarEventosPJ = new("EVENTOSATUALIZACAO", "SOLICEVENTOSPJ132", "1.0", TipoEndpoint.Monitorar);
        /// <summary>133 - Obter eventos de pessoas físicas.</summary>
        public static readonly ServicoIntegraContador ObterEventosPF = new("EVENTOSATUALIZACAO", "OBTEREVENTOSPF133", "1.0", TipoEndpoint.Monitorar);
        /// <summary>134 - Obter eventos de pessoas jurídicas.</summary>
        public static readonly ServicoIntegraContador ObterEventosPJ = new("EVENTOSATUALIZACAO", "OBTEREVENTOSPJ134", "1.0", TipoEndpoint.Monitorar);
    }

    /// <summary>Integra-SITFIS: Relatório de Situação Fiscal.</summary>
    public static class Sitfis
    {
        /// <summary>91 - Solicitar protocolo do relatório.</summary>
        public static readonly ServicoIntegraContador SolicitarProtocolo = new("SITFIS", "SOLICITARPROTOCOLO91", "2.0", TipoEndpoint.Apoiar);
        /// <summary>92 - Emitir relatório de situação fiscal.</summary>
        public static readonly ServicoIntegraContador EmitirRelatorio = new("SITFIS", "RELATORIOSITFIS92", "2.0", TipoEndpoint.Emitir);
    }

    /// <summary>Integra-Redesim: PNR Contador (renúncia de responsabilidade contábil).</summary>
    public static class PnrContador
    {
        /// <summary>261 - Consultar vínculos.</summary>
        public static readonly ServicoIntegraContador ConsultarVinculos = new("PNRCONTADOR", "CONSVINCULOS261", "1.0", TipoEndpoint.Consultar);
        /// <summary>262 - Solicitar renúncia.</summary>
        public static readonly ServicoIntegraContador SolicitarRenuncia = new("PNRCONTADOR", "SOLICRENUNCIA262", "1.0", TipoEndpoint.Declarar);
        /// <summary>263 - Consultar renúncias.</summary>
        public static readonly ServicoIntegraContador ConsultarRenuncias = new("PNRCONTADOR", "CONSRENUNCIA263", "1.0", TipoEndpoint.Consultar);
        /// <summary>264 - Emitir comprovante de renúncia.</summary>
        public static readonly ServicoIntegraContador EmitirComprovanteRenuncia = new("PNRCONTADOR", "COMPRENUNCIA264", "1.0", TipoEndpoint.Emitir);
        /// <summary>265 - Consultar situação da solicitação de renúncia.</summary>
        public static readonly ServicoIntegraContador SituacaoSolicitacaoRenuncia = new("PNRCONTADOR", "SITSOLICRENUNCIA265", "1.0", TipoEndpoint.Consultar);
    }

    /// <summary>Integra-e-Processo.</summary>
    public static class EProcesso
    {
        /// <summary>271 - Consultar processos por interessado.</summary>
        public static readonly ServicoIntegraContador ConsultarProcessos = new("EPROCESSO", "CONSPROCPORINTER271", "2.0", TipoEndpoint.Consultar);
    }

    /// <summary>Integra-Parcelamento: serviços de cada modalidade de parcelamento.</summary>
    public static class Parcelamento
    {
        private static readonly Dictionary<ModalidadeParcelamento, ServicosParcelamento> _servicos = new()
        {
            [ModalidadeParcelamento.PARCSN] = Criar("PARCSN", 16),
            [ModalidadeParcelamento.PARCSN_ESP] = Criar("PARCSN-ESP", 17),
            [ModalidadeParcelamento.PERTSN] = Criar("PERTSN", 18),
            [ModalidadeParcelamento.RELPSN] = Criar("RELPSN", 19),
            [ModalidadeParcelamento.PARCMEI] = Criar("PARCMEI", 20),
            [ModalidadeParcelamento.PARCMEI_ESP] = Criar("PARCMEI-ESP", 21),
            [ModalidadeParcelamento.PERTMEI] = Criar("PERTMEI", 22),
            [ModalidadeParcelamento.RELPMEI] = Criar("RELPMEI", 23)
        };

        /// <summary>Serviços (GERARDAS, PARCELASPARAGERAR, PEDIDOSPARC, OBTERPARC, DETPAGTOPARC) da modalidade.</summary>
        public static ServicosParcelamento Servicos(ModalidadeParcelamento modalidade) => _servicos[modalidade];

        private static ServicosParcelamento Criar(string idSistema, int prefixo) => new(
            new(idSistema, $"GERARDAS{prefixo}1", "1.0", TipoEndpoint.Emitir),
            new(idSistema, $"PARCELASPARAGERAR{prefixo}2", "1.0", TipoEndpoint.Consultar),
            new(idSistema, $"PEDIDOSPARC{prefixo}3", "1.0", TipoEndpoint.Consultar),
            new(idSistema, $"OBTERPARC{prefixo}4", "1.0", TipoEndpoint.Consultar),
            new(idSistema, $"DETPAGTOPARC{prefixo}5", "1.0", TipoEndpoint.Consultar));
    }
}
