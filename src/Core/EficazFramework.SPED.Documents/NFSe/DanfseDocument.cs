using SchemaNFSe = EficazFramework.SPED.Schemas.NFSe.Nacional.NFSe;
using EficazFramework.SPED.Schemas.NFSe.Nacional;

namespace EficazFramework.SPED.Documents.NFSe;

/// <summary>
/// Documento QuestPDF que gera o DANFSE (Documento Auxiliar da NFS-e Nacional)
/// conforme layout Nacional versão 1.1 com suporte a IBS/CBS (Reforma Tributária).
/// </summary>
public sealed class DanfseDocument : IDocument
{
    // ── Paleta de cores ───────────────────────────────────────────────────────
    private const string CorPrimaria   = "#1a3a5c";
    private const string CorSecundaria = "#2e6da4";
    private const string CorBorda      = "#bdc3c7";
    private const string CorCabecalho  = "#d0dce8";
    private const string CorDestaque   = "#e8f1fa";

    private const float FonteRotulo = 6f;
    private const float FonteValor  = 8f;
    private const float FonteTitulo = 14f;

    private readonly SchemaNFSe _nfse;
    private readonly DanfseOptions _options;

    // Atalhos
    private InformacoesNfse? Info   => _nfse.InfNFSe;
    private InformacoesDps?  Dps    => Info?.DPS?.InfDPS;
    private InfoDpsPrestador? Prest => Dps?.Prestador;
    private InfoDpsTomadorOuIntermediario? Toma => Dps?.Tomador;
    private TotalValores? Vals      => Dps?.Valores;
    private Servico? Serv           => Dps?.Servico;

    static DanfseDocument()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public DanfseDocument(SchemaNFSe nfse, DanfseOptions options)
    {
        _nfse    = nfse;
        _options = options;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public DocumentSettings GetSettings() => DocumentSettings.Default;

    // =========================================================================
    // Compose
    // =========================================================================
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.MarginTop(4, Unit.Millimetre);
            page.MarginBottom(4, Unit.Millimetre);
            page.MarginLeft(6, Unit.Millimetre);
            page.MarginRight(6, Unit.Millimetre);
            page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(FonteValor));

            page.Header().Element(ComposeHeaderPrincipal);

            page.Content().PaddingTop(4).Column(col =>
            {
                col.Item().Element(ComposePrestador);
                col.Item().PaddingTop(3).Element(ComposeTomador);
                col.Item().PaddingTop(3).Element(ComposeDiscriminacao);
                col.Item().PaddingTop(3).Element(ComposeValores);
                col.Item().PaddingTop(3).Element(ComposeCompetenciaVerificacao);
            });

