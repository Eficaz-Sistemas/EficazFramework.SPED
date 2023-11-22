using EficazFramework.SPED.Schemas;

namespace EficazFramework.SPED.Tests;

public class BaseXmlTest<T> : BaseTest where T : IXmlSpedDocument
{
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
}
