using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Destinação de item para consumo pessoal
/// </summary>
[XmlType("ev211120", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ev211120 : IbsCbsEventoBase
{
    /// <summary>
    /// Informações por item da NF-e de Aquisição
    /// </summary>
    [XmlElement("gConsumo")]
    public List<Consumo> Consumo { get; set; } = [];
}

/// <summary>
/// Informações por item da NF-e de Aquisição
/// </summary>
public class Consumo
{
    /// <summary>
    /// Corresponde ao atributo “nItem” do elemento “det” da NF-e de importação
    /// </summary>
    [XmlAttribute("nItem")]
    public int NItem { get; set; }

    /// <summary>
    /// Valor do IBS na nota de aquisição correspondente à quantidade destinada a uso e consumo pessoal
    /// </summary>
    [XmlElement("vIBS")]
    public decimal VIBS { get; set; }

    /// <summary>
    /// Valor da CBS na nota de aquisição correspondente à quantidade destinada a uso e consumo pessoal
    /// </summary>
    [XmlElement("vCBS")]
    public decimal VCBS { get; set; }

    /// <summary>
    /// Controle de estoque para consumo pessoal
    /// </summary>
    [XmlElement("gControleEstoque")]
    public ControleEstoqueConsumo ControleEstoque { get; set; } = new();

    /// <summary>
    /// Documento Fiscal Eletrônico Referenciado
    /// </summary>
    [XmlElement("DFeReferenciado")]
    public DFeReferenciadoConsumo DFeReferenciado { get; set; } = new();
}

/// <summary>
/// Controle de estoque para consumo pessoal
/// </summary>
public class ControleEstoqueConsumo
{
    /// <summary>
    /// Informar a quantidade para consumo de pessoa física
    /// </summary>
    [XmlElement("qConsumo")]
    public decimal QConsumo { get; set; }

    /// <summary>
    /// Informar a unidade relativa ao campo gConsumo
    /// </summary>
    [XmlElement("uConsumo")]
    public string UConsumo { get; set; } = string.Empty;
}

/// <summary>
/// Documento Fiscal Eletrônico Referenciado
/// </summary>
public class DFeReferenciadoConsumo
{
    /// <summary>
    /// Informar a chave da nota (NFe ou NFCe) emitida para o fornecimento nos casos em que a legislação obriga a emissão de documento fiscal.
    /// </summary>
    [XmlElement("chaveAcesso")]
    public string ChaveAcesso { get; set; } = string.Empty;

    /// <summary>
    /// Corresponde ao atributo “nItem” do elemento “det” do documento referenciado
    /// </summary>
    [XmlElement("nItem")]
    public int NItem { get; set; }
}

