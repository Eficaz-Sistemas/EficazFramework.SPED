using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Imobilização de Item
/// </summary>
[XmlType("ev211130", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ev211130 : IbsCbsEventoBase
{
    /// <summary>
    /// Informações de itens integrados ao ativo imobilizado
    /// </summary>
    [XmlElement("gImobilizacao")]
    public List<Imobilizacao> Imobilizacoes { get; set; } = new();
}

public class Imobilizacao
{
    /// <summary>
    /// Valor do IBS relativo à imobilização
    /// </summary>
    [XmlElement("vIBS")]
    public decimal ValorIBS { get; set; }

    /// <summary>
    /// Valor da CBS relativo à imobilização
    /// </summary>
    [XmlElement("vCBS")]
    public decimal ValorCBS { get; set; }

    /// <summary>
    /// Controle de estoque do item imobilizado
    /// </summary>
    [XmlElement("gControleEstoque")]
    public ControleEstoqueImobilizacao ControleEstoque { get; set; } = new();

    /// <summary>
    /// Corresponde ao atributo “nItem” do elemento “det” da NF-e de importação
    /// </summary>
    [XmlAttribute("nItem")]
    public int NumeroItem { get; set; }
}

public class ControleEstoqueImobilizacao
{
    /// <summary>
    /// Informar a quantidade do item a ser imobilizado
    /// </summary>
    [XmlElement("qImobilizado")]
    public decimal QuantidadeImobilizado { get; set; }

    /// <summary>
    /// Informar a unidade relativa ao campo qImobilizado
    /// </summary>
    [XmlElement("uImobilizado")]
    public string UnidadeImobilizado { get; set; } = string.Empty;
}