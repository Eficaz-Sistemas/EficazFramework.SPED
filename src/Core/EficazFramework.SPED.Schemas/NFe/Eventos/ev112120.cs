using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Importação em ALC/ZFM não convertida em isenção
/// </summary>
[XmlType("ev112120", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ev112120 : IbsCbsEventoBase
{
    public ConsumoImob? gConsumo { get; set; }
}

/// <summary>
/// Informações de itens integrados ao ativo imobilizado
/// </summary>
public class ConsumoImob
{
    /// <summary>
    /// Corresponde ao atributo “nItem” do elemento “det” da NF-e de importação
    /// </summary>
    [XmlAttribute("nItem")]
    public string NItem { get; set; } = null!;

    /// <summary>
    /// Valor do IBS correspondente à quantidade que não atendeu aos requisitos para a conversão em isenção
    /// </summary>
    [XmlElement("vIBS")]
    public decimal VIBS { get; set; }

    /// <summary>
    /// Valor do CBS correspondente à quantidade que não atendeu aos requisitos para a conversão em isenção
    /// </summary>
    [XmlElement("vCBS")]
    public decimal VCBS { get; set; }

    [XmlElement("gControleEstoque")]
    public ControleEstoqueImob? ControleEstoque { get; set; }
}


public class ControleEstoqueImob
{
    /// <summary>
    /// Informar a quantidade que não atendeu os requisitos para a conversão em isenção
    /// </summary>
    [XmlElement("qtde")]
    public decimal Qtde { get; set; }

    /// <summary>
    /// Informar a unidade relativa ao campo gConsumo
    /// </summary>
    [XmlElement("unidade")]
    public string Unidade { get; set; }
}
