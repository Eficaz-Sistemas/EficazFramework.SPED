using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraDCTFWeb;

/// <summary>
/// Categoria da declaração DCTFWeb (enviada como número no campo <c>categoria</c>).
/// </summary>
public enum CategoriaDctfWeb
{
    /// <summary>40 - GERAL_MENSAL. Também é a categoria das guias de apurações do MIT.</summary>
    GeralMensal = 40,
    /// <summary>41 - GERAL_13o_SALARIO (sem <c>mesPA</c>).</summary>
    Geral13Salario = 41,
    /// <summary>44 - AFERICAO (informar <c>cnoAfericao</c>).</summary>
    Afericao = 44,
    /// <summary>45 - ESPETACULO_DESPORTIVO (informar <c>diaPA</c>).</summary>
    EspetaculoDesportivo = 45,
    /// <summary>46 - RECLAMATORIA_TRABALHISTA (informar <c>numProcReclamatoria</c>).</summary>
    ReclamatoriaTrabalhista = 46,
    /// <summary>50 - PF_MENSAL.</summary>
    PfMensal = 50,
    /// <summary>51 - PF_13o_SALARIO (sem <c>mesPA</c>).</summary>
    Pf13Salario = 51
}

/// <summary>
/// Sistema de origem das receitas (campo <c>idsSistemaOrigem</c>), para gerar a guia apenas com as receitas desses sistemas.
/// </summary>
public enum SistemaOrigemDctfWeb
{
    /// <summary>1 - eSocial.</summary>
    ESocial = 1,
    /// <summary>5 - Sero.</summary>
    Sero = 5,
    /// <summary>6 - EFD-Reinf (contribuição previdenciária).</summary>
    ReinfCp = 6,
    /// <summary>7 - EFD-Reinf (retenções - RET).</summary>
    ReinfRet = 7,
    /// <summary>8 - MIT (Módulo de Inclusão de Tributos).</summary>
    Mit = 8
}

/// <summary>
/// Identificação da declaração DCTFWeb (categoria e período de apuração), comum às entradas dos serviços DCTFWEB
/// (serializada antes dos campos específicos de cada serviço, como nos exemplos da documentação).
/// </summary>
public abstract class DeclaracaoDctfWeb
{
    /// <summary>Categoria da declaração.</summary>
    [JsonPropertyName("categoria"), JsonPropertyOrder(-1)]
    public CategoriaDctfWeb Categoria { get; set; } = CategoriaDctfWeb.GeralMensal;

    /// <summary>Ano do período de apuração (AAAA).</summary>
    [JsonPropertyName("anoPA"), JsonPropertyOrder(-1)]
    public string AnoPA { get; set; } = string.Empty;

    /// <summary>Mês do período de apuração (MM, ex.: "06"). Não informar nas categorias 41 e 51 (13º salário).</summary>
    [JsonPropertyName("mesPA"), JsonPropertyOrder(-1)]
    public string? MesPA { get; set; }

    /// <summary>Dia do período de apuração (DD). Somente para a categoria 45 (espetáculo desportivo).</summary>
    [JsonPropertyName("diaPA"), JsonPropertyOrder(-1)]
    public string? DiaPA { get; set; }

    /// <summary>Número da obra (CNO). Somente para a categoria 44 (aferição).</summary>
    [JsonPropertyName("cnoAfericao"), JsonPropertyOrder(-1)]
    public long? CnoAfericao { get; set; }

    /// <summary>Número do processo da reclamatória trabalhista. Somente para a categoria 46.</summary>
    [JsonPropertyName("numProcReclamatoria"), JsonPropertyOrder(-1)]
    public string? NumProcReclamatoria { get; set; }
}

/// <summary>
/// Entrada dos serviços CONSRECIBO32 (recibo), CONSDECCOMPLETA33 (declaração completa) e CONSXMLDECLARACAO38 (XML da declaração).
/// </summary>
public sealed class ConsultaDctfWeb : DeclaracaoDctfWeb
{
    /// <summary>Número do recibo de entrega; quando não informado, a consulta é feita para a declaração mais recente.</summary>
    [JsonPropertyName("numeroReciboEntrega")]
    public long? NumeroReciboEntrega { get; set; }
}

