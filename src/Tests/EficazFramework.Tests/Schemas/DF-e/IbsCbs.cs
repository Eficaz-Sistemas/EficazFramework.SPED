using EficazFramework.SPED.Schemas.NFe;
using EficazFramework.SPED.Tests;
using System;

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
                    XmlDocumentType.CTeWithProtocol => (Action)(() => ParseCTe(doc as EficazFramework.SPED.Schemas.CTe.ProcessoCTe)),
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
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: IBS UF % Red: {item.Imposto.IBSCBS.gIBSCBS.gIBSUF.gRed?.pRedAliq}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: IBS UF % Efetivo: {item.Imposto.IBSCBS.gIBSCBS.gIBSUF.gRed?.pAliqEfet}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: IBS UF: {item.Imposto.IBSCBS.gIBSCBS.gIBSUF.vIBSUF}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: CBS %: {item.Imposto.IBSCBS.gIBSCBS.gCBS.pCBS}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: CBS UF % Red: {item.Imposto.IBSCBS.gIBSCBS.gCBS.gRed?.pRedAliq}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: CBS UF % Efetivo: {item.Imposto.IBSCBS.gIBSCBS.gCBS.gRed?.pAliqEfet}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: CBS: {item.Imposto.IBSCBS.gIBSCBS.gCBS.vCBS}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: BC Monofásico: {item.Imposto.IBSCBS.gIBSCBSMono?.qBCMono?.ToString("n2") ?? "n/d"}");
            Console.WriteLine($"🛍️ Item {item.NumeroSequencial}: Créd. Presumido / ZFM: {item.Imposto.IBSCBS.gCredPresIBSZFM?.vCredPresIBSZFM?.ToString("n2") ?? "n/d"}");
            Console.WriteLine($"***");
        }
    }

    private void ParseCTe(EficazFramework.SPED.Schemas.CTe.ProcessoCTe doc)
    {
        Console.WriteLine($"🛍️ Valor Prestação = {doc.CTe.Informacoes.Valores.vTPrest}");
        doc.CTe.Informacoes.Impostos.IBSCBS.Should().NotBeNull($"🛍️ IBS/CBS tag group is null");
        doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.gIBSMun.Should().NotBeNull($"🛍️ IBS Mun tag group is null");
        doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.gIBSUF.Should().NotBeNull($"🛍️ IBS UF tag group is null");
        Console.WriteLine($"🛍️ BC IBS/CBS: {doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.vBC}");
        Console.WriteLine($"🛍️ IBS Mun %: {doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.gIBSMun.pIBSMun}");
        Console.WriteLine($"🛍️ IBS Mun: {doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.gIBSMun.vIBSMun}");
        Console.WriteLine($"🛍️ IBS UF %: {doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.gIBSUF.pIBSUF}");
        Console.WriteLine($"🛍️ IBS UF % Red: {doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.gIBSUF.gRed?.pRedAliq}");
        Console.WriteLine($"🛍️ IBS UF % Efetivo: {doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.gIBSUF.gRed?.pAliqEfet}");
        Console.WriteLine($"🛍️ IBS UF: {doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.gIBSUF.vIBSUF}");
        Console.WriteLine($"🛍️ CBS %: {doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.gCBS.pCBS}");
        Console.WriteLine($"🛍️ CBS UF % Red: {doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.gCBS.gRed?.pRedAliq}");
        Console.WriteLine($"🛍️ CBS UF % Efetivo: {doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.gCBS.gRed?.pAliqEfet}");
        Console.WriteLine($"🛍️ CBS: {doc.CTe.Informacoes.Impostos.IBSCBS.gIBSCBS.gCBS.vCBS}");
        Console.WriteLine($"***");
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