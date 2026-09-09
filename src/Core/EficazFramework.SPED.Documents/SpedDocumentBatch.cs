using SchemaNFSe = EficazFramework.SPED.Schemas.NFSe.Nacional.NFSe;
using EficazFramework.SPED.Documents.CTe;
using EficazFramework.SPED.Documents.NFe;
using EficazFramework.SPED.Documents.NFSe;
using EficazFramework.SPED.Schemas.CTe;

namespace EficazFramework.SPED.Documents;

/// <summary>
/// Permite geração de PDF em lote para documentos fiscais heterogêneos
/// (NF-e, CT-e, NFS-e Nacional), unificando todos os documentos em um único PDF
/// (retornado em memória como byte[] ou gravado em Stream).
/// A numeração de folha reinicia em 1 para cada documento.
/// </summary>
/// <example>
/// <code>
/// var batch = new SpedDocumentBatch();
/// batch.Add(processoNFe1);
/// batch.Add(processoNFe2);
/// batch.Add(processoCTe);
/// batch.Add(nfse);
///
/// // Retorna todos os documentos unificados em um único PDF:
/// byte[] pdfBytes = batch.GerarPdf();
/// </code>
/// </example>
public sealed class SpedDocumentBatch
{
    private readonly List<Entry> _entries = [];

    // -------------------------------------------------------------------------
    // Add overloads — NF-e
    // -------------------------------------------------------------------------

    /// <summary>Adiciona uma NF-e ao lote.</summary>
    public SpedDocumentBatch Add(Schemas.NFe.ProcessoNFe processo, DanfeOptions? options = null)
    {
        _entries.Add(new Entry(processo, options ?? new DanfeOptions()));
        return this;
    }

    // -------------------------------------------------------------------------
    // Add overloads — CT-e
    // -------------------------------------------------------------------------

    /// <summary>Adiciona um CT-e ao lote.</summary>
    public SpedDocumentBatch Add(ProcessoCTe processo, DacteOptions? options = null)
    {
        _entries.Add(new Entry(processo, options ?? new DacteOptions()));
        return this;
    }

    // -------------------------------------------------------------------------
    // Add overloads — NFS-e Nacional
    // -------------------------------------------------------------------------

    /// <summary>Adiciona uma NFS-e Nacional ao lote.</summary>
    public SpedDocumentBatch Add(SchemaNFSe nfse, DanfseOptions? options = null)
    {
        _entries.Add(new Entry(nfse, options ?? new DanfseOptions()));
        return this;
    }

    // -------------------------------------------------------------------------
    // Geração do PDF Único (Renderização Individual + Mesclagem via PdfPig)
    // -------------------------------------------------------------------------

    /// <summary>
    /// Gera cada documento individualmente em PDF (garantindo que cada um tenha sua numeração
    /// de folha 100% isolada e independente) e mescla todas as páginas em memória em um único
    /// PDF via <see cref="UglyToad.PdfPig.Writer.PdfDocumentBuilder"/>, retornando os bytes resultantes.
    /// Não grava nenhum arquivo físico em disco.
    /// </summary>
    public byte[] GerarPdf()
    {
        if (_entries.Count == 0)
            return [];

        if (_entries.Count == 1)
            return CriarIDocument(_entries[0]).GeneratePdf();

        var builder = new UglyToad.PdfPig.Writer.PdfDocumentBuilder();
        foreach (var entry in _entries)
        {
            byte[] pdfBytes = CriarIDocument(entry).GeneratePdf();
            using var doc = UglyToad.PdfPig.PdfDocument.Open(pdfBytes);
            for (int i = 1; i <= doc.NumberOfPages; i++)
            {
                builder.AddPage(doc, i);
            }
        }
        return builder.Build();
    }

    /// <summary>
    /// Gera todos os documentos do lote unificados em um único PDF e grava no Stream fornecido.
    /// </summary>
    public void GerarPdf(Stream destino)
    {
        byte[] pdf = GerarPdf();
        destino.Write(pdf, 0, pdf.Length);
    }

    /// <summary>
    /// Gera os PDFs individuais de cada documento (caso necessário obter separadamente).
    /// </summary>
    public IEnumerable<byte[]> GerarPdfsIndividuais()
    {
        foreach (var entry in _entries)
            yield return CriarIDocument(entry).GeneratePdf();
    }

    /// <summary>Quantidade de documentos no lote.</summary>
    public int Count => _entries.Count;

    // -------------------------------------------------------------------------
    // Internos
    // -------------------------------------------------------------------------

    private static IDocument CriarIDocument(Entry entry) =>
        entry.Documento switch
        {
            Schemas.NFe.ProcessoNFe nfe => new DanfeDocument(nfe, (DanfeOptions)entry.Options),
            ProcessoCTe cte => new DacteDocument(cte, (DacteOptions)entry.Options),
            SchemaNFSe nfse => new DanfseDocument(nfse, (DanfseOptions)entry.Options),
            _ => throw new NotSupportedException(
                $"Tipo de documento não suportado: {entry.Documento.GetType().Name}")
        };

    private sealed record Entry(object Documento, object Options);
}
