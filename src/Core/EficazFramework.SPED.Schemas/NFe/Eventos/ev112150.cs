using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Atualização da Data de Previsão de Entrega
/// </summary>
[XmlType("ev112150", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ev112150 : IbsCbsEventoBase
{
    /// <summary>
    /// Data da previsão de entrega ou disponibilização do bem.
    /// </summary>
    [System.Xml.Serialization.XmlElement("dPrevEntrega")]
    public DateTime? DataPrevisaoEntrega { get; set; }
}

