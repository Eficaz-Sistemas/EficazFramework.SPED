using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraSN;

#region TRANSDECLARACAO11 - Entregar declaração mensal

/// <summary>
/// Entrada do serviço PGDASD / TRANSDECLARACAO11: transmissão de uma declaração do Simples Nacional, original ou retificadora.
/// </summary>
public sealed class TransmitirDeclaracao
{
    /// <summary>CNPJ completo, sem formatação.</summary>
    [JsonPropertyName("cnpjCompleto")]
    public string CnpjCompleto { get; set; } = string.Empty;

    /// <summary>Período de apuração da declaração no formato AAAAMM.</summary>
    [JsonPropertyName("pa")]
    public int Pa { get; set; }

    /// <summary>
    /// Indica se a declaração deve ser transmitida. Quando <c>false</c>, são devolvidos os valores devidos sem transmissão.
    /// </summary>
    [JsonPropertyName("indicadorTransmissao")]
    public bool IndicadorTransmissao { get; set; }

    /// <summary>
    /// Indica se os <see cref="ValoresParaComparacao"/> devem ser comparados com os valores calculados antes da transmissão
    /// (devem ser exatamente iguais; diferença de 0,01 impede a transmissão).
    /// </summary>
    [JsonPropertyName("indicadorComparacao")]
    public bool IndicadorComparacao { get; set; }

    /// <summary>Dados da declaração.</summary>
    [JsonPropertyName("declaracao")]
    public DeclaracaoPgdasd Declaracao { get; set; } = new();

    /// <summary>
    /// Valores para comparação com o valor apurado pelo sistema. Obrigatório, exceto quando não há valor devido.
    /// </summary>
    [JsonPropertyName("valoresParaComparacao")]
    public List<ValorDevido>? ValoresParaComparacao { get; set; }
}

/// <summary>
/// Dados da declaração do PGDAS-D (objeto <c>declaracao</c> do TRANSDECLARACAO11).
/// </summary>
public sealed class DeclaracaoPgdasd
{
    /// <summary>Tipo da declaração (ver dados de domínio do PGDAS-D: 1 - Original; 2 - Retificadora).</summary>
    [JsonPropertyName("tipoDeclaracao")]
    public int TipoDeclaracao { get; set; }

    /// <summary>Receita do mercado interno no PA, regime de competência.</summary>
    [JsonPropertyName("receitaPaCompetenciaInterno")]
    public decimal ReceitaPaCompetenciaInterno { get; set; }

    /// <summary>Receita do mercado externo no PA, regime de competência.</summary>
    [JsonPropertyName("receitaPaCompetenciaExterno")]
    public decimal ReceitaPaCompetenciaExterno { get; set; }

    /// <summary>Receita do mercado interno no PA, regime de caixa.</summary>
    [JsonPropertyName("receitaPaCaixaInterno")]
    public decimal? ReceitaPaCaixaInterno { get; set; }

    /// <summary>Receita do mercado externo no PA, regime de caixa.</summary>
    [JsonPropertyName("receitaPaCaixaExterno")]
    public decimal? ReceitaPaCaixaExterno { get; set; }

    /// <summary>Valor fixo de ICMS (deve ser maior que zero e obedecer às regras de negócio).</summary>
    [JsonPropertyName("valorFixoIcms")]
    public decimal? ValorFixoIcms { get; set; }

    /// <summary>Valor fixo de ISS (deve ser maior que zero e obedecer às regras de negócio).</summary>
    [JsonPropertyName("valorFixoIss")]
    public decimal? ValorFixoIss { get; set; }

    /// <summary>Receitas brutas de períodos anteriores.</summary>
    [JsonPropertyName("receitasBrutasAnteriores")]
    public List<ReceitaBrutaAnterior>? ReceitasBrutasAnteriores { get; set; }

    /// <summary>Valores de folha de salário.</summary>
    [JsonPropertyName("folhasSalario")]
    public List<FolhaSalario>? FolhasSalario { get; set; }

    /// <summary>Informações de não optante.</summary>
    [JsonPropertyName("naoOptante")]
    public NaoOptante? NaoOptante { get; set; }

