using EficazFramework.SPED.Models.Contracts;
using System.IO;
using System.Xml;

namespace EficazFramework.SPED.Services.Utilities;

public class XMLFunctions : IXMLFunctions
{
    /// <summary>
    /// Método usado para criação de Documento XML
    /// </summary>
    /// <returns>Retorno em objeto (XmlDocument) nulo.</returns>
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

    public XmlWriter CreateXMLWriter(MemoryStream memoryStream, XmlWriterSettings xmlWriterSettings)
    {
        return XmlWriter.Create(memoryStream, xmlWriterSettings);
    }

    public XmlWriterSettings CreateXMLWriterDefaultSettings(Encoding encoder)
    {
        return new XmlWriterSettings() { Indent = false, NewLineChars = string.Empty, Encoding = encoder };
    }

    public StreamReader CreateStreamReader(MemoryStream memoryStream, Encoding encoder, bool specificEncoder)
    {
        return new StreamReader(memoryStream, encoder, specificEncoder);
    }

    public void SaveObjectInstanceInXMLWriter(object instance, XmlWriter xmlWriter)
    {
        LoadXMLWithAnInformation(CreateXmlDocument(), ((XmlElement)((XmlNode[])instance)[1]).OuterXml).Save(xmlWriter);
    }

    public MemoryStream CreateMemoryStreamWithParameters()
    {
        var memoryStream = new MemoryStream();
        memoryStream.Seek(0L, SeekOrigin.Begin);
        return memoryStream;
    }
}
