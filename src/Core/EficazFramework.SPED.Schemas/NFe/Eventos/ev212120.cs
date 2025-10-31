using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Manifestação sobre Pedido de Transferência de Crédito de IBS em Operação de Sucessão
/// </summary>
public class ev212110 : IbsCbsEventoBase
{
    [XmlElement("indAceitacao")]
    public IndicadorAceite IndicadorAceite { get; set; } = IndicadorAceite.NaoAceite;
}
