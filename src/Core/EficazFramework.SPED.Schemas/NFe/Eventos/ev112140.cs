using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Fornecimento não realizado com pagamento antecipado
/// </summary>
[XmlType("ev112140", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ev112140 : IbsCbsEventoBase
{
    /// <summary>
    /// Informações por item da Nota de Fornecimento não realizado
    /// </summary>
    [XmlElement("gItemNaoFornecido")]
    public List<ItemNaoFornecido>? ItensNaoFornecidos { get; set; }
}

/// <summary>
/// Informações por item da Nota de Fornecimento não realizado
/// </summary>
public class ItemNaoFornecido
{
    /// <summary>
    /// Valor do IBS na nota de débito de pagamento antecipado correspondente à quantidade que não foi fornecida
    /// </summary>
    [XmlElement("vIBS")]
    public decimal VIBS { get; set; }

    /// <summary>
    /// Valor da CBS na nota de débito de pagamento antecipado correspondente à quantidade que não foi fornecida.
    /// </summary>
    [XmlElement("vCBS")]
    public decimal VCBS { get; set; }

    [XmlElement("gControleEstoque")]
    public ControleEstoqueNaoFornecido ControleEstoque { get; set; } = new();

    /// <summary>
    /// Corresponde ao atributo “nItem” do elemento “det” da NF-e de importação
    /// </summary>
    [XmlAttribute("nItem")]
    public string NItem { get; set; }
}

/// <summary>
/// Controle de estoque para item não fornecido
/// </summary>
public class ControleEstoqueNaoFornecido
{
    /// <summary>
    /// Informar a quantidade que não foi fornecida e teve o imposto antecipado
    /// </summary>
    [XmlElement("qNaoFornecida")]
    public decimal QNaoFornecida { get; set; }

    /// <summary>
    /// Informar a unidade relativa ao campo qNaoFornecida
    /// </summary>
    [XmlElement("uNaoFornecida")]
    public string UNaoFornecida { get; set; }
}