    /// <summary>
    /// Estabelecimentos da declaração: devem constar todos os estabelecimentos vigentes à época do período de apuração.
    /// </summary>
    [JsonPropertyName("estabelecimentos")]
    public List<Estabelecimento> Estabelecimentos { get; set; } = [];
}

/// <summary>
/// Receita bruta de período anterior.
/// </summary>
public sealed class ReceitaBrutaAnterior
{
    /// <summary>Período de apuração no formato AAAAMM.</summary>
    [JsonPropertyName("pa")]
    public int Pa { get; set; }

    /// <summary>Valor no mercado interno.</summary>
    [JsonPropertyName("valorInterno")]
    public decimal ValorInterno { get; set; }

    /// <summary>Valor no mercado externo.</summary>
    [JsonPropertyName("valorExterno")]
    public decimal ValorExterno { get; set; }
}

/// <summary>
/// Valor de folha de salário de um período.
/// </summary>
public sealed class FolhaSalario
{
    /// <summary>Período de apuração no formato AAAAMM.</summary>
    [JsonPropertyName("pa")]
    public int Pa { get; set; }

    /// <summary>Valor.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}

/// <summary>
/// Informações de não optante da declaração do PGDAS-D.
/// </summary>
public sealed class NaoOptante
{
    /// <summary>Esfera administrativa: 1 - Federal; 2 - Distrital; 3 - Estadual; 4 - Municipal.</summary>
    [JsonPropertyName("esferaAdm")]
    public string EsferaAdm { get; set; } = string.Empty;

    /// <summary>UF do processo.</summary>
    [JsonPropertyName("uf")]
    public string Uf { get; set; } = string.Empty;

    /// <summary>Código do município do processo.</summary>
    [JsonPropertyName("codMunicipio")]
    public string CodMunicipio { get; set; } = string.Empty;

    /// <summary>Nome do município do processo (consta apenas no schema de entrada).</summary>
    [JsonPropertyName("nomeMunicipio")]
    public string? NomeMunicipio { get; set; }

    /// <summary>Número do processo, sem formatação.</summary>
    [JsonPropertyName("processo")]
    public string Processo { get; set; } = string.Empty;
}

/// <summary>
/// Estabelecimento da declaração do PGDAS-D.
/// </summary>
public sealed class Estabelecimento
{
    /// <summary>CNPJ do estabelecimento, sem formatação.</summary>
    [JsonPropertyName("cnpjCompleto")]
    public string CnpjCompleto { get; set; } = string.Empty;

    /// <summary>Atividades do estabelecimento (não enviar quando não houve atividade).</summary>
    [JsonPropertyName("atividades")]
    public List<Atividade>? Atividades { get; set; }
}

/// <summary>
/// Atividade de um estabelecimento da declaração do PGDAS-D.
/// </summary>
public sealed class Atividade
{
    /// <summary>Identificador da atividade.</summary>
    [JsonPropertyName("idAtividade")]
    public int IdAtividade { get; set; }

    /// <summary>Valor da atividade.</summary>
    [JsonPropertyName("valorAtividade")]
    public decimal ValorAtividade { get; set; }

    /// <summary>Parcelas de receita da atividade.</summary>
    [JsonPropertyName("receitasAtividade")]
    public List<ReceitaAtividade> ReceitasAtividade { get; set; } = [];
}

/// <summary>
/// Parcela de receita de uma atividade.
/// </summary>
public sealed class ReceitaAtividade
{
    /// <summary>Valor da parcela.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Código (TOM) do município, no caso de atividade em outro município. A tabela de campos indica String, mas o
    /// exemplo e o schema de entrada usam número.
    /// </summary>
    [JsonPropertyName("codigoOutroMunicipio")]
    public int? CodigoOutroMunicipio { get; set; }

    /// <summary>UF, no caso de atividade em outro município/UF.</summary>
    [JsonPropertyName("outraUf")]
    public string? OutraUf { get; set; }

    /// <summary>Informações de isenção.</summary>
    [JsonPropertyName("isencoes")]
    public List<Isencao>? Isencoes { get; set; }

    /// <summary>Informações de redução.</summary>
    [JsonPropertyName("reducoes")]
    public List<Reducao>? Reducoes { get; set; }

