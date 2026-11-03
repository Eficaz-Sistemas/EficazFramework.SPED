using EficazFramework.SPED.Schemas.MIT;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraDCTFWeb;

/// <summary>
/// Situação de uma apuração do MIT (campos <c>situacaoApuracao</c> e <c>situacao</c>).
/// </summary>
public enum SituacaoApuracaoMit
{
    /// <summary>1 - Em edição com pendências: editada na interface Web com campos inconsistentes ou não preenchidos (exclusivo da interface Web).</summary>
    EmEdicaoComPendencias = 1,
    /// <summary>2 - Em edição: pode ser editada pela interface Web ou reenviada pelo Integra Contador.</summary>
    EmEdicao = 2,
    /// <summary>3 - Encerrada: enviada para a DCTFWeb, não pode mais ser alterada no MIT.</summary>
    Encerrada = 3,
    /// <summary>4 - Encerramento em curso: a apuração está em processamento.</summary>
    EncerramentoEmCurso = 4
}

/// <summary>
/// Apuração do MIT: entrada do serviço ENCAPURACAO314 e estrutura <c>dadosApuracaoMit</c> do CONSAPURACAO316.
/// Reaproveita o leiaute de <see cref="Escrituracao"/> (arquivo de importação do MIT), acrescido de <see cref="TransmissaoImediata"/>.
/// </summary>
/// <remarks>
/// As chaves são enviadas em PascalCase, como no leiaute do MIT (ver <see cref="SerializarDados"/>).
/// </remarks>
public sealed class ApuracaoMit : Escrituracao
{
    /// <summary>Cria uma apuração vazia.</summary>
    public ApuracaoMit() { }

    /// <summary>Cria a apuração a partir de uma escrituração do MIT já montada.</summary>
    /// <param name="escrituracao">Escrituração (período, eventos especiais, dados iniciais, débitos e suspensões).</param>
    /// <param name="transmissaoImediata">Transmite a DCTFWeb logo após o encerramento (obrigatório se sem movimento).</param>
    public ApuracaoMit(Escrituracao escrituracao, bool? transmissaoImediata = null)
    {
        ArgumentNullException.ThrowIfNull(escrituracao);
        PeriodoApuracao = escrituracao.PeriodoApuracao;
        ListaEventosEspeciais = escrituracao.ListaEventosEspeciais;
        DadosIniciais = escrituracao.DadosIniciais;
        Debitos = escrituracao.Debitos;
        ListaSuspensoes = escrituracao.ListaSuspensoes;
        TransmissaoImediata = transmissaoImediata;
    }

    /// <summary>
    /// Indica que a DCTFWeb correspondente será transmitida imediatamente após o encerramento da apuração, sem
    /// intervenção do usuário. Obrigatório se <see cref="DadosIniciais.SemMovimento"/> for verdadeiro.
    /// </summary>
    [JsonPropertyOrder(1)]
    public bool? TransmissaoImediata { get; set; }

    /// <summary>
    /// Opções JSON do leiaute do MIT: chaves em PascalCase, nulos omitidos, inteiros zerados omitidos (nenhum código
    /// ou identificador do leiaute aceita 0) e indicadores <c>ComDeposito</c>/<c>ProcessoTerceiro</c> enviados
    /// somente em suspensões judiciais.
    /// </summary>
    public static JsonSerializerOptions OpcoesJson { get; } = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        TypeInfoResolver = new DefaultJsonTypeInfoResolver { Modifiers = { OmitirCamposNaoAplicaveis } }
    };

    /// <summary>Serializa a apuração no formato esperado pelo campo <c>dados</c> do ENCAPURACAO314.</summary>
    public string SerializarDados() => JsonSerializer.Serialize(this, OpcoesJson);

    private static void OmitirCamposNaoAplicaveis(JsonTypeInfo tipo)
    {
        if (tipo.Kind != JsonTypeInfoKind.Object)
            return;

        foreach (var propriedade in tipo.Properties)
        {
            if (propriedade.PropertyType == typeof(int))
                propriedade.ShouldSerialize = static (_, valor) => valor is int numero && numero != 0;
        }

        if (tipo.Type != typeof(Suspensao))
            return;

        foreach (var propriedade in tipo.Properties)
        {
            if (propriedade.Name == nameof(Suspensao.ProcessoTerceiro))
                propriedade.ShouldSerialize = static (objeto, _) => ((Suspensao)objeto).TipoSuspensao == 2;
            else if (propriedade.Name == nameof(Suspensao.ComDeposito))
                propriedade.ShouldSerialize = static (objeto, _) => objeto is Suspensao { TipoSuspensao: 2, MotivoSuspensao: not 2 };
        }
    }
}

/// <summary>
/// Retorno do serviço ENCAPURACAO314. A apuração é enviada à DCTFWeb posteriormente; acompanhe pelo SITUACAOENC315.
/// </summary>
public sealed class RetornoEncerrarApuracaoMit
{
    /// <summary>Protocolo de encerramento da apuração (entrada do SITUACAOENC315).</summary>
    [JsonPropertyName("protocoloEncerramento")]
    public string? ProtocoloEncerramento { get; set; }