/// <summary>
/// Entrada do serviço GERARGUIA31: gera o documento de arrecadação (DARF) de uma declaração ATIVA.
/// </summary>
public sealed class GerarGuiaDctfWeb : DeclaracaoDctfWeb
{
    /// <summary>Número do recibo de entrega; quando não informado, a guia é gerada para a declaração mais recente.</summary>
    [JsonPropertyName("numeroReciboEntrega")]
    public long? NumeroReciboEntrega { get; set; }

    /// <summary>
    /// Data proposta para acolhimento/pagamento da guia, no formato AAAAMMDD (número): dia útil do mês corrente,
    /// igual ou posterior a hoje (mesmas regras da opção "editar DARF" da DCTFWeb).
    /// </summary>
    [JsonPropertyName("DataAcolhimentoProposta")]
    public int? DataAcolhimentoProposta { get; set; }

    /// <summary>Sistemas de origem das receitas; quando informado, a guia contém apenas as receitas desses sistemas.</summary>
    [JsonPropertyName("idsSistemaOrigem")]
    public List<SistemaOrigemDctfWeb>? IdsSistemaOrigem { get; set; }
}

/// <summary>
/// Entrada do serviço GERARGUIAANDAMENTO313: gera o documento de arrecadação de uma declaração EM ANDAMENTO.
/// </summary>
public sealed class GerarGuiaAndamentoDctfWeb : DeclaracaoDctfWeb
{
    /// <summary>Sistemas de origem das receitas; quando informado, a guia contém apenas as receitas desses sistemas.</summary>
    [JsonPropertyName("idsSistemaOrigem")]
    public List<SistemaOrigemDctfWeb>? IdsSistemaOrigem { get; set; }
}

/// <summary>
/// Entrada do serviço TRANSDECLARACAO310: transmite uma declaração EM ANDAMENTO a partir do XML obtido no
/// CONSXMLDECLARACAO38, assinado pelo autor do pedido de dados.
/// </summary>
/// <remarks>
/// A assinatura (XMLDSig enveloped, RSA-SHA256, C14N, somente o certificado final) deve ser feita na tag
/// <c>ConteudoDeclaracao</c>, com o certificado do autor do pedido de dados. Fora a assinatura, o XML deve ser
/// idêntico, caractere a caractere, ao recebido no CONSXMLDECLARACAO38.
/// </remarks>
public sealed class TransmitirDeclaracaoDctfWeb : DeclaracaoDctfWeb
{
    /// <summary>XML da declaração, assinado e codificado em Base64.</summary>
    [JsonPropertyName("xmlAssinadoBase64")]
    public string XmlAssinadoBase64 { get; set; } = string.Empty;
}

/// <summary>
/// Retorno dos serviços GERARGUIA31, CONSRECIBO32, CONSDECCOMPLETA33 e GERARGUIAANDAMENTO313: documento PDF em Base64.
/// </summary>
public sealed class RetornoPdfDctfWeb
{
    /// <summary>Documento (DARF ou relatório) no formato PDF, em Base64.</summary>
    [JsonPropertyName("PDFByteArrayBase64")]
    public string? PdfBase64 { get; set; }

    /// <summary>Conteúdo binário do PDF (nulo quando não houver documento).</summary>
    public byte[]? ObterPdf() => string.IsNullOrEmpty(PdfBase64) ? null : Convert.FromBase64String(PdfBase64);
}

/// <summary>
/// Retorno do serviço CONSXMLDECLARACAO38: XML da declaração em Base64 (já assinado, se transmitida; para assinatura, se em andamento).
/// </summary>
public sealed class RetornoXmlDctfWeb
{
    /// <summary>XML da declaração, em Base64.</summary>
    [JsonPropertyName("XMLStringBase64")]
    public string? XmlBase64 { get; set; }

    /// <summary>Conteúdo binário do XML (nulo quando não houver XML); deve ser assinado sem nenhuma outra alteração.</summary>
    public byte[]? ObterXml() => string.IsNullOrEmpty(XmlBase64) ? null : Convert.FromBase64String(XmlBase64);
}

/// <summary>
/// Retorno do serviço TRANSDECLARACAO310.
/// </summary>
public sealed class RetornoTransmissaoDctfWeb
{
    /// <summary>Número do recibo de transmissão da declaração.</summary>
    [JsonPropertyName("NumeroRecibo")]
    public long? NumeroRecibo { get; set; }
}