    /// <summary>Informações de qualificação tributária.</summary>
    [JsonPropertyName("qualificacoesTributarias")]
    public List<QualificacaoTributaria>? QualificacoesTributarias { get; set; }

    /// <summary>Informações de exigibilidade suspensa.</summary>
    [JsonPropertyName("exigibilidadesSuspensas")]
    public List<ExigibilidadeSuspensa>? ExigibilidadesSuspensas { get; set; }
}

/// <summary>
/// Isenção aplicada a uma parcela de receita.
/// </summary>
public sealed class Isencao
{
    /// <summary>Código do tributo.</summary>
    [JsonPropertyName("codTributo")]
    public int CodTributo { get; set; }

    /// <summary>Valor da isenção.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>Identificador do tipo de isenção.</summary>
    [JsonPropertyName("identificador")]
    public int Identificador { get; set; }
}

/// <summary>
/// Redução aplicada a uma parcela de receita.
/// </summary>
public sealed class Reducao
{
    /// <summary>Código do tributo.</summary>
    [JsonPropertyName("codTributo")]
    public int CodTributo { get; set; }

    /// <summary>Valor da redução.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>Percentual da redução.</summary>
    [JsonPropertyName("percentualReducao")]
    public decimal PercentualReducao { get; set; }

    /// <summary>Identificador do tipo de redução.</summary>
    [JsonPropertyName("identificador")]
    public int Identificador { get; set; }
}

/// <summary>
/// Qualificação tributária de uma parcela de receita.
/// </summary>
public sealed class QualificacaoTributaria
{
    /// <summary>Código do tributo.</summary>
    [JsonPropertyName("codigoTributo")]
    public int CodigoTributo { get; set; }

    /// <summary>Identificador da qualificação.</summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }
}

/// <summary>
/// Exigibilidade suspensa de uma parcela de receita.
/// </summary>
public sealed class ExigibilidadeSuspensa
{
    /// <summary>Código do tributo.</summary>
    [JsonPropertyName("codTributo")]
    public int CodTributo { get; set; }

    /// <summary>Número do processo da exigibilidade suspensa (String no schema de entrada).</summary>
    [JsonPropertyName("numeroProcesso")]
    public string NumeroProcesso { get; set; } = string.Empty;

    /// <summary>Código do município da exigibilidade suspensa.</summary>
    [JsonPropertyName("codMunicipio")]
    public string? CodMunicipio { get; set; }

    /// <summary>UF da exigibilidade suspensa.</summary>
    [JsonPropertyName("uf")]
    public string Uf { get; set; } = string.Empty;

    /// <summary>Vara do processo da exigibilidade suspensa.</summary>
    [JsonPropertyName("vara")]
    public string Vara { get; set; } = string.Empty;

    /// <summary>Indicador de existência de depósito.</summary>
    [JsonPropertyName("existeDeposito")]
    public bool ExisteDeposito { get; set; }

    /// <summary>Motivo da exigibilidade suspensa.</summary>
    [JsonPropertyName("motivo")]
    public int Motivo { get; set; }
}

/// <summary>
/// Valor devido de um tributo (comparação na entrada e valores calculados na saída do TRANSDECLARACAO11).
/// </summary>
public sealed class ValorDevido
{
    /// <summary>Código do tributo.</summary>
    [JsonPropertyName("codigoTributo")]
    public int CodigoTributo { get; set; }

    /// <summary>Valor devido do tributo.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}

/// <summary>
/// Retorno do serviço PGDASD / TRANSDECLARACAO11: declaração transmitida (ou apenas calculada).
/// </summary>
public sealed class DeclaracaoTransmitida
{
    /// <summary>Identificador da declaração transmitida.</summary>
    [JsonPropertyName("idDeclaracao")]
    public string? IdDeclaracao { get; set; }

    /// <summary>Data e hora da transmissão no formato AAAAMMDDHHmmSS.</summary>
    [JsonPropertyName("dataHoraTransmissao")]
    public string? DataHoraTransmissao { get; set; }

    /// <summary>Valores devidos calculados pelo sistema.</summary>
    [JsonPropertyName("valoresDevidos")]
    public List<ValorDevido>? ValoresDevidos { get; set; }

