using EficazFramework.SPED.Schemas;
using System.Collections.Generic;

namespace EficazFramework.SPED.Tests;

public class BaseXmlTest<T> : BaseTest where T : IXmlSpedDocument
{
    private int _validationErrorCount = 0;
    private List<string> _validationErrorsList = [];

    /// <summary>
    /// Executa a leitura de um XML a partir de seu conteúdo em texto plano (string)
    /// </summary>
    internal static async Task<T> ReadAsync(string xmlString)
    {
        MemoryStream stream = new();
        StreamWriter writer = new(stream);
        await writer.WriteAsync(xmlString);
        writer.Flush();
        stream.Position = 0;
        return await ReadAsync(stream);
    }

    /// <summary>
    /// Executa a leitura (desserialização) de um XML a partir do stream de bytes
    /// </summary>
    internal static async Task<T> ReadAsync(Stream xmlStream)
    {
        T def = Activator.CreateInstance<T>();
        IXmlSpedDocument document = await SPED.Utilities.XML.Operations.OpenAsync(xmlStream);
        document.DocumentType.Should().Be(def.DocumentType);
        return (T)document;
    }


    internal IEnumerable<string> ValidateSchemaAsync( 
        T instance,
        string[] nmspace,
        string[] schemas,
        string tagToSign)
    {
        _validationErrorCount = 0;
        _validationErrorsList.Clear();
        XmlDocument doc = new();
        doc.LoadXml(instance.Serialize());

        // assinando o documento XML com o certificado digital e-CNPJ de testes
        Utilities.IcpBrasilX509Certificate2 cert = new Utilities.IcpBrasilX509Certificate2($"{Environment.CurrentDirectory}\\Resources\\Certificados\\WayneEnterprisesInc.pfx", "1234");
        Utilities.XML.Sign.SignXml(doc, doc.LastChild.Name, tagToSign, cert, false, false);

        // adicionando os schemas para validação do documento XML
        ValidationEventHandler eventHandler = new(ValidationEventHandler);
        for (int i = 0; i < schemas.Length; i++)
        {
            doc.Schemas.Add(nmspace[i], XmlReader.Create(new StringReader(schemas[i])));
        }
        doc.Schemas.Add("http://www.w3.org/2000/09/xmldsig#", XmlReader.Create(new StringReader(Resources.Schemas.XML.Sign)));

        // executando a validação
        doc.Validate(eventHandler);
        return _validationErrorsList;
    }

    private void ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        _validationErrorCount += 1;
        _validationErrorsList.Add($"{e.Severity} : {e.Message}");
        switch (e.Severity)
        {
            case XmlSeverityType.Error:
                Console.WriteLine("Error: {0}", e.Message);
                break;
            case XmlSeverityType.Warning:
                Console.WriteLine("Warning {0}", e.Message);
                break;
        }
    }

}
