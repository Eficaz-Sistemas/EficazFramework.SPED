using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Solicitação de Apropriação de crédito presumido
/// </summary>
public class ev211110 : IbsCbsEventoBase
{
    [XmlElement("gIBS")]
    public CreditoPresumido Ibs { get; set; } = new CreditoPresumido();

    [XmlElement("gCBS")]
    public CreditoPresumido Cbs { get; set; } = new CreditoPresumido();

}

