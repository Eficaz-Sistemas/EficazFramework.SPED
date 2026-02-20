using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Manifestação sobre Pedido de Transferência de Créditode CBS em Operação de Sucessão
/// </summary>
[XmlType("ev212120", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ev212120 : IbsCbsEventoBase
{
    [XmlElement("indAceitacao")]
    public IndicadorAceite IndicadorAceite { get; set; } = IndicadorAceite.NaoAceite;
}
