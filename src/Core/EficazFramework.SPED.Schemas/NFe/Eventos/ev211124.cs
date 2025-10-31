using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Perecimento, perda, roubo ou furto durante o transporte contratado pelo adquirente
/// </summary>
public class ev211124 : IbsCbsEventoBase
{
    [XmlElement("gPerecimento")]
    public List<PerecimentoAdq>? Perecimento { get; set; }
}

/// <summary>
/// Informações por item da Nota de Aquisição
/// </summary>
public class PerecimentoAdq
{
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

    [XmlElement("gControleEstoque")]
    public PerecimentoControleEstoqueAdq ControleEstoque { get; set; } = new();

    /// <summary>
    /// Corresponde ao atributo “nItem” do elemento “det” da NF-e de importação
    /// </summary>
    [XmlAttribute("nItem")]
    public int NItem { get; set; }
}

public class PerecimentoControleEstoqueAdq
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
    public string UPerecimento { get; set; } = string.Empty;
}


