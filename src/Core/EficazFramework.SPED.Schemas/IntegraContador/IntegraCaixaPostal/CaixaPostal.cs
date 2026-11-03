using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraCaixaPostal;

// ENUMS

/// <summary>
/// Status de leitura das mensagens a listar (MSGCONTRIBUINTE61).
/// </summary>
public enum StatusLeitura
{
    /// <summary>0 - Não se aplica (todas as mensagens).</summary>
    NaoSeAplica = 0,
    /// <summary>1 - Lida.</summary>
    Lida = 1,
    /// <summary>2 - Não lida.</summary>
    NaoLida = 2
}

/// <summary>
/// Indicador de mensagem favorita.
/// </summary>
public enum IndicadorFavorito
{
    /// <summary>0 - Não favorita.</summary>
    NaoFavorita = 0,
    /// <summary>1 - Favorita.</summary>
    Favorita = 1
}

/// <summary>
/// Indicador da página solicitada (MSGCONTRIBUINTE61).
/// </summary>
public enum IndicadorPagina
{
    /// <summary>0 - Página inicial (mensagens mais recentes).</summary>
    Inicial = 0,
    /// <summary>1 - Página não inicial (informar <see cref="ListarMensagens.PonteiroPagina"/>).</summary>
    NaoInicial = 1
}

/// <summary>
/// Indicador de mensagens novas (INNOVAMSG63).
/// </summary>
public enum IndicadorMensagensNovas
{
    /// <summary>0 - Contribuinte não possui mensagens novas.</summary>
    SemMensagensNovas = 0,
    /// <summary>1 - Contribuinte possui uma mensagem nova.</summary>
    UmaMensagemNova = 1,
    /// <summary>2 - Contribuinte possui mensagens novas.</summary>
    MensagensNovas = 2
}


// ENTRADAS

/// <summary>
/// Entrada do serviço MSGCONTRIBUINTE61: filtros e paginação da lista de mensagens da Caixa Postal.
/// </summary>
/// <remarks>Os códigos são enviados como texto, conforme o exemplo da documentação (ex.: <c>"statusLeitura": "0"</c>).</remarks>
public sealed class ListarMensagens
{
    /// <summary>CNPJ para filtro (somente para contribuinte pessoa jurídica).</summary>
    [JsonPropertyName("cnpjReferencia")]
    public string? CnpjReferencia { get; set; }

    /// <summary>
    /// Status de leitura da mensagem: <br/>
    /// 0 - Não se aplica <br/>
    /// 1 - Lida <br/>
    /// 2 - Não lida <br/>
    /// </summary>
    [JsonPropertyName("statusLeitura")]
    [JsonConverter(typeof(EnumNumericoJsonConverter))]
    public StatusLeitura StatusLeitura { get; set; } = StatusLeitura.NaoSeAplica;

    /// <summary>
    /// Indicador de mensagem favorita: <br/>
    /// 0 - Não favorita <br/>
    /// 1 - Favorita <br/>
    /// </summary>
    [JsonPropertyName("indicadorFavorito")]
    [JsonConverter(typeof(EnumNumericoJsonConverter))]
    public IndicadorFavorito? IndicadorFavorito { get; set; }

    /// <summary>
    /// Indicador da página solicitada: <br/>
    /// 0 - Página inicial (mensagens mais recentes) <br/>
    /// 1 - Página não inicial <br/>
    /// </summary>
    [JsonPropertyName("indicadorPagina")]
    [JsonConverter(typeof(EnumNumericoJsonConverter))]
    public IndicadorPagina IndicadorPagina { get; set; } = IndicadorPagina.Inicial;

    /// <summary>
    /// Ponteiro da página (obrigatório para página não inicial): use <see cref="PaginaMensagens.PonteiroProximaPagina"/>
    /// da consulta anterior. Até 24 dígitos.
    /// </summary>
    [JsonPropertyName("ponteiroPagina")]
    public string? PonteiroPagina { get; set; }
}

