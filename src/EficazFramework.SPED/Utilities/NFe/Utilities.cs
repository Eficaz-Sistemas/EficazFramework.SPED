using System;
using System.IO;
using System.Text;
using System.Xml;

namespace EficazFrameworkCore.SPED.Utilities.NFe
{
    public class DownloadNF
    {
        public static XmlDocument NFeToXmlDocument(object instance)
        {
            if (instance is null)
                return null;
            string tmp = ((XmlElement)((XmlNode[])instance)[1]).OuterXml;
            var xml = new XmlDocument();
            xml.LoadXml(tmp);
            return xml;
        }

        public static XmlDocument NFeToXmlDocument(byte[] data)
        {
            var xml = new XmlDocument();
            xml.LoadXml(Encoding.UTF8.GetString(data));
            return xml;
        }

        public static string NFeToXmlString(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }

        public static string NFeToXmlString(object instance, Encoding encoder)
        {
            if (instance is null)
                return null;
            try
            {
                var xml = NFeToXmlDocument(instance);
                var ms = new MemoryStream();
                var xmlWriter = XmlWriter.Create(ms, new XmlWriterSettings() { Indent = false, NewLineChars = string.Empty, Encoding = encoder });
                xml.Save(xmlWriter);
                var reader = new StreamReader(ms, encoder, true);
                ms.Seek(0L, SeekOrigin.Begin);
                string res = reader.ReadToEnd();
                ms.Close();
                ms.Dispose();
                reader.Close();
                reader.Dispose();
                return res;
            }
            // Return stringWriter.ToString
            catch (Exception)
            {
                return null;
            }
        }

        public static Schemas.NFe.ProcessoNFe NFeObject(object instance)
        {
            var proc = Schemas.NFe.ProcessoNFe.Deserialize(NFeToXmlString(instance, Encoding.UTF8)); // twr.ToString)
            return proc;
        }
    }
}