            page.Footer().Element(ComposeFooter);
        });
    }

    // =========================================================================
    // HEADER
    // =========================================================================
    private void ComposeHeaderPrincipal(IContainer c)
    {
        c.Border(0.5f).BorderColor(CorBorda).Column(col =>
        {
            // Linha 1: Logo | Título | Número NFS-e
            col.Item().Row(row =>
            {
                // Logo
                row.RelativeItem(2).Padding(3).AlignMiddle().AlignCenter().Column(logoCol =>
                {
                    var logo = _options.LogoPrestador;
                    if (logo is { Length: > 0 })
                        logoCol.Item().MaxHeight(40).Image(logo);
                    else
                        logoCol.Item().Text("NFS-e Nacional").Bold().FontSize(FonteValor).FontColor(CorPrimaria);
                });

                // Título
                row.RelativeItem(4).BorderLeft(0.5f).BorderColor(CorBorda).Padding(4).Column(tCol =>
                {
                    tCol.Item().AlignCenter().Text("NFS-e NACIONAL").Bold().FontSize(FonteTitulo).FontColor(CorPrimaria);
                    tCol.Item().AlignCenter().Text("Nota Fiscal de Serviço Eletrônica").FontSize(FonteRotulo);
                    if (Info?.LocalEmissao is not null)
                        tCol.Item().AlignCenter().Text($"Emissão: {Info.LocalEmissao}").FontSize(FonteRotulo);
                });

                // Número e ambiente
                row.RelativeItem(3).BorderLeft(0.5f).BorderColor(CorBorda).Padding(3).Column(nCol =>
                {
                    nCol.Item().Text("NÚMERO DA NFS-e").FontSize(FonteRotulo).Bold().FontColor(CorSecundaria);
                    nCol.Item().Text($"{Info?.Numero:D15}").FontSize(FonteValor + 2).Bold().FontColor(CorPrimaria);
                    nCol.Item().PaddingTop(3).Text("COMPETÊNCIA").FontSize(FonteRotulo).Bold().FontColor(CorSecundaria);
                    nCol.Item().Text(Dps?.Competencia ?? "-").FontSize(FonteValor);

                    if (_options.MostrarMarcaDagua)
                        nCol.Item().PaddingTop(2)
                           .Text("⚠ HOMOLOGAÇÃO - SEM VALOR FISCAL ⚠")
                           .FontSize(FonteRotulo).Bold().FontColor("#e74c3c");
                });
            });
        });
    }

    // =========================================================================
    // PRESTADOR
    // =========================================================================
    private void ComposePrestador(IContainer c)
    {
        var endNac = Prest?.end?.Nacional;
        c.Border(0.5f).BorderColor(CorBorda).Padding(3).Column(col =>
        {
            Rotulo(col, "PRESTADOR DE SERVIÇOS");
            col.Item().Text(Prest?.xNome ?? string.Empty).Bold().FontSize(FonteValor);
            col.Item().Row(row =>
            {
                CelulaLabel(row.RelativeItem(3), "CNPJ / CPF",
                    Prest?.Cnpj?.FormatCNPJ() ?? Prest?.CPF?.FormatCPF());
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(2), "INSCRIÇÃO MUNICIPAL", Prest?.InscricaoMunicipal);
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(2), "TELEFONE", Prest?.Telefone);
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(3), "E-MAIL", Prest?.Email);
            });
            if (endNac is not null)
                col.Item().PaddingTop(1).Text(
                    $"{endNac.Logradouro}, {endNac.Numero}" +
                    (string.IsNullOrEmpty(endNac.xCpl) ? "" : $", {endNac.xCpl}") +
                    $" - {endNac.Bairro} - {endNac.MunicipioCodigo}/{endNac.UF} - CEP {endNac.CEP}")
                    .FontSize(FonteRotulo);
        });
    }

    // =========================================================================
    // TOMADOR
    // =========================================================================
    private void ComposeTomador(IContainer c)
    {
        if (Toma is null) return;
        var end = Toma.Endereco?.Nacional;
        c.Border(0.5f).BorderColor(CorBorda).Padding(3).Column(col =>
        {
            Rotulo(col, "TOMADOR DE SERVIÇOS");
            col.Item().Text(Toma.xNome ?? string.Empty).Bold().FontSize(FonteValor);
            col.Item().Row(row =>
            {
                CelulaLabel(row.RelativeItem(3), "CNPJ / CPF",
                    Toma.CNPJ?.FormatCNPJ() ?? Toma.CPF?.FormatCPF());
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(2), "INSCRIÇÃO MUNICIPAL", Toma.IM);
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(3), "E-MAIL", Toma.email);
            });
            if (end is not null)
                col.Item().PaddingTop(1).Text(
                    $"{end.Logradouro}, {end.Numero} - {end.Bairro} - {end.MunicipioCodigo}/{end.UF} - CEP {end.CEP}")
                    .FontSize(FonteRotulo);
        });
    }

    // =========================================================================
    // DISCRIMINAÇÃO DO SERVIÇO
    // =========================================================================
    private void ComposeDiscriminacao(IContainer c)
    {
        var infoServ = Serv?.InfoServico;
        c.Border(0.5f).BorderColor(CorBorda).Padding(3).Column(col =>
        {
            Rotulo(col, "DISCRIMINAÇÃO DO SERVIÇO");
            col.Item().Row(row =>
            {
                CelulaLabel(row.RelativeItem(2), "CÓD. TRIB. MUNICIPAL", infoServ?.cTribMun);
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(2), "CÓD. TRIBUTAÇÃO NAC.", infoServ?.CodigoTribNacional);
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(1), "NBS", infoServ?.NBS);
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(4), "DESCRIÇÃO", infoServ?.Descricao);
            });
            var locPrest = Serv?.LocalPrestacao;
            if (locPrest is not null)
            {
                col.Item().LineHorizontal(0.3f).LineColor(CorBorda);
                col.Item().Row(row =>
                {
                    CelulaLabel(row.RelativeItem(3), "CÓD. MUNICÍPIO PRESTAÇÃO", locPrest.Codigo);
                    BordaVertical(row);
                    CelulaLabel(row.RelativeItem(3), "CÓD. PAÍS PRESTAÇÃO", locPrest.cPaisPrestacao);
                });
            }
        });
    }

    // =========================================================================
    // VALORES
    // =========================================================================
    private void ComposeValores(IContainer c)
    {
        var vServ = Vals?.ValoresPrestacao;
        var trib = Vals?.Tributos;
        var tribMun = trib?.Municipais;
        var descCond = Vals?.vDescCondIncond;
        var dedRed = Vals?.vDedRed;

        c.Border(0.5f).BorderColor(CorBorda).Column(col =>
        {
            Rotulo(col, "VALORES DO SERVIÇO");

            // Linha 1: Valor Serviço | Descontos | Deduções | Base de Cálculo
            col.Item().Row(row =>
            {
                CelulaLabel(row.RelativeItem(), "VALOR DOS SERVIÇOS",
                    $"R$ {vServ?.ValorServico:N2}");
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(), "DESCONTOS INCOND.",
                    $"R$ {descCond?.vDescIncond:N2}");
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(), "DEDUÇÕES/REDUÇÕES",
                    $"R$ {dedRed?.vDR:N2}");
                BordaVertical(row);
                // Base de cálculo = Valor Serviço - Descontos - Deduções
                var bc = (vServ?.ValorServico ?? 0) - (descCond?.vDescIncond ?? 0) - (dedRed?.vDR ?? 0);
                CelulaLabel(row.RelativeItem(), "BASE DE CÁLCULO ISSQN",
                    $"R$ {bc:N2}");
            });

            col.Item().LineHorizontal(0.3f).LineColor(CorBorda);

            // Linha 2: Alíquota | ISSQN | Valor Líquido | Recebido
            col.Item().Row(row =>
            {
                CelulaLabel(row.RelativeItem(), "ALÍQUOTA ISS (%)",
                    $"{Info?.Valores?.IssqnAliquota:N4}%");
                BordaVertical(row);

                // O ISSQN vem de InformacoesNfse.Valores.IssqnValor
                CelulaLabel(row.RelativeItem(), "VALOR ISS",
                    $"R$ {Info?.Valores?.IssqnValor:N2}");
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(), "RETIDO ISS",
                    tribMun?.TipoRetencao == "1" ? "SIM" : "NÃO");
                BordaVertical(row);
                CelulaLabel(row.RelativeItem(), "VALOR LÍQUIDO",
                    $"R$ {Info?.Valores?.ValorTotalLiquido:N2}");
            });

            // Bloco IBS/CBS — Reforma Tributária
            var ibsCbs = Info?.IBSCBS;
            if (ibsCbs is not null)
            {
                col.Item().LineHorizontal(0.3f).LineColor(CorBorda);
                col.Item().Background(CorDestaque).Padding(2).PaddingLeft(4)
                   .Text("REFORMA TRIBUTÁRIA — IBS / CBS (Leiaute Nacional v1.1)")
                   .FontSize(FonteRotulo).Bold().FontColor(CorPrimaria);
                col.Item().Row(row =>
                {
                    var vals2 = ibsCbs.valores;
                    CelulaLabel(row.RelativeItem(), "BASE CÁLC. IBS/CBS",
                        $"R$ {vals2?.vBC:N2}");
                    BordaVertical(row);
                    CelulaLabel(row.RelativeItem(), "ALÍQ. IBS UF",
                        $"{vals2?.uf?.pAliqEfetUF:N4}%");
                    BordaVertical(row);
                    CelulaLabel(row.RelativeItem(), "ALÍQ. IBS MUN",
                        $"{vals2?.mun?.pAliqEfetMun:N4}%");
                    BordaVertical(row);
                    CelulaLabel(row.RelativeItem(), "ALÍQ. CBS FED",
                        $"{vals2?.fed?.pAliqEfetCBS:N4}%");
                    BordaVertical(row);
                    CelulaLabel(row.RelativeItem(), "TOTAL NF (c/ IBS/CBS)",
                        $"R$ {ibsCbs.totCIBS?.vTotNF:N2}");
                });
            }
        });
    }

    // =========================================================================
    // COMPETÊNCIA / REGIME / CÓDIGO VERIFICAÇÃO
    // =========================================================================
    private void ComposeCompetenciaVerificacao(IContainer c)
    {
        var regTrib = Prest?.RegimeTributario;
        c.Border(0.5f).BorderColor(CorBorda).Row(row =>
        {
            CelulaLabel(row.RelativeItem(2), "COMPETÊNCIA", Dps?.Competencia);
            BordaVertical(row);
            CelulaLabel(row.RelativeItem(2), "REGIME TRIBUTÁRIO",
                regTrib?.OptanteSimplesNacional is not null ? $"Simples Nacional ({regTrib.OptanteSimplesNacional})" :
                regTrib?.RegimeEspecial is not null ? $"Regime Especial ({regTrib.RegimeEspecial})" : "-");
            BordaVertical(row);
            CelulaLabel(row.RelativeItem(2), "DATA/HORA EMISSÃO",
                Dps?.DataHoraEmissao?.ToString("dd/MM/yyyy HH:mm:ss") ?? "-");
            BordaVertical(row);
            CelulaLabel(row.RelativeItem(2), "SÉRIE DPS", Dps?.Serie);
            BordaVertical(row);
            CelulaLabel(row.RelativeItem(1), "Nº DPS", $"{Dps?.Numero}");
        });
    }

    // =========================================================================
    // FOOTER
    // =========================================================================
    private void ComposeFooter(IContainer c)
    {
        c.Row(row =>
        {
            row.RelativeItem().Text(_options.MensagemRodape ?? string.Empty)
               .FontSize(FonteRotulo).Italic();
            row.ConstantItem(60).AlignRight().Column(col =>
                col.Item().Text(ctx =>
                {
                    ctx.Span("Folha ").FontSize(FonteRotulo);
                    ctx.CurrentPageNumber().FontSize(FonteRotulo).Bold();
                    ctx.Span(" / ").FontSize(FonteRotulo);
                    ctx.TotalPages().FontSize(FonteRotulo).Bold();
                }));
        });
    }

    // =========================================================================
    // Helpers
    // =========================================================================

    private static void Rotulo(ColumnDescriptor col, string texto) =>
        col.Item().Background(CorCabecalho).Padding(1).PaddingLeft(3)
           .Text(texto).FontSize(FonteRotulo).Bold().FontColor(CorPrimaria);

    private static void CelulaLabel(
        IContainer cell, string rotulo, string? valor) =>
        cell.Column(col =>
        {
            col.Item().Padding(1).PaddingLeft(2)
               .Text(rotulo).FontSize(FonteRotulo).FontColor("#666666");
            col.Item().Padding(1).PaddingLeft(2)
               .Text(valor ?? "-").FontSize(FonteValor);
        });

    private static void BordaVertical(RowDescriptor row) =>
        row.ConstantItem(0.5f).Background(CorBorda);
}

// ── Extensões internas de formatação ─────────────────────────────────────────
file static class StringExtensionsNFSe
{
    internal static string FormatCNPJ(this string? s) =>
        s?.Length == 14
        ? $"{s[..2]}.{s[2..5]}.{s[5..8]}/{s[8..12]}-{s[12..14]}"
        : s ?? string.Empty;

    internal static string FormatCPF(this string? s) =>
        s?.Length == 11
        ? $"{s[..3]}.{s[3..6]}.{s[6..9]}-{s[9..11]}"
        : s ?? string.Empty;
}
