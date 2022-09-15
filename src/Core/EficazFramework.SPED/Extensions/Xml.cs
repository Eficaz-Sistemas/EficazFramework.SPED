namespace EficazFramework.SPED.Extensions;

public static class Xml
{
    /// <summary>
    /// Converte uma instância de System.Xml.XmlElement para System.Xml.Linq.XElement
    /// </summary>
    public static XElement ToXElement(this XmlElement source) =>
         XElement.Parse(source.OuterXml);


    /// <summary>
    /// Converte uma instância de System.Xml.Linq.XElement para System.Xml.XmlElement
    /// </summary>
    public static XmlElement ToXmlElement(this XElement source)
    {
        if (source == null)
            throw new NullReferenceException();

        XmlDocument tmp_doc = new();
        tmp_doc.Load(source.CreateReader());
        XmlElement result = tmp_doc.DocumentElement;
        return result;
    }


    /// <summary>
    /// Converte uma instância de System.Xml.Linq.XDocument para System.Xml.XmlDocument
    /// </summary>
    public static XmlDocument ToXmlDocument(this XDocument xDocument)
    {
        var xmlDocument = new XmlDocument();
        using (var xmlReader = xDocument.CreateReader())
        {
            xmlDocument.Load(xmlReader);
        }
        return xmlDocument;
    }

    /// <summary>
    /// Converte uma instância de System.Xml.XmlDocument para System.Xml.Linq.XDocument
    /// </summary>
    public static XDocument ToXDocument(this XmlDocument xmlDocument)
    {
        using var nodeReader = new XmlNodeReader(xmlDocument);
        nodeReader.MoveToContent();

        return XDocument.Load(nodeReader);
    }

}