    /// <summary>PDF da declaração, em Base64.</summary>
    [JsonPropertyName("declaracao")]
    public string? Declaracao { get; set; }

    /// <summary>PDF do recibo, em Base64.</summary>
    [JsonPropertyName("recibo")]
    public string? Recibo { get; set; }

    /// <summary>PDF da notificação da MAED, em Base64 (nulo quando não há MAED).</summary>
    [JsonPropertyName("notificacaoMaed")]
    public string? NotificacaoMaed { get; set; }

    /// <summary>PDF do DARF da MAED, em Base64 (nulo quando não há MAED).</summary>
    [JsonPropertyName("darf")]
    public string? Darf { get; set; }

    /// <summary>Detalhamento dos valores do DARF da MAED.</summary>
    [JsonPropertyName("detalhamentoDarfMaed")]
    public DetalhamentoDas? DetalhamentoDarfMaed { get; set; }
}

#endregion

#region GERARDAS12 - Gerar DAS

/// <summary>
/// Entrada do serviço PGDASD / GERARDAS12: geração do DAS de uma declaração previamente transmitida.
/// </summary>
public sealed class GerarDas
{
    /// <summary>Período de apuração no formato AAAAMM.</summary>
    [JsonPropertyName("periodoApuracao")]
    public string PeriodoApuracao { get; set; } = string.Empty;

    /// <summary>Data de consolidação (futura) no formato AAAAMMDD.</summary>
    [JsonPropertyName("dataConsolidacao")]
    public string? DataConsolidacao { get; set; }
}

#endregion

#region CONSDECLARACAO13 - Consultar declarações transmitidas

/// <summary>
/// Entrada do serviço PGDASD / CONSDECLARACAO13: informe o ano-calendário <b>ou</b> o período de apuração.
/// </summary>
public sealed class ConsultarDeclaracoes
{
    /// <summary>Ano-calendário (AAAA), quando a consulta for por ano-calendário.</summary>
    [JsonPropertyName("anoCalendario")]
    public string? AnoCalendario { get; set; }

    /// <summary>Período de apuração (AAAAMM), quando a consulta for por período de apuração.</summary>
    [JsonPropertyName("periodoApuracao")]
    public string? PeriodoApuracao { get; set; }
}

/// <summary>
/// Retorno do serviço PGDASD / CONSDECLARACAO13: índice das declarações transmitidas.
/// </summary>
public sealed class DeclaracoesEntregues
{
    /// <summary>Ano-calendário.</summary>
    [JsonPropertyName("anoCalendario")]
    public int? AnoCalendario { get; set; }

    /// <summary>Períodos de apuração (consulta por ano-calendário).</summary>
    [JsonPropertyName("periodos")]
    public List<PeriodoDeclaracoes>? Periodos { get; set; }

    /// <summary>Período de apuração (consulta por período de apuração).</summary>
    [JsonPropertyName("periodo")]
    public PeriodoDeclaracoes? Periodo { get; set; }
}

/// <summary>
/// Operações realizadas em um período de apuração.
/// </summary>
public sealed class PeriodoDeclaracoes
{
    /// <summary>Período de apuração no formato AAAAMM.</summary>
    [JsonPropertyName("periodoApuracao")]
    public int PeriodoApuracao { get; set; }

    /// <summary>Operações realizadas no período de apuração.</summary>
    [JsonPropertyName("operacoes")]
    public List<OperacaoDeclaracao>? Operacoes { get; set; }
}

/// <summary>
/// Operação realizada em um período de apuração (declaração original/retificadora ou geração de DAS).
/// </summary>
public sealed class OperacaoDeclaracao
{
    /// <summary>
    /// Tipo da operação (ex.: Original; Retificadora; Geração de DAS; DAS Avulso; DAS Medida Judicial; DAS Cobrança).
    /// </summary>
    [JsonPropertyName("tipoOperacao")]
    public string? TipoOperacao { get; set; }

    /// <summary>Dados da declaração (operações de declaração).</summary>
    [JsonPropertyName("indiceDeclaracao")]
    public IndiceDeclaracao? IndiceDeclaracao { get; set; }

