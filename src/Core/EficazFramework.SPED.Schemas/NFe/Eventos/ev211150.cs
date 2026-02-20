using System.Xml.Serialization;
using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Solicitação de Apropriação de Crédito para bens e serviços que dependem de atividade do adquirente
/// </summary>
[XmlType("ev211150", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ev211150 : IbsCbsEventoBase
{
    [XmlElement("gCredito")]
    public List<CreditosApropriar>? Creditos { get; set; }
}

/// <summary>
/// Informações de crédito
/// </summary>
public class CreditosApropriar
{
    /// <summary>
    /// Valor da solicitação de crédito a ser apropriado de IBS
    /// </summary>
    [XmlElement("vCredIBS")]
    public decimal ValorCreditoIBS { get; set; }

    /// <summary>
    /// Valor da solicitação de crédito a ser apropriado de CBS
    /// </summary>
    [XmlElement("vCredCBS")]
    public decimal ValorCreditoCBS { get; set; }

    /// <summary>
    /// Corresponde ao atributo “nItem” do elemento “det” da NF-e de importação
    /// </summary>
    [XmlAttribute("nItem")]
    public int NumeroItem { get; set; }
}

