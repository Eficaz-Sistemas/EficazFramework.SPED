﻿using EficazFramework.SPED.Models.Contracts;
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
        return _xmlFunctions.LoadXMLWithAnInformation(_xmlFunctions.CreateXmlDocument(), ((XmlElement)((XmlNode[])instance)[1]).OuterXml);
    }

    public XmlDocument NFeToXmlDocument(byte[] data)
    {
        return _xmlFunctions.LoadXMLWithAnInformation(_xmlFunctions.CreateXmlDocument(), data);
    }

    public string NFeToXmlString(object instance, MemoryStream memoryStream, XmlWriter xmlWriter, StreamReader streamReader)
    {
        try
        {
            using (memoryStream)
            {
                using (xmlWriter)
                {
                    NFeToXmlDocument(instance).Save(xmlWriter);
                    using (streamReader)
                    {
                        memoryStream.Seek(0L, SeekOrigin.Begin);
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
        // Return stringWriter.ToString
        catch
        {
            return null;
        }
    }

    public ProcessoNFe NFeObject(object instance)
    {
        if (instance is null) return null;

        using var memoryStream = new MemoryStream();
        return ProcessoNFe.Deserialize(
            NFeToXmlString
                (
                instance, 
                memoryStream, 
                _xmlFunctions.CreateXMLWriter(memoryStream, _xmlFunctions.CreateXMLWriterDefaultSettings(Encoding.UTF8)),
                _xmlFunctions.CreateStreamReader(memoryStream, Encoding.UTF8, true)
                )
            ); 
        
        // twr.ToString)
    }
}
