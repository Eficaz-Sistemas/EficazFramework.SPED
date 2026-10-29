using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraSicalc;

// ENTRADAS

/// <summary>
/// Entrada dos serviços de consolidação do Sicalc: CONSOLIDARGERARDARF51 (Darf em PDF), GERARDARFCODBARRA53
/// (código de barras) e CONSOLIDAR54 (somente cálculo dos acréscimos legais).
/// </summary>
/// <remarks>
/// <para>Os campos numéricos são enviados como texto, conforme os exemplos da documentação (ex.: <c>"valorImposto": "1000.00"</c>).</para>
/// <para>Use o serviço CONSULTAAPOIORECEITAS52 para saber quais campos são obrigatórios/opcionais para a receita.</para>
/// <para><see cref="Cota"/> e <see cref="Vencimento"/> são mutuamente excludentes; <see cref="GanhoCapital"/> e
/// <see cref="DataAlienacao"/> são obrigatórios para a receita 4600-02.</para>
/// </remarks>
[JsonNumberHandling(JsonNumberHandling.WriteAsString | JsonNumberHandling.AllowReadingFromString)]
public sealed class ConsolidarDarf
{
    /// <summary>Unidade Federativa (sigla). Quando não informada, podem ser usados os dados cadastrais do contribuinte.</summary>
    [JsonPropertyName("uf")]
    public string? Uf { get; set; }

    /// <summary>
    /// Código do município de domicílio na Tabela de Órgãos e Municípios (TOM) da RFB, sem o dígito verificador
    /// (ex.: 9701 para Brasília). Códigos IBGE não são aceitos.
    /// </summary>
    [JsonPropertyName("municipio")]
    public string? Municipio { get; set; }

    /// <summary>Código da receita (Tabela de Receitas da RFB), ex.: 0190.</summary>
    [JsonPropertyName("codigoReceita")]
    public string CodigoReceita { get; set; } = string.Empty;

    /// <summary>Código da extensão da receita (Tabela de Receitas da RFB), ex.: 01.</summary>
    [JsonPropertyName("codigoReceitaExtensao")]
    public string CodigoReceitaExtensao { get; set; } = string.Empty;

    /// <summary>Número de referência do Darf (obrigatório quando a receita o exige, ex.: NIRF do ITR).</summary>
    [JsonPropertyName("numeroReferencia")]
    public string? NumeroReferencia { get; set; }

    /// <summary>
    /// Tipo do período de apuração: <br/>
    /// AN - anual <br/>
    /// TR - trimestral <br/>
    /// ME - mensal <br/>
    /// QZ - quinzenal <br/>
    /// DC - decendial <br/>
    /// SM - semanal <br/>
    /// DI - diário <br/>
    /// </summary>
    [JsonPropertyName("tipoPA")]
    public string? TipoPA { get; set; }

    /// <summary>
    /// Data do período de apuração, no formato do <see cref="TipoPA"/>: aaaa (anual), trimestre/aaaa, mm/aaaa (mensal),
    /// quinzena/mm/aaaa, decêndio/mm/aaaa, semana/mm/aaaa ou dd/mm/aaaa (diário).
    /// </summary>
    [JsonPropertyName("dataPA")]
    public string DataPA { get; set; } = string.Empty;

    /// <summary>Data de vencimento do tributo (não enviar junto com <see cref="Cota"/>).</summary>
    [JsonPropertyName("vencimento")]
    [JsonConverter(typeof(DataHoraSicalcJsonConverter))]
    public DateTime? Vencimento { get; set; }

    /// <summary>Número da cota, para débitos que possuem cotas (não enviar junto com <see cref="Vencimento"/>).</summary>
    [JsonPropertyName("cota")]
    public int? Cota { get; set; }

    /// <summary>Valor do imposto.</summary>
    [JsonPropertyName("valorImposto")]
    public decimal ValorImposto { get; set; }

    /// <summary>Valor da multa - preenchido somente no caso de Darf manual.</summary>
    [JsonPropertyName("valorMulta")]
    public decimal? ValorMulta { get; set; }

    /// <summary>Valor dos juros - preenchido somente no caso de Darf manual.</summary>
    [JsonPropertyName("valorJuros")]
    public decimal? ValorJuros { get; set; }

    /// <summary>Indicador de ganho de capital.</summary>
    [JsonPropertyName("ganhoCapital")]
    public bool? GanhoCapital { get; set; }

    /// <summary>Data da alienação referente ao ganho de capital.</summary>
    [JsonPropertyName("dataAlienacao")]
    [JsonConverter(typeof(DataHoraSicalcJsonConverter))]
    public DateTime? DataAlienacao { get; set; }

