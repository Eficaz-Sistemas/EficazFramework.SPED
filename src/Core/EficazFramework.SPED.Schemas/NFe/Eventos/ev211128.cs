using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Aceite de débito na apuração por emissão de nota de crédito
/// </summary>
[XmlType("ev211128", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ev211128 : IbsCbsEventoBase
{
    [XmlElement("indAceitacao")]
    public IndicadorAceite IndicadorAceite { get; set; } = IndicadorAceite.NaoAceite;
}

public enum IndicadorAceite
{
    [System.ComponentModel.Description("Não Aceite")]
    [System.Xml.Serialization.XmlEnum("0")]
    NaoAceite = 0,

    [System.ComponentModel.Description("Aceite")]
    [System.Xml.Serialization.XmlEnum("1")]
    Aceite = 1,
}