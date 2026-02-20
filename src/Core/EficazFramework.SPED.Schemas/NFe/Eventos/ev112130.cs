using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Perecimento, perda, roubo ou furto durante o transporte contratado pelo fornecedor 
/// </summary>
[XmlType("ev112130", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ev112130 : IbsCbsEventoBase
{
    public Perecimento? gPerecimento { get; set; }
}

/// <summary>
/// Informações por item da Nota de Fornecimento (roubo, perda, furto ou perecimento)
/// </summary>
public class Perecimento
{
    /// <summary>
    /// Corresponde ao atributo “nItem” do elemento “det” da NF-e de importação
    /// </summary>
    [XmlAttribute("nItem")]
    public string NItem { get; set; } = null!;

    /// <summary>
    /// Valor do IBS na Nota de Fornecimento correspondente à quantidade que foi objeto de roubo, perda, furto ou perecimento.
    /// </summary>
    [XmlElement("vIBS")]
    public decimal VIBS { get; set; }

    /// <summary>
    /// Valor da CBS na Nota de Fornecimento correspondente à quantidade que foi objeto de roubo, perda, furto ou perecimento.
    /// </summary>
    [XmlElement("vCBS")]
    public decimal VCBS { get; set; }

    [XmlElement("gControleEstoque")]
    public PerecimentoControleEstoque ControleEstoque { get; set; } = null!;
}

public class PerecimentoControleEstoque
{
    /// <summary>
    /// Informar a quantidade que foi objeto de roubo, perda, furto ou perecimento
    /// </summary>
    [XmlElement("qPerecimento")]
    public decimal QPerecimento { get; set; }

    /// <summary>
    /// Informar a unidade relativa ao campo qPerecimento
    /// </summary>
    [XmlElement("uPerecimento")]
    public string UPerecimento { get; set; } = null!;

    /// <summary>
    /// Valor do crédito IBS referente às aquisições a ser estornado correspondente à quantidade que foi objeto de roubo, perda, furto ou perecimento
    /// </summary>
    [XmlElement("vIBS")]
    public decimal VIBS { get; set; }

    /// <summary>
    /// Valor do crédito CBS referente às aquisições a ser estornado correspondente à quantidade que foi objeto de roubo, perda, furto ou perecimento
    /// </summary>
    [XmlElement("vCBS")]
    public decimal VCBS { get; set; }
}

