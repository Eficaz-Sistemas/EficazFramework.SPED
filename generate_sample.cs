using System;
using System.IO;
using System.Xml.Linq;
using EficazFramework.SPED.Schemas.eSocial;
using EficazFramework.Tests.Schemas.eSocial;

class Program
{
    static void Main()
    {
        var test = new S2399Test();
        test._versao = Versao.v_S_01_03_00;
        var evento = new S2399();
        test.PreencheCampos(evento);
        
        string xml;
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(S2399));
        using (var stringWriter = new System.IO.StringWriter())
        {
            using (var xmlWriter = System.Xml.XmlWriter.Create(stringWriter, new System.Xml.XmlWriterSettings { Indent = true }))
            {
                serializer.Serialize(xmlWriter, evento);
                xml = stringWriter.ToString();
            }
        }
        
        // Remove UTF-16 declaration if any, force utf-8
        xml = xml.Replace("utf-16", "utf-8");

        string resxPath = @"c:\repos\Eficaz-Sistemas\EficazFramework.SPED\src\Tests\EficazFramework.Tests\Resources\Samples\eSocial.resx";
        var doc = XDocument.Load(resxPath);
        
        // Remove existing if any
        foreach (var element in doc.Root.Elements("data"))
        {
            if (element.Attribute("name")?.Value == "S2399_v_S_01_03_00")
            {
                element.Remove();
                break;
            }
        }
        
        var newData = new XElement("data", 
            new XAttribute("name", "S2399_v_S_01_03_00"),
            new XAttribute(XNamespace.Xml + "space", "preserve"),
            new XElement("value", xml)
        );
        
        doc.Root.Add(newData);
        doc.Save(resxPath);
        
        Console.WriteLine("Added to resx successfully!");
    }
}
