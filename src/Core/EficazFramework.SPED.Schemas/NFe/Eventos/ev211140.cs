using System.Xml.Serialization;
using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Solicitação de Apropriação de Crédito de Combustível
/// </summary>
public class ev211140 : IbsCbsEventoBase
{
    /// <summary>
    /// Informações de consumo de combustíveis
    /// </summary>
    [XmlElement("gConsumoComb")]
    public List<ConsumoCombustivel> ConsumosCombustivel { get; set; } = new();
}

public class ConsumoCombustivel
{
    /// <summary>
    /// Valor do IBS relativo ao consumo de combustível na nota de aquisição
    /// </summary>
    [XmlElement("vIBS")]
    public decimal ValorIBS { get; set; }

    /// <summary>
    /// Valor da CBS relativo ao consumo de combustível na nota de aquisição
    /// </summary>
    [XmlElement("vCBS")]
    public decimal ValorCBS { get; set; }

    /// <summary>
    /// Informações de controle de estoque
    /// </summary>
    [XmlElement("gControleEstoque")]
    public ControleEstoqueCombustivel ControleEstoque { get; set; } = new();

    /// <summary>
    /// Corresponde ao atributo “nItem” do elemento “det” da NF-e de importação
    /// </summary>
    [XmlAttribute("nItem")]
    public int NumeroItem { get; set; }
}

public class ControleEstoqueCombustivel
{
    /// <summary>
    /// Informar a quantidade de consumo do item
    /// </summary>
    [XmlElement("qComb")]
    public decimal QuantidadeCombustivel { get; set; }

    /// <summary>
    /// Informar a unidade relativa ao campo qComb
    /// </summary>
    [XmlElement("uComb")]
    public string UnidadeCombustivel { get; set; }
}