    /// <summary>Dados do DAS (operações de geração de DAS).</summary>
    [JsonPropertyName("indiceDas")]
    public IndiceDas? IndiceDas { get; set; }
}

/// <summary>
/// Índice de uma declaração transmitida.
/// </summary>
public sealed class IndiceDeclaracao
{
    /// <summary>Identificador único da declaração transmitida.</summary>
    [JsonPropertyName("numeroDeclaracao")]
    public string? NumeroDeclaracao { get; set; }

    /// <summary>
    /// Data e hora da entrega à RFB no formato yyyyMMddHHmmss (texto no exemplo, número na tabela de campos).
    /// </summary>
    [JsonPropertyName("dataHoraTransmissao")]
    public long? DataHoraTransmissao { get; set; }

    /// <summary>
    /// Situação da malha, quando aplicável (Retida em Malha; Liberada; Intimada; Rejeitada); nula ou vazia quando não está em malha.
    /// </summary>
    [JsonPropertyName("malha")]
    public string? Malha { get; set; }
}

/// <summary>
/// Índice de um DAS gerado.
/// </summary>
public sealed class IndiceDas
{
    /// <summary>Número do DAS.</summary>
    [JsonPropertyName("numeroDas")]
    public string? NumeroDas { get; set; }

    /// <summary>
    /// Data e hora da emissão do DAS no formato yyyyMMddHHmmss (texto no exemplo, número na tabela de campos).
    /// </summary>
    [JsonPropertyName("datahoraEmissaoDas")]
    public long? DataHoraEmissaoDas { get; set; }

    /// <summary>Indica se houve pagamento do DAS até o momento da consulta.</summary>
    [JsonPropertyName("dasPago")]
    public bool? DasPago { get; set; }
}

#endregion

#region CONSULTIMADECREC14 / CONSDECREC15 - Consultar declaração/recibo

/// <summary>
/// Entrada do serviço PGDASD / CONSULTIMADECREC14: última declaração/recibo transmitida no período de apuração.
/// </summary>
public sealed class ConsultarUltimaDeclaracao
{
    /// <summary>Período de apuração no formato AAAAMM.</summary>
    [JsonPropertyName("periodoApuracao")]
    public string PeriodoApuracao { get; set; } = string.Empty;
}

/// <summary>
/// Entrada do serviço PGDASD / CONSDECREC15: declaração/recibo específica.
/// </summary>
public sealed class ConsultarDeclaracao
{
    /// <summary>Número identificador único da declaração.</summary>
    [JsonPropertyName("numeroDeclaracao")]
    public string NumeroDeclaracao { get; set; } = string.Empty;
}

/// <summary>
/// Retorno dos serviços PGDASD / CONSULTIMADECREC14 e CONSDECREC15: declaração, recibo e, se houver, MAED.
/// </summary>
public sealed class DeclaracaoRecibo
{
    /// <summary>Identificador único da declaração transmitida.</summary>
    [JsonPropertyName("numeroDeclaracao")]
    public string? NumeroDeclaracao { get; set; }

    /// <summary>Recibo de entrega da declaração (PDF).</summary>
    [JsonPropertyName("recibo")]
    public ArquivoPdf? Recibo { get; set; }

    /// <summary>Declaração entregue (PDF).</summary>
    [JsonPropertyName("declaracao")]
    public ArquivoPdf? Declaracao { get; set; }

    /// <summary>Notificação e DARF da MAED, nos casos de declaração original entregue fora do prazo.</summary>
    [JsonPropertyName("maed")]
    public ArquivoMaed? Maed { get; set; }
}

/// <summary>
/// Arquivo PDF retornado pelo PGDAS-D.
/// </summary>
public sealed class ArquivoPdf
{
    /// <summary>Nome do arquivo, para uso na decodificação do Base64.</summary>
    [JsonPropertyName("nomeArquivo")]
    public string? NomeArquivo { get; set; }

    /// <summary>Conteúdo do PDF, em Base64.</summary>
    [JsonPropertyName("pdf")]
    public string? Pdf { get; set; }
}

/// <summary>
/// Documentos da MAED (Multa por Atraso na Entrega da Declaração).
/// </summary>
public sealed class ArquivoMaed
{
    /// <summary>Nome do arquivo da notificação da MAED.</summary>
    [JsonPropertyName("nomeArquivoNotificacao")]
    public string? NomeArquivoNotificacao { get; set; }