    /// <summary>Identificador da apuração criada.</summary>
    [JsonPropertyName("idApuracao")]
    public long? IdApuracao { get; set; }
}

/// <summary>
/// Entrada do serviço SITUACAOENC315.
/// </summary>
public sealed class ConsultaSituacaoEncerramentoMit
{
    /// <summary>Protocolo de encerramento fornecido pelo ENCAPURACAO314.</summary>
    [JsonPropertyName("protocoloEncerramento")]
    public string ProtocoloEncerramento { get; set; } = string.Empty;
}

/// <summary>
/// Retorno do serviço SITUACAOENC315.
/// </summary>
public sealed class RetornoSituacaoEncerramentoMit
{
    /// <summary>Identificador da apuração.</summary>
    [JsonPropertyName("idApuracao")]
    public long? IdApuracao { get; set; }

    /// <summary>Situação da apuração.</summary>
    [JsonPropertyName("situacaoApuracao")]
    public SituacaoApuracaoMit? SituacaoApuracao { get; set; }

    /// <summary>Descrição da situação da apuração (ex.: ENCERRADA).</summary>
    [JsonPropertyName("textoSituacao")]
    public string? TextoSituacao { get; set; }

    /// <summary>Mensagens retornadas pela DCTFWeb no encerramento.</summary>
    [JsonPropertyName("avisosDctf")]
    public List<string>? AvisosDctf { get; set; }

    /// <summary>Data do encerramento (AAAAMMDD).</summary>
    [JsonPropertyName("dataEncerramento")]
    public string? DataEncerramento { get; set; }
}

/// <summary>
/// Entrada do serviço CONSAPURACAO316.
/// </summary>
public sealed class ConsultaApuracaoMit
{
    /// <summary>Identificador da apuração fornecido pelo ENCAPURACAO314.</summary>
    [JsonPropertyName("idApuracao")]
    public long IdApuracao { get; set; }
}

/// <summary>
/// Retorno do serviço CONSAPURACAO316.
/// </summary>
public sealed class RetornoConsultaApuracaoMit
{
    /// <summary>Situação da apuração.</summary>
    [JsonPropertyName("situacaoApuracao")]
    public SituacaoApuracaoMit? SituacaoApuracao { get; set; }

    /// <summary>Descrição da situação da apuração (ex.: ENCERRADA).</summary>
    [JsonPropertyName("textoSituacao")]
    public string? TextoSituacao { get; set; }

    /// <summary>Dados da apuração, no leiaute do arquivo de importação do MIT.</summary>
    [JsonPropertyName("dadosApuracaoMit")]
    public ApuracaoMit? DadosApuracaoMit { get; set; }
}

/// <summary>
/// Entrada do serviço LISTAAPURACOES317.
/// </summary>
public sealed class ListaApuracoesMit
{
    /// <summary>Ano das apurações a consultar (AAAA).</summary>
    [JsonPropertyName("anoApuracao")]
    public int AnoApuracao { get; set; }

    /// <summary>Mês das apurações; quando informado, consulta apenas as apurações do ano e mês.</summary>
    [JsonPropertyName("mesApuracao")]
    public int? MesApuracao { get; set; }

    /// <summary>Situação das apurações a consultar.</summary>
    [JsonPropertyName("situacaoApuracao")]
    public SituacaoApuracaoMit? SituacaoApuracao { get; set; }
}

/// <summary>
/// Retorno do serviço LISTAAPURACOES317.
/// </summary>
public sealed class RetornoListaApuracoesMit
{
    /// <summary>Apurações do período consultado.</summary>
    [JsonPropertyName("Apuracoes")]
    public List<ApuracaoListadaMit>? Apuracoes { get; set; }
}

/// <summary>
/// Apuração listada pelo serviço LISTAAPURACOES317.
/// </summary>
public sealed class ApuracaoListadaMit
{
    /// <summary>Período da apuração (AAAAMM).</summary>
    [JsonPropertyName("periodoApuracao")]
    public int? PeriodoApuracao { get; set; }

    /// <summary>Identificador da apuração fornecido no encerramento (identEFD).</summary>
    [JsonPropertyName("idApuracao")]
    public long? IdApuracao { get; set; }

    /// <summary>Situação da apuração.</summary>
    [JsonPropertyName("situacao")]
    public SituacaoApuracaoMit? Situacao { get; set; }

    /// <summary>Data de encerramento da apuração (AAAAMMDD).</summary>
    [JsonPropertyName("dataEncerramento")]
    public string? DataEncerramento { get; set; }

    /// <summary>Indica a existência de evento especial na apuração.</summary>
    [JsonPropertyName("eventoEspecial")]
    public bool? EventoEspecial { get; set; }

    /// <summary>Valor total apurado.</summary>
    [JsonPropertyName("valorTotalApurado")]
    public decimal? ValorTotalApurado { get; set; }
}
