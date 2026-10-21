namespace EficazFramework.SPED.Schemas.CTe;

/// <summary>
/// Base para o conteúdo específico (detEvento) dos eventos do CT-e
/// </summary>
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
public abstract class DetalheEvento
{
    [XmlElement("descEvento")]
    public string Descricao { get; set; }

    /// <summary>
    /// Serializa o detalhe como elemento XML, para ser acoplado ao detEvento
    /// </summary>
    public XElement ToXElement()
    {
        var ns = new XmlSerializerNamespaces();
        ns.Add("", "http://www.portalfiscal.inf.br/cte");
        using var sw = new System.IO.StringWriter();
        new XmlSerializer(GetType()).Serialize(sw, this, ns);
        return XElement.Parse(sw.ToString());
    }
}
