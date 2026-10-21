namespace EficazFramework.SPED.Schemas.CTe;

/// <summary>
/// Cancelamento da Prestação do Serviço em Desacordo (610111)
/// </summary>
[XmlType("evCancPrestDesacordo", Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("evCancPrestDesacordo", Namespace = "http://www.portalfiscal.inf.br/cte")]
public class evCancPrestDesacordo : DetalheEvento
{
    public evCancPrestDesacordo() => Descricao = "Cancelamento Prestacao do Servico em Desacordo";

    /// <summary>
    /// Protocolo do evento de prestação de serviço em desacordo que será cancelado
    /// </summary>
    [XmlElement("nProtEvPrestDes")]
    public string ProtocoloEventoDesacordo { get; set; }
}
