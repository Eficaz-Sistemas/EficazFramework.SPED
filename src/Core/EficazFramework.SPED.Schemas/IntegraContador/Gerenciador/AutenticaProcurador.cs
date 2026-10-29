using System.Globalization;
using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.Gerenciador;

/// <summary>
/// Termo de Autorização (AUTENTICAPROCURADOR): o autor do pedido de dados (procurador) autoriza o contratante a
/// executar requisições em seu nome. Deve ser assinado (XMLDSig RSA-SHA256, enveloped, URI vazia) com o certificado
/// do autor do pedido de dados.
/// </summary>
public sealed class TermoAutorizacao
{
    /// <summary>Texto fixo do atributo <c>termo/@texto</c>.</summary>
    public const string TextoTermo = "Autorizo a empresa CONTRATANTE, identificada neste termo de autorização como DESTINATÁRIO, a executar as requisições dos serviços web disponibilizados pela API INTEGRA CONTADOR, onde terei o papel de AUTOR PEDIDO DE DADOS no corpo da mensagem enviada na requisição do serviço web. Esse termo de autorização está assinado digitalmente com o certificado digital do PROCURADOR ou OUTORGADO DO CONTRIBUINTE responsável, identificado como AUTOR DO PEDIDO DE DADOS.";

    /// <summary>Texto fixo do atributo <c>avisoLegal/@texto</c>.</summary>
    public const string TextoAvisoLegal = "O acesso a estas informações foi autorizado pelo próprio PROCURADOR ou OUTORGADO DO CONTRIBUINTE, responsável pela informação, via assinatura digital. É dever do destinatário da autorização e consumidor deste acesso observar a adoção de base legal para o tratamento dos dados recebidos conforme artigos 7º ou 11º da LGPD (Lei n.º 13.709, de 14 de agosto de 2018), aos direitos do titular dos dados (art. 9º, 17 e 18, da LGPD) e aos princípios que norteiam todos os tratamentos de dados no Brasil (art. 6º, da LGPD).";

    /// <summary>Texto fixo do atributo <c>finalidade/@texto</c>.</summary>
    public const string TextoFinalidade = "A finalidade única e exclusiva desse TERMO DE AUTORIZAÇÃO, é garantir que o CONTRATANTE apresente a API INTEGRA CONTADOR esse consentimento do PROCURADOR ou OUTORGADO DO CONTRIBUINTE assinado digitalmente, para que possa realizar as requisições dos serviços web da API INTEGRA CONTADOR em nome do AUTOR PEDIDO DE DADOS (PROCURADOR ou OUTORGADO DO CONTRIBUINTE).";

    /// <summary>Nome do elemento raiz (ponto de inserção da assinatura).</summary>
    public const string ElementoRaiz = "termoDeAutorizacao";

    /// <summary>CNPJ do contratante (destinatário da autorização), somente números.</summary>
    public string CnpjContratante { get; set; } = string.Empty;

    /// <summary>Razão social do contratante.</summary>
    public string NomeContratante { get; set; } = string.Empty;

    /// <summary>CPF/CNPJ do autor do pedido de dados (deve ser o do certificado que assina), somente números.</summary>
    public string NumeroAutor { get; set; } = string.Empty;

    /// <summary>Nome do autor do pedido de dados.</summary>
    public string NomeAutor { get; set; } = string.Empty;

    /// <summary>Tipo do autor do pedido de dados: CPF (PF) ou CNPJ (PJ).</summary>
    public TipoIdentificacao TipoAutor { get; set; } = TipoIdentificacao.CNPJ;

    /// <summary>Data da assinatura do termo.</summary>
    public DateTime DataAssinatura { get; set; } = DateTime.Today;

    /// <summary>Data de validade do termo.</summary>
    public DateTime Vigencia { get; set; } = DateTime.Today.AddYears(1);

    /// <summary>
    /// Gera o XML do termo (sem indentação), pronto para assinatura.
    /// </summary>
    public XmlDocument GerarXml()
    {
        var tipoAutor = TipoAutor == TipoIdentificacao.CPF ? "PF" : "PJ";
        var raiz = new XElement(ElementoRaiz,
            new XElement("dados",
                new XElement("sistema", new XAttribute("id", "API Integra Contador")),
                new XElement("termo", new XAttribute("texto", TextoTermo)),
                new XElement("avisoLegal", new XAttribute("texto", TextoAvisoLegal)),
                new XElement("finalidade", new XAttribute("texto", TextoFinalidade)),
                new XElement("dataAssinatura", new XAttribute("data", DataAssinatura.ToString("yyyyMMdd", CultureInfo.InvariantCulture))),
                new XElement("vigencia", new XAttribute("data", Vigencia.ToString("yyyyMMdd", CultureInfo.InvariantCulture))),
                new XElement("destinatario",
                    new XAttribute("numero", CnpjContratante),
                    new XAttribute("nome", NomeContratante),
                    new XAttribute("tipo", "PJ"),
                    new XAttribute("papel", "contratante")),
                new XElement("assinadoPor",
                    new XAttribute("numero", NumeroAutor),
                    new XAttribute("nome", NomeAutor),
                    new XAttribute("tipo", tipoAutor),
                    new XAttribute("papel", "autor pedido de dados"))));

        // sem declaração XML e sem indentação, como no exemplo da documentação
        var xml = new XmlDocument { PreserveWhitespace = false };
        xml.LoadXml(raiz.ToString(SaveOptions.DisableFormatting));
        return xml;
    }
}

/// <summary>
/// Entrada do serviço ENVIOXMLASSINADO81: termo de autorização assinado, em Base64.
/// </summary>
/// <param name="Xml">XML assinado do termo de autorização, codificado em Base64.</param>
public sealed record EnvioXmlAssinado([property: JsonPropertyName("xml")] string Xml);

/// <summary>
/// Retorno do serviço ENVIOXMLASSINADO81: token do procurador, enviado no cabeçalho
/// <c>autenticar_procurador_token</c> das requisições feitas em nome do autor do pedido de dados.
/// </summary>
public sealed class RetornoAutenticaProcurador
{
    /// <summary>Token do procurador (UUID de 36 caracteres).</summary>
    [JsonPropertyName("autenticar_procurador_token")]
    public string? Token { get; set; }

    /// <summary>Data e hora de expiração do token (yyyy-MM-ddTHH:mm:ss, horário de Brasília).</summary>
    [JsonPropertyName("data_hora_expiracao")]
    public DateTime? DataHoraExpiracao { get; set; }
}