    /// <summary>PDF da notificação da MAED, em Base64.</summary>
    [JsonPropertyName("pdfNotificacao")]
    public string? PdfNotificacao { get; set; }

    /// <summary>Nome do arquivo do DARF da MAED.</summary>
    [JsonPropertyName("nomeArquivoDarf")]
    public string? NomeArquivoDarf { get; set; }

    /// <summary>PDF do DARF da MAED, em Base64.</summary>
    [JsonPropertyName("pdfDarf")]
    public string? PdfDarf { get; set; }
}

#endregion

#region CONSEXTRATO16 - Consultar extrato do DAS

/// <summary>
/// Entrada do serviço PGDASD / CONSEXTRATO16: extrato detalhado de um DAS gerado.
/// </summary>
public sealed class ConsultarExtratoDas
{
    /// <summary>Número do DAS.</summary>
    [JsonPropertyName("numeroDas")]
    public string NumeroDas { get; set; } = string.Empty;
}

/// <summary>
/// Retorno do serviço PGDASD / CONSEXTRATO16.
/// </summary>
public sealed class ExtratoDas
{
    /// <summary>Número do DAS.</summary>
    [JsonPropertyName("numeroDas")]
    public string? NumeroDas { get; set; }

    /// <summary>Extrato do DAS (PDF).</summary>
    [JsonPropertyName("extrato")]
    public ArquivoPdf? Extrato { get; set; }
}

#endregion

#region GERARDASCOBRANCA17 / GERARDASPROCESSO18 / GERARDASAVULSO19

/// <summary>
/// Entrada do serviço PGDASD / GERARDASCOBRANCA17: DAS com os débitos em sistema de cobrança.
/// </summary>
public sealed class GerarDasCobranca
{
    /// <summary>
    /// Período de apuração no formato AAAAMM (texto no exemplo da documentação, número na tabela de campos).
    /// </summary>
    [JsonPropertyName("periodoApuracao")]
    public string PeriodoApuracao { get; set; } = string.Empty;
}

/// <summary>
/// Entrada do serviço PGDASD / GERARDASPROCESSO18: DAS com os débitos de processo em sistema de cobrança.
/// </summary>
public sealed class GerarDasProcesso
{
    /// <summary>Número do processo (17 dígitos, sem formatação).</summary>
    [JsonPropertyName("numeroProcesso")]
    public string NumeroProcesso { get; set; } = string.Empty;
}

/// <summary>
/// Entrada do serviço PGDASD / GERARDASAVULSO19: DAS avulso.
/// </summary>
public sealed class GerarDasAvulso
{
    /// <summary>Período de apuração no formato AAAAMM (número no exemplo da documentação).</summary>
    [JsonPropertyName("periodoApuracao")]
    public int PeriodoApuracao { get; set; }

    /// <summary>Tributos a incluir no DAS avulso.</summary>
    [JsonPropertyName("listaTributos")]
    public List<TributoDasAvulso> ListaTributos { get; set; } = [];

    /// <summary>Data da emissão (AAAAMMDD); não informar quando a emissão for no próprio dia.</summary>
    [JsonPropertyName("dataConsolidacao")]
    public int? DataConsolidacao { get; set; }

    /// <summary>
    /// Indicador de prorrogação especial (somente para os períodos prorrogados entre 03/2020 e 05/2020 ou 03/2021 e 05/2021).
    /// </summary>
    [JsonPropertyName("prorrogacaoEspecial")]
    public int? ProrrogacaoEspecial { get; set; }
}

/// <summary>
/// Tributo do DAS avulso.
/// </summary>
public sealed class TributoDasAvulso
{
    /// <summary>Código do tributo.</summary>
    [JsonPropertyName("codigo")]
    public int Codigo { get; set; }

    /// <summary>Valor do tributo.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>Código do município (TOM); obrigatório para o ISS.</summary>
    [JsonPropertyName("codMunicipio")]
    public int? CodMunicipio { get; set; }

    /// <summary>UF de destino; obrigatória para o ICMS.</summary>
    [JsonPropertyName("uf")]
    public string? Uf { get; set; }
}

#endregion
