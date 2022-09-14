using EficazFramework.SPED.Models.Contracts;
using System.IO;
using System.Xml;
using EficazFramework.SPED.Schemas.NFe;

namespace EficazFramework.SPED.Utilities.NFe;

public class DownloadNF
{
    private readonly IXMLFunctions _xmlFunctions;

    public DownloadNF(IXMLFunctions xmlFunctions)
    {
        _xmlFunctions = xmlFunctions;
    }

    /// <summary>
    /// Método para converter NFe em um documento XML
    /// </summary>
    /// <param name="instance">Informação para o XML Document</param>
    public XmlDocument NFeToXmlDocument(object instance)
    {
        if (instance is null) return null;

        return _xmlFunctions.LoadXMLWithAnInformation(_xmlFunctions.CreateXmlDocument(), ((XmlElement)((XmlNode[])instance)[1]).OuterXml);
    }

    public XmlDocument NFeToXmlDocument(byte[] data)
    {
        return _xmlFunctions.LoadXMLWithAnInformation(_xmlFunctions.CreateXmlDocument(), data);
    }

    public string NFeToXmlString(byte[] data)
    {
        return Encoding.UTF8.GetString(data);
    }

    public string NFeToXmlString(object instance, Encoding encoder)
    {
        if (instance is null)
            return null;
        try
        {
            var xml = NFeToXmlDocument(instance);
            using (var ms = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(ms, new XmlWriterSettings() { Indent = false, NewLineChars = string.Empty, Encoding = encoder }))
                {
                    xml.Save(xmlWriter);
                    using (var reader = new StreamReader(ms, encoder, true))
                    {
                        ms.Seek(0L, SeekOrigin.Begin);
                        string res = reader.ReadToEnd();
                        return res;
                    }
                }
            }
        }
        // Return stringWriter.ToString
        catch (Exception)
        {
            return null;
        }
    }

    public ProcessoNFe NFeObject(object instance)
    {
        var proc = ProcessoNFe.Deserialize(NFeToXmlString(instance, Encoding.UTF8)); // twr.ToString)
        return proc;
    }
}
