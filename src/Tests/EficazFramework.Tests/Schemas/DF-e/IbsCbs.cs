using System;
using EficazFramework.SPED.Tests;

namespace EficazFramework.SPED.Schemas.DFe.RTC;

internal class IbsCbs
{

    [Test]
    public async Task ParseLote()
    {
        var folder = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Samples", "IbsCbs");
        if (Directory.Exists(folder))
        {
            var files = Directory.GetFiles(folder, "*.xml");
            foreach (var file in files)
            {
                Console.WriteLine($"Processing file: {file}");
                var doc = await ReadAsync(await File.ReadAllTextAsync(file));
                doc.Should().NotBeNull();
                Console.WriteLine($"✅ Parsed document type: {doc.DocumentType}. Chave: {doc.Chave}");

                var action = doc.DocumentType switch
                {
                    XmlDocumentType.NFeWithProtocol => (Action)(() => ParseNFe(doc as EficazFramework.SPED.Schemas.NFe.ProcessoNFe)),
                    XmlDocumentType.NFeWithoutProtocol => (Action)(() => ParseNFe(new() { NFe = doc as EficazFramework.SPED.Schemas.NFe.NFe })),
                    object other => () => Assert.Fail($"Unexpected document type: {doc.DocumentType}")
                };
                action();
                Console.WriteLine("=============================================");
            }
        }
        else
        {
            Assert.Fail($"Test folder does not exist: {folder}");
        }
    }


    private void ParseNFe(EficazFramework.SPED.Schemas.NFe.ProcessoNFe doc)
    {
        foreach(var item in doc.NFe.InformacoesNFe.Items)
        {
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: Valor Mercadoria = {item.ValorItem}");
            item.Imposto.IBSCBS.Should().NotBeNull($"🛍️ Item {item.NumeroSequencial}: IBS/CBS tag group is null");
            item.Imposto.IBSCBS.gIBSCBS.gIBSMun.Should().NotBeNull($"🛍️ Item {item.NumeroSequencial}: IBS Mun tag group is null");
            item.Imposto.IBSCBS.gIBSCBS.gIBSUF.Should().NotBeNull($"🛍️ Item {item.NumeroSequencial}: IBS UF tag group is null");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: BC IBS/CBS: {item.Imposto.IBSCBS.gIBSCBS.vBC}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: IBS Mun %: {item.Imposto.IBSCBS.gIBSCBS.gIBSMun.pIBSMun}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: IBS Mun: {item.Imposto.IBSCBS.gIBSCBS.gIBSMun.vIBSMun}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: IBS UF %: {item.Imposto.IBSCBS.gIBSCBS.gIBSUF.pIBSUF}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: IBS UF: {item.Imposto.IBSCBS.gIBSCBS.gIBSUF.vIBSUF}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: CBS %: {item.Imposto.IBSCBS.gIBSCBS.gCBS.pCBS}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: CBS: {item.Imposto.IBSCBS.gIBSCBS.gCBS.vCBS}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: BC Monofásico: {item.Imposto.IBSCBS.gIBSCBSMono?.qBCMono?.ToString("n2") ?? "n/d"}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: Créd. Presumido / ZFM: {item.Imposto.IBSCBS.gCredPresIBSZFM?.vCredPresIBSZFM?.ToString("n2") ?? "n/d"}");
            Console.WriteLine($"***");
        }
    }


    /// <summary>
    /// Executa a leitura de um XML a partir de seu conteúdo em texto plano (string)
    /// </summary>
    internal static async Task<IXmlSpedDocument> ReadAsync(string xmlString)
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
    internal static async Task<IXmlSpedDocument> ReadAsync(Stream xmlStream)
    {
        IXmlSpedDocument document = await SPED.Utilities.XML.Operations.OpenAsync(xmlStream);
        return document;
    }


}