    /// <summary>Data da consolidação/arrecadação (data prevista para pagamento).</summary>
    [JsonPropertyName("dataConsolidacao")]
    [JsonConverter(typeof(DataHoraSicalcJsonConverter))]
    public DateTime? DataConsolidacao { get; set; } = DateTime.Today;

    /// <summary>Texto adicionado ao Darf.</summary>
    [JsonPropertyName("observacao")]
    public string? Observacao { get; set; }

    /// <summary>Número do Cadastro Nacional de Obras (CNO).</summary>
    [JsonPropertyName("cno")]
    public string? Cno { get; set; }

    /// <summary>CNPJ do prestador de serviço.</summary>
    [JsonPropertyName("cnpjPrestador")]
    public string? CnpjPrestador { get; set; }
}

/// <summary>
/// Entrada do serviço CONSULTAAPOIORECEITAS52: código da receita a consultar.
/// </summary>
/// <param name="CodigoReceita">Código da receita (Tabela de Receitas da RFB).</param>
public sealed record ConsultarReceita([property: JsonPropertyName("codigoReceita")] string CodigoReceita);


// SAÍDAS

/// <summary>
/// Valores consolidados do crédito tributário (objeto <c>consolidado</c>).
/// </summary>
public sealed class ConsolidadoDarf
{
    /// <summary>Valor principal atualizado.</summary>
    [JsonPropertyName("valorPrincipalMoedaCorrente")]
    public decimal? ValorPrincipalMoedaCorrente { get; set; }

    /// <summary>Valor total atualizado.</summary>
    [JsonPropertyName("valorTotalConsolidado")]
    public decimal? ValorTotalConsolidado { get; set; }

    /// <summary>Valor da multa de mora calculada.</summary>
    [JsonPropertyName("valorMultaMora")]
    public decimal? ValorMultaMora { get; set; }

    /// <summary>Percentual da multa de mora calculada.</summary>
    [JsonPropertyName("percentualMultaMora")]
    public decimal? PercentualMultaMora { get; set; }

    /// <summary>Valor dos juros calculados.</summary>
    [JsonPropertyName("valorJuros")]
    public decimal? ValorJuros { get; set; }

    /// <summary>Percentual dos juros calculados.</summary>
    [JsonPropertyName("percentualJuros")]
    public decimal? PercentualJuros { get; set; }

    /// <summary>Data em que começa a incidência de juros.</summary>
    [JsonPropertyName("termoInicialJuros")]
    public DateTime? TermoInicialJuros { get; set; }

    /// <summary>Data de consolidação do cálculo.</summary>
    [JsonPropertyName("dataArrecadacaoConsolidacao")]
    public DateTime? DataArrecadacaoConsolidacao { get; set; }

    /// <summary>Data limite em que o Darf pode ser pago na rede bancária.</summary>
    [JsonPropertyName("dataValidadeCalculo")]
    public DateTime? DataValidadeCalculo { get; set; }
}

/// <summary>
/// Retorno do serviço CONSOLIDAR54: somente os valores consolidados (sem emissão do Darf).
/// </summary>
public sealed class RetornoConsolidacao
{
    /// <summary>Valores consolidados do crédito tributário.</summary>
    [JsonPropertyName("consolidado")]
    public ConsolidadoDarf? Consolidado { get; set; }
}

/// <summary>
/// Retorno do serviço CONSOLIDARGERARDARF51: valores consolidados e Darf em PDF.
/// </summary>
public sealed class RetornoDarf
{
    /// <summary>Valores consolidados do crédito tributário.</summary>
    [JsonPropertyName("consolidado")]
    public ConsolidadoDarf? Consolidado { get; set; }

    /// <summary>PDF do Darf, em Base64.</summary>
    [JsonPropertyName("darf")]
    public string? Darf { get; set; }

    /// <summary>Número do documento do Darf.</summary>
    [JsonPropertyName("numeroDocumento")]
    public string? NumeroDocumento { get; set; }

    /// <summary>Código do Pix (QR code); ausente quando a instituição financeira não o retorna (Aviso-SICALC-001).</summary>
    [JsonPropertyName("qrCode")]
    public string? QrCode { get; set; }
}

/// <summary>
/// Campos do código de barras do Darf (objeto <c>codigoDeBarras</c>).
/// </summary>
public sealed class CodigoDeBarrasDarf
{
    /// <summary>Código de barras com 44 posições.</summary>
    [JsonPropertyName("codigo44")]
    public string? Codigo44 { get; set; }

    /// <summary>Campo 1 da linha digitável, com dígito verificador.</summary>
    [JsonPropertyName("campo1ComDV")]
    public string? Campo1ComDV { get; set; }

