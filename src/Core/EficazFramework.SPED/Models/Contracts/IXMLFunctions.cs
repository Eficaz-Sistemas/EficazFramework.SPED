using System.Xml;

namespace EficazFramework.SPED.Models.Contracts;

public interface IXMLFunctions
{
    public XmlDocument CreateXmlDocument();
    public XmlDocument LoadXMLWithAnInformation(XmlDocument xmlDocument, string information);
    public XmlDocument LoadXMLWithAnInformation(XmlDocument xmlDocument, byte[] data);
}
