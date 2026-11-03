using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraRedesim;

// PNRCONTADOR: renúncia de responsabilidade contábil (Integra-Redesim).

/// <summary>
/// Entrada do serviço CONSVINCULOS261 (Consultar Vínculos): paginação por cursor de CNPJ.
/// </summary>
public sealed class ConsultaVinculos
{
    /// <summary>Paginação da consulta.</summary>
    [JsonPropertyName("pagination")]
    public PaginacaoVinculos Pagination { get; set; } = new();
}

/// <summary>
/// Paginação da consulta de vínculos.
/// </summary>
public sealed class PaginacaoVinculos
{
    /// <summary>Quantidade de registros por página (padrão 10, máximo 50).</summary>
    [JsonPropertyName("size")]
    public int Size { get; set; } = 10;

    /// <summary>Cursor: último CNPJ da página anterior (<see cref="PaginaVinculos.LastCnpj"/>); nulo na primeira requisição.</summary>
    [JsonPropertyName("lastCnpj")]
    public string? LastCnpj { get; set; }
}

/// <summary>
/// Retorno do serviço CONSVINCULOS261: página das empresas com vínculo contabilista ativo com o contador.
/// </summary>
public sealed class PaginaVinculos
{
    /// <summary>Empresas da página atual.</summary>
    [JsonPropertyName("cnpjs")]
    public List<EmpresaVinculada>? Cnpjs { get; set; }

    /// <summary>Total de registros na página atual.</summary>
    [JsonPropertyName("totalInThePage")]
    public int? TotalInThePage { get; set; }

    /// <summary>Total de registros existentes.</summary>
    [JsonPropertyName("totalInTheDatabase")]
    public int? TotalInTheDatabase { get; set; }

    /// <summary>Cursor para a próxima página (informar em <see cref="PaginacaoVinculos.LastCnpj"/>).</summary>
    [JsonPropertyName("lastCnpj")]
    public string? LastCnpj { get; set; }
}

/// <summary>
/// Empresa com vínculo contabilista.
/// </summary>
public sealed class EmpresaVinculada
{
    /// <summary>CNPJ da empresa.</summary>
    [JsonPropertyName("cnpj")]
    public string? Cnpj { get; set; }

    /// <summary>Tipo de estabelecimento (ex.: Matriz, Filial).</summary>
    [JsonPropertyName("tipoEstabelecimento")]
    public string? TipoEstabelecimento { get; set; }

    /// <summary>Situação cadastral da empresa.</summary>
    [JsonPropertyName("situacaoCadastral")]
    public SituacaoCadastralEmpresa? SituacaoCadastral { get; set; }

    /// <summary>UF da empresa.</summary>
    [JsonPropertyName("uf")]
    public string? Uf { get; set; }

    /// <summary>Código do município.</summary>
    [JsonPropertyName("codigoMunicipio")]
    public string? CodigoMunicipio { get; set; }

    /// <summary>Nome do município.</summary>
    [JsonPropertyName("nomeMunicipio")]
    public string? NomeMunicipio { get; set; }
}

/// <summary>
/// Situação cadastral da empresa vinculada.
/// </summary>
public sealed class SituacaoCadastralEmpresa
{
    /// <summary>Código da situação cadastral (ex.: "02").</summary>
    [JsonPropertyName("codigo")]
    public string? Codigo { get; set; }

    /// <summary>Descrição da situação cadastral (pode ser nula).</summary>
    [JsonPropertyName("descricao")]
    public string? Descricao { get; set; }
}

/// <summary>
/// Entrada do serviço SOLICRENUNCIA262 (Solicitar Renúncia).
/// </summary>
/// <remarks>O autor do pedido de dados deve ter o mesmo NI de <see cref="DadosSolicitacaoRenuncia.CpfContador"/> ou de
/// <see cref="DadosSolicitacaoRenuncia.CnpjEmpresaContabil"/>.</remarks>
public sealed class SolicitacaoRenuncia
{
    /// <summary>Dados da solicitação de renúncia.</summary>
    [JsonPropertyName("solicitacaoRenunciaContador")]
    public DadosSolicitacaoRenuncia SolicitacaoRenunciaContador { get; set; } = new();

    /// <summary>
    /// Aceite do autor do pedido de dados às declarações exigidas para a renúncia (renúncia ao vínculo; comunicação à
    /// administração tributária do Estado e do Município via REDESIM; comunicação imediata à pessoa jurídica;
    /// irretratabilidade da renúncia).
    /// </summary>
    [JsonPropertyName("cienciaDeclaracoes")]
    public bool CienciaDeclaracoes { get; set; }
}