    /// <summary>Campo 2 da linha digitável, com dígito verificador.</summary>
    [JsonPropertyName("campo2ComDV")]
    public string? Campo2ComDV { get; set; }

    /// <summary>Campo 3 da linha digitável, com dígito verificador.</summary>
    [JsonPropertyName("campo3ComDV")]
    public string? Campo3ComDV { get; set; }

    /// <summary>Campo 4 da linha digitável, com dígito verificador.</summary>
    [JsonPropertyName("campo4ComDV")]
    public string? Campo4ComDV { get; set; }
}

/// <summary>
/// Retorno do serviço GERARDARFCODBARRA53: valores consolidados e código de barras do Darf.
/// </summary>
public sealed class RetornoDarfCodigoBarras
{
    /// <summary>Valores consolidados do crédito tributário.</summary>
    [JsonPropertyName("consolidado")]
    public ConsolidadoDarf? Consolidado { get; set; }

    /// <summary>Campos do código de barras do Darf.</summary>
    [JsonPropertyName("codigoDeBarras")]
    public CodigoDeBarrasDarf? CodigoDeBarras { get; set; }

    /// <summary>Número do documento do Darf.</summary>
    [JsonPropertyName("numeroDocumento")]
    public string? NumeroDocumento { get; set; }

    /// <summary>Código do Pix (QR code); ausente quando a instituição financeira não o retorna (Aviso-SICALC-001).</summary>
    [JsonPropertyName("qrCode")]
    public string? QrCode { get; set; }
}

/// <summary>
/// Retorno do serviço CONSULTAAPOIORECEITAS52.
/// </summary>
public sealed class RetornoConsultaReceita
{
    /// <summary>Dados da receita consultada.</summary>
    [JsonPropertyName("receita")]
    public ReceitaSicalc? Receita { get; set; }
}

/// <summary>
/// Receita do Sicalc e as regras de preenchimento de cada extensão.
/// </summary>
public sealed class ReceitaSicalc
{
    /// <summary>Código da receita informado na chamada.</summary>
    [JsonPropertyName("codigoReceita")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? CodigoReceita { get; set; }

    /// <summary>Nome descritivo do código de receita.</summary>
    [JsonPropertyName("descricaoReceita")]
    public string? DescricaoReceita { get; set; }

    /// <summary>
    /// Extensões da receita, cada uma com os campos obrigatórios, opcionais e informações para o serviço
    /// "Consolidar e emitir um Darf".
    /// </summary>
    [JsonPropertyName("extensoes")]
    public List<ExtensaoReceitaSicalc>? Extensoes { get; set; }
}

/// <summary>
/// Extensão de uma receita do Sicalc (item do array <c>extensoes</c>).
/// </summary>
public sealed class ExtensaoReceitaSicalc
{
    /// <summary>Campos de envio obrigatório.</summary>
    [JsonPropertyName("obrigatorios")]
    public CamposObrigatoriosReceita? Obrigatorios { get; set; }

    /// <summary>Campos de envio opcional.</summary>
    [JsonPropertyName("opcionais")]
    public CamposOpcionaisReceita? Opcionais { get; set; }

    /// <summary>Informações da receita/extensão.</summary>
    [JsonPropertyName("informacoes")]
    public InformacoesReceita? Informacoes { get; set; }
}

/// <summary>
/// Indica, para cada campo da entrada, se o seu envio é obrigatório (objeto <c>obrigatorios</c>).
/// </summary>
public sealed class CamposObrigatoriosReceita
{
    /// <summary>Código da receita.</summary>
    [JsonPropertyName("codigoReceita")]
    public bool? CodigoReceita { get; set; }

    /// <summary>Código da extensão da receita.</summary>
    [JsonPropertyName("codigoReceitaExtensao")]
    public bool? CodigoReceitaExtensao { get; set; }

    /// <summary>Número da cota.</summary>
    [JsonPropertyName("cota")]
    public bool? Cota { get; set; }

    /// <summary>Data da consolidação.</summary>
    [JsonPropertyName("dataConsolidacao")]
    public bool? DataConsolidacao { get; set; }

    /// <summary>Data do período de apuração.</summary>
    [JsonPropertyName("dataPA")]
    public bool? DataPA { get; set; }

    /// <summary>Número de referência.</summary>
    [JsonPropertyName("referencia")]
    public bool? Referencia { get; set; }

    /// <summary>Tipo do período de apuração.</summary>
    [JsonPropertyName("tipoPA")]
    public bool? TipoPA { get; set; }

    /// <summary>Valor do imposto.</summary>
    [JsonPropertyName("valorImposto")]
    public bool? ValorImposto { get; set; }

