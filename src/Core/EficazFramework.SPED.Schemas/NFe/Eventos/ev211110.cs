using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Solicitação de Apropriação de crédito presumido
/// </summary>
[XmlType("ev211110", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ev211110 : IbsCbsEventoBase
{
    [XmlElement("gIBS")]
    public CreditoPresumido Ibs { get; set; } = new CreditoPresumido();

    [XmlElement("gCBS")]
    public CreditoPresumido Cbs { get; set; } = new CreditoPresumido();

}

