using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraMEI;

/// <summary>
/// Retorno do serviço EMITIRCCMEI121 (CCMEI): Certificado da Condição de Microempreendedor Individual em PDF.
/// </summary>
public sealed class RetornoEmitirCcmei
{
    /// <summary>Número do CNPJ sem formatação.</summary>
    [JsonPropertyName("cnpj")]
    public string? Cnpj { get; set; }

    /// <summary>PDF do CCMEI no formato texto Base64.</summary>
    [JsonPropertyName("pdf")]
    public string? Pdf { get; set; }
}

/// <summary>
/// Retorno do serviço DADOSCCMEI122 (CCMEI): dados atualizados do Certificado da Condição de MEI.
/// </summary>
public sealed class DadosCcmei
{
    /// <summary>Número do CNPJ sem formatação.</summary>
    [JsonPropertyName("cnpj")]
    public string? Cnpj { get; set; }

    /// <summary>Informações do empresário.</summary>
    [JsonPropertyName("empresario")]
    public EmpresarioCcmei? Empresario { get; set; }

    /// <summary>Data de início das atividades no formato AAAA-MM-DD.</summary>
    [JsonPropertyName("dataInicioAtividades")]
    public string? DataInicioAtividades { get; set; }

    /// <summary>Nome empresarial.</summary>
    [JsonPropertyName("nomeEmpresarial")]
    public string? NomeEmpresarial { get; set; }

    /// <summary>Capital social do CNPJ.</summary>
    [JsonPropertyName("capitalSocial")]
    public decimal? CapitalSocial { get; set; }

    /// <summary>Situação cadastral do CNPJ.</summary>
    [JsonPropertyName("situacaoCadastralVigente")]
    public string? SituacaoCadastralVigente { get; set; }

    /// <summary>Data da atual situação cadastral no formato AAAA-MM-DD.</summary>
    [JsonPropertyName("dataInicioSituacaoCadastral")]
    public string? DataInicioSituacaoCadastral { get; set; }

    /// <summary>Endereço comercial.</summary>
    [JsonPropertyName("enderecoComercial")]
    public EnderecoComercialCcmei? EnderecoComercial { get; set; }

    /// <summary>Períodos de enquadramento como MEI.</summary>
    [JsonPropertyName("enquadramento")]
    public EnquadramentoCcmei? Enquadramento { get; set; }

    /// <summary>Atividade exercida pelo CNPJ.</summary>
    [JsonPropertyName("atividade")]
    public AtividadeCcmei? Atividade { get; set; }

    /// <summary>Termo assinalado como ciência da dispensa de alvará.</summary>
    [JsonPropertyName("termoCienciaDispensa")]
    public TermoCienciaDispensaCcmei? TermoCienciaDispensa { get; set; }

    /// <summary>QR Code para emissão do CCMEI no formato texto Base64.</summary>
    [JsonPropertyName("qrCode")]
    public string? QrCode { get; set; }
}

/// <summary>
/// Empresário titular do MEI (DADOSCCMEI122).
/// </summary>
public sealed class EmpresarioCcmei
{
    /// <summary>Nome civil do empresário.</summary>
    [JsonPropertyName("nomeCivil")]
    public string? NomeCivil { get; set; }

    /// <summary>Nome social do empresário.</summary>
    [JsonPropertyName("nomeSocial")]
    public string? NomeSocial { get; set; }

    /// <summary>CPF do empresário.</summary>
    [JsonPropertyName("cpf")]
    public string? Cpf { get; set; }
}

/// <summary>
/// Endereço comercial do MEI (DADOSCCMEI122).
/// </summary>
public sealed class EnderecoComercialCcmei
{
    /// <summary>CEP do endereço comercial (texto, conforme o exemplo de retorno).</summary>
    [JsonPropertyName("cep")]
    public string? Cep { get; set; }

    /// <summary>Logradouro.</summary>
    [JsonPropertyName("logradouro")]
    public string? Logradouro { get; set; }

    /// <summary>Número do logradouro.</summary>
    [JsonPropertyName("numero")]
    public string? Numero { get; set; }

    /// <summary>Complemento do logradouro.</summary>
    [JsonPropertyName("complemento")]
    public string? Complemento { get; set; }

    /// <summary>Bairro.</summary>
    [JsonPropertyName("bairro")]
    public string? Bairro { get; set; }

    /// <summary>Município.</summary>
    [JsonPropertyName("municipio")]
    public string? Municipio { get; set; }

