using System.Xml;

namespace EficazFramework.SPED.Services.Utilities;

public class XMLFunctions
{
    public XmlDocument CreateXmlDocument()
    {
        return new XmlDocument();
    }

    public XmlDocument LoadXMLWithAnInformation(XmlDocument xmlDocument, string information)
    {
        xmlDocument.LoadXml(information);
        return xmlDocument;
    }
}