/// <summary>
/// Entrada do serviço MSGDETALHAMENTO62: identificador da mensagem.
/// </summary>
/// <param name="Isn">Identificador único da mensagem do contribuinte (<see cref="MensagemCaixaPostal.Isn"/>).</param>
public sealed record DetalharMensagem([property: JsonPropertyName("isn")] string Isn);


// SAÍDAS

/// <summary>
/// Retorno do serviço MSGCONTRIBUINTE61: lista de mensagens da Caixa Postal.
/// </summary>
public sealed class RetornoListaMensagens
{
    /// <summary>Código do resultado da requisição (ex.: 00 - sucesso).</summary>
    [JsonPropertyName("codigo")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? Codigo { get; set; }

    /// <summary>Páginas de mensagens retornadas (normalmente uma).</summary>
    [JsonPropertyName("conteudo")]
    public List<PaginaMensagens>? Conteudo { get; set; }
}

/// <summary>
/// Página de mensagens da Caixa Postal (até 50 mensagens).
/// </summary>
public sealed class PaginaMensagens
{
    /// <summary>Quantidade de mensagens encontradas na página.</summary>
    [JsonPropertyName("quantidadeMensagens")]
    public int? QuantidadeMensagens { get; set; }

    /// <summary>Indicador de última página: S - Sim, N - Não.</summary>
    [JsonPropertyName("indicadorUltimaPagina")]
    public string? IndicadorUltimaPagina { get; set; }

    /// <summary>Indica se esta é a última página (<see cref="IndicadorUltimaPagina"/> = S).</summary>
    [JsonIgnore]
    public bool UltimaPagina => string.Equals(IndicadorUltimaPagina, "S", StringComparison.OrdinalIgnoreCase);

