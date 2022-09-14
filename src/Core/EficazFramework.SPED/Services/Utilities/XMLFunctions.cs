using EficazFramework.SPED.Models.Contracts;
using System.Xml;

namespace EficazFramework.SPED.Services.Utilities;

public class XMLFunctions : IXMLFunctions
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

    public XmlDocument LoadXMLWithAnInformation(XmlDocument xmlDocument, byte[] data)
    {
        xmlDocument.LoadXml(Encoding.UTF8.GetString(data));
        return xmlDocument;
    }
}