    /// <summary>Data de vencimento.</summary>
    [JsonPropertyName("vencimento")]
    public bool? Vencimento { get; set; }
}

/// <summary>
/// Indica, para cada campo da entrada, se o seu envio é opcional (objeto <c>opcionais</c>).
/// </summary>
public sealed class CamposOpcionaisReceita
{
    /// <summary>Número do CNO.</summary>
    [JsonPropertyName("cno")]
    public bool? Cno { get; set; }

    /// <summary>CNPJ do prestador.</summary>
    [JsonPropertyName("cnpjPrestador")]
    public bool? CnpjPrestador { get; set; }

    /// <summary>Data da alienação.</summary>
    [JsonPropertyName("dataAlienacao")]
    public bool? DataAlienacao { get; set; }

    /// <summary>Indicador de ganho de capital.</summary>
    [JsonPropertyName("ganhoCapital")]
    public bool? GanhoCapital { get; set; }

    /// <summary>Código do município.</summary>
    [JsonPropertyName("municipio")]
    public bool? Municipio { get; set; }

    /// <summary>Observação.</summary>
    [JsonPropertyName("observacao")]
    public bool? Observacao { get; set; }

    /// <summary>Número de referência.</summary>
    [JsonPropertyName("referencia")]
    public bool? Referencia { get; set; }

    /// <summary>Unidade Federativa.</summary>
    [JsonPropertyName("uf")]
    public bool? Uf { get; set; }

    /// <summary>Valor dos juros.</summary>
    [JsonPropertyName("valorJuros")]
    public bool? ValorJuros { get; set; }

    /// <summary>Valor da multa.</summary>
    [JsonPropertyName("valorMulta")]
    public bool? ValorMulta { get; set; }
}

/// <summary>
/// Informações sobre as características da receita/extensão (objeto <c>informacoes</c>).
/// </summary>
public sealed class InformacoesReceita
{
    /// <summary>O débito pode ter os acréscimos legais calculados pelo sistema.</summary>
    [JsonPropertyName("calculado")]
    public bool? Calculado { get; set; }

    /// <summary>A receita permite a emissão do Darf com código de barras (e Pix).</summary>
    [JsonPropertyName("codigoBarras")]
    public bool? CodigoBarras { get; set; }

    /// <summary>Extensão da receita.</summary>
    [JsonPropertyName("codigoReceitaExtensao")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? CodigoReceitaExtensao { get; set; }

    /// <summary>Data de criação da receita.</summary>
    [JsonPropertyName("criacao")]
    public DateTime? Criacao { get; set; }

    /// <summary>Data de extinção da receita.</summary>
    [JsonPropertyName("extincao")]
    public DateTime? Extincao { get; set; }

    /// <summary>Descrição da extensão da receita.</summary>
    [JsonPropertyName("descricaoReceitaExtensao")]
    public string? DescricaoReceitaExtensao { get; set; }

    /// <summary>Tipo de dado esperado no campo referência.</summary>
    [JsonPropertyName("descricaoReferencia")]
    public string? DescricaoReferencia { get; set; }

    /// <summary>Somente o CNPJ da matriz pode ser utilizado para o débito.</summary>
    [JsonPropertyName("exigeMatriz")]
    public bool? ExigeMatriz { get; set; }

    /// <summary>
    /// O débito não pode ter os acréscimos legais calculados pelo sistema: todos os atributos (inclusive os valores)
    /// devem ser preenchidos pelo usuário.
    /// </summary>
    [JsonPropertyName("manual")]
    public bool? Manual { get; set; }

    /// <summary>A receita pode ser utilizada em débito de pessoa física.</summary>
    [JsonPropertyName("pf")]
    public bool? Pf { get; set; }

    /// <summary>A receita pode ser utilizada em débito de pessoa jurídica.</summary>
    [JsonPropertyName("pj")]
    public bool? Pj { get; set; }

    /// <summary>Tipo do período de apuração esperado (AN, TR, ME, QZ, DC, SM ou DI).</summary>
    [JsonPropertyName("tipoPeriodoApuracao")]
    public string? TipoPeriodoApuracao { get; set; }

    /// <summary>Indica se o valor total do Darf não pode ser inferior a R$ 10,00.</summary>
    [JsonPropertyName("vedaValor")]
    public bool? VedaValor { get; set; }
}


// CONVERSORES

/// <summary>
/// Data e hora no formato ISO 8601 sem fuso (aaaa-MM-ddTHH:mm:ss), como nos exemplos da documentação.
/// </summary>
internal sealed class DataHoraSicalcJsonConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;
        var texto = reader.GetString();
        return string.IsNullOrWhiteSpace(texto) ? null : DateTime.Parse(texto, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value is null)
            writer.WriteNullValue();
        else
            writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture));
    }
}
