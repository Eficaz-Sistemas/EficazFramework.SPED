using System.IO;
using System.Xml;

namespace EficazFramework.SPED.Models.Contracts;

public interface IXMLFunctions
{
    public XmlDocument CreateXmlDocument();
    public XmlDocument LoadXMLWithAnInformation(XmlDocument xmlDocument, string information);
    public XmlDocument LoadXMLWithAnInformation(XmlDocument xmlDocument, byte[] data);
    public XmlWriter CreateXMLWriter(MemoryStream memoryStream, XmlWriterSettings xmlWriterSettings);
    public XmlWriterSettings CreateXMLWriterDefaultSettings(Encoding encoder);
    public StreamReader CreateStreamReader(MemoryStream memoryStream, Encoding encoder, bool specificEncoder);
    public void SaveObjectInstanceInXMLWriter(object instance, XmlWriter xmlWriter);
}