/// <summary>
/// Dados da solicitação de renúncia ao vínculo contabilista (somente números, sem máscara).
/// </summary>
public sealed class DadosSolicitacaoRenuncia
{
    /// <summary>CNPJ da empresa com a qual se deseja renunciar o vínculo (14 dígitos).</summary>
    [JsonPropertyName("cnpj")]
    public string Cnpj { get; set; } = string.Empty;

    /// <summary>CPF do profissional contábil renunciante (11 dígitos).</summary>
    [JsonPropertyName("cpfContador")]
    public string? CpfContador { get; set; }

    /// <summary>CNPJ da empresa contábil renunciante (14 dígitos).</summary>
    [JsonPropertyName("cnpjEmpresaContabil")]
    public string? CnpjEmpresaContabil { get; set; }

    /// <summary>CPF do preenchedor: o do autor do pedido de dados ou, se PJ, o do responsável pelo e-CNPJ (11 dígitos).</summary>
    [JsonPropertyName("cpfPreenchedor")]
    public string CpfPreenchedor { get; set; } = string.Empty;
}

/// <summary>
/// Retorno do serviço SOLICRENUNCIA262: identificador da solicitação.
/// </summary>
public sealed class RetornoSolicitacaoRenuncia
{
    /// <summary>ID da solicitação de renúncia (ex.: PNRCONTADOR-20250212-af81730aeb29c9fdac15).</summary>
    [JsonPropertyName("idSolicitacao")]
    public string? IdSolicitacao { get; set; }
}

/// <summary>
/// Entrada do serviço CONSRENUNCIA263 (Consultar Renúncias).
/// </summary>
public sealed class ConsultaRenuncias
{
    /// <summary>Data início (AAAA-MM-DD); informar junto com <see cref="DtFim"/>.</summary>
    [JsonPropertyName("dtInicio")]
    public string? DtInicio { get; set; }

    /// <summary>Data fim (AAAA-MM-DD), posterior a <see cref="DtInicio"/>.</summary>
    [JsonPropertyName("dtFim")]
    public string? DtFim { get; set; }

    /// <summary>Índice da página (a primeira é 0).</summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>Registros por página (padrão 10, máximo 50).</summary>
    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

    /// <summary>Consulta por período, com as datas no formato AAAA-MM-DD.</summary>
    /// <param name="inicio">Data início.</param>
    /// <param name="fim">Data fim.</param>
    /// <param name="page">Índice da página (a primeira é 0).</param>
    /// <param name="pageSize">Registros por página.</param>
    public static ConsultaRenuncias Periodo(DateTime inicio, DateTime fim, int? page = null, int? pageSize = null) => new()
    {
        DtInicio = inicio.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
        DtFim = fim.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
        Page = page,
        PageSize = pageSize
    };
}

/// <summary>
/// Retorno do serviço CONSRENUNCIA263: página (Spring Data) das renúncias.
/// </summary>
public sealed class PaginaRenuncias
{
    /// <summary>Renúncias da página atual.</summary>
    [JsonPropertyName("content")]
    public List<Renuncia>? Content { get; set; }

    /// <summary>Indica se a página está vazia.</summary>
    [JsonPropertyName("empty")]
    public bool? Empty { get; set; }

    /// <summary>Indica se é a primeira página.</summary>
    [JsonPropertyName("first")]
    public bool? First { get; set; }

    /// <summary>Indica se é a última página.</summary>
    [JsonPropertyName("last")]
    public bool? Last { get; set; }

    /// <summary>Número da página atual.</summary>
    [JsonPropertyName("number")]
    public int? Number { get; set; }

    /// <summary>Quantidade de elementos na página atual.</summary>
    [JsonPropertyName("numberOfElements")]
    public int? NumberOfElements { get; set; }

    /// <summary>Informações de paginação.</summary>
    [JsonPropertyName("pageable")]
    public PaginacaoRenuncias? Pageable { get; set; }

    /// <summary>Quantidade de elementos por página.</summary>
    [JsonPropertyName("size")]
    public int? Size { get; set; }

    /// <summary>Informações de ordenação.</summary>
    [JsonPropertyName("sort")]
    public OrdenacaoRenuncias? Sort { get; set; }

    /// <summary>Total de elementos.</summary>
    [JsonPropertyName("totalElements")]
    public long? TotalElements { get; set; }

    /// <summary>Total de páginas.</summary>
    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }
}

/// <summary>
/// Informações de paginação (Pageable) da consulta de renúncias.
/// </summary>
public sealed class PaginacaoRenuncias
{
    /// <summary>Deslocamento do primeiro elemento.</summary>
    [JsonPropertyName("offset")]
    public long? Offset { get; set; }

    /// <summary>Indica se a paginação está ativada.</summary>
    [JsonPropertyName("paged")]
    public bool? Paged { get; set; }