    /// <summary>Ponteiro da página retornada.</summary>
    [JsonPropertyName("ponteiroPaginaRetornada")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? PonteiroPaginaRetornada { get; set; }

    /// <summary>Ponteiro da próxima página (informar em <see cref="ListarMensagens.PonteiroPagina"/>).</summary>
    [JsonPropertyName("ponteiroProximaPagina")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? PonteiroProximaPagina { get; set; }

    /// <summary>CNPJ do contribuinte pessoa jurídica (matriz).</summary>
    [JsonPropertyName("cnpjMatriz")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? CnpjMatriz { get; set; }

    /// <summary>Mensagens da página.</summary>
    [JsonPropertyName("listaMensagens")]
    public List<MensagemCaixaPostal>? ListaMensagens { get; set; }
}

/// <summary>
/// Campos comuns das mensagens da Caixa Postal (lista e detalhamento). Datas no formato AAAAMMDD e horas no formato
/// HHMMSS, como texto (vazio quando não há valor).
/// </summary>
public abstract class MensagemCaixaPostalBase
{
    /// <summary>Código do sistema remetente.</summary>
    [JsonPropertyName("codigoSistemaRemetente")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? CodigoSistemaRemetente { get; set; }

    /// <summary>Código do modelo da mensagem.</summary>
    [JsonPropertyName("codigoModelo")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? CodigoModelo { get; set; }

    /// <summary>Data do envio (AAAAMMDD).</summary>
    [JsonPropertyName("dataEnvio")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? DataEnvio { get; set; }

    /// <summary>Hora do envio (HHMMSS).</summary>
    [JsonPropertyName("horaEnvio")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? HoraEnvio { get; set; }

    /// <summary>Número de controle da mensagem (AAAA/999999999999999).</summary>
    [JsonPropertyName("numeroControle")]
    public string? NumeroControle { get; set; }

    /// <summary>Data da primeira leitura (AAAAMMDD).</summary>
    [JsonPropertyName("dataLeitura")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? DataLeitura { get; set; }

    /// <summary>Hora da primeira leitura (HHMMSS).</summary>
    [JsonPropertyName("horaLeitura")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? HoraLeitura { get; set; }

    /// <summary>Data da exclusão (AAAAMMDD).</summary>
    [JsonPropertyName("dataExclusao")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? DataExclusao { get; set; }

    /// <summary>Hora da exclusão (HHMMSS).</summary>
    [JsonPropertyName("horaExclusao")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? HoraExclusao { get; set; }

    /// <summary>Data da ciência (AAAAMMDD).</summary>
    [JsonPropertyName("dataCiencia")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? DataCiencia { get; set; }

    /// <summary>Assunto do modelo da mensagem; o texto <c>++VARIAVEL++</c> é substituído por <see cref="ValorParametroAssunto"/>.</summary>
    [JsonPropertyName("assuntoModelo")]
    public string? AssuntoModelo { get; set; }

    /// <summary>Origem do modelo da mensagem: 1 - Sistema remetente, 2 - RFB.</summary>
    [JsonPropertyName("origemModelo")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? OrigemModelo { get; set; }

    /// <summary>Valor do parâmetro do assunto.</summary>
    [JsonPropertyName("valorParametroAssunto")]
    public string? ValorParametroAssunto { get; set; }

    /// <summary>Relevância do modelo da mensagem: 1 - Sem relevância, 2 - Com relevância.</summary>
    [JsonPropertyName("relevancia")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? Relevancia { get; set; }

    /// <summary>Identificador único da mensagem do contribuinte (usado no MSGDETALHAMENTO62).</summary>
    [JsonPropertyName("isn")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? Isn { get; set; }

    /// <summary>Tipo de origem da mensagem: 1 - Receita, 2 - Estado, 3 - Município.</summary>
    [JsonPropertyName("tipoOrigem")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? TipoOrigem { get; set; }

    /// <summary>Descrição da origem (nome da UA, do estado ou do município).</summary>
    [JsonPropertyName("descricaoOrigem")]
    public string? DescricaoOrigem { get; set; }

    /// <summary>Assunto com o parâmetro <c>++VARIAVEL++</c> substituído por <see cref="ValorParametroAssunto"/>.</summary>
    [JsonIgnore]
    public string? AssuntoFormatado => AssuntoModelo?.Replace("++VARIAVEL++", ValorParametroAssunto ?? string.Empty);
}

/// <summary>
/// Mensagem da lista da Caixa Postal (MSGCONTRIBUINTE61).
/// </summary>
public sealed class MensagemCaixaPostal : MensagemCaixaPostalBase
{
    /// <summary>Indicador de leitura: 0 - Não lida, 1 - Lida.</summary>
    [JsonPropertyName("indicadorLeitura")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? IndicadorLeitura { get; set; }

    /// <summary>Indicador de favorita: 0 - Não favorita, 1 - Favorita.</summary>
    [JsonPropertyName("indicadorFavorito")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? IndicadorFavorito { get; set; }

    /// <summary>Data de validade da mensagem (AAAAMMDD).</summary>
    [JsonPropertyName("dataValidade")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? DataValidade { get; set; }
}

/// <summary>
/// Retorno do serviço MSGDETALHAMENTO62: detalhes da mensagem.
/// </summary>
public sealed class RetornoDetalheMensagem
{
    /// <summary>Código do resultado da requisição (ex.: 00 - sucesso).</summary>
    [JsonPropertyName("codigo")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? Codigo { get; set; }

    /// <summary>Mensagens encontradas.</summary>
    [JsonPropertyName("conteudo")]
    public List<DetalheMensagemCaixaPostal>? Conteudo { get; set; }
}

/// <summary>
/// Detalhes de uma mensagem da Caixa Postal (MSGDETALHAMENTO62).
/// </summary>
public sealed class DetalheMensagemCaixaPostal : MensagemCaixaPostalBase
{
    /// <summary>Indicador de favorita: 0 - Não favorita, 1 - Favorita.</summary>
    [JsonPropertyName("indFavorito")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? IndicadorFavorito { get; set; }

    /// <summary>Data de expiração da mensagem (AAAAMMDD).</summary>
    [JsonPropertyName("dataExpiracao")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? DataExpiracao { get; set; }

    /// <summary>Texto (HTML) do corpo do modelo; os parâmetros <c>++1++</c>, <c>++2++</c>... são substituídos por <see cref="Variaveis"/>.</summary>
    [JsonPropertyName("corpoModelo")]
    public string? CorpoModelo { get; set; }

    /// <summary>Valores dos parâmetros do corpo da mensagem (na ordem de <c>++1++</c>, <c>++2++</c>...).</summary>
    [JsonPropertyName("variaveis")]
    public List<string>? Variaveis { get; set; }

    /// <summary>Enquadramento.</summary>
    [JsonPropertyName("enquadramento")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? Enquadramento { get; set; }

    /// <summary>Data do acesso externo (AAAAMMDD).</summary>
    [JsonPropertyName("dataAcessoExterno")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? DataAcessoExterno { get; set; }

    /// <summary>Hora do acesso externo (HHMMSS).</summary>
    [JsonPropertyName("horaAcessoExterno")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? HoraAcessoExterno { get; set; }

    /// <summary>Tipo de autenticação do usuário.</summary>
    [JsonPropertyName("tipoAutenticacaoUsuario")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? TipoAutenticacaoUsuario { get; set; }

    /// <summary>Código de acesso.</summary>
    [JsonPropertyName("codigoAcesso")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? CodigoAcesso { get; set; }

    /// <summary>Número de série do certificado digital.</summary>
    [JsonPropertyName("numeroSerieCertificadoDigital")]
    public string? NumeroSerieCertificadoDigital { get; set; }

    /// <summary>Emissor do certificado digital.</summary>
    [JsonPropertyName("emissorCertificadoDigital")]
    public string? EmissorCertificadoDigital { get; set; }

    /// <summary>Tipo do usuário.</summary>
    [JsonPropertyName("tipoUsuario")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? TipoUsuario { get; set; }

    /// <summary>NI (CPF/CNPJ) do usuário.</summary>
    [JsonPropertyName("niUsuario")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? NiUsuario { get; set; }

    /// <summary>Papel do usuário.</summary>
    [JsonPropertyName("papelUsuario")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? PapelUsuario { get; set; }

    /// <summary>Código da aplicação.</summary>
    [JsonPropertyName("codigoAplicacao")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? CodigoAplicacao { get; set; }

    /// <summary>Corpo da mensagem com os parâmetros <c>++n++</c> substituídos pelos valores de <see cref="Variaveis"/>.</summary>
    [JsonIgnore]
    public string? CorpoFormatado => CorpoModelo is null
        ? null
        : Regex.Replace(CorpoModelo, @"\+\+(\d+)\+\+", m =>
        {
            var indice = int.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture) - 1;
            return Variaveis is not null && indice >= 0 && indice < Variaveis.Count ? Variaveis[indice] : m.Value;
        });
}

/// <summary>
/// Retorno do serviço INNOVAMSG63: indicador de mensagens novas.
/// </summary>
public sealed class RetornoIndicadorNovasMensagens
{
    /// <summary>Código do resultado da requisição (ex.: 00 - sucesso).</summary>
    [JsonPropertyName("codigo")]
    [JsonConverter(typeof(TextoOuNumeroJsonConverter))]
    public string? Codigo { get; set; }

    /// <summary>Conteúdo do retorno (um item com o indicador).</summary>
    [JsonPropertyName("conteudo")]
    public List<IndicadorNovasMensagens>? Conteudo { get; set; }

    /// <summary>Indicador de mensagens novas do primeiro item de <see cref="Conteudo"/>.</summary>
    [JsonIgnore]
    public IndicadorMensagensNovas? IndicadorMensagensNovas => Conteudo?.FirstOrDefault()?.IndicadorMensagensNovas;
}

/// <summary>
/// Item do retorno do serviço INNOVAMSG63.
/// </summary>
public sealed class IndicadorNovasMensagens
{
    /// <summary>
    /// Indicador de mensagens novas: <br/>
    /// 0 - Não possui mensagens novas <br/>
    /// 1 - Possui uma mensagem nova <br/>
    /// 2 - Possui mensagens novas <br/>
    /// </summary>
    [JsonPropertyName("indicadorMensagensNovas")]
    [JsonConverter(typeof(EnumNumericoJsonConverter))]
    public IndicadorMensagensNovas? IndicadorMensagensNovas { get; set; }
}