    /// <summary>UF.</summary>
    [JsonPropertyName("uf")]
    public string? Uf { get; set; }
}

/// <summary>
/// Enquadramento como MEI (DADOSCCMEI122).
/// </summary>
public sealed class EnquadramentoCcmei
{
    /// <summary>Períodos de enquadramento.</summary>
    [JsonPropertyName("periodosMei")]
    public List<PeriodoMei>? PeriodosMei { get; set; }

    /// <summary>Situação do enquadramento (enquadrado ou não).</summary>
    [JsonPropertyName("situacao")]
    public string? Situacao { get; set; }

    /// <summary>Optante como MEI ou não.</summary>
    [JsonPropertyName("optanteMei")]
    public bool? OptanteMei { get; set; }
}

/// <summary>
/// Período de enquadramento como MEI (DADOSCCMEI122).
/// </summary>
public sealed class PeriodoMei
{
    /// <summary>Índice de ordenação.</summary>
    [JsonPropertyName("indice")]
    public int? Indice { get; set; }

    /// <summary>Data de início do enquadramento (AAAA-MM-DD; o exemplo traz AAAA-MM-DDTHH:mm:ss).</summary>
    [JsonPropertyName("dataInicio")]
    public string? DataInicio { get; set; }

    /// <summary>Data final do enquadramento (AAAA-MM-DD); nula quando vigente.</summary>
    [JsonPropertyName("dataFim")]
    public string? DataFim { get; set; }
}

/// <summary>
/// Atividade exercida pelo MEI (DADOSCCMEI122).
/// </summary>
public sealed class AtividadeCcmei
{
    /// <summary>Formas de atuação.</summary>
    [JsonPropertyName("formasAtuacao")]
    public List<string>? FormasAtuacao { get; set; }

    /// <summary>Ocupação principal exercida pelo CNPJ.</summary>
    [JsonPropertyName("ocupacaoPrincipal")]
    public OcupacaoCcmei? OcupacaoPrincipal { get; set; }

    /// <summary>Ocupações secundárias exercidas pelo CNPJ.</summary>
    [JsonPropertyName("ocupacoesSecundarias")]
    public List<OcupacaoCcmei>? OcupacoesSecundarias { get; set; }

    /// <summary>Optante como MEI ou não (consta na tabela da documentação, mas não no exemplo de retorno).</summary>
    [JsonPropertyName("optanteMei")]
    public bool? OptanteMei { get; set; }
}

/// <summary>
/// Ocupação (principal ou secundária) do MEI (DADOSCCMEI122).
/// </summary>
public sealed class OcupacaoCcmei
{
    /// <summary>Descrição da ocupação.</summary>
    [JsonPropertyName("descricaoOcupacao")]
    public string? DescricaoOcupacao { get; set; }

    /// <summary>Código da CNAE exercida.</summary>
    [JsonPropertyName("codigoCNAE")]
    public string? CodigoCnae { get; set; }

    /// <summary>Descrição da CNAE exercida.</summary>
    [JsonPropertyName("descricaoCNAE")]
    public string? DescricaoCnae { get; set; }
}

/// <summary>
/// Termo de ciência e responsabilidade com efeito de dispensa de alvará e licença de funcionamento (DADOSCCMEI122).
/// </summary>
public sealed class TermoCienciaDispensaCcmei
{
    /// <summary>Título do termo de dispensa de alvará e licenciamento.</summary>
    [JsonPropertyName("titulo")]
    public string? Titulo { get; set; }

    /// <summary>Texto do termo de dispensa de alvará e licenciamento.</summary>
    [JsonPropertyName("texto")]
    public string? Texto { get; set; }
}

/// <summary>
/// Retorno do serviço CCMEISITCADASTRAL123 (CCMEI): situação cadastral de um CNPJ (que tenha sido MEI) vinculado ao CPF.
/// </summary>
public sealed class SituacaoCadastralCcmei
{
    /// <summary>Número do CNPJ sem formatação.</summary>
    [JsonPropertyName("cnpj")]
    public string? Cnpj { get; set; }

    /// <summary>Atual situação cadastral do CNPJ.</summary>
    [JsonPropertyName("situacao")]
    public string? Situacao { get; set; }

    /// <summary>Atual situação de enquadramento MEI.</summary>
    [JsonPropertyName("enquadradoMei")]
    public bool? EnquadradoMei { get; set; }
}
