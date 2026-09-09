using EficazFramework.SPED.Schemas.CTe;
using EficazFramework.SPED.Schemas.NFe;
using EficazFramework.SPED.Schemas.NFSe.Nacional;

namespace EficazFramework.Documents.Companion;

internal static class Helper
{
    internal static async Task<ProcessoNFe?> ObterNFeAsync(string fileName = "001.xml")
    {
        var path = Path.Combine(AppContext.BaseDirectory,"Samples", "NFe", fileName);
        var xml = await File.ReadAllTextAsync(path);
        using var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml));
        return (ProcessoNFe?)await EficazFramework.SPED.Utilities.XML.Operations.OpenAsync(ms);
    }

    internal static async Task<NFSe?> ObterNFSeAsync()
    {
        var folder = Path.Combine(AppContext.BaseDirectory, "Samples", "IbsCbs");
        if (!Directory.Exists(folder)) return null;

        foreach (var file in Directory.GetFiles(folder, "*.xml"))
        {
            var xml = await File.ReadAllTextAsync(file);
            using var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml));
            var doc = await EficazFramework.SPED.Utilities.XML.Operations.OpenAsync(ms);
            if (doc is NFSe nfse)
                return nfse;
        }
        return null;
    }

    internal static async Task<ProcessoCTe?> ObterCTeAsync()
    {
        var folder = Path.Combine(AppContext.BaseDirectory, "Samples", "IbsCbs");
        if (!Directory.Exists(folder)) return null;

        foreach (var file in Directory.GetFiles(folder, "*.xml"))
        {
            var xml = await File.ReadAllTextAsync(file);
            using var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml));
            var doc = await EficazFramework.SPED.Utilities.XML.Operations.OpenAsync(ms);
            if (doc is ProcessoCTe cte)
                return cte;
        }
        return null;
    }

}
