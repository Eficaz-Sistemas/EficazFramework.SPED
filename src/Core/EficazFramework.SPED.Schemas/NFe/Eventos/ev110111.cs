namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Cancelamento
/// </summary>
public class ev110111 : DetalheEvento
{
    [XmlElement("nProt")]
    public string? Protocolo { get; set; }

    [XmlElement("xJust")]
    public string? Justificativa { get; set; }

}