    /// <summary>Número da página atual.</summary>
    [JsonPropertyName("pageNumber")]
    public int? PageNumber { get; set; }

    /// <summary>Quantidade de elementos por página.</summary>
    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

    /// <summary>Informações de ordenação.</summary>
    [JsonPropertyName("sort")]
    public OrdenacaoRenuncias? Sort { get; set; }

    /// <summary>Indica se a paginação está desativada.</summary>
    [JsonPropertyName("unpaged")]
    public bool? Unpaged { get; set; }
}

/// <summary>
/// Informações de ordenação (Sort) da consulta de renúncias.
/// </summary>
public sealed class OrdenacaoRenuncias
{
    /// <summary>Indica se está ordenado.</summary>
    [JsonPropertyName("sorted")]
    public bool? Sorted { get; set; }

    /// <summary>Indica se não está ordenado.</summary>
    [JsonPropertyName("unsorted")]
    public bool? Unsorted { get; set; }

    /// <summary>Indica se a ordenação está vazia.</summary>
    [JsonPropertyName("empty")]
    public bool? Empty { get; set; }
}

/// <summary>
/// Renúncia de vínculo contabilista.
/// </summary>
/// <remarks>Pelo menos um dos campos Solicitante (CPF/CNPJ) e um dos campos Renunciante é sempre preenchido.</remarks>
public sealed class Renuncia
{
    /// <summary>Identificador da renúncia (usado na emissão do comprovante).</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>CNPJ da empresa renunciada.</summary>
    [JsonPropertyName("cnpjRenunciada")]
    public string? CnpjRenunciada { get; set; }

    /// <summary>Data da renúncia em milissegundos desde 01/01/1970 (timestamp Unix; o exemplo a traz como texto).</summary>
    [JsonPropertyName("dataRenuncia")]
    public long? DataRenuncia { get; set; }

    /// <summary>CNPJ do solicitante.</summary>
    [JsonPropertyName("cnpjSolicitante")]
    public string? CnpjSolicitante { get; set; }

    /// <summary>CNPJ do renunciante.</summary>
    [JsonPropertyName("cnpjRenunciante")]
    public string? CnpjRenunciante { get; set; }

    /// <summary>CPF do solicitante.</summary>
    [JsonPropertyName("cpfSolicitante")]
    public string? CpfSolicitante { get; set; }

    /// <summary>CPF do renunciante.</summary>
    [JsonPropertyName("cpfRenunciante")]
    public string? CpfRenunciante { get; set; }

    /// <summary>CPF do usuário que realizou a requisição.</summary>
    [JsonPropertyName("cpfLogado")]
    public string? CpfLogado { get; set; }

    /// <summary>Data da renúncia convertida de <see cref="DataRenuncia"/> (UTC).</summary>
    [JsonIgnore]
    public DateTimeOffset? DataRenunciaUtc => DataRenuncia is long ms ? DateTimeOffset.FromUnixTimeMilliseconds(ms) : null;
}

/// <summary>
/// Entrada do serviço COMPRENUNCIA264 (Emitir Comprovante); o retorno é o PDF em Base64.
/// </summary>
public sealed class EmissaoComprovanteRenuncia
{
    /// <summary>ID da renúncia (<see cref="Renuncia.Id"/>).</summary>
    [JsonPropertyName("idRenuncia")]
    public long IdRenuncia { get; set; }
}

/// <summary>
/// Entrada do serviço SITSOLICRENUNCIA265 (Situação da Solicitação de Renúncia).
/// </summary>
/// <remarks>Recomenda-se aguardar ao menos 30 segundos após a solicitação.</remarks>
public sealed class ConsultaSituacaoRenuncia
{
    /// <summary>ID da solicitação de renúncia (<see cref="RetornoSolicitacaoRenuncia.IdSolicitacao"/>).</summary>
    [JsonPropertyName("idSolicitacao")]
    public string IdSolicitacao { get; set; } = string.Empty;
}

/// <summary>
/// Retorno do serviço SITSOLICRENUNCIA265: situação da solicitação de renúncia.
/// </summary>
public sealed class SituacaoSolicitacaoRenuncia
{
    /// <summary>Indica se a renúncia foi efetivada.</summary>
    [JsonPropertyName("resultado")]
    public bool? Resultado { get; set; }

    /// <summary>Mensagem com a situação da solicitação.</summary>
    [JsonPropertyName("mensagemRetorno")]
    public string? MensagemRetorno { get; set; }

    /// <summary>Renúncia efetivada (nula se ainda não processada ou negada).</summary>
    [JsonPropertyName("renuncia")]
    public Renuncia? Renuncia { get; set; }
}
