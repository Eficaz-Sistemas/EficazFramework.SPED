using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AwesomeAssertions;
using EficazFramework.SPED.Documents;
using EficazFramework.SPED.Documents.CTe;
using EficazFramework.SPED.Documents.NFe;
using EficazFramework.SPED.Documents.NFSe;
using EficazFramework.SPED.Schemas.CTe;
using EficazFramework.SPED.Schemas.NFe;
using EficazFramework.SPED.Schemas.NFSe.Nacional;
using NUnit.Framework;

namespace EficazFramework.SPED.Tests.Documents;

[TestFixture]
public class DocumentTests : BaseTest
{
    private static async Task<ProcessoNFe> ObterNFeAsync(string fileName = "001.xml")
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Samples", "NFe", fileName);
        var xml = await File.ReadAllTextAsync(path);
        using var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml));
        return (ProcessoNFe)await Utilities.XML.Operations.OpenAsync(ms);
    }

    private static async Task<NFSe> ObterNFSeAsync()
    {
        var xml = Resources.Schemas.XML.NFSe_Nacional_1_0_1;
        using var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml));
        return (NFSe)await Utilities.XML.Operations.OpenAsync(ms);
    }

    private static async Task<ProcessoCTe?> ObterCTeAsync()
    {
        var folder = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Samples", "IbsCbs");
        if (!Directory.Exists(folder)) return null;

        foreach (var file in Directory.GetFiles(folder, "*.xml"))
        {
            var xml = await File.ReadAllTextAsync(file);
            using var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml));
            var doc = await Utilities.XML.Operations.OpenAsync(ms);
            if (doc is ProcessoCTe cte)
                return cte;
        }
        return null;
    }

    // =========================================================================
    // DANFE (NF-e)
    // =========================================================================

    [Test]
    public async Task GerarDanfeRetratoNFe001()
    {
        var nfe = await ObterNFeAsync("001.xml");
        nfe.Should().NotBeNull();

        byte[] pdf = nfe.GerarDanfe();
        pdf.Should().NotBeNull();
        pdf.Length.Should().BeGreaterThan(1000);

        // Verifica magic number PDF (%PDF)
        System.Text.Encoding.ASCII.GetString(pdf[..4]).Should().Be("%PDF");

        using var pdfDoc = UglyToad.PdfPig.PdfDocument.Open(pdf);
        var pageText = pdfDoc.GetPage(1).Text;
        pageText.Should().Contain("DADOS DOS PRODUTOS / SERVIÇOS");
    }

    [Test]
    public async Task GerarDanfeComStream()
    {
        var nfe = await ObterNFeAsync("001.xml");
        using var ms = new MemoryStream();
        nfe.GerarDanfe(ms);

        ms.Length.Should().BeGreaterThan(1000);
        var bytes = ms.ToArray();
        System.Text.Encoding.ASCII.GetString(bytes[..4]).Should().Be("%PDF");
    }

    [Test]
    public async Task GerarDanfeNFe004ComItensEMultiPaginacao()
    {
        var nfe = await ObterNFeAsync("004.xml");
        nfe.Should().NotBeNull();

        byte[] pdf = nfe.GerarDanfe();
        pdf.Should().NotBeNull();
        pdf.Length.Should().BeGreaterThan(1000);
        System.Text.Encoding.ASCII.GetString(pdf[..4]).Should().Be("%PDF");
    }

    [Test]
    public async Task GerarDanfeComMuitosItensDeveRepetirHeaderFooterEIncrementarFolhaNoHeader()
    {
        var nfe = await ObterNFeAsync("001.xml");
        nfe.Should().NotBeNull();

        // Duplica itens para forçar paginação (ex: 80 itens)
        var itemBase = nfe.NFe.InformacoesNFe.Items[0];
        for (int i = 0; i < 80; i++)
        {
            nfe.NFe.InformacoesNFe.Items.Add(itemBase);
        }

        byte[] pdf = nfe.GerarDanfe();
        pdf.Should().NotBeNull();

        using var pdfDoc = UglyToad.PdfPig.PdfDocument.Open(pdf);
        pdfDoc.NumberOfPages.Should().BeGreaterThanOrEqualTo(2);

        // Verifica que no Header de cada página aparece "FOLHA {page} / {total}"
        for (int p = 1; p <= pdfDoc.NumberOfPages; p++)
        {
            var page = pdfDoc.GetPage(p);
            var text = page.Text;
            text.Should().Contain($"FOLHA {p} / {pdfDoc.NumberOfPages}");
            // E o Footer também está presente em todas as páginas (Transporte / Totais)
            text.Should().Contain("DADOS DO TRANSPORTE");
            text.Should().Contain("CÁLCULO DO IMPOSTO");
        }
    }

    // =========================================================================
    // DANFSE (NFS-e Nacional)
    // =========================================================================

    [Test]
    public async Task GerarDanfseNacional()
    {
        var nfse = await ObterNFSeAsync();
        nfse.Should().NotBeNull();

        byte[] pdf = nfse.GerarDanfse();
        pdf.Should().NotBeNull();
        pdf.Length.Should().BeGreaterThan(1000);
        System.Text.Encoding.ASCII.GetString(pdf[..4]).Should().Be("%PDF");
    }

    [Test]
    public async Task GerarDanfseNacionalComStream()
    {
        var nfse = await ObterNFSeAsync();
        using var ms = new MemoryStream();
        nfse.GerarDanfse(ms);

        ms.Length.Should().BeGreaterThan(1000);
        System.Text.Encoding.ASCII.GetString(ms.ToArray()[..4]).Should().Be("%PDF");
    }

    // =========================================================================
    // DACTE (CT-e)
    // =========================================================================

    [Test]
    public async Task GerarDacteSeCTeExistir()
    {
        var cte = await ObterCTeAsync();
        if (cte is null)
        {
            Assert.Ignore("Nenhum XML de teste com ProcessoCTe encontrado nos samples.");
            return;
        }

        byte[] pdf = cte.GerarDacte();
        pdf.Should().NotBeNull();
        pdf.Length.Should().BeGreaterThan(1000);
        System.Text.Encoding.ASCII.GetString(pdf[..4]).Should().Be("%PDF");
    }

    // =========================================================================
    // SPED DOCUMENT BATCH (Geração em lote unificada em PDF único)
    // =========================================================================

    [Test]
    public async Task GerarPdfUnicoBatchHeterogeneo()
    {
        var nfe1 = await ObterNFeAsync("001.xml");
        var nfe2 = await ObterNFeAsync("004.xml");
        var nfse = await ObterNFSeAsync();
        var cte = await ObterCTeAsync();

        var batch = new SpedDocumentBatch();
        batch.Add(nfe1);
        batch.Add(nfe2);
        batch.Add(nfse);
        if (cte is not null)
            batch.Add(cte);

        batch.Count.Should().Be(cte is not null ? 4 : 3);

        // Gera todos no mesmo PDF unificado (em memória como byte[])
        byte[] pdfUnico = batch.GerarPdf();
        pdfUnico.Should().NotBeNull();
        pdfUnico.Length.Should().BeGreaterThan(5000);
        System.Text.Encoding.ASCII.GetString(pdfUnico[..4]).Should().Be("%PDF");

        using var pdfDoc = UglyToad.PdfPig.PdfDocument.Open(pdfUnico);
        foreach (var page in pdfDoc.GetPages())
        {
            TestContext.Out.WriteLine($"Página {page.Number}: texto final -> {string.Join(" ", page.GetWords().TakeLast(10).Select(w => w.Text))}");
        }
    }

    [Test]
    public async Task GerarPdfUnicoComStream()
    {
        var nfe = await ObterNFeAsync("001.xml");
        var nfse = await ObterNFSeAsync();

        var batch = new SpedDocumentBatch();
        batch.Add(nfe);
        batch.Add(nfse);

        using var ms = new MemoryStream();
        batch.GerarPdf(ms);

        ms.Length.Should().BeGreaterThan(3000);
        System.Text.Encoding.ASCII.GetString(ms.ToArray()[..4]).Should().Be("%PDF");
    }

    [Test]
    public async Task GerarPdfsIndividuaisBatch()
    {
        var nfe = await ObterNFeAsync("001.xml");
        var nfse = await ObterNFSeAsync();

        var batch = new SpedDocumentBatch();
        batch.Add(nfe);
        batch.Add(nfse);

        var pdfs = batch.GerarPdfsIndividuais().ToList();
        pdfs.Count.Should().Be(2);
        foreach (var pdf in pdfs)
        {
            pdf.Should().NotBeNull();
            pdf.Length.Should().BeGreaterThan(1000);
            System.Text.Encoding.ASCII.GetString(pdf[..4]).Should().Be("%PDF");
        }
    }
}
