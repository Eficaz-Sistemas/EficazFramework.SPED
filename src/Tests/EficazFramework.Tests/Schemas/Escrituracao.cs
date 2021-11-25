using System.IO;

namespace EficazFrameworkCore.SPED.Schemas;

internal class Escrituracao
{
    internal static Stream Read(string source)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(Sources.EFD_ICMS_IPI._2020_posto);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